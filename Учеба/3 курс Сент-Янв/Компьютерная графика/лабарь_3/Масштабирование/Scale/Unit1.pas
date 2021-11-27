unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    Panel1: TPanel;
    btnTreug: TButton;
    btnCurves: TButton;
    btnCircle: TButton;
    btnStar: TButton;
    btnDraw: TButton;
    Panel2: TPanel;
    Panel3: TPanel;
    PaintBox1: TPaintBox;
    Panel4: TPanel;
    lbxScale: TListBox;
    lbxReal: TListBox;
    chbProportion: TCheckBox;
    Label3: TLabel;
    Label4: TLabel;
    Splitter1: TSplitter;
    Panel5: TPanel;
    Label1: TLabel;
    Label2: TLabel;
    Label5: TLabel;
    btnLines: TButton;
    procedure btnDrawClick(Sender: TObject);
    procedure btnCurvesClick(Sender: TObject);
    procedure btnTreugClick(Sender: TObject);
    procedure btnCircleClick(Sender: TObject);
    procedure btnStarClick(Sender: TObject);
    procedure btnLinesClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

type
  RPoint = record
   x, y : real;        // Мировые координаты точки
   draw : boolean;     // Параметр, указывает рисовать ли в эту точку линию
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

// Расчет коэффициентов масштабирования и построение изображения
procedure TForm1.btnDrawClick(Sender: TObject);
var
  Point : Rpoint;
  f     : file of RPoint;
  Xmin, Xmax, Ymin, Ymax : real;
  SXmin, SXmax, SYmin, SYmax : integer;
  ScaleX, ScaleY : real;
  sx, sy : integer;
begin
  AssignFile( f, 'plot.dat'); // Читаем данные из файла
  reset (f);
  Xmin:=1e10; Ymin:=1e10;
  Xmax:=-Xmin; Ymax:=-Ymin;

  while not eof(f) do begin   // Находим минимум и максимум по Х и по Y
    read( f, Point);          // в мировых координатах
    if Point.x < Xmin then Xmin := Point.x;
    if Point.x > Xmax then Xmax := Point.x;
    if Point.y < Ymin then Ymin := Point.y;
    if Point.y > Ymax then Ymax := Point.y;
  end;
  CloseFile(f);

  SXmin := 0; SXmax := PaintBox1.Width-1;   // Минимум и максимум
  SYmin := 0; SYmax := PaintBox1.Height-1;  // в экранных координатах

  ScaleX := (SXmax - SXmin) / (Xmax - Xmin); // Коэффициенты масштабирования
  ScaleY := (SYmax - SYmin) / (Ymax - Ymin);

  if chbProportion.Checked then    // Сохранение пропорций
    if (ScaleX < ScaleY) then
      ScaleY := ScaleX
    else
      ScaleX := ScaleY;

  lbxScale.Clear;
  reset(f);
  while not eof(f) do begin // Построение изображение с учетом масштаба и сдвига
    read( f, Point);
    sx := SXmin + round(ScaleX * (Point.x - Xmin));
    sy := SYmax - (SYmin + round(ScaleY * (Point.y - Ymin)));
    lbxScale.Items.Add('X:'+IntToStr(sx)+'  Y:'+IntToStr(sy));
    if Point.draw then
      PaintBox1.Canvas.LineTo( sx, sy)
    else
      PaintBox1.Canvas.MoveTo( sx, sy);
  end;
  CloseFile(f);
end;

// Построение кривой
procedure TForm1.btnCurvesClick(Sender: TObject);
const N = 500;
var
  Point : Rpoint;
  f     : file of RPoint;
  phi,
  alpha : integer;
  i     : integer;
begin
  AssignFile( f, 'plot.dat');
  Rewrite(f);
  lbxReal.Items.Clear;

  Point.x := 0;
  Point.y := 0;
  Point.draw := false;
  write( f , point);
  lbxReal.Items.Add('X:'+FloatToStr(Point.x)+'  Y:'+FloatToStr(Point.x));

  randomize;
  Point.draw := true;
  phi := 0;
  alpha := 0;
  for i:=1 to N do begin
    alpha := alpha + (6 - random(13));
    if abs(alpha) > 15 then alpha := 0;
    phi := phi + alpha;
    point.x := point.x + cos(phi*PI/180);
    point.y := point.y + sin(phi*PI/180);
    write( f , point);
    lbxReal.Items.Add('X:'+FloatToStr(Point.x)+'  Y:'+FloatToStr(Point.x));
  end;

  CloseFile(f);
end;

// Построение треугольника
procedure TForm1.btnTreugClick(Sender: TObject);
var
  Point : Rpoint;
  f     : file of RPoint;
begin
  AssignFile( f, 'plot.dat');   // Открываем файл для записи
  Rewrite(f);
  lbxReal.Items.Clear;

  Point.x := 0;    // Координаты первой точки
  Point.y := 0;
  Point.draw := false; // Параметр, указывает рисовать ли в эту точку линию
  write( f , point);   // Записать в файл
  lbxReal.Items.Add('X:'+FloatToStr(Point.x)+'  Y:'+FloatToStr(Point.x));

  Point.x := 10;   // Координаты второй точки
  Point.y := 10;
  Point.draw := true;  // Рисовать линию из предыдущей точки
  write( f , point);   // Записать в файл
  lbxReal.Items.Add('X:'+FloatToStr(Point.x)+'  Y:'+FloatToStr(Point.x));

  Point.x := 10;    // Координаты третьей точки
  Point.y := 0;
  Point.draw := true; // Рисовать линию из предыдущей точки
  write( f , point);  // Записать в файл
  lbxReal.Items.Add('X:'+FloatToStr(Point.x)+'  Y:'+FloatToStr(Point.x));

  Point.x := 0;      // Координаты первой точки
  Point.y := 0;
  Point.draw := true; // Рисовать линию из предыдущей точки
  write( f , point);  // Записать в файл
  lbxReal.Items.Add('X:'+FloatToStr(Point.x)+'  Y:'+FloatToStr(Point.x));

  CloseFile(f);
end;

// Построение окружности
procedure TForm1.btnCircleClick(Sender: TObject);
const N = 20;
var
  Point : Rpoint;
  f     : file of RPoint;
  phi   : integer;
  i     : integer;
begin
  AssignFile( f, 'plot.dat');
  Rewrite(f);
  lbxReal.Items.Clear;

  Point.x := 0;
  Point.y := 0;
  Point.draw := false;
  write( f , point);
  lbxReal.Items.Add('X:'+FloatToStr(Point.x)+'  Y:'+FloatToStr(Point.x));

  Point.draw := true;
  phi := 0;
  for i:=1 to N do begin
    phi := phi + 18;
    point.x := point.x + cos(phi*PI/180);
    point.y := point.y + sin(phi*PI/180);
    write( f , point);
    lbxReal.Items.Add('X:'+FloatToStr(Point.x)+'  Y:'+FloatToStr(Point.x));
  end;

  CloseFile(f);
end;

// Рекурсивное построение звезд
procedure TForm1.btnStarClick(Sender: TObject);
var
  f     : file of RPoint;

procedure Star( x, y, r: real);
var
  Point : Rpoint;
  phi   : integer;
  i     : integer;
begin
  if r < 0.1 then Exit;
  Point.x := x+r;
  Point.y := y;
  Point.draw := false;
  write( f , point);
  lbxReal.Items.Add('X:'+FloatToStr(Point.x)+'  Y:'+FloatToStr(Point.x));

  Point.draw := true;
  for i := 1 to 5 do begin
    phi := i*144;
    point.x := x + r*cos(phi*PI/180);
    point.y := y + r*sin(phi*PI/180);
    write( f , point);
    lbxReal.Items.Add('X:'+FloatToStr(Point.x)+'  Y:'+FloatToStr(Point.x));
  end;

  for i:=0 to 4 do begin
    phi := 36 + i*72;
    Star(x+2*r*cos(phi*PI/180),y+2*r*sin(phi*PI/180), r/2);
  end;
end;

begin
  AssignFile( f, 'plot.dat');
  Rewrite(f);
  lbxReal.Items.Clear;
  Star (0,0,1);
  CloseFile(f);
end;

// Построение линий из центра окружности
procedure TForm1.btnLinesClick(Sender: TObject);
const N = 300;
var
  Point : Rpoint;
  f     : file of RPoint;
  phi   : Double;
begin
  AssignFile( f, 'plot.dat');
  Rewrite(f);
  lbxReal.Items.Clear;

  phi := 0;
  while phi < 2*PI do begin
    Point.x := 0;
    Point.y := 0;
    Point.draw := false;
    write( f , point);
    lbxReal.Items.Add('X:'+FloatToStr(Point.x)+'  Y:'+FloatToStr(Point.x));
    point.x := cos(phi);
    point.y := sin(phi);
    Point.draw := true;
    write( f , point);
    lbxReal.Items.Add('X:'+FloatToStr(Point.x)+'  Y:'+FloatToStr(Point.x));
    phi := phi + 2*PI/N;
  end;

  CloseFile(f);
end;

end.
