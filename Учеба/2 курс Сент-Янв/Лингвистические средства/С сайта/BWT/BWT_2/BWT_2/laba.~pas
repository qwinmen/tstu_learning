unit laba;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Button2: TButton;
    memo2: TMemo;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
var
a,b:textfile;
l3:array[1..50] of string;
l2:array[1..50] of string;
l:array[1..50,1..50] of string;
i,j,k,r,r1,r2,n,w,v,z,d:integer;
f,s,s1,s2,g,s3,s4,c,c1,f1:string;
begin
memo2.Text:=' ';
n:=1;k:=50;r2:=1;v:=1;w:=2;r1:=0;d:=1;
c:=inputbox('Введите имя текстового файла','file in','');
c1:=inputbox('Введите имя получнного файла','file out','');
assignfile (b,c1);
rewrite (b);
assignfile (a,c);
reset(a);
while not seekeof(a) do
begin
read (a,f1);
f:=f+f1;
end;
r:=length(f);
if r<50 then k:=r;
if r>50 then
begin
r1:=(r mod k);
r2:=(r div k);
end;
if r1>=1 then inc(r2);
for j:=1 to r2 do
begin
s1:=' ';
if (j=r2) and (r1<>0) then begin k:=r1;end;
for i:=1 to k do
begin
l[1,i]:=f[n];
l3[i]:=f[n];
s1:=s1+l3[i];
n:=n+1;
end;
w:=1;
for i:=2 to k do
begin
for v:=1 to k-1 do
begin
s:=l[w,1];
l[i,v]:=l[w,v+1];
l[i,k]:=s;
end;
w:=w+1;
end;
i:=1;
for w:=1 to k do
begin
for z:=1 to k-1 do
begin
i:=1;
if l[z,i]<>l[z+1,i] then i:=1;
if l[z,i]=l[z+1,i] then i:=i+1;
if l[z,i]=l[z+1,i] then i:=i+1;
if l[z,i]=l[z+1,i] then i:=i+1;
if l[z,i]=l[z+1,i] then i:=i+1;
if l[z,i]>l[z+1,i] then
begin
for v:=1 to k do
begin
l2[v]:=l[z,v];
l[z,v]:=l[z+1,v];
l[z+1,v]:=l2[v];
end;
end;
end;
end;
for i:=1 to k do
begin
for v:=1 to k do
begin
l2[v]:=l[i,v];
s2:=s2+l2[v];
if s1=s2 then d:=i;
end;
s2:=' ';
end;
g:=inttostr(d);
for i:=1 to k do
begin
s3:=s3+l[i,k];
end;
s4:=g+'~'+s3;
memo2.SelText:=s4;
memo2.seltext:=' '#13#10;
append (b);
writeln (b,s4);
s3:='';
end;
closefile (a);
closefile (b);
end;
procedure TForm1.FormCreate(Sender: TObject);
begin
memo2.text:=' ';
end;

procedure TForm1.Button2Click(Sender: TObject);
label a1,a2;
var
a,b:textfile;
l:array [1..53,1..53] of string;
l2:array[1..53,1..53] of string;
l1:array [1..53] of string;
l3:array[1..53] of string;
i,j,k,n,m,h,w,v,z,i1:integer;
s,s2,p,c,c1:string;
s1:array[1..53]of string;
s3:array[1..53]of string;
s4:array[1..53]of string;
begin
    c:=inputbox('Введите имя текстового файла','file in','');
    c1:=inputbox('Введите имя получнного файла','file out','');
    memo2.Text:=' ';
    assignfile (a,c);
    reset (a);
    assignfile (b,c1);
    rewrite (b);
    n:=1;k:=53;
    while n<>0  do
    begin
         readln(a,s);
         n:=length(s);
         if n<50 then k:=n;
         for i:=1 to k do
         begin
             s1[i]:=s[i];
         end;
         s2:=s1[1];
         if s1[2]<>'~' then
              s2:=s1[1]+s1[2];
              h:=strtoint(s2);
              m:=3;
              if h>10 then
                    m:=4;
                    w:=1;
                    for i:=m to k do
                    begin
                         l[i,1]:=s[i];
                         l[i,2]:=inttostr(w);
                         s3[i]:=s[i];
                         w:=w+1;
                    end;
                    for i:=1 to k do
                    begin
                        for j:=1 to k-1 do
                        begin
                            if l[j,1]>l[j+1,1] then
                            begin
                                for v:=1 to k do
                                begin
                                     l1[v]:=l[j,v];
                                     l[j,v]:=l[j+1,v];
                                     l[j+1,v]:=l1[v];
                                     l[v,3]:=inttostr(v);
                                end;
                            end;
                        end;
                    end;
                    for i:=1 to k do
                    begin
                        l3[i]:=l[h+m-1,1];
                        h:=strtoint(l[h+m-1,2]);
                    end;
                    for i:=1 to k-m+1 do
                    begin
                        memo2.SelText:=l3[i];
                        write (b,l3[i]);
                    end;
          {memo2.SelText:=' '#13#10;}
              end;
              closefile(a);
              closefile (b);
         end;

end.
