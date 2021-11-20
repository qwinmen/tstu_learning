unit Unit2;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons, Unit1;

type
  TForm2 = class(TForm)
    edt1: TEdit;
    edt2: TEdit;
    lbl1: TLabel;
    lbl2: TLabel;
    btn1: TBitBtn;
    procedure btn1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form2: TForm2;

implementation

{$R *.dfm}

procedure TForm2.btn1Click(Sender: TObject);
begin

  Form2.Visible := false;
  Form1.Img1.height := strtoint(form2.edt2.Text);
  Form1.Img1.width := strtoint(form2.edt1.Text);
  Form1.img1.Picture := nil;
  Form1.img1.Canvas.FillRect(Form1.img1.Canvas.ClipRect);
end;

procedure TForm2.FormCreate(Sender: TObject);
begin
  Form2.edt2.Text:=inttostr(Form1.Img1.height);
  Form2.edt1.Text:=inttostr(Form1.Img1.width);
end;

end.
