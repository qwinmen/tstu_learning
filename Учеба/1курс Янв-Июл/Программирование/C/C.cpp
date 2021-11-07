// C.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
	#include <stdio.h>
#include <conio.h>
#include <math.h>

	#include <windows.h>

float f(float x)
{return (  1/(pow(x,2)+1)  );}//sin(x)/(sqrt(x)+1);}

int main()
	{
	int i;
	float a,b,min,max,x,y,h,k;
	
	void clrscr();
	scanf("%f",&a);
	scanf("%f",&b);
	min=f(a);
	max=f(b);
	h=fabs(b-a)/80;
		for(x=a;x<=b;x=x+h)
		{
		if(max<=f(x))
		{max=f(x);}
		 else if(min>f(x))
		 {min=f(x);}
		}
	void clrscr();	
	k=25/fabs(max-min);
	i=0;
	 for(x=a+h;x<=b;x+=h)
	 {
	  i++;
	  y=f(x);
	  //goto (i*25-k*(y-min));
	  printf("*");
	 }
	 /*/CPU---------//}
		double t1,t2,dt,tn,tk;
		unsigned long int i,n=9000000000,f;
		register int A;
		tn=GetTickCount();
		for(i=0;i<n;i++)
			A=1;

		tk=GetTickCount();
		t1=tk-tn;
		printf("start time %lf\n",tn);
		printf("end time %lf\n",tk);
		tn=GetTickCount();

		for(i=0;i<n;i++)
		{A=1;A=1;}
		tk=GetTickCount();
		t2=tk-tn;
		printf("start time %lf\n",tn);
		printf("end time %lf\n",tk);
		dt=(t2-t1);
		f=n/dt*1000;
		f=f/1000000000;

		printf("CPU= %ld GHz\n",f);

	*/

		getch();
		return 0;
	}