#include <math.h>
#include <stdio.h>
#include <intrin.h>
#include <windows.h>

// ��������� ������ �������: ����� �� lat_mem_rd
int step(int k) {
    if(k < 1024) k = k * 2;
    else if(k < 4*1024) k += 1024;
    else {
        int s;
        for (s = 32*1024; s <= k; s *= 2)	;
        k += s / 16;
    }
    return k;
}

#define TWICE(x) x x
#define MB (1024*1024)

int main()
{
    // ����������� �������� �������
    LARGE_INTEGER perfcnt1, perfcnt2; __int64 tsc1, tsc2;
    QueryPerformanceCounter(&perfcnt1); tsc1=__rdtsc();
    // �������� (�� ����������� ����� ���������)
    Sleep(500);
    // �����
    QueryPerformanceCounter(&perfcnt2); tsc2=__rdtsc();
    perfcnt2.QuadPart -= perfcnt1.QuadPart;
    QueryPerformanceFrequency(&perfcnt1);
    // ���������
    const double MHz = (double)(tsc2-tsc1)*perfcnt1.QuadPart/perfcnt2.QuadPart/1e6;
    printf("Clock rate: %.0f MHz\n", MHz);

    // ����� ������� ������� � ������
    // ���������� � �������������� �������� �������
    typedef struct segment_t segment;
    struct segment_t {
        int size_l, size_r;  // ������� ����, � ������
        double level, total; // ����� �������, � ������
        int width;			 // ������, � ���������� ������
        segment* next;
    };
    // ������ � ���������� ��������� ����
    typedef struct {
        int step_size_bytes;
        segment data;
    } segments;

    // ������� ����� ������� ����
    segments allsegs[]={{128}, {256}, {512}, {1024}, {2048}, {4096}, {0}};
    for(segments *cursegs = allsegs;
            int step_size = cursegs->step_size_bytes/sizeof(void*);
            cursegs++) {

        printf("\rTesting stride: %d          \n", cursegs->step_size_bytes);

        int iters = 1<<28; // ��������� � ������� �� ������ �������
        int state = 0;	   // ��������� ��������� - ������� ���������
        segment* curseg = &(cursegs->data); // ������� �������

        // ���������� ��� ������� �������, � ���������� �� ���
        int a_size_bytes, b_size_bytes;
        double a, b; 

        // �� ������ �������� ������� ����� ���������� �� ������� ������
        for(int arr_size_bytes = 1<<12; arr_size_bytes <= 1<<29;
                                        arr_size_bytes = step(arr_size_bytes)) {
            const int arr_size = arr_size_bytes / sizeof(void*);

            void **x = (void**)malloc(arr_size_bytes); // �������� ������

            // ��������� ������ ����������� � ����� step_size
            int k;
            for(k = 0; k < arr_size; k += step_size) {
                x[k] = x + k + step_size;
            }
            x[k-step_size] = x;
            const int arr_iters = k / step_size; // ����� ����������� ��������� �������

            // �� ������ ������ ������ �������� �� �������
            if(iters < 4*arr_iters) iters = 4*arr_iters;

            // ��������� ��� ��������� � ������� � �������� �����
            void **p = x;

            // ������� ������ �� ���������� ������
            const __int64 ticks_start = __rdtsc();

            // �������� ���� -- ��� ����� ���������� �� ��������
            for(int j = 0; j < iters; j+=256) {
                TWICE(TWICE(TWICE(TWICE(TWICE(TWICE(TWICE(TWICE( p=(void**)*p; ))))))))
            }

            // ������� ������ ����� ���������� ������
            const __int64 ticks_end = __rdtsc();

            // ���������� ����������� ������ ����������, � ������� �� ���� ���������
            // ������ �� !!p (�������), ����� ����������� �� ������� � ��� ��������������
            const double cycles = (double)!!p * (ticks_end-ticks_start) / iters;

            // ����������� �����������
            printf("\r%f MB - %.2f cycles    ", (double)arr_size_bytes/MB, cycles);

            free(x); // ����������� ������

            // ������������� ����� ��������, ����� ������ ������ ������� ������ �������
            while(cycles/MHz*iters > 1e6) iters >>= 1;

            // ����� ���� ���������?
            if(!state && (curseg->width>2) && (fabs(a-curseg->level)<(a*.1)) &&
                    (b>(curseg->level*1.1)) && (cycles>(curseg->level*1.1))) {
                curseg->size_r = a_size_bytes;
                curseg = curseg->next = (segment*)calloc(1, sizeof(segment));
                state = 1;
                b = 0; // ������ ���� ������ ���� ������ ������ ������
            }
            // ������ ���� ���������?
            if(state && (fabs(cycles-a)<(a*.1)) && (fabs(cycles-b)<(b*.1))) {
                curseg->size_l = a_size_bytes;
                state = 0;
            }
            // ������ ��� ����� ��������� ������
            if(!state && ((curseg->width<=2) || (fabs(cycles-curseg->level)<cycles*.1))) {
                curseg->total += cycles;
                curseg->width++;
                curseg->level = curseg->total / curseg->width;
            }
            // ������� ������� ������� �� ���������?
            if(!state && (cycles<curseg->level*.9) && (fabs(cycles-a)<(a*.1)) && (fabs(cycles-b)<(b*.1))) {
                curseg->total = a + b + cycles;
                curseg->width = 3;
                curseg->level = curseg->total / curseg->width;
            }

            // �������� �������
            a_size_bytes = b_size_bytes; b_size_bytes = arr_size_bytes;
            a = b; b = cycles;
        }
    }

    // ������ ���������� ������
    int TLB = 0; // ��������� ������������������ ������� -- TLB?
    for(int cache_level = 1;;cache_level++) {

        // ������ � ����� ������� � ����
        int cache_size = allsegs[0].data.size_r, step_count = 0;
        if(!cache_size) break; // ����� ������ ������� (�������� ������)

        double latency, total = 0;
        if(TLB) // ����� ������� � ���� ���������� ������ ��� ����������
            cache_level--;
        else
            latency = allsegs[0].data.level;

        int less=0, same=0, more=0; // ��� ����������� ������� "�� ����"

        // ��� ���� ������������� �������� ����
        for(segments *cursegs = allsegs; cursegs->step_size_bytes; cursegs++) {
            segment* next = cursegs->data.next; // ��������� ������� ����
            if(!next) { // � ������� �������� ����, ���������� �� �������� ������
                printf("Missing results for L%d! Step size %d, array size %f MB\n",
                        cache_level, cursegs->step_size_bytes, (double)cursegs->data.size_l/MB);
                cache_size = 0;
                break;
            }
            // ���� ��������� ������� ���� ����������, ���������
            while(fabs(cursegs->data.level-next->level)<cursegs->data.level*.2) {
                cursegs->data.size_r = next->size_r;
                cursegs->data.total += next->total;
                cursegs->data.width += next->width;
                cursegs->data.level = cursegs->data.total / cursegs->data.width;
                cursegs->data.next = next->next;
                free(next);
                next = cursegs->data.next;
                // ���������������
                if(cursegs==allsegs) {
                    cache_size = cursegs->data.size_r;
                    if(!TLB) latency = cursegs->data.level;
                }
            }
            // ���� ��������� ��������� ������� � ���������
            if(cursegs->data.size_r == cache_size)
                same++;
            // ���� ��������� ��������� ���� ���������� �� ���������
            else if(cursegs->data.size_r == step(cache_size))
                more++;
            else if(step(cursegs->data.size_r) == cache_size)
                less++;
            // ���� ��������� ������� ����� ���������: ������ TLB
            else if(cursegs->data.size_r < cache_size/2) {
                // ���������� �� ��� ��� ������ -- �����������
                cache_size = cursegs->data.size_r;
                more = less = 0; same = 1;
                // ������� ��������� ��������� � ��� �� �������
                for(segments *prevsegs = allsegs; prevsegs<cursegs; prevsegs++) {
                    segment* second = (segment*)malloc(sizeof(segment));
                    *second = prevsegs->data;
                    prevsegs->data.next = second;
                    prevsegs->data.size_r = second->size_l = cache_size;
                }
            }
            // ���� ������������ �������� ������, ��� ���������
            if(less>same) {
                cache_size = cursegs->data.size_r;
                more = same; same = less; less = 0;
            } else if (more>same) {
                cache_size = cursegs->data.size_r;
                less = same; same = more; more = 0;
            }
            if(!TLB && fabs(latency-cursegs->data.level)<latency*.1) {
                total += cursegs->data.level;
                latency = total / ++step_count;
            }
        }
        if(!cache_size) break; // ����������� ������� ���� �� �������

        // ��������������� ���� � ��������� TLB
        int min_way_size = 0, max_way_size = 0, next_step_at = 2*cache_size;
        // ��������, ����������� �������� ������� � TLB
        double additional = (allsegs[0].data.next->level - latency) / 2;
        if(additional<0) additional=0; // � �������� �����������
        TLB = 1; // ������� �� TLB, ���� �� �������� � ���������
        for(segments *cursegs = allsegs; cursegs->step_size_bytes; cursegs++) {
            segment* next = cursegs->data.next; // ��������� ������� ����
            // ���� ��� ��� ���������, ����� ������� �������� ���������
            if(cursegs->data.size_r <= cache_size) {
                if(max_way_size && (max_way_size != next->size_l - cache_size)) {
                    printf("Inconsistent results for L%d! Step size %d, array size %f MB\n",
                            cache_level, cursegs->step_size_bytes, (double)next->size_l/MB);
                }
                min_way_size = cursegs->step_size_bytes; // ��� �� ������ ���
                max_way_size = next->size_l - cache_size; // ������ ��� -- ������ ���������
                // ���� ��������� �� ������������, ������ �������� ������ ������ ���
                if(next->size_l > step(cache_size)) min_way_size = max_way_size;
            // ��� ������������ ����, ��������� �������� ����� ������
            } else if(cursegs->data.size_r > step(cache_size)) {
                if(cursegs->data.size_r != next_step_at)
                    printf("Inconsistent results for L%d! Step size %d, array size %f MB\n",
                            cache_level, cursegs->step_size_bytes, (double)cursegs->data.size_r/MB);
                if (!max_way_size)
                    max_way_size = cursegs->step_size_bytes / 2; // ��� ��� ������� � ��� ���
                next_step_at *= 2; // ��������� ��������� ������ ���� ��� ����� ������
            }

            // ������ �� TLB, ���� �������������� �������� ����������� ��� �������� ����
            double new_additional = cursegs->data.next->level - latency;
            if((fabs(new_additional - additional*2) < new_additional*.1) ||	(additional<latency*.1))
                additional = new_additional;
            else // �� ������ �� TLB
                TLB = 0;

            // ��������� � ������ ���������
            cursegs->data = *next;
            free(next);
        }
        if(TLB)
            printf("TLB size: %d, latency: %.2f cycles (%.2f ns)\n"
                   "    way size: min. %d, max. %d\n",
                cache_size/4096, additional/2, (additional/2)/MHz*1000,
                min_way_size/4096, max_way_size/4096);
        else
            printf("L%d size: %d KB, latency: %.2f cycles (%.2f ns)\n"
                   "   way size: min. %d KB, max. %d KB\n",
                cache_level, cache_size/1024, latency, latency/MHz*1000,
                min_way_size/1024, max_way_size/1024);
    }
    return 0;
}