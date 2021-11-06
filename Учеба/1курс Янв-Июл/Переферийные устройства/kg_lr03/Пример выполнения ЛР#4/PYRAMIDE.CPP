#include "pyramide.h"
#include "fixed.h"

#define Kd           0.73
#define Ks           0.1

#define calcintensity                                    \
                                                         \
    n += dn;                                             \
    _n = n/n.length();                                   \
    k = _n&m_light;                                      \
    color = ambient+MIN_DEF;                             \
                                                         \
    if( k>0 )                                            \
    {                                                    \
        r.x = m_light.z*2*_n.x*_n.z-m_light.x;           \
        r.y = m_light.z*2*_n.y*_n.z-m_light.y;           \
        r.z = m_light.z*(_n.z*_n.z-_n.x*_n.x-_n.y*_n.y); \
        color += (k*Kd+(r&m_eye)*Ks)*63;                 \
    }

float sint[MAXANGLE],
      cost[MAXANGLE];

Pyramide::Pyramide(unsigned int a)
{
    if( a<DEFSIZE )
        a = DEFSIZE;

    vertex[0].x = a;
    vertex[1].y = a;
    vertex[2].z = a;
    vertex[3].x = a;
    vertex[3].y = a;
    vertex[3].z = a;

    a /= 2;
    for(int j = 0; j<PYRPOINTS; j++)
    {
        vertex[j].x -= a;
        vertex[j].y -= a;
        vertex[j].z -= a;
    }

    polys[0].pnts_n[0] = 3;
    polys[0].pnts_n[1] = 0;
    polys[0].pnts_n[2] = 2;
    facecolor[0] = 0;

    polys[1].pnts_n[0] = 2;
    polys[1].pnts_n[1] = 1;
    polys[1].pnts_n[2] = 3;
    facecolor[1] = 64;

    polys[2].pnts_n[0] = 1;
    polys[2].pnts_n[1] = 0;
    polys[2].pnts_n[2] = 3;
    facecolor[2] = 128;

    polys[3].pnts_n[0] = 2;
    polys[3].pnts_n[1] = 0;
    polys[3].pnts_n[2] = 1;
    facecolor[3] = 192;

    for(int angle = 0; angle<MAXANGLE; angle++)
    {
        sint[angle] = sin(float(angle)/MAXANGLE*2*M_PI);
        cost[angle] = cos(float(angle)/MAXANGLE*2*M_PI);
    }

    for(j = 0; j<PYRPOINTS; j++)
    {
        vertexnormals[j].x = 0;
        vertexnormals[j].y = 0;
        vertexnormals[j].z = 0;
    }

    vector3d polynormals[4];

    for(j = 0; j<4; j++)
    {
        vector3d n = (vertex[polys[j].pnts_n[1]]-vertex[polys[j].pnts_n[0]])^
                     (vertex[polys[j].pnts_n[1]]-vertex[polys[j].pnts_n[2]]);

        n /= n.length();
        polynormals[j] = n;
    }

    for(j = 0; j<4; j++)
        for(int i = 0; i<4; i++)
            if( (polys[i].pnts_n[0]==j) ||
                (polys[i].pnts_n[1]==j) ||
                (polys[i].pnts_n[2]==j) )
                vertexnormals[j] += polynormals[i];
}

Pyramide::Pyramide()
{
    Pyramide::Pyramide(DEFSIZE);
}

void Pyramide::SetLight(vector3d lightsource)
{
    m_light = (lightsource/lightsource.length());
}

void Pyramide::SetEye(vector3d eyevector)
{
    m_eye = (eyevector/eyevector.length());
}

void Pyramide::HLine(int x1, int x2, int y, char color, char far* where)
{
    char far* scr;
    int       x;

    if( x2<x1 )
    {
        scr = where+x2+(y<<8)+(y<<6);
        for(x = x2; x<x1+1; x++)
            *(++scr) = color;
    } else
    {
        scr = where+x1+(y<<8)+(y<<6);
        for(x = x1; x<x2+1; x++)
            *(++scr) = color;
    }
}

void Pyramide::SolidPoly(point2d p[], char color, char far* where)
{
    int iMin = 0, iMax = 0, iMid = 0;

    for(int i = 0; i<3; i++)
    {
        if( p[i].y<p[iMin].y )
        {
            iMin = i;
        } else
        {
            if( p[i].y>p[iMax].y )
                iMax = i;
        }
    }

    iMid = 3-iMax-iMin;
    fixed dx01 = p[iMax].y!=p[iMin].y ?
                 int2fixed(p[iMax].x-p[iMin].x)/
                 (p[iMax].y-p[iMin].y) : int2fixed(0);
    fixed dx02 = p[iMin].y!=p[iMid].y ?
                 int2fixed(p[iMid].x-p[iMin].x)/
                 (p[iMid].y-p[iMin].y) : int2fixed(0);
    fixed dx21 = p[iMax].y!=p[iMid].y ?
                 int2fixed(p[iMax].x-p[iMid].x)/
                 (p[iMax].y-p[iMid].y) : int2fixed(0);
    fixed x1 = int2fixed(p[iMin].x);
    fixed x2 = x1;

    for(i = p[iMin].y; i<=p[iMid].y; i++)
    {
        HLine(fixed2int(x1), fixed2int(x2), i, color, where);
        x1 += dx01;
        x2 += dx02;
    }

    x2 = int2fixed(p[iMid].x);
    for(i = p[iMid].y+1; i<p[iMax].y; i++)
    {
        x1 += dx01;
        x2 += dx21;
        HLine(fixed2int(x1), fixed2int(x2), i, color, where);
    }
}

void Pyramide::SolidDraw(char far* where)
{
    point2d polypoints[3];
    char    color;

    for(int j = 0; j<PYRPOINTS; j++)
    {
        for(int i = 0; i<3; i++)
        {
            polypoints[i].x = vertex[polys[j].pnts_n[i]].x+160;
            polypoints[i].y = vertex[polys[j].pnts_n[i]].y+100;
        }

        vector3d n = (vertex[polys[j].pnts_n[1]]-vertex[polys[j].pnts_n[0]])^
                     (vertex[polys[j].pnts_n[1]]-vertex[polys[j].pnts_n[2]]);
        n /= n.length();

        if( (n&m_eye)>0 )
        {
            float k = n&m_light;
            if( k>0 ) color = (j<<6)+k*(63-MIN_DEF); else
                      color = (j<<6)+1;
            SolidPoly(polypoints, color, where);
        }
    }
}

void Pyramide::PhongHLine(int x1, int x2, int y,
                          vector3d nv, vector3d nu,
                          char ambient, char far* where)
{
    char far* scr;
    int       x;
    char      color;
    vector3d  dn, n, _n, zv(0, 0, 0), r;
    float     k;

    if( x2<=x1 )
    {
        n = nu;
        dn = ( x2!=x1 ) ? (nv-nu)/(x1-x2) : zv;
        scr = where+x2+(y<<8)+(y<<6);
        for(x = x2; x<x1+1; x++)
        {
            calcintensity;
            *(++scr) = color;
        }
    } else
    {
        n = nv;
        dn = (nu-nv)/(x2-x1);
        scr = where+x1+(y<<8)+(y<<6);
        for(x = x1; x<x2+1; x++)
        {
            calcintensity;
            *(++scr) = color;
        }
    }
}

void Pyramide::PhongPoly(point2d p[], int indexes[],
                         char ambient, char far* where)
{
    int iMin = 0,
        iMax = 0,
        iMid = 0;

    for(int i = 0; i<3; i++)
    {
        if( p[i].y<p[iMin].y )
        {
            iMin = i;
        } else
        {
            if( p[i].y>p[iMax].y )
                iMax = i;
        }
    }

    iMid = 3-iMax-iMin;

    fixed    dx01 = p[iMax].y!=p[iMin].y ?
                    int2fixed(p[iMax].x-p[iMin].x)/
                    (p[iMax].y-p[iMin].y) : int2fixed(0);
    fixed    dx02 = p[iMin].y!=p[iMid].y ?
                    int2fixed(p[iMid].x-p[iMin].x)/
                    (p[iMid].y-p[iMin].y) : int2fixed(0);
    fixed    dx21 = p[iMax].y!=p[iMid].y ?
                    int2fixed(p[iMax].x-p[iMid].x)/
                    (p[iMax].y-p[iMid].y) : int2fixed(0);
    fixed    x1 = int2fixed(p[iMin].x);
    fixed    x2 = x1;
    int      niMin = indexes[iMin],
             niMid = indexes[iMid],
             niMax = indexes[iMax];
    vector3d zv(0, 0, 0),
             nu = vertexnormals[niMin],
             du = p[iMid].y!=p[iMin].y ?
                  (vertexnormals[niMid]-vertexnormals[niMin])/
                  (p[iMid].y-p[iMin].y) : zv,
             nv = vertexnormals[niMin],
             dv = p[iMax].y!=p[iMin].y ?
                  (vertexnormals[niMax]-vertexnormals[niMin])/
                  (p[iMax].y-p[iMin].y) : zv;

    for(i = p[iMin].y; i<=p[iMid].y; i++)
    {
        PhongHLine(fixed2int(x1), fixed2int(x2), i,
                   nv, nu, ambient, where);
        x1 += dx01;
        x2 += dx02;
        nu += du;
        nv += dv;
    }

    x2 = int2fixed(p[iMid].x);
    nu = vertexnormals[niMid],
    du = p[iMax].y!=p[iMid].y ?
         (vertexnormals[niMax]-vertexnormals[niMid])/
         (p[iMax].y-p[iMid].y) : zv;

    for(i = p[iMid].y+1; i<p[iMax].y; i++)
    {
        x1 += dx01;
        x2 += dx21;
        nv += dv;
        nu += du;
        PhongHLine(fixed2int(x1), fixed2int(x2), i,
                   nv, nu, ambient, where);
    }
}

void Pyramide::PhongRender(char far* where)
{
    point2d polypoints[3];
    int     vertexindexes[3];

    for(int j = 0; j<PYRPOINTS; j++)
    {
        for(int i = 0; i<3; i++)
        {
            vertexindexes[i] = polys[j].pnts_n[i];
            polypoints[i].x  = vertex[vertexindexes[i]].x+160;
            polypoints[i].y  = vertex[vertexindexes[i]].y+100;
        }

        vector3d n = (vertex[polys[j].pnts_n[1]]-vertex[polys[j].pnts_n[0]])^
                     (vertex[polys[j].pnts_n[1]]-vertex[polys[j].pnts_n[2]]);

        if( (n&m_eye)>0 )
            PhongPoly(polypoints, vertexindexes, j<<6, where);
    }
}

void Pyramide::Rotate(int alpha, int beta, int gamma)
{
    float tx, ty, tz, tx1, ty1, tz1;

    for(int j = 0; j<PYRPOINTS; j++)
    {
        tx = vertex[j].x;
        ty = vertex[j].y*cost[alpha]-vertex[j].z*sint[alpha];
        tz = vertex[j].y*sint[alpha]+vertex[j].z*cost[alpha];
        tx1 = tx*cost[beta]+tz*sint[beta];
        ty1 = ty;
        tz1 = -tx*sint[beta]+tz*cost[beta];
        vertex[j].x = tx1*cost[gamma]-ty1*sint[gamma];
        vertex[j].y = tx1*sint[gamma]+ty1*cost[gamma];
        vertex[j].z = tz1;
    }

    for(j = 0; j<4; j++)
    {
        tx = vertexnormals[j].x;
        ty = vertexnormals[j].y*cost[alpha]-vertexnormals[j].z*sint[alpha];
        tz = vertexnormals[j].y*sint[alpha]+vertexnormals[j].z*cost[alpha];
        tx1 = tx*cost[beta]+tz*sint[beta];
        ty1 = ty;
        tz1 = -tx*sint[beta]+tz*cost[beta];
        vertexnormals[j].x = tx1*cost[gamma]-ty1*sint[gamma];
        vertexnormals[j].y = tx1*sint[gamma]+ty1*cost[gamma];
        vertexnormals[j].z = tz1;
    }

}