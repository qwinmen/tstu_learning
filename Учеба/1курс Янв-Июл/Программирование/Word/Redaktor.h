//---------------------------------------------------------------------------
#include <stdio.h>
#pragma hdrstop
#include <tchar.h>
//---------------------------------------------------------------------------
# include <stdio.h>//work for File
# include <string.h>
# include <conio.h>//clrscr()
# include <stdlib.h>//atoi()
# include <windows.h>

# define LINESIZE 20

#pragma argsused
FILE *f,*ff;
char s[255],s1[255],s2[255],smax[255], name[15], line[LINESIZE] = "";
int i,ii,n,k,l,lmax=0, menuKey=0;
_CreateNewFile()
{
  //strlen("������") ������� ����� 6
  //fgets() ������ ������ �� �����
  //fputs() ������ ������ � ����
  printf("Create NEW file: \nC://Borland/BORLANDC/BIN/");
  scanf("%s",&s);
  f=fopen (s,"wb");//�������� ������
  clrscr();
   for(;getchar()!='`';)
   {
	//fscanf(f,"%s",s1);
	gets(s1);//��������� �������
	fputs(s1,f);//����� � �����
   }
/*---------------------------*/
//char line[LINESIZE]="";
//if (fgets(line, LINESIZE, stdin) == NULL)
//{
// printf("Err");/* ��������� ������ ��� ��� �������� EOF */
//}
//		else
//		{
				/* ������� ������ ����� ������ */
				//size_t last = strlen(line) - 1;
				//if (line[last] == '\n')
				 //	line[last] = '\0';
				/* ����� ����� ���������������� ������ */
//		}
/*char *sdf="HelBoy";
  fputs(sdf,f);
 */
 //fwrite(&str, sizeof(255), 1, f);//���������

 /*char *buf;
setbuf(f, buf);
 char* bufb, char* bufe;//������ � ����� ������
 char* gapb, char* gape;//C�������� ������������ � ������
if( gapb==bufb && gape==bufe)
if(key)
   *gapb++=key;
if(key==backspace)
   gapb--;
if(key==keyleft)
   *--gape=*--gapb;
if(key==keyright)
   *gapb++ = *gape++;*/
 fclose(f);//��������� ����� ��� ���������� �����
}
_OpenFile()
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
		fscanf(f,"%s",name);//������ �������� �� �����
	  //getline();
	  //gets(name);
   //printf(name);
	  printf("%s ",&name);//������� �������� �� �����+������
	}
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
	case 1:{ clrscr();_CreateNewFile();break;}
	case 2:{ clrscr();_OpenFile();break;}

   }
 }while( menuKey!=3 );


 fclose(f);//�������� ������
}
//---------------------------------------------------------------------------
