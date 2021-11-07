#include "stdio.h"
#include "conio.h"
#include "stdlib.h"
#include "dos.h"
#include "math.h"

unsigned char r,g,b;

void colors()
{
     r=rand()%256;
     g=rand()%256;
     b=rand()%256;
}

void pixel(int x,int y)
{
     unsigned char far *mem=(unsigned char far*)MK_FP(0xa000,0);
     long bunk=y;
     bunk*=800;
     bunk+=x;
     bunk/=16384;
     int bank=bunk;

     _asm{
          mov ah, 0x4F
          mov al, 0x05
          mov bh, 0
          mov bl, 0
          mov dx, bank
          int 0x10
     }
     int adr=(y*800+x)%16384;
     *(mem+adr*4)=b;
     *(mem+adr*4+1)=g;
     *(mem+adr*4+2)=r;
     *(mem+adr*4+3)=0;
}

int main()
{
    int sel,v,k;
    clrscr();
    _asm{
         mov ax, 13h
         int 0x10
    }
    printf("Choise action to do:\nPrees 1 for a demonstration of the banks\nPress 2 to fill the monitor with random colors.\nPress 3 for weaving of threads.\nPress 4 to exit.\nEnter your choise: ");
    scanf("%d",&sel);
    switch(sel)
    {
          case 1:
          {
               printf("\nEnter the first color:\nSaturation of red: ");
               scanf("%d",&r);
               printf("Saturation of green: ");
               scanf("%d",&g);
               printf("Saturation of blue: ");
               scanf("%d",&b);
               int bank=0;
               _asm{
                    mov ax, 0x4F02
                    mov bx, 0x115
                    int 0x10
               }
               for(int i=0;i<600;i++)
               {
                    for(int j=0;j<800;j++)
                    {
                         bank++;
                         if(bank%16384==0)
                         colors();
                         pixel(j,i);
                    }
               }
               sleep(15);
               break;
          }
          
          case 2:
          {
               _asm{
                    mov ax, 0x4F02
                    mov bx, 0x115
                    int 0x10
               }
               for(int i=0;i<600;i++)
               {
                    for(int j=0;j<800;j++)
                    {
                         colors();
                         pixel(j,i);
                    }
               }
               sleep(15);
               break;
          }

          case 3:
          {
               printf("red:");
               scanf("%i ", &r);
               printf("green:");
               scanf("%i ", &g);
               printf("blue:");
               scanf("%i ", &b);
               _asm{
                    mov ax, 0x4F02
                    mov bx, 0x115
                    int 0x10
               }
               k=1;
               for(int z=0;z<700;z++)
               {
                    v=k-(k/2)*2;
                    if(v==1)
                    {
                         for(int j=k-1;j<k;j++)
                         {
                              for(int i=1;i<800;i++)
                              {
                                   r=i;
                                   pixel(i,j);
                              }
                              sleep(0.5);
                         }
                         k++;
                    }
                    else
                    {
                        for(int i=k-1;i<k;i++)
                        {
                             for(int j=1;j<600;j++)
                             {
                                  b=j;
                                  pixel(i,j);
                             }
                             sleep(0.5);
                        }
                        k++;
                    }
               }
               sleep(30);
               break;
          }
          case 4:
          {
               break;
          }
          default:
          {
               printf("Incorrect choise. Try again.");
          }
    }
    return 0;
}