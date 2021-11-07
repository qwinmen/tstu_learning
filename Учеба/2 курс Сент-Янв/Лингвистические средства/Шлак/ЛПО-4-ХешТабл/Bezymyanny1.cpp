#include<stdio.h>
#include<stdlib.h>
#include<malloc.h>
#include<string.h>
#include<conio.h>

struct symbols_table
{
	char symbol;
	char type[10];
	int chain;
};

int hash_func(char symbol)
{
	int hashfunc=symbol;
	hashfunc=(hashfunc)%10;
	return hashfunc;
}

void print(struct symbols_table* tab, int* hash_table)
{
    int i;
	printf("Hash table:    |             Symbols table:\n");
	for(i=0; i<10; i++)
	printf("    %d         |      %c           %s  %d \n",hash_table[i], tab[i].symbol, tab[i].type, tab[i].chain);

}

main()
{
	FILE *f;
	int i, j, k, n=1, p1, p2, hash_table[10], ptr=0;
	char c;
	struct symbols_table tab[10];

	f=fopen("OUT.txt", "r");
	if(f!=NULL)
	{
		for(i=0; i<10; i++)
		{
			hash_table[i]=0;
			tab[i].symbol=' ';
			strcpy(tab[i].type, "          ");
			tab[i].chain=-1;
		}
		while((c=fgetc(f))!=EOF)
		{
			p1=hash_func(c);
			p2=hash_table[p1];
			if(p2==0)
			{
				ptr++;
				hash_table[p1]=ptr;
				tab[ptr-1].symbol=c;
				j=0;
				c=fgetc(f);
				while((c=fgetc(f))!='\n')
                {
					tab[ptr-1].type[j]=c;
                    j++;
                }
				tab[ptr-1].chain=0;
			}
            else
            {
				if(tab[p2-1].symbol==c)
                {
					printf("ERROR! Repeated symbol! %c\n", c);
					getch();
                    return 0;
                }
                do
                {
					   p1=p2;
					   p2=tab[p2-1].chain;
				}
				while(p2!=0);
				ptr++;
				tab[p1-1].chain=ptr;
				tab[ptr-1].symbol=c;
				j=0;
				c=fgetc(f);
				while((c=fgetc(f))!='\n')
				{
					tab[ptr-1].type[j]=c;
					j++;
				}
				tab[ptr-1].chain=0;
			}
		}

	}
	else printf("File not found!");
	print(tab, hash_table);
	fclose(f);
	getch();
	return 0;
}

