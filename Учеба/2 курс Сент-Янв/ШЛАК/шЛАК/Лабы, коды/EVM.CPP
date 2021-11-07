#include <time.h>
#include <conio.h>
#include <stdio.h>
#include <Windows.h>
int main(){
                  int a;
       long	int   i;
	long double n, n1;
	long double dT1,dT2,dT, T1, T2, T3, T4;
	T1=GetTickCount();
	printf ("T1=  %ld ", &T1);
	for(i=0; i<=99999999; i++){
	  a=4;
}
	T2=GetTickCount();
	printf ("\n T2= %ld ", &T2);
	dT1=T2-T1;
	printf ("\n dT1= %ld", &dT1);
	T3=GetTickCount();
	printf ("\n T3= %ld ", &T3);
	for(i=0; i<=99999999; i++){
}
	T4=GetTickCount();
	printf ("\n T4= %ld ", &T4);
	dT2=T4-T3;
	printf ("\n dT2= %ld", &dT2);
	dT=dT1-dT2;
	printf ("\n dT= %ld", &dT );
	n=dT/99999999;
	printf("\n n= %ld", &n);
	n1=1/n;
	printf("\n chastota %ld MHz", &n1);
	getch();

	return 0;
}