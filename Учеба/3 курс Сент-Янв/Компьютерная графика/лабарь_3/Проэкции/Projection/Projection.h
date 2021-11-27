#pragma once

#include "resource.h"
#include <iostream>

using namespace std;

#define S 4

typedef struct Vertex * PVertex;
struct Vertex{ double x, y, z; Vertex *next; }; typedef struct Vertex Vertex;
typedef struct VT * PVT;
struct VT{int v;PVT next;}; typedef struct VT VT;
typedef struct SIDE * PSIDE;
struct  SIDE{int color;int n;PVT w;PSIDE next;};typedef struct SIDE SIDE;
typedef struct VERGE * PVERGE;
struct VERGE{int v1, v2;PSIDE ps1, ps2;PVERGE next;}; typedef struct VERGE VERGE;

class Point {
public:
	double x, y, z;
	Point(double _x=0, double _y=0, double _z=0):x(_x),y(_y),z(_z){;};
};

class stMatrix {
public:
	double d[S][S];
	stMatrix();
	stMatrix operator *(stMatrix & m);
	friend istream &operator >> (istream &in, stMatrix & m);
	friend ostream &operator << (ostream &out, stMatrix & m);
};
stMatrix::stMatrix() {
	for (int i = 0; i < S; i++)
		for (int j = 0; j < S; j++) d[i][j] = 0;
	for(int i=0; i<S;i++) d[i][i]=1;
}
stMatrix stMatrix::operator * (stMatrix & m){
	stMatrix res;
	for (int i = 0; i < S; i++){
		for(int j = 0; j < S; j++) {
			res.d[i][j] = 0;
			for(int k = 0; k < S; k++) res.d[i][j] += (*this).d[i][k] * m.d[k][j];
		}
	}
	return res;
}

istream & operator >> (istream &in, stMatrix & m){
	for (int i = 0; i < S; i++) {
		for (int j = 0; j < S; j++) in >> m.d[i][j];
	}
	return in;
}
ostream & operator << (ostream & out, stMatrix & m) {
	for (int i = 0; i < S; i++) {
		out << m.d[i][0];
		for (int j = 1; j < S; j++) out << " " << m.d[i][j];
		out << endl;
	}
	return out;
}

class Vect{
public:
	double v[S];
	Vect(){;};
	Vect(Point &);
	Vect &PtoV(Point &);
	Vect &VertexToVect(Vertex & vv);
	Vect operator *(stMatrix & m);
	Point VtoP(void);
	friend istream & operator >> (istream & in, Vect & v);
	friend ostream & operator << (ostream & out, Vect & v);
};

Vect::Vect(Point &p) {
	v[0] = p.x;
	v[1] = p.y;
	v[2] = p.z;
	v[3] = 1;
}
Vect & Vect::PtoV(Point & p) {
	v[0] = p.x; v[1] = p.y; v[2] = p.z; v[3] = 1;
	return (*this);
}

Point Vect::VtoP() {
	Point p;
	p.x = v[0]; p.y = v[1]; p.z = v[2];
	return p;
}

Vect Vect::operator *(stMatrix & m) {
	Vect r;
	for (int i = 0; i < S; i++) {
		r.v[i] = 0;
		for (int j = 0; j < S; j++)
			r.v[i] += v[j]*m.d[j][i];
	}
	for (int i = 0; i < S; i++) r.v[i] /= r.v[3];
	return r;
}

istream & operator >> (istream &in, Vect & v) {
	for (int i = 0; i < S; i++) in >> v.v[i];
	return in;
}
ostream &operator << (ostream & out, Vect & v) {
	out << v.v[0];
	for (int i = 1; i < S; i++) out << " " << v.v[i];
	out << endl;
	return out;
}

Vect & Vect::VertexToVect(Vertex & vv){
	v[0] = vv.x; v[1] = vv.y; v[2] = vv.z; v[3] = 1;
	return (*this);
}

