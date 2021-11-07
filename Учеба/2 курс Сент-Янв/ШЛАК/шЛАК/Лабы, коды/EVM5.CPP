#include "conio.h"
#include "dos.h"
#include "math.h"
#include "stdio.h"
#include "stdlib.h"

void Send(int port, int value){
	outp(0x3CE,port);
	outp(0x3CF,value);
}

void Pixel(int x, int y, unsigned char color){
	unsigned int adr;
	unsigned char far *mem;
	Send(0x01,0x0F);
	Send(0x03,0x00);
	Send(0x08,0xFF);
	Send(0x00,color);
	adr = y*80 + x / 8;
	mem = (char*)MK_FP(0xa000,0);
	*((unsigned char far*)mem+adr) = 0;
}

void Square(int x0, int y0, int x1, int y1,unsigned char color){
	int i,j;
	for (i = x0; i < x1; i++){
		for (j = y0; j < y1; j++)
			Pixel(i,j,color);
	}
}

int Color(int dx, int dy){
	int adr,i;
	unsigned int bitmask;
	unsigned char far *mem =(char*)MK_FP(0xa000,0);
	unsigned short a[4];
	adr=dy*80+dx/8;
	bitmask=128>>(dx%8);
	Send(5,0);
	int dcolor=0;
	for (i = 0; i <= 3; i++){
		Send(4,i);
		a[i]=*((unsigned char far*)mem+adr);
		a[i]=a[i]&bitmask;
		a[i]=a[i]>>(7-dx%8);
		dcolor+=a[i]*pow(2.0, i);
	}
	if(dcolor==0)
		printf("\nBlack");
	if(dcolor==1)
		printf("\nBlue");
	if(dcolor==2)
		printf("\nGreen");
	if(dcolor==3)
		printf("\nCeladon");
	if(dcolor==4)
		printf("\nRed");
	if(dcolor==5)
		printf("\nViolet");
	if(dcolor==6)
		printf("\nLight Brown");
	if(dcolor==7)
		printf("\nLight Gray");
	if(dcolor==8)
		printf("\nDark Gray");
	if(dcolor==9)
		printf("\nLight Blue");
	if(dcolor==10)
		printf("\nLight Green");
	if(dcolor==11)
		printf("\nLight Celadon");
	if(dcolor==12)
		printf("\nPink");
	if(dcolor==13)
		printf("\nLight Violet");
	if(dcolor==14)
		printf("\nYellow");
	if(dcolor==15)
		printf("\nWhite");
	return 0;
}

int main(){
	int x,y,r;
	x=0;
	y=0;
	asm {
		mov ax,0x12
		int 0x10
	}
	for(r=0;r<=15;r++){
		Square(x,y,x+160,y+120,r);
		x+=160;
		if((r==3)||(r==7)||(r==11))
			y+=120;
	}
	printf("X = ");
	scanf("%d",&x);
	printf("Y = ");
	scanf("%d",&y);
	Color(x,y);
	getch();
        return 0;
 }
