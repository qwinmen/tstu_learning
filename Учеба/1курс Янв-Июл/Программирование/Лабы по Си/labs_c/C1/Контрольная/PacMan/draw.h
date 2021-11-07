#pragma once
#include <windows.h>

//-------------------------------------------------------- экран
const int SCR_WIDTH  = 80;		// ширина
const int SCR_HEIGHT = 43;		// высота
const int SCR_SIZE = SCR_WIDTH * SCR_HEIGHT;	// размер буфера
extern CHAR_INFO scr_chars [SCR_SIZE];			// экранный буфер (символы + атрибуты)
extern HANDLE hOut;		// указатель на стандартный поток вывода
//-------------------------------------------------------- режимы вывода
const int DRAW_MODE_CHAR = 1;		// символ
const int DRAW_MODE_TEXTCOLOR = 2;	// цвет символа
const int DRAW_MODE_BACKGROUND = 4; // цвет фона
const int DRAW_MODE_ATTR = DRAW_MODE_TEXTCOLOR | DRAW_MODE_BACKGROUND;	// цвет символа и фона
const int DRAW_MODE_CH_COLOR = DRAW_MODE_CHAR | DRAW_MODE_TEXTCOLOR;	// цветной символ
const int DRAW_MODE_ALL = 0xFFFFFF;	// все
//--------------------------------------------------------
BYTE scrGetAttr(int x, int y); // возвращает атрибут символа
BYTE scrGetChar(int x, int y); // возвращает символ
BOOL scrIsEmpty(int x, int y); // TRUE если ничего нет

RECT& Rect(int left, int top, int right, int bottom);
BOOL scrInic(const char* Title); // инициализация (выполнить до использования других функций)
BOOL scrUpdata(); // обновление экрана
void scrClear(BYTE attr = 0, BYTE ch = ' '); // очистка экрана
void drawChar(int x, int y, BYTE ch, BYTE attr = 0x0F, const int Mode = DRAW_MODE_ALL);
void drawRect(RECT& rc, BYTE ch, BYTE attr, const int Mode = DRAW_MODE_ALL);
void drawFillRect(RECT& rc, BYTE ch, BYTE attr, const int Mode = DRAW_MODE_ALL);
void drawLine(int x1, int y1, int x2, int y2, BYTE attr, char* str = "", const int Mode = DRAW_MODE_ALL);
void drawLine(int x1, int y1, int x2, int y2, BYTE attr, BYTE ch, const int Mode = DRAW_MODE_ALL);
void drawText(int x, int y, char* str, BYTE attr = 0x0F, const int Mode = DRAW_MODE_ALL);
void drawWindow(RECT& r, const BYTE attr = 0x18);
