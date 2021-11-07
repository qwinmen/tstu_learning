#include <stdio.h>
#include <conio.h>
#include <math.h>

const double EPS = 0.00001; // точность

// вычисление алгаритма
// x Ц аргумент функции
// eps Ц точность вычислени€
double FuncLog(const double x, const double eps)
{
	double sum = 0; // сумма р€да
	int n = 1; // текущий член р€да 
	int q; // степень числа
	double k; // значение члена р€да

	do{
		q = 2 * n - 1; // находим степень дл€ текущего члена
		k = ((double)2 / q) * pow((1-x)/(1+x), q); // вычисл€ем очередной член р€да
		sum = sum + k; // прибавл€ем новый член к сумме
		n++; // следующий член р€да
	}while (k > eps); // провер€ем точность 
	return -sum;
}

// главна€ функци€ программы
void main()
{
	clrscr(); // чистим экран
	double arg; // аргумент функции 
	printf("agr\tmyfunc\t\tlog(arg)\n\n");

	for (arg = 0.1; arg < 1.0; arg += 0.1)
	{
		// выводим строку таблицы
		printf("%0.1lf\t%lf\t%lf\n", arg, FuncLog(arg, EPS), log(arg));
	}

    getch();
}
