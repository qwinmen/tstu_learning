#include "vga.h"
#include "dos.h"

void setpal(char col, char r, char g, char b)
{
    __asm {
        mov     dx,3c8h
        mov     al,[col]
        out     dx,al
        inc     dx
        mov     al,[r]
        out     dx,al
        mov     al,[g]
        out     dx,al
        mov     al,[b]
        out     dx,al
    }
}

void vgaon()
{
    __asm {
        mov     ax,13h
        int     10h
    }
}

void vgaoff()
{
    __asm {
        mov     ax,3
        int     10h
    }
}

void flip(char far* source, char far* dest)
{
    __asm {
        push    ds
        mov     es,word ptr [dest+2]
        mov     ds,word ptr [source+2]
        mov     si,word ptr [source]
        mov     di,word ptr [dest]
        mov     cx,16000
        cld
        db      66h
        rep     movsw
        pop     ds
    }
}

void clearscreen(char far* where)
{
    __asm {
        push    es
        mov     cx,16000
        mov     es,word ptr [where+2]
        mov     di,word ptr [where]
        db      66h
        xor     ax,ax
        cld
        db      66h
        rep     stosw
        pop     es
    }
}

void horizret()
{
    __asm {
        mov     dx,3dah
    }

_horiz:
    __asm {
        in      al,dx
        and     al,8
        jz      _horiz
    }
}

void putpix(int x, int y, char color, char far* where)
{
    __asm {
        mov     es,word ptr [where+2]
        mov     ax,[y]
        mov     bx,ax
        shl     ax,8
        shl     bx,6
        add     ax,bx
        add     ax,[x]
        add     ax,word ptr [where]
        mov     di,ax
        mov     al,[color]
        mov     es:[di],al
    }
}