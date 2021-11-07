/************************/
/* Compiler TurboC v1.0 */
/************************/

#include <stdio.h>
#include <conio.h>

/* ������������� ����� ������ ���������� */
#define END_PARAM -1



/* ����� ������������� �������� ��������� */
int max(int a, ...)
{
	int m = a;
	int* p = &a; /* ��������� �� �������� ��������� */
	p++;
	while (*p != END_PARAM)
	{
		if (*p > m)	/* ���� �������� �������� ��������� ������ �������������, �� */
			m = *p;	/* ���������� ������� */
		p++;		/* ��������� � ���������� ��������� */
	}
	
	/* ���������� ��������� */
	return m;
}



void main()
{
	/* ����� */
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
