#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
char* IntToText(int one,int two)
{
 if (one==1 && two==0) return "REWRITE";
 if (one==2 && two==0) return " PUT";
 if (one==3 && two==0) return "(";
 if (one==4 && two==0) return ")";
 if (one==6 && two==0) return ";\n";
 if (one==7 && two==0) return "^";
 if (one==8 && two==0) return ":=";
 if (one==9 && two==0) return "*";
 if (one==11 && two==1) return "F";
 if (one==11 && two==2) return "K ";
 if (one==10 && two==1) return " 'F.DAT'\n";
 return "";
}
int main()
{clrscr();
 int i=0,j=0,m=0,mass[3][10]=
                         {
			  1,  3,  11,  1,  5,  10,  1,  4,  6,  0,
			  11 ,1,  7 ,  8,  11, 2,   9,  11, 2,  6,
			  2,  3,  11,  1,  4,  0,   0,  0,  0,  0,
			 };
 int map[12][12]={0,0,0,0,0,0,0,0,0,0,0,0,
		  0,0,0,1,0,0,0,0,0,0,0,0,
		  0,0,0,1,0,0,0,0,0,0,0,0,
		  0,0,0,0,0,0,0,0,0,0,0,2,
		  0,0,0,0,0,0,1,0,0,0,0,0,
		  0,0,0,0,0,0,0,0,0,0,2,0,
		  0,0,0,0,0,0,0,0,0,0,0,0,
		  0,0,0,0,0,0,0,0,1,0,0,0,
		  0,0,0,0,0,0,0,0,0,2,0,2,
		  0,0,0,0,0,0,0,0,0,0,0,2,
		  0,0,0,0,3,0,0,0,0,0,0,0,
		  0,0,0,0,3,3,3,1,0,3,0,0};
   char str[80];
  for(i=0;i<3;i++)
  {
   for(j=0;j<10;j++)
   {
    if(map[mass[i][j]][mass[i][j+1]]==2 && map[mass[i][j+1]][mass[i][j+2]]==3)
    {
     printf("%s",IntToText(mass[i][j+1],0));
     mass[i][j+1]=0;

    }
    if(map[mass[i][j]][mass[i][j+1]]==2 && map[mass[i][j+1]][mass[i][j+3]]==3)
    {
     printf("%s",IntToText(mass[i][j+1],mass[i][j+2]));
     mass[i][j+1]=0;
     mass[i][j+2]=0;
    }
   }
    for(m=0;m<10;m++)
    {
     if(map[mass[i][m]][mass[i][m+3]]==2 || map[mass[i][m]][mass[i][m+3]]==3)
     {
      printf("%s",IntToText(mass[i][m+3],0));
      mass[i][m+3]=0;
     }
    }
    for(m=0;m<10;m++)
    {
     if(mass[i][m]!=0)
     {
      if(mass[i][m]==10 || mass[i][m]==11) {printf("%s",IntToText(mass[i][m],mass[i][m+1]));m++;}
      else printf("%s",IntToText(mass[i][m],0));
     }
    }
   }
   return 0;
}
