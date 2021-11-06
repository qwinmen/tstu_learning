#include "fixed.h"

fixed* sintable;
fixed* costable;

void InitTables()
{
    sintable = new fixed[8192];
    costable = new fixed[8192];

    for(int i = 0; i<8192; i++)
    {
        float x = i*2*M_PI/8192.0;

        sintable[i] = float2fixed(sin(x));
        costable[i] = float2fixed(cos(x));
    }
}

void FreeTables()
{
    delete sintable;
    delete costable;
}