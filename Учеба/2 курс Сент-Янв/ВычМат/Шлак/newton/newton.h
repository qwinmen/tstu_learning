/**
 * Эта прога похожа на полином Лагранжа, поэтому почти все остальные
 * комментарии совпадают; смотрите здесь:
 * http:/photoroofers.ru/personal_stuff/lagrange.zip
 **/

class newton
{
	double *x;
	double *y;
	int n;

public:

	newton ();
	~newton ();
	void show ();
	double* coeffs ();
	double calc (double*, double);
};
