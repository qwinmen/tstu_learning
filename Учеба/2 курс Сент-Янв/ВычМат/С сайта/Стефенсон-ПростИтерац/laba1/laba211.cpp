#include <stdio.h>
#include <math.h>
#include <conio.h>
int main()
{
 float x=0,i=0, E=0,g=0;
 clrscr();
 printf("������ �⥯��� �筮�� (���ਬ�� -6 ��� -10)\n");
 scanf("%f",&E);
 printf("������ x0\n");
 scanf("%f",&x);
 do
 {
  i=x-(x*x*x+3*x*x-2)/(3*x*x+6*x);
  g=i-x;
  x=i;
  printf("%f\n",x);
 }while(fabs(g)>E);
 getch();
 return 0;
}
