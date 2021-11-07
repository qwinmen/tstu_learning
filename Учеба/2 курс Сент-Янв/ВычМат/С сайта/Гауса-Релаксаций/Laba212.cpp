#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <conio.h>
int main()
{
 float **m,**m1, *r, *r1, max, pr;
 int l,n,i,j,x,y,z,nmax;
 float yg;
 printf("Введите число неизвестных\n");
 scanf("%u",&n);
 r=(float*)malloc(n*sizeof(float));
 r1=(float*)malloc(n*sizeof(float));
 m=(float**)malloc(n*sizeof(float*));
 m1=(float**)malloc(n*sizeof(float*));
 for(i=0;i<=n;i++)
 {
  m[i]=(float*)malloc(n*sizeof(float));
  m1[i]=(float*)malloc(n*sizeof(float));
 }
 printf("Вводите коэффициенты и свободные члены по строкам\n");
 for(i=0;i<n;i++)
 {
  for(j=0;j<=n;j++) scanf("%f", &m[i][j]);
 }
 for(i=0;i<n;i++)
 {
  for(j=0;j<=n;j++) m1[i][j]=m[i][j];
 }
 for(z=0;z<n-1;z++)
 {
  for(y=z;y<n-1;y++)
  {
   for(x=n;x>=z;x--) m[y+1][x]=m[y+1][x]-m[y+1][z]/m[z][z]*m[z][x];
  }
 }
 for(x=n-1;x>=0;x--)
 {
  yg=0;
  for(y=n-1;y>x;y--) yg=yg+m[x][y]*m[y][y];
  m[x][x]=(m[x][n]-yg)/m[x][x];
 }
 printf("Метод Гаусса:\n\n");
 for(i=0;i<n;i++) printf("x%u=%f\n",i+1,m[i][i]);
 printf("\n\n");
 for(i=0;i<n;i++)
 {
  m1[i][n]=-m1[i][n];
  yg=m1[i][i];
  for(j=0;j<=n;j++) m1[i][j]=-m1[i][j]/yg;
  m1[i][i]=-1;
 }
 printf("Метод Релаксаций\n");
 l=0;
 for(i=0;i<n;i++)
 {
  for(j=0;j<=n;j++) if(m1[i][i]>m1[i][j]) l++;
  if(l==0)
  {
   printf("Вводите начальные приближения\n");
   for(i=0;i<n;i++) scanf("%f",&r[i]);
   for(i=0;i<n;i++) r[i]=r1[i]=0;
   for(i=0;i<n;i++)
   {
    for(j=0;j<n;j++) r[i]=m1[i][j]*r1[j]+r[i];
    r[i]=r[i]+m1[i][n];
   }
   for(i=0;i<n;i++) r1[i]=0;
   do
   {
    nmax=0;
    max=r[0];
    for(i=1;i<n;i++) if(r[i]>max) {max=r[i];nmax=i;}
    pr=max;
    for(i=0;i<n;i++) r[i]=r[i]+m1[i][nmax]*max;
    r1[nmax]=r1[nmax]+max;
   }while(fabs(pr)>0.00000001);
   for(i=0;i<n;i++) printf("\tx%u=%f\n",i+1,r1[i]);
   }
   else printf(" для данной системы не сходится\n");
   for(i=0;i<=n;i++) {free(m1[i]); free(m[i]);}
   free(m1);
   free(m);
   free(r1);
   free(r);
   getch();
   return 0;
  }
 }




