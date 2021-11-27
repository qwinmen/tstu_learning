uses s_graph,Crt,s_mouse;
{$I fnt.inc}
const size=14;
      count=24;

type

    VRec = record
            x,y,z:integer;
            end;
   RRec = record
            F,L:integer;
           end;

{------------------------------------Перерисовка:---------------------------}
procedure WaiteReTrace;
begin
while(port[$3da] and 8)=0 do
end;


var
   V,v1:array[1..100]of VRec;
   R,r1:array[1..100]of RRec;
   i,j,xx,yy,a:integer;
   x,y,z,kn:word;
   dx,dy,alfa,t:real;
{$I fobj.inc}
{$I tobj.inc}

{------------------------------------Обьект:-------------------------------}
procedure ShowObj(color:byte);
var
    i,n,k:integer;
    x,x1,y,y1:integer;
begin

for i:=1 to count do begin
n:=r[i].f;   k:=r[i].l;
line(v[n].x,v[n].y, v[k].x,v[k].y,color);
                 end;
end;

{------------------------------------Сдвиг:---------------------------------}
procedure Move;
var
    xx,yy,zz:integer;
    i,j:integer;
    k,n:Integer;
    Vec,Vec1:Array [1..4] Of real;
begin
xx:=100;yy:=200;zz:=100;
for n:=1 to size do begin
Vec[1]:=V[n].x-xx; Vec[2]:=V[n].y-yy; Vec[3]:=V[n].z-zz; Vec[4]:=1;

vec1[1]:=vec[1]+(1);
vec1[2]:=vec[2]+(0);
vec1[3]:=vec[3]+(1);

V[n].x:=round(Vec1[1]+xx);
V[n].y:=round(Vec1[2]+yy);
V[n].z:=round(Vec1[3]+zz);
  end;
end;

{-------------------------------Масштабирование:----------------------------}
procedure Scale;
var
    xx,yy,zz:integer;
    i,j:integer;
    k,n:Integer;
    Vec,Vec1:Array [1..4] Of real;
begin
xx:=100;yy:=200;zz:=100;
for n:=1 to size do begin
Vec[1]:=V[n].x-xx; Vec[2]:=V[n].y-yy; Vec[3]:=V[n].z-zz; Vec[4]:=1;

vec1[1]:=vec[1]*(1.03);
vec1[2]:=vec[2]*(1.03);
vec1[3]:=vec[3]*(1.03);
V[n].x:=round(Vec1[1]+xx);
V[n].y:=round(Vec1[2]+yy);
V[n].z:=round(Vec1[1]+zz);
  end;
end;

{-------------------------------Поворот:------------------------------------}
procedure Rotate(alfa:real);
var
    xx,yy,zz:integer;
    i,j:integer;
    k,n:Integer;
    Vec,Vec1:Array [1..4] Of real;
begin
xx:=150;yy:=260;zz:=100;
initfObj;

for n:=1 to size do begin
Vec[1]:=V[n].x-xx; Vec[2]:=V[n].y-yy; Vec[3]:=V[n].z-zz; Vec[4]:=1;

vec1[1]:=vec[1]*(cos(alfa)*cos(alfa))+vec[2]*((cos(alfa)*(-sin(alfa)))*cos(alfa)+(sin(alfa)*sin(alfa)))+vec[3]*((sin(alfa)
*sin(alfa))*cos(alfa)+(sin(alfa)*cos(alfa)));
vec1[2]:=vec[1]*(sin(alfa))+vec[2]*(cos(alfa)*cos(alfa))+vec[3]*(-sin(alfa)*cos(alfa));
vec1[3]:=vec[1]*(sin(alfa)*cos(alfa))+vec[2]*((-sin(alfa)*cos(alfa))*sin(alfa)+(sin(alfa))*cos(alfa))+vec[3]*((sin(alfa)
*sin(alfa))*(-sin(alfa))+(cos(alfa))*cos(alfa));

V[n].x:=trunc(Vec1[1]+xx);
V[n].y:=trunc(Vec1[2]+yy);
V[n].z:=trunc(Vec1[3]+zz);
  end;
end;

{-------------------------------Поворот:------------------------------------}
procedure Rotate1(alfa:real);
var
    xx,yy,zz:integer;
    i,j:integer;
    k,n:Integer;
    Vec2,Vec3:Array [1..4] Of real;
begin
xx:=150;yy:=260;zz:=100;
initfObj;

for n:=1 to size do begin
Vec2[1]:=V1[n].x-xx; Vec2[2]:=V1[n].y-yy; Vec2[3]:=V1[n].z-zz; Vec2[4]:=1;

vec3[1]:=vec2[1]*(cos(alfa)*cos(alfa))+vec2[2]*((cos(alfa)*(-sin(alfa)))*cos(alfa)+(sin(alfa)*sin(alfa)))+vec2[3]*((sin(alfa)
*sin(alfa))*cos(alfa)+(sin(alfa)*cos(alfa)));
vec3[2]:=vec2[1]*(sin(alfa))+vec2[2]*(cos(alfa)*cos(alfa))+vec2[3]*(-sin(alfa)*cos(alfa));
vec3[3]:=vec2[1]*(sin(alfa)*cos(alfa))+vec2[2]*((-sin(alfa)*cos(alfa))*sin(alfa)+(sin(alfa))*cos(alfa))+vec2[3]*((sin(alfa)
*sin(alfa))*(-sin(alfa))+(cos(alfa))*cos(alfa));

V1[n].x:=trunc(Vec3[1]+xx);
V1[n].y:=trunc(Vec3[2]+yy);
V1[n].z:=trunc(Vec3[3]+zz);
V[n].x:=V1[n].x;
V[n].y:=V1[n].y;
V[n].z:=V1[n].z;
  end;
end;

procedure Morf(t:real);
var
    n:Integer;

begin
initfObj;

for n:=1 to size+1 do begin

v[n].x:=trunc((1-t)*v[n].x+(v1[n].x*t));
v[n].y:=trunc((1-t)*v[n].y+(v1[n].y*t));
r[n].f:=r1[n].f;
r[n].l:=r1[n].l;

end;end;



begin
openVesa($0101);
initfObj;

ShowObj(15);
readkey;
keypressed;


for i:=1 to 500 do begin
ShowObj(0);
Rotate(i/100);
ShowObj(15);
WaiteReTrace;
                   end;
ShowObj(0);
{InitfObj;}

for i:=1 to 100 do begin
move;
ShowObj(15);
WaiteReTrace;
ShowObj(0);

                   end;

for i:=1 to 10 do begin
Scale;
ShowObj(15);
WaiteReTrace;
if i=10 then readln;
ShowObj(0);

                   end;


for i:=1 to 100 do begin
Morf(i/100);
ShowObj(15);
WaiteReTrace;
ShowObj(0);
                   end;
{for i:=100 downto 1 do begin
Morf(i/100);
ShowObj(15);
WaiteReTrace;
ShowObj(0);
                   end;
          }

for i:=1 to 500 do begin
ShowObj(0);
Rotate1(i/100);
ShowObj(15);
WaiteReTrace;
                   end;


ShowObj(15);
readkey;

readkey;
CloseVesa;

end.

