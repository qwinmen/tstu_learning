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
   //�஢�ઠ �� ReWrite
   if(mass[i]==1 && mass[i-1]!=11)
   {//�᫨ ������ � �뢮���� ��� � �᪠�� ��ࠬ����
    if(mass[i+1]==3 && mass[i+9]==4)
    {
     printf("REWRITE\n");
     for(k=i;k<i+10;k++)
     {
      if(mass[k]==11 && mass[k+1]==1 && mass[k+2]==5) z=1;
      if(mass[k]==11 && mass[k+1]==2) j=1;
      if(mass[k-1]==6 && mass[k+2]==6) h=1;
     }
    if(z==1 && j!=1) printf("�� ������ ��ன ��ࠬ��� RewRite\n");
    if(z!=1 && j==1) printf("�� ������ ���� ��ࠬ��� RewRite\n");
    if(z!=1 && j!=1) printf("��� �� ������ ��ࠬ��� RewRite\n");
    if(h!=1) printf("�� 墠⠥� ����祪 �� ��஬ ��ࠬ��� Rewrite\n");
    if(z==1 && j==1 && h==1) {printf("PARAM1 F\n");printf("PARAM2 'F.DAT'\n");}
    }else printf("�� 墠⠥� ᪮���\n");
   }
   //����� �஢�ન �� ReWrite
   //�᫨ ������� ��ᢠ������
   if(mass[i]==9)
   {//�ந�������� ���� ����樨 㬭������
    z=0;j=0;
    if(mass[i-1]==8 && mass[i-2]==1 && mass[i-3]==11)
    {
     for(k=i;k<27;k++) if(mass[k]==10) break;
     if(mass[k-1]==3 && mass[k-2]==11) z=1;
     if(mass[k+1]==11 && mass[k+2]==3) j=1;
     if(z==1 && j!=1) printf("�� ������ ��ன ���࠭� 㬭������\n");
     if(z!=1 && j==1) printf("�� ������ ���� ���࠭� 㬭������\n");
     if(z!=1 && j!=1) printf("��� �� ������ ���࠭�� �� 㬭������\n");
     if(z==1 && j==1) {printf("* K K REZ1\n"); printf(":= REZ1 F^\n");}
    }else printf("������ := ��祬� �� ᮮ⢥�����\n");
   }
   //���� ������ PUT
   if(mass[i]==2 && mass[i-1]!=11)
   {//������-�뢮���� � �᪠�� �����⢥��� ��ࠬ���
    z=0;
    if(mass[i+1]==3 && mass[i+4]==4)
    {
     for(k=i;k<27;k++) if(mass[k]==11 && mass[k+1]==1) z=1;
     if(z!=1) printf("������ ��� ���������騩 �����䨪��� � ������ PUT\n");
     if(z==1) {printf("PUT\n");printf("PARAM F\n");}
    }else printf("�� 墠⠥� ᪮���\n");
   }
  }
 }else printf("� ���� ��ப� �� 墠⠥� ;\n");
 getch();
 return 0;
}
