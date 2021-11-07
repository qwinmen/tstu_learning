#include <stdio.h>
#include <string.h>
#include <ctype.h>
#include <conio.h>
struct info
{
 char id[80];
 char type[20];
 int chain;
 int number;
 int error;
};
char hash(char str[80])
{
 int h=0,j=0;
 for(j=0;j<strlen(str);j++) h=h+(int)str[j];
 return h%6;
}
int main()
{clrscr();
 FILE *fp,*fn;
 char str[80],name[80][80],str2[80],hashmass[80];
 struct info insert[80];
 int i=0,j=0,z=0,k=0,m=0,ident=0,l=0;
 for(i=0;i<80;i++)
 {
   insert[i].number=i;
   hashmass[i]=0;
   insert[i].chain=0;
   insert[i].error=0;
   str2[i]='\0';
   str[i]='\0';
   for(j=0;j<80;j++)
   {
    insert[i].type[j]='\0';
    insert[i].id[j]='\0';
   }
  }
 j=1;
 for(m=j;m<80;m++) insert[m].number=m;
 if ((fp=fopen("fine.txt","rt"))==NULL)
  {
   printf("Error open file. \n");
   return 1;
  }
 j=0;
 while(!feof(fp))
 {
  fgets(str,79,fp);
  for(i=0;i<strlen(str);i++)
  {
   if(str[i]==':')
   {
    for(k=0;k<80;k++) str2[k]='\0';
    for(k=i+1;k<strlen(str)-1;k++) if(str[k]!=';') str2[j++]=str[k];
    strcpy(insert[z].type,str2);
    j=0;
    for(k=0;k<80;k++) str2[k]='\0';
    for(k=0;k<i;k++) str2[k]=str[k];
    strcpy(insert[z].id,str2);
    z++;
   }
  }
  l=hash(str2);
  for(k=0;k<z-1;k++)
  {
   if(l==hash(insert[k].id))
   {
    if(strcmp(insert[k].id,insert[z-1].id)==0) { printf("Error!!! Identificator '%s' uge obyavlen",insert[z-1].id);return 0;}
    if(insert[k].chain==0) {insert[k].chain=z-1; break;} else k=insert[k].chain-1;
   }
  }
 }
for(i=0;i<z;i++) printf("#%d ID=%s, Type=%s, Hash=%d, Chain=%d\n",insert[i].number,insert[i].id,insert[i].type,hash(insert[i].id),insert[i].chain);
fclose(fp);
printf("\nPress Enter to Exit");
gets("");
return 0;
}



