#ifndef GAME_H
#define GAME_H
#include "game.h"
#include "common.h"

const BYTE LOGO_COLOR_BG = 0x17; // цвет фона логотипа
const BYTE LOGO_COLOR_TEXT = 0x6E; // цвет текста логотипа
const DWORD LOGO_ANIMATION_TIME = 500; // время анимации логотипа
const BYTE LOGO_FILL_CHAR = 1; // символ которым рисуется логотип

const int LOGO_POS_X = (SCR_WIDTH >> 1) - 24;
const int LOGO_POS_Y = 8;

int current_level; // текущий уровень
DWORD last_time_updata; // последнее время обновления
//---------------------------------------------
void GameOver();	// вызываем при окончании игры
void GameUpdata();	// обновление игры
void NextLevel();	// переход на следующий уровень
void MainLoop();	// главный цикл
//---------------------------------------------

void NextLevel()
{
	// плавное стирание изображения
	for (int j = 0; j < 6; j++)
	{
		for (int i = 0; i < SCR_SIZE; i += 6)
		{
			int p = i + j;
			if (p < SCR_SIZE)
			{
				scr_chars[p].Attributes = 0;
				scr_chars[p].Char.AsciiChar = ' ';
			}
		}
		scrUpdata();
		Sleep(30);
	}
	
	current_level++;			// увеличиваем уровень
	mapCreate(current_level);	// создаем новую карту
	scrClear();					// очищаем экрынный буфер				

	// плавное появление нового уровня на экране
	for (int j = 0; j < 6; j++)
	{
		for (int i = 0; i < SCR_SIZE; i += 6)
		{
			int p = i + j;
			if (p < SCR_SIZE)
			{			
				scr_chars[p] = map_data[p];
			}
		}
		scrUpdata();
		Sleep(30);
	}

	GameUpdata();	// обновляем информацию о игре 
	scrUpdata();	// обновляем изображение на экране
	getch();
}

// новая игра
void NewGame()
{
	playerSet();  // устанавливаем игрока
	current_level = 1;					// текущий уровень
	mapCreate(current_level);			// создаем карту (игровое поле)
}

// обновление игры
void GameUpdata()
{
	scrClear();		// очищаем экранный буфер
	mapDraw();		// рисуем карту (игровое поле)
	EnemyMoves();	// обновляем положение врагов
	EnemyDraw();	// рисуем врагов
	PrizeDraw();	// рисуем призы
	playerMove();	// обновляем положение игрока
	playerDraw();	// рисуем игрока
	statusDraw();	// выводим информацию о игре
	scrUpdata();	// обновляем изображение на экране
}

// главная функция игры
BOOL Game()
{
	while (TRUE)
	{
		if (IsKeyDown(VK_ESCAPE))
		{
			int res = subMenuExecute();			// вызываем меню
			if (res == SMI_EXIT) return FALSE;	// закрываем игру
			if (res == SMI_TO_MENU) return TRUE;// выходим в главное меню
		}

		// синхронизация игры
		if (GetTickCount() - last_time_updata >= GAME_TIME_REFRESH)
		{
			last_time_updata = GetTickCount(); // время последнего обновления
			
			GameUpdata(); // обновляем игру
			
			// проверяем количество жизней игрока
			if (player.lives <= 0)
			{
				GameOver();
				return TRUE;
			}
			
			// если нет призов нв карте, то переходим на следующий уровень 
			if (PrizeCount == 0)
				NextLevel();
		}
	}
}

// главный цикл
void MainLoop()
{
	scrClear();
	int res;

	do{
		res = menuExecute();
		if (res == MI_NEW_GAME)
		{
			NewGame();
			if (!Game()) return;
		}

	}while (res != MI_EXIT);
}

// вывод статуса игры
void statusDraw()
{
	int x = SCR_WIDTH - 2;
	int y = 5;

	int sz = (int)strlen(IntToStr(current_level));
	drawText(x - sz, y, IntToStr(current_level), COLOR_INFO_VALUE, DRAW_MODE_CH_COLOR); y += 2;
	sz = (int)strlen(IntToStr(player.score));
	drawText(x - sz, y, IntToStr(player.score), COLOR_INFO_VALUE, DRAW_MODE_CH_COLOR); y += 2;
	sz = (int)strlen(IntToStr(PrizeCount));
	drawText(x - sz, y, IntToStr(PrizeCount), COLOR_INFO_VALUE, DRAW_MODE_CH_COLOR); y += 2;
	sz = (int)strlen(IntToStr(player.lives));
	drawText(x - sz, y, IntToStr(player.lives), COLOR_INFO_VALUE, DRAW_MODE_CH_COLOR);
}

// вывод логотипа (PACMAN)
void LogoDraw(BOOL animation)
{	
	int p;	// позиция вывода
	int logoD;	// смешение

	DWORD logo_start_time = GetTickCount(); // используем для синхронизации анимации

	do{
		if (animation) // расчитываем смещение символов, исходи из прошедшего времени
			logoD = (int)((1-((float(GetTickCount() - logo_start_time)) / LOGO_ANIMATION_TIME)) * (SCR_WIDTH)); 
		else
			logoD = 0;

		scrClear(LOGO_COLOR_BG);
		if (logoD < 0)
			logoD = 0;

		// выводим большие буквы
		p = LOGO_POS_X;
		abcDraw(p + logoD, LOGO_POS_Y, abc_P, LOGO_FILL_CHAR, LOGO_COLOR_TEXT);	p = p + ABC_CHAR_WIDTH;
		abcDraw(p - logoD, LOGO_POS_Y, abc_A, LOGO_FILL_CHAR, LOGO_COLOR_TEXT); p = p + ABC_CHAR_WIDTH;
		abcDraw(p + logoD, LOGO_POS_Y, abc_C, LOGO_FILL_CHAR, LOGO_COLOR_TEXT);	p = p + ABC_CHAR_WIDTH;
		abcDraw(p - logoD, LOGO_POS_Y, abc_M, LOGO_FILL_CHAR, LOGO_COLOR_TEXT);	p = p + ABC_CHAR_WIDTH;
		abcDraw(p + logoD, LOGO_POS_Y, abc_A, LOGO_FILL_CHAR, LOGO_COLOR_TEXT);	p = p + ABC_CHAR_WIDTH;
		abcDraw(p - logoD, LOGO_POS_Y, abc_N, LOGO_FILL_CHAR, LOGO_COLOR_TEXT);

		// задаем цвет
		p = LOGO_POS_Y;
		drawLine(0, p, SCR_WIDTH, p, 0x04, " ", DRAW_MODE_TEXTCOLOR);p++;
		drawLine(0, p, SCR_WIDTH, p, 0x05, " ", DRAW_MODE_TEXTCOLOR);p++;
		drawLine(0, p, SCR_WIDTH, p, 0x07, " ", DRAW_MODE_TEXTCOLOR);p++;
		drawLine(0, p, SCR_WIDTH, p, 0x0F, " ", DRAW_MODE_TEXTCOLOR);p++;
		drawLine(0, p, SCR_WIDTH, p, 0x0F, " ", DRAW_MODE_TEXTCOLOR);p++;
		drawLine(0, p, SCR_WIDTH, p, 0x07, " ", DRAW_MODE_TEXTCOLOR);p++;
		drawLine(0, p, SCR_WIDTH, p, 0x03, " ", DRAW_MODE_TEXTCOLOR);p++;
		drawLine(0, p, SCR_WIDTH, p, 0x02, " ", DRAW_MODE_TEXTCOLOR);p++;

		if (animation)
			scrUpdata();
	}while (logoD > 0);

	// выводим рамку экрана
	drawRect(Rect(0,0, SCR_WIDTH, SCR_HEIGHT), 177, 0x00, DRAW_MODE_CH_COLOR); 
	drawRect(Rect(1,1, SCR_WIDTH-1, SCR_HEIGHT-1), 176, 0x00, DRAW_MODE_CH_COLOR);
	// авторское право
	drawText((SCR_WIDTH >> 1) - 20, SCR_HEIGHT - 3, "Copyright by U81, prog.81@mail.ru 01.2009", 0x17); 

	if (animation)
		scrUpdata();
}

// вызываем если игра окончена
void GameOver()
{
	// задаем параметры окна
	RECT r;
	int cx = SCR_WIDTH >> 1;
	int cy = SCR_HEIGHT >> 1;
	r.left = cx - 9;
	r.top  = cy - 3;
	r.right  = cx + 9;
	r.bottom = cy + 4;
	drawWindow(r, 0x4F); // выводим окно с сообщением
	drawText(cx - 6, cy, "Вы проиграли", 0x0F, DRAW_MODE_CH_COLOR);
	scrUpdata(); // отображаем на экране

	// ждем нажатия одной из указаных клавиш
	while (!IsKeyDown(VK_RETURN) && !IsKeyDown(VK_ESCAPE)) getch();
}

#endif /* GAME_H */