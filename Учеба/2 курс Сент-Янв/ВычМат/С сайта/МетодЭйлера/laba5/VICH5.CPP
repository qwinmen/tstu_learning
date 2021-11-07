#include <stdio.h>
#include <math.h>
#include <conio.h>
int main()
{clrscr();
 float i,a,b,h,ya,yb,K1,K2,K3,K4;
 printf("Введите a\n");
 scanf("%f",&a);
 printf("Введите y[a]\n");
 scanf("%f",&ya);
 printf("Введите b\n");
 scanf("%f",&b);
 printf("Введите шаг\n");
 scanf("%f",&h);
 for(i=a;i<=b;i=i+h)
 {
  K1=i+sin(ya/2);
  K2=i+h/2+sin((ya+K1/2)/2);
  K3=i+h/2+sin((ya+K2/2)/2);
  K4=i+h+sin((ya+K3)/2);
  yb=ya+h*(K1+2*K2+2*K3+K4)/6;
  ya=yb;
 }
 printf("%f",yb);
 return 0;
}