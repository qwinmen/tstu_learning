#ifndef _ACTION_H_
#define _ACTION_H_

#include<math.h>

double kt = 6500;
double ct = 4190;
double p = 1000;
double TT = 80;
double L = 1;
double D = 0.05;
double u = 0.2;
double tav = L/u;
double tMax = 10;
double a;
double aMin;
double aMax;
double bMin;
double bMax;
double b;
double da = 0.3;
double db = 0.2;

double T0(double _l) {
	return 20 + 10*_l;
}

double Tvx(double _t) {
	return 20 + 5*sin(_t);
}





#endif