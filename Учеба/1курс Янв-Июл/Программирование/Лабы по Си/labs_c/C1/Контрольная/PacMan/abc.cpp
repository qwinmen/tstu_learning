#ifndef ABC_H
#define ABC_H
#include "abc.h"

/*---------------------------------------------*/
// информация о символах
const BYTE abcCharData[abc_COUNT][8] = {
	{135,179,177,177,129,177,177,177}, // A
	{195,177,241,241,241,241,177,195}, // C
	{193,177,177,177,193,241,241,241}, // P
	{184,144,168,184,184,184,184,184}, // M
	{184,176,176,168,168,152,152,184}, // N
	// добавлять в конец
	}; 
/*---------------------------------------------*/

void abcDraw(int x, int y, abcID id, BYTE ch, BYTE attr, int Mode)
{
	for (int row = 0; row < 8; row++)
	{
		byte b = abcCharData[id][row];
	for (int col = 0; col < 8; col++)
	{
		if ((b & (1 << col)) == 0)
			drawChar(x+col, y+row, ch, attr, Mode);
	}}
}


#endif /* ABC_H */