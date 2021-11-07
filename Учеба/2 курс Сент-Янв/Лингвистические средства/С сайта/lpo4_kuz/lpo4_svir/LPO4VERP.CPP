#include<stdio.h>
#include<string.h>
#include<conio.h>
int hash (char *str,float razm)
 {int sum=0,j,hash;
 float y;
 for(j=0;str[j]!='\0';j++)  sum+=str[j];
 y=(float)sum/razm;
 hash=(y-(int)y)*10;
 return hash;
 }
struct desk
{char name[20];
 int chain;
 char tip[20];
 int hash;
 };

int main()
{char dt[]=" i:integer;\n file:text;\n sim:simbol;\n qwer:file of byte;\n";
 int i=0,j=0,sch=0,l=0,z=1,zhash;
 struct desk tabl[31];
 struct desk table;
 int hashh[10];
 clrscr();
 printf("ÚÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄ¿\n");
 printf(" âàë¢®ª ¯à®£à ¬¬ë:\n%s",dt);
 printf("ÀÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÙ\n");
 for(i=0;i<31;i++) tabl[i].chain=0;
 for(i=0;i<10;i++) hashh[i]=0; i=0;
 do
 { j=0; l=0;
  while(dt[i]!=':') {table.name[j]=dt[i]; i++; j++;} i++;
  table.name[j]='\0';
  j=0;
  while(dt[i]!=';') {table.tip[j]=dt[i]; i++; j++;}
  table.tip[j]='\0';
  zhash=hash(table.name,31);
  if (hashh[zhash]==0)
  {sch++;
   hashh[zhash]=sch;
   tabl[sch].hash=zhash;
   strcpy(tabl[sch].name,table.name);
   strcpy(tabl[sch].tip,table.tip);
   }
  else
  {j=hashh[zhash];
   do {if(strcmp(table.name,tabl[j].name)==0) l++; z=j; j=tabl[j].chain;} while(j!=0);
   if(l!=0) printf("\nè¨¡ª : ®¢â®à¥­¨¥ - %s - ¯ à ¬¥âà \n",table.name);
   else
   {sch++;
    tabl[sch].hash=zhash;
    tabl[z].chain=sch;
    strcpy(tabl[sch].name,table.name);
    strcpy(tabl[sch].tip,table.tip);
   }
  }
 i+=2; }while(dt[i]!='\0');
 printf("\n•¥è:");
 for(i=0;i<10;i++) printf("  %u",hashh[i]);
 for(i=1;i<=sch;i++) printf("\n%u\t%-2.5s\t%-10s\t–¥¯®çª =%u\t\t•¥è=%u",i,tabl[i].name,tabl[i].tip,tabl[i].chain,tabl[i].hash);
 return 0;}