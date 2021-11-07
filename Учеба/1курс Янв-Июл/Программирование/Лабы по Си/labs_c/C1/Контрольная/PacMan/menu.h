#pragma once
#include "common.h"

//-------------------------------------------------------- ������� ����
extern const int MENU_ITEM_COUNT;	// ���������� ���������
extern int MenuItemSelected;		// ��������� �������
//-------------------------------------------------------- �������������� ����
const int MI_NO_SELECT = -1;		// ������ �� ��������	
const int MI_NEW_GAME = 0;			// ����
const int MI_EXIT = 1;				// �����
//-------------------------------------------------------- �������������� ��������������� ����
const int SMI_NO_SELECT = -1;		// ������ �� ��������
const int SMI_CONTINUE = 0;			// ���������� ����
const int SMI_TO_MENU = 1;			// ������� ����
const int SMI_EXIT = 2;				// �����
//--------------------------------------------------------
int menuExecute();		// ����� ����
int subMenuExecute();	// ����� ��������������� ����
