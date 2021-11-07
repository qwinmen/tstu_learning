//Лаба по Програмированию
//ВАР-20_Треба написать мини Текстовый редактор с
//возможностью шифровки квадратами
# include <conio.h>//clrscr()//textcolor()
# include <stdio.h>//work for File
# include <stdlib.h>//atoi()
# include <string.h>	# include <windows.h>
# include <cstdlib>	  //# include <iostream>
# define LINESIZE 20
FILE *f,*ff;
//# define ESC 27
 /*/операциa взятия адреса (&)
  //что бы определить размер структуры можно использовать операцию sizeof()
  //strlen("привет") выведет число 6
  //fgets() чтение строки из файла
  //fputs() запись строки в файл*/
unsigned const n=8;			  //struct sType{char *arr[32];};
struct matrix{char *arr[8];};//struct matrix{sType;};
struct matrix mask={"x...x...",".x...x..","..x...x.","...x...x",
					"..x...x.","...x....","x...x..x","..x..x.."};
/*struct netTrevel{char name[20];}brom;//или 'struct netTrevel brom[10]'
struct netTrevel brom={"Kapec!\n"};*/
int _s,q;
int replace( _s, q)
{//Переворот букв КИРИЛИЦА:
		  //(_s>='А')&&(_s<='Я')//Разница=31+Ё
   if ((q)&&(_s>=192)&&(_s<=223)) _s=_s+32;
		  //(_s=='Ё') _s='ё';
   if ((q)&&(_s==168)) _s=184;
		  // (_s>='а')&&(_s<='я')//Разница=31+ё
   if ((!q)&&(_s>=224)&&(_s<=255)) _s=_s-32;
		  // (_s=='ё') _s='Ё';
   if ((!q)&&(_s==184)) _s=168;
 //Переворот букв English:
		  //(_s>='А')&&(_s<='Z')//Разница=25+@$%^&
   if ((q)&&(_s>=65)&&(_s<=90)) _s=_s+32;
		  // (_s>='a')&&(_s<='z')//Разница=25+[`@!
   if ((!q)&&(_s>=97)&&(_s<=122)) _s=_s-32;
   return _s;
}    char s[255];unsigned char sa;int k0=1;//=true;
							   int point=0;//=false;
void editor()
{
	ff=fopen("output","w");//g
	f=fopen (&s,"r");//Открытие потока
	while(!feof(f))
	{	fscanf(f,"%c", &sa);//Отсюда берем
		sa=replace(sa, 1);
		if ((sa!=32)&&(k0)){  sa=replace(sa, 0); k0=0;	 }//32-Пробел
		if ((sa==46)) {point=1; }//46-Точка
		if ((sa!=32)&&(sa!=46)&&(sa!=10)&&(point==1)){sa=replace(sa, 0); point=0;}
		fprintf(ff,"%c",sa);//Сюда вставляем
	}fclose(ff);
}

int i,ch, tmp, menuKey=0;
char s1[255];	char name[15];	char line[LINESIZE] = "";
CreateNewFile()
{
  printf("Create NEW file: \nC://Borland/BORLANDC/BIN/");
  scanf("%s",&s);
  f=fopen (s,"wb");//Открытие потока
  clrscr();
/*Пишим строки с клавы в файл*/
	if(!ch)
	{tmp=0;//Обнуляем!
	 for(;;)//27-Esc
	 {
		//scanf("%s",s1);//Читаем ввод с клавы
		tmp=getche();//Считка посимволу с клавы и отображение на экране
		fprintf(f,"%c",tmp);//Пишим в файл
		if(tmp==13){printf("\n");fprintf(f,"\n");}//Сами делаем перевод строки
		/*fprintf(f,"%s",s1);//fprintf(f,"\n");
		//key=getc(f);
		//CharToOem(s1,s1);//OemToCharA(s1,s1);
		//fputs(s1,f);//putc(s1,f);//Пишим в файл
	  //	tmp=getche();//Ловит 27
		//if(key==13) {printf("\r");fputs("\n",f);fprintf(f,"\n");}*/
		if(tmp==27) break;//Exit
	 }clrscr();printf("Zapisano v fail '%s'\n",&s);
	}
/*---------------------------*/
/*
if (fgets(line, LINESIZE, stdin) == NULL)
//{
 printf("Err");/* Произошла ошибка или был прочитан EOF */
//}
	//    else
		//{
				/* Удаляем символ конца строки */
	  //          size_t last = strlen(line) - 1;
		  //      if (line[last] == '\n')
			//        line[last] = '\0';
				/* Здесь можно проанализировать строку */
	//    }
/*char *sdf="HelBoy";
  fputs(sdf,f);
 */
 //fwrite(&str, sizeof(255), 1, f);//Сохранить

 /*char *buf;
setbuf(f, buf);
 char* bufb, char* bufe;//Начало и Конец буфера
 char* gapb, char* gape;//Cвободное пространство в буфере
if( gapb==bufb && gape==bufe)
if(key)
   *gapb++=key;
if(key==backspace)
   gapb--;
if(key==keyleft)
   *--gape=*--gapb;
if(key==keyright)
   *gapb++ = *gape++;*/
 fclose(f);//Закрываем поток
}
int key,YN;
_OpenFile()
{
 printf("Open File: \nC://Borland/BORLANDC/BIN/");
 scanf("%s",&s);
 f=fopen (s,"rt"); //otkruvaem fail dla chtenua
 if(f==NULL )//Открываем файл
	printf ("Can't find file '%s'\n",&s);//Файл несоздан
 else//Читаем из файла
 {
  key=0;clrscr();//Чистим экран
	for(;;)
   {
	if (feof(f)){printf("\n");break;}//Условие окончания файла
	//fscanf(f,"%s",name);//Читает порциями по слову
	key=fgetc(f);//Читаем из файла по символу
	//if(key==13)printf("\n");else printf("%c",key);//Выводим порциями по слову+пробел
	switch(key){	case 10: printf("\n");break;//printf("|ABZAC-->|")
					//case 46: printf("|TOCHKA|");
					//		 strupr("97");//key=fgetc(f);
					//		 break;
						}printf("%c",key);//Вывод текста из *f
	//gets(name);//Ввод текста с пробелом и энтером, а вот как сохранить?
   }printf("Obrabotat' tekst?\t[Y]	[N]\n");scanf("%s",&YN);
	switch(YN){  case 110: gotoxy(36,35);printf("<--\n");gotoxy(0,60);break;//n
				 case 121: gotoxy(22,35);printf("-->\n");gotoxy(0,60);//y
						   editor();
				 break;}
 }
}


main()
{
do
{
 printf("1:Create New File\n2:Open File\n3:Exit\n");
 scanf("%d",&menuKey);
 switch(menuKey)
 {
 case 1:{ clrscr();CreateNewFile();break;}
 case 2:{ clrscr();_OpenFile();break;}
 }
}while( menuKey!=3 );
 fclose(f);//Закрытие потока
}








