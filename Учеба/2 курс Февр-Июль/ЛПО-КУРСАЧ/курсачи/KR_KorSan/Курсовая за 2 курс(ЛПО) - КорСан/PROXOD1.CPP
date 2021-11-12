#include<iostream.h>
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<io.h>
#include<string.h>
#include"allexic.cpp"
#include"sintaxis.cpp"
#include"broadcas.cpp"

void main() {
    clrscr();
    CLexic lexem;
    CSintaxis sintax;
    CBroadcast broadc;
    lexem.analiz();
    sintax.sin_analiz();
    lexem.Lmistake();
    broadc.Bgeneral();
    getch();
}