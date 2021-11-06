#include "vga.h"
#include "vector3d.h"
#include "conio.h"
#include "dos.h"
#include "stdlib.h"
#include "alloc.h"
#include "mem.h"
#include "math.h"
#include "pyramide.h"

#define KB_NONE      0
#define KB_ENTER     13
#define KB_ESC       27
#define KB_SPACE     32
#define KB_BACKSPACE 8

#define MAXCOLOR     63
#define MIN_INT      0.15

void Rotate(int alpha, int beta, int gamma, vector3d& vec)
{
    float tx, ty, tz, tx1, ty1, tz1;

    tx = vec.x;
    ty = vec.y*cost[alpha]-vec.z*sint[alpha];
    tz = vec.y*sint[alpha]+vec.z*cost[alpha];
    tx1 = tx*cost[beta]+tz*sint[beta];
    ty1 = ty;
    tz1 = -tx*sint[beta]+tz*cost[beta];
    vec.x = tx1*cost[gamma]-ty1*sint[gamma];
    vec.y = tx1*sint[gamma]+ty1*cost[gamma];
    vec.z = tz1;
}

void main()
{
    char far* video  = (char far*) MK_FP(0xA000, 0);
    char far* buffer = (char far*) farmalloc(SCREENSIZE);
    char far* buf;
    Pyramide  p;
    int       i;
    RGBpal    pal;
    vector3d  eye(0, 0, 1);
    vector3d  light(0, 0, 120);
    int       objectrotate = 1,
              lightrotate = 0,
              rendermode = FLAT;
    char      key;

    cprintf("\n\r Клавиши yпpавления:\n\r");
    cprintf("   ESC       - выход,\n\r");
    cprintf("   ENTER     - вpащение/оcтановка объекта,\n\r");
    cprintf("   SPACE     - вpащение/оcтановка иcточника cвета,\n\r");
    cprintf("   BACKSPACE - закpаcка Ламбеpта/Фонга.\n\r");
    cprintf(" Hажмите ESC.");

    key = KB_NONE;
    while( key!=KB_ESC )
    {
        if( kbhit() )
            key = getch();
    }
    key = KB_NONE;

    vgaon();
    clearscreen(buffer);

    for(int j = 0; j<64; j++)
    {
        if( j<64-MIN_DEF )
        {
            float k = ((float) j)/(65-MIN_DEF);

            if( k<MIN_INT )
                k = MIN_INT;

            setpal(j, k*63, k*63, k*63);
            setpal(j+64, k*63, 0, 0);
            setpal(j+64*2, 0, k*63, 0);
            setpal(j+64*3, 0, 0, k*63);
        } else
        {
            float k = ((float) j-64)/MIN_DEF;
            setpal(j, 63, 63, 63);
            setpal(j+64, 63, 63*k, 63*k);
            setpal(j+64*2, 63*k, 63, 63*k);
            setpal(j+64*3, 63*k, 63*k, 63);
        }
    }

    setpal(0, 0, 0, 0);
    p.Rotate(130, 20, 30);
    p.SetLight(light);
    p.SetEye(eye);

    while( key!=KB_ESC )
    {
        clearscreen(buffer);

        if( objectrotate )
            p.Rotate(3, 358, 359);

        if( lightrotate )
        {
            Rotate(1, 2, 0, light);
            p.SetLight(light);
        }

        if( light.z<0 )
        {
            putpix(light.x+160, light.y+100, 62, buffer);
            if( rendermode==FLAT ) p.SolidDraw(buffer); else
                                   p.PhongRender(buffer);
        } else
        {
            if( rendermode==FLAT ) p.SolidDraw(buffer); else
                                   p.PhongRender(buffer);
            putpix(light.x+160, light.y+100, 62, buffer);
        }

        horizret();
        flip(buffer, video);

        if( kbhit() )
        {
            key = getch();
            switch( key )
            {
                case KB_ENTER:
                {
                    objectrotate = !objectrotate;
                    break;
                }
                case KB_SPACE:
                {
                    lightrotate = !lightrotate;
                    break;
                }
                case KB_BACKSPACE:
                {
                    if( rendermode==FLAT ) rendermode = PHONG; else
                                           rendermode = FLAT;
                    break;
                }
            }
        }
    }

    vgaoff();
    farfree(buffer);
}