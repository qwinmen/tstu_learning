uses crt;
var filename:text;
    stroka,tip,numstr,kod,numfun,strindex:string;
    iden:char;
    tabl: array[1..20,1..4]of string;
    fun: array[1..10]of integer;
    i,num,numold,j,index,chain,code:integer;
    z:longint;
    err:boolean;

begin
clrscr;
err:=false;
assign(filename,'c:\var.txt');
reset(filename);
readln(filename,stroka);
if stroka='var' then begin
num:=0;
for i:=1 to 10 do
fun[i]:=0;
while stroka<>'' do begin
readln(filename,stroka);
if stroka='' then break;
numold:=num+1;
i:=1;
repeat

case stroka[i] of
   ',':  i:=i+1;
   ':':
     begin
         tip:='';
         repeat
          i:=i+1;
          if stroka[i]<>';' then
          tip:=tip+stroka[i];
         until stroka[i]=';';
      end;

    ';':
        begin
        i:=i+1;
        for j:=numold to num do
         tabl[j,2]:=tip;
        end
      else begin
         iden:=stroka[i];
         i:=i+1;
         num:=num+1;
         tabl[num,1]:=iden;
           str(ord(iden),kod);
         tabl[num,4]:=kod;


         z:=Ord(iden) mod 10 + 1;
         if fun[z]=0 then fun[z]:=num
          else begin
            index:=fun[z];
            repeat
            if tabl[index,1]=iden then
             begin
             err:=true;
             writeln('Dublecate identifier ',iden);
             break;end else begin
            val(tabl[index,3],chain,code);
            if chain<>0 then
            begin
            strindex:=tabl[index,3];
            val(strindex,index,code);
            end
            else begin
            str(num,numfun);
            tabl[index,3]:=numfun;
             break;end; end;
            until false;

           end;
       end;
     end;
until i>length(stroka);
end;
write('Hesh Function  : ');
           for j:=1 to 10 do
           write('   ',fun[j]);
writeln;

if err then writeln('                ERROR') else begin

for i:=1 to num do
begin
write(' ',i:2);
for j:=1 to 4 do
write(' ',tabl[i,j]:17);
writeln;
end;
writeln;
writeln('  Функция : остаток от деления кода идентификатора на 10');
end;
end;
readln;
end.