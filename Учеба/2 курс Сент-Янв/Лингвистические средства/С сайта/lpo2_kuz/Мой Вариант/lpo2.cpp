#include <stdio.h>
#include <string.h>
#include <conio.h>
int main()
{clrscr();
 int mass[80]={1,3,11,1,5,6,11,2,6,4,7,11,1,8,9,11,3,10,11,3,7,2,3,11,1,4},i=0,k=0,n=0,h=0,j=0,z=0;
 if(mass[10]==7 && mass[20]==7)
 {
  for(i=0;i<80;i++)
  {
   //Проверка на ReWrite
   if(mass[i]==1 && mass[i-1]!=11)
   {//Если найден то выводить его и искать параметры
    if(mass[i+1]==3 && mass[i+9]==4)
    {
     printf("REWRITE\n");
     for(k=i;k<i+10;k++)
     {
      if(mass[k]==11 && mass[k+1]==1 && mass[k+2]==5) z=1;
      if(mass[k]==11 && mass[k+1]==2) j=1;
      if(mass[k-1]==6 && mass[k+2]==6) h=1;
     }
    if(z==1 && j!=1) printf("Не найден второй параметр RewRite\n");
    if(z!=1 && j==1) printf("Не найден первый параметр RewRite\n");
    if(z!=1 && j!=1) printf("Нет ни одного параметра RewRite\n");
    if(h!=1) printf("Не хватает кавычек во втором параметре Rewrite\n");
    if(z==1 && j==1 && h==1) {printf("PARAM1 F\n");printf("PARAM2 'F.DAT'\n");}
    }else printf("Не хватает скобки\n");
   }
   //Конец проверки на ReWrite
   //Если найдено присваивание
   if(mass[i]==9)
   {//Производится поиск операции умножения
    z=0;j=0;
    if(mass[i-1]==8 && mass[i-2]==1 && mass[i-3]==11)
    {
     for(k=i;k<27;k++) if(mass[k]==10) break;
     if(mass[k-1]==3 && mass[k-2]==11) z=1;
     if(mass[k+1]==11 && mass[k+2]==3) j=1;
     if(z==1 && j!=1) printf("Не найден второй операнд умножения\n");
     if(z!=1 && j==1) printf("Не найден первый операнд умножения\n");
     if(z!=1 && j!=1) printf("Нет ни одного операнда при умножении\n");
     if(z==1 && j==1) {printf("* K K REZ1\n"); printf(":= REZ1 F^\n");}
    }else printf("Операция := ничему не соответствует\n");
   }
   //Поиск оператора PUT
   if(mass[i]==2 && mass[i-1]!=11)
   {//Найден-выводить и искать единственный параметр
    z=0;
    if(mass[i+1]==3 && mass[i+4]==4)
    {
     for(k=i;k<27;k++) if(mass[k]==11 && mass[k+1]==1) z=1;
     if(z!=1) printf("Неверный или отсутствующий идентификатор в операторе PUT\n");
     if(z==1) {printf("PUT\n");printf("PARAM F\n");}
    }else printf("Не хватает скобки\n");
   }
  }
 }else printf("В конце строки не хватает ;\n");
 getch();
 return 0;
}
