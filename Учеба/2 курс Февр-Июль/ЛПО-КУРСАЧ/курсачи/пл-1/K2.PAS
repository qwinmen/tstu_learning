uses crt;
{*********************************ПЕРЕМЕННЫЕ*********************************}
var tabid:array[1..90]of string;
    kod:array[1..500]of integer;
    kolid,n,i,k,z:integer;
    f:text;
    a:string[8];

{*********************************ПРОЦЕДУРЫ*********************************}

procedure obr_esli;             {Обработчик если}
begin
  write(f,'if ',tabid[kod[i+2]]);
  if kod[i+3]=24 then write(f,'<')
  else if kod[i+3]=25 then write(f,'>')
       else write(f,'=');
  write(f,tabid[kod[i+5]],' then ');
  inc(i,6);
end;

procedure obr_chit_viv;         {Обработчик ввода/вывода}
begin
  write(f,a);
  inc(i,2);

  repeat
    if kod[i]=26 then write(f,'(',tabid[kod[i+1]],')') else break;
    inc(i,3);
  until false;

  writeln(f,';')
end;

procedure obr_perem;            {Обработчик раздела переменных}
begin
  write(f,'dcl (');

  for k:=i downto 1 do
  if (kod[k]=11)and(kod[k-1]<>26) then break;

  for z:=k to i do
    begin
      if (kod[z]=26)and(kod[z-1]<>26) then write(f,tabid[kod[z+1]]);
      if (kod[z]=13)and(kod[k-1]<>26) then write(f,',');
    end;
  write(f,') ');
  inc(i);
  if kod[i]=3 then writeln(f,'dec float;')
end;

procedure obr_arifm;            {Обработчик арифметических выражений}
begin
  write(f,tabid[kod[i-1]],'=');

  repeat
    case kod[i] of
      11:break;
      22:write(f,'*');
      20:write(f,'+');
      21:write(f,'-');
      23:write(f,'/');
      15:write(f,'(');
      16:write(f,')');
    end;
    z:=1;

    if kod[i]=26 then begin write(f,tabid[kod[i+1]]);z:=2 end;
    if kod[i]=27 then begin write(f,kod[i+1]);z:=2 end;
    inc(i,z);
  until false;

  writeln(f,';')
end;

procedure obr_prog;             {Обработчик заголовка программы}
begin
  writeln(f,'main options ',tabid[kod[i+2]],';');
  inc(i,3);
end;

{*****************************ОСНОВНАЯ ПРОГРАММА*****************************}

BEGIN
clrscr;
assign(f,'Tabid.txt');           {Считывание идентификаторов}
reset(f);
readln(f,kolid);
for i:=1 to kolid do
readln(f,tabid[i]);
close(f);

assign(f,'kod.txt');            {Считывание кодов}
reset(f);i:=0;
while not eof(f) do
  begin
    inc(i);
    readln(f,kod[i]);
  end;
n:=i;
close(f);

assign(f,'proga.pl1');            {Транслятор}
rewrite(f);
for i:=1 to n do begin
if(kod[i]=1)and(kod[i-1]<>26)and(kod[i-1]<>27)then obr_prog;
if(kod[i]=12)and(kod[i-1]<>26)and(kod[i-1]<>27)then obr_perem;
if(kod[i]=19)and(kod[i-1]<>26)and(kod[i-1]<>27)then obr_arifm;
if(kod[i]=5)and(kod[i-1]<>26)and(kod[i-1]<>27)then obr_esli;
if((kod[i]=10)or(kod[i]=18))and(kod[i-1]<>26)and(kod[i-1]<>27)then writeln(f,'end;');
if((kod[i]=9)or(kod[i]=17))and(kod[i-1]<>26)and(kod[i-1]<>27)then writeln(f,'do;');
if((kod[i]=4)or(kod[i]=8))and(kod[i-1]<>26)and(kod[i-1]<>27)then
  begin
    if(kod[i]=4)then begin a:='getlist';obr_chit_viv;end
    else begin a:='putlist';obr_chit_viv;end;
  end;
if kod[i]=7 then write(f,'else ');
end;
close(f);

reset(f);                         {Вывод на экран файла}
while not eof(f) do
  begin
    readln(f,tabid[1]);
    writeln(tabid[1])
  end;
close(f);

assign(f,'kod.txt');               {Удаление временных файлов}
erase(f);
assign(f,'tabid.txt');
erase(f);

readkey;
END.