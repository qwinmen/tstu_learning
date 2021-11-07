#include <stdio.h>
#include <stdlib.h>

struct ntch
   {struct ntch *f;
    int num,n;
   };

FILE *in,*o;
int temp=1,razm=15;

int main()
{int i,j,l;
 char **mp;
 struct ntch *s,*st=NULL,*t,*b,*e;

 if((in=fopen("a:\\lpo1o.txt","rt"))==NULL)
	{printf("Can't open input file\n");
	 return 1;
	}
 /*if((i=fopen("lpo3o.txt","wt"))==NULL)
	{printf("Can't open output file\n");
	 return 1;
	}*/
 //-------------Заполнение матрицы предшествования-----------//
 mp=(char**)malloc(razm*sizeof(char*));
 for(i=0;i<razm;i++)
    mp[i]=(char*)malloc(razm*sizeof(char));
 for(i=0;i<razm;i++)
    for(j=0;j<razm;j++)
       mp[i][j]=3;
 mp[0][1]=-1,mp[0][2]=1,mp[0][4]=-1,mp[0][5]=-1,mp[0][13]=-1,mp[0][14]=-1;
 mp[1][1]=-1,mp[1][2]=1,mp[1][4]=-1,mp[1][5]=-1,mp[1][6]=1,mp[1][13]=-1,mp[1][14]=-1;
 mp[2][0]=-1,mp[2][2]=-1,mp[2][7]=-1,mp[2][10]=-1,mp[2][12]=-1,mp[2][13]=-1,mp[2][14]=-1;
 mp[3][8]=1,mp[3][13]=-1,mp[3][14]=-1;
 mp[4][1]=1,mp[4][2]=1,mp[4][4]=-1,mp[4][5]=-1,mp[4][6]=1,mp[4][13]=-1,mp[4][14]=-1;
 mp[5][1]=-1,mp[5][4]=-1,mp[5][5]=-1,mp[5][6]=2,mp[5][13]=-1,mp[5][14]=-1;
 mp[6][1]=1,mp[6][2]=1,mp[6][4]=1,mp[6][6]=1;
 mp[7][3]=-1,mp[7][8]=2,mp[7][13]=-1,mp[7][14]=-1;
 mp[8][9]=2;
 mp[9][2]=1;
 mp[10][11]=2;
 mp[11][2]=1,mp[11][5]=-1;
 mp[12][2]=1;
 mp[13][1]=1,mp[13][2]=1,mp[13][3]=1,mp[13][4]=1,mp[13][6]=1,mp[13][8]=1;
 mp[14][0]=1,mp[14][1]=1,mp[14][2]=1,mp[14][3]=1,mp[14][4]=1,mp[14][6]=1,mp[14][8]=1;
 //----------------------------------------//
 s=(struct ntch*)malloc(sizeof(struct ntch));
 st=s->f=NULL;
 s->num=3;
 s->n=0;
 while(!feof(in))
  {//--------Заполнение списка по строке---------//
   st=NULL;
   do
     {fscanf(in,"%u",&l);
      if(st==NULL) {st=s->f=(struct ntch*)malloc(sizeof(struct ntch));
		    st->num=l;
		    if((l==15)||(l==14)) {fscanf(in,"%u",&l);
					  st->n=l;
					 }
			     else st->n=0;
		    st->f=NULL;
		   }
	 else{t=st;
	      while(t->f!=NULL)
		   t=t->f;
	      t->f=(struct ntch*)malloc(sizeof(struct ntch));
	      t=t->f;
	      t->num=l;
	      if((l==15)||(l==14)) {fscanf(in,"%u",&l);
				    t->n=l;
				   }
		    else t->n=0;
	      t->f=NULL;
	     }
     }
   while(l!=3);
  //----------------------------------------------//

 while(s->f->num!=3)
   {i=0;t=s;b=t;
    while(t->f!=NULL)
      {if(mp[t->num-1][t->f->num-1]==3)
		{i=1;printf("\nError\n");break;}
       if(mp[t->num-1][t->f->num-1]==-1)
		b=t->f;
       if(mp[t->num-1][t->f->num-1]==1)
		{e=t->f;
		 break;
		}
       t=t->f;
       e=t->f;
      }
    if(i) break;
    t=b;
    while(t->f!=e)
      {printf("%u ",t->num);
       if(t->n!=0)printf("%u ",t->n);
       t=t->f;
      }
    printf("%u ",t->num);
    if(t->n!=0)printf("%u ",t->n);
    t=s;
    while(t->f!=b) t=t->f;
    t->f=e;
    do
     {t=b->f;
      free(b);
      b=t;
     }
    while(b!=e);
   }
  //--------Вывод на экран--------------//
/*   t=st;
   while(t->f!=NULL)
      {printf("%u ",t->num);
       if(t->n!=0)printf("%u ",t->n);
       t=t->f;
      }
   printf("%u ",t->num);
   if(t->n!=0)printf("%u ",t->n);*/
   //-----------Освобождение динамической памяти-------//
/*   t=st;
   while(t->f!=NULL)
	{st=t->f;
	 free(t);
	 t=st;
	}*/
   free(t);
   //---------------------------------------------//
   if(i) break;
   printf("\n");
  }
 printf("\n");

 for(j=0;j<razm;j++)
   free(mp[j]);
 free(mp);
 free(s);
 fclose(in);
 return 0;
}
