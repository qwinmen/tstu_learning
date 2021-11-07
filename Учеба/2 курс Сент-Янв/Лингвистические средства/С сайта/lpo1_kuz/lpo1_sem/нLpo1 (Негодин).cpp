#include <stdio.h>
#include <string.h>
#include <ctype.h>
#include <conio.h>
char strfunct(int one, int two,char str[80])
{
 char str1[80];
 int h=0,j=0;
 if(one==two) return 11;
 for(h=0;h<80;h++) str1[h]='\0';
 for(h=one;h<two;h++) str1[j++]=str[h];
 if(strcmp(str1,"read")==0) return 1;
 if(strcmp(str1, "h")==0) return 9;
 if(strcmp(str1, "b")==0) return 8;
 if(strcmp(str1, "m")==0) return 7;
 if(strcmp(str1, "pi")==0) return 6;
 if(strcmp(str1, "v")==0) return 5;
}
int main()
{clrscr();
 FILE *fp,*fn;
 char str[80],mass[80],str2[80];
 int i=0,z=0,k=0,m=0,ident=0,l=0;
 for(i=0;i<80;i++) mass[i]=0;
 for(i=0;i<80;i++) str[i]='\0';
 if ((fp=fopen("test","r"))==NULL)
  {
   printf("Error open file. \n");
   return 1;

  }
 while(!feof(fp))
 {fgets(str,79,fp);
 for(i=0;i<strlen(str);i++)
 {
  if(str[i]=='(') mass[z++]=2;
  if(str[i]==')') mass[z++]=3;
  if(str[i]==',') mass[z++]=4;
  if(str[i]==';') mass[z++]=5;
  if(str[i]==':' && str[i+1]=='=') {mass[z++]=6; i=i+2;}
  if(str[i]=='3' && str[i+1]=='.' && str[i+2]=='1' && str[i+3]=='4') {mass[z++]=11;mass[z++]=1; i=i+3;}
  if(str[i]=='3' && str[i+1]!='.') {mass[z++]=11;mass[z++]=2;}
  if(str[i]=='*') mass[z++]=7;
  if(str[i]=='+') mass[z++]=8;
  if(str[i]=='/') mass[z++]=9;
  if(isalpha(str[i])!=0)
  {
   for(k=i;k<strlen(str);k++) if(isalpha(str[k])==0 && str[k]!='.') break;
   for(m=i;m<k;m++) str[m]=tolower(str[m]);
   l=strfunct(i,k,str);
   if(l==1) mass[z++]=1;
   else
   {
     mass[z++]=10;
     mass[z++]=10-strfunct(i,k,str);
   }
   i=k-1;
  }
 }
for(i=0;i<80;i++) if(mass[i]!=0) printf("%d ",mass[i]);
printf("\n");
for(m=0;m<80;m++) mass[m]=0;
for(m=0;m<80;m++) str[m]='\0';
}
fclose(fp);
printf("Press Enter to Exit");
getch();
return 0;
}