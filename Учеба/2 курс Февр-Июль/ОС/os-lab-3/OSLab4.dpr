program OSLab4;

uses
  Forms,
  MainForm in 'MainForm.pas' {Form1},
  Processes in 'Processes.pas',
  Maps in 'Maps.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
