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
 if(f==NULL )//��������� ����
  	printf ("Can't find file '%s'\n",&s);//���� ��������
 else//������ �� �����
 {
  clrscr();//������ �����  
    for(;;)
   {
    if (feof(f))//������� ��������� �����
       {printf("\n");break;}
	   if(s=="\0")
	    printf("PROBEL");
    fscanf(f,"%s",name);//������ �������� �� �����
    printf("%s ",name);//������� �������� �� �����+������	  	
   }
 } 
 
 
 
}


int main(array<System::String ^> ^args)
{
    Console::WriteLine(L"Hello World");
    return 0;
}
