#include <conio.h>
#include <stdlib.h>
#include <bios.h> /* bioskey() */

#define ITEM_COUNT 5
#define FILE_COUNT 4

#define POS_MENU_LEFT	26
#define POS_MENU_TOP	8

#define KEY_UP		18432
#define KEY_DOWN	20480
#define KEY_EXECUTE	7181
#define KEY_ESC		283

#define ITEM_EXIT (ITEM_COUNT -1)

/* элементы меню */
char* MenuItems[ITEM_COUNT] = {"laba1: sort selected", "laba2: edit structure list", "laba3: strings", "laba4: function(...)", "Exit"};
/* имена файлов */
char* FileNames[FILE_COUNT] = {"laba1.exe", "laba2.exe", "laba3.exe", "laba4.exe"};

void text_out(int color, int bkColor, char* text)
{
	textcolor(color);
	textbackground(bkColor);

	while(*text != 0)
	{
		putch(*text);
		text++;
	}
	/* востанавливаем цвет по умолчанию */
	textcolor(LIGHTGRAY);
	textbackground(BLACK);
}

/* вывод цветного текста в заданной позиции */
void text_outxy(int x, int y, int color, int bkColor, char* text)
{
	gotoxy(x, y);
	text_out(color, bkColor, text);
}


/* вывод меню на экран */
void show_menu(int Selected)
{
	int i;
	
	for (i = 0; i < ITEM_COUNT; i++)
	{	
		if (i == Selected)
			text_outxy(POS_MENU_LEFT, POS_MENU_TOP + (i << 1), LIGHTGREEN, BLUE, MenuItems[i]);
		else
		{
			if (i == ITEM_COUNT-1)
				text_outxy(POS_MENU_LEFT, POS_MENU_TOP + (i << 1), LIGHTRED, BLACK, MenuItems[i]);
			else
				text_outxy(POS_MENU_LEFT, POS_MENU_TOP + (i << 1), GREEN, BLACK, MenuItems[i]);
		}
	}
	
	text_outxy(20,22, RED, BLACK,"CONTROL KEYS: ");
	text_out(GREEN, BLACK, "UP, DOWN,"); 
	text_out(LIGHTGREEN, BLACK, " ENTER,"); 
	text_out(LIGHTRED, BLACK, " ESC"); 
}


void main()
{
	int selected = 0;
	while (!kbhit())
	{
		clrscr();
		show_menu(selected);
		
		switch (bioskey(0))
		{
			case KEY_UP:
				if (selected > 0)
					selected--;
			break;
			case KEY_DOWN:
				if (selected < ITEM_COUNT-1)
					selected++;
			break;
			case KEY_EXECUTE:
				if (selected == ITEM_EXIT)
					exit(1);
				else
				{
					clrscr();
					spawnl(0, FileNames[selected], 0);
				}
			break;
			case KEY_ESC:
				exit(1);
			break;
		}
	}	
}
