program HaffmanProject;

uses
  Forms,
  HaffmanArch in 'HaffmanArch.pas' {Form1} ,
  Haffman in 'Haffman.pas',
  Shannon in 'Shannon.pas';
{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
