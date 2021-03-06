#include <stdio.h>
#include <conio.h>
#include <math.h>

const double EPS = 0.00001; // ��������

// ���������� ���������
// x � �������� �������
// eps � �������� ����������
double FuncLog(const double x, const double eps)
{
	double sum = 0; // ����� ����
	int n = 1; // ������� ���� ���� 
	int q; // ������� �����
	double k; // �������� ����� ����

	do{
		q = 2 * n - 1; // ������� ������� ��� �������� �����
		k = ((double)2 / q) * pow((1-x)/(1+x), q); // ��������� ��������� ���� ����
		sum = sum + k; // ���������� ����� ���� � �����
		n++; // ��������� ���� ����
	}while (k > eps); // ��������� �������� 
	return -sum;
}

// ������� ������� ���������
void main()
{
	clrscr(); // ������ �����
	double arg; // �������� ������� 
	printf("agr\tmyfunc\t\tlog(arg)\n\n");

	for (arg = 0.1; arg < 1.0; arg += 0.1)
	{
		// ������� ������ �������
		printf("%0.1lf\t%lf\t%lf\n", arg, FuncLog(arg, EPS), log(arg));
	}

    getch();
}
