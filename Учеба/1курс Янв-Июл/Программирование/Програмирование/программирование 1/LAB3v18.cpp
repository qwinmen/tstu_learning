#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

   FILE *file, *temp;
   int t, i, j, f ;
   const int n=10;
   long total=0, Temp=0;
   char FileName1[80], FileName2[80], t1[80], t2[80], a[n];
   void Search(void);
   void Coding(void);

main()
{
   clrscr();
   printf("\nEnter a full name of an initial file:  ");
   gets(FileName1);
   printf("\nEnter a name of a file: ");
   gets(FileName2);
   file = fopen(FileName1, "r");
   temp = fopen(FileName2, "w");
   if(file==NULL) {printf("\nThe file is not found!?!\n"); while(!kbhit()); exit(1);}
   Search();
   while(!kbhit());
   Coding();                          
   fclose(file);
   fclose(temp);
   while(!kbhit());
return 0;
}
//******************************************************************************
void Search(void)
{
   do
   {
     f=fgetc(file);
     for(i=0;(f!=EOF)&&(f!=32); i++)
     {
        t1[i]=f;
        f=fgetc(file);
     }
     total=0;
     for(j=0; j<i; j++)
     {
        if(!((t1[j]>=48)&&(t1[j]<=57))) {total=0; break;}
        total+=t1[j];
     }
     if(total>Temp)
     {
         Temp=total;
         t=i;
         for(j=0; j<i; j++)
            t2[j]=t1[j];
     }
   }
   while(f!=EOF);
   printf("\nIn a file the number with the maximal sum \nof figures which is numerically equal is found... ");
   for(j=0; j<t; j++)
       printf("%c", t2[j]);
}
//******************************************************************************
void Coding(void)
{
   rewind(file);
   do
   {
     for(i=0; i<n; i++)
     {
       f=fgetc(file);
       if(f==EOF)break;
       a[i]=f;
     }
     for(i=0; i<n; i++)
     {
       if(i>=n/2)
       {
         t=a[i];
         a[i]=a[n-i-1];
         a[n-i-1]=t;
       }
         else
         {
           t=a[i];
           a[i]=a[i+i];
           a[i+i]=t;
         }
     }
     for(i=0; i<n; i++)
        fputc(a[i], temp);
   }
   while(f!=EOF);
}
//******************************************************************************

