#include <stdio.h>
#include <conio.h>
#include <stdlib.h>

struct dvunaprav
{
 struct dvunaprav *next, *prev;
 int i;
};
struct dvunaprav *first=NULL, *other, *third;
int IndexMenu, error, m, d, k;

int main()
{
 
 do
 {
  other=first;
  k=1;
   while( other!=NULL )
   {
    printf("%d)Danie elementa: %d\n", k, other->i);
	other=other->next;
	k++;
   }
   
   printf("\nSdelaite vibor...\n\n");
   printf("1-Sozdat' novyu stryktyry\n");
   printf("2-Dobavit' novii element v stryktyry\n");
   printf("3-Udalit' element iz stryktyri\n");
   printf("0-Exit\n");
   
   scanf("%d", &IndexMenu);
    if( IndexMenu==0 )
	 goto end; //0-Exit
	 else
	 {
	  switch( IndexMenu )
	  {
//---------------Sozdanie novoii stryktyri-----------------------	  
	   case 1:
	   {
	    first=(struct dvunaprav*)malloc( sizeof(struct dvunaprav) );
		first->next=first->prev=NULL;
		printf("Vvedite dannie elementa: ");
		scanf("%d", &first->i);
		break;
	   }
//---------------Dobavlenie novogo elementa--------------------------	   
	   case 2:
	   {
	    if(first==NULL)
		{
		 first=(struct dvunaprav*)malloc( sizeof(struct dvunaprav) );
		 first->next=first->prev=NULL;
		 printf("Vvedite dannie elementa: ");
		 scanf("%d", &first->i);
		}
		else
		{
		 other=first;
		 k=1;
		  while( other!=NULL )
		  {
		   printf("%d)Dannie elementa: %d\n", k, other->i);
		   other=other->next;
		   k++;
		  }
		  
		  third=(struct dvunaprav*)malloc( sizeof(struct dvunaprav) );
		  printf("Vvedite nomer v stryktyre dlya novogo elementa: ");
		  scanf("%d", &m);
		  other=first;
		   if( m==1 )
		   {
		    third->next=other;
			other->prev=third;
			third->prev=NULL;
			first=third;
			printf("\nVvedite dannie novogo elementa: ");
			scanf("%d", &third->i);
			break;
		   }
		   else
		   {
		    d=2;
			 while( d>m && other->next!=NULL )
			 {
			  d=d+1;
			  other=other->next;
			 }
			 
			 third->next=other->next;
			 third->prev=other;
			 other->next->prev=third;
			 other->next=third;
			 printf("\nVvedite dannie novogo elementa: ");
			 scanf("%d", &third->i);
			 break;
		   }
		}
		break;
	   }
//-------------------Udalenie elementa----------------------
		case 3:
		{
		 other=first;
		 k=1;
		  while( other!=NULL )
		  {
		   printf("%d)Dannie elementa: %d\n", k, other->i);
		   other=other->next;
		   k++;
		  }
		  
		  printf("Vvedite nomer elementa kotoryi nado udalit': ");
		  scanf("%d", &m);
		  other=first;
		   if( m==1 )
		   {
		    third=first;
			first=first->next;
			other->prev=NULL;
			free(third);
		   }
		   else
		   {
		    d=2;
			 while( d<m && other->next!=NULL )
			 {
			  d=d+1;
			  other=other->next;
			 }
			 
			  if( d==m )
			  {
			   other->next->next->prev=other;
			   third=other->next;
			   other->next=third->next;
			   free(third);
			  }
			  else
			  {
			   printf("\nTakogo elementa net v spiske");
			   getch();
			  }
		   }
		   break;
		}
		default:
		{
		 printf("\nOshibka vvoda! Try again.\n");
		 error=0;
		 getch();
		}
	   
	  } //end switch()
	 } //end else{}	 
 }while( error==0 );// end do..while()
 end:
  return 0;
 
 
 
}