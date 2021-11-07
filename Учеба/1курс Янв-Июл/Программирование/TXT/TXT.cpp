// TXT.cpp : main project file.

# include <stdio.h>//work for File
# include <string.h>
# include <conio.h>//clrscr()
# include <stdlib.h>//atoi()
# include "stdafx.h"//atoi()
using namespace System;

OpenFile()
{   
printf("Open File: \nC://Borland/BORLANDC/BIN/");
 scanf("%s",&s);
 f=fopen (s,"rt"); //otkruvaem fail dla chtenua
 if(f==NULL )//Открываем файл
  	printf ("Can't find file '%s'\n",&s);//Файл несоздан
 else//Читаем из файла
 {
  clrscr();//Чистим экран  
    for(;;)
   {
    if (feof(f))//Условие окончания файла
       {printf("\n");break;}
	   if(s=="\0")
	    printf("PROBEL");
    fscanf(f,"%s",name);//Читает порциями по слову
    printf("%s ",name);//Выводим порциями по слову+пробел	  	
   }
 } 
 
 
 
}


int main(array<System::String ^> ^args)
{
    Console::WriteLine(L"Hello World");
    return 0;
}
