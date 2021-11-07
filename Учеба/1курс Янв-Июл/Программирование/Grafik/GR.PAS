uses crt,graph;
function F(x,a,b:real):real;
begin
F:=a/Exp(2*Ln(x))+1;
end;
var a,b,xn,xk,x,y,mx,my,dx:real;
    x0,y0,i,px,py:integer;
    s:string;
begin
clrscr;
writeln('Vvedite a,b:');
readln(a);
write('Press Enter...');
readln;
x0:=0;
initgraph(x0,y0,'');
x0:=getmaxX div 2;{центр экрана}
y0:=getmaxY div 2+round(10*b);
xn:=-5;xk:=5;{интервал по Х}
mx:=600/(xk-xn);{масштаб по Х}
my:=(y0-20)/20;{по У}
setbkcolor(15);{цвет фона}
setcolor(8);{цвет линий}
line(0,y0,getmaxX,y0);{оси}
line(x0,0,X0,getmaxY);
for i:=1 to 50 do{максимальное количество засечек в одну сторону}
  begin
    line(x0+round(i*mx),y0-3,x0+round(i*mx),Y0+3); {засечки на оси Х}
    line(x0-round(i*mx),y0-3,x0-round(i*mx),Y0+3);
    {подпись оси Х}
    str(i*0.4:0:1,s);
    str(i,s);
    outtextXY(x0+round(i*mx)-15,y0+10,s);
    outtextXY(x0-round(i*mx),y0+10,'-'+s);
    line(x0-3,y0+round(i*my),x0+3,y0+round(i*my));{засечки на оси У}
    line(x0-3,y0-round(i*my),x0+3,y0-round(i*my));
     str(i*10,s);
    {подпись оси У}
    outtextXY(x0-25,y0+round(10*i*my),'-'+s);{соответственно засечкам}
    outtextXY(x0-20,y0-round(10*i*my),s);
  end;
{центр}
outtextXY(x0+5,y0+10,'0');
{подписи концов осей}
outtextXY(getmaxX-10,y0-10,'X');
outtextXY(x0-10,10, 'Y');
setcolor(8);
{график}
x:=xn;
dx:=0.001;
while x<=xk do
   begin
    if abs(x)>dx then
      begin
       px:=x0+round(x*mx); {изменение по оси Х}
       y:=F(x,a,b); {график в реальных координатах}
       py:=y0-round(y*my);{в экранных}
       putpixel(px,py,8);
      end;
    x:=x+dx; {наращиваем х}
   end;
readln
end.