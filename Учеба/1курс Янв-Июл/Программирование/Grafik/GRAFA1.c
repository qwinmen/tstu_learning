
 #include <stdio.h>
 #include <stdlib.h>
 #include <math.h>
 #include <conio.h>

 double f(double x)
 {
	return 1/(x*x)+1;
 }


 int main ()
 {
  double x,y,xmin,ymin,xmax,ymax,h;
  int i,n;

 clrscr();
 printf("\nXmin="); scanf("%le",&xmin);
 printf("\nXmax="); scanf("%le",&xmax);
 ymin=1e60;
 ymax=-1e60;

 h=(xmax-xmin)/79;

 for(i=0;i<80;i++)
 {
		x=xmin+i*h;
		y=f(x);
		if(y>ymax) ymax=y;
		if(y<ymin) ymin=y;

 }
//		printf("\nmax=%lf",ymax);
//		printf("\nmin=%lf",ymin);
//		 getch();

 clrscr();

 for(i=0;i<80;i++)
 {
		x=xmin+i*h;
		y=f(x);
		n=(int)(26-((y-ymin)/(ymax-ymin)*24+1));
//		printf("y=%lf  n=%d",y,n); getch();

//		getch();
		gotoxy(i+1,n);
		printf("*");
 }
  getch();
 return 0;
}