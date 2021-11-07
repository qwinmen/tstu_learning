#include <stdio.h>
#include <conio.h>
#include <dos.h>

int set12h()
{
	_asm{
		mov ax,12h
		int 10h
	}

	return 0;
}

int main()
{
	unsigned char far *mem=(unsigned char far*)MK_FP(0xA000,0);

	set12h();

	//Write mode
	outp(0x3CE,5);
	outp(0x3CF,2);

	//Mask
	outp(0x3CE,8);
	outp(0x3CF,0x55);

	mem[0]=15;



	getch();

	return 0;
}