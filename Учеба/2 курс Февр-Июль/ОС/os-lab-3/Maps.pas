unit Maps;

interface

uses Windows, Graphics, SysUtils, ExtCtrls;

const
  MaxUserAddress = $7FFF0000;
  MemUnknown = 0;
  MemFree = 1;
  MemMixed = 2;
  MemSystem = 3;
  MemPrivate = 4;
  MemMapped = 5;
  MemImage = 6;
  MemReserve = 7;

var
  clMemUnknown, clMemFree, clMemMixed, clMemSystem,
  clMemPrivate, clMemMapped, clMemImage, clMemReserve: TColor;

type
  TMemoryMap = array[0..1023] of byte;

  TMemory = class
  private
    FEndAddress: DWORD;
    FStartAddress: DWORD;
    FMap: TMemoryMap;
    FEntrySize: DWORD;
    function GetMap(I: Integer): byte;
    procedure PutMap(I: Integer; const Value: byte);
    function GetMemory(Process: THandle): boolean;
  public
    constructor Create(AEntrySize: DWORD);
    class function MapEntryColor(const MapEntry: byte): TColor;
    procedure RegionToMap(RegionStart, RegionSize: DWORD; MemType: byte);
    procedure FillRegion(MapStart, MapSize: DWORD; MemType: byte);
    procedure Draw(PaintBox: TPaintBox);
    function GetWholeMemory(Process: THandle): boolean;
    function GetSelectedMemory(Process: THandle;
      StartAddress, EndAddress: DWORD): boolean;
    //property MapArray: TMemoryMap read FMap;
    property Map[I: Integer]: byte read GetMap write PutMap;
    property StartAddress: DWORD read FStartAddress write FStartAddress;
    property EndAddress: DWORD read FEndAddress write FEndAddress;
    property EntrySize: DWORD read FEntrySize;
  end;


implementation

constructor TMemory.Create(AEntrySize: DWORD);
begin
  FStartAddress:=0;
  FEndAddress:=MaxUserAddress;
  FEntrySize:=AEntrySize;
end;

function TMemory.GetMap(I: Integer): byte;
begin
  Result:=FMap[I];
end;

procedure TMemory.PutMap(I: Integer; const Value: byte);
begin
  FMap[I]:=Value;
end;

class function TMemory.MapEntryColor(const MapEntry: byte): TColor;
begin
  Result:=clMemUnknown;
  case MapEntry of
    MemFree:    Result:=clMemFree;
    MemMixed:   Result:=clMemMixed;
    MemSystem:  Result:=clMemSystem;
    MemImage:   Result:=clMemImage;
    MemMapped:  Result:=clMemMapped;
    MemPrivate: Result:=clMemPrivate;
    MemReserve: Result:=clMemReserve;
  end;
end;

procedure TMemory.RegionToMap(RegionStart, RegionSize: DWORD; MemType: byte);
var i: integer; StartEntryIndex, EndEntryIndex: integer;
begin
  StartEntryIndex:=RegionStart div FEntrySize;
  EndEntryIndex:=(RegionStart+RegionSize-1) div FEntrySize;
  for i:=StartEntryIndex to EndEntryIndex do begin
    if (FMap[i]<>MemUnknown) and (FMap[i]<>MemType) then
      FMap[i]:=MemMixed
    else
      FMap[i]:=MemType;
  end;
end;

procedure TMemory.FillRegion(MapStart, MapSize: DWORD; MemType: byte);
var i: integer; MapEnd: DWORD;
begin
  MapEnd:=MapStart+MapSize-1;
  for i:=MapStart to MapEnd do
    FMap[i]:=MemType;
end;

function TMemory.GetMemory(Process: THandle): boolean;
var MBI: TMemoryBasicInformation; Address: ULONG; rc: integer; MemType: byte;
  MapAddress, MapSize: DWORD;
begin
  Result:=false;
  Address:=self.StartAddress;
  while (Address < self.EndAddress) and (Address < MaxUserAddress) do begin
    rc := VirtualQueryEx(Process, pointer(Address), MBI, SizeOf(MBI));
    if rc <> sizeof(MBI) then
      raise Exception.Create(SysErrorMessage(GetLastError));
    MemType:=MemUnknown;
    case MBI.State of
    MEM_FREE:
      MemType:=MemFree;
    MEM_RESERVE:
      MemType:=MemReserve;
    MEM_COMMIT:
      case MBI.Type_9 of
      MEM_IMAGE:
        MemType:=MemImage;
      MEM_MAPPED:
        MemType:=MemMapped;
      MEM_PRIVATE:
        MemType:=MemPrivate;
      end;
    end;
    MapAddress:=DWORD(MBI.BaseAddress);
    MapSize:=MBI.RegionSize;
    if MapAddress < Address then begin
      MapAddress:=Address;
      dec(MapSize, Address - DWORD(MBI.BaseAddress));
    end;
    if MapAddress + MapSize > self.EndAddress then
      MapSize := self.EndAddress - MapAddress + 1;
    self.RegionToMap(MapAddress - self.StartAddress, MapSize, MemType);
    if MBI.RegionSize = 0 then
      MBI.RegionSize := 4096;
    Address := DWORD(MBI.BaseAddress) + MBI.RegionSize;
  end;
  Result:=true;
end;

function TMemory.GetWholeMemory(Process: THandle): boolean;
begin
  self.FillRegion(0, 512, MemUnknown);
  self.FillRegion(512, 512, MemSystem);
  Result:=self.GetMemory(Process);
end;

function TMemory.GetSelectedMemory(Process: THandle;
  StartAddress, EndAddress: DWORD): boolean;
begin
  self.FillRegion(0, 1024, MemUnknown);
  self.StartAddress:=StartAddress;
  self.EndAddress:=EndAddress;
  Result:=self.GetMemory(Process);
end;

procedure TMemory.Draw(PaintBox: TPaintBox);
var Column, GridHeight, GridWidth, Row, i: integer;
  BrushNew, BrushOld: HBRUSH;
begin
  GridHeight:=PaintBox.Height div 32;
  GridWidth:=PaintBox.Width div 32;
  for i:=0 to 1023 do begin
    Row:=i div 32; Column:=i mod 32;
    BrushNew:=CreateSolidBrush(TMemory.MapEntryColor(FMap[I]));
    BrushOld:=SelectObject(PaintBox.Canvas.Handle, BrushNew);
    Rectangle(PaintBox.Canvas.Handle, GridWidth*Column, GridHeight*Row,
      GridWidth*(Column+1), GridHeight*(Row+1));
    SelectObject(PaintBox.Canvas.Handle, BrushOld);
    DeleteObject(BrushNew);
  end;
end;


Begin
  clMemUnknown:=RGB(192,192,192);
  clMemFree:=RGB(255,255,255);
  clMemMixed:=RGB(255,128,128);
  clMemSystem:=RGB(0,0,255);
  clMemImage:=RGB(0,255,0);
  clMemMapped:=RGB(255,255,0);
  clMemPrivate:=RGB(255,0,0);
  clMemReserve:=RGB(255,128,255);
End.
