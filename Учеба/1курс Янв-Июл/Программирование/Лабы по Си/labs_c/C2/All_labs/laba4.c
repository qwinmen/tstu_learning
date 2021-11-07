/************************/
/* Compiler TurboC v1.0 */
/************************/

#include <stdio.h>
#include <conio.h>

/* идентификатор конца списка параметров */
#define END_PARAM -1



/* поиск максимального значения параметра */
int max(int a, ...)
{
	int m = a;
	int* p = &a; /* указатель на значение параметра */
	p++;
	while (*p != END_PARAM)
	{
		if (*p > m)	/* если значение текущего параметра больше максимального, то */
			m = *p;	/* запоминаем большее */
		p++;		/* переходим к следующемк параметру */
	}
	
	/* возвращаем результат */
	return m;
}



void main()
{
	/* тесты */
	printf("test 1: max = 100\n");
	printf("\t(100, 20, 30, 90, 22)\tresult = %d\n\n", max(100,20,30,90,22, END_PARAM));
	printf("test 2: max = 200\n");
	printf("\t(100, 20, 200, 90, 22)\tresult = %d\n\n", max(100,20,200,90,22, END_PARAM));
	printf("test 3: max = 300\n");
	printf("\t(100, 20, 200, 90, 300)\tresult = %d\n\n", max(100,20,200,90,300, END_PARAM));
	printf("test 3: max = 400\n");
	printf("\t(100, 20, 200, 90, 300, 400, 2)\tresult = %d\n\n", max(100,20,200,90,300,400,2, END_PARAM));
	getch();
}
