#include <iostream.h>
#include <dos.h>
#include <stdio.h>
#include <conio.h>
unsigned char far *ptr=(unsigned char far*)MK_FP(0xA000,0);

int mode( int mod)
{	
	int h;
	_asm{
			mov ax,0x4F02
			mov bx,mod
			int 10h
			mov h, ax
		}
	return h==0x004F;
}	
void bank( int bank)
{
	_asm{
		mov ax, 0x4F05
		mov bx, 0
		mov dx, bank
		int 0x10
		}
}
void main()
{
	int i=0, re=0, a[27], j=0, k=0, color=0, rastr, n=0, col=255;
	for(i=0x100; i<=0x11B; i++)
	{
		_asm{
				mov AX,0x4F02
				mov BX,i
				int 0x10
				mov re, AX
			}
		a[j]=re;
		j++;
	}
	_asm{
			mov AX,0x3
			int 0x10
		}
	cout<<"podderjivaemye  Mode VESA 1.2\n";
	for(i=0; i<j; i++)
	{
		if(a[i]==0x4F && i==0) cout<<"100h,  640x400,   256 color\n";
		if(a[i]==0x4F && i==1) cout<<"101h,  640x480,   256 color\n";
		if(a[i]==0x4F && i==2) cout<<"102h,  800x600,   16 color\n";
		if(a[i]==0x4F && i==3) cout<<"103h,  800x600,   256 color\n";
		if(a[i]==0x4F && i==4) cout<<"104h,  1024x768,  16 color\n";
		if(a[i]==0x4F && i==5) cout<<"105h,  1024x768,  256 color\n";
		if(a[i]==0x4F && i==6) cout<<"106h,  1280x1024, 16 color\n";
		if(a[i]==0x4F && i==7) cout<<"107h,  1280x1024, 256 color\n";
		if(a[i]==0x4F && i==8) cout<<"108h,  80x60,     text\n";
		if(a[i]==0x4F && i==9) cout<<"109h,  132x25,    text\n";
		if(a[i]==0x4F && i==10) cout<<"10Ah, 132x43,    text\n";
		if(a[i]==0x4F && i==11) cout<<"10Bh, 132x50,    text\n";
		if(a[i]==0x4F && i==12) cout<<"10Ch, 132x60,    text\n";
		if(a[i]==0x4F && i==13) cout<<"10Dh, 320x200,   32K (1:5:5:5) color\n";
		if(a[i]==0x4F && i==14) cout<<"10Eh, 320x200,   64K (5:6:5) color\n";
		if(a[i]==0x4F && i==15) cout<<"10Fh, 320x200,   16.8M (8:8:8) color\n";
		if(a[i]==0x4F && i==16) cout<<"110h, 640x480,   32K (1:5:5:5) color\n";
		if(a[i]==0x4F && i==17) cout<<"111h, 640x480,   64K (5:6:5) color\n";
		if(a[i]==0x4F && i==18) cout<<"112h, 640x480,   16.8M (8:8:8) color\n";
		if(a[i]==0x4F && i==19) cout<<"113h, 800x600,   32K (1:5:5:5) color\n";
		if(a[i]==0x4F && i==20) cout<<"114h, 800x600,   64K (5:6:5) color\n";
		if(a[i]==0x4F && i==21) cout<<"115h, 800x600,   16.8M (8:8:8) color\n";
		if(a[i]==0x4F && i==22) cout<<"116h, 1024x768,  32K (1:5:5:5) color\n";
		if(a[i]==0x4F && i==23) cout<<"117h, 1024x768,  64K (5:6:5) color\n";
		if(a[i]==0x4F && i==24) cout<<"118h, 1024x768,  16.8M (8:8:8) color\n";
		if(a[i]==0x4F && i==25) cout<<"119h, 1280x1024, 32K (1:5:5:5) color\n";
		if(a[i]==0x4F && i==26) cout<<"11Ah, 1280x1024, 64K (5:6:5) color\n";
		if(a[i]==0x4F && i==27) cout<<"11Bh, 1280x1024, 16.8M (8:8:8) color\n";
	}
	cout<<"\nvvedite nomer rezima(0x....)->"; cin>>re;
    mode(re);
 int colr=255, p;
 int colg=0;
 int colb=0;
 for(p=0;p<16;p++)
 {
  asm{
      mov ax, 0x4F05
      mov bx, 0
      mov dx, p
      int 0x10
     }

   k=0;
  for(i=0;i<16;i++)
  {
    for(j=0;j<1024;j++)
    {
     *(ptr+k)=colr;
     *(ptr+k+1)=0;
     *(ptr+k+2)=colb;
     k=k+5;
    }
  colg++;
  colr--;
  }
 }
colg=255;
//int colb=0;
 for(p=16;p<32;p++)
 {
  asm{
      mov ax, 0x4F05
      mov bx, 0
      mov dx, p
      int 0x10
     }

   k=0;
  for(i=0;i<16;i++)
  {
    for(j=0;j<1024;j++)
    {
     *(ptr+k)=colr;
     *(ptr+k+1)=0;
     *(ptr+k+2)=colb;
     k=k+5;
    }
  colb++;
  colg--;
  }
 }
 colb=255;
 colr=0;
 for(p=32;p<48;p++)
 {
  asm{
      mov ax, 0x4F05
      mov bx, 0
      mov dx, p
      int 0x10
     }

   k=0;
  for(i=0;i<16;i++)
  {
    for(j=0;j<1024;j++)
    {
     *(ptr+k)=colr;
     *(ptr+k+1)=0;
     *(ptr+k+2)=colb;
     k=k+5;
    }
  colb--;
  colr++;
  }
 }
  getch();
}
