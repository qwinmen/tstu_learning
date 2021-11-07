#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<math.h>
void MG(float**c,float*b,float*a,int n);
float fun(float a,int n);
int main()
{
  float p=0,pgr=0,e;
  int i,j,k,n,m;
  printf(" Kalichestvo tochek:");
  scanf("%d",&n);
  float *x=(float*)malloc(n*sizeof(float));
  float *y=(float*)malloc(n*sizeof(float));
  float *r=(float*)malloc(n*sizeof(float));
  for(i=0;i<n;i++)
  {
   printf("\tx(%d)=",i+1);
   scanf("%g",&x[i]);
   printf("\ty(%d)=",i+1);
   scanf("%g",&y[i]);
  }
  printf("Vvedite tochnocb'=");
  scanf("%g",&e);

  m=1;
  pgr=100;
  printf("===polinomu:===\n");
  while (pgr>e)
  {
    pgr=0;
    float **c=(float**)malloc((m)*sizeof(float*));
    for (i=0;i<=m;i++)
    {
     c[i]=(float*)malloc((m)*sizeof(float));
    }
    float *b=(float*)malloc((m)*sizeof(float));
    float *a=(float*)malloc((m)*sizeof(float));
    for (i=0;i<m;i++)
    {
     for (j=0;j<m;j++)
     {
      p=0;
      for (k=0;k<n;k++)
      {
       p=p+fun(x[k],j+i);
      }
      c[i][j]=p;
     }
     p=0;
     for (k=0;k<n;k++)
     {
      p=p+y[k]*fun(x[k],i);
     }
     b[i]=p;
    }
    MG(c,b,a,m);
    pgr=0;
    for (i=0;i<n;i++)
    {
      p=0;
      for (k=0;k<m;k++)
      {
       p=p+a[k]*fun(x[i],k);
      }
      r[i]=fabs((p-y[i])/y[i])*100/n;
      pgr=pgr+r[i];
        }
    printf("y= ");
    for (i=0;i<m;i++)
    {
printf(" + %.4g*x^%d",a[i],i);
    }
   printf("\tPGRRESHNOST' %.4g%\n",pgr);
     
    free(b);
    free(a);
    for (i=0;i<m;i++)
    {
     free(c[i]);
    }
    free(c);
    m++;
  }
  free(x);
  free(y);
  free(r);
  return 0;
}


void MG(float**a,float*b,float*x,int n)
{
 int k=0,i,j;
 float m;
 
 for(i=0;i<n-1;i++)
 {
  for(k=i+1;k<n;k++)
  {
   m=a[k][i]/a[i][i];
   a[k][i]=0;
   for(j=i+1;j<n;j++)
   {
    a[k][j]=a[k][j]-m*a[i][j];
   }
   b[k]=b[k]-m*b[i];
  }
 }

for(i=0;i<n;i++)
  x[i]=0;
    
 for(i=n-1;i>=0;i--)
 {
  m=0;
  for(j=i+1;j<n;j++)
  {
   m=m+a[i][j]*x[j];
  }
  x[i]=(b[i]-m)/a[i][i];
 }
return;
}


float fun(float a,int n)
{
 int i;
 float s=1;
 for(i=0;i<n;i++)
 {
  s=s*a;
 }
return s;
}