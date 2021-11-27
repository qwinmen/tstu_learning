unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs,  StdCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    PaintBox1: TPaintBox;
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Tree(x, y: Integer; a: Real; l: Integer);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  kount:integer;

implementation

{$R *.dfm}

{ TForm1 }

procedure TForm1.Button1Click(Sender: TObject);
begin

  Tree(320, 580, 3*pi/2, 500);
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
	//��������� �������
		if Random > 0.5 then//0.1__0.5 ��������
                        paintbox1.Canvas.Pen.Color:=clgreen
		else
                        paintbox1.Canvas.Pen.Color:=clred;
	    	for i := 0 to 6 do

                        paintbox1.Canvas.LineTo(x+i,y);


		end
	else
	begin
		//��������� �����
                paintbox1.Canvas.Pen.Color:=RGB(100,3,4);
		for i := 0 to (p div 6) do
			paintbox1.Canvas.LineTo(x + i - (p div 12), y);
	end;
	//��������� �����
 	for i := 0 to 9 - Random(9) do
	begin
		s := Random(l - l div 6) + (l div 6);
		a1 := a + 1.6 * (0.5 - Random); //���� ������� �����
		x1 := Round(x + s * cos(a));
		y1 := Round(y + s * sin(a));
		Tree(x1, y1, a1, p - 5 - Random(30)); //��� ������ ��������, ��� ������ ������
	end;

end;





end.
