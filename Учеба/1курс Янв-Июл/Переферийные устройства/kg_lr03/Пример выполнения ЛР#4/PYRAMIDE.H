#ifndef __PYRAMIDE__
#define __PYRAMIDE__

#include "vector3d.h"

#define PYRPOINTS    4
#define DEFSIZE      60
#define MAXANGLE     360
#define MIN_DEF      10

#define FLAT         0
#define PHONG        1

class Pyramide
{

    struct point2d
    {
        int x, y;
    };

    struct polygon
    {
        int pnts_n[3];
    };

public:
    Pyramide();
    Pyramide(unsigned int a);

    void SolidDraw(char far* where);
    void PhongRender(char far* where);
    void Rotate(int alpha, int beta, int gamma);
    void SetLight(vector3d lightsource);
    void SetEye(vector3d eyevector);

private:

    void HLine(int x1, int x2, int y, char color, char far* where);
    void SolidPoly(point2d p[], char color, char far* where);
    void PhongHLine(int x1, int x2, int y, vector3d nv, vector3d nu,
                    char color, char far* where);
    void PhongPoly(point2d p[], int indexes[],
                   char ambient, char far* where);

    vector3d vertex[PYRPOINTS];
    vector3d vertexnormals[PYRPOINTS];
    vector3d m_light;
    vector3d m_eye;
    polygon  polys[PYRPOINTS];
    char     facecolor[PYRPOINTS];
};

extern float sint[MAXANGLE];
extern float cost[MAXANGLE];

#endif __PYRAMIDE__