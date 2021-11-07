#pragma once
#include "common.h"

int const ABC_CHAR_WIDTH = 8;
int const ABC_CHAR_HEIGHT = 8;

// �������������� ��������
enum abcID {
	abc_A,
	abc_C,
	abc_P,
	abc_M,
	abc_N,
	// ����� ��������� ����
	abc_COUNT // ������ ���������!!!
};

// ����� �������� �������
void abcDraw(int x, int y, abcID id, BYTE ch, BYTE attr, int Mode = DRAW_MODE_ALL);