#ifndef __FIXED__
#define __FIXED__

#include "math.h"

#define ANGLE_90  16384U
#define ANGLE_180 32768U
#define ANGLE_270 49152U
#define MAX_FIXED 0x7fffffff
#define ONE       0x10000L

typedef long           fixed;
typedef unsigned short angle;

extern fixed* sintable;
extern fixed* costable;

inline fixed int2fixed(int x)
{
    return ((fixed)x)<<16;
}

inline int frac2fixed(int a, int b)
{
    return (fixed)((((fixed) a)<<16)/((fixed) b));
}

inline fixed float2fixed(float x)
{
    return (fixed)(65536.0*x);
}

inline int fixed2int(fixed x)
{
    return (int)(x>>16);
}

inline float fixed2float(fixed x)
{
    return ((float) x)/65536.0;
}

inline fixed fixabs(fixed x)
{
    return x>0 ? x:-x;
}

inline fixed frac(fixed x)
{
    return x&0xffffL;
}

inline fixed sin(angle ang)
{
    return sintable[ang>>3];
}

inline fixed cos(angle ang)
{
    return costable[ang>>3];
}

inline angle rad2angle(float ang)
{
    return (angle)(32768.0*ang/M_PI);
}

inline float angle2rad(angle ang)
{
    return ((float) ang)*M_PI/32768.0;
}

void InitTables();
void FreeTables();

#endif