#ifndef _ACTION_H_
#define _ACTION_H_

#include<math.h>

double a = 0.013; //�*�.�
double dx = 0.1; //�
//double dt = 0.5*dx*dx;
double dt = 1;
double XMin = 0;
double X = 1; //�
double tMin = 0;
double tMax = 100; //�

double fi(double _x) {
	return 20 + 10*_x;
}

double f1(double _t) {
	return 20 + 5*sin(_t);
}

double f2(double _t) {
	return 30;
}


#endif