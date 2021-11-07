#pragma once
#include "common.h"

int const ABC_CHAR_WIDTH = 8;
int const ABC_CHAR_HEIGHT = 8;

// идентификаторы символов
enum abcID {
	abc_A,
	abc_C,
	abc_P,
	abc_M,
	abc_N,
	// новые вставлять сюда
	abc_COUNT // всегда последний!!!
};

// вывод большого символа
void abcDraw(int x, int y, abcID id, BYTE ch, BYTE attr, int Mode = DRAW_MODE_ALL);