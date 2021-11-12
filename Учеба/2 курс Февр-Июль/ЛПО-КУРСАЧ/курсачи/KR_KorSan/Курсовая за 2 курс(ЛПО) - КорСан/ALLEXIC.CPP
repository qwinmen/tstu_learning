#include "lexic.h"
#define usl1 ((sim<91)&&(sim>64))
#define usl2 ((sim<123)&&(sim>96))
#define usl3 ((sim<58)&&(sim>47))
#define	usl5 ((sim!=33)&&(sim!=38)&&(sim!=43)&&(sim!=45)&&(sim!=60)&&(sim!=61)&&(sim!=62)&&(sim!=124))

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
    int sim,simold;

    begin();
    in=fopen("textpro.dat", "rb");

    int j;
    i=0;

    for(j=0;j<20;j++) {
	a[j]=0;
    }

    while(!feof(in)) {
	sim=fgetc(in);
	if (sim==13) {
	    FlagEndLine=1;
	}
	if (sim==13||sim==10) continue;
	if (usl1||usl2||usl3) {
	    if ((FlagBukvaCifra==0)&&(FlagOutL==0)&&(simold!=92)) {
		findlex(); simold=sim;
	    }
	    if ((FlagBukvaCifra==0)&&(FlagOutL==0)&&(simold==92)) {
		a[i++]=sim; FlagOutL=0; findlex(); simold=sim; continue;
	    }
	    if (usl3) {
		if (FlagBukvaCifra==0) {
		    FlagBeginCifra=1;
		}
		a[i++]=sim; FlagCifra=1; FlagOutL=0;
	    }
	    else {
		if (FlagBeginCifra==1) {
		    fputc(cstrok,mistake);
		    fputc(3,mistake);
		}
		a[i++]=sim; FlagOutL=0; FlagBeginCifra=0; FlagBukva=1;
	    }
	    FlagBukvaCifra=1; flag5=0;
	}
	else {
	    if (sim!=32) {
		if (usl5) {
			if (FlagOutL==0) {
			    findlex(); simold=sim;
			}
			a[i++]=sim;
			FlagOutL=0;
			flag5=0;
		}
		else {
		    if (flag5==1) {
			a[i++]=sim;
			FlagOutL=0;
			findlex();
			simold=sim;
		    }
		    else {
			findlex();
			simold=sim;
			a[i++]=sim;
			FlagOutL=0;
		    }
		    flag5=1;
		}
	    }
	    else {
		if (FlagOutL!=1) {
		    findlex(); simold=sim;
		}

	    }
	    FlagBukvaCifra=0;
	    FlagBeginCifra=0;
	    FlagBukva=0;
	    FlagCifra=0;
	}
    }
    fclose(in);
    end();
}

void CLexic::findlex()
{
    int p,j,con,n,m,l,h;
    char o;

    if ((FlagBukvaCifra==1)&&(FlagCifra==1)&&(FlagBukva==0)) {
	printf(" %d",42);
	fputc(42,out);
	con=atoi(a);
	printf(" %d,",con);
	fputc(con,out);//вывожу цифру
	FlagOutL=1;
	if (FlagEndLine==1) {
	    cstrok=cstrok+1;
	    fputc(100,out);
	    FlagEndLine=0;
	}
    }

    if (FlagOutL!=1) {
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
		//fprintf(out," %d,",int(o));
		printf(" %d,",int(o));
		fputc(o,out);
		if (FlagEndLine==1) {
		    cstrok=cstrok+1;
		    fputc(100,out);
		    FlagEndLine=0;
		}
		if (int(o)==15) {
		    FlagDeclare=1;
		}
		if (int(o)==16) {
		    FlagDeclare=2;
		}
		if (int(o)==4) {
		    FlagDeclare=0;
		}
		FlagOutL=1; break;
	    }
	}
    }

    if (FlagOutL!=1) {
	fputc(41,out); // вывожу цифру
	heshidn=hesh();
	fputc(heshidn,out); // вывожу цифру
	printf(" %d",41);
	printf(" %d,",heshidn);
	if (FlagEndLine==1) {
	    cstrok=cstrok+1;
	    fputc(100,out);
	    FlagEndLine=0;
	}

	if (i>2) {
	    for(o=0;o<40;o++) {
		m=0; n=0; l=0; h=0;
		for(p=0;p<10;p++) {
		    if (a[p]==0) break;
		    if (a[p]==masNTS[o][p]) {
			FlagLex=1;
			m=m+1;
		    }
		    else {
			FlagLex=0;
			if((a[p+1]==masNTS[o][p])||(a[p]==masNTS[o][p+1])) {
			    if (a[p+1]==masNTS[o][p]) {
				FlagLex=1;    //лишняя буква
				l=l+1;
			    }
			    if (a[p]==masNTS[o][p+1]) {
				FlagLex=1;    //нехватает буквы
				h=h+1;
			    }
			}
			else n=n+1;
		    }
		}
		if ((m+1==p)&&(l==0)&&(h==0)) {
		    cout << "В лексеме "<< int(o) << heshidn << "одна букава перепутана";
		    fputc(cstrok,mistake);
		    fputc(12,mistake);
		}
		if (l==p-m) {
		    cout << "Лишняя буква в лексеме "<< int(o) << heshidn;
		    fputc(cstrok,mistake);
		    fputc(11,mistake);
		}
		if (h==p-m) {
		    cout << "Пропущна буква в лексеме "<< int(o) <<heshidn;
		    fputc(cstrok,mistake);
		    fputc(10,mistake);
		}
	    }
	}
    }

    for(j=0;j<20;j++)
	a[j]=0;

    i=0;
    FlagOutL=1;
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

    for(x=0;x<20;x++) {
	for(y=0;y<10;y++) {
	    masIDN[x][y]=0;
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
//	cout << masNTS[x]<<endl;//[y++];
	//}
    }
    fclose(dat);
}

void CLexic::begin()
{
    view_if();
    readdat();

    q=0; w=-1; cstrok=1;
    FlagOutL=1; FlagBukvaCifra=0; FlagDeclare=0;
    FlagBeginCifra=0; FlagCifra=0; FlagEndLine=0;
    FlagBukva=0; flag5=0; FlagLex=0;
    out=fopen("lexic.rez","wb");
    listIDN=fopen("listidn.dat","wb");
    mistake=fopen("mistake.rez","wb");
}

void CLexic::end()
{
    fclose(out);
    fclose(listIDN);
    fclose(mistake);
}

int CLexic::hesh()
{
    int r,t;
    w=w+1;
    for(t=0;t<10;t++) {
	masIDN[w][t]=a[t];
    }

    for(r=0;r<=w;r++) {
	FlagIDN=0;
	for(t=0;t<10;t++) {
	    if (masIDN[r][t]==a[t]) {
		FlagIDN=1;
	    }
	    else {
		FlagIDN=0; break;
	    }
	}
	if (FlagIDN==1) {
	    if (r<w) {
		if (FlagDeclare>0) {
	 //	    cout << "повторное описание идентификатора";
		    fputc(cstrok,mistake);
		    fputc(2,mistake);
		}
		for(t=0;t<10;t++) {
		    masIDN[w][t]=0;
		}
		w=w-1;
	    }
	    else {
		if (FlagDeclare==0) {
		    fputs(a,listIDN);
		    fputs(" ",listIDN);
		    fputc(FlagDeclare,listIDN);
		    fputc(13,listIDN);
	 //	    cout << "идентификатор не обявлен";
		    fputc(cstrok,mistake);
		    fputc(1,mistake);
		}
		if (FlagDeclare==1) {
		    fputs(a,listIDN);
		    fputs(" ",listIDN);
		    fputc(FlagDeclare,listIDN);
		    fputc(13,listIDN);
		}
		if (FlagDeclare==2) {
		    fputs(a,listIDN);
		    fputs(" ",listIDN);
		    fputc(FlagDeclare,listIDN);
		    fputc(13,listIDN);
		}
	    }
	    return(r);
	}
    }
}

void CLexic::Lmistake()
{
    int nostroki,nooshibki;
    mistake=fopen("mistake.rez","rb");
    while (nostroki!=-1) {
	nostroki=int(fgetc(mistake));
	nooshibki=int(fgetc(mistake));
	switch (nooshibki) {
	    case 1: cout<< nostroki<< " идентиф. не объявлен"<< endl; break;
	    case 2: cout<< nostroki<< " повторное описание идентиф."<< endl; break;
	    case 3: cout<< nostroki<< " идентиф. начинается с цифры"<< endl; break;
	    case 4: cout<< nostroki<< " нет символа ("<< endl; break;
	    case 5: cout<< nostroki<< " нет символа )"<< endl; break;
	    case 6: cout<< nostroki<< " нет символа { в начале программы"<< endl; break;
	    case 7: cout<< nostroki<< " нет символа }"<< endl; break;
	    case 8: cout<< nostroki<< " нет символа {"<< endl; break;
	    case 9: cout<< nostroki<< " нет символа ;"<< endl; break;
	    case 10: cout<< nostroki<< " возможно, пропущена буква в лексеме"<< endl; break;
	    case 11: cout<< nostroki<< " возможно, лишняя буква в лексеме"<< endl; break;
	    case 12: cout<< nostroki<< " возможно, перепутана буква в лексеме"<< endl; break;
	    case 13: cout<< nostroki<< " лишний символ , | пропущен идентиф."<< endl; break;
	    case 14: cout<< nostroki<< " нет символа & "<< endl; break;
	    case 15: cout<< nostroki<< " нет символа \""<< endl; break;
	    case 16: cout<< nostroki<< " неправильно записана операция присвоения"<< endl; break;
	    case 17: cout<< nostroki<< " неправильно записана арифметическая операция"<< endl; break;
	}
    }
    fclose(mistake);
}

void CLexic::view_of()
{
}