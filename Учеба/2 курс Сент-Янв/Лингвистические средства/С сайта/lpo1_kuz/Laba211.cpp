#include <stdio.h>
#include <string.h>
#include <ctype.h>
char strfunct(int one, int two,char str[80])
{
 char str1[80];
 int h=0,j=0;
 if(one==two) return 11;
 for(h=0;h<80;h++) str1[h]='\0';
 for(h=one;h<two;h++) str1[j++]=str[h];
 if(strcmp(str1,"rewrite")==0) return 1;
 if(strcmp(str1, "put")==0) return 2;
 if(strcmp(str1, "f")==0) return 12;
 if(strcmp(str1, "f.dat")==0) return 13;
 if(strcmp(str1, "k")==0) return 14;
 return 11;
}
int main()
{
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
  if(str[i]=='(') mass[z++]=3;
  if(str[i]==')') mass[z++]=4;
  if(str[i]==',') mass[z++]=5;
  if(str[i]==39)  mass[z++]=6;
  if(str[i]==';') mass[z++]=7;
  if(str[i]=='^') mass[z++]=8;
  if(str[i]==':' && str[i+1]=='=') {mass[z++]=9; i=i+2;}
  if(str[i]=='*') mass[z++]=10;
  if(isalpha(str[i])!=0)
  {
   for(k=i;k<strlen(str);k++) if(isalpha(str[k])==0 && str[k]!='.') break;
   for(m=i;m<k;m++) str[m]=tolower(str[m]);
   l=strfunct(i,k,str);
   if(l==1 || l==2) mass[z++]=strfunct(i,k,str);
   if(l>11)
   {
    mass[z++]=11;
    mass[z++]=strfunct(i,k,str)-11;
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
gets("");
return 0;
}



