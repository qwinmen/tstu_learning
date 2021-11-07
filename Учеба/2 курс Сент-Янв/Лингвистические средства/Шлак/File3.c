#include <stdio.h>
#include <stdlib.h>
//LPO-lab_2
int main()
{
   FILE *f=fopen("input.txt", "r");
   int i, j, k,l,h;
   char *str;
   fseek(f,1,SEEK_END);
   int n = ftell (f);
   n=n-1;
   //printf("%d", n);
   rewind(f);
   str=(char*)malloc(n*sizeof(char));
   for (i=0; i<n; i++)
   {
      fscanf(f, "%c", &str[i]);
      if(str[i]=='\n') n--;
   }
   for (i=0; i<n; i++)
   {
       if(str[i]=='M')
       {
        printf("9 1 "); i=i+3;
       }
       if(str[i]=='=')
        printf("4 ");
       if(str[i]=='0')
        printf("10 0 ");
       if(str[i]=='i')
       {
         printf("1 "); i=i+2;
       }
       if(str[i]=='(')
        printf("5 ");
       if(str[i]==')')
        printf("6 ");
       if(str[i]=='X')
        printf("9 2 ");
       if(str[i]=='.')
        printf("7 ");
       if(str[i]=='G')
       {
        printf("2 "); i=i+1;
       }
       if(str[i]=='T' && str[i+1]=='Y')
       {
          printf("3 "); i=i+4;
       }

       if(str[i]=='*')
        {printf("8 "); i=i+1;
        }
   }
    return 0;
}

