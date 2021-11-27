#include <iostream>
#include <stdio.h>
#include <math.h>

using namespace std;
double k=1, k1=1;

double f (double x, double y)
{
    return x*x+y*y;
}
double f1(double x, double y)
{
    return 2*x+y-8;
}
double f2(double x, double y)
{
    return x+y;
}



/*bool oblast (double x, double y)
{
    if (f(x,y))
}
*/
double R (double x, double y)
{

    return f(x,y)-1/k*(log(f1(x,y))+log(f2(x,y)));
// return f(x,y);
}

double dxF(double x, double y, double dx)
{
    return (R(x+dx,y)-R(x,y))/dx;
}

double dyF(double x, double y, double dy)
{
    return (R(x,y+dy)-R(x,y))/dy;
}



int main()
{
    double x=1,y=10, dx = 0.01, dy = 0.01,h1=0.0001,h2=0.0001, xMin=1000, yMin=10000;
    k=1;
    int n=0, i;
    float p1, p2;
    // while ()
   // while (sqrt(pow((xMin-x),2)+pow((yMin-y),2))>0.001)
   while (fabs(R(x,y)-R(xMin, yMin))>0.0001)
    {
        //printf("!!!");
        xMin=x;
        yMin=y;
        //  printf("%d ", i);
        p1=h1*dxF(x,y,dx);
        p2=h2*dyF(x,y,dy);
        //printf("p1=%f p2=%f\n",p1,p2);
        while ((fabs(p1)+fabs(p2))>0.00001)
        {

            x=x-p1;
            y=y-p2;
            p1=h1*dxF(x,y,dx);
            p2=h2*dyF(x,y,dy);
           // printf("p1=%f p2=%f\n",p1,p2);
            n++;
            printf("%f %f\n", x, y);
        }
        k1=10*k1;
        k=10*k;
    }

    printf("ans= %f %f", x, y);

    return 0;
}
