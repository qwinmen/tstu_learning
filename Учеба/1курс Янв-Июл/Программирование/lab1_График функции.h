#include <stdio.h>
#include <conio.h>
#include <math.h>
//LabRa_1
double f(double x)
{
return sin(x)/(sqrt(x)+1);//k/(x^2)+1
}
int main()
	{
	int i;
	float a,b,min,max,x,y,h,k;
	
	clrscr();//ClearScreen
	scanf("%f",&a);//ввести а
	scanf("%f",&b);//ввести б
	min=f(a);
	max=f(b);
	h=fabs(b-a)/80;
		for(x=a;x<=b;x=x+h)
		{
		if(max<=f(x))
		 max=f(x);
		 else if(min>f(x))
		  min=f(x);
		}
	clrscr();
	k=25/fabs(max-min);
	i=0;
	 for(x=a+h;x<=b;x+=h)
	 {
	  i++;
	  y=f(x);
	  gotoxy(i,25-k*(y-min));//(x,y)
	  printf("*");
	 }
		getch();
		return 0;
	}