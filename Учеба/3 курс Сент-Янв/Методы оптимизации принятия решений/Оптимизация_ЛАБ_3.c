#include <stdio.h>
#include <conio.h>
#include <math.h>
struct point{double x[30];};
double fx(double t,struct point a);
double dx(double t,struct point a);
double fy(double t,struct point a);
double dy(double t,struct point a);
double d2x(double t,struct point a);
double func(struct point a);double t,dt=0.01;
struct point Simplex(void);
int n,i; FILE *fout; double alpha=1.0,beta=2.0,gamma=0.5,sigma; 
void main(void)
{
 struct point a;
 printf("n=");
 scanf("%d",&n);
 a=Simplex();
 fout=fopen("out.txt","w"); 
  for(t=0.0;t<=1+dt;t=dt+t)
	fprintf(fout,"%lf\t%lf\t%lf\n",t,2*t*t-t*t*t,fx(t,a));
 getch();
 fclose(fout);
}
double fx(double t,struct point a)
{
 double W[30],sum=0.0;
 W[0]=2*t*t-t*t*t;
  for(i=1;i<n+1;i++)
  {W[i]=a.x[i-1]*(t-0)*(t-0)*(t-1)*(t-1)*pow(t,i); sum=sum+W[i];}
 return (W[0]+sum);
}
double d2x(double t,struct point a)
{
 double dt=1e-3;
 return (	(fx(t+2*dt,a)-2*fx(t+dt,a)+fx(t,a))/(dt*dt)	); 
}
double func(struct point a)
{
 double t,dt=0.01,J=0.0;
  for(t=0.0;t<=1.57;t=t+dt)J=J+0.5*(pow(d2x(t,a),2)*dt);
 return J;
}
int i,j;
struct point Simplex(void)
{
 struct point Xg,Xh,Xl,Xr,Xs,Xc,Xo,tmp;
 double Fg,Fh,Fl,Fr,Fs,Fc,Fo,e,k,F;
 k=0.5;e=1e-3;
  for(i=0;i<n;i++)Xg.x[i]=1.0;
 Xl.x[0]=Xg.x[0]+k;
 Xh.x[n-1]=Xg.x[n-1]+k;
  for(i=1;i<n;i++){	Xl.x[i]=Xg.x[i];Xh.x[i-1]=Xg.x[i-1];	}
 i=0;
  do{
     i++;
	 if(func(Xh)<=func(Xg)){tmp=Xh;Xh=Xg;Xg=tmp;}
	 if(func(Xh)<=func(Xl)){tmp=Xh;Xh=Xl;Xl=tmp;}
	 if(func(Xg)<=func(Xl)){tmp=Xg;Xg=Xl;Xl=tmp;}
	  Fh=func(Xh);Fg=func(Xg);Fl=func(Xl);
	 for(j=0;j<n;j++)	printf("\n%d Xh=%lf Xg=%lf Xl=%lf",j+1,Xh.x[j],Xg.x[j],Xl.x[j]);
	 printf("\nFh=%lf, Fg=%lf, Fl=%lf",Fh,Fg,Fl);
	 for(j=0;j<n;j++)	Xc.x[j]=(Xl.x[j]+Xg.x[j])/2.0;
	 Fc=func(Xc);
	 for(j=0;j<n;j++)	Xo.x[j]=(alpha+1.0)*Xc.x[j]-alpha*Xh.x[j];
	 Fo=func(Xo);
	 if(Fo<Fl)
	 {
		printf(">>>>>>|Sjatie ");
		for(j=0;j<n;j++)	Xr.x[j]=(1.0-beta)*Xc.x[j]+beta*Xo.x[j];
		Fr=func(Xr);
		if(Fr<Fl){Xh=Xr;}else{Xh=Xo;}
	 }else{	if(Fl<Fo&&Fo<=Fg){Xh=Xo;}else{printf(">>>>>> Rastajenie ");
			if(Fo<Fh){for(j=0;j<n;j++)Xs.x[j]=gamma*Xo.x[j]+(1.0-gamma)*Xc.x[j];}
	  else{ for(j=0;j<n;j++)Xs.x[j]=gamma*Xh.x[j]+(1.0-gamma)*Xc.x[j];}
			Fh=func(Xh);Fs=func(Xs);
			if(Fs<Fh){for(j=0;j<n;j++)Xh.x[j]=gamma*Xs.x[j]+(1-gamma)*Xs.x[j];}
	  else{ for(j=0;j<n;j++){Xh.x[j]=Xh.x[j]+0.5*(Xh.x[j]-Xl.x[j]);
							 Xg.x[j]=Xg.x[j]+0.5*(Xg.x[j]-Xl.x[j]);
							}
		  }								 }//END else{printf(">>>>>> Rastajenie ");						
		  }//END else{	if(Fl<Fo&&Fo<=Fg){Xh=Xo;}	 
	 F=(Fh+Fg+Fl)/3.0;sigma=sqrt(	(pow(Fl-F,2)+pow(Fg-F,2)+pow(Fh-F,2))/3.0	);
	 printf("\n sigma= %lf",sigma);
	 if(!(i%4))getch();
	 
	}while(sigma>e); 
	
	if(func(Xl)>func(Xg))Xl=Xg;
	if(func(Xl)>func(Xh))Xl=Xh;
	printf("\nNumber of iterrations: %d",i);printf("\nMin: ");
	for(j=0;j<n;j++)printf("a%d=%lf ",j,Xl.x[j]);
	printf("J(X)=%lf",func(Xl));
	return Xl;
}
