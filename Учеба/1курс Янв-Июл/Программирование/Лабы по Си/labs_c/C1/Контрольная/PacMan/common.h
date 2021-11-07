#pragma once
#include <stdio.h>
#include <conio.h>
#include "draw.h"
#include "menu.h"
#include "abc.h"
#include "game.h"
#include "map.h"

//-------------------------------------------------------- панель информации
const BYTE COLOR_CONTROL_CHAR	= 0x16; // цвет клавиши управления
const BYTE COLOR_DIRECT_TEXT	= 0x12; // цвет текста направления
const BYTE COLOR_INFO_TEXT		= 0x17; // цвет текста информации
const BYTE COLOR_INFO_VALUE		= 0x1A; // цвет текста значения
//-------------------------------------------------------- карта
const BYTE MAP_SPACE_ATTR = 0x00; // цвет пустоты
const BYTE MAP_SPACE_CHAR = ' ';  // символ пустоты
const BYTE MAP_RECT_ATTR  = 52;	  // цвет границы
const BYTE MAP_RECT_CHAR  = 177;  // символ границы
//-------------------------------------------------------- дополнительное меню
const BYTE SUBMENU_COLOR_TEXT	  = 0x18; // цвет в обычном состоянии
const BYTE SUBMENU_COLOR_SELECTED = 0x1F; // цвет в выбранном состоянии
//-------------------------------------------------------- окно
const BYTE WINDOW_COLOR_BOUNDRECT = 0x1F; // цвет рамки
//-------------------------------------------------------- враг
const DWORD ENEMY_TIME_DIRECT_UPDATA = 500;	// время обновления направления
const DWORD ENEMY_ATTR_NORMAL		 = 0x04;// цвет в нормальном состоянии
const DWORD ENEMY_ATTR_PURSUIT		 = 0x0C;// цвет во время преследования
//-------------------------------------------------------- игра
const DWORD GAME_TIME_REFRESH = 80; // время обновления игры в мс
//-------------------------------------------------------- игрок
const DWORD PLAYER_TIME_FLASH  = 5000;// время мегания игрока при потере жизни (мс)
const int PLAYER_MAX_ADD_SCORE = 10;  // максимальное число очков за приз
const int PLAYER_START_LIVES   = 5;   // количество жизней в начале игры
//-------------------------------------------------------- разное
const int MIN_DISTANCE_SQUARE_PL_VS_EN	= 20*20; // минимальное растояние (в степени 2) между персонажем и врагом
//--------------------------------------------------------


BOOL IsKeyDown(int VK); // проверяет нажата ли клавиша
int Distance_square(int x1, int y1, int x2, int y2); // квадрат растояния между точками [x1,y1] и [x2,y2]
char* IntToStr(int d); // конвертирует число в строку и возвражает указатель на результат