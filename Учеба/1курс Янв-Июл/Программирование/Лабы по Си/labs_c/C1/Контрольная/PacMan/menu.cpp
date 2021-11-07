#ifndef MENU_H
#define MENU_H
#include "menu.h"
#include "common.h"

int MenuItemSelected;
const int MENU_ITEM_COUNT = 2;
char* const MenuItems [MENU_ITEM_COUNT] = {"И Г Р А", "В Ы Х О Д"};

const int SUBMENU_ITEM_COUNT = 3;
char* const SubMenuItems [SUBMENU_ITEM_COUNT] = {"П Р О Д О Л Ж И Т Ь  И Г Р У", "Г Л А В Н О Е  М Е Н Ю", "В Ы Х О Д"};
int SubMenuItemSelected;

void subMenuDraw()
{
	int cx = SCR_WIDTH >> 1;	// центр экрана
	int cy = SCR_HEIGHT >> 1;
	int h = SUBMENU_ITEM_COUNT; // высота меню
	int pos_y = cy - h; // позиция вставки текста
	h += 3;
	int w = (int)strlen(SubMenuItems[0]); 
	for (int i = 1; i < SUBMENU_ITEM_COUNT; i++)
	{
		int len = (int)strlen(SubMenuItems[i]);
		if (w < len) w = len; // находим самый длинный текст в меню
	}
	w = (w >> 1) + 3; // половина ширины меню

	// прямоугольник меню
	RECT r = Rect(cx - w, cy - h, cx + w, cy + h - 1);
	drawWindow(r);

	// вывод текста по центру окна меню
	for (int i = 0; i < SUBMENU_ITEM_COUNT; i++)
	{
		int sz = (int)strlen(SubMenuItems[i]) >> 1;
		if (i == SubMenuItemSelected) // если елемент выбран
			drawText(cx - sz, pos_y, SubMenuItems[i], SUBMENU_COLOR_SELECTED, DRAW_MODE_CH_COLOR);
		else
			drawText(cx - sz, pos_y, SubMenuItems[i], SUBMENU_COLOR_TEXT, DRAW_MODE_CH_COLOR);

		pos_y += 2; // пропускаем строку
	}
}

int subMenuExecute()
{
	SubMenuItemSelected = 0;
	BOOL flag = FALSE;
	while(TRUE)
	{	
		if (flag)
		{
			if (IsKeyDown(VK_RETURN)) // если сделан выбор, то
				return SubMenuItemSelected; // возвращаем индекс элемента

			if (IsKeyDown(VK_ESCAPE))
				return SMI_CONTINUE; // продолжаем игру
			
			// перемещаем курсор меню вверх
			if (IsKeyDown(VK_UP) && SubMenuItemSelected > 0)
				SubMenuItemSelected--;

			// перемещаем курсор меню вниз
			if (IsKeyDown(VK_DOWN) && SubMenuItemSelected < SUBMENU_ITEM_COUNT-1)
				SubMenuItemSelected++;		
		}

		subMenuDraw();	// рисуем меню
		scrUpdata();	// рисуем на экране		
		getch();		// ждем ввода с клавиатуры
		flag = !flag;	// инвертируем флаг
	}
}

// выводим меню в экранный буфер
void menuDraw()
{
	int cx = SCR_WIDTH >> 1;
	int pos_y = SCR_HEIGHT - (MENU_ITEM_COUNT << 1) - 11;

	for (int i = 0; i < MENU_ITEM_COUNT; i++)
	{
		int sz = (int)strlen(MenuItems[i]) >> 1;
		if (i == MenuItemSelected) // подсвечиваем выделенный элемент меню
			drawText(cx - sz, pos_y + (i << 1), MenuItems[i], 0x0F, DRAW_MODE_CH_COLOR);
		else // элемент в нормальном состоянии
			drawText(cx - sz, pos_y + (i << 1), MenuItems[i], 0x08, DRAW_MODE_CH_COLOR);
	}
}

// вызов меню
int menuExecute()
{
	MenuItemSelected = 0;
	LogoDraw(TRUE);	// выводим логотип с анимацией
	BOOL flag = FALSE; // для правильной обработки мультимедийной клавиатуры
	while(TRUE)
	{			
		if (flag)
		{
			if (IsKeyDown(VK_RETURN)) // если сделан выбор, то 
				return MenuItemSelected; // возвращаем индекс элемента
			
			if (IsKeyDown(VK_ESCAPE))
				return MI_EXIT; // закрываем программу

			// перемещаем курсор меню вверх
			if (IsKeyDown(VK_UP) && (MenuItemSelected > 0))
				MenuItemSelected--;

			// перемещаем курсор меню вниз
			if (IsKeyDown(VK_DOWN) && (MenuItemSelected < MENU_ITEM_COUNT-1))
				MenuItemSelected++;
		}
		
		menuDraw();	// вывод меню
		scrUpdata();// обновляем изображение на экране
		getch();	// ждем ввода с клавиатуры

		flag = !flag; // инвертируем флаг
	}
}

#endif /* MENU_H */