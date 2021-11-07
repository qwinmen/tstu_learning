/************************/
/* Compiler TurboC v1.0 */
/************************/

#include <stdio.h>
#include <conio.h>
#include <stdlib.h>

/* размер массива */
#define BUFF_SIZE 100

/* поиск минимального значения в массиве */
double* find_min(double* A, int Count)
{
	double* m = A; /* указатель на минимальное значение */
	A++;
	for (; Count > 1; Count--)
	{		
		if (*m > *A)/* если минимальный больше текущего, то */
			m = A;	/* текущий делаем минимальным */
		A++;		/* переходим к следующему элементу */
	}
	
	/* возвращаем указатель на минимальный элемент массива */
	return m;
}


/* обмен */
void swap(double* a, double* b)
{
	double t = *a;
	*a = *b;
	*b = t;
}

/* сортировка выбором */
void sort(double* A, int Count)
{
	double* m; /* указатель на минимальное значение */
	for (; Count > 0; Count--)
	{
		/* поиск минимального */
		m = find_min(A, Count);
		swap(m, A); /* обмен */
		A++;	/* на следующий */
	}
}

/* инициализация массива случайными значениями */
void init_array(double* A, int Count)
{
	srand(ctime()); /* рандомизация */
	for ( ; Count > 0; Count--)
	{
		*A = rand() % 100;
		A++;
	}
}

/* вывод массива на экран */
void print_array(double* A, int Count)
{
	for ( ; Count > 0; Count--)
	{
		printf("%3.0f\t", *A);
		A++;
	}	
}

void main()
{
	double A[BUFF_SIZE];			/* массив вещественных чисел */
	init_array(A, BUFF_SIZE);		/* инициализация случайными значениями */
	printf("the source data:\n");	
	print_array(A, BUFF_SIZE);		/* вывод исходной последовательности */
	sort(A, BUFF_SIZE);				/* сортировка массива */
	printf("\nthe result:\n");
	print_array(A, BUFF_SIZE);		/* вывод результата сортировки */
	getch();
	
}
