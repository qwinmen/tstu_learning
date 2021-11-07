uses crt;
var  kodf,vpf:text;
     kod{suda schit kody iz fayla}:array[1..25] of string;
     s:string;
     i{sch kodov},n{kolvo kodov},k{sch chetv}:integer;
     ch1,ch2:char;
     chetv{massiv chetv}:array[1..25,1..4] of string;

     Procedure ErrorMessage(st:string);
      begin
       writeln('Syntaxis Error in Program : ',st);
       writeln('Exiting the programm...');
       halt;
      end;

     procedure Prisv;
     begin
     inc(k);
     chetv[k,1]:=kod[i];
     chetv[k,2]:=kod[i+1]+' '+kod[i+2];
     chetv[k,4]:=kod[i-2]+' '+kod[i-1];
     inc(i,2);
     end;

     procedure ObrIf;
      begin
       if (kod[i+2]<>'8') then ErrorMessage('!!!Error in If expression(No identificator found)!!!');
       inc(k);
       if kod[i+4]='7'  then chetv[k,1]:='<=' else
         ErrorMessage('!!!Error in If expression!!!');
       if (kod[i+5]<>'8') then ErrorMessage('!!!Error in If expression(No identificator found)!!!');
       chetv[k,2]:=kod[i+2]+' '+kod[i+3];
       chetv[k,3]:=kod[i+5]+' '+kod[i+6];
       str(k+2,s);
       chetv[k,4]:='goto '+s;
       inc(i,8);
       repeat
       inc(i);
       if ((kod[i]='1')and(kod[i-1]<>'8')and(kod[i-1]<>'9'))then Prisv;
       until(kod[i]='3');{do "type"}
      end;

      Procedure Vyvod;
      begin
       inc(k);
       chetv[k,1]:=kod[i];
       chetv[k,2]:=kod[i+1];
       inc(k);
       chetv[k,1]:='Param';
       chetv[k,2]:=kod[i+3]+' '+kod[i+4];
       inc(i,3);
      end;

begin
clrscr;
assign(kodf,'kod.txt');
assign(vpf,'Vnpr.txt');
reset(kodf);
rewrite(vpf);
writeln('Vot takie vot chetvñrki:');
writeln;
n:=0;     k:=0;
repeat
read(kodf,ch1);
if ch1<>' ' then
   begin
   inc(n);
   read(kodf,ch2);
   if ch2<>' ' then kod[n]:=ch1+ch2 else kod[n]:=ch1;
   end;
until eof(kodf);
 i:=1;
 repeat
  if ((kod[i]='2')and(kod[i-1]<>'8')) then ObrIf;
  if ((kod[i]='1')and(kod[i-1]<>'8')and(kod[i-1]<>'9'))then Prisv;
  if (kod[i]='3') then Vyvod;
  Inc(i);
 until i>n;
 for i:=1 to k do
 begin
 writeln(i:4,chetv[i,1]:9,chetv[i,2]:9,chetv[i,3]:9,chetv[i,4]:9);
 writeln(vpf,i:4,chetv[i,1]:9,chetv[i,2]:9,chetv[i,3]:9,chetv[i,4]:9);
 end;
close(vpf);
readkey;
end.