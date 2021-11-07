#ifndef MAP_H
#define MAP_H
#include "map.h"

// направления
const int DIRECT_LEFT   = 0;
const int DIRECT_TOP    = 1;
const int DIRECT_RIGHT  = 2;
const int DIRECT_BOTTOM = 3;
//-------------------------------------------------------- режим врага
const int ENEMY_MODE_NORMAL  = 0; // нормальное
const int ENEMY_MODE_PURSUIT = 1; // преследование
//-------------------------------------------------------- карта
const int MAP_WIDTH  = SCR_WIDTH-15; // ширина карты
const int MAP_HEIGHT = SCR_HEIGHT;	 // высота карты

const int  MAP_BOXS_COUNT = 11;
const BYTE MAP_BOXS[MAP_BOXS_COUNT] = {176, 177, 178, 179, 30, 31, 16, 17, 196, 221, 220};

const int MAX_ENEMYS = 20; // максимум врагов
const BYTE ENEMY_CHAR = 2; // символ врага

// то что будим собирать
const int MAX_PRIZE_CHARS = 5;
const BYTE PRIZE_CHARS[MAX_PRIZE_CHARS] = {3,4,5,6, 253}; // символы призов
const int MAX_PRIZES = 100;

const DWORD PRIZE_TIME_FLASH = 500 >> 1; // мигание призов в мс
DWORD PrizeLastTime; // последнее время переключения
BOOL  PrizeIsON; // true если включено // используется для мерцания

struct Player player; // игрок
struct Prize prizes [MAX_PRIZES]; // иоформация о призах
struct Enemy enemys [MAX_ENEMYS]; // информация о врагах

CHAR_INFO map_data [SCR_SIZE]; // стены лабиринта
int EnemyCount; // количество врагов
int PrizeCount; // количество призов
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
void PanelInfoDraw(); // рисует информационную панель
//---------------------------------------------------------------------

// вывод панели с информыцией
void PanelInfoDraw()
{
	drawFillRect(Rect(MAP_WIDTH, 0, SCR_WIDTH, SCR_HEIGHT), ' ', 0x11);
	drawRect(Rect(MAP_WIDTH, 0, SCR_WIDTH, SCR_HEIGHT), 177, 0x01);

	int x = MAP_WIDTH + 2;
	int y = 2;

	drawText(x, y, "P A C M A N", 0x03, DRAW_MODE_CH_COLOR); y += 2;
	drawLine(MAP_WIDTH+1, y, SCR_WIDTH-1, y, 0x13, 196, DRAW_MODE_CH_COLOR); y++;
	drawText(x, y, "Уровень", COLOR_INFO_TEXT);	y++;
	drawLine(MAP_WIDTH+1, y, SCR_WIDTH-1, y, 0x13, 196, DRAW_MODE_CH_COLOR); y++;
	drawText(x, y, "Счет", COLOR_INFO_TEXT); y++;
	drawLine(MAP_WIDTH+1, y, SCR_WIDTH-1, y, 0x13, 196, DRAW_MODE_CH_COLOR); y++;
	drawText(x, y, "Осталось", COLOR_INFO_TEXT); y++;
	drawLine(MAP_WIDTH+1, y, SCR_WIDTH-1, y, 0x13, 196, DRAW_MODE_CH_COLOR); y++;
	drawText(x, y, "Жизнь", COLOR_INFO_TEXT); y++;
	drawLine(MAP_WIDTH+1, y, SCR_WIDTH-1, y, 0x13, 196, DRAW_MODE_CH_COLOR);

	// клавиши управления
	y = SCR_HEIGHT - 15;
	drawLine(MAP_WIDTH+1, y, SCR_WIDTH-1, y, 0x13, 205, DRAW_MODE_CH_COLOR); y++;
	drawText(x, y, "управление", 0x13);	y++;
	drawLine(MAP_WIDTH+1, y, SCR_WIDTH-1, y, 0x13, 205, DRAW_MODE_CH_COLOR); y += 2;
	x += 3;
	drawText(x-3, y, "ESC", COLOR_CONTROL_CHAR); drawText(x+1, y, "меню", COLOR_DIRECT_TEXT);y += 2;
	drawChar(x-1, y, 30, COLOR_CONTROL_CHAR); drawText(x+1, y, "вверх", COLOR_DIRECT_TEXT); y += 2;
	drawChar(x-1, y, 31, COLOR_CONTROL_CHAR); drawText(x+1, y, "вниз", COLOR_DIRECT_TEXT); y += 2;
	drawChar(x-1, y, 17, COLOR_CONTROL_CHAR); drawText(x+1, y, "влево", COLOR_DIRECT_TEXT); y += 2;
	drawChar(x-1, y, 16, COLOR_CONTROL_CHAR); drawText(x+1, y, "вправо", COLOR_DIRECT_TEXT); 
}

// если враг видит игрока
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

// выбор направления врага
void EnemyNewDirect(Enemy& e)
{	
	// назад не ходим 
	while ((e.direct = rand() % 4) == e.direct_back);

	// запоминаем обратное направление
	if (e.direct == DIRECT_LEFT)
		e.direct_back = DIRECT_RIGHT;
	else if (e.direct == DIRECT_RIGHT)
		e.direct_back = DIRECT_LEFT;
	else if (e.direct == DIRECT_TOP)
		e.direct_back = DIRECT_BOTTOM;
	else 
		e.direct_back = DIRECT_TOP;
}

// создаем врагов
void EnemysCreate(int Level)
{
	// задаем количество врагов
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

		enemys[i].x = (float)x;	// позиция по горизонтали
		enemys[i].y = (float)y;	// позиция по вертикали
		enemys[i].attr = 0x04;	// цвет врага
		enemys[i].mode = ENEMY_MODE_NORMAL;	// режим
		enemys[i].speed = (float(rand() % 1000) / 1000) + 0.1f; // скорость
		if (enemys[i].speed > 1.0f) enemys[i].speed = 1.0f; // ограничиваем скорость
		EnemyNewDirect(enemys[i]); // выбираем направление
	}
}

// есть ли враг в заданной позиции
BOOL EnemyIs(int x, int y)
{
	return scrGetChar(x,y) == ENEMY_CHAR;
}

// рисуем врага
void EnemyDraw()
{
	for (int i = 0; i < EnemyCount; i++)
	{
		drawChar((int)enemys[i].x, (int)enemys[i].y, ENEMY_CHAR, enemys[i].attr);
	}
}

// движение врага
void EnemyMove(Enemy& e)
{
	// запоминаем координаты
	float old_x = e.x;
	float old_y = e.y;
	// проверка видимости игрока
	BOOL isView = EnemyIsViewPlayer(e); 
	// если враг видит игрока
	if (isView && !player.hidden)
	{	// выбираем направление в сторону игрока
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
		e.mode = ENEMY_MODE_PURSUIT; // режим преследования
		e.attr = ENEMY_ATTR_PURSUIT; // цвет врага в режиме преследования
	}
	else
	{
		e.mode = ENEMY_MODE_NORMAL; // свободное движение
		e.attr = ENEMY_ATTR_NORMAL; // нормальный цвет врага
	}

	// устанавливаем новые координаты врага
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

	// если догнаг игрока
	if (PlayerIs((int)e.x, (int)e.y))
	{
		if (!player.hidden) // если игрок не скрыт от врага
		{
			player.lives--; // отнимаем жизнь
			playerFlash();  // делаем игрока скрытым от врагов и заставляем его мигать
			EnemyNewDirect(e); // выбираем новое направление врага
		}
		return;
	}	
	
	// если ничего нет
	if (scrIsEmpty((int)e.x, (int)e.y))
	{
		if (GetTickCount() - e.last_time_direct >= ENEMY_TIME_DIRECT_UPDATA)
		{
			EnemyNewDirect(e);
			e.last_time_direct = GetTickCount();
		}
		return;
	}

	// если неможет походить, то выбираем другое направление и возвращаем врага на шаг назад
	EnemyNewDirect(e);
	e.x = old_x;
	e.y = old_y;
}

// обновляем координаты всех врагов
void EnemyMoves()
{
	for (int i = 0; i < EnemyCount; i++)
		EnemyMove(enemys[i]);
}

//---------------------------------------------------------------------
// рисуем призы
void PrizeDraw()
{
	if (PrizeIsON) // инвертируем яркость приза
		for (int i = 0; i < PrizeCount; i++)
			drawChar(prizes[i].x, prizes[i].y, prizes[i].ch, prizes[i].attr ^ 0x08);
	else // нормальная яркость
		for (int i = 0; i < PrizeCount; i++)
			drawChar(prizes[i].x, prizes[i].y, prizes[i].ch, prizes[i].attr);

	// синхронизируем изменение яркости
	if (GetTickCount() - PrizeLastTime >= PRIZE_TIME_FLASH)
	{
		PrizeIsON = !PrizeIsON;
		PrizeLastTime = GetTickCount();
	}
}

// создаем призы
void PrizeCreate(int Level)
{
	// количество призов
	PrizeCount = (Level << 1) + (rand() % 3) + 5;
	if (PrizeCount >= MAX_PRIZES)
		PrizeCount = MAX_PRIZES;

	int x,y;
	for (int i = 0; i < PrizeCount; i++)
	{
		do
		{	// ищим куда можно вставить
			x = rand() % MAP_WIDTH;
			y = rand() % MAP_HEIGHT;
		}while(!scrIsEmpty(x,y));

		prizes[i].x = x; // положение по горизонтали
		prizes[i].y = y; // положение по вертикали
		prizes[i].attr = (rand() % 15) + 1; // случайный цвет
		prizes[i].ch = PRIZE_CHARS[rand() % MAX_PRIZE_CHARS]; // задаем один из символов
		// выводим на экран для предотвращения наложения одного на другой
		drawChar(prizes[i].x, prizes[i].y, prizes[i].ch, prizes[i].attr);
	}
}

// возвращает индекс приза в заданнных координатах если есть, еначе -1
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

// удаление приза
void PrizeDelete(int Index)
{
	// если приз не последний, то ставим последний на его место
	if (Index < PrizeCount-1)
		prizes[Index] = prizes[PrizeCount-1];

	// уменьшаем количество призов
	if (PrizeCount > 0)
		PrizeCount--;
}

// если есть приз в позиции [x,y]
BOOL PrizeIs(int x, int y)
{
	return PrizeIndexOf(x,y) >= 0;
}

// если есть игрок в позиции [x,y]
BOOL PlayerIs(int x, int y)
{
	return (x == player.x) && (y == player.y);
}

// движение игрока
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

// задаем начальные координаты игрока
void playerSet()
{
	player.lives = PLAYER_START_LIVES;	// количество жизней игрока
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
	if (player.hidden) // если скрыт от врагов, то мигает
	{
		if (player.lighten)
			drawChar((int)player.x, (int)player.y, player.ch, player.attr, player.draw_mode);
		else
			drawChar((int)player.x, (int)player.y, player.ch, player.attr ^ 0x08, player.draw_mode);
		
		player.lighten = !player.lighten;
		
		// если время вышло, то отключаем невидимость и мегание
		if (GetTickCount() - player.last_time_flash >= PLAYER_TIME_FLASH) 
			player.hidden = FALSE;
	}
	else // игрок в нормальном состоянии
		drawChar((int)player.x, (int)player.y, player.ch, player.attr, player.draw_mode);
}

// возвращает количество свободных клеток в заданном направлении
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

// возвращает true если прямоугольник пуст
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

// рисует линию лабиринта
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

// создает новый уровень
void mapCreate(int Level)
{
	// рандомизируем
	SYSTEMTIME st;
	GetLocalTime(&st);	
	srand( st.wMilliseconds);

	scrClear(MAP_SPACE_ATTR, MAP_SPACE_CHAR);
	drawRect(Rect(0,0, MAP_WIDTH, MAP_HEIGHT), MAP_RECT_CHAR, MAP_RECT_ATTR);

	
	playerDraw(); // выводим игрока 

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