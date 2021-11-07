//LPO-Lab-2_var-16:
	//Read (N)
	//M:=0;
	//if f=1 Then write ln(M)
	//else M:=M+1/n
#include<stdio.h>
#include<conio.h>
#include<string.h>
#include<stdlib.h>
char str[255],s[255];
int len,l,i,leks_find;
const N=20;
char *leksems[]={"Read","m:=o;","if f=1then write ln(m)","else m:=m+1/n", //0-3
           ">",":=","+",";","-","*","/","(",")","T","EPS","K","SX","S","2","1","\n"}; //4-20
int find(char *s,char **leksems)
{
  int num=-1;
  for(i=0;i<=N;i++)
  {
    if(strcmp(leksems[i],s)==0)
    {
      num=i;
      break;
    }
  }
return num;
}
void del(char *str,int l)
{
  int i;
  int len;
  len=strlen(str);
  for(i=l;i<len;i++) str[i-l]=str[i];
  str[len-l]='\0';
}
int main()
{
  //clrscr();
  FILE *in,*out;
  if ((in=fopen("first.txt","r+t"))==0)
  {
    printf("Error to open file first.txt\n");
    getch();
    return 1;
  }
  if ((out=fopen("out.txt","w+t"))==0)
  {
    printf("Error to open file out.txt\n");
    getch();
    return 1;
  }
  getch();

  printf("File in.txt:\n\n");
  while(feof(in)==0)
  {
    fgets(str,255,in);
    printf("%s",str);
    while(strlen(str)>0)
    {
      len=strlen(str);
      l=len;
      do
      {
		  strcpy(s,str);
		  s[l]='\0';
		  leks_find=find(s,leksems);
		  l--;
      }
	  while((leks_find<0) && (l>0));
      if(leks_find<0)
      {
		  if(str[0]!=' ')
		  fputs(" ",out);
		  del(str,1);
      }
      else
      {
	 if(leks_find==20) fputs("\n",out);
     else
     {
       if((leks_find>=18) && (leks_find<=19))
       {
         fputs("14 ",out);
         leks_find=leks_find-17;
       }
       if(leks_find>=13 && (leks_find<=17))
       {
         fputs("13 ",out);
	 leks_find=leks_find-12;
       }
       fputs(itoa(leks_find,s,10),out);
       fputs(" ",out);
     }
     del(str,l+1);
      }
    }
  }
  fclose(in);
  rewind(out);
  printf("\n\nFile out.txt\n");
  while(!feof(out))
  {
	fgets(str,255,out);
    printf("%s",str);
  }
  getch();
  return 0;
}

