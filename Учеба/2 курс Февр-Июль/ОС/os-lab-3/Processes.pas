unit Processes;

interface

uses Classes, Windows, TlHelp32, SysUtils;

type
  TProcessInfo = class(TObject)
  private
    FName: string;
    FId: DWORD;
  public
    constructor Create(name: string; id: DWORD);
    property Name: string read FName;
    property Id: DWORD read FId;
  end;

  TProcessList = class(TObject)
  private
    InfoList: TList;
    FCount: integer;
  public
    constructor Create;
    destructor Free; virtual;
    property Count: integer read FCount;
    procedure Refresh;
    function GetProcess(Id: DWORD): string; overload;
    function GetProcess(Name: string): DWORD; overload;
    function Get(i: integer): TProcessInfo;
  end;


implementation

uses PsAPI;

constructor TProcessInfo.Create(name: string; id: DWORD);
begin
  self.FName:=name;
  self.FId:=id;
end;

constructor TProcessList.Create;
begin
  InfoList:=TList.Create;
  self.Refresh;
end;

destructor TProcessList.Free;
begin
  InfoList.Free;
end;

procedure TProcessList.Refresh;
var Handle: THandle; Entry: TProcessEntry32; fRepeat: LONGBOOL;
  Info: TProcessInfo;
begin
  InfoList.Clear;
  Handle:=CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
  Entry.dwSize:=sizeof(TProcessEntry32);
  fRepeat:=Process32First(Handle, Entry);
  while (fRepeat) do begin
    Info:=TProcessInfo.Create(Entry.szExeFile, Entry.th32ProcessID);
    InfoList.Add(Info);
    fRepeat:=Process32Next(Handle, Entry);
  end;
  CloseHandle(Handle);
  FCount:=InfoList.Count;
end;

function TProcessList.GetProcess(Id: DWORD): string;
var i: integer; Info: TProcessInfo;
begin
  Result:='';
  for i:=0 to InfoList.Count-1 do begin
    Info:=InfoList.Items[i];
    if Info.Id=Id then begin
      Result:=Info.Name;
      exit;
    end;
  end;
end;

function TProcessList.GetProcess(Name: string): DWORD;
var i: integer; Info: TProcessInfo;
begin
  Result:=0;
  for i:=0 to InfoList.Count-1 do begin
    Info:=InfoList.Items[i];
    if Info.Name=Name then begin
      Result:=Info.Id;
      exit;
    end;
  end;
end;

function TProcessList.Get(i: integer): TProcessInfo;
begin
  Result:=InfoList.Items[i];
end;


end.
