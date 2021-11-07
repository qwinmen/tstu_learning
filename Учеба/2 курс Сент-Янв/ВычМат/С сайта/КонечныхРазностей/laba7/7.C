#include<stdio.h>
#include<math.h>
#include<stdlib.h>
#include<conio.h>
int main()
{float *u,*x,*g,*d,h,a,b;
 int i,j,k,n;
 printf("a:\n");
 scanf("%f",&a);
 printf("b:\n");
 scanf("%f",&b);
 printf("Vvedite shag:");
 scanf("%f",&h);
 n=(int)((b-a)/h); n++;
 u=(float *)malloc(n*sizeof(float));
 x=(float *)malloc(n*sizeof(float));
 g=(float *)malloc(n*sizeof(float));
 d=(float *)malloc(n*sizeof(float));
 printf("u(a):");
 scanf("%f",&u[0]);
 printf("u(b):");
 scanf("%f",&u[n-1]);
 for (i=0;i<n;i++) x[i]=i*h+a;
 g[1]=(h*h*pow((x[1]+1),3)+u[0])/(2+h*h*x[1]);
 d[1]=1/(2+h*h*x[1]);
 for(i=2;i<n-1;i++)
 {
  d[i]=1/(2+h*h*x[i]-d[i-1]);
  g[i]=(g[i-1]+h*h*pow((x[1]+1),3))/(2+h*h*x[i]-d[i-1]);
 }
 for(i=n-2;i>0;i--) u[i]=d[i]*u[i+1]+g[i];
 for(i=0;i<n;i++) {printf("Series1.AddXY(%f,%f);\n",x[i],u[i]);getch();}
 return 0;
}
