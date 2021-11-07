/**
 * Эта прога похожа на полином Лагранжа, поэтому почти все остальные
 * комментарии совпадают; смотрите здесь:
 * http:/photoroofers.ru/personal_stuff/lagrange.zip
 **/

void newton_start ()
{
	int n;
	newton first;
	first.show();
	cout << "\nWant to calc another x[i]? X=";
	double xtocalc;
	cin >> xtocalc;
	double *k=first.coeffs();

	double res=first.calc (k, xtocalc);
	cout << "\nf(x)=" << res << endl;
	cout << "\nExit? [Y] ";
	string quit;
	cin >> quit;
	if ((quit == "Y") || (quit == "y"))
		exit (EXIT_SUCCESS);
	else
	{
		first.~newton();
		newton_start();
	}
}
