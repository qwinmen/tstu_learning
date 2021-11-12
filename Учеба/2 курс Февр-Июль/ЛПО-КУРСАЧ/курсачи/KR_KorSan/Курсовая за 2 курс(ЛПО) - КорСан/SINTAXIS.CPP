#include "sintaxis.h"

void CSintaxis::next_lex()
{
    lexold3=lexold2;
    lexold2=lexold1;
    lexold1=lex;
    lex=int(fgetc(lrez));

    if ((lex==100)&&(lexold1!=42)&&(lexold1!=41)) {
	cstrok=cstrok+1;
	lex=int(fgetc(lrez));
    }
    if ((lex==2)&&(lexold1!=42)&&(lexold1!=41)) num_skobki=num_skobki+1;
    if ((lex==3)&&(lexold1!=42)&&(lexold1!=41)) num_skobki=num_skobki-1;
}

void CSintaxis::list_oper()
{
    next_lex();
    if (lex==2) {
	FlagBegin=0;
	next_lex();
	while ((lex!=3)&&(lex!=-1)) {
	    declare();
	    introduce();
	    conclusion();
	    appropriate();
	    cycle();
	    next_lex();
	}
    }
    else {
	introduce();
	conclusion();
	appropriate();
	cycle();
    }
}

void CSintaxis::list_IDN()
{
    next_lex();
    if ((lex==41)||(lex==20)) {
	if (lex==41) {
	    next_lex();
	    next_lex();
	    while(lex==5) {
		next_lex();
		if (lex==41) {
		    next_lex();
		}
		else {
		    fputc(cstrok,mistake);
		    fputc(13,mistake);
		}
		next_lex();
	    }
	}
	else {
	    next_lex();
	    if (lex==41) {
		next_lex();
		next_lex();
		while(lex==5) {
		    next_lex();
		    if (lex==20) {
			next_lex();
			if (lex==41) {
			    next_lex();
			}
			else {
			    fputc(cstrok,mistake);
			    fputc(9,mistake);
			}
			next_lex();
		    }
		    else {
			fputc(cstrok,mistake);
			fputc(14,mistake);
		    }
		}
	    }
	    else {
		fputc(cstrok,mistake);
		fputc(13,mistake);
	    }
	}
    }
}

void CSintaxis::arith_expr()
{
    if ((lex==0)||(lex==41)||(lex==42)||(lex==21)) {
	if ((lex==41)||(lex==42)) {
	    next_lex();
	    next_lex();
	    while ((lex==9)||(lex==21)||(lex==22)||(lex==23)) {
		switch (lex) {
		    case 9: {
				next_lex();
				if (lex==0) {
				    next_lex(); arith_expr();
				}
				else next_lex();
				break;
			    }
		    case 21: {
				 next_lex();
				 if (lex==0) {
				     next_lex(); arith_expr();
				 }
				 else next_lex();
				 break;
			     }
		    case 22: {
				 next_lex();
				 if (lex==0) {
				     next_lex(); arith_expr();
				 }
				 else next_lex();
				 break;
			     }
		    case 23: {
				 next_lex();
				 if (lex==0) {
				     next_lex(); arith_expr();
				 }
				 else next_lex();
				 break;
			     }
		}
		next_lex();
	    }
	    return;
	}
	if (lex==21) {
	    while ((lex==9)||(lex==21)||(lex==22)||(lex==23)) {
		switch (lex) {
		    case 9: {
				next_lex();
				if (lex==0) {
				    next_lex(); arith_expr();
				}
				else next_lex();
				break;
			    }
		    case 21: {
				 next_lex();
				 if (lex==0) {
				     next_lex();
				     arith_expr();
				 }
				 else next_lex();
				 break;
			     }
		    case 22: {
				 next_lex();
				 if (lex==0) {
				     next_lex(); arith_expr();
				 }
				 else next_lex();
				 break;
			     }
		    case 23: {
				 next_lex();
				 if (lex==0) {
				     next_lex(); arith_expr();
				 }
				 else next_lex();
				 break;
			     }
		    default: {
				 fputc(cstrok,mistake);
				 fputc(17,mistake);
				 break;
			     }
		}
		next_lex();
	    }
	    return;
	}
	if (lex==0) {
	    while (lex!=1) {
		next_lex(); arith_expr();
	    }
	    return;
	}
    }
    else {
	fputc(cstrok,mistake);
	fputc(17,mistake);
    }
}

void CSintaxis::declare()
{
    if (FlagBegin!=0) {
	fputc(cstrok,mistake);
	fputc(6,mistake);
    }
    if (lex==15) {
	list_IDN();
	if (lex==4) {
	    return;
	}
	else {
	    fputc(cstrok,mistake);
	    fputc(9,mistake);
	}
    }
    if (lex==16) {
	list_IDN();
	if (lex==4) {
	    return;
	}
	else {
	    fputc(cstrok,mistake);
	    fputc(9,mistake);
	}
    }
}

void CSintaxis::begin_program()
{
    next_lex();
    if (lex==14) {
	FlagBegin=1;
	next_lex();
	if (lex==0) {
	    next_lex();
	    if (lex==1) {
	    }
	    else {
		fputc(cstrok,mistake);
		fputc(5,mistake);
	    }
	}
	else {
	    fputc(cstrok,mistake);
	    fputc(4,mistake);
	}
    }
}

void CSintaxis::introduce()
{
    if (FlagBegin!=0) {
	fputc(cstrok,mistake);
	fputc(6,mistake);
    }
    if (lex==17) {
	next_lex();
	if (lex==0) {
	    next_lex();
	    if (lex==6) {
		next_lex();
		while (lex!=6) next_lex();
		next_lex();
		if (lex==5) {
		    list_IDN();
		    if (lex==1) {
			next_lex();
			if (lex==4) {
			}
			else {
			    fputc(cstrok,mistake);
			    fputc(9,mistake);
			}
		    }
		    else {
			fputc(cstrok,mistake);
			fputc(5,mistake);
		    }
		}
	    }
	    else {
		fputc(cstrok,mistake);
		fputc(15,mistake);
	    }
	}
	else {
	    fputc(cstrok,mistake);
	    fputc(4,mistake);
	}
    }
}

void CSintaxis::conclusion()
{
    if (FlagBegin!=0) {
	fputc(cstrok,mistake);
	fputc(6,mistake);
    }
    if (lex==19) {
	next_lex();
	if (lex==0) {
	    next_lex();
	    if (lex==6) {
		next_lex();
		while (lex!=6) next_lex();
		next_lex();
		if (lex==5) {
		    list_IDN();
		    if (lex==1) {
			next_lex();
			if (lex==4) {
			}
			else {
			    fputc(cstrok,mistake);
			    fputc(9,mistake);
			}
		    }
		    else {
			fputc(cstrok,mistake);
			fputc(5,mistake);
		    }

		}
	    }
	    else {
		fputc(cstrok,mistake);
		fputc(15,mistake);
	    }
	}
	else {
	    fputc(cstrok,mistake);
	    fputc(4,mistake);
	}
    }
}

void CSintaxis::condition()
{
    next_lex();
    if ((lex==0)||(lex==41)||(lex==42)) {
	if (lex==0) {
	    next_lex();
	    condition();
	    if (lex==1) {
	    }
	    else {
		fputc(cstrok,mistake);
		fputc(5,mistake);
	    }
	}
	if (lex==41) {
	    next_lex();
	    next_lex();
	    switch (lex) {
		case 10: next_lex(); arith_expr(); break;
		case 24: next_lex(); arith_expr(); break;
		case 25: next_lex(); arith_expr(); break;
		case 26: next_lex(); arith_expr(); break;
		case 27: next_lex(); arith_expr(); break;
		case 28: next_lex(); arith_expr(); break;
	    }
	}
	if (lex==42) {
	    next_lex();
	    next_lex();
	    switch (lex) {
		case 10: next_lex(); arith_expr(); break;
		case 24: next_lex(); arith_expr(); break;
		case 25: next_lex(); arith_expr(); break;
		case 26: next_lex(); arith_expr(); break;
		case 27: next_lex(); arith_expr(); break;
		case 28: next_lex(); arith_expr(); break;
	    }
	}
    }
}

void CSintaxis::appropriate()
{
    if (FlagBegin!=0) {
	fputc(cstrok,mistake);
	fputc(6,mistake);
    }
    int a,b;

    if (lex==41) {
	next_lex();
	next_lex();
	if ((lex==8)||(lex==11)) {
	    if (lex==8) {
		a=lexold2; b=lexold1;
		next_lex();
		arith_expr();
		if ((lex==4)||(lex==1)) {
		}
		else {
		    fputc(cstrok,mistake);
		    fputc(9,mistake);
		}
	    }
	    else {
		a=lexold2; b=lexold1;
		next_lex();
		if ((lex==4)||(lex==1)) {
		}
		else {
		    fputc(cstrok,mistake);
		    fputc(9,mistake);
		}
	    }
	}
	else {
	    fputc(cstrok,mistake);
	    fputc(16,mistake);
	}
    }
}

void CSintaxis::cycle()
{
    if (FlagBegin!=0) {
	fputc(cstrok,mistake);
	fputc(6,mistake);
    }
    if (lex==18) {
	next_lex();
	if (lex==0) {
	    next_lex();
	    appropriate();
	    condition();
	    if (lex==4) {
		next_lex();
		appropriate();
		if (lex==1) {
		    list_oper();
		}
		else {
		    fputc(cstrok,mistake);
		    fputc(5,mistake);
		    list_oper();
		}
	    }
	    else {
		fputc(cstrok,mistake);
		fputc(9,mistake);
		next_lex();
		appropriate();
		if (lex==1) {
		    list_oper();
		}
		else {
		    fputc(cstrok,mistake);
		    fputc(5,mistake);
		    list_oper();
		}
	    }
	}
	else {
	    fputc(cstrok,mistake);
	    fputc(4,mistake);
	}
    }
}

void CSintaxis::sin_analiz()
{
    num_skobki=0; cstrok=1; FlagBegin=0;
    lrez=fopen("lexic.rez","rb");
    mistake=fopen("mistake.rez","a+b");
    begin_program();
    while (lex!=-1) {
	list_oper();
    }
    if (num_skobki>0) {
	fputc(cstrok,mistake);
	fputc(7,mistake);
    }
    if (num_skobki<0) {
	fputc(cstrok,mistake);
	fputc(8,mistake);
    }
    fclose(lrez);
    fclose(mistake);
}