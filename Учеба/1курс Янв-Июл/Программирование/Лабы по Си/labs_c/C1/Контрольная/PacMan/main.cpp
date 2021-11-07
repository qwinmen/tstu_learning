#include "common.h"

void main()
{
	// инициализируем
	if (!scrInic("PacMan"))
		printf("error: inic");

	// главное меню
	MainLoop();
}

