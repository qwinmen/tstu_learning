unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons;

type
  TArxivation = class(TObject)
    public
    masc: array [0..255,0..255] of char;
    FilNam: string;
    fic: file;
    foc: file;
    b1,b2,oldB1,oldB2,simbol: byte;
    a,b: integer;
    buff: array [0..7] of byte;
    Constructor codec;
    procedure compressing; virtual; abstract;
    procedure kpd;
  end;
  TCompress = class(TArxivation)
    public
    procedure compressing; override;
  end;
  TDecompress = class(TCompress)
    public
    procedure compressing; override;
  end;
  TForm1 = class(TForm)
    Button1: TButton;
    Button2: TButton;
    Edit1: TEdit;
    OpenDialog1: TOpenDialog;
    Label1: TLabel;
    Edit2: TEdit;
    Button3: TButton;
    Edit3: TEdit;
    Button4: TButton;
    Button5: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  Arxiv: TArxivation;
  Compress: TCompress;
  Decompress: TDecompress;
  b1,b2,oldB1,oldB2,simbol: byte;
  i,j,a,b,x,y,z: integer;

implementation

Constructor TArxivation.codec;
begin

end;

function stepen(k:integer): integer;
var sum,q: integer;
begin
    sum:=1;
    for q:=1 to k do begin
        sum:=sum*2;
    end;
    stepen:=sum;
end;

procedure TCompress.compressing;
var
    comi,comy,comj,comz,comx,coma,comb: integer;
begin
    for comi:=0 to 255 do begin
        for comj:=0 to 255 do begin
            masc[comi,comj]:=chr(32);
        end;
    end;
    b2:=0; b1:=0; oldB1:=0; oldB2:=0; comi:=0;
    Form1.Edit3.Text:=chr(oldB1);
    assignfile(fic,Form1.OpenDialog1.FileName);
    Form1.Edit3.Text:=Form1.OpenDialog1.FileName;
    reset(fic,1);
    FilNam:=ExtractFileName(Form1.OpenDialog1.FileName);
    b1:=Length(FilNam);
    SetLength(FilNam,b1-3);
    FilNam:=FilNam+'wrl';
    assignfile(foc,FilNam);
    rewrite(foc,1);
    b1:=Length(FilNam);
    Form1.Edit3.Text:=IntToStr(b1);
    BlockWrite(foc,b1,1);
    FilNam:=ExtractFileName(Form1.OpenDialog1.FileName);
    for comx:=1 to b1 do begin
        BlockWrite(foc,FilNam[comx],1);
    end;
    b2:=0; comx:=0; comy:=0;
    a:=ord(oldB2); b:=ord(oldB1);
    while not EOF(fic) do begin
        BlockRead(fic,b1,1);
        if (masc[a,b]=chr(b1)) then begin
            b2:=b2+stepen(comi);
        end
        else begin
            masc[a,b]:=chr(b1);
            buff[comy]:=b1;
            comy:=comy+1;
        end;
        oldB2:=oldB1; oldB1:=b1;
        a:=ord(oldB2); b:=ord(oldB1);
        if comi=7 then begin
            BlockWrite(foc,b2,1);
            for comz:=0 to comy-1 do begin
                BlockWrite(foc,buff[comz],1);
            end;
            comi:=0; comy:=0; b2:=0;
        end
        else comi:=comi+1;

    end;
    Blockwrite(foc,b2,1);
    for comz:=0 to comy-1 do begin
        BlockWrite(foc,buff[comz],1);
    end;
    comi:=0; comy:=0; b2:=0;
    closefile(fic);
    closefile(foc);
    Form1.Edit3.Text:='compl';

end;

procedure TDecompress.compressing;
var
    comi,comy,comj,comz,comx: integer;
begin
    Form1.Edit3.Text:='kdjhhghg';
    for comi:=0 to 255 do begin
        for comj:=0 to 255 do begin
            masc[comi,comj]:=' ';
        end;
    end;
    b2:=0; FilNam:=''; b1:=0; oldB1:=0; oldB2:=0; comi:=0;
    assignfile(fic,Form1.OpenDialog1.FileName);
    reset(fic,1);
    BlockRead(fic,b1,1);
    for comx:=1 to b1 do begin
        BlockRead(fic,b1,1);
        //FilNam[comx]:=chr(b1);
    end;
    assignfile(foc,'rez');
    rewrite(foc,1);
    b2:=0; comx:=0; comy:=0;
    a:=ord(oldB2); b:=ord(oldB1);
    while not eof(fic) do begin
        if not EOF(fic) then BlockRead(fic,b1,1);
        for comi:=0 to 7 do begin
            if (b1 and  stepen(comi))=stepen(comi) then begin
                b2:=ord(masc[a,b]);
                BlockWrite(foc,masc[a,b],1);
                oldB2:=oldB1; oldB1:=b2;
                a:=ord(oldB2); b:=ord(oldB1);
            end
            else begin
                if not EOF(fic) then begin
                    BlockRead(fic,b2,1);
                    BlockWrite(foc,b2,1);
                    masc[a,b]:=chr(b2);
                    oldB2:=oldB1; oldB1:=b2;
                    a:=ord(oldB2); b:=ord(oldB1);
                end;
            end;
        end;
        b1:=0;
    end;

    closefile(fic);
    closefile(foc);
    Form1.Edit3.Text:='upacked';
end;

procedure TArxivation.kpd;
var i,j: integer;
    k: real;
    nam1,nam2: LPDWORD;
begin
    compressing;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
    Compress:=TCompress.Create;
    OpenDialog1.Execute;
    Compress.kpd;
    Compress.Destroy;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
    Decompress:=TDecompress.Create;
    OpenDialog1.Execute;
    Decompress.kpd;
    Decompress.Destroy;
end;

{$R *.dfm}

procedure TForm1.Button4Click(Sender: TObject);
begin
Close;
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
    Arxiv.kpd;
end;

procedure TForm1.Button3Click(Sender: TObject);
var lin,i,j: integer;
begin
    lin:=Length(Form1.Edit1.Text);
    for i:=1 to lin do begin
        b1:=Ord(Form1.Edit1.Text[i]);
        if (mas[a,b]=chr(b1)) then begin
            b2:=b2+stepen(comi);
        end
        else begin
            masc[a,b]:=chr(b1);
            buff[comy]:=b1;
            comy:=comy+1;
        end;
        oldB2:=oldB1; oldB1:=b1;
        a:=ord(oldB2); b:=ord(oldB1);
        if comi=7 then begin
            BlockWrite(foc,b2,1);
            for comz:=0 to comy-1 do begin
                BlockWrite(foc,buff[comz],1);
            end;
            comi:=0; comy:=0; b2:=0;
        end
        else comi:=comi+1;

    end;
    Blockwrite(foc,b2,1);
    for comz:=0 to comy-1 do begin
        BlockWrite(foc,buff[comz],1);
    end;

end;

end.
