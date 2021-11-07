#pragma once
#include "common.h"

//-------------------------------------------------------- главное меню
extern const int MENU_ITEM_COUNT;	// количество элементов
extern int MenuItemSelected;		// выбранный элемент
//-------------------------------------------------------- идентификаторы меню
const int MI_NO_SELECT = -1;		// ничего не выбранно	
const int MI_NEW_GAME = 0;			// игра
const int MI_EXIT = 1;				// выход
//-------------------------------------------------------- идентификаторы дополнительного меню
const int SMI_NO_SELECT = -1;		// ничего не выбранно
const int SMI_CONTINUE = 0;			// продолжить игру
const int SMI_TO_MENU = 1;			// главное меню
const int SMI_EXIT = 2;				// выход
//--------------------------------------------------------
int menuExecute();		// вызав меню
int subMenuExecute();	// вызов дополнительного меню
