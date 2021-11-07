#include<stdio.h>
#include<stdlib.h>
#include<conio.h>

typedef struct LinSpis
  {
    LinSpis* next;
    LinSpis* last;
    int key;
  };
  LinSpis *first=NULL,*neww;
void add(LinSpis *other,int key)
 {
   int num,metka;
   if(first==NULL)
     {
       first=(LinSpis*)malloc(sizeof(LinSpis));
       first->next=first->last=NULL;
       first->key=key;
       return;
     }
   printf("1.Dobavit posle ykazannogo elementa\n 2.Dobavit pered ykazannim elementom\n");
   scanf("%d",&metka);
   switch(metka)
     {
       case 1: {
	       printf("posle kakogo elementa vstavit novyi");
	       scanf("%d",&num);
	       while(other->key!=num)
		 {
		  other=other->next;
		  neww=other->next;

                  }
     
     
                 neww=(LinSpis*)malloc(sizeof(LinSpis));
		  neww->next=other->next;
		  other->next->last=neww;
		  neww->last=other;
		  other->next=neww;

		   if(other->next!=NULL)
                   {
		   other->next=neww;
                   neww->key=key;
		 } 
	       else
		 {
		   printf("takogo elementa net v spiske");
		   getch();
		 }
	      };break;

       case 2: { printf("pered kakim elementom xotite vstavit novyi");
		 scanf("%d",&num);
		 while(other->key!=num)
		   {
		     other=other->next;
		     neww=other->next;
		   
		     }
		     
		  if(other!=NULL)
		 
		    {
		     neww=(LinSpis*)malloc(sizeof(LinSpis));
		     neww->last=other->last;
		     other->last->next=neww;
		     neww->next=other;
		     other->last=neww;
		     neww->key=key;
		     if(other==first)
		     {
		     first=neww;
		     neww->next=other;
		     }
		     }
		 else
		   {
		     printf("takogo elementa net v spiske");
		     getch();
		   }
	       };break;
	}
	  return;
	}
void del(LinSpis*other,int key)
  {
  other=first;
    while(other->key!=key&&other!=NULL)
      {
	other=other->next;
	if(other==NULL)break;
      }
    if(other!=NULL)
      {
	if(other==first)
	  {
	  first=first->next;
	    if(first->last!=NULL&&first->next!=NULL)
	      {
		
		other->next->last=other->last;
                other->last->next=other->last;
		free(other);
	      }

	  }
	else
	  {
	    other->next->last=other->last;
	    other->last->next=other->next;
	    free(other);
	  }
      }
    else
      {
	printf("takogo elementa net v spiske");
	getch();
      }
    return;
  }
void printlist(LinSpis *other)
  {
    if(first!=NULL)
      {
	do
	  {
	    printf("%d\n",other->key);
	    other=other->next;
	  }
	while(other!=NULL);
      }
    else
      {
	printf("spisok pyst");
	getch();
      }
    return;
  }
void del_all(LinSpis *other)
  {
    do
      {
	neww=other;
	other=other->next;
	free(neww);
      }
    while(other!=NULL);
 return;
  }

void main()
  {
    int key,metka;
    do
      {
	printf("1. Dobavit element v spisok\n2. Ydalit element iz spiska \n3. Exit\n");
	scanf("%d",&metka);
	switch(metka)
	  {
	    case 1: { clrscr();
		      printf("Vvod ykazannogo elementa v spisok: ");
		      scanf("%d",&key);
		      add (first, key);
		    };break;
	    case 2: { clrscr();
		      printf("Vvod ydalaemogo elementa: ");
		      scanf("%d",&key);
		      del(first,key);
		    };break;
	    case 3: del_all(first);break;
	  }
	clrscr();
       printlist(first);
      }
    while(metka!=3);
    return ;

  }
