#include <stdlib.h>
#include <stdio.h>
#include <conio.h>
#include <string.h>

struct TYPE_PHONE
{
	struct TYPE_PHONE *PtrNEXT;
        struct TYPE_PHONE *PtrPREVIOUS;
        char Name[80];
	char Adress[80];
	long Number;
};

struct TYPE_PHONE *PTR, *PTRBegin=NULL,*TEMP;
int IndexMenu, error, IndexSubmenu;
long number=0;
char *TempStr;

void PrintStruct(char*, char*, long);
void PrintMenu(void);
void PrintSubmenuSearch(void);

void Creat(void);
void Addition(void);
void Removal(void);
TYPE_PHONE *SearchByString(char*);
TYPE_PHONE *SearchByNumber(long);
//------------------------------------------------------------------------------
main()
{
//------------------------------------------------------------------------------
        do
        {
          PrintMenu();
	  scanf("%d",&IndexMenu);
          switch(IndexMenu)
          {
          case 1: {clrscr();Creat(); break;}
          case 2: {clrscr(); if(PTRBegin==NULL)
                    {
                     printf("\nError!!!  The structure has not been created\n");
                     while (!kbhit());
                     break;
                    }
                    Addition();break;}
          case 3: {
                   clrscr();
                   PTR=PTRBegin;
                   while(PTR!=NULL)
                    {
                        PrintStruct(PTR->Name, PTR->Adress, PTR->Number);
                        PTR=PTR->PtrNEXT;
                    }
                   while (!kbhit());
                   break;}
          case 4: {
                    PrintSubmenuSearch();
                    do
                    {
                      error=0;
                      scanf("%d",&IndexSubmenu);
                      if(IndexSubmenu==1)
                        {
                         TempStr=(char*)malloc(80*sizeof(char));
                         clrscr();
                         printf("Enter a search string\n");
                         gets(TempStr);
                         gets(TempStr);
                         PTR=SearchByString(TempStr);
                         if(PTR==NULL)
                         {
                           printf("\nThe entered recording is absent!!!\n");
                           while (!kbhit());
                           break;
                         }
                         PrintStruct(PTR->Name, PTR->Adress, PTR->Number);
                         while (!kbhit());
                         free(TempStr);
                         break;
                        }
                      if(IndexSubmenu==2)
                        {
                         TempStr=(char*)malloc(80*sizeof(char));
                         clrscr();
                         printf("Enter a search string\n");
                         gets(TempStr);
                         gets(TempStr);
                         PTR=SearchByString(TempStr);
                         if(PTR==NULL)
                         {
                           printf("\nThe entered recording is absent!!!\n");
                           while (!kbhit());
                           break;
                         }
                         PrintStruct(PTR->Name, PTR->Adress, PTR->Number);
                         while (!kbhit());
                         free(TempStr);
                         break;
                        }
                      if(IndexSubmenu==3)
                        {
                         clrscr();
                         printf("Enter a search Number\n");
                         scanf("%d",&number);
                         PTR=SearchByNumber(number);
                         if(PTR==NULL)
                         {
                           printf("\nThe entered recording is absent!!!\n");
                           while (!kbhit());
                           break;
                         }
                         PrintStruct(PTR->Name, PTR->Adress, PTR->Number);
                         while (!kbhit());
                         break;
                        }
                      printf("\nMistake!!! Try once again.\n");
                      error=1;
                    }
                    while(error==1);
                    break;
                  }
          case 5: {Removal();break;}
          case 6: exit(0);
          default:{printf("\nMistake!!! Try once again.\n"); error=0;};
          }
        }
        while(error==0);
//------------------------------------------------------------------------------
        free(TempStr);
        while(!kbhit());
return 0;
}
//==============================================================================
void PrintMenu(void)
{
        clrscr();
        printf("Input...\n\n");
        printf("1-Creation of structure\n");
        printf("2-Addition of a new element of structure\n");
        printf("3-Print of a list\n");
        printf("4-Information search\n");
        printf("5-Removal of an element of structure\n");
        printf("6-Exit\n");
}
//,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
void PrintSubmenuSearch(void)
{
        clrscr();
        printf("Input...\n\n");
        printf("1-Search by name\n");
        printf("2-Search by adress\n");
        printf("3-Search by number\n");
}
//,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
void Creat(void)
{

        PTR=(struct TYPE_PHONE*)malloc(sizeof(struct TYPE_PHONE));
	PTR->PtrNEXT=NULL; PTR->PtrPREVIOUS=NULL;
        PTRBegin=PTR;
	gets(PTR->Name);
        printf("Input Name: ");
        gets(PTR->Name);
        printf("Input Adress: ");
        gets(PTR->Adress);
        printf("Input Number: ");
        scanf("%d",&PTR->Number);
}
//,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
void Addition(void)
{
        TEMP=NULL;
        TEMP=(struct TYPE_PHONE*)malloc(sizeof(struct TYPE_PHONE));
        TEMP->PtrNEXT=NULL; TEMP->PtrPREVIOUS=NULL;
        clrscr();
        gets(TEMP->Name);
        printf("Input Name: ");
        gets(TEMP->Name);
        printf("Input Adress: ");
        gets(TEMP->Adress);
        printf("Input Number: ");
        scanf("%d",&TEMP->Number);
        PTR=PTRBegin;
        while(PTR!=NULL)
         {
           if((TEMP->Number<PTR->Number)&&(PTR->PtrPREVIOUS==NULL))
               {
                TEMP->PtrNEXT=PTRBegin;
                PTR->PtrPREVIOUS=TEMP;
                PTRBegin=TEMP;
                break;
               }
           if((TEMP->Number>PTR->Number)&&(PTR->PtrNEXT==NULL))
               {
                PTR->PtrNEXT=TEMP;
                TEMP->PtrPREVIOUS=PTR;
                break;
               }
           if((TEMP->Number>PTR->Number)&&(TEMP->Number<PTR->PtrNEXT->Number))
               {
                TEMP->PtrNEXT=PTR->PtrNEXT;
                PTR->PtrNEXT->PtrPREVIOUS=TEMP;
                PTR->PtrNEXT=TEMP;
                TEMP->PtrPREVIOUS=PTR;
                break;
               }
           PTR=PTR->PtrNEXT;
         }
}
//,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
void Removal(void)
{
        TEMP=NULL;
        TEMP=(struct TYPE_PHONE*)malloc(sizeof(struct TYPE_PHONE));
        clrscr();
        printf("You want to remove what number?\n");
        scanf("%d",&number);
        PTR=PTRBegin;
        while(PTR!=NULL)
         {
           if((PTR->PtrNEXT==NULL)&&(PTR->PtrPREVIOUS==NULL)) free(PTRBegin);
           if((number==PTR->Number)&&(PTR->PtrPREVIOUS==NULL)&&(PTR->PtrNEXT!=NULL))
               {
                PTRBegin=PTR->PtrNEXT;
                free(PTR);
                PTRBegin->PtrPREVIOUS=NULL;
                break;
               }
           if((number==PTR->Number)&&(PTR->PtrNEXT==NULL)&&(PTR->PtrPREVIOUS!=NULL))
               {
                PTR=PTR->PtrPREVIOUS;
                free(PTR->PtrNEXT);
                PTR->PtrNEXT=NULL;
                break;
               }
           if((number==PTR->Number))
               {
                TEMP=PTR;
                PTR=PTR->PtrPREVIOUS;
                PTR->PtrNEXT=PTR->PtrNEXT->PtrNEXT;
                PTR->PtrNEXT->PtrPREVIOUS=PTR;
                free(TEMP);
                break;
               }
           PTR=PTR->PtrNEXT;
         }
}
//,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
TYPE_PHONE *SearchByString(char *String)
{
        int t=1;
        PTR=PTRBegin;
        while((PTR!=NULL)&&(t!=0))
          {
              t=strcmp(TempStr,PTR->Name);
              if(t==0) break;
              t=strcmp(TempStr,PTR->Adress);
              if(t==0) break;
              PTR=PTR->PtrNEXT;
          }
return PTR;
}
//,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
TYPE_PHONE *SearchByNumber(long NUMBER)
{
        int t=1;
        PTR=PTRBegin;
        while((PTR!=NULL)&&(t!=0))
          {
              if(NUMBER==PTR->Number)t=0;
              if(t==0) break;
              PTR=PTR->PtrNEXT;
          }
return PTR;
}
//,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
void PrintStruct(char *NAME, char *ADRESS, long NUMBER)
{
        printf("\nName: %s",NAME);
        printf("\nAdress: %s",ADRESS);
        printf("\nNumber: %d\n",NUMBER);
}
//..............................................................................
