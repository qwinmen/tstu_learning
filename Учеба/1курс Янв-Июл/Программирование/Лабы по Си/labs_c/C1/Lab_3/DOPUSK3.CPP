#include <stdio.h>
#include <conio.h>

void print(char* str)
{
	while (*str)
	{
		putch(*str);
		str++;
	}
}

void main()
{
	clrscr();
	char str[1000];
	gets(str);
	print(str);
        getch();
}