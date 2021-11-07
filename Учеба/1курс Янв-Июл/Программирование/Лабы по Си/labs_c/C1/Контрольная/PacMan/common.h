#pragma once
#include <stdio.h>
#include <conio.h>
#include "draw.h"
#include "menu.h"
#include "abc.h"
#include "game.h"
#include "map.h"

//-------------------------------------------------------- ������ ����������
const BYTE COLOR_CONTROL_CHAR	= 0x16; // ���� ������� ����������
const BYTE COLOR_DIRECT_TEXT	= 0x12; // ���� ������ �����������
const BYTE COLOR_INFO_TEXT		= 0x17; // ���� ������ ����������
const BYTE COLOR_INFO_VALUE		= 0x1A; // ���� ������ ��������
//-------------------------------------------------------- �����
const BYTE MAP_SPACE_ATTR = 0x00; // ���� �������
const BYTE MAP_SPACE_CHAR = ' ';  // ������ �������
const BYTE MAP_RECT_ATTR  = 52;	  // ���� �������
const BYTE MAP_RECT_CHAR  = 177;  // ������ �������
//-------------------------------------------------------- �������������� ����
const BYTE SUBMENU_COLOR_TEXT	  = 0x18; // ���� � ������� ���������
const BYTE SUBMENU_COLOR_SELECTED = 0x1F; // ���� � ��������� ���������
//-------------------------------------------------------- ����
const BYTE WINDOW_COLOR_BOUNDRECT = 0x1F; // ���� �����
//-------------------------------------------------------- ����
const DWORD ENEMY_TIME_DIRECT_UPDATA = 500;	// ����� ���������� �����������
const DWORD ENEMY_ATTR_NORMAL		 = 0x04;// ���� � ���������� ���������
const DWORD ENEMY_ATTR_PURSUIT		 = 0x0C;// ���� �� ����� �������������
//-------------------------------------------------------- ����
const DWORD GAME_TIME_REFRESH = 80; // ����� ���������� ���� � ��
//-------------------------------------------------------- �����
const DWORD PLAYER_TIME_FLASH  = 5000;// ����� ������� ������ ��� ������ ����� (��)
const int PLAYER_MAX_ADD_SCORE = 10;  // ������������ ����� ����� �� ����
const int PLAYER_START_LIVES   = 5;   // ���������� ������ � ������ ����
//-------------------------------------------------------- ������
const int MIN_DISTANCE_SQUARE_PL_VS_EN	= 20*20; // ����������� ��������� (� ������� 2) ����� ���������� � ������
//--------------------------------------------------------


BOOL IsKeyDown(int VK); // ��������� ������ �� �������
int Distance_square(int x1, int y1, int x2, int y2); // ������� ��������� ����� ������� [x1,y1] � [x2,y2]
char* IntToStr(int d); // ������������ ����� � ������ � ���������� ��������� �� ���������