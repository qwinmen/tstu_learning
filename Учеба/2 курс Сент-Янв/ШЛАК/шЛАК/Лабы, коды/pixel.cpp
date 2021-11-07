#include "conio.h"
#include "dos.h"
#include "stdio.h"
#include "stdlib.h"
unsigned char far *mem=(unsigned char far *)0xA0000000;
void dot(){
	clrscr();
	int x, y;
	unsigned adr, color, mask, tmp;
	printf("\n Enter x:");
	scanf("%d", &x);
	printf("\n Enter y:");
	scanf("%d", &y);
	printf("\n Enter bitmask:");
	scanf("%d", &mask);
	printf("\n Enter color: ");
	scanf("%d", &color);
	_asm{
		mov ax, 12h
		int 10h
	}
	adr=y*80+x/8;
	outp(0x3CE, 5);
	outp(0x3CF, 2);
	outp(0x3CE, 8);
	outp(0x3CF, mask);
	mem[adr]=color;
	getch();
	_asm{
		mov ax,0003h
		int 10h
	}
}
int choice(){
	int c;
	clrscr();
	printf("\n1-Output pixel");
	printf("\n2-Exit");
	printf("\nEnter your choice: ");
	scanf("%d", &c);
return c;
}
void main(){
	int k;
	while((k=choice())!=3){
		switch(k){
			case 1:
				dot();
				break;

			case 2:
				exit(1);
				break;
		}
	}
	return;
}
