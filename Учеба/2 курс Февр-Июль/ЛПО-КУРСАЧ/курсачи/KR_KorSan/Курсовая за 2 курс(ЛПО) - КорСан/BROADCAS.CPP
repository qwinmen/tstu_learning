#include "broadcas.h"

void CBroadcast::Bgeneral()
{
    num_cycle=0; num_skobki=0;
    lrez=fopen("lexic.rez","rb");
    brez=fopen("broadcas.rez","wb");
    IDN=fopen("listidn.dat","rb");
    Bread_dat();
    Bbegin_program();
    while (lex!=-1) {
	Blist_oper();
    }

    fclose(lrez);
    fclose(brez);
    fclose(IDN);
}

void CBroadcast::Bread_dat()
{
    int i,j,simbol;

    for(i=0;i<40;i++) {
	masType[i]=0;
	for(j=0;j<10;j++)
	    masIDN[i][j]=0;
    }
    for(i=0;i<10;i++) {
	for(j=0;j<20;j++)
	    a[i][j]=0;
    }
    i=0; j=0;
    while ((feof(IDN)!=1)&&(int(simbol)!=-1)) {
	simbol=fgetc(IDN);
	if ((int(simbol)==32)||(int(simbol)==10)||(int(simbol)==13)) {
	    if (int(simbol)==32) {
		masType[i]=int(fgetc(IDN));
	    }
	    if (int(simbol)==13) {
		i=i+1; j=0;
	    }
	}
	else {
	    masIDN[i][j]=simbol;
	    j=j+1;
	}
    }

    for(i=0;i<10;i++) introdbuff[i]=0;
    for(i=0;i<10;i++) num_a[i]=0;

}

void CBroadcast::Bnext_lex()
{
    lexold3=lexold2;
    lexold2=lexold1;
    lexold1=lex;
    lex=int(fgetc(lrez));
    if ((lex==100)&&(lexold1!=42)&&(lexold1!=41)) {
	lex=int(fgetc(lrez));
    }
    if ((lex==2)&&(lexold1!=42)&&(lexold1!=41)) num_skobki=num_skobki+1;
    if ((lex==3)&&(lexold1!=42)&&(lexold1!=41)) num_skobki=num_skobki-1;
}

void CBroadcast::Blist_oper()
{
    Bnext_lex();
    if (lex==2) {
	Bnext_lex();
	while ((lex!=3)&&(lex!=-1)) {
	    Bdeclare();
	    Bintroduce();
	    Bconclusion();
	    Bappropriate();
	    Bcycle();
	    Bnext_lex();
	}
    }
    else {
	Bintroduce();
	Bconclusion();
	Bappropriate();
	Bcycle();
    }
    if ((num_skobki==0)&&(lex!=-1)) fputs("\nEND;",brez);
}

void CBroadcast::Blist_IDN()
{
    Bnext_lex();
    if ((lex==41)||(lex==20)) {
	if (lex==41) {
	    Bnext_lex();
	    Bnext_lex();
	    if (lex==5) fputs("(",brez);
	    fputs(masIDN[lexold1],brez);
	    while (lex==5) {
		Bnext_lex();
		if (lex==41) {
		    Bnext_lex();
		    fputs(",",brez);
		    fputs(masIDN[lex],brez);
		}
		Bnext_lex();
		if (lex!=5) {
		    fputs(")",brez);
		}
	    }
	    if (lex==41) {
		Bnext_lex();
		Bnext_lex();
		fputs(",",brez);
		fputs(masIDN[lexold1],brez);
		fputs(")",brez);
	    }
	}
	else {
	    Bnext_lex();
	    if (lex==41) {
		Bnext_lex();
		Bnext_lex();
		if (lex==5) fputs("(",brez);
		fputs(masIDN[lexold1],brez);
		while(lex==5) {
		    Bnext_lex();
		    if (lex==20) {
			Bnext_lex();
			if (lex==41) {
			    Bnext_lex();
			    fputs(",",brez);
			    fputs(masIDN[lex],brez);
			}
			Bnext_lex();
			if (lex!=5) {
				fputs(")",brez);
			}
		    }
		}
		if (lex==20) {
		    Bnext_lex();
		    if (lex==41) {
			Bnext_lex();
			fputs(",",brez);
			fputs(masIDN[lex],brez);
			Bnext_lex();
		    }
		}
	    }
	}
    }
}

void CBroadcast::Barith_expr()
{
    if ((lex==0)||(lex==41)||(lex==42)||(lex==21)) {
	if ((lex==41)||(lex==42)) {
	    Bnext_lex();
	    if (lexold1==41) {
		fputs(masIDN[lex],brez);
	    }
	    else {
                itoa(lex,string,10);
		fputs(string,brez);
	    }
	    Bnext_lex();
	    while ((lex==9)||(lex==21)||(lex==22)||(lex==23)) {
		switch (lex) {
		    case 9: {
				Bnext_lex();
				fputs("+",brez);
				if (lex==0) {
				    Bnext_lex(); Barith_expr();
				}
				else {
				    Bnext_lex();
				    if (lexold1==41) {
					fputs(masIDN[lex],brez);
				    }
				    else {
					itoa(lex,string,10);
					fputs(string,brez);
				    }
				}
				break;
			    }
		    case 21: {
				 Bnext_lex();
				 fputs("-",brez);
				 if (lex==0) {
				     Bnext_lex(); Barith_expr();
				 }
				 else {
				     Bnext_lex();
				     if (lexold1==41) {
					 fputs(masIDN[lex],brez);
				     }
				     else {
					 itoa(lex,string,10);
					 fputs(string,brez);
				     }
				 }
				 break;
			     }
		    case 22: {
				 Bnext_lex();
				 fputs("/",brez);
				 if (lex==0) {
				     Bnext_lex(); Barith_expr();
				 }
				 else {
				     Bnext_lex();
				     if (lexold1==41) {
					 fputs(masIDN[lex],brez);
				     }
				     else {
					 itoa(lex,string,10);
					 fputs(string,brez);
				     }
				 }
				 break;
			     }
		    case 23: {
				 Bnext_lex();
				 fputs("*",brez);
				 if (lex==0) {
				     Bnext_lex(); Barith_expr();
				 }
				 else {
				     Bnext_lex();
				     if (lexold1==41) {
					 fputs(masIDN[lex],brez);
				     }
				     else {
					 itoa(lex,string,10);
					 fputs(string,brez);
				     }
				 }
				 break;
			     }
		}
		Bnext_lex();
	    }
	    return;
	}
	if (lex==21) {
	    while ((lex==9)||(lex==21)||(lex==22)||(lex==23)) {
		switch (lex) {
		    case 9: {
				Bnext_lex();
				fputs("+",brez);
				if (lex==0) {
				    Bnext_lex(); Barith_expr();
				}
				else {
				    Bnext_lex();
				    if (lexold1==41) {
					fputs(masIDN[lex],brez);
				    }
				    else {
					itoa(lex,string,10);
					fputs(string,brez);
				    }
				}
				break;
			    }
		    case 21: {
				 Bnext_lex();
				 fputs("+",brez);
				 if (lex==0) {
				     Bnext_lex(); Barith_expr();
				 }
				 else {
				     Bnext_lex();
				     if (lexold1==41) {
					 fputs(masIDN[lex],brez);
				     }
				     else {
					 itoa(lex,string,10);
					 fputs(string,brez);
				     }
				 }
				 break;
			     }
		    case 22: {
				 Bnext_lex();
				 fputs("/",brez);
				 if (lex==0) {
				     Bnext_lex(); Barith_expr();
				 }
				 else {
				     Bnext_lex();
				     if (lexold1==41) {
					 fputs(masIDN[lex],brez);
				     }
				     else {
					 itoa(lex,string,10);
					 fputs(string,brez);
				     }
				 }
				 break;
			     }
		    case 23: {
				 Bnext_lex();
				 fputs("*",brez);
				 if (lex==0) {
				     Bnext_lex(); Barith_expr();
				 }
				 else {
				     Bnext_lex();
				     if (lexold1==41) {
					 fputs(masIDN[lex],brez);
				     }
				     else {
					 itoa(lex,string,10);
					 fputs(string,brez);
				     }
				 }
				 break;
			     }
		}
		Bnext_lex();
	    }
	    return;
	}
	if (lex==0) {
	    fputs("(",brez);
	    while (lex!=1) {
		Bnext_lex(); Barith_expr();
	    }
	    fputs(")",brez);
	    return;
	}
    }
}

void CBroadcast::Bdeclare()
{
    if (lex==15) {
	fputs("\n DCL ",brez);
	Blist_IDN();
	fputs(" FIXED",brez);

	if (lex==4) {
	    fputs(" ;",brez);
	    return;
	}
    }
    if (lex==16) {
	fputs("\n DCL ",brez);
	Blist_IDN();
	fputs(" FLOAT",brez);
	if (lex==4) {
	    fputs(" ;",brez);
	    return;
	}
    }
}

void CBroadcast::Bbegin_program()
{
    Bnext_lex();
    if (lex==14) {
	fputs("MAIN: PROC OPTIONS",brez);
	Bnext_lex();
	if (lex==0) {
	    fputs("(",brez);
	    Bnext_lex();
	    fputs("MAIN",brez);
	    if (lex==1) {
		fputs(")",brez);
	    }
	}
    }
}

void CBroadcast::Bintroduce()
{
    int i,j;

    i=0; j=0;
    if (lex==17) {
	fputs("\nGET EDIT",brez);
	Bnext_lex();
	if (lex==0) {
	    Bnext_lex();
	    if (lex==6) {
		Bnext_lex();
		while (lex!=6) {
		    Bnext_lex();
		    if (lex==13) {
			introdbuff[i]=2;
			i=i+1;
		    }
		}
		Bnext_lex();
		if (lex==5) {
		    Blist_IDN();
		    if (lex==1) {
			Bnext_lex();
			fputs(" (",brez);
			for(j=0;j<i;j++) {
			    if (introdbuff[j]==2)
			    fputs("F(9)",brez);
			    if ((j+1)!=i) fputs(",",brez);
			}
			fputs(")",brez);
			if (lex==4) {
			    fputs(";",brez);
			}
		    }
		}
		if (lex==1) {
		}
	    }
	}
    }
}

void CBroadcast::Bconclusion()
{
    int i,j;

    i=0; j=0;
    if (lex==19) {
	fputs("\nPUT EDIT",brez);
	Bnext_lex();
	if (lex==0) {
	    Bnext_lex();
	   // fputs("(",brez);
	    if (lex==6) {
		Bnext_lex();
		while (lex!=6) {
		    Bnext_lex();
		    if (lex==13) {
			introdbuff[i]=2;
			i=i+1;
		    }
		}
		Bnext_lex();
		if (lex==5) {
		    Blist_IDN();
		    if (lex==1) {
			Bnext_lex();
			fputs(" (",brez);
			for(j=0;j<i;j++) {
			    if (introdbuff[j]==2)
			    fputs("F(9) ",brez);
			    if ((j+1)!=i) fputs(",",brez);
			}
			fputs(")",brez);
			if (lex==4) {
			    fputs(";",brez);
			}
		    }
		}
		if (lex==1) {
		}
	    }
	}
    }
}

void CBroadcast::Bcondition()
{
    Bnext_lex();
    if ((lex==0)||(lex==41)||(lex==42)) {
	if (lex==0) {
	    fputs("(",brez);
	    Bnext_lex();
	    Bcondition();
	    if (lex==1) {
		fputs(")",brez);
		Bnext_lex();
	    }
	}
	if (lex==41) {
	    fputs("(",brez);
	    Bnext_lex();
	    fputs(masIDN[lex],brez);
	    Bnext_lex();
	    switch (lex) {
		case 10: fputs("<=",brez);
			 Bnext_lex(); Barith_expr(); break;
		case 24: fputs("<",brez);
			 Bnext_lex(); Barith_expr(); break;
		case 25: fputs(">",brez);
			 Bnext_lex(); Barith_expr(); break;
		case 26: fputs(">=",brez);
			 Bnext_lex(); Barith_expr(); break;
		case 27: fputs("-=",brez);
			 Bnext_lex(); Barith_expr(); break;
		case 28: fputs("=",brez);
			 Bnext_lex(); Barith_expr(); break;
	    }
	    fputs(")",brez);
	}
	if (lex==42) {
	    Bnext_lex();
	    fputs("(",brez);
	    itoa(lex,string,10);
	    fputs(string,brez);
	    Bnext_lex();
	    switch (lex) {
		case 10: fputs("<=",brez); Bnext_lex(); Barith_expr(); break;
		case 24: fputs("<",brez); Bnext_lex(); Barith_expr(); break;
		case 25: fputs(">",brez); Bnext_lex(); Barith_expr(); break;
		case 26: fputs(">=",brez); Bnext_lex(); Barith_expr(); break;
		case 27: fputs("-=",brez); Bnext_lex(); Barith_expr(); break;
		case 28: fputs("=",brez); Bnext_lex(); Barith_expr(); break;
	    }
	    fputs(")",brez);
	}
    }
}

void CBroadcast::Bappropriate()
{
    if (lex==41) {
	if (lexold1!=0) fputs("\n",brez);
	Bnext_lex();
	fputs(masIDN[lex],brez);
	Bnext_lex();
	if ((lex==8)||(lex==11)) {
	    if (lex==8) {
		fputs("=",brez);
		Bnext_lex();
		Barith_expr();
		if (lex==4) {
		    fputs(";",brez);
		}
	    }
	    else {
		fputs(masIDN[lexold1],brez);
		fputs("=",brez);
		fputs(masIDN[lexold1],brez);
		Bnext_lex();
		fputs("+1",brez);
		if (lex==4) {
		    fputs(";",brez);
		}
	    }
	}
    }
}

void CBroadcast::Bcycle()
{
    int i;

    if (lex==18) {
    num_cycle=num_cycle+1;
	Bnext_lex();
	if (lex==0) {
	    Bnext_lex();
	    Bappropriate();
	    fputs("\nDO WHILE ",brez);
	    Bcondition();
	    if (lex==4) {
		Bnext_lex();
		BCycleAppropriate();
		if (lex==1) {
		    Blist_oper();
		    fputs(a[num_cycle],brez);
		    for(i=0;i<20;i++) a[num_cycle][i]=0;
		    fputs("\nEND;\n",brez);
		    num_cycle=num_cycle-1;
		}
	    }
	}
    }
}
void CBroadcast::BCycleAppropriate()
{
    if (lex==41) {
	Bnext_lex();
	strcpy(a[num_cycle],masIDN[lex]);
	Bnext_lex();
	if ((lex==8)||(lex==11)) {
	    if (lex==8) {
		strcat(a[num_cycle],"=");
		Bnext_lex();
		BCycleArith_expr();
		strcat(a[num_cycle],";");
	    }
	    else {
		strcat(a[num_cycle],"=");
		strcat(a[num_cycle],masIDN[lexold1]);
		Bnext_lex();
		strcat(a[num_cycle],"+");
		strcat(a[num_cycle],"1");
		strcat(a[num_cycle],";");
	    }
	}
    }
}

void CBroadcast::BCycleArith_expr()
{
    if ((lex==0)||(lex==41)||(lex==42)||(lex==21)) {
	if ((lex==41)||(lex==42)) {
	    Bnext_lex();
	    if (lexold1==41) {
		strcat(a[num_cycle],masIDN[lex]);
	    }
	    else {
		itoa(lex,string,10);
		strcat(a[num_cycle],string);
	    }
	    Bnext_lex();
	    while ((lex==9)||(lex==21)||(lex==22)||(lex==23)) {
		switch (lex) {
		    case 9: {
				Bnext_lex();
				strcat(a[num_cycle],"+");
				if (lex==0) {
				    Bnext_lex(); BCycleArith_expr();
				}
				else {
				    Bnext_lex();
				    if (lexold1==41) {
					strcat(a[num_cycle],masIDN[lex]);
				    }
				    else {
					itoa(lex,string,10);
					strcat(a[num_cycle],string);
				    }
				}
				break;
			    }
		    case 21: {
				 Bnext_lex();
				 strcat(a[num_cycle],"-");
				 if (lex==0) {
				     Bnext_lex(); BCycleArith_expr();
				 }
				 else {
				     Bnext_lex();
				     if (lexold1==41) {
					 strcat(a[num_cycle],masIDN[lex]);
				     }
				     else {
					 itoa(lex,string,10);
					 strcat(a[num_cycle],string);
				     }
				 }
				 break;
			     }
		    case 22: {
				 Bnext_lex();
				 strcat(a[num_cycle],"/");
				 if (lex==0) {
				     Bnext_lex(); BCycleArith_expr();
				 }
				 else {
				     Bnext_lex();
				     if (lexold1==41) {
					 strcat(a[num_cycle],masIDN[lex]);
				     }
				     else {
					 itoa(lex,string,10);
					 strcat(a[num_cycle],string);
				     }
				 }
				 break;
			     }
		    case 23: {
				 Bnext_lex();
				 strcat(a[num_cycle],"*");
				 if (lex==0) {
				     Bnext_lex(); BCycleArith_expr();
				 }
				 else {
				     Bnext_lex();
				     if (lexold1==41) {
					 strcat(a[num_cycle],masIDN[lex]);
				     }
				     else {
					 itoa(lex,string,10);
					 strcat(a[num_cycle],string);
				     }
				 }
				 break;
			     }
		}
		Bnext_lex();
	    }
	    return;
	}
	if (lex==21) {
	    while ((lex==9)||(lex==21)||(lex==22)||(lex==23)) {
		switch (lex) {
		    case 9: {
				Bnext_lex();
				strcat(a[num_cycle],"+");
				if (lex==0) {
				    Bnext_lex(); BCycleArith_expr();
				}
				else {
				    Bnext_lex();
				    if (lexold1==41) {
					strcat(a[num_cycle],masIDN[lex]);
				    }
				    else {
					itoa(lex,string,10);
					strcat(a[num_cycle],string);
				    }
				}
				break;
			    }
		    case 21: {
				 Bnext_lex();
				 strcat(a[num_cycle],"-");
				 if (lex==0) {
				     Bnext_lex(); BCycleArith_expr();
				 }
				 else {
				     Bnext_lex();
				     if (lexold1==41) {
					 strcat(a[num_cycle],masIDN[lex]);
				     }
				     else {
					 itoa(lex,string,10);
					 strcat(a[num_cycle],string);
				     }
				 }
				 break;
			     }
		    case 22: {
				 Bnext_lex();
				 strcat(a[num_cycle],"/");
				 if (lex==0) {
				     Bnext_lex(); BCycleArith_expr();
				 }
				 else {
				     Bnext_lex();
				     if (lexold1==41) {
					 strcat(a[num_cycle],masIDN[lex]);
				     }
				     else {
					 itoa(lex,string,10);
					 strcat(a[num_cycle],string);
				     }
				 }
				 break;
			     }
		    case 23: {
				 Bnext_lex();
				 strcat(a[num_cycle],"*");
				 if (lex==0) {
				     Bnext_lex(); BCycleArith_expr();
				 }
				 else {
				     Bnext_lex();
				     if (lexold1==41) {
					 strcat(a[num_cycle],masIDN[lex]);
				     }
				     else {
					 itoa(lex,string,10);
					 strcat(a[num_cycle],string);
				     }
				 }
				 break;
			     }
		}
		Bnext_lex();
	    }
	    return;
	}
	if (lex==0) {
	    strcat(a[num_cycle],"(");
	    while (lex!=1) {
		Bnext_lex(); BCycleArith_expr();
	    }
	    strcat(a[num_cycle],")");
	    return;
	}
    }
}
