#ifndef MENU_H
#define MENU_H
#include "menu.h"
#include "common.h"

int MenuItemSelected;
const int MENU_ITEM_COUNT = 2;
char* const MenuItems [MENU_ITEM_COUNT] = {"� � � �", "� � � � �"};

const int SUBMENU_ITEM_COUNT = 3;
char* const SubMenuItems [SUBMENU_ITEM_COUNT] = {"� � � � � � � � � �  � � � �", "� � � � � � �  � � � �", "� � � � �"};
int SubMenuItemSelected;

void subMenuDraw()
{
	int cx = SCR_WIDTH >> 1;	// ����� ������
	int cy = SCR_HEIGHT >> 1;
	int h = SUBMENU_ITEM_COUNT; // ������ ����
	int pos_y = cy - h; // ������� ������� ������
	h += 3;
	int w = (int)strlen(SubMenuItems[0]); 
	for (int i = 1; i < SUBMENU_ITEM_COUNT; i++)
	{
		int len = (int)strlen(SubMenuItems[i]);
		if (w < len) w = len; // ������� ����� ������� ����� � ����
	}
	w = (w >> 1) + 3; // �������� ������ ����

	// ������������� ����
	RECT r = Rect(cx - w, cy - h, cx + w, cy + h - 1);
	drawWindow(r);

	// ����� ������ �� ������ ���� ����
	for (int i = 0; i < SUBMENU_ITEM_COUNT; i++)
	{
		int sz = (int)strlen(SubMenuItems[i]) >> 1;
		if (i == SubMenuItemSelected) // ���� ������� ������
			drawText(cx - sz, pos_y, SubMenuItems[i], SUBMENU_COLOR_SELECTED, DRAW_MODE_CH_COLOR);
		else
			drawText(cx - sz, pos_y, SubMenuItems[i], SUBMENU_COLOR_TEXT, DRAW_MODE_CH_COLOR);

		pos_y += 2; // ���������� ������
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
			if (IsKeyDown(VK_RETURN)) // ���� ������ �����, ��
				return SubMenuItemSelected; // ���������� ������ ��������

			if (IsKeyDown(VK_ESCAPE))
				return SMI_CONTINUE; // ���������� ����
			
			// ���������� ������ ���� �����
			if (IsKeyDown(VK_UP) && SubMenuItemSelected > 0)
				SubMenuItemSelected--;

			// ���������� ������ ���� ����
			if (IsKeyDown(VK_DOWN) && SubMenuItemSelected < SUBMENU_ITEM_COUNT-1)
				SubMenuItemSelected++;		
		}

		subMenuDraw();	// ������ ����
		scrUpdata();	// ������ �� ������		
		getch();		// ���� ����� � ����������
		flag = !flag;	// ����������� ����
	}
}

// ������� ���� � �������� �����
void menuDraw()
{
	int cx = SCR_WIDTH >> 1;
	int pos_y = SCR_HEIGHT - (MENU_ITEM_COUNT << 1) - 11;

	for (int i = 0; i < MENU_ITEM_COUNT; i++)
	{
		int sz = (int)strlen(MenuItems[i]) >> 1;
		if (i == MenuItemSelected) // ������������ ���������� ������� ����
			drawText(cx - sz, pos_y + (i << 1), MenuItems[i], 0x0F, DRAW_MODE_CH_COLOR);
		else // ������� � ���������� ���������
			drawText(cx - sz, pos_y + (i << 1), MenuItems[i], 0x08, DRAW_MODE_CH_COLOR);
	}
}

// ����� ����
int menuExecute()
{
	MenuItemSelected = 0;
	LogoDraw(TRUE);	// ������� ������� � ���������
	BOOL flag = FALSE; // ��� ���������� ��������� �������������� ����������
	while(TRUE)
	{			
		if (flag)
		{
			if (IsKeyDown(VK_RETURN)) // ���� ������ �����, �� 
				return MenuItemSelected; // ���������� ������ ��������
			
			if (IsKeyDown(VK_ESCAPE))
				return MI_EXIT; // ��������� ���������

			// ���������� ������ ���� �����
			if (IsKeyDown(VK_UP) && (MenuItemSelected > 0))
				MenuItemSelected--;

			// ���������� ������ ���� ����
			if (IsKeyDown(VK_DOWN) && (MenuItemSelected < MENU_ITEM_COUNT-1))
				MenuItemSelected++;
		}
		
		menuDraw();	// ����� ����
		scrUpdata();// ��������� ����������� �� ������
		getch();	// ���� ����� � ����������

		flag = !flag; // ����������� ����
	}
}

#endif /* MENU_H */