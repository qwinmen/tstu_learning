//---------------------------------------------------------------------------
#include <vcl.h>
#include "ZBuffer3.h"
#include <math.h>
#include <stdio.h>
#include <alloc.h>
#pragma resource "*.dfm"
//---------------------------------------------------------------------------

TForm1 *Form1;
#define MAXDIST 1000.0 //������������ ������� �����
#define MAXYLINES 200 //������������ ���������� ����� � �����.
#define clBk 3; //���� �� ���������

typedef struct Point3d POINT3D;
typedef struct Cell CELL;

//��������� ��� ����� � 3-������ ������������.
struct Point3d {
	double x, y, z;
};

//��������� ������, �� ������� ����� �������� Z-�����.
struct Cell {
	double z;
	int color;
};

//����� �������������.
class Triangle {
	public:
		int color;
		POINT3D p[ 3 ];
		Triangle ( POINT3D p1, POINT3D p2, POINT3D p3, int c ) {
			p[ 0 ] = p1; p[ 1 ] = p2; p[ 2 ] = p3;
			color = c;
		}
};

//����� Z-������.
class ZBuffer {
	public:
		CELL *buff[ MAXYLINES ];
		int sX, sY;	// ������ Z-������
		ZBuffer ( int, int );
		~ZBuffer ();
		void PutTriangle ( Triangle& );
		void Show ();
		void Clear ();
};

//����������� Z-������.
ZBuffer :: ZBuffer ( int ax, int ay ) {
	sX = ax; sY = ay;
	for ( int i = 0; i < sY; i++ ) {
		//��������� ������ ��� ������
		buff[ i ] = (struct Cell *)malloc ( sX * sizeof ( struct Cell ));
	}
}

//���������� Z-������.
ZBuffer :: ~ZBuffer ( ) {
	for ( int i = 0; i < sY; i++ )
		free( buff[i] ); //������������ ������
}

//�������, ��������� �� ����� ���������� ������������ Z-������.
void ZBuffer :: Show () {
	for ( int j = 0; j < sY; j++ )
		for ( int i = 0; i < sX; i++ )
			//������� ������� �� �����
			Form1->Canvas->Pixels[50+i][j] = clBlue/(*( buff[ j ] + i )).color;
}

//�������, '���������' Z-�����.
void ZBuffer :: Clear () {
	for ( int j = 0; j < sY; j++ )
		for ( int i = 0; i < sX; i++ )
			//�������������� ������ Z-������
			(*( buff[ j ] + i )).z = MAXDIST, (*( buff[ j ] + i )).color = clBk;
}

void ZBuffer :: PutTriangle ( Triangle& t ) {
	int ymax, ymin, ysc, e1, e, i;
	int x[3], y[3];
	//������� x,y �� t � ������� ��� ����������� ������ � ����
	for ( i = 0; i < 3; i++ )
		x[ i ] = int( t.p[ i ].x ), y[ i ] = int( t.p[ i ].y );
	//���������� ������������ � ����������� y
	ymax = ymin = y[0];
	if ( ymax < y[1] ) ymax = y[1]; else if ( ymin > y[1] ) ymin = y[1];
	if ( ymax < y[2] ) ymax = y[2]; else if ( ymin > y[2] ) ymin = y[2];
	ymin = ( ymin < 0 ) ? 0 : ymin;
	ymax = ( ymax < sY ) ? ymax : sY;
	int ne;
	int x1, x2, xsc1, xsc2;
	double z1, z2, tc, z;
	//��������� ������� ���� ���������� ��� ������ �����
	//� ���������� ������� ������� �������
	//��� ���������������� ������������
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
			//���� ���������� ������� ������� ������ ���,
			//��� ��������� � Z-������ - �������� ���������� �� �����.
			if ( z < (*( buff[ ysc ] + xsc )).z )
				(*( buff[ ysc ] + xsc )).color = t.color,
				(*( buff[ ysc ] + xsc )).z = z;
			}
	}
}

//������� 6 ������� ����� ��� 6 �������������, x,y,z ��������������.
POINT3D p[ 6 ][ 3 ] = {
{{  20.0,  60.0,  50.0}, {  60.0,  20.0,  50.0}, { 180.0, 140.0,   0.0}},
{{  80.0,  20.0,   0.0}, {  80.0, 180.0,  50.0}, {  40.0, 160.0,  50.0}},
{{  20.0, 140.0,   0.0}, { 150.0,  60.0,  50.0}, { 180.0, 100.0,  50.0}},
{{  90.0,  10.0, 100.0}, {  10.0,  90.0, 100.0}, { 210.0, 190.0, 100.0}},
{{ 100.0,  50.0, 100.0}, { 100.0, 150.0,   0.0}, { 200.0, 100.0,  50.0}},
{{  50.0, 100.0,  50.0}, { 150.0, 150.0, 100.0}, { 150.0,  50.0,   0.0}},
};

//�������������� ������������.
Triangle	t1( p[0][0], p[0][1], p[0][2], 13 ),
			t2( p[1][0], p[1][1], p[1][2], 14 ),
			t3( p[2][0], p[2][1], p[2][2], 12 ),
			t4( p[3][0], p[3][1], p[3][2], 10 ),
			t5( p[4][0], p[4][1], p[4][2], 11 ),
			t6( p[5][0], p[5][1], p[5][2],  9 );

//�������, ��������������� ������ ��������� Z-������.
void Buffer(){
	ZBuffer * zb;
	zb = new ZBuffer ( 220, 200 ); //������� Z-����� � ������� ���������
	zb->Clear(); //�������������� � ����������
	//��������� Z-�����
	zb->PutTriangle ( t1 );
	zb->PutTriangle ( t2 );
	zb->PutTriangle ( t3 );
	zb->PutTriangle ( t4 );
	zb->PutTriangle ( t5 );
	zb->PutTriangle ( t6 );
	//������� ���������� �� �����
	zb->Show();
}

//��������� ������� ��� ���������� ����������.
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
