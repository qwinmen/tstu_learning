#include <stdio.h>
#include <conio.h>
#include <math.h>
long step (long a, long b)
{
long q=1;
long i;
for (i=1;i<(b+1);i++)
{
q=q*a;
}
return q;
}
int kol (long a, int b)
{
int c,k;
k=0;
while (a>0)
{
int c,k;
k=0;
while (a>0)
{
c=a%10;
a/=10
if (c==b) {k++;}
}
return k;
}
long udl (long a, int b)
{
long b1,i;
int c;
i=0;
b1=0;
while (a>0)
{
c=a%10;
a/=10;
if (c!=b)
{
b1=b1+c*step(10,i);
i++;
}

}
return b1;
}
int main ()
{
clrscr();
int c,max,k,mk,f,i;
long a,b,b1;
mk=0;
max=0;
/* printf ("a = \n");
scanf ("%d",&a); */
a=7818766;
b=a;
f=1;
while (b>0)
{
c=b%10;
if (c!=max)
{
k= kol (a,c);
if (k==mk) {f++; max=c: mk=k:}
if (k>mk) {max=c; mk=k;f=1;}
}
b/=10;
}

b=a;
b1=a;
i=1;
if (f==1) {printf ("%d",max);}
if (f>1)
{
while (i==1)
{
i=0;
c=b1%10;
k=kol (b1,c);
if (k==mk)
{
printf("%d",c);
b1= udl(b1,c);
i=1;
}

}
}

getch();
return 0;
}