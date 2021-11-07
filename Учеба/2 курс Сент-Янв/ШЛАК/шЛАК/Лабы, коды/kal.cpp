#include <stdlib.h>
#include <conio.h>
#include <stdio.h>
#include <dos.h>
#include <math.h>

void setVesa(){ //вход в режим VESA
	_asm{
	mov ax, 4f02h
	mov bx, 115h
	int 10h
	}
}

//Чтобы сделать нормальную меню, надо в режим 13h зайти
void set13h(){
       _asm{
	mov Ax,13h
	int 10h
	}
}

//Ну это сама функция Путпиксел
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
//Это функция, чтобы нарисовать круг.
void circle(int x,int y,int radius, int red,int green,int blue){
	for(int i=x-radius;i<=x+radius;i++)
	{
		int y1=ceil(y-sqrt(y*y-i*i+2*x*i-x*x-y*y+radius*radius)); //Координаты по х и у для круга по стандартной формуле
		int y2=ceil(y+sqrt(y*y-i*i+2*x*i-x*x-y*y+radius*radius));
		for(int j=y1;j<=y2;j++)
			if (i>=0 && i<800 && j>=0 && j<600) //условие, чтобы круг не выходил за рамки нашего экрана
				PutPixel(i,j,red,green,blue);

	}
}

int krug(){
	setVesa();
	srand(time(NULL));
	for(int i=0;i<100;i++){ // i это радиус круга
		circle(400,300,i,rand()%255,rand()%255,rand()%255); //вставляем сюда функцию нашего круга, 400 и 300-координаты, откуда будет расти круг.
		delay(100); //время, через которое растет один пиксел круга(в милисекундах)
	}
	getch();
	return 0;
}

int choice(){ //МЕНЮ
	set13h();
	int ch;
	clrscr();
	printf("\n1-Growing circle");
	printf("\n2-Exit");
	printf("\n Enter your choice: ");
	scanf("%d",&ch);
return ch;
}
void main(void){ //То же меню, только с выбором (case)
	int k;
	while((k=choice())!=3){
		switch(k){
			case 1:
				krug();
				break;

			case 2:
				exit(1);
				break;

		}
	}
	return;
}