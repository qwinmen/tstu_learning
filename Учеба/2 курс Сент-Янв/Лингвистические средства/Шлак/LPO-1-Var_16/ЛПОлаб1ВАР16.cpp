//LPO Lab_1 Var-16
#include <stdio.h>
#include <conio.h>
#include <malloc.h>
FILE *f, *ff;
void main()
{
	int i=0, j=0;
	f=fopen("LPO_1_V-16 IN.txt","r");
	ff=fopen("LPO_1_V-16 OUT.txt","w");
	while(!feof(f))
	{
		fgetc(f);
		i++;
	}
	char* str=(char*)malloc(i*sizeof(char));
	rewind(f);
	do{
		str[j]=fgetc(f);
		j++;
	}while(!feof(f));

	for(int k=0; k<i; k++)
	{
		switch(str[k])
		{
		case 'R'://���� READ
			if(str[k+1]=='e')
			{
			printf("1 ");
			fputs("1 ",ff);
			k=k+4;
			}
			break;
		case '(':
			printf("2 ");
			fputs("2 ",ff);
			break;
		case ')':
			printf("3 ");
			fputs("3 ",ff);
			break;
		case ';':
			printf("4 ");
			fputs("4 ",ff);
			break;

//���� ���� ���� �������, �� �� ������� �� ����� ������ "��� � �����"
/*		case ':':
			if(str[k+1]=='=')
			{
				printf("5 ");
				fputs("5 ",ff);
			}
			break;
*/
		case '/':
			printf("6 ");
			fputs("6 ",ff);
			break;
		case 'i'://���� IF
			if(str[k+1]=='f')
			{
				printf("7 ");
				fputs("7 ",ff);
				k++;
			}
			break;
		case 'f':
			printf("8 ");
			fputs("8 ",ff);
			break;
/* ��� � �����:
 * ���� '=', ���� �������, �� ������� �� ���� �������
 * ����� � ������� ':', ���� ���� - �� ��� ������ ':='
 * ����� ������ ������ '=' � ���.
 */
		case '=':
			if(str[k-1]==':')
			{// :=
				printf("5 ");
				fputs("5 ", ff);
			}
			else
			{// =
				printf("9 ");
				fputs("9 ",ff);
			}
			break;
		case 't'://���� THEN
			if(str[k+1]=='h')
			{
				printf("10 ");
				fputs("10 ",ff);
				k=k+4;
			}
			break;
		case 'w'://���� WriteLn
			if (str[k+1]== 'r')
			{
				printf("11 ");
				fputs("11 ",ff);
				k=k+7;
			}
				break;
		case '+':
			printf("12  ");
			fputs("12 ",ff);
			break;
		case 'e'://���� ELSE
			if(str[k+1]=='l')
			 {
				printf("13  ");
				fputs("13 ",ff);
				k=k+4;
			 }
			break;
		case 'm':
			printf("14-1 ");
			fputs("14-1 ",ff);
			break;
		case 'n':
			printf("14-2 ");
			fputs("14-2 ",ff);
			break;
		case '0':
			printf("15-1 ");
			fputs("15-1 ",ff);
			break;
		case '1':
			printf("15-2 ");
			fputs("15-2 ",ff);
			break;
		case '\n':
			printf("\n");
			fputs("\n",ff);
	}//end switch()

   }//end for()

   fclose(f); fclose(ff);
   getch();
}


/*
 * 	��� ������ ���� � ����� ������ ���������:
 *  1 2 14-1 3 4
 *  14-1 5 15-1 4
 *  	7 8 9 15-2 10 11 2 14-1 3
 *  	13 14-1 5 14-1 12 15-2 6 14-2
 */

 /*qwinmen*/
