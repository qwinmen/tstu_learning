//LPO_Lab_1_var-18
#include<stdio.h>
#include<conio.h>
#include<malloc.h>
FILE *f, *ff;
void main(){
	int i=0,j=0, zz=0, k;
	char* str;
	f=fopen("111.txt","r");
	ff=fopen("222.txt","w");
	while(!feof(f))
	{
		fgetc(f);
		i++;
	}
	str=(char*)malloc(i*sizeof(char));
	rewind(f);
	do{
		str[j]=fgetc(f);
		j++;
	}
	while(!feof(f));
	for(k=0;k<i;k++)
	{
		switch(str[k])
		{
		case'R':
			if(str[k+1]=='E')
			{
				printf("1 ");
				fputs("1 ",ff);
				k=k+3;
			}
			break;
		case':':
			if(str[k+1]=='=')
			{
				printf("2 ");
				fputs("2 ",ff);
				k=k+2;
			}
			break;
/*		case ':':
		{
				printf("58 ");
				fputs("58 ",ff);
				k++;
		}
		break;*/
		case'+':
			printf("3 ");
			fputs("3 ",ff);
			break;
		case'(':
			printf("4 ");
			fputs("4 ",ff);
			break;
		case')':
			printf("5 ");
			fputs("5 ",ff);
			break;
		case',':
			printf("6 ");
			fputs("6 ",ff);
			break;
		case';':
			printf("7 ");
			fputs("7 ",ff);
			break;
		case'*':
			printf("8 ");
			fputs("8 ",ff);
			break;
		case'/':
			printf("9 ");
			fputs("9 ",ff);
			break;
		case'.':
			if(str[k-1]=='3')
			{
				printf("11 1 ");
				fputs("11 1 ",ff);
				k=k+2;
			}
			break;
		case'3':
			if(str[k+1]!='.')
			{
				printf("11 2 ");
				fputs("11 2 ",ff);
				k++;
			}
			break;
		//_______________________//

		case'H':
			{
			 printf("10 1 ");
			 fputs("10 1 ",ff);
			 k++;
			}
			break;
					case'B':
			{
			 printf("10 2 ");
			 fputs("10 2 ",ff);
			 k++;
			}
			break;
					case'M':
			{
			 printf("10 3 ");
			 fputs("10 3 ",ff);
			 k++;
			}
			break;
					case'V':
			{
			 printf("10 4 ");
			 fputs("10 4 ",ff);
			 k++;
			}
			break;
					case'P':
					if(str[k+1]=='I')
			{
			 printf("10 5 ");
			 fputs("10 5 ",ff);
			 k=k+2;

			}
			break;

			default:
			if((int)str[k]==10)
			{
			 printf("\n");
			 fputs("\n",ff);
//			 k++;

			}
//			break;






		}

	}
	getch();

}

