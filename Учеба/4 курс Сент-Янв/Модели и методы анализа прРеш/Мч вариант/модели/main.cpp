#include <iostream>
#include <conio.h>
#include <stdio.h>
#include <math.h>

using namespace std;

int main()
{
double alf1=2, alf2=2, E1=33800,A1=200, A2=500, E2=41200, M=16, Tmin=450, Tmax=540;
double u=0.5, ro=1.1, dt=0.001, k=10*exp(-0.6*dt);
double R=8.31;

double k1,k2;

double* C1=new double [1000];
double* C2=new double [1000];
double* C3=new double [1000];
C1[0]=0.4*ro/(double)0.028,C2[0]=0.4*ro/(double)0.032, C3[0]=0.2*ro/(double)0.044;
double Cogr=0.5*ro/(double)0.044;
printf("Ogr=%f\n", Cogr);
printf("C3[0]=%f\n",C3[0]);

//k1=A1*exp(-E1/(double)(R*Tmin));
  //  k2=A2*exp(-E2/(double)(R*Tmin));
double L=150, dl=0.01, st, now;
int i;

for(double j=Tmin;j<Tmax;j++)
{
    k1=A1*exp(-E1/(R*j));
    k2=A2*exp(-E2/(R*j));
  //  printf("k1=%f k2=%f\n",k1,k2);
for(int i=0;i<=L;i++)
{

    C1[i+1]=C1[i]+((-2*k1*C1[0]*C2[0])-(k2*C1[0]*C2[0]))/(double)u*dl;
    C2[i+1]=C2[i]+(-k1*C1[0]*C2[0]-3*k2*C1[0]*C2[0])/(double)u*dl;
    C3[i+1]=C3[i]+(2*k1*C1[0]*C2[0])/(double)u*dl;
     if(C3[i+1]>Cogr)
     {
         printf("i=%i\n",i);
     break;

     }

    //printf("%f %f %f",C1[i+1],C2[i+1],C3[i+1]);
   // printf("\n");
}
}
//double L=i;

printf("\n");
 //printf("%f %f %f",C1[1],C2[1],C3[1]);
    return 0;
}




    // #include <iostream>
    // #include <conio.h>
    // #include <stdio.h>
    // #include <math.h>
     
    // using namespace std;
     
    // int main()
    // {
    // double alf1=2, alf2=2, E1=33800,A1=200, A2=500, E2=41200, M=16, Tmin=450, Tmax=540;
    // double u=0.5, ro=1.1, dt=0.001, k=10*exp(-0.6*dt);
    // double R=8.31;
     
    // double k1,k2;
     
    // double* C1=new double [1000];
    // double* C2=new double [1000];
    // double* C3=new double [1000];
    // C1[0]=0.4*ro/(double)0.028,C2[0]=0.4*ro/(double)0.032, C3[0]=0.2*ro/(double)0.044;
    // double Cogr=0.5*ro/(double)0.044;
    // printf("Ogr=%f\n", Cogr);
    // printf("C3[0]=%f\n",C3[0]);
     
    // //k1=A1*exp(-E1/(double)(R*Tmin));
      // //  k2=A2*exp(-E2/(double)(R*Tmin));
    // double L=150, dl=0.001, st, now;
    // int i;
     
    // for(double j=Tmin;j<=Tmax;j++)
    // {
        // k1=A1*exp(-E1/(R*j));
        // k2=A2*exp(-E2/(R*j));
      // //  printf("k1=%f k2=%f\n",k1,k2);
      // double l=0;
    // for(int i=0;i<10000;i++)
    // {
     
        // C1[i+1]=C1[i]+((-2*k1*C1[i]*C2[i])-(k2*C1[i]*C2[i]))/(double)u*dl;
        // C2[i+1]=C2[i]+(-k1*C1[i]*C2[i]-3*k2*C1[i]*C2[i])/(double)u*dl;
        // C3[i+1]=C3[i]+(2*k1*C1[i]*C2[i])/(double)u*dl;
     
         // if(C3[i+1]>Cogr)
         // {
             // printf("l=%f\n",l);
         // break;
         // }
             // l+=dl;
     
        // //printf("%f %f %f",C1[i+1],C2[i+1],C3[i+1]);
       // // printf("\n");
    // }
    // }
    // //double L=i;
     
    // printf("\n");
     // //printf("%f %f %f",C1[1],C2[1],C3[1]);
        // return 0;
    // }


