#ifndef __VGA__
#define __VGA__

#define MAX_COLOR  0x100
#define SCREENSIZE 64000

struct RGB
{
    char red;
    char green;
    char blue;
};

struct RGBpal
{
    RGB color[MAX_COLOR];
};

void vgaon();
void vgaoff();
void flip(char far* source, char far* dest);
void clearscreen(char far* where);
void horizret();
void setpal(char col, char r, char g, char b);
void putpix(int x, int y, char color, char far* where);

#endif