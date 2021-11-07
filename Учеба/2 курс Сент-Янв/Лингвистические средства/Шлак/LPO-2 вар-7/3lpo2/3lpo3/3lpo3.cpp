#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <windows.h>

void oper(int *mass, int n);
void uslovoper (int *mass, int n);
void RazOp (int *mass, int n);
void prisv (int *mass, int n);
void vivod (int *mass, int n);
void uslovie (int *mass, int n);
void viraj (int *mass, int n);
void slag (int *mass, int n);
void mnozh (int *mass, int n);
void letter(int lexeme, int newline);
void letter2(int lexeme, int value, int newline);

void letter(int lexeme, int newline){
        switch(lexeme){
		case 1:{
			printf("= ");
			break;
                }
		case 2:{
			printf("+ ");
			break;
                }
		case 3:{
			printf("( ");
			break;
                }
		case 4:{
			printf(") ");
			break;
                }
		case 5:{
			printf("; ");
			break;
                }
		case 6:{
			printf("/ ");
			break;
                }
		case 7:{
			printf("> ");
			break;
                }
		case 8:{
			printf("DO ");
			break;
                }
		case 9:{
			printf("DATA ");
			break;
                }
		case 10:{
			printf("THEN ");
			break;
                }
		case 11:{
			printf("IF ");
			break;
                }
		case 12:{
			printf("PUT ");
			break;
		}
		case 13:{
			printf("END ");
			break;
                }
	}
	if(newline)
        	printf("\n");
	return;
}

int vyraz(int i,int *mass, int n){
	int z=0;
	if(mass[i+2]==2){
		printf("Z1+");
		z=0;
	}
	if(mass[i+2]==6){
		printf("\nZN/");
		z=1;
	}
	return z;
}

int prisv(int i,int *mass, int n){
	int z=vyraz(i+3,mass,n);
	printf(" Z=");
	i+=8-z;
	return i;
}



int vivod(int i,int *mass,int n){
	printf("\nPUT DATA(Z)");
	return i+7;
}

void usl(int i,int *mass,int n){
	printf("\nZ>N");
	return;
}
int uslop(int i,int *mass,int n){
	usl(i+1,mass,n);
	int y=prisv(i+8,mass,n);
	i=vivod(y,mass,n);
	printf("\nif then do ;;;");
	return i+2;
}




void RazOp(int *mass, int n){
	int i=0;
	while(i<=n){
		if(mass[i]==14)
			i=prisv(i,mass,n);
		if(mass[i]==11)
			i=uslop(i,mass,n);
		if(mass[i]==13){
			printf("\nend;");
			return;
		}
		//if(mass[i]==12)
			//i=vivod(i,mass,n);
	}
	return;
}

int main(){
	system("cls");
	int mass[35]={14,1,1,14,1,2,15,5,11,14,1,7,14,2,10,8,14,1,1,14,1,6,14,2,5,12,9,3,14,1,4,5,13,5};
	int i=0, j=0;
	int start=0;
        int n=sizeof(mass)/sizeof(int);
	RazOp(mass, n);
	getch();
	return 0;
}