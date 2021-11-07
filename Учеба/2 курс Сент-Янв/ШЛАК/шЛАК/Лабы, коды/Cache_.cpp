#include <math.h>
#include <stdio.h>
#include <intrin.h>
#include <windows.h>

// следующий размер массива: взято из lat_mem_rd
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
    // ОПРЕДЕЛЕНИЕ ТАКТОВОЙ ЧАСТОТЫ
    LARGE_INTEGER perfcnt1, perfcnt2; __int64 tsc1, tsc2;
    QueryPerformanceCounter(&perfcnt1); tsc1=__rdtsc();
    // нагрузка (не обязательно нашим процессом)
    Sleep(500);
    // замер
    QueryPerformanceCounter(&perfcnt2); tsc2=__rdtsc();
    perfcnt2.QuadPart -= perfcnt1.QuadPart;
    QueryPerformanceFrequency(&perfcnt1);
    // результат
    const double MHz = (double)(tsc2-tsc1)*perfcnt1.QuadPart/perfcnt2.QuadPart/1e6;
    printf("Clock rate: %.0f MHz\n", MHz);

    // ЗАМЕР ВРЕМЕНИ ДОСТУПА К ПАМЯТИ
    // информация о горизонтальном сегменте графика
    typedef struct segment_t segment;
    struct segment_t {
        int size_l, size_r;  // размеры краёв, в байтах
        double level, total; // время доступа, в циклах
        int width;			 // ширина, в замеренных точках
        segment* next;
    };
    // график с постоянной величиной шага
    typedef struct {
        int step_size_bytes;
        segment data;
    } segments;

    // пробуем шесть величин шага
    segments allsegs[]={{128}, {256}, {512}, {1024}, {2048}, {4096}, {0}};
    for(segments *cursegs = allsegs;
            int step_size = cursegs->step_size_bytes/sizeof(void*);
            cursegs++) {

        printf("\rTesting stride: %d          \n", cursegs->step_size_bytes);

        int iters = 1<<28; // обращений к массиву на каждом проходе
        int state = 0;	   // начальное состояние - снаружи ступеньки
        segment* curseg = &(cursegs->data); // текущий сегмент

        // предыдущие два размера массива, и результаты на них
        int a_size_bytes, b_size_bytes;
        double a, b; 

        // на каждой итерации данного цикла выделяется всё большая память
        for(int arr_size_bytes = 1<<12; arr_size_bytes <= 1<<29;
                                        arr_size_bytes = step(arr_size_bytes)) {
            const int arr_size = arr_size_bytes / sizeof(void*);

            void **x = (void**)malloc(arr_size_bytes); // выделяем память

            // заполняем память указателями с шагом step_size
            int k;
            for(k = 0; k < arr_size; k += step_size) {
                x[k] = x + k + step_size;
            }
            x[k-step_size] = x;
            const int arr_iters = k / step_size; // число заполненных элементов массива

            // не меньше четырёх полных проходов по массиву
            if(iters < 4*arr_iters) iters = 4*arr_iters;

            // указатель для обращения к массиву в основном цикле
            void **p = x;

            // счётчик тактов до выполнения команд
            const __int64 ticks_start = __rdtsc();

            // основной цикл -- его время выполнения мы замеряем
            for(int j = 0; j < iters; j+=256) {
                TWICE(TWICE(TWICE(TWICE(TWICE(TWICE(TWICE(TWICE( p=(void**)*p; ))))))))
            }

            // счётчик тактов после выполнения команд
            const __int64 ticks_end = __rdtsc();

            // количество затраченных тактов процессора, в среднем на одно обращение
            // множим на !!p (единицу), чтобы оптимизатор не выкинул её как неиспользуемую
            const double cycles = (double)!!p * (ticks_end-ticks_start) / iters;

            // отображение результатов
            printf("\r%f MB - %.2f cycles    ", (double)arr_size_bytes/MB, cycles);

            free(x); // освобождаем память

            // скорректируем число итераций, чтобы каждый проход занимал меньше секунды
            while(cycles/MHz*iters > 1e6) iters >>= 1;

            // левый край ступеньки?
            if(!state && (curseg->width>2) && (fabs(a-curseg->level)<(a*.1)) &&
                    (b>(curseg->level*1.1)) && (cycles>(curseg->level*1.1))) {
                curseg->size_r = a_size_bytes;
                curseg = curseg->next = (segment*)calloc(1, sizeof(segment));
                state = 1;
                b = 0; // правый край должен быть строго правее левого
            }
            // правый край ступеньки?
            if(state && (fabs(cycles-a)<(a*.1)) && (fabs(cycles-b)<(b*.1))) {
                curseg->size_l = a_size_bytes;
                state = 0;
            }
            // первые две точки учитываем всегда
            if(!state && ((curseg->width<=2) || (fabs(cycles-curseg->level)<cycles*.1))) {
                curseg->total += cycles;
                curseg->width++;
                curseg->level = curseg->total / curseg->width;
            }
            // приняли широкий всплеск за ступеньку?
            if(!state && (cycles<curseg->level*.9) && (fabs(cycles-a)<(a*.1)) && (fabs(cycles-b)<(b*.1))) {
                curseg->total = a + b + cycles;
                curseg->width = 3;
                curseg->level = curseg->total / curseg->width;
            }

            // сдвигаем историю
            a_size_bytes = b_size_bytes; b_size_bytes = arr_size_bytes;
            a = b; b = cycles;
        }
    }

    // АНАЛИЗ ПОЛУЧЕННЫХ ДАННЫХ
    int TLB = 0; // последний проанализированный уровень -- TLB?
    for(int cache_level = 1;;cache_level++) {

        // размер и время доступа к кэшу
        int cache_size = allsegs[0].data.size_r, step_count = 0;
        if(!cache_size) break; // самый высший уровень (основная память)

        double latency, total = 0;
        if(TLB) // время доступа к кэшу следующего уровня уже определено
            cache_level--;
        else
            latency = allsegs[0].data.level;

        int less=0, same=0, more=0; // для определения медианы "на ходу"

        // для всех испробованных размеров шага
        for(segments *cursegs = allsegs; cursegs->step_size_bytes; cursegs++) {
            segment* next = cursegs->data.next; // следующий уровень кэша
            if(!next) { // с текущим размером шага, натыкаемся на основную память
                printf("Missing results for L%d! Step size %d, array size %f MB\n",
                        cache_level, cursegs->step_size_bytes, (double)cursegs->data.size_l/MB);
                cache_size = 0;
                break;
            }
            // если следующий уровень мало отличается, объединим
            while(fabs(cursegs->data.level-next->level)<cursegs->data.level*.2) {
                cursegs->data.size_r = next->size_r;
                cursegs->data.total += next->total;
                cursegs->data.width += next->width;
                cursegs->data.level = cursegs->data.total / cursegs->data.width;
                cursegs->data.next = next->next;
                free(next);
                next = cursegs->data.next;
                // реинициализация
                if(cursegs==allsegs) {
                    cache_size = cursegs->data.size_r;
                    if(!TLB) latency = cursegs->data.level;
                }
            }
            // если очередная ступенька совпала с расчётной
            if(cursegs->data.size_r == cache_size)
                same++;
            // если очередная ступенька чуть отличается от расчётной
            else if(cursegs->data.size_r == step(cache_size))
                more++;
            else if(step(cursegs->data.size_r) == cache_size)
                less++;
            // если ступенька намного левее расчётной: эффект TLB
            else if(cursegs->data.size_r < cache_size/2) {
                // измеренный до сих пор размер -- ненастоящий
                cache_size = cursegs->data.size_r;
                more = less = 0; same = 1;
                // добавим фиктивные ступеньки с тем же уровнем
                for(segments *prevsegs = allsegs; prevsegs<cursegs; prevsegs++) {
                    segment* second = (segment*)malloc(sizeof(segment));
                    *second = prevsegs->data;
                    prevsegs->data.next = second;
                    prevsegs->data.size_r = second->size_l = cache_size;
                }
            }
            // если отличающихся ступенек больше, чем расчётных
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
        if(!cache_size) break; // определение размера кэша не удалось

        // ассоциативность кэша и параметры TLB
        int min_way_size = 0, max_way_size = 0, next_step_at = 2*cache_size;
        // задержка, добавляемая временем доступа к TLB
        double additional = (allsegs[0].data.next->level - latency) / 2;
        if(additional<0) additional=0; // в пределах погрешности
        TLB = 1; // считаем за TLB, пока не убедимся в противном
        for(segments *cursegs = allsegs; cursegs->step_size_bytes; cursegs++) {
            segment* next = cursegs->data.next; // следующий уровень кэша
            // если все веи заполнены, левые границы ступенек совпадают
            if(cursegs->data.size_r <= cache_size) {
                if(max_way_size && (max_way_size != next->size_l - cache_size)) {
                    printf("Inconsistent results for L%d! Step size %d, array size %f MB\n",
                            cache_level, cursegs->step_size_bytes, (double)next->size_l/MB);
                }
                min_way_size = cursegs->step_size_bytes; // шаг не больше вея
                max_way_size = next->size_l - cache_size; // размер вея -- ширина ступеньки
                // если ступенька не вертикальная, значит известен точный размер вея
                if(next->size_l > step(cache_size)) min_way_size = max_way_size;
            // при недополнении веев, ступенька сдвинута вдвое вправо
            } else if(cursegs->data.size_r > step(cache_size)) {
                if(cursegs->data.size_r != next_step_at)
                    printf("Inconsistent results for L%d! Step size %d, array size %f MB\n",
                            cache_level, cursegs->step_size_bytes, (double)cursegs->data.size_r/MB);
                if (!max_way_size)
                    max_way_size = cursegs->step_size_bytes / 2; // шаг как минимум в два вея
                next_step_at *= 2; // следующая ступенька должна быть ещё вдвое правее
            }

            // похоже на TLB, если дополнительная задержка удваивается при удвоении шага
            double new_additional = cursegs->data.next->level - latency;
            if((fabs(new_additional - additional*2) < new_additional*.1) ||	(additional<latency*.1))
                additional = new_additional;
            else // не похоже на TLB
                TLB = 0;

            // закончили с первым сегментом
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