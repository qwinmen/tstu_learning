#include <iostream>
#include <math.h>
#include <conio.h>
using namespace std;
   int main()
     {
         /* double u,i,p,f,pi;
          double r,z,x,l;
          pi = 3.14;
          u = 41;
          i = 0.13;
          p = 0.5;
          f = 50;
          z = u/i;
          r = p/(i*i);
          x = sqrt(z*z - r*r);
          l = x/(2*pi*f);
          cout<<"z = "<<z<<"\t"<<"r = "<<r<<"\t"<<"x = "<<x<<"\t"<<"l = "<<l<<endl;  */
          double u,i,p,uk,uc,z,x,c,a,pi,f;
          pi = 3.14;
          f = 50;
          u = 31;
          i = 0.22;
          p = 2;
          uk = 62;
          uc = 31;
          z = u/i;
          x = uc/i;
          c = 1e6/(2*pi*f*x);
          a = p/(i*u); 
          cout<<"z = "<<z<<"\t"<<"x = "<<x<<"\t"<<"c = "<<c<<"\t"<<"cos (fi) = "<<a<<endl;  
                   getch();        
     }
