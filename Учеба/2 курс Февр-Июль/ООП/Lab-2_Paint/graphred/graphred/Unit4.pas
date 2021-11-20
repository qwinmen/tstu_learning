unit Unit4;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, unit1;

type
  TForm4 = class(TForm)
    img1: TImage;
    lbl1: TLabel;
    btn1: TButton;
    btn2: TButton;
    btn3: TButton;
    procedure btn3Click(Sender: TObject);
    procedure btn1Click(Sender: TObject);
    procedure btn2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form4: TForm4;

implementation

{$R *.dfm}

procedure TForm4.btn3Click(Sender: TObject);
begin
  Form4.close;
end;

procedure TForm4.btn1Click(Sender: TObject);
begin
  Form1.N4Click(sender);
  fsave := true;
  Form4.close;
end;

procedure TForm4.btn2Click(Sender: TObject);
begin
  Form1.N10Click(Sender);
  fsave := true;
  Form4.close;
end;

end.
