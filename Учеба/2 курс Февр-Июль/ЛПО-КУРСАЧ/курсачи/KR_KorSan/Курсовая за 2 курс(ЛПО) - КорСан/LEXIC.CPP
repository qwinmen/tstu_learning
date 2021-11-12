#include "lexic.h"
#define usl1 ((sim<91)&&(sim>64))
#define usl2 ((sim<123)&&(sim>96))
#define usl3 ((sim<58)&&(sim>47))
#define	usl5 ((sim!=33)||(sim!=38)||(sim!=43)||(sim!=45)||(sim!=60)||(sim!=61)||(sim!=62)||(sim!=124))

void CLexic::view_if()
{
    FILE *in;
    in = fopen("textpro.dat", "rb");

    while(!feof(in)) cout<< char(fgetc(in));

    fclose(in);
}

void CLexic::analiz()
{
    FILE *in;
    int sim;

    in=fopen("textpro.dat", "rb");

    int j;
    i=0;

    for(j=0;j<20;j++) {
	a[j]=0;
    }
    FlagOutL=1;

    while(!feof(in)) {
	sim=fgetc(in);

	if (usl1||usl2||usl3) {
	    FlagBukvaCifra=1;
	    if (FlagOutL==1) {
		if usl3 FlagCifra=1;
		else FlagCifra=0;
	    }
	    if (FlagOutL==0) {
		if (FlagCifra==1) if (usl1||usl2) mistake();
	    }
	    a[i++]=sim;
	    FlagOutL=0;

//	    if ((FlagBukvaCifra==0)&&(FlagOutL!=1)) {
//		findlex();
//	    }

//	    if (usl3) {
//		if (FlagBukvaCifra==0) {
//		    FlagBeginCifra=1;
//		}
//		a[i++]=sim; FlagCifra=1; FlagOutL=0;
//	    }
//	    else {
//		if (FlagBeginCifra==1) {
//		    mistake();
//		}
//		a[i++]=sim; FlagOutL=0; FlagBeginCifra=0; FlagBukva=1;
//	    }
//	    FlagBukvaCifra=1;
	}
	else {
	    if (FlagBukvaCifra==1) findlex();
	    FlagBukvaCifra=0;
	    findlex();
//	    if (sim!=32) {
//		if (usl5) {
//			findlex();
//			a[i++]=sim;
//			FlagOutL=0;
//			flag5=0;
//		}
//		else {
//		    if (flag5==1) {
//			a[i++]=sim;
///			FlagOutL=0;
//			findlex();
//		    }
//		    else {
 //			findlex();
//			a[i++]=sim;
//			FlagOutL=0;
//		    }
//		    flag5=1;
//		}
//	    }
//	    else {
 //		if (FlagOutL!=1) {
//		    findlex();
//		}
//
//	    }
//	    FlagBukvaCifra=0;
//	    FlagBukva=0;
	}
    }
    fclose(in);
}

void CLexic::findlex()
{
   cout << a << endl;
/*    //FILE *out;
    int p,j,con;
    char o;
    //out=fopen("lexic.rez","wb");

    if ((FlagBukvaCifra==0)&&(FlagCifra==1)&&(FlagBukva==0)) {
	fprintf(out," %d",42);
	//fputc(42,out);
	con=10;//atoi(a);
	fprintf(out," %d,",con);
	FlagOutL=1;
	//fputc(con,out);//вывожу цифру
    }

    for(o=0;o<40;o++) {
	for(p=0;p<10;p++) {
	    if (a[p]==masNTS[o][p]) {
		FlagLex=1;
	    }
	    else {
		FlagLex=0; break;
	    }
	}
	if (FlagLex==1) {
	    fprintf(out," %d,",int(o));
	    FlagOutL=1;
	    //fputc(o,out);
	}
    }

    if (FlagOutL!=1) {
	fprintf(out," %d",41);
	//fputc(42,out);
	fprintf(out," %d,",int(a));
	//fputc(con,out);//вывожу цифру
    }
 */
    for(int j=0;j<20;j++)
	a[j]=0;

    i=0;
    FlagOutL=1;
    //fclose(out);
}

void CLexic::readdat()
{
    FILE *dat;
    char sim2;
    int x,y;
    x=0; y=0;
    dat=fopen("simbol.NTS","rb");

    for(x=0;x<40;x++) {
	for(y=0;y<10;y++) {
	    masNTS[x][y]=0;
	}
    }
    x=0; y=0;

    while(!feof(dat)) {
	sim2=fgetc(dat);
	if (sim2==-1) {
	    masNTS[x][y]=0;
	    //ss[y]=0;
	    countNTS=x;
	    break;
	    //strcpy(masNTS[x],ss);
	}

	if ((sim2!=10)&&(sim2!=13)) {
	    masNTS[x][y]=sim2;
	    //ss[y]=sim2;
	    y=y+1;
	}
	else {
	    if (sim2==13) {
		masNTS[x][y]=0;
 //		ss[y]=0;
   //	    strcpy(masNTS[x],ss);

		y=0; x=x+1;
	    }
	}
    }
    for(x=0;x<=countNTS;x++) {
//    	y=0;
//	while (masNTS[x][y]!=0){
		cout << masNTS[x]<<endl;//[y++];
	//}
    }
    fclose(dat);
}

void CLexic::begin()
{
    out=fopen("lexic.rez","wb");
}

void CLexic::end()
{
    fclose(out);
}

void CLexic::mistake()
{
}

void CLexic::view_of()
{
}