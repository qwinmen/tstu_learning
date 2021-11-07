#pragma once
#include <windows.h>

//-------------------------------------------------------- �����
const int SCR_WIDTH  = 80;		// ������
const int SCR_HEIGHT = 43;		// ������
const int SCR_SIZE = SCR_WIDTH * SCR_HEIGHT;	// ������ ������
extern CHAR_INFO scr_chars [SCR_SIZE];			// �������� ����� (������� + ��������)
extern HANDLE hOut;		// ��������� �� ����������� ����� ������
//-------------------------------------------------------- ������ ������
const int DRAW_MODE_CHAR = 1;		// ������
const int DRAW_MODE_TEXTCOLOR = 2;	// ���� �������
const int DRAW_MODE_BACKGROUND = 4; // ���� ����
const int DRAW_MODE_ATTR = DRAW_MODE_TEXTCOLOR | DRAW_MODE_BACKGROUND;	// ���� ������� � ����
const int DRAW_MODE_CH_COLOR = DRAW_MODE_CHAR | DRAW_MODE_TEXTCOLOR;	// ������� ������
const int DRAW_MODE_ALL = 0xFFFFFF;	// ���
//--------------------------------------------------------
BYTE scrGetAttr(int x, int y); // ���������� ������� �������
BYTE scrGetChar(int x, int y); // ���������� ������
BOOL scrIsEmpty(int x, int y); // TRUE ���� ������ ���

RECT& Rect(int left, int top, int right, int bottom);
BOOL scrInic(const char* Title); // ������������� (��������� �� ������������� ������ �������)
BOOL scrUpdata(); // ���������� ������
void scrClear(BYTE attr = 0, BYTE ch = ' '); // ������� ������
void drawChar(int x, int y, BYTE ch, BYTE attr = 0x0F, const int Mode = DRAW_MODE_ALL);
void drawRect(RECT& rc, BYTE ch, BYTE attr, const int Mode = DRAW_MODE_ALL);
void drawFillRect(RECT& rc, BYTE ch, BYTE attr, const int Mode = DRAW_MODE_ALL);
void drawLine(int x1, int y1, int x2, int y2, BYTE attr, char* str = "", const int Mode = DRAW_MODE_ALL);
void drawLine(int x1, int y1, int x2, int y2, BYTE attr, BYTE ch, const int Mode = DRAW_MODE_ALL);
void drawText(int x, int y, char* str, BYTE attr = 0x0F, const int Mode = DRAW_MODE_ALL);
void drawWindow(RECT& r, const BYTE attr = 0x18);
