{$G+}
Uses CRT, VESA;

(*    non-VESA Modes    *)
(*   13h 320x200x256    *)
(*      VESA Modes      *)
(*  100h 640x400x256    *)
(*  101h 640x480x256    *)
(*  103h 800x600x256    *)
(*  105h 1024x768x256   *)
(*        Modes         *)

Const
  Mode : Word = $101;

Var
  VESAInfo : TVESAInfo;
  ModeInfo : TVESAModeInfo;
  I, J : Word;
  PCh : PChar;

Procedure VESAError (Msg : String);
Begin
  WriteLn (Msg, #13#10'(Operation fail or not supproted!)');
  Halt
End;

Begin
  ClrScr;
  If not IsVESA then Begin
    WriteLn ('No VESA support!');
    Exit
  End;
  With VESAInfo do Begin
    GetVESAInfo (VESAInfo);
    Write ('ID: '); For I := 0 to 3 do Write (ID[I]);
    WriteLn (' ver ', Ver shr 8, '.', Ver and 255);
    Write ('OEM name: '); PCh := POEMName;
    While (PCh^ <> #0) do Begin Write (PCh^); Inc(PCh) End; WriteLn;
    WriteLn ('Memory on board: ', TotalMemory*64, ' KB')
  End;
  WriteLn (#13#10'Mode ', Mode, ' (dec):');
  If GetVESAModeInfo (Mode, ModeInfo) then
    With ModeInfo do Begin
      WriteLn ('Mode attributes: ', Attrs);
      WriteLn ('Window A attributes: ', WinAAttrs);
      WriteLn ('Window B attributes: ', WinBAttrs);
      WriteLn ('Window granularity: ', WinGranul, ' KB');
      WriteLn ('Window size: ', WinSize, ' KB');
      WriteLn ('Window A segment: ', WinASeg);
      WriteLn ('Window B segment: ', WinBSeg);
      WriteLn ('Bytes per scanline: ', BytesPerScanLine);
      WriteLn ('Dimensions: ', Width, 'x', Height);
      WriteLn ('Character cell dimensions: ', CharWidth, 'x', CharHeight);
      WriteLn ('Planes: ', Planes);
      WriteLn ('Bits per pixel: ', BitsPerPixel);
      WriteLn ('Banks: ', Banks);
      WriteLn ('Memory model type: ', MemoryModel);
      WriteLn ('Bank size: ', BankSize, ' KB')
    End
  Else
    VESAError ('Couldn''t get VESA mode info!');

  Write (#13#10'Press any key for demo...'); ReadKey; WriteLn;

  SetVESAMode (Mode);

  ClearScreen (Green);
  ReadKey;

  For J := 0 to GetMaxY do
    For I := 0 to GetMaxX do
      PutPixel (I, J, Random(8));

  Line (0, 0, GetMaxX, GetMaxY, LightCyan);
  Line (GetMaxX, 0, 0, GetMaxY, LightCyan);
  Line (0, 0, GetMaxX, 0, Yellow);
  Line (0, GetMaxY, GetMaxX, GetMaxY, Yellow);
  Line (0, 0, 0, GetMaxY, Yellow);
  Line (GetMaxX, 0, GetMaxX, GetMaxY, Yellow);
  ReadKey;

  For I := 0 to 15 do
    For J := 0 to GetMaxY do
      LineH (0, J, GetMaxX+1, I);
  ReadKey;

  For J := 0 to 15 do
    For I := 0 to GetMaxX do
      LineV (I, 0, GetMaxY+1, J);
  ReadKey;

  For I := 0 to GetMaxY shr 1 do
    LineH ((GetMaxX shr 1)-I, I, I shl 1, Yellow);
  For I := 0 to GetMaxY shr 1 do
    LineH ((GetMaxX shr 1)-I, GetMaxY-I, I shl 1, Blue);
  ReadKey;

  Ellipse (GetMaxX shr 1, GetMaxY shr 1, GetMaxX shr 1, GetMaxY shr 1,
           Green, True);
  ReadKey;

  Box (10, 10, GetMaxX+1-20, GetMaxY+1-20, Black, False);
  ReadKey;

  Circle (GetMaxX shr 1, GetMaxY shr 1, GetMaxY shr 1, LightRed, True);
  ReadKey;

  For J := 0 to GetMaxY shr 1 do
    For I := 0 to GetMaxX shr 1 do
      PutPixel (I+(GetMaxX shr 1), J+(GetMaxY shr 1), GetPixel(I,J));
  ReadKey;

  TextMode (CO80);
{$IFDEF DPMI}
  FreeRMInfos;
{$ENDIF}
End.
