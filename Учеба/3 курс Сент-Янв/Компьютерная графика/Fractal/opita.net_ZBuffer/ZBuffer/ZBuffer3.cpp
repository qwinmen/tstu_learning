//---------------------------------------------------------------------------
#include <vcl.h>
#include "ZBuffer3.h"
#include <math.h>
#include <stdio.h>
#include <alloc.h>
#pragma resource "*.dfm"
//---------------------------------------------------------------------------

TForm1 *Form1;
#define MAXDIST 1000.0 //Максимальная глубина сцены
#define MAXYLINES 200 //Максимальное количество линий в сцене.
#define clBk 3; //Цвет по умолчанию

typedef struct Point3d POINT3D;
typedef struct Cell CELL;

//Структура для точки в 3-мерном пространстве.
struct Point3d {
	double x, y, z;
};

//Структура ячейки, из которых будет состоять Z-буфер.
struct Cell {
	double z;
	int color;
};

//Класс треугольников.
class Triangle {
	public:
		int color;
		POINT3D p[ 3 ];
		Triangle ( POINT3D p1, POINT3D p2, POINT3D p3, int c ) {
			p[ 0 ] = p1; p[ 1 ] = p2; p[ 2 ] = p3;
			color = c;
		}
};

//Класс Z-буфера.
class ZBuffer {
	public:
		CELL *buff[ MAXYLINES ];
		int sX, sY;	// Размер Z-Буфера
		ZBuffer ( int, int );
		~ZBuffer ();
		void PutTriangle ( Triangle& );
		void Show ();
		void Clear ();
};

//Конструктор Z-буфера.
ZBuffer :: ZBuffer ( int ax, int ay ) {
	sX = ax; sY = ay;
	for ( int i = 0; i < sY; i++ ) {
		//Выделение памяти под ячейки
		buff[ i ] = (struct Cell *)malloc ( sX * sizeof ( struct Cell ));
	}
}

//Деструктор Z-буфера.
ZBuffer :: ~ZBuffer ( ) {
	for ( int i = 0; i < sY; i++ )
		free( buff[i] ); //Освобождение памяти
}

//Функция, выводящая на экран содержимое заполненного Z-буфера.
void ZBuffer :: Show () {
	for ( int j = 0; j < sY; j++ )
		for ( int i = 0; i < sX; i++ )
			//Выводим пиксели на экран
			Form1->Canvas->Pixels[50+i][j] = clBlue/(*( buff[ j ] + i )).color;
}

//Функция, 'очищающая' Z-буфер.
void ZBuffer :: Clear () {
	for ( int j = 0; j < sY; j++ )
		for ( int i = 0; i < sX; i++ )
			//Инициализируем ячейки Z-буфера
			(*( buff[ j ] + i )).z = MAXDIST, (*( buff[ j ] + i )).color = clBk;
}

void ZBuffer :: PutTriangle ( Triangle& t ) {
	int ymax, ymin, ysc, e1, e, i;
	int x[3], y[3];
	//Заносим x,y из t в массивы для последующей работы с ними
	for ( i = 0; i < 3; i++ )
		x[ i ] = int( t.p[ i ].x ), y[ i ] = int( t.p[ i ].y );
	//Определяем максимальный и минимальный y
	ymax = ymin = y[0];
	if ( ymax < y[1] ) ymax = y[1]; else if ( ymin > y[1] ) ymin = y[1];
	if ( ymax < y[2] ) ymax = y[2]; else if ( ymin > y[2] ) ymin = y[2];
	ymin = ( ymin < 0 ) ? 0 : ymin;
	ymax = ( ymax < sY ) ? ymax : sY;
	int ne;
	int x1, x2, xsc1, xsc2;
	double z1, z2, tc, z;
	//Следующий участок кода перебирает все строки сцены
	//и определяет глубину каждого пикселя
	//для соответствующего треугольника
	for ( ysc = ymin; ysc < ymax; ysc++ ) {
		ne = 0;
		for ( int e = 0; e < 3; e++ ) {
			e1 = e + 1;
			if ( e1 == 3 ) e1 = 0;
			if ( y[e] < y[e1] ) {
				if ( y[e1] <= ysc || ysc < y[e] ) continue;
			}
			else if ( y[e] > y[e1] ) {
				if ( y[e1] > ysc || ysc >= y[e] ) continue;
			}
			else continue;
			tc = double( y[ e ] - ysc ) / ( y[ e ] - y[ e1 ] );
			if ( ne )
				x2 = x[ e ] + int ( tc * ( x[ e1 ] - x[ e ] ) ),
				z2 = t.p[ e ].z + tc * ( t.p[ e1 ].z - t.p[ e ].z );
			else
				x1 = x[ e ] + int ( tc * ( x[ e1 ] - x[ e ] ) ),
				z1 = t.p[ e ].z + tc * ( t.p[ e1 ].z - t.p[ e ].z ),
			ne = 1;
		}
		if ( x2 < x1 ) e = x1, x1 = x2, x2 = e, tc = z1, z1 = z2, z2 = tc;
		xsc1 = ( x1 < 0 ) ? 0 : x1;
		xsc2 = ( x2 < sX ) ? x2 : sX;
		for ( int xsc = xsc1; xsc < xsc2; xsc++ ) {
			tc = double( x1 - xsc ) / ( x1 - x2 );
			z = z1 + tc * ( z2 - z1 );
			//Если полученная глубина пиксела меньше той,
			//что находится в Z-Буфере - заменяем храняшуюся на новую.
			if ( z < (*( buff[ ysc ] + xsc )).z )
				(*( buff[ ysc ] + xsc )).color = t.color,
				(*( buff[ ysc ] + xsc )).z = z;
			}
	}
}

//Создаем 6 наборов точек для 6 треугольников, x,y,z соответственно.
POINT3D p[ 6 ][ 3 ] = {
{{  20.0,  60.0,  50.0}, {  60.0,  20.0,  50.0}, { 180.0, 140.0,   0.0}},
{{  80.0,  20.0,   0.0}, {  80.0, 180.0,  50.0}, {  40.0, 160.0,  50.0}},
{{  20.0, 140.0,   0.0}, { 150.0,  60.0,  50.0}, { 180.0, 100.0,  50.0}},
{{  90.0,  10.0, 100.0}, {  10.0,  90.0, 100.0}, { 210.0, 190.0, 100.0}},
{{ 100.0,  50.0, 100.0}, { 100.0, 150.0,   0.0}, { 200.0, 100.0,  50.0}},
{{  50.0, 100.0,  50.0}, { 150.0, 150.0, 100.0}, { 150.0,  50.0,   0.0}},
};

//Инициализируем треугольники.
Triangle	t1( p[0][0], p[0][1], p[0][2], 13 ),
			t2( p[1][0], p[1][1], p[1][2], 14 ),
			t3( p[2][0], p[2][1], p[2][2], 12 ),
			t4( p[3][0], p[3][1], p[3][2], 10 ),
			t5( p[4][0], p[4][1], p[4][2], 11 ),
			t6( p[5][0], p[5][1], p[5][2],  9 );

//Функция, демонстрирующая работу алгоритма Z-буфера.
void Buffer(){
	ZBuffer * zb;
	zb = new ZBuffer ( 220, 200 ); //Создаем Z-буфер с нужными размерами
	zb->Clear(); //Подготовливаем к заполнению
	//Заполняем Z-буфер
	zb->PutTriangle ( t1 );
	zb->PutTriangle ( t2 );
	zb->PutTriangle ( t3 );
	zb->PutTriangle ( t4 );
	zb->PutTriangle ( t5 );
	zb->PutTriangle ( t6 );
	//Выводим содержимое на экран
	zb->Show();
}

//Служебные функции для интерфейса приложения.
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
		: TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::N2Click(TObject *Sender)
{
Close();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::SpeedButton2Click(TObject *Sender)
{
this->Close();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::SpeedButton1Click(TObject *Sender)
{
Buffer();
}
//---------------------------------------------------------------------------
