/**
 * Эта прога похожа на полином Лагранжа, поэтому почти все остальные
 * комментарии совпадают; смотрите здесь:
 * http:/photoroofers.ru/personal_stuff/lagrange.zip
 **/

#include "newton.h"

newton::newton ()
{
	cout << "\nCreating an object...\n\n";

	cout << "Number of dots: ";
	for (;;)
	{
		cin >> n;
		if (n < 1)
			cout << "N must be more than 1, enter it again: ";
		else break;
	}
	cout << endl;
	
	x=new double[n];
	y=new double[n];

	for (int i=0; i<n; i++)
	{
		cout << "X[" << i+1 << "]=";
		cin >> x[i];
		cout << "Y[" << i+1 << "]=";
		cin >> y[i];
	}
}

void newton::show()
{
	cout << "\nThe Table:\n\n";
	for (int i=0; i<n; i++)
	{
		cout << x[i] << "\t";
		cout << y[i] << "\n";
	}
}

newton::~newton ()
{
	delete [] x;
	delete [] y;
}

double* newton::coeffs ()
{
	/**
	 * Я не знаю, кем надо быть, чтобы суметь объяснить работу
	 * Ньютоновского полинома вот так вот, текстом.
	 * Короче, надо создать такой вот массив коэффициентов, чтобы потом
	 * юзать его в методе calc - см. ниже
	 **/
	double *k=new double[n];
	k[0]=y[0];
	for (int j=1; j<n; j++)
		for (int i=0; i<n-j; i++)
		{
			y[i]=(y[i+1]-y[i])/(x[i+j]-x[i]);
			k[j]=y[0];
		}
	return k;
}

double newton::calc (double *k, double argx)
{
	/**
	 * argx, как вы догадались - это та точка, в которой мы хотим
	 * посчитать значение "загаданной функции" (я понимаю, что это тупо
	 * звучит, но так проще всего объяснить, в чём состоит смысл
	 * интерполяции. Читайте комментарий в файле lagrange.h, скачать - 
	 * http://photoroofers.ru/personal_stuff/lagrange.zip).
	 * А double *k - так мы передаём этот самый массив коэффициентов,
	 * полученный чуть выше, в методе coeffs().
	 **/
	double S=k[0], p=1;
	for (int i=1; i<n; i++)
	{
		p=p*(argx-x[i-1]);
		S+=k[i]*p;
	}
	return S;
}
