#include<conio.h>
#include<stdio.h>
#include<stdlib.h>
#include<time.h>
#include<math.h>
int main()
{
clock_t start1, start2, end1, end2;
int k,i,j,n=30,f,h,**a;
double sum1=0,sum2=0;
float time1, time2, time3;
clrscr();
while(1) {
n=n+1;
a=(int**)malloc(n*sizeof(int*));
for(i=0;i<n;i++)
a[i]=(int*)malloc(n*sizeof(int));
randomize();
for(i=0;i<n;i++)
for(j=0;j<n;j++)
a[i][j]=random(1);

start1=clock();
for(k=0;k<30000;k++)
for(i=0;i<n;i++)
for(j=0;j<n;j++)
sum1=sum1+a[i][j];
end1=clock();
time1=((end1-start1)/CLK_TCK);
printf("\nThe first sum: %f\n", time1);
start2=clock();
for(k=0;k<30000;k++)
for(j=0;j<n;j++)
for(i=0;i<n;i++)
sum2=sum2+a[i][j];
end2=clock();
time2=((end2-start2)/CLK_TCK);
printf("The second sum: %f\n", time2);
time3=time2-time1;
if(time3!=0)
{
	h=(n*n)*4;
        h=h/1024;
	printf("\nL1-Cache: %d kb", h);
        printf("\nn=%d",n);
        break;
    }
}
for(i=0;i<n;i++) free(a[i]);
free(a);
getch();
return 0;
}  