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
#include "newton.cpp"
#include "funcs.cpp"

int main ()
{
	/**
 * Смысл этой программы в том же, что и у "Лагранжевой", поэтому почти
 * все комментарии можно взять по сцыле, структуры прожек совпадают
 * на все 100, разнится только математическая часть.
 * Скачать Лагранжа: http://photoroofers.ru/personal_stuff/lagrange.zip
 **/
	cout << "\nClass Newton\n";
	cout << "Input values: X[n] and Y[n] - The Table\n";
	cout << "Then choose another x to calc f(x)\n";

	newton_start ();
}
