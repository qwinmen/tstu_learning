#include <stdio.h>
#include <math.h>
#include <conio.h>
int main()
{
 float x0=0,y0=0, E=0,x=0,y=0,g=0,k=0,i=5,x10=0,y10=0;
 clrscr();
 printf("������ �⥯��� �筮�� (���ਬ�� -6 ��� -10)\n");
 scanf("%f",&E);
 printf("������ x0\n");
 scanf("%f",&x0);
 printf("������ y0\n");
 scanf("%f",&y0);
 x10=x0;
 y10=y0;
 printf("���� ���� ���権:\n");
 printf("--------------------------------\n");
 do
 {
  x=cos(y0+1)/2;
  y=-sin(x0)-0.4;
  g=x-x0;
  x0=x;
  k=y-y0;
  y0=y;
  if(i!=0)
  {
   printf("%f\n",x0);
   printf("%f\n",y0);
   i--;
  }
 }while(fabs(g)>E && fabs(k)>E);
 printf("--------------------------------\n");
 printf("��୨ ��室��� ��⥬� �ࠢ����� �� ��⮤�\n������ ���権 ����� ���:\n");
 printf("%f\n",x);
 printf("%f\n",y);
 getch();
 clrscr();
 printf("��⮤ ���⮭�\n");
 printf("--------------------------------\n");
 x0=x10;
 y0=y10;
 if((2-cos(x0)*sin(y0+1))<1)
 {
  printf("��⮤ ���⮭� �� �室���� ��� ������ x0 � y0 !!!");
  getch();
  return 0;
 }
 i=5;
 do
 {
  x=x0-(2*x0-cos(y0+1)-(y0+sin(x0)+0.4)*cos(x0))/(2-sin(y0+1)*cos(x0));
  y=y0-(-(2*x0-cos(y0+1))*sin(y0+1)+2*(y0+sin(x0)+0.4))/(2-sin(y0+1)*cos(x0));
  g=x-x0;
  x0=x;
  k=y-y0;
  y0=y;
  if(i!=0)
  {
   printf("%f\n",x0);
   printf("%f\n",y0);
   i--;
  }
 }while(fabs(g)>E && fabs(k)>E);
 printf("--------------------------------\n");
 printf("��୨ ��室��� ��⥬� �ࠢ����� �� ��⮤�\n���⮭� ����� ���:\n");
 printf("%f\n",x);
 printf("%f\n",y);
 getch();
 return 0;
}
