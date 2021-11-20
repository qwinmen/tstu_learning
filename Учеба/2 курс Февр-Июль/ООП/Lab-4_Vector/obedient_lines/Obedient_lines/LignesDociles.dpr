program LignesDociles;

uses
  Forms,
  Unit_Princ in 'Unit_Princ.pas' {FichePrinc};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TFichePrinc, FichePrinc);
  Application.Run;
end.
