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
x0:=getmaxX div 2;{����� ������}
y0:=getmaxY div 2+round(10*b);
xn:=-5;xk:=5;{�������� �� �}
mx:=600/(xk-xn);{������� �� �}
my:=(y0-20)/20;{�� �}
setbkcolor(15);{���� ����}
setcolor(8);{���� �����}
line(0,y0,getmaxX,y0);{���}
line(x0,0,X0,getmaxY);
for i:=1 to 50 do{������������ ���������� ������� � ���� �������}
  begin
    line(x0+round(i*mx),y0-3,x0+round(i*mx),Y0+3); {������� �� ��� �}
    line(x0-round(i*mx),y0-3,x0-round(i*mx),Y0+3);
    {������� ��� �}
    str(i*0.4:0:1,s);
    str(i,s);
    outtextXY(x0+round(i*mx)-15,y0+10,s);
    outtextXY(x0-round(i*mx),y0+10,'-'+s);
    line(x0-3,y0+round(i*my),x0+3,y0+round(i*my));{������� �� ��� �}
    line(x0-3,y0-round(i*my),x0+3,y0-round(i*my));
     str(i*10,s);
    {������� ��� �}
    outtextXY(x0-25,y0+round(10*i*my),'-'+s);{�������������� ��������}
    outtextXY(x0-20,y0-round(10*i*my),s);
  end;
{�����}
outtextXY(x0+5,y0+10,'0');
{������� ������ ����}
outtextXY(getmaxX-10,y0-10,'X');
outtextXY(x0-10,10, 'Y');
setcolor(8);
{������}
x:=xn;
dx:=0.001;
while x<=xk do
   begin
    if abs(x)>dx then
      begin
       px:=x0+round(x*mx); {��������� �� ��� �}
       y:=F(x,a,b); {������ � �������� �����������}
       py:=y0-round(y*my);{� ��������}
       putpixel(px,py,8);
      end;
    x:=x+dx; {���������� �}
   end;
readln
end.