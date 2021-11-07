#include <iostream.h>
#include<io.h>
#include<conio.h>
#include<stdio.h>
#include<errno.h>
#include<dos.h>
#include<stdlib.h>

int fl;
unsigned count;
int io_handle;
union REGS inregs, outregs;
struct SREGS segregs;
char *MenuItems[3] = {
		      "  Запуск  ",
		      "  О программе  ",
		      "  Выход  "
		     };
void InputData(int &p, int &q, char *&buf);
void Window (int z);
int  Menu(int Menu_Item);
void DrawItem(int Item, int Menu_Item);
void Shifr(int &p, int &q, char *buf);
int p,q,d,e;

void main(void) {
 fl=0;
 int Exit = 0;
 int Menu_Item = 0;
 int p,q;
 char buf[128];
 _setcursortype(0);
 Window(2);
 while( !Exit )
 {
	Window(2);
	Menu_Item = Menu(Menu_Item);
	switch( Menu_Item )
	 {
		case 0:InputData(p,q,buf);
		 getch();
		 break;
		case 1:
		 _setcursortype(0);
		 window(1,1,80,25);
		 textbackground(13);
		 clrscr();
		 window(14,11,64,14);
		 textbackground(15);
		 textcolor(4);
		 clrscr();
		 gotoxy(1,1);
		 for(int j=0;j<49;j++) cputs("─");
		 gotoxy(1,4);
		 for(j=0;j<49;j++) cputs("─");
		 gotoxy(2,2);
		 cputs("Название: ");
		 gotoxy(2,3);
		 cputs("Метод реализации:");
		 gotoxy(23,2);
		 textcolor(1);
		 cputs("Shifrovanie");
		 gotoxy(23,3);
		 cputs("RSA");
		 getch();
		 window(1,1,80,25);
		 clrscr();
		 break;
		case 2:Exit = 1;
		 break;
	 }
	 if(!Exit ) getch();
 }
	 clrscr();
	 _setcursortype(2);
}

void InputData(int &p, int &q, char *&buf)
{
//otkruvaem ystroistvo po imeni CON
      io_handle=open("CON",4);
	 if(io_handle==-1) {
		 printf("Oshibka pri otkrutii ystroistva %d",errno);
		 return;
		 }
 int i,j,flag,ch;
 int r1,sq;
 window(1,1,80,25);
 clrscr();
  _setcursortype(0);
  textcolor(0);
  textbackground(1);
  clrscr();
  for(r1=0;r1<20;r1++)
  {
   delay(45);
   window(40-r1,10,40+r1,16);
   textbackground(0);
   clrscr();
   window(40-r1-1,9,40+r1-1,15);
   textbackground(15);
   clrscr();
  }
  _setcursortype(2);
 a:
  clrscr();
  gotoxy(3,2);
  textcolor(14);
  cputs("Vvedite pervoe chislo:");
  // Введите количество городов,
  gotoxy(3,3);
  cin >>p;
  clrscr();
  gotoxy(3,2);
  cputs("Vvedite vtoroe chislo:");
  gotoxy(3,3);
  cin >>q;
  //перечень
  flag=0;
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11
  for(i=2;i<p;i++) if (p%i==0) flag=1;
  for(i=2;i<q;i++) if (q%i==0) flag=1;
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1!
     if(flag==1)
     {
      clrscr();
      gotoxy(3,3);
      printf("Odno ili oba chisla ne prostue");
      gotoxy(3,4);
      printf("Dla prodolgeniya -");
      gotoxy(3,5);
      printf("Nagmite lubyy klavishy...");
      ch=getch();
      goto a;
      }
    clrscr();
    gotoxy(3,2);
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
 int n,m;
 int n1,p1;

  n=p*q; n1=(p-1)*(q-1);
  p=0;d=1;
//d?
  while (p==0)
  {
   d++;
   if (n1>d) m=n1; else m=d;
   p1=0;
   for(i=2;i<=m;i++) if(n1%i==0 && d%i==0) p1=1;
   if(p1==0) p=1;
  }
//e?
  p=0; e=0;
  while(p==0)
  {
    e++;
    if((e*d)%n1==1) p=1;
  }
    printf("n=%d, d=%d, e=%d",n,d,e);ch=getch();
    gotoxy(3,2);
    printf("Vvodite vash text dla shifrovaniya:");
    flag=1;
    gotoxy(3,3);
//    count=read(io_handle,buf,128);
    ch=0;
    while (ch!=27)
    {
	ch=getch();
	int kod=1;
	for(int st=1;st<=e;st++) kod=kod*ch; kod=kod%n;
	cprintf("%d ",kod);
    }
    window(1,1,80,25);
    clrscr();
    textcolor(0);
    _setcursortype(0);
    fl=1;
}


void Window(int z)
{
 int i,j;
 textcolor(1);
 textbackground(15);
 clrscr();
 for(i=0;i<24;i++)
 {
  if (z==1) delay(20);
  for(j=0;j<80;j++) cputs("░");
 }
 if(z!=1)
 {
  gotoxy(2,25);
  textcolor(4);
  if(z==2)
  {
   cprintf("Выберите пункт меню и нажмите ");
   textcolor(1);
   textbackground(15);
   cprintf("< Enter >");
  }
  else
  {
   cprintf("Нажмите ");
   textcolor(1);
   textbackground(15);
   cprintf("< Enter >");
  }
 }
}

void DrawItem(int Item, int Menu_Item)
{
 if(Item!=Menu_Item)
 {
  textcolor(0);
  textbackground(15);
  cprintf("%s",MenuItems[Item]);
 }
 else
 {
  textcolor(0);
  textbackground(2);
  cprintf("%s",MenuItems[Item]);
 }
}

int Menu(int Menu_Item)
{
 int Exit = 0,i;
 gotoxy(1,1);
 for(i=0;i<3;i++)
	DrawItem(i,Menu_Item);
 textcolor(7);
 for(i=0;i<36;i++) cputs("█");
 while(!Exit)
 {
	switch(getch())
	{
	 case 0:
		switch(getch())
		{
		 case 77:
			if( Menu_Item==2 ) Menu_Item = 0;
			else Menu_Item++;
			gotoxy(1,1);
			for(i=0;i<3;i++)
			 DrawItem(i,Menu_Item);
			textcolor(7);
			for(i=0;i<36;i++) cputs("█");
			break;
		 case 75:
			if( Menu_Item==0 ) Menu_Item = 2;
			else Menu_Item--;
			gotoxy(1,1);
			for(i=0;i<3;i++)
			 DrawItem(i,Menu_Item);
			textcolor(7);
			for(i=0;i<36;i++) cputs("█");
			break;
		}
		break;
	 case 13:
    Exit = 1;
    break;
  }
 }
 clrscr();
 return Menu_Item;
}
