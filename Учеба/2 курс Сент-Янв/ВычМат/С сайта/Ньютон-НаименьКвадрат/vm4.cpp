#include<stdio.h>
#include<math.h>
#include<stdlib.h>
int fact(int n)
{int i;
float f=1;
for(i=1;i<=n;i++)
  f=f*i;
return f;}
int main()
{int n,j=0;
float t1,k,k1,k2,h,i,*mas,x,t,fun,p=1,dy=1,d,a;
printf("¬ведите концы отрезка и шаг\nx начальное: ");
scanf("%f",&k1);
printf ("x конечное: ");
scanf("%f",&k2);
printf("шаг: "); 
scanf("%f",&h);
n=(k2-k1)/h;
mas=(float *)malloc(n*sizeof(float));
printf("¬водите ординаты точек:\n");
for(i=k1;i<=k2;i=i+h){
  printf ("x=%f		y=",i);
  scanf("%f",&mas[j]);
  j++;
  }
printf("\n¬ведите абсциссу интересующей ¬ас точки: x=");
scanf("%f",&x);
t1=t=(x-k1)/h;
fun=mas[0];
for(i=0;i<n;i++)
{k=1;
dy=mas[i+1];
for(d=0;d<i+1;d++)
{k=i+1;
 for(a=0;a<d;a++)
   k=k*(i-a);
 dy=dy+pow(-1,d+1)*k/fact(d+1)*mas[i-d];
 }
 fun=fun+t*dy/fact(i+1);
 t=t*(t1-(i+1));
 }
printf("\n«начение функции в данной точке равно %f",fun);
return 0;
}