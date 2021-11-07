uses crt;
Var
i,j,n,k1,k2,l{счётчик кол-ва удаляемых эл-ов},j2{счётчик i},v:Integer;
a:array[1..11,1..11] of Char;
st{строка с предшествованиями}:array[1..25] of Char;
fr:Text;
s:integer;
fl,fl1:Boolean;
poss{строка с кодировками},id{строка, в которой хранятся исключённые фрагменты}:array[1..25] of Integer;
us{№ boolean i} : Integer;

Procedure Udalenie(Var num,count:integer);{удаляет из строки с кодировкой коды
отработанных выражений:num -откуда, count-сколько}
 Var i:integer;
  Begin
   For i:=num+count to n do
    poss[i-count]:=poss[i];
   n:=n-count;
  End;

Begin
 clrscr;
 For i:=1 to 10 do
   For j:=1 to 10 do
   a[i,j]:='q';

 a[1,2]:='>';
 a[1,6]:='>';
 a[1,10]:='<';
 a[1,9]:='<';

 a[2,3]:='=';

 a[3,4]:='<';
 a[3,5]:='=';
 a[3,9]:='<';

 a[4,5]:='>';
 a[4,9]:='<';

 a[5,9]:='>';

 a[6,6]:='<';
 a[6,7]:='=';
 a[6,9]:='<';

 a[7,8]:='=';

 a[8,9]:='<';
 a[8,11]:='>';

 a[9,1]:='>';
 a[9,4]:='>';
 a[9,6]:='>';
 a[9,5]:='>';
 a[9,11]:='>';

 a[10,2]:='>';



 Assign(fr,'kodyar2.txt');
 Reset(fr);
 n:=0;j2:=0;
 While not EOF(fr) do
  Begin
   Readln(fr,s);
   Inc(n);
   poss[n]:=s;
  End;
 Close(fr);
 fl:=true;
 {начало проги}
 Repeat

  i:=1;
  j:=1;
  st[1]:='<';{ставим 'if'у < по умолчанию}
  Repeat
   fl1:=false;

   While poss[i]=0 do {пo массиву кодировок:0 - если затёрт идент/конст}
    Inc(i);
   k1:=i;{n-ый код}
   If (poss[i]=9) or (poss[i]=10) then
    Inc(i);
   Inc(i);
   While poss[i]=0 do
    Inc(i);
   k2:=i;{n+1- код}
   Inc(j);{счётчик строки приоритетов}
   st[j]:=a[poss[k1],poss[k2]];{записываем в строку приоритетов приоритет}
   If st[j]='q' then
      Begin
       Writeln('Ошибка');
       writeln(st[j]);
       Halt;
      End;
    If st[j]='>' then fl1 := True;
  Until fl1=true;
{ Удаление идентификаторов и констант }
  If (poss[k1]=9)or(poss[k1]=10) then
   Begin
    id[k1]:=poss[k1];
    id[k1+1]:=poss[k1+1];
    poss[k1]:=0;
    poss[k1+1]:=0;
   End
{ Четверки }
else
  If poss[k1]=1 then            {  Присваивание  }
   Begin
    Write(poss[k1]:8);
     Write(id[k1+1]:8,' ',id[k1+2]);
     Write(id[k1-2]:17,' ',id[k1-1]);
    l:=5;
    k1:=k1-2;
    Udalenie(k1,l);
    Writeln;
   End
else

  If poss[k1]=8{если ',' то type} then  {  Условие   }
   Begin
    Write(poss[k1-2]:8);
      Writeln(poss[k1-1]:8);
      write('Param':8);
      Write(id[k1+1]:8,' ',id[k1+2]);
      Writeln;
    k1:=k1-2;
    l:=5;
    Udalenie(k1,l);
   Writeln;
   End
else

  If poss[k1]=4{.gt.} then  {  Условие   }
   Begin
    Write(poss[k1]:8);
      Write(id[k1-2]:8,' ',id[k1-1]);
      Write(id[k1+1]:8,' ',id[k1+2]);
    Inc(j2);
    Write('i':8,j2);
    id[k1-2]:=20;
    id[k1-1]:=j2;
    Writeln;
    l:=3;
    Udalenie(k1,l);
   End
else
  If poss[k1]=5{если ')'} then {обработка if}
   Begin
    Write('not i':7,id[k1-1],'Go to 6':29);
    us:=id[k1-1];
    l:=5;
    k1:=k1-4;
    Udalenie(k1,l);
    Writeln;
   End
else
     Begin
      writeln(poss[k1],' ',poss[k2]);
      writeln('Oshibka');
      Halt;
     End;
 Until n=1 ;
readln;
End.