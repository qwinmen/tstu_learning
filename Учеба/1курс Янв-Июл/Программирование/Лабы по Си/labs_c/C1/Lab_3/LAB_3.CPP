#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <ctype.h>

void correct_text(char* s)
{
	do{
		while (*s != 0 && (*s == '\n' || *s == '\t' || *s == ' ')) s++;
		*s = toupper(*s);
		s = strchr(s, '.');
	}while (s++);
}

void main()
{
	clrscr();
	const int MAXSIZE = 1024;
	char str[MAXSIZE];
	printf("input text\n\n");
	gets(str);

	correct_text(str);

	printf("%s", str);
	getch();
}