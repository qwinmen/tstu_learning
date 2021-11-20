unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ColorGrd, ComCtrls, StdCtrls, Buttons, ExtCtrls, Menus, ExtDlgs;

type
  TForm1 = class(TForm)
    mm1: TMainMenu;
    a1: TMenuItem;
    N1: TMenuItem;
    N2: TMenuItem;
    N3: TMenuItem;
    N4: TMenuItem;
    N5: TMenuItem;
    N6: TMenuItem;
    pnl1: TPanel;
    btn1: TSpeedButton;
    btn2: TSpeedButton;
    btn3: TSpeedButton;
    btn4: TSpeedButton;
    btn5: TSpeedButton;
    btn6: TSpeedButton;
    btn7: TSpeedButton;
    btn8: TSpeedButton;
    edt1: TEdit;
    ud1: TUpDown;
    pnl2: TPanel;
    clrgrd1: TColorGrid;
    bvl1: TBevel;
    pnl3: TPanel;
    pnl4: TPanel;
    scrlbx1: TScrollBox;
    img1: TImage;
    stat1: TStatusBar;
    dlgOPic1: TOpenPictureDialog;
    dlg1: TSavePictureDialog;
    lbl1: TLabel;
    img2: TImage;
    img3: TImage;
    N7: TMenuItem;
    N8: TMenuItem;
    N9: TMenuItem;
    N10: TMenuItem;
    N11: TMenuItem;
    N12: TMenuItem;
    N13: TMenuItem;
    rb1: TRadioButton;
    rb2: TRadioButton;
    procedure FormCreate(Sender: TObject);
    procedure N2Click(Sender: TObject);
    procedure ud1Click(Sender: TObject; Button: TUDBtnType);
    procedure clrgrd1Change(Sender: TObject);
    procedure btn1MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure btn2MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure btn3MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure btn4MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure btn5MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure btn6MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure btn7MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure btn8MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure edt1MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure clrgrd1MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure pnl4MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure pnl3MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure img1MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure edt1Change(Sender: TObject);
    procedure img1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btn5Click(Sender: TObject);
    procedure N7Click(Sender: TObject);
    procedure N8Click(Sender: TObject);
    procedure N10Click(Sender: TObject);
    procedure N11Click(Sender: TObject);
    procedure N13Click(Sender: TObject);
    procedure btn6Click(Sender: TObject);
    procedure btn8Click(Sender: TObject);
    procedure btn7Click(Sender: TObject);
    procedure btn4Click(Sender: TObject);
    procedure btn1Click(Sender: TObject);
    procedure btn3Click(Sender: TObject);
    procedure btn2Click(Sender: TObject);
    procedure N3Click(Sender: TObject);
    procedure N4Click(Sender: TObject);
    procedure N1Click(Sender: TObject);
    procedure N5Click(Sender: TObject);
    procedure img1MouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1   : TForm1;
  x1,y1,
  x2,y2,
  fat     : integer;
  mb      : char;
  flag,
  front   : integer;
  fname   : string;
  backp,
  nextp,
  fopen,
  fsave   : boolean;

implementation

uses Unit2, Unit3, Unit4;

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  fsave := true;
  img1.Canvas.FillRect(img1.Canvas.ClipRect);
  img2.Canvas.FillRect(img2.Canvas.ClipRect);
  img3.Canvas.FillRect(img3.Canvas.ClipRect);
end;

procedure TForm1.N2Click(Sender: TObject);
begin
   img1.AutoSize := true;
   fopen := true;
   dlgOPic1.Execute;
   img1.Picture.LoadFromFile(dlgOPic1.FileName);
   fname := dlgOPic1.FileName;
   img1.AutoSize := false;
end;

procedure TForm1.ud1Click(Sender: TObject; Button: TUDBtnType);
begin
  if not btn5.Down then
  begin
    front := StrToInt(edt1.Text);
    if front <> 0 then
    begin
    if Button = btprev then
     begin
       dec(front);
       if front = 0 then
        front := 1;
      edt1.Text := IntToStr(front);
     end;
     if Button = btnext then
     begin
       Inc(front);
       edt1.Text := IntToStr(front);
     end;
    end;
  end;
end;

procedure TForm1.clrgrd1Change(Sender: TObject);
begin
  pnl4.Color := clrgrd1.ForegroundColor;
  pnl3.color := clrgrd1.BackgroundColor;
end;

procedure TForm1.btn1MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  stat1.Panels[0].Text := 'Стирание части рисунка с помощью '+
                           'ластика выбраного цвета';
end;

procedure TForm1.btn2MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  stat1.Panels[0].Text := 'Заполнение области одним из текущих цветов';
end;

procedure TForm1.btn3MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  stat1.Panels[0].text := 'Выбор цветов из имеющихся на рисунке';
end;

procedure TForm1.btn4MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  stat1.panels[0].text := 'Проведение прямой линии выбраной толщины';
end;

procedure TForm1.btn5MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  stat1.Panels[0].Text := 'Проведение произвольной линии толщиной в одну точку';
end;

procedure TForm1.btn6MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  stat1.panels[0].text := 'Рисование кистью выброной толщины';
end;

procedure TForm1.btn7MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  stat1.Panels[0].Text := 'Рисование эллипса';
end;

procedure TForm1.btn8MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  stat1.Panels[0].text := 'Рисование прямоугольника';
end;

procedure TForm1.edt1MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  stat1.Panels[0].text := 'Выбор толщины ';
end;
procedure TForm1.clrgrd1MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  stat1.Panels[0].Text := 'Выбор цветов';
end;

procedure TForm1.pnl4MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  stat1.Panels[0].Text := 'Цвет левой кнопки мыши';
end;

procedure TForm1.pnl3MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  stat1.Panels[0].Text := 'Цвет правой кнопки мыши';
end;

procedure TForm1.img1MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  stat1.Panels[0].Text := 'Область для рисования';
  stat1.Panels[1].text := 'x:'+inttostr(x)+ ' y:'+inttostr(y);
  if ((ssRight in Shift) or (ssLeft in Shift)) then
  begin
    fsave := false;
    backp := true;
    nextp := false;
    if btn1.Down then
    begin
      img1.Canvas.Pen.color:=pnl3.Color;
      img1.Canvas.pen.Width:=strtoint((edt1.text));
      Img1.Canvas.lineto(x,y);
    end;

    if btn5.down then
    begin
      if mb = 'l' then
       img1.Canvas.Pen.Color := pnl4.Color
      else
       img1.Canvas.Pen.Color := pnl3.Color;
      img1.Canvas.LineTo(x,y);
    end;

    if btn6.Down then
    begin
      img1.canvas.Pen.Width := strtoint(edt1.Text);
      if mb = 'l' then
       img1.Canvas.Pen.Color := pnl4.Color
      else
       img1.Canvas.Pen.Color := pnl3.Color;
      img1.canvas.lineto(x,y);
    end;

    if btn4.down then
    begin
      img1.picture.Assign(img2.picture);
      if mb = 'l' then
       Img1.Canvas.Pen.color := pnl4.Color
      else
       Img1.Canvas.Pen.color := pnl3.Color;
      Img1.Canvas.Pen.width := strtoint(edt1.text);
      Img1.Canvas.moveto(x,y);
      Img1.Canvas.lineto(x1,y1);
    end;

    if btn7.Down then
    begin
      img1.picture.Assign(img2.picture);
      img1.Canvas.pen.Width := strtoint(edt1.text);
      if mb = 'r' then
       img1.Canvas.Pen.color := pnl3.Color
      else
       Img1.Canvas.Pen.color := pnl4.color;
      if rb1.checked = true then
       img1.Canvas.Brush.Style := bsClear
      else
       img1.Canvas.Brush.Style := bsSolid;
      Img1.Canvas.ellipse(x,y,x1,y1);
    end;

    if btn8.Down then
    begin
      img1.picture.Assign(img2.picture);
      img1.Canvas.pen.Width := strtoint(edt1.text);
      if mb = 'r' then
       img1.Canvas.Pen.color := pnl3.Color
      else
       Img1.Canvas.Pen.color := pnl4.color;
      if rb1.Checked = true then
       img1.Canvas.Brush.Style := bsClear
      else
       img1.Canvas.Brush.Style := bsSolid;
      img1.Canvas.Rectangle(x,y,x1,y1);
    end;

 end;
  x2 := x;
  y2 := y;
end;

procedure TForm1.img1MouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
    if btn2.Down then
    begin
      if button = mbRight then
       Img1.Canvas.brush.color := pnl3.Color
      else
       Img1.Canvas.brush.color := pnl4.Color;
      Img1.Canvas.FloodFill(x, y,Img1.Canvas.Pixels[x,y], fssurface);
    end;

    if btn3.Down then
    begin
      if button = mbRight then
       pnl3.Color := Img1.Canvas.pixels[x,y]
      else
       pnl4.color := Img1.Canvas.pixels[x,y];
    end;
end;

procedure TForm1.img1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  img2.picture.Assign(img1.Picture);
  x1 := x;
  y1 := y;
  if button = mbRight then
   mb := 'r'
  else
   mb := 'l';
  img1.Canvas.MoveTo(x,y);
  Img1MouseMove(Sender,Shift,X,Y);
end;

procedure TForm1.edt1Change(Sender: TObject);
begin
  fat := strtoint(edt1.text);
  if not btn5.Down then
   img1.Canvas.Pen.Width := fat;
end;

procedure TForm1.btn5Click(Sender: TObject);
begin
  img1.Canvas.Pen.Width := 1;
  lbl1.Visible := false;
  edt1.Visible := false;
  rb1.Visible := false;
  rb2.Visible := false;
end;

procedure TForm1.N7Click(Sender: TObject);
begin
  if backp = true then
  begin
    img3.picture.Assign(img1.Picture);
    img1.picture.Assign(img2.Picture);
    nextp := true;
  end;
  backp := false;
end;

procedure TForm1.N8Click(Sender: TObject);
begin
  if nextp = true then
  begin
    img2.Picture.Assign(img1.Picture);
    img1.Picture.Assign(img3.Picture);
    backp := true;
  end;
  nextp := false;
end;

procedure TForm1.N10Click(Sender: TObject);
begin
  img1.Picture := nil;
  img1.Canvas.FillRect(img1.Canvas.ClipRect);
  img2.Picture := nil;
  img2.Canvas.FillRect(img2.Canvas.ClipRect);
  img3.Picture := nil;
  img3.Canvas.FillRect(img3.Canvas.ClipRect);
  backp := false;
  nextp := false;
end;

procedure TForm1.N11Click(Sender: TObject);
begin
  Form2.ShowModal;
end;

procedure TForm1.N13Click(Sender: TObject);
begin
  form3.ShowModal;
end;

procedure TForm1.btn6Click(Sender: TObject);
begin
  lbl1.Visible := true;
  edt1.Visible := true;
  ud1.Visible := true;
  rb1.Visible := false;
  rb2.Visible := false;
end;

procedure TForm1.btn8Click(Sender: TObject);
begin
  lbl1.Visible := true;
  edt1.Visible := true;
  ud1.Visible := true;
  rb1.Visible := true;
  rb2.Visible := true;
end;

procedure TForm1.btn7Click(Sender: TObject);
begin
  lbl1.Visible := true;
  edt1.Visible := true;
  ud1.Visible := true;
  rb1.Visible := true;
  rb2.Visible := true;
end;

procedure TForm1.btn4Click(Sender: TObject);
begin
  lbl1.Visible := true;
  edt1.Visible := true;
  ud1.Visible := true;
  rb1.Visible := false;
  rb2.Visible := false;
end;

procedure TForm1.btn1Click(Sender: TObject);
begin
  lbl1.Visible := true;
  edt1.Visible := true;
  ud1.Visible := true;
  rb1.Visible := false;
  rb2.Visible := false;
end;

procedure TForm1.btn3Click(Sender: TObject);
begin
  lbl1.Visible := true;
  edt1.Visible := true;
  ud1.Visible := true;
  rb1.Visible := false;
  rb2.Visible := false;
end;

procedure TForm1.btn2Click(Sender: TObject);
begin
  lbl1.Visible := true;
  edt1.Visible := true;
  ud1.Visible := true;
  rb1.Visible := false;
  rb2.Visible := false;
end;

procedure TForm1.N3Click(Sender: TObject);
var
  bmp:  TBitmap;
begin
  if fopen then
   begin
      try
         bmp := TBitmap.Create;
         bmp.Assign(img1.Picture);
         bmp.SaveTofile(ChangeFileExt(fname, '.bmp'));
      finally
         bmp.Free;
      end;
   end
  else
   begin
     dlg1.Execute;
     try
        bmp := TBitmap.Create;
        bmp.Assign(img1.Picture);
        bmp.SaveTofile(ChangeFileExt(dlg1.FileName, '.bmp'));
     finally
        bmp.Free;
     end;
     fopen := true;
   end;
   fsave := true;
end;

procedure TForm1.N4Click(Sender: TObject);
var
  bmp: TBitmap;
begin
  dlg1.Execute;
  try
    bmp := TBitmap.Create;
    bmp.Assign(img1.Picture);
    bmp.SaveTofile(ChangeFileExt(dlg1.FileName, '.bmp'));
  finally
    bmp.Free;
  end;
  fsave := true;
end;

procedure TForm1.N1Click(Sender: TObject);
begin
  if fsave <> true then
  begin
    Form4.ShowModal;
  end
  else
  begin
    fopen := false;
    img1.Picture := nil;
    img1.Canvas.FillRect(img1.Canvas.ClipRect);
    img2.Picture := nil;
    img2.Canvas.FillRect(img2.Canvas.ClipRect);
    img3.Picture := nil;
    img3.Canvas.FillRect(img3.Canvas.ClipRect);
    backp := false;
    nextp := false;
  end;
end;

procedure TForm1.N5Click(Sender: TObject);
begin
  if fsave <> true then
  begin
    Form4.ShowModal;
  end;
  if fsave = true then
   form1.Close;
end;

end.

