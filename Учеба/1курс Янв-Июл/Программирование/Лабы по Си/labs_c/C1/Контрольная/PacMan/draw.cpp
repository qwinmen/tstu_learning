#ifndef DRAW_H
#define DRAW_H
#include "draw.h"
#include "common.h"

HANDLE hOut; // указатель на поток вывода
CHAR_INFO scr_chars [SCR_SIZE]; // символы + атрибуты

BYTE scrGetAttr(int x, int y)
{
	if (x < 0 || y < 0 || x >= SCR_WIDTH || y >= SCR_HEIGHT)
		return 0;

	int p = y * SCR_WIDTH + x;
	return (BYTE)scr_chars[p].Attributes;
}

BYTE scrGetChar(int x, int y)
{
	if (x < 0 || y < 0 || x >= SCR_WIDTH || y >= SCR_HEIGHT)
		return 0;

	int p = y * SCR_WIDTH + x;
	return scr_chars[p].Char.AsciiChar;
}

BOOL scrIsEmpty(int x, int y)
{
	if (x < 0 || y < 0 || x >= SCR_WIDTH || y >= SCR_HEIGHT)
		return FALSE;

	int p = y * SCR_WIDTH + x;
	return scr_chars[p].Char.AsciiChar == MAP_SPACE_CHAR && scr_chars[p].Attributes == MAP_SPACE_ATTR;
}

RECT& Rect(int left, int top, int right, int bottom)
{
	static RECT r;
	r.left = left;
	r.top = top;
	r.right = right;
	r.bottom = bottom;
	return r;
}

BOOL scrInic(const char* Title)
{
	SetConsoleTitleA(Title);
	// получаем указатель на стандартный поток вывода
	hOut = GetStdHandle(STD_OUTPUT_HANDLE);
	if (!hOut)
	{
		printf("\nerror: scrInic::GetStdHandle");
		return FALSE;
	}
	// убираем курсор
	CONSOLE_CURSOR_INFO cur;
	cur.bVisible = FALSE;
	cur.dwSize = 1;
	SetConsoleCursorInfo(hOut, &cur);
	// размер буфера в символах
	COORD sz;
	sz.X = SCR_WIDTH;
	sz.Y = SCR_HEIGHT;		
	// устанавливаем размер буфера
	if (!SetConsoleScreenBufferSize(hOut, sz))
	{
		printf("\nerror: scrInic::SetConsoleScreenBufferSize");
		return FALSE;
	}
	// прямоугольник окна
	SMALL_RECT r;
	r.Top = 0;
	r.Left = 0;
	r.Right = SCR_WIDTH-1;
	r.Bottom = SCR_HEIGHT-1;
	// устанавливаем размер окна
	if (!SetConsoleWindowInfo(hOut, TRUE, &r))
	{
		printf("\nerror: scrInic::SetConsoleWindowInfo");
		return FALSE;
	}
	return TRUE;
}

void scrClear(BYTE attr, BYTE ch)
{
	CHAR_INFO ci;
	ci.Attributes = attr;
	ci.Char.AsciiChar = ch;

	for (int i = 0; i < SCR_SIZE; i++)
	{
		scr_chars[i] = ci;
	}
}

BOOL scrUpdata()
{
	if (!hOut)
		return FALSE;

	COORD pos;
	pos.X = 0;
	pos.Y = 0;

	COORD sz;
	sz.X = SCR_WIDTH;
	sz.Y = SCR_HEIGHT;
	SMALL_RECT r;
	r.Left = 0;
	r.Top = 0;
	r.Right = SCR_WIDTH;
	r.Bottom = SCR_HEIGHT;

	return WriteConsoleOutputA(hOut, scr_chars, sz, pos, &r) == 1;
}

/// вывод символа в экранный буфер
void drawChar(int x, int y, BYTE ch, BYTE attr, const int Mode)
{
	if (x < 0 || x > SCR_WIDTH || y < 0 || y > SCR_HEIGHT)
		return;
	int p = y*SCR_WIDTH + x;
	
	if (Mode & DRAW_MODE_CHAR)		scr_chars[p].Char.AsciiChar = ch; 
	if (Mode & DRAW_MODE_TEXTCOLOR ) scr_chars[p].Attributes = (scr_chars[p].Attributes & 0xF0) | (attr & 0x0F);
	if (Mode & DRAW_MODE_BACKGROUND) scr_chars[p].Attributes = (scr_chars[p].Attributes & 0x0F) | (attr & 0xF0);

}

void drawRect(RECT& rc, BYTE ch, BYTE attr, const int Mode)
{
	char c[2] = {ch, 0};
	drawLine(rc.left, rc.top, rc.right, rc.top, attr, c, Mode);
	drawLine(rc.left, rc.top, rc.left, rc.bottom-1, attr, c, Mode);
	drawLine(rc.left, rc.bottom-1, rc.right, rc.bottom-1, attr, c, Mode);
	drawLine(rc.right, rc.top, rc.right-1, rc.bottom-1, attr, c, Mode);
}

void drawFillRect(RECT& rc, BYTE ch, BYTE attr, const int Mode)
{
	RECT r;
	// проверяем выход за границу
	if (rc.left < 0) r.left = 0; else r.left = rc.left;
	if (rc.top < 0) r.top = 0; else r.top = rc.top;
	if (rc.right >= SCR_WIDTH) r.right = SCR_WIDTH; else r.right = rc.right;
	if (rc.bottom >= SCR_HEIGHT) r.bottom = SCR_HEIGHT; else r.bottom = rc.bottom;

	// рисуем прямоугольник
	for (int y = r.top; y < r.bottom; y++)
	for (int x = r.left; x < r.right; x++)
	{
		drawChar(x, y, ch, attr, Mode);	
	}
}

void drawLine(int x1, int y1, int x2, int y2, BYTE attr, char* str, const int Mode)
{
	int min_x = x1 < x2 ? x1 : x2;
	int max_x = x1 > x2 ? x1 : x2;
	int min_y = y1 < y2 ? y1 : y2;
	int max_y = y1 > y2 ? y1 : y2;
	int w = max_x - min_x;
	int h = max_y - min_y;
	if (w == 0) w = 1;
	if (h == 0) h = 1;
	if (min_x == max_x) max_x++;
	if (min_y == max_y) max_y++;

	char* s = str;

	for (int y = min_y; y < max_y; y++)
	{	
	for (int x = min_x; x < max_x; x++)
	{
		int nx = min_x + int(((float)(y - min_y) / h) * w); 
		int ny = min_y + int(((float)(x - min_x) / w) * h);
		if (ny >= 0 && ny < SCR_HEIGHT && nx >= 0 && nx < SCR_WIDTH)
		{
			int p = w > h ? ny * SCR_WIDTH + x : y * SCR_WIDTH + nx;
			if (*s == 0) s = str;
			if (Mode & DRAW_MODE_CHAR) scr_chars[p].Char.AsciiChar = *s; s++;
			if (Mode & DRAW_MODE_TEXTCOLOR ) scr_chars[p].Attributes = (scr_chars[p].Attributes & 0xF0) | (attr & 0x0F);
			if (Mode & DRAW_MODE_BACKGROUND) scr_chars[p].Attributes = (scr_chars[p].Attributes & 0x0F) | (attr & 0xF0);
		}
	}}
}

void drawLine(int x1, int y1, int x2, int y2, BYTE attr, BYTE ch, const int Mode)
{
	char A[2];
	A[0] = ch;
	A[1] = 0;
	drawLine(x1, y1, x2, y2, attr, A ,Mode);
}

void drawText(int x, int y, char* str, BYTE attr, const int Mode)
{
	CHAR A[1024];
	AnsiToOem(str, A);
	char* s = A;

	while (*s != 0)
	{
		drawChar(x++, y, *s, attr, Mode);
		s++;
	}
}

void drawWindow(RECT& r, const BYTE attr)
{
	drawFillRect(r, ' ', attr);
	r.right--;
	r.bottom--;

	// рисуем рамку окна
	drawLine(r.left, r.top, r.right, r.top, WINDOW_COLOR_BOUNDRECT, 205, DRAW_MODE_CH_COLOR);
	drawLine(r.left, r.bottom, r.right, r.bottom, WINDOW_COLOR_BOUNDRECT, 205, DRAW_MODE_CH_COLOR);
	drawLine(r.left, r.top, r.left, r.bottom, WINDOW_COLOR_BOUNDRECT, 186, DRAW_MODE_CH_COLOR);
	drawLine(r.right, r.top, r.right, r.bottom, WINDOW_COLOR_BOUNDRECT, 186, DRAW_MODE_CH_COLOR);
	// рисуем углы окна
	drawChar(r.left, r.top, 201, WINDOW_COLOR_BOUNDRECT, DRAW_MODE_CH_COLOR); 
	drawChar(r.right, r.top, 187, WINDOW_COLOR_BOUNDRECT, DRAW_MODE_CH_COLOR); 
	drawChar(r.left, r.bottom, 200, WINDOW_COLOR_BOUNDRECT, DRAW_MODE_CH_COLOR); 
	drawChar(r.right, r.bottom, 188, WINDOW_COLOR_BOUNDRECT, DRAW_MODE_CH_COLOR);
}
#endif /* DRAW_H */