unit Laba1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Mask, DBCtrls, Menus;

type
    TCompress=class
    procedure compress;
    procedure initform;virtual;
    end;
    TDecompress=class(TCompress)
    procedure decompress;
    procedure initform;override;
    end;
    TForm1 = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    Edit2: TEdit;
    Label3: TLabel;
    Memo1: TMemo;
    Memo2: TMemo;
    MainMenu1: TMainMenu;
    N1: TMenuItem;
    OpenDialog1: TOpenDialog;
    N4: TMenuItem;
    N5: TMenuItem;
    procedure N4Click(Sender: TObject);
    procedure N5Click(Sender: TObject);
    procedure N2Click(Sender: TObject);
    procedure N3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
    Form1: TForm1;
    str,str1,str2:string;
    i,k,z,m,j,f,g,p: Integer;
    strmass:array[1..2000] of string;
    mass,mass1:array[1..2000] of integer;
    ch:char;
    Comp: TCompress;
    Decomp:TDecompress;
implementation

{$R *.dfm}
procedure TCompress.initform;
begin
Form1.Memo2.Text:='';
Form1.Edit2.Text:='';
end;
procedure TDecompress.initform;
begin
Form1.Memo1.Text:='';
Form1.Memo2.Text:='';
Form1.Edit2.Text:='';
end;
//Откытие внешнего файла
procedure TForm1.N4Click(Sender: TObject);
begin
With OpenDialog1 Do
      If Execute Then
       begin
        Memo1.Lines.LoadFromFile(FileName);
      end;
end;
procedure TForm1.N2Click(Sender: TObject);
begin
Comp:=TCompress.Create;
Comp.initform;
Comp.compress;
Comp.destroy;
end;
procedure TForm1.N3Click(Sender: TObject);
begin
Comp:=TDecompress.Create;
Comp.initform;
Comp.Destroy;
Decomp:=TDecompress.Create;
Decomp.decompress;
Decomp.Destroy;
end;
procedure TForm1.N5Click(Sender: TObject);
begin
Application.Terminate;
end;

procedure TCompress.compress;
begin
z:=0;
str:=Form1.Memo1.Text;
str1:=Form1.Memo1.Text;
for i:=1 to Length(str) do //сдвиг матрицы на один символ
begin
     ch:=str[1];
     for k:=2 to Length(str) do str[k-1]:=str[k];
     str[Length(str)]:=ch;
     inc(z);
     strmass[z]:=str;
end;

for m:=1 to z do //Сортировка по алфавиту
begin
     for i:=1 to z-1 do
     begin
          if (strcomp(PChar(strmass[i+1]),PChar(strmass[i]))<0) then
          begin
               str:=strmass[i+1];
               strmass[i+1]:=strmass[i];
               strmass[i]:=str;
          end;
     end;
end;

for m:=1 to z do   //поиск исходной строки
  begin
     if (strmass[m]=str1) then
     begin
        Form1.Edit2.Text:='№  '+inttostr(m-1);
        p:=m;
        break;
     end;
  end;
str:='';

//Вывод последнего столбца
For m:=1 to z do str:=str+strmass[m][z];
str1:='';
For m:=1 to z do str1:=str1+strmass[m][1];
Form1.Memo2.Text:=str;
end;

//Преобразование массива
procedure TDecompress.decompress;
begin
g:=0; //Номера матрицы сортируются в соответствии с алгоритмом
for m:=1 to z do
begin
     for j:=1 to z do
     begin
          g:=0;
          //Если найдены два символа в строке то выполняется проверка
          //Вдруг этот символ встретился
          if str[m]=str1[j] then
          begin
               if m=1 then  begin mass[m]:=j; break; end;
               for f:=1 to m-1 do if mass[f]=j then g:=1;
               if g=1 then continue;
               if g=0 then begin mass[m]:=j; break;  end;
          end;
     end;
end;
//Определение коэффициентов в соответсвии с которыми раскодируется последний столбец
for m:=1 to z do
begin
     for j:=1 to z do
       if mass[j]=p then
       begin
           mass1[m]:=j;
           p:=j;
           break;
       end;
end;

str1:='';
for m:=1 to z do str1:=str1+str[mass1[m]];
ShowMessage(str1);
end;
end.




