#include <stdio.h>
#include <math.h>
#include <conio.h>
#include <stdlib.h>
#define pi 3.14159265358979323846
struct tochka {double x1; double x2; };

double e,e1,k=1,ks,h,delta=0.0000001; struct tochka x; int i=0,pok,uk;
double fun(double x1, double x2)
{if(pok==1) return pow(((x1-3)*cos(5*pi/180)+(x2-5)*sin(5*pi/180)),2)/4+pow(((x2-5)*cos(5*pi/180)-(x1-3)*sin(5*pi/180)),2)/9; else return 100*pow((x2-x1*x1),2)+pow((1-x1),2);}

double min(double a, double b) {if(a<b) return a;  else return b;}

double shtraf1(double x1, double x2) {return x2*x1*exp(x2)-2*x1-5*x2+4;}

double fi(double x1, double x2) {return (min(0, shtraf1(x1,x2))+min(0, x1));}

struct tochka gradfi(double x1, double x2) {struct tochka t; t.x1=(fi(x1+delta, x2)-fi(x1, x2))/delta;
 t.x2=(fi(x1, x2+delta)-fi(x1, x2))/delta; return t;}

struct tochka move(struct tochka x1)
{struct tochka grad, x; x=x1;
 while(shtraf1(x.x1,x.x2)<0 || x.x1<0) {grad=gradfi(x.x1,x.x2); x.x1=x.x1+h*grad.x1; x.x2=x.x2+h*grad.x2;	}
 return x;}

double S(double x1, double x2) {return (k*pow(shtraf1(x1,x2),2));}

double R(double x1, double x2) {return (fun(x1,x2)+S(x1,x2));}

struct tochka simplex(struct tochka xg)
{struct tochka t; double fc,fo,fl,fr,fs,fh,fg,sigma,f; struct tochka xo,xc,xh,xl,xr,xs;
 xl.x1=xg.x1+ks; xl.x2=xg.x2; xh.x1=xg.x1; xh.x2=xg.x2+ks;
 xg=move(xg); xh=move(xh); xl=move(xl);
do{if(R(xh.x1,xh.x2)<=R(xg.x1,xg.x2)) {xc.x1=xh.x1;xc.x2=xh.x2;
                                       xh.x1=xg.x1;xh.x2=xg.x2;
                                       xg.x1=xc.x1;xg.x2=xc.x2;}
if(R(xh.x1,xh.x2)<=R(xl.x1,xl.x2)){
                                   xc.x1=xh.x1;xc.x2=xh.x2;
                                   xh.x1=xl.x1;xh.x2=xl.x2;
                                   xl.x1=xc.x1;xl.x2=xc.x2;}
 if(R(xg.x1,xg.x2)<=R(xl.x1,xl.x2)) {
                                    xc.x1=xg.x1;xc.x2=xg.x2;
                                    xg.x1=xl.x1;xg.x2=xl.x2;
                                    xl.x1=xc.x1;xl.x2=xc.x2;	}
 xc.x1=(xl.x1+xg.x1)/2;
 xc.x2=(xl.x2+xg.x2)/2;
 fc=R(xc.x1,xc.x2);
 xo.x1=2*xc.x1-xh.x1;
 xo.x2=2*xc.x2-xh.x2;
 fo=R(xo.x1,xo.x2);
 fl=R(xl.x1,xl.x2);
 fh=R(xh.x1,xh.x2);
 fg=R(xg.x1,xg.x2);
 if(fo<fl)	{xr.x1=-xc.x1+2*xo.x1;
             xr.x2=-xc.x2+2*xo.x2;
			 fr=R(xr.x1,xr.x2);
 if(fr<fl)	{xh.x1=xr.x1;
             xh.x2=xr.x2;}
 else	{xh.x1=xo.x1;
         xh.x2=xo.x2;}
			}
 else if(fo<fg)		{xh.x1=xo.x1;
                     xh.x2=xo.x2;}
 else {if(fo<fh) {xs.x1=0.5*xc.x1+0.5*xo.x1;
                  xs.x2=0.5*xc.x2+0.5*xo.x2;}
 else	{xs.x1=0.5*xc.x1+0.5*xh.x1;
         xs.x2=0.5*xc.x2+0.5*xh.x2;	}
			  fs=R(xs.x1,xs.x2);
			  fh=R(xh.x1,xh.x2);
if(fs<fh) {xh.x1=0.5*xs.x1+0.5*xs.x1;
           xh.x2=0.5*xs.x2+0.5*xs.x2;}
else	  {xh.x1=xh.x1+0.5*(xh.x1-xl.x1);
           xh.x2=xh.x2+0.5*(xh.x2-xl.x2);
           xg.x1=xg.x1+0.5*(xg.x1-xl.x1);
           xg.x2=xg.x2+0.5*(xg.x2-xl.x2);}
			}
f=(fl+fg+fh)/3; sigma=pow((pow(fl-f,2)+pow(fg-f,2)+pow(fh-f,2))/3,0.5);
}while(sigma>e);
if(R(xl.x1,xl.x2)>R(xg.x1,xg.x2)) {xl.x1=xg.x1; xl.x2=xg.x2;}
if(R(xl.x1,xl.x2)>R(xh.x1,xh.x2)) {xl.x1=xh.x1; xl.x2=xh.x2;}
t.x1=xl.x1;t.x2=xl.x2;return t;
}

int main()
{struct tochka q;
 printf("Vvedite nomer functsii: \n1)f(x1,x2)=((x1-3)cos(150)+(x2-5)sin(150))^2/4+((x2-5)cos(150)-(x1-3)sin(150))^2/9 \n 2)f(x1,x2)=100(x2-x1^2)^2+(1-x1)^2\n"); scanf("%u",&pok);
 if(!(pok==1 || pok==2)) exit(1); printf("Vvedite nachalnuyu tochku:\nx1 = "); scanf("%lf",&x.x1);
 printf("x2 = "); scanf("%lf",&x.x2); printf("k = "); scanf("%lf",&ks); printf("tochnost e = ");
 scanf("%lf",&e); printf("tochnost e1 = "); scanf("%lf",&e1); printf("h = "); scanf("%lf",&h);
 q=simplex(x);
 do{k=k*10; x=q; printf("\n\nMIN:\nx1 = %f\nx2 = %f",x.x1,x.x2); q=simplex(x);
 }while(pow((q.x1-x.x1)*(q.x1-x.x1)+(q.x2-x.x2)*(q.x2-x.x2),2)>e1);
 printf("\n\nMINIMUM:\nx1 = %f\nx2 = %f\nf = %f",q.x1,q.x2,fun(q.x1,q.x2));
getch();return 0;
}
