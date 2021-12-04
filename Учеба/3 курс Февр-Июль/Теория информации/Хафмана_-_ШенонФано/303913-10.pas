unit HaffmanArch;

interface

uses
  Shannon,Haffman,Windows, Messages, SysUtils, Variants, Classes, Graphics,
  Controls, Forms,  Dialogs, ComCtrls, StdCtrls, XPMan;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Button2: TButton;
    OpenDialog1: TOpenDialog;
    SaveDialog1: TSaveDialog;
    Button3: TButton;
    Button4: TButton;
    ProgressBar1: TProgressBar;
    XPManifest1: TXPManifest;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
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
begin
   Button1.Enabled:=false;
   Button2.Enabled:=false;
   Button3.Enabled:=false;
   Button4.Enabled:=false;

   If OpenDialog1.Execute
   Then
     RunEncodeHaff(OpenDialog1.FileName);
     ProgressBar1.Min := 0;
     ProgressBar1.Max := 100;
   Button1.Enabled:=true;
   Button2.Enabled:=true;
   Button3.Enabled:=true;
   Button4.Enabled:=true;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
   Button1.Enabled:=false;
   Button2.Enabled:=false;
   Button3.Enabled:=false;
   Button4.Enabled:=false;

   If OpenDialog1.Execute
   Then
     RunDecodeHaff(OpenDialog1.FileName);

   Button1.Enabled:=true;
   Button2.Enabled:=true;
   Button3.Enabled:=true;
   Button4.Enabled:=true;
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
   Button1.Enabled:=false;
   Button2.Enabled:=false;
   Button3.Enabled:=false;
   Button4.Enabled:=false;
   If OpenDialog1.Execute
   Then
     RunEncodeShan(OpenDialog1.FileName);

   Button1.Enabled:=true;
   Button2.Enabled:=true;
   Button3.Enabled:=true;
   Button4.Enabled:=true;
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
   Button1.Enabled:=false;
   Button2.Enabled:=false;
   Button3.Enabled:=false;
   Button4.Enabled:=false;
   If OpenDialog1.Execute
   Then
     RunDecodeShan(OpenDialog1.FileName);

   Button1.Enabled:=true;
   Button2.Enabled:=true;
   Button3.Enabled:=true;
   Button4.Enabled:=true;
end;

end.
