# include <stdio.h>
# include <string.h>
int main ()
{
 FILE *f,*ff;
 char s[255],s1[255],s2[255],smax[255];
 int i,ii,n,k,l,lmax=0;
 clrscr ();
 printf("IMIA ISX FILE"); scanf("%s",&s);
 f=fopen (s,"wt");
  fclose (f);



  f=fopen (s,"rt"); /*otkruvaem fail dla chtenua*/
 if(f==NULL)
  {
	printf ("can't find ");
	getch();
	return -1;
 }
  printf("IMIA FILE RESULT"); scanf("%s",&s);
	ff=fopen (s,"wt"); /*otkruvaem fail dla zapisi*/
 if(ff==NULL)
  {
	printf (" Не открыл");
	getch();
	return -1;
 }
 printf ("vvodite dannie v fail");
 getch();

 while(fgets(s,255,f)!=NULL)
 {
 //puts(s);

 strcat(s," "); /*pribavl probel v konec*/

 strcpy(s1," ");strcat(s1,s); strcpy(s,s1);  /*probel v nachalo*/

strcpy(s1," ");  /*v s1 zagonaet probel*/
mmm:
 for(i=0;i<=strlen(s);i++)  /*dvugaet po ctroke*/
 {
	if(s[i]==' ' &&  s[i+1]!=' ') n=i+1;  /*uchet nachalo*/
	if(s[i]!=' ' &&  (s[i+1]==' ' ||  s[i+1]==10))     /*conec*/
	{
		k=i+1;
		l=k-n;
		strncpy(s2,s+n,l); s2[l]= '\0';/*vurezaet slovo*/
		if(strcmp(s1,s2)==0)    /*sravnuvaet s predudychem*/
		{
			for(ii=n;ii<=strlen(s);ii++) s[ii]=s[ii+l+1];  /*udalaet clovo*/
			 strcpy(s1," ");
			 goto mmm;
		}
		strcpy(s1,s2);  /*v predudychee zapucuvaet cleduchee*/
		if(l>lmax) {lmax=l;	strcpy(smax,s2);} /*uchet max dlun clova*/

  }
  }
 // puts(s);
  fputs(s,ff);
}

 fprintf(ff,"\nSAMOE DLINNOE SLOVO      %s",smax);
 fclose (f);
 fclose (ff);
 //printf("\nSAMOE DLINNOE SLOVO      %s",smax);
getch();
 return 0;
 }
