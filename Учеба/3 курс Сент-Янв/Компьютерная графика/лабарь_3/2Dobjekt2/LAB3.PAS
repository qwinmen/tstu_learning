{-------Рисуем триугольник!НЕ пирамиду---------}
uses crt,graph;
var
grdriver,grmode,errcode,i:integer;
x,y:array[1..3] of real;
xp,yp:array[1..3] of real;
ss,tt,rr,res:array[1..3,1..3] of real;
th,tx,ty,tmpx,tmpy,i1,i2,i3:real;
sym: char;

function IntToStr(I: Longint): String;
var
  S: string[11];
begin
  Str(I, S);
  IntToStr := S;
 end;

procedure paint(x1,y1,x2,y2,x3,y3:real);
begin
line(round(x1*30)+300,round(y1*30)+250,round(x2*30)+300,round(y2*30)+250);
line(round(x2*30)+300,round(y2*30)+250,round(x3*30)+300,round(y3*30)+250);
line(round(x3*30)+300,round(y3*30)+250,round(x1*30)+300,round(y1*30)+250);
end;

{-------------------------------Масштабирование----------------------------}
procedure scale(sx,sy:real);
var
i,j:integer;
begin
for i:=1 to 3 do
for j:=1 to 3 do ss[i,j]:=0;
ss[1,1]:=sx;
ss[2,2]:=sy;
ss[3,3]:=1;
end;

{------------------------------------Сдвиг---------------------------------}
procedure tran(tx,ty:real);
var i,j:integer;
begin
for i:=1 to 3 do
begin
for j:=1 to 3 do tt[i,j]:=0;
tt[i,i]:=1;
end;
tt[1,3]:=tx;
tt[2,3]:=ty;
end;

{-------------------------------Поворот------------------------------------}
procedure rotate(theta:real);
var i,j:integer; m1,m2,c,s:real;
begin
for i:=1 to 3 do
for j:=1 to 3 do rr[i,j]:=0;
rr[3,3]:=1;
c:=(cos(theta));
s:=(sin(theta));
rr[1,1]:=c;
rr[2,2]:=c;
rr[2,1]:=s;
rr[1,2]:=-s;
end;

{------------------------------Перемножить-----------------------------------}
procedure mult;
var i,j,k:integer; ab:real; tmp:array[1..3,1..3] of real;
begin
for i:=1 to 3 do
for j:=1 to 3 do
begin
ab:=0;
for k:=1 to 3 do ab:=ab+ss[i,k]*tt[k,j];
tmp[i,j]:=ab;
end;
for i:=1 to 3 do
for j:=1 to 3 do
begin
ab:=0;
for k:=1 to 3 do ab:=ab+rr[i,k]*tmp[k,j];
res[i,j]:=ab;
end;
end;

begin
clrscr;
grdriver:=detect;
initgraph(grdriver,grmode,'d:\pascal\bgi');
x[1] := 0;
y[1] := -1;
x[2] := -1;
y[2] := 1;
x[3] := 1;
y[3] := 1;
paint(x[1],y[1],x[2],y[2],x[3],y[3]);
scale(1,1);
tran(0,0);
rotate(2*pi);
i1:=1; i2:=0; i3:=0;
repeat
sym := readkey;
case sym of
'1': begin i1:=i1+0.1; scale(i1,i1); end;
'2': begin i1:=i1-0.1; scale(i1,i1); end;
'3': begin i2:=i2+0.1; tran(i2,i2);  end;
'4': begin i2:=i2-0.1; tran(i2,i2);  end;
'5': begin i3:=i3+0.1; rotate(i3);   end;
'6': begin i3:=i3-0.1; rotate(i3);   end;
end;
mult;
for i := 1 to 3 do
begin
xp[i] := x[i]*res[1,1]+y[i]*res[1,2]+res[1,3];
yp[i] := x[i]*res[2,1]+y[i]*res[2,2]+res[2,3];
end;
cleardevice;
paint(xp[1],yp[1],xp[2],yp[2],xp[3],yp[3]);
{setcolor(green);
outtextxy(1,1,inttostr(round(xp[1]*30)+300));
outtextxy(30,1,inttostr(round(yp[1]*30)+300));
outtextxy(1,15,inttostr(round(xp[2]*30)+300));
outtextxy(30,15,inttostr(round(xp[2]*30)+300));
outtextxy(1,30,inttostr(round(xp[3]*30)+300));
outtextxy(30,30,inttostr(round(xp[3]*30)+300));
line(0,45,60,45);
line(60,0,60,45);
setcolor(white);}
until sym = #27;

closegraph;
end.
