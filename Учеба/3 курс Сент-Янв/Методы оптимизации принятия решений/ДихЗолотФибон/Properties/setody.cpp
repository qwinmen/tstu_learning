// половинное деление.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

float fun(float x)

{
	return x*x*x + 10.5*x*x + 30 * x + 13;
}

int _tmain(int argc, _TCHAR* argv[])
{
	float x0, x1, x2, a = -4.5, b = 4;
	//Половинное деление
	/*while ((b - a) > 0.01)
	{
	x1 = a + 0.25*(b - a);
	x2 = b - 0.25*(b - a);
	if (fun(x1) < fun(x2))
	b = x2;
	else a = x1;
	//printf("(%f, %f)\n", x1, x2);
	}
	printf("%f\n", (x2 	+ x1) / 2); */

	// Золотое сечение
	/*float A, B;
	x1 = a + 0.38*(b - a);
	x2 = b - 0.38*(b - a);
	A = fun(x1);
	B = fun(x2);
	while ((b-a)>0.01)
	{
	if (A < B)
	{
	b = x2;
	x2 = x1;
	x1 = a + 0.38*(b - a);
	B = A;
	A = fun(x1);
	}
	else
	{
	a = x1;
	x1 = x2;
	x2 = b - 0.38*(b - a);
	A = B;
	B = fun(x2);
	}

	}
	printf("%f\n", (a + b) / 2);
	*/

	// Фибоначчи
	int F[30], N, s;
	float d, X[30];
	F[0] = 1; F[1] = 1;
	for (int i = 0; i < 30; i++)
	{
		F[i + 2] = F[i + 1] + F[i];
		//	printf("%d, ", F[i]);
	}
	//printf("\n");
	//printf("%f\n",b);
	N = (b - a) / 0.01;
	//printf("%d\n",N);
	for (int i = 1; i < 30; i++)
	{
		if (F[i - 1] < N)
			if (N < F[i])
				s = i;
	}
	//printf("%d\n", s);
	d = (b - a) / F[s];
	X[0] = a;
	X[1] = a + d*F[s - 2];
	if (fun(X[1]) < fun(a))
		X[2] = X[1] + d*F[s - 3];
	else
		X[2] = X[1] - d*F[s - 3];

	
	for (int i = 2; i<s; i++)
	{
		if (fun(X[i])<fun(X[i - 1]))
			X[i + 1] = X[i] + d*F[s - i - 2];
		else X[i + 1] = X[i - 1] - d*F[s - i - 2];

	}
	for (int i = 0; i<s; i++)
		printf("%f %f\n ", X[i], fun(X[i]));

	//printf("%f %f ", X[s]);
	_getch();
	return 0;
}