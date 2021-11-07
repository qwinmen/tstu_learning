#include <stdio.h>
#include <conio.h>
#include <math.h>

void main()
{
	const int N = 5;
	double A[N];
	clrscr();
	printf("enter %d digit\n\n", N);
	int i;
	for (i = 0; i < N; i++)
		scanf("%lf", &A[i]);

	double s = A[0];
	for (i = 1; i < N; i++)
		s += A[i];
	s = s / N;

	int idx = 0;
	for (i = 1; i < N; i++)
		if (fabs(A[idx] - s) > fabs(A[i] - s))
			idx = i;

	printf("\nelement number: %d", idx + 1);

	getch();
}
