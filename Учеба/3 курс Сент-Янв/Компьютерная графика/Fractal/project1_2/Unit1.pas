unit Unit1; 

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, FileUtil, LResources, Forms, Controls, Graphics, Dialogs,
  StdCtrls, ExtCtrls;

type

  { TForm1 }

  TForm1 = class(TForm)
    Button1: TButton;
    PaintBox1: TPaintBox;
    procedure Button1Click(Sender: TObject);
    procedure Tree(x, y: Integer; a: Real; l: Integer);
  private
    { private declarations }
  public
    { public declarations }
  end; 

var
  Form1: TForm1;
  kount:integer;

implementation

{ TForm1 }

procedure TForm1.Button1Click(Sender: TObject);
begin

  Tree(320, 580, 3*pi/2, 200);
end;

procedure TForm1.Tree(x, y: Integer; a: Real; l: Integer);
var
	x1, y1: Integer;
	p, s  : Integer;
	i     : Integer;
	a1    : Real;
begin
	if l < 8 then
		exit;
	x1 := Round(x + l*cos(a));
	y1 := Round(y + l*sin(a));
	if l > 100 then
		p := 100
	else
		p := l;
	if p < 40 then
	begin
	//Генерация листьев
		if Random > 0.5 then
                        paintbox1.Canvas.Pen.Color:=clgreen

		else
                        paintbox1.Canvas.Pen.Color:=rgbtocolor(90,139,5);

	    	for i := 0 to 3 do

                        paintbox1.Canvas.Line(x+i,y,x1,y1);


		end
	else
	begin
		//Генерация веток
                paintbox1.Canvas.Pen.Color:=rgbtocolor(100,3,4);
		for i := 0 to (p div 6) do
			paintbox1.Canvas.Line(x + i - (p div 12), y, x1, y1);
	end;
	//Следующие ветки
 	for i := 0 to 9 - Random(9) do
	begin
		s := Random(l - l div 6) + (l div 6);
		a1 := a + 1.6 * (0.5 - Random); //Угол наклона веток
		x1 := Round(x + s * cos(a));
		y1 := Round(y + s * sin(a));
		Tree(x1, y1, a1, p - 5 - Random(30)); //Чем меньше вычетаем, тем пышнее дерево
	end;

end;





initialization
  {$I unit1.lrs}

end.

