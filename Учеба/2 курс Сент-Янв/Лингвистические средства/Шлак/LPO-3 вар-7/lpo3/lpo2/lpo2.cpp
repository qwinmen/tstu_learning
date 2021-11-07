#include <conio.h>
#include <stdio.h>

int print(int n,int k, int *ish,int z);

int main(){
	int mass[16][15]={	0,2,0,0,3,2,0,0,0,0,0,0,0,2,0,
						0,0,0,0,3,0,0,0,0,0,0,0,0,0,2,
						0,0,0,0,3,0,0,0,0,0,0,0,0,2,0,
						0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,
						3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,
						0,0,0,0,3,0,0,0,0,0,0,0,0,2,0,
						0,0,0,0,3,0,0,0,0,3,0,0,0,2,0,
						0,0,0,0,3,0,0,0,0,3,0,0,0,0,0,
						0,0,1,1,3,0,0,0,0,0,0,0,0,0,0,
						0,0,0,0,3,0,0,3,0,0,0,0,0,0,0,
						0,0,0,0,3,0,2,2,0,1,0,0,0,2,0,
						0,0,0,0,3,0,0,0,1,0,0,0,0,0,0,
						0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,
						1,3,0,3,3,3,3,0,0,3,0,0,0,0,0,
						0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,
						2,2,2,2,2,2,2,2,2,2,2,2,2,2,2};
	int i,z=36,prev,next,prev1,next1;
	int ish[36]={16,14,1,1,14,1,2,15,5,11,14,1,7,14,2,10,8,5,14,1,1,14,1,6,14,2,5,12,9,3,14,1,4,5,13,5};
	for(i=0;i<z && z>0;){
		prev=i;
		next=prev+1;
		if(ish[prev]==14)
			next++;
		if(mass[ish[prev]-1][ish[next]-1]==3){
			prev1=prev;
			next1=next;
			while(mass[ish[prev1]-1][ish[next1]-1]!=2 && prev1>=1){
				next1=prev1;
				prev1--;
				if(ish[prev1-1]==14)
					prev1--;
			}
			z=print(prev1,next,ish,z);
			next=0;
		}
		i=next;
	}
	getch();
	return 0;
}

int print(int n,int k, int *ish,int z){
	int i,flag=0;
	for(i=n+1;i<k;i++){
		switch(ish[i]){
			case 1: {printf("= ");break;}
			case 2: {printf("+ ");break;}
			case 3: {printf("( ");break;}
			case 4: {printf(") ");break;}
			case 5: {printf("; ");break;}
			case 6: {printf("/ ");break;}
			case 7: {printf("> ");break;}
			case 8: {printf("DO ");break;}
			case 9: {printf("DATA ");break;}
			case 10: {printf("then ");break;}
			case 11: {printf("if ");break;}
			case 12: {printf("PUT ");break;}
			case 13: {printf("end ");break;}
			case 14: {	 if(ish[i+1]==1)
							 printf("Z ");
						 else
							printf("N ");
						 i++;flag++;
						 break;}
			case 15: {printf("1 ");}
		}
		flag++;
	}
	int e=0;
	for(i=n+1;i<k;i++,e++){
		for(int h=i-e;h<z;h++)
			ish[h]=ish[h+1];
		ish[z-1]=0;
	}
	z=z-flag;
	printf("\n");
	return z;
}