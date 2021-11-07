#ifndef MAP_H
#define MAP_H
#include "map.h"

// �����������
const int DIRECT_LEFT   = 0;
const int DIRECT_TOP    = 1;
const int DIRECT_RIGHT  = 2;
const int DIRECT_BOTTOM = 3;
//-------------------------------------------------------- ����� �����
const int ENEMY_MODE_NORMAL  = 0; // ����������
const int ENEMY_MODE_PURSUIT = 1; // �������������
//-------------------------------------------------------- �����
const int MAP_WIDTH  = SCR_WIDTH-15; // ������ �����
const int MAP_HEIGHT = SCR_HEIGHT;	 // ������ �����

const int  MAP_BOXS_COUNT = 11;
const BYTE MAP_BOXS[MAP_BOXS_COUNT] = {176, 177, 178, 179, 30, 31, 16, 17, 196, 221, 220};

const int MAX_ENEMYS = 20; // �������� ������
const BYTE ENEMY_CHAR = 2; // ������ �����

// �� ��� ����� ��������
const int MAX_PRIZE_CHARS = 5;
const BYTE PRIZE_CHARS[MAX_PRIZE_CHARS] = {3,4,5,6, 253}; // ������� ������
const int MAX_PRIZES = 100;

const DWORD PRIZE_TIME_FLASH = 500 >> 1; // ������� ������ � ��
DWORD PrizeLastTime; // ��������� ����� ������������
BOOL  PrizeIsON; // true ���� �������� // ������������ ��� ��������

struct Player player; // �����
struct Prize prizes [MAX_PRIZES]; // ���������� � ������
struct Enemy enemys [MAX_ENEMYS]; // ���������� � ������

CHAR_INFO map_data [SCR_SIZE]; // ����� ���������
int EnemyCount; // ���������� ������
int PrizeCount; // ���������� ������
//---------------------------------------------------------------------

int  get_space_count(int x, int y, int direct, int maxlen);
BOOL isSpaceBox3x3(int x, int y);
BOOL mapDrawLine(int x, int y, int direct, int maxlen, BYTE attr, BYTE ch);
void mapDraw();
void mapCreate(int Level);
void setClearBox3x3(int x, int y);
//-------------------------------------------
void playerMove();
void playerSet();
void playerDraw();
void playerFlash();
BOOL PlayerIs(int x, int y);
//-------------------------------------------
void PrizeCreate(int Level);
void PrizeDraw();
int  PrizeIndexOf(int x, int y);
void PrizeDelete(int Index);
BOOL PrizeIs(int x, int y);
//-------------------------------------------
void EnemyNewDirect(Enemy& e);
void EnemysCreate(int Level);
void EnemyDraw();
void EnemyMove(Enemy& e);
void EnemyMoves();
BOOL EnemyIs(int x, int y);
BOOL EnemyIsViewPlayer(Enemy& e); 
//-------------------------------------------
void PanelInfoDraw(); // ������ �������������� ������
//---------------------------------------------------------------------

// ����� ������ � �����������
void PanelInfoDraw()
{
	drawFillRect(Rect(MAP_WIDTH, 0, SCR_WIDTH, SCR_HEIGHT), ' ', 0x11);
	drawRect(Rect(MAP_WIDTH, 0, SCR_WIDTH, SCR_HEIGHT), 177, 0x01);

	int x = MAP_WIDTH + 2;
	int y = 2;

	drawText(x, y, "P A C M A N", 0x03, DRAW_MODE_CH_COLOR); y += 2;
	drawLine(MAP_WIDTH+1, y, SCR_WIDTH-1, y, 0x13, 196, DRAW_MODE_CH_COLOR); y++;
	drawText(x, y, "�������", COLOR_INFO_TEXT);	y++;
	drawLine(MAP_WIDTH+1, y, SCR_WIDTH-1, y, 0x13, 196, DRAW_MODE_CH_COLOR); y++;
	drawText(x, y, "����", COLOR_INFO_TEXT); y++;
	drawLine(MAP_WIDTH+1, y, SCR_WIDTH-1, y, 0x13, 196, DRAW_MODE_CH_COLOR); y++;
	drawText(x, y, "��������", COLOR_INFO_TEXT); y++;
	drawLine(MAP_WIDTH+1, y, SCR_WIDTH-1, y, 0x13, 196, DRAW_MODE_CH_COLOR); y++;
	drawText(x, y, "�����", COLOR_INFO_TEXT); y++;
	drawLine(MAP_WIDTH+1, y, SCR_WIDTH-1, y, 0x13, 196, DRAW_MODE_CH_COLOR);

	// ������� ����������
	y = SCR_HEIGHT - 15;
	drawLine(MAP_WIDTH+1, y, SCR_WIDTH-1, y, 0x13, 205, DRAW_MODE_CH_COLOR); y++;
	drawText(x, y, "����������", 0x13);	y++;
	drawLine(MAP_WIDTH+1, y, SCR_WIDTH-1, y, 0x13, 205, DRAW_MODE_CH_COLOR); y += 2;
	x += 3;
	drawText(x-3, y, "ESC", COLOR_CONTROL_CHAR); drawText(x+1, y, "����", COLOR_DIRECT_TEXT);y += 2;
	drawChar(x-1, y, 30, COLOR_CONTROL_CHAR); drawText(x+1, y, "�����", COLOR_DIRECT_TEXT); y += 2;
	drawChar(x-1, y, 31, COLOR_CONTROL_CHAR); drawText(x+1, y, "����", COLOR_DIRECT_TEXT); y += 2;
	drawChar(x-1, y, 17, COLOR_CONTROL_CHAR); drawText(x+1, y, "�����", COLOR_DIRECT_TEXT); y += 2;
	drawChar(x-1, y, 16, COLOR_CONTROL_CHAR); drawText(x+1, y, "������", COLOR_DIRECT_TEXT); 
}

// ���� ���� ����� ������
BOOL EnemyIsViewPlayer(Enemy& e)
{
	int i = 0;
	int min_x = ((int)e.x < player.x ? (int)e.x : player.x);
	int max_x = ((int)e.x > player.x ? (int)e.x : player.x);
	int min_y = ((int)e.y < player.y ? (int)e.y : player.y);
	int max_y = ((int)e.y > player.y ? (int)e.y : player.y);

	int w = max_x - min_x;
	int h = max_y - min_y;

	if (w > h)
	{		
		while (i < w && scrIsEmpty(min_x + i, int(((float)i / w) * h + min_y)))	i++;
	}
	else
	{
		while (i < h && scrIsEmpty(int(((float)i / h) * w + min_x), min_y + i))	i++;
	}

	return i == (w > h ? w : h);
}

// ����� ����������� �����
void EnemyNewDirect(Enemy& e)
{	
	// ����� �� ����� 
	while ((e.direct = rand() % 4) == e.direct_back);

	// ���������� �������� �����������
	if (e.direct == DIRECT_LEFT)
		e.direct_back = DIRECT_RIGHT;
	else if (e.direct == DIRECT_RIGHT)
		e.direct_back = DIRECT_LEFT;
	else if (e.direct == DIRECT_TOP)
		e.direct_back = DIRECT_BOTTOM;
	else 
		e.direct_back = DIRECT_TOP;
}

// ������� ������
void EnemysCreate(int Level)
{
	// ������ ���������� ������
	if (Level + 2 < MAX_ENEMYS)
		EnemyCount = Level + 2;
	else
		EnemyCount = MAX_ENEMYS;
	
	int x, y;
	for (int i = 0; i < EnemyCount; i++)
	{
		do{
			x = rand() % MAP_WIDTH;
			y = rand() % MAP_HEIGHT;
		}while(!isSpaceBox3x3(x,y) || Distance_square(x,y, player.x, player.y) <= MIN_DISTANCE_SQUARE_PL_VS_EN);

		enemys[i].x = (float)x;	// ������� �� �����������
		enemys[i].y = (float)y;	// ������� �� ���������
		enemys[i].attr = 0x04;	// ���� �����
		enemys[i].mode = ENEMY_MODE_NORMAL;	// �����
		enemys[i].speed = (float(rand() % 1000) / 1000) + 0.1f; // ��������
		if (enemys[i].speed > 1.0f) enemys[i].speed = 1.0f; // ������������ ��������
		EnemyNewDirect(enemys[i]); // �������� �����������
	}
}

// ���� �� ���� � �������� �������
BOOL EnemyIs(int x, int y)
{
	return scrGetChar(x,y) == ENEMY_CHAR;
}

// ������ �����
void EnemyDraw()
{
	for (int i = 0; i < EnemyCount; i++)
	{
		drawChar((int)enemys[i].x, (int)enemys[i].y, ENEMY_CHAR, enemys[i].attr);
	}
}

// �������� �����
void EnemyMove(Enemy& e)
{
	// ���������� ����������
	float old_x = e.x;
	float old_y = e.y;
	// �������� ��������� ������
	BOOL isView = EnemyIsViewPlayer(e); 
	// ���� ���� ����� ������
	if (isView && !player.hidden)
	{	// �������� ����������� � ������� ������
		if (int(e.x) == player.x)
		{
			if (int(e.y) > player.y)
				e.direct = DIRECT_TOP;
			else
				e.direct = DIRECT_BOTTOM;
		}
		else
		{
			if (int(e.x) > player.x)
				e.direct = DIRECT_LEFT;
			else
				e.direct = DIRECT_RIGHT;
		}
		e.mode = ENEMY_MODE_PURSUIT; // ����� �������������
		e.attr = ENEMY_ATTR_PURSUIT; // ���� ����� � ������ �������������
	}
	else
	{
		e.mode = ENEMY_MODE_NORMAL; // ��������� ��������
		e.attr = ENEMY_ATTR_NORMAL; // ���������� ���� �����
	}

	// ������������� ����� ���������� �����
	switch (e.direct){
	case DIRECT_LEFT:
		e.x = e.x - e.speed;
	break;
	case DIRECT_RIGHT:
		e.x = e.x + e.speed;
	break;
	case DIRECT_TOP:
		e.y = e.y - e.speed;
	break;
	case DIRECT_BOTTOM:
		e.y = e.y + e.speed;
	break;
	}

	// ���� ������ ������
	if (PlayerIs((int)e.x, (int)e.y))
	{
		if (!player.hidden) // ���� ����� �� ����� �� �����
		{
			player.lives--; // �������� �����
			playerFlash();  // ������ ������ ������� �� ������ � ���������� ��� ������
			EnemyNewDirect(e); // �������� ����� ����������� �����
		}
		return;
	}	
	
	// ���� ������ ���
	if (scrIsEmpty((int)e.x, (int)e.y))
	{
		if (GetTickCount() - e.last_time_direct >= ENEMY_TIME_DIRECT_UPDATA)
		{
			EnemyNewDirect(e);
			e.last_time_direct = GetTickCount();
		}
		return;
	}

	// ���� ������� ��������, �� �������� ������ ����������� � ���������� ����� �� ��� �����
	EnemyNewDirect(e);
	e.x = old_x;
	e.y = old_y;
}

// ��������� ���������� ���� ������
void EnemyMoves()
{
	for (int i = 0; i < EnemyCount; i++)
		EnemyMove(enemys[i]);
}

//---------------------------------------------------------------------
// ������ �����
void PrizeDraw()
{
	if (PrizeIsON) // ����������� ������� �����
		for (int i = 0; i < PrizeCount; i++)
			drawChar(prizes[i].x, prizes[i].y, prizes[i].ch, prizes[i].attr ^ 0x08);
	else // ���������� �������
		for (int i = 0; i < PrizeCount; i++)
			drawChar(prizes[i].x, prizes[i].y, prizes[i].ch, prizes[i].attr);

	// �������������� ��������� �������
	if (GetTickCount() - PrizeLastTime >= PRIZE_TIME_FLASH)
	{
		PrizeIsON = !PrizeIsON;
		PrizeLastTime = GetTickCount();
	}
}

// ������� �����
void PrizeCreate(int Level)
{
	// ���������� ������
	PrizeCount = (Level << 1) + (rand() % 3) + 5;
	if (PrizeCount >= MAX_PRIZES)
		PrizeCount = MAX_PRIZES;

	int x,y;
	for (int i = 0; i < PrizeCount; i++)
	{
		do
		{	// ���� ���� ����� ��������
			x = rand() % MAP_WIDTH;
			y = rand() % MAP_HEIGHT;
		}while(!scrIsEmpty(x,y));

		prizes[i].x = x; // ��������� �� �����������
		prizes[i].y = y; // ��������� �� ���������
		prizes[i].attr = (rand() % 15) + 1; // ��������� ����
		prizes[i].ch = PRIZE_CHARS[rand() % MAX_PRIZE_CHARS]; // ������ ���� �� ��������
		// ������� �� ����� ��� �������������� ��������� ������ �� ������
		drawChar(prizes[i].x, prizes[i].y, prizes[i].ch, prizes[i].attr);
	}
}

// ���������� ������ ����� � ��������� ����������� ���� ����, ����� -1
int PrizeIndexOf(int x, int y)
{
	if (PrizeCount <= 0)
		return -1;
	int i = 0;
	while ((i < PrizeCount-1) && (prizes[i].x != x || prizes[i].y != y)) i++;
	if (prizes[i].x == x && prizes[i].y == y)
		return i;
	else 
		return -1;
}

// �������� �����
void PrizeDelete(int Index)
{
	// ���� ���� �� ���������, �� ������ ��������� �� ��� �����
	if (Index < PrizeCount-1)
		prizes[Index] = prizes[PrizeCount-1];

	// ��������� ���������� ������
	if (PrizeCount > 0)
		PrizeCount--;
}

// ���� ���� ���� � ������� [x,y]
BOOL PrizeIs(int x, int y)
{
	return PrizeIndexOf(x,y) >= 0;
}

// ���� ���� ����� � ������� [x,y]
BOOL PlayerIs(int x, int y)
{
	return (x == player.x) && (y == player.y);
}

// �������� ������
void playerMove()
{
	int old_x = player.x;
	int old_y = player.y;

	if (IsKeyDown(VK_UP))
		player.y--;
	else
	if (IsKeyDown(VK_DOWN))
		player.y++;
	else
	if (IsKeyDown(VK_LEFT))
		player.x--;
	else
	if (IsKeyDown(VK_RIGHT))
		player.x++;
	
	if (scrIsEmpty(player.x, player.y)) return;
	if (PrizeIs(player.x, player.y))
	{
		player.score += DWORD((PLAYER_MAX_ADD_SCORE-1) * (float(rand() % 1000) / 1000)+1) + (PLAYER_MAX_ADD_SCORE >> 1);
		PrizeDelete(PrizeIndexOf(player.x, player.y));
		return;
	}

	player.x = old_x;
	player.y = old_y;
}

void playerFlash()
{
	player.last_time_flash = GetTickCount();
	player.hidden = TRUE;
}

// ������ ��������� ���������� ������
void playerSet()
{
	player.lives = PLAYER_START_LIVES;	// ���������� ������ ������
	player.score = 0;
	player.attr = 0x07;
	player.ch = 1;
	player.draw_mode = DRAW_MODE_CH_COLOR;
	player.x = 1;
	player.y = MAP_HEIGHT - 2;
	player.hidden = FALSE;
	player.last_time_flash = 0;
	player.lighten = FALSE;
}

void playerDraw()
{
	if (player.hidden) // ���� ����� �� ������, �� ������
	{
		if (player.lighten)
			drawChar((int)player.x, (int)player.y, player.ch, player.attr, player.draw_mode);
		else
			drawChar((int)player.x, (int)player.y, player.ch, player.attr ^ 0x08, player.draw_mode);
		
		player.lighten = !player.lighten;
		
		// ���� ����� �����, �� ��������� ����������� � �������
		if (GetTickCount() - player.last_time_flash >= PLAYER_TIME_FLASH) 
			player.hidden = FALSE;
	}
	else // ����� � ���������� ���������
		drawChar((int)player.x, (int)player.y, player.ch, player.attr, player.draw_mode);
}

// ���������� ���������� ��������� ������ � �������� �����������
int get_space_count(int x, int y, int direct, int maxlen)
{
	int i = 0;
	switch (direct){
	case DIRECT_LEFT:
		if (x - maxlen < 1) maxlen = x;
		while (i < maxlen && scrIsEmpty(x-i,y)) i++;
	break;
	case DIRECT_TOP:
		if (y - maxlen < 1) maxlen = y;
		while (i < maxlen && scrIsEmpty(x,y+i)) i++;
	break;
	case DIRECT_RIGHT:
		if (x + maxlen >= MAP_WIDTH) maxlen = MAP_WIDTH - x - 1;
		while (i < maxlen && scrIsEmpty(x+i,y)) i++;
	break;
	case DIRECT_BOTTOM:
		if (y + maxlen >= MAP_HEIGHT) maxlen = MAP_HEIGHT - y - 1;
		while (i < maxlen && scrIsEmpty(x,y+i)) i++;
	break;
	};	
	return i;
}

// ���������� true ���� ������������� ����
BOOL isSpaceBox3x3(int x, int y)
{
	for (int row = y-1; row < y+1; row++)
	for (int col = x-1; col < x+1; col++)
	{
		if (!scrIsEmpty(col, row))
			return FALSE;
	}
	return TRUE;
}

// ������ ����� ���������
BOOL mapDrawLine(int x, int y, int direct, int maxlen, BYTE attr, BYTE ch)
{
	maxlen = get_space_count(x, y, direct, maxlen);
	if (maxlen < 1) return FALSE;

	int p = SCR_HEIGHT * y + x;
	
	switch (direct){
	case DIRECT_LEFT:
		while (maxlen > 0 && get_space_count(x-1,y-1, DIRECT_BOTTOM, 3) == 3 && get_space_count(x,y-1, DIRECT_BOTTOM, 3) == 3)
		{
			drawChar(x,y, ch, attr);
			maxlen--;
			x--;
		}
	break;
	case DIRECT_TOP:
		while (maxlen > 0 && get_space_count(x-1,y-1, DIRECT_RIGHT, 3) == 3 && get_space_count(x-1,y, DIRECT_RIGHT, 3) == 3)
		{
			drawChar(x,y, ch, attr);
			maxlen--;
			y--;
		}
	break;
	case DIRECT_RIGHT:
		while (maxlen > 0 && get_space_count(x+1,y-1, DIRECT_BOTTOM, 3) == 3 && get_space_count(x,y-1, DIRECT_BOTTOM, 3) == 3)
		{
			drawChar(x,y, ch, attr);
			maxlen--;
			x++;
		}
	break;
	case DIRECT_BOTTOM:
		while (maxlen > 0 && get_space_count(x-1,y+1, DIRECT_RIGHT, 3) == 3 && get_space_count(x-1,y, DIRECT_RIGHT, 3) == 3)
		{
			drawChar(x,y, ch, attr);
			maxlen--;
			y++;
		}
	break;
	};

	return TRUE;
}

void mapDraw()
{
	memcpy(scr_chars, map_data, sizeof(CHAR_INFO) * SCR_SIZE);	
}

// ������� ����� �������
void mapCreate(int Level)
{
	// �������������
	SYSTEMTIME st;
	GetLocalTime(&st);	
	srand( st.wMilliseconds);

	scrClear(MAP_SPACE_ATTR, MAP_SPACE_CHAR);
	drawRect(Rect(0,0, MAP_WIDTH, MAP_HEIGHT), MAP_RECT_CHAR, MAP_RECT_ATTR);

	
	playerDraw(); // ������� ������ 

	for (int i = 0; i < Level * 50 + 50; i++)
	{
		int x = (rand() % MAP_WIDTH);
		int y = (rand() % MAP_HEIGHT);
		int d = rand() % 3;
		BYTE attr = ((rand() % 6)+1) | (((rand() % 6)+1) << 4);
		mapDrawLine(x,y,d, (rand() % 15) + 5, attr, MAP_BOXS[rand() % MAP_BOXS_COUNT]);
	}

	drawChar(player.x, player.y, MAP_SPACE_CHAR, MAP_SPACE_ATTR);

	PanelInfoDraw();
	memcpy(map_data, scr_chars, sizeof(CHAR_INFO) * SCR_SIZE);

	PrizeCreate(Level);
	EnemysCreate(Level);	
}

#endif /* MAP_H */