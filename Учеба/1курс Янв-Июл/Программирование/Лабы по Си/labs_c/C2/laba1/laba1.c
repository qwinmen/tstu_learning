/************************/
/* Compiler TurboC v1.0 */
/************************/

#include <stdio.h>
#include <conio.h>
#include <stdlib.h>

/* ������ ������� */
#define BUFF_SIZE 100

/* ����� ������������ �������� � ������� */
double* find_min(double* A, int Count)
{
	double* m = A; /* ��������� �� ����������� �������� */
	A++;
	for (; Count > 1; Count--)
	{		
		if (*m > *A)/* ���� ����������� ������ ��������, �� */
			m = A;	/* ������� ������ ����������� */
		A++;		/* ��������� � ���������� �������� */
	}
	
	/* ���������� ��������� �� ����������� ������� ������� */
	return m;
}


/* ����� */
void swap(double* a, double* b)
{
	double t = *a;
	*a = *b;
	*b = t;
}

/* ���������� ������� */
void sort(double* A, int Count)
{
	double* m; /* ��������� �� ����������� �������� */
	for (; Count > 0; Count--)
	{
		/* ����� ������������ */
		m = find_min(A, Count);
		swap(m, A); /* ����� */
		A++;	/* �� ��������� */
	}
}

/* ������������� ������� ���������� ���������� */
void init_array(double* A, int Count)
{
	srand(ctime()); /* ������������ */
	for ( ; Count > 0; Count--)
	{
		*A = rand() % 100;
		A++;
	}
}

/* ����� ������� �� ����� */
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
	double A[BUFF_SIZE];			/* ������ ������������ ����� */
	init_array(A, BUFF_SIZE);		/* ������������� ���������� ���������� */
	printf("the source data:\n");	
	print_array(A, BUFF_SIZE);		/* ����� �������� ������������������ */
	sort(A, BUFF_SIZE);				/* ���������� ������� */
	printf("\nthe result:\n");
	print_array(A, BUFF_SIZE);		/* ����� ���������� ���������� */
	getch();
	
}
