//---------------------------------------------------------------------------

#pragma hdrstop

#include <tchar.h>
#include <math.h>
#include <stdio.h>
//---------------------------------------------------------------------------

double PI=3.14159265358979;
double F(double x1, double x2)
{
	int a=0, b=1, c=2, d=4, alpha=110;
	alpha = alpha*PI/180.0;

	return (((x1 - 8)*cos(170) + (x2 - (-1))*sin(170))*
								((x1 - 8)*cos(170) + (x2 - (-1))*sin(170)))/4
							   +
							   (((x2 - (-1))*cos(170) - (x1 - 8)*sin(170))*
								((x2 - (-1))*cos(170) - (x1 - 8)*sin(170)))/25;

//	return pow(((x-a)*cos(alpha) + (y-b)*sin(alpha)), 2)/(c*c) +
  //		 pow(((y-b)*cos(alpha) - (x-a)*sin(alpha)),2)/(d*d);
}


double dxF(double x, double y, double dx)
{
	return (F(x+dx,y)-F(x,y))/dx;
}

double dyF(double x, double y, double dy)
{
	return (F(x,y+dy)-F(x,y))/dy;
}


#pragma argsused
int _tmain(int argc, _TCHAR* argv[])
{
//Point A0 = new Point(2.0,4.0);
double x = 2.0, y = 4.0, dx = 0.1, dy = 0.1, h1=1, h2=1.0;
	while (fabs(dxF(x,y,dx)-dxF(x,y,dx/2))>0.01)
	{
		dx=dx/2;

	}
	while (fabs(dyF(x,y,dy)-dyF(x,y,dy/2))>0.01)
	{
		dy=dy/2;
	}

int n=0;
	while ((fabs(dxF(x,y,dx))+fabs(dyF(x,y,dy)))>0.01)
	{
		x=x-h1*dxF(x,y,dx);
		y=y-h2*dyF(x,y,dy);
		n++;

		printf("%f   ", (pow(dxF(x,y,dx),2)+pow(dyF(x,y,dy),2)));
		printf("\n\nminF(%lf,%lf) = %lf\n", x,y,F(x,y));
	}

	printf("\n\nminF(%lf,%lf) = %lf\n", x,y,F(x,y));

	printf("\nKolichestvo iteratorov: %d", n);

	//printf("dx=%f dy=%f", dx,dy);


	return 0;



}
//---------------------------------------------------------------------------


