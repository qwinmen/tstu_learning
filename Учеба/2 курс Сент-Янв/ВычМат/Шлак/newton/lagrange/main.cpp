/**
 * Эту прожку задрачивал Kremchik - 
 * студент специальности "Математика. Компьютерные Науки"
 * факультета физико-математических и естественных наук РУДН
 *
 * Акромя программирования я занимаюсь фотографией, так что
 * советую посетить сцайт http://photoroofers.ru
 * он богат достаточно необычной темой - фотографиями с крыш
 * московских небоскрёбов. Красиво, сука.
 **/

using namespace std;
#include <iostream>
#include <string>
#include <math.h>
#include <stdlib.h>
//для exit(EXIT_SUCCES);
#include "lagrange.cpp"
#include "funcs.cpp"
//его мы сделали и подключили,
//дабы облегчить main()

int main ()
{
	cout << "\nClass Lagrange\n";
	cout << "Input values: X[n] and Y[n] - The Table\n";
	cout << "Then choose another x to calc f(x)\n";
	//а-ля баннер

	lagrange_start();
	//начинаем (см. funcs.cpp)
}
