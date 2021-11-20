unit MainForm;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, TeEngine, Series, ExtCtrls, TeeProcs, Chart,
  Processes, Maps;

type
  TForm1 = class(TForm)
    MemoryChart: TChart;
    Series1: TPieSeries;
    PhysicalChart: TChart;
    PieSeries1: TPieSeries;
    PageFileChart: TChart;
    PieSeries2: TPieSeries;
    VirtualChart: TChart;
    PieSeries3: TPieSeries;
    ProcessesComboBox: TComboBox;
    ProcessHandleLabel: TLabel;
    RefreshProcessesButton: TButton;
    DiagramsTimer: TTimer;
    PaintBoxWhole: TPaintBox;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    lbSelectedRange: TLabel;
    lbLowestSelected: TLabel;
    lbMiddleSelectedLow: TLabel;
    lbMiddleSelectedHigh: TLabel;
    lbHighestSelected: TLabel;
    PaintBoxSelected: TPaintBox;
    Label14: TLabel;
    Label15: TLabel;
    Label16: TLabel;
    lbSelectedPage: TLabel;
    gbLegend: TGroupBox;
    ShapeUnknown: TShape;
    Label5: TLabel;
    ShapeFree: TShape;
    Label6: TLabel;
    ShapeMixed: TShape;
    Label7: TLabel;
    ShapeSystem: TShape;
    Label8: TLabel;
    ShapePrivate: TShape;
    ShapeMapped: TShape;
    ShapeImage: TShape;
    Label9: TLabel;
    ShapeReserved: TShape;
    Label10: TLabel;
    Label11: TLabel;
    Label12: TLabel;
    btnRefreshProcessMap: TButton;
    procedure FormCreate(Sender: TObject);
    procedure ProcessesComboBoxChange(Sender: TObject);
    procedure RefreshProcessesButtonClick(Sender: TObject);
    procedure DiagramsTimerTimer(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure PaintBoxWholePaint(Sender: TObject);
    procedure PaintBoxSelectedPaint(Sender: TObject);
    procedure PaintBoxSelectedMouseDown(Sender: TObject;
      Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
    procedure btnRefreshProcessMapClick(Sender: TObject);
    procedure PaintBoxWholeMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
  private
    { Private declarations }
    ProcessList: TProcessList;
    fCouldRepaintSelectedMap: boolean;
    hCurrentProcess: THandle;
    WholeMemory: TMemory;
    SelectedMemory: TMemory;
    fPrevSuccess: boolean;
    procedure RefreshDiagrams;
    procedure MakeProcessList;
    procedure RefreshHandleLabel;
    procedure DrawLegend;
    procedure DrawWholeMap;
    procedure DrawSelectedMap;
    procedure SelectWholeMapEntry(EntryIndex: Integer);
    procedure RefreshProcessMap;
    function GetPaintBoxIndex(X, Y: integer; PaintBox: TPaintBox): integer;
  public
    { Public declarations }
  end;

const
  DefaultProcessItem = 'OSLab4.exe';

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.RefreshDiagrams;
var lpBuffer: _MEMORYSTATUS;
begin
  Windows.GlobalMemoryStatus(lpBuffer);
  with Series1 do begin
    Clear;
    AddPie(lpBuffer.dwMemoryLoad, 'Занято', clRed);
    AddPie(100-lpBuffer.dwMemoryLoad, 'Свободно', clLime);
  end;
  with PieSeries1 do begin
    Clear;
    AddPie(lpBuffer.dwTotalPhys-lpBuffer.dwAvailPhys, 'Занято', clRed);
    AddPie(lpBuffer.dwAvailPhys, 'Свободно', clLime);
  end;
  with PieSeries2 do begin
    Clear;
    AddPie(lpBuffer.dwTotalPageFile-lpBuffer.dwAvailPageFile, 'Занято', clRed);
    AddPie(lpBuffer.dwAvailPageFile, 'Свободно', clLime);
  end;
  with PieSeries3 do begin
    Clear;
    AddPie(lpBuffer.dwTotalVirtual-lpBuffer.dwAvailVirtual, 'Занято', clRed);
    AddPie(lpBuffer.dwAvailVirtual, 'Свободно', clLime);
  end;
end;

procedure TForm1.MakeProcessList;
var i: integer;
begin
  ProcessesComboBox.Clear;
  for i:=0 to ProcessList.Count-1 do
    ProcessesComboBox.Items.Add(ProcessList.Get(i).Name);
  if (ProcessesComboBox.Items.Count > 0) then
    with ProcessesComboBox do begin
      ItemIndex:=0;
      for i:=0 to Items.Count-1 do
        if (UpperCase(Items[i])=UpperCase(DefaultProcessItem)) then begin
          ItemIndex:=i;
          break;
        end;
    end;
  RefreshHandleLabel;
end;

procedure TForm1.RefreshHandleLabel;
var index: integer; item: string; id: DWORD;
begin
  fPrevSuccess:=true;
  index:=ProcessesComboBox.ItemIndex;
  item:=ProcessesComboBox.Items[index];
  id:=ProcessList.GetProcess(item);
  if hCurrentProcess <> GetCurrentProcess then
    CloseHandle(hCurrentProcess);
  hCurrentProcess:=OpenProcess(PROCESS_QUERY_INFORMATION, true, id);
  ProcessHandleLabel.Caption:='Идентификатор: ' + IntToStr(id);
end;

procedure TForm1.DrawLegend;
begin
  ShapeUnknown.Brush.Color:=  TMemory.MapEntryColor(MemUnknown);
  ShapeFree.Brush.Color:=     TMemory.MapEntryColor(MemFree);
  ShapeMixed.Brush.Color:=    TMemory.MapEntryColor(MemMixed);
  ShapeSystem.Brush.Color:=   TMemory.MapEntryColor(MemSystem);
  ShapePrivate.Brush.Color:=  TMemory.MapEntryColor(MemPrivate);
  ShapeMapped.Brush.Color:=   TMemory.MapEntryColor(MemMapped);
  ShapeImage.Brush.Color:=    TMemory.MapEntryColor(MemImage);
  ShapeReserved.Brush.Color:= TMemory.MapEntryColor(MemReserve);
end;

procedure TForm1.DrawWholeMap;
begin
  PaintBoxWhole.Invalidate;
end;

procedure TForm1.DrawSelectedMap;
begin
  fCouldRepaintSelectedMap:=true;
  PaintBoxSelected.Invalidate;
end;

procedure TForm1.SelectWholeMapEntry(EntryIndex: Integer);
var StartAddress, EndAddress: DWORD;
begin
  StartAddress := DWORD(EntryIndex)*WholeMemory.EntrySize;
  EndAddress := DWORD((EntryIndex+1))*WholeMemory.EntrySize-1;
  lbSelectedRange.Caption := Format('Выбранный диапазон: 0x%.8x-0x%.8x',
    [StartAddress, EndAddress]);
  if EntryIndex >= 512 then begin
    SelectedMemory.FillRegion(0, 1024, MemSystem);
    SelectedMemory.StartAddress := StartAddress;
    SelectedMemory.EndAddress := EndAddress;
  end else begin
    fPrevSuccess:=false;
    SelectedMemory.GetSelectedMemory(hCurrentProcess, StartAddress, EndAddress);
    fPrevSuccess:=true;
  end;
  lbLowestSelected.Caption := Format('0x%.8x', [StartAddress]);
  lbMiddleSelectedLow.Caption := Format('0x%.8x', [StartAddress +
    DWORD(WholeMemory.EntrySize div 2 - 1)]);
  lbMiddleSelectedHigh.Caption := Format('0x%.8x', [StartAddress +
    DWORD(WholeMemory.EntrySize div 2)]);
  lbHighestSelected.Caption := Format('0x%.8x', [EndAddress]);
  lbSelectedPage.Caption := 'не выбран';
  DrawSelectedMap;
end;

procedure TForm1.RefreshProcessMap;
begin
  fPrevSuccess:=false;
  try
    WholeMemory.GetWholeMemory(hCurrentProcess);
    fPrevSuccess:=true;
  except
    SelectedMemory.FillRegion(0, 1024, MemUnknown);
    WholeMemory.FillRegion(0, 1024, MemUnknown);
    DrawWholeMap;
    DrawSelectedMap;
  end;
  DrawWholeMap;
  SelectWholeMapEntry(0);
end;

function TForm1.GetPaintBoxIndex(X, Y: integer; PaintBox: TPaintBox): integer;
var EntryX, EntryY, GridHeight, GridWidth: integer;
begin
  GridHeight:=PaintBox.Height div 32;
  GridWidth :=PaintBox.Width  div 32;
  EntryX:=(X div GridWidth);
  EntryY:=(Y div GridHeight);
  Result:=EntryY*32+EntryX;
end;

procedure TForm1.ProcessesComboBoxChange(Sender: TObject);
begin
  RefreshHandleLabel;
  RefreshProcessMap;
end;

procedure TForm1.RefreshProcessesButtonClick(Sender: TObject);
begin
  RefreshDiagrams;
  ProcessList.Refresh;
  MakeProcessList;
  RefreshProcessMap;
end;

procedure TForm1.DiagramsTimerTimer(Sender: TObject);
begin
  RefreshDiagrams;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  fPrevSuccess:=true;
  hCurrentProcess:=GetCurrentProcess;
  DrawLegend;
  ProcessList:=TProcessList.Create;
  MakeProcessList;
  WholeMemory:=TMemory.Create(4096*1024);
  SelectedMemory:=TMemory.Create(4096);
  RefreshProcessMap;
end;

procedure TForm1.FormDestroy(Sender: TObject);
begin
  ProcessList.Free;
  WholeMemory.Free;
  SelectedMemory.Free;
  if hCurrentProcess <> GetCurrentProcess then
    CloseHandle(hCurrentProcess);
end;

procedure TForm1.PaintBoxWholePaint(Sender: TObject);
begin
  WholeMemory.Draw(Sender as TPaintBox);
end;

procedure TForm1.PaintBoxSelectedPaint(Sender: TObject);
begin
  if not fCouldRepaintSelectedMap then exit;
  SelectedMemory.Draw(Sender as TPaintBox);
end;

procedure TForm1.PaintBoxSelectedMouseDown(Sender: TObject;
  Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
var EntryIndex: integer; Address: DWORD;
  PaintBox : TPaintBox;
begin
  PaintBox:=Sender as TPaintBox;
  if Button=mbLeft then begin
    EntryIndex:=GetPaintBoxIndex(X, Y, PaintBox);
    Address:=DWORD(DWORD(EntryIndex)*SelectedMemory.EntrySize)+
      SelectedMemory.StartAddress;
    lbSelectedPage.Caption := Format('%.8x', [Address]);
  end;
end;

procedure TForm1.btnRefreshProcessMapClick(Sender: TObject);
begin
  RefreshProcessMap;
end;

procedure TForm1.PaintBoxWholeMouseDown(Sender: TObject;
  Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
var EntryIndex: integer; PaintBox: TPaintBox;
begin
  PaintBox:=Sender as TPaintBox;
  if Button = mbLeft then begin
    EntryIndex:=GetPaintBoxIndex(X, Y, PaintBox);
    SelectWholeMapEntry(EntryIndex);
  end;
end;

end.
