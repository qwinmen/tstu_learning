//                                                       ���⨭� 1
 #include <stdio.h>
 #include <stdlib.h>
 #include <ctype.h>
 #include <string.h>
 FILE *tmp; char ch;
 int p=0;
 char *s;
 char lexema[13][8]=
 {
   "REWRITE","PUT",      /*  �⠭����� �����䨪���� */
   "(",")",",",";",".",  /*  ����� �㭪��樨           */
   ":=",                 /*  ������                   */
   "^","*",              /*  ����樨                   */
   "'F.DAT'",            /*  ����⠭�                  */
   "F","K"               /*  �����䨪����             */
 };
 int get_token(void);
 int GetStr(int w);
 int main()
 {
  FILE *f; int i; char FileName[80];
  printf(" ������ ��� 䠩�� � ��室�� ⥪�⮬ > ");
  scanf("%s",&FileName);
  if((f=fopen(FileName,"rt"))==NULL)
  {
   printf(" �訡�� �� ����⨨ �⮣� 䠩��\n");
   return 0;
  }
  if((tmp=fopen("conv.$$$","w+t"))==NULL)
  {
   printf(" �訡�� �� ᮧ����� 䠩�� conv.$$$\n");
   fclose(f);
   return 0;
  }
  ch=fgetc(f);
  while(!feof(f))
  {
   if(ch!='\n'&&ch!=' ') putc(toupper(ch),tmp);
   ch=fgetc(f);
  }
  putc(' ',tmp);
  fclose(f); rewind(tmp);
  printf(" ������ ��� ������ 䠩�� > ");
  scanf("%s",&FileName);
  if((f=fopen(FileName,"w"))==NULL)
  {
   printf("%s%s%c"," �訡�� �� ᮧ����� 䠩�� ",FileName,'\n');
   fclose(tmp);
   return 0;
  }
  while(1)
  {
   i=get_token();
   if(!i) break;
   if(i==12||i==13) fprintf(f,"%s%d"," 12 ",i-11);
   else
   {
    fprintf(f,"%c%d",' ',i);
    if(i==6) fprintf(f,"%c",'\n');
    if(i==11) fprintf(f,"%s"," 1");
   }
  }
  fcloseall();
  return 0;
 }
/* ���뢠��� ���ᥬ� �� �室���� ��⮪� */
 int get_token()
 {
  int i,l,q=0;
  for(i=0;i<13;i++)
  {
   fseek(tmp,p,SEEK_SET);
   l= strlen(lexema[i]);
   if(GetStr(l))
    if(!strcmp(s,lexema[i]))
    {
     p+=l; q=i+1;
     break;
    }
   free(s);
  }
  if(i!=13) free(s);
  return q;
 }
/* �㭪�� �⠥� ��ப� �� 䠩�� */
 int GetStr(int w)
 {
  int i;
  s=(char *)calloc(w+1,sizeof(char));
  ch=fgetc(tmp);
  for(i=0;!feof(tmp)&&i<w;i++)
  {
   s[i]=ch;
   ch=fgetc(tmp);
  }
  s[i]='\0';
  if(feof(tmp)) return 0;
  return 1;
 }