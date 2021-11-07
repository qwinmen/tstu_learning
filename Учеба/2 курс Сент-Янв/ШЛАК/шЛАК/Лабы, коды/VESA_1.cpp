#include <stdlib.h>
#include <conio.h>
#include <stdio.h>
#include <dos.h>
#include <math.h>

void setVesa(){
	_asm{
	mov ax, 4f02h
	mov bx, 115h
	int 10h
	}
}

void set13h(){
       _asm{
	mov Ax,13h
	int 10h
	}
}

void PutPixel(int x,int y,char red,char green,char blue)
{
	unsigned char far *mem=(unsigned char far*)MK_FP(0xA000,0);
	//Считаем номер банка
	long lbank=y;
	lbank*=800;
	lbank+=x;
	lbank/=16384;
	int bank=lbank;
	//Активируем этот банк
	_asm{
		mov AX, 4F05h
		mov BX, 0h
		mov DX, bank
		int 10h
	}
	//Запивываем компоненты цветов пикселя
	long pixel=1;
	pixel*=y;
	pixel*=3200;
	pixel+=x*4;
	pixel-=bank*65536;
	//printf("%li\n",pixel);
	mem[pixel]=blue;
	mem[pixel+1]=green;
	mem[pixel+2]=red;
	mem[pixel+3]=0;
}
void circle(int x,int y,int radius, int red,int green,int blue){
	for(int i=x-radius;i<=x+radius;i++)
	{
		int y1=ceil(y-sqrt(y*y-i*i+2*x*i-x*x-y*y+radius*radius));
		int y2=ceil(y+sqrt(y*y-i*i+2*x*i-x*x-y*y+radius*radius));
		for(int j=y1;j<=y2;j++)
			if (i>=0 && i<800 && j>=0 && j<600)
				PutPixel(i,j,red,green,blue);

	}
}

int replay(){
	setVesa();
	srand(time(NULL));
	for(int i=0;i<50;i++){
		circle(rand()%799,rand()%599,rand()%70+30,rand()%255,rand()%255,rand()%255);
		delay(100);
	}
	getch();
	return 0;
}
int krug(){
	setVesa();
	srand(time(NULL));
	for(int i=0;i<100;i++){
		circle(400,300,i,rand()%255,rand()%255,rand()%255);
		delay(100);
	}
	getch();
	return 0;
}

int choice(){
	set13h();
	int ch;
	clrscr();
	printf("\n1-Replay circles");
	printf("\n2-Growing circle");
	printf("\n3-Exit");
	printf("\n Enter your choice: ");
	scanf("%d",&ch);
return ch;
}
void main(void){
	int k;
	while((k=choice())!=3){
		switch(k){
			case 1:
				replay();
				break;

			case 2:
				krug();
				break;

			case 3:
				exit(1);
				break;

		}
	}
	return;
}