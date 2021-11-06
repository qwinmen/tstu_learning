Unit VESA;
{$G+}

(************************)
(* Valid non-VESA modes *)
(*   $13  320x200x256   *)
(************************)

(*********************)
(* Valid  VESA modes *)
(*                   *)
(* $100  640x400x256 *)
(* $101  640x480x256 *)
(* $104  800x600x256 *)
(* $105 1024x768x256 *)
(*********************)

Interface

Const
  TranspColor   : Byte = 0;             { Transparency color needs in the }
                                               { PutTranspImage procedure }
Var
  GetMaxX,                              { Maximum value for X on the screen }
  GetMaxY       : Word;                 { Maximum value for Y on the screen }
  _YOffs        : Array [0..767] of LongInt;    { Lookup table for each Y }
  _Granularity,                         { Window size in granules }
  _Granule,                             { Curren granule for window }
  _GMask        : Word;                 { Offset mask for current granule }
  _GShift       : Byte;                 { Shift counter for current granule }
  _FontL,
  _FontH,
  _FontHS       : Word;
  _PFont        : Pointer;
  _Poly         : Array [0..1023, 1..2] of Integer;

Type
  TVESAInfo = Record
    ID          : Array [0..3] of Char;         { 'VESA' }
    Ver         : Word;
    POEMName    : PChar;
    Capatibs    : LongInt;
    PModesList  : Pointer;
    TotalMemory : Word;                         { in 64K blocks }
    Res         : Array [0..235] of Byte
  End;
  TVESAModeInfo = Record
    Attrs       : Word;
    WinAAttrs,
    WinBAttrs   : Byte;
    WinGranul,
    WinSize,
    WinASeg,
    WinBSeg     : Word;
    PWinPosFunc : Pointer;
    BytesPerScanLine,
    Width,
    Height      : Word;
    CharWidth,
    CharHeight,
    Planes,
    BitsPerPixel,
    Banks,
    MemoryModel,
    BankSize    : Byte;
    Res         : Array [0..226] of Byte
  End;
  TPoint = Record
    X, Y : Integer
  End;

Function IsVGA : Boolean;
Function IsVESA : Boolean;
Function GetVESAInfo (Var VESAInfo : TVESAInfo) : Boolean;
Function GetVESAModeInfo (Mode : Word; Var VESAModeInfo : TVESAModeInfo) : Boolean;
Procedure SetVESAMode (Mode : Word);
Function GetVESAMode : Word;
Procedure ClearScreen (Color : Byte);
Procedure PutPixel (X, Y : Word; Color : Byte);
Function GetPixel (X, Y : Word) : Byte;
Procedure LineH (X, Y, L : Word; Color : Byte);
Procedure LineV (X, Y, H : Word; Color : Byte);
Procedure Box (X, Y, L, H : Word; Color : Byte; Fill : Boolean);
Procedure Line (x1, Y1, X2, Y2 : Word; Color : Byte);
Procedure Circle (X, Y, R : Word; C : Byte; Fill : Boolean);
Procedure Ellipse (X, Y, A, B : Word; C : Byte; Fill : Boolean);
Procedure DrawPoly (Num : Word; PolyPoints : Array of TPoint; C : Byte);
Procedure DrawPoly2 (Num : Word; PolyPoints : Array of TPoint; C : Byte);
Procedure FillPoly (Num : Word; PolyPoints : Array of TPoint; C : Byte);
Procedure FillPolyPat (Num : Word; PolyPoints : Array of TPoint;
                             L, H : Word; Var Pat);   { PatternSize <= 64K }
Procedure SetFont (PFont : Pointer; L, H : Word); { L<=16, FontSize <= 64K }
Procedure OutTextXY (X, Y : Word; TextString : String; Color : Byte);
Function ImageSize (L, H : Word) : LongInt;
Procedure GetImage (X, Y, L, H : Word; Var BitMap);
Procedure PutImage (X, Y : Word; Var BitMap);
Procedure PutTranspImage (X, Y : Word; Var BitMap);
Procedure WaitRetrace;
Procedure GetCRGB (C : Byte; Var R, G, B : Byte);
Procedure SetCRGB (C : Byte; R, G, B : Byte);
Procedure GetPal (Var Pal);
Procedure SetPal (Var Pal);
Function LSqrt (X : LongInt) : LongInt;

{$IFDEF DPMI}
Function FreeRMInfos : Boolean;
{$ENDIF}

Implementation

{$IFDEF DPMI}
Uses DOS, WinAPI;
{$ELSE}
Uses DOS;
{$ENDIF}

{$L VESA.OBJ}

Type
  PRegs = ^TRegs;
  TRegs = Record
     EDI, ESI, EBP, Res, EBX, EDX, ECX, EAX : LongInt;
     Flags, ES, DS, FS, GS, IP, CS, SP, SS : Word;
  End;

{$IFDEF DPMI}
Var
  PRMVESAInfo : ^TVESAInfo;
  PRMModeInfo : ^TVESAModeInfo;
  RMVESAInfoHandle,
  RMVESAInfoSeg,
  RMModeInfoHandle,
  RMModeInfoSeg : LongInt;
{$ENDIF}


(*************** DPMI Support functions ***************)

{$IFDEF DPMI}
Function AllocRMInfos : Boolean;
Begin
  RMVESAInfoHandle := GlobalDOSAlloc (SizeOf(TVESAInfo));
  RMVESAInfoSeg := RMVESAInfoHandle shr 16;
  PRMVESAInfo := Ptr (RMVESAInfoHandle and $FFFF, 0);
  RMModeInfoHandle := GlobalDOSAlloc (SizeOf(TVESAModeInfo));
  RMModeInfoSeg := RMModeInfoHandle shr 16;
  PRMModeInfo := Ptr (RMModeInfoHandle and $FFFF, 0);
  AllocRMInfos := True
End;

Function FreeRMInfos : Boolean;
Begin
  GlobalDOSFree (RMVESAInfoHandle);
  GlobalDOSFree (RMModeInfoHandle);
  FreeRMInfos := True
End;

Function Seg2Sel (Var Segment : Word) : Boolean;
Var R : Registers;
Begin
  R.AX := 2;
  R.BX := Segment;
  Intr ($31, R);
  If R.Flags and FCarry <> 0 then Seg2Sel := False;
  Segment := R.AX;
  Seg2Sel := True
End;

Function RealIntr (Int : Byte; Var RMR : Registers) : Boolean;
Var
  R : Registers;
  Regs : TRegs;
Begin
  With RMR, Regs do Begin
    EAX := AX;
    EBX := BX;
    ECX := CX;
    EDX := DX;
    EBP := BP;
    ESI := SI;
    EDI := DI;
    Regs.Flags := RMR.Flags;
    Regs.DS := RMR.DS;
    Regs.ES := RMR.ES;
    SP := 0;
    SS := 0
  End;
  R.AX := $300;
  R.BL := Int;
  R.BH := 0;
  R.CX := 0;
  R.ES := Seg (Regs);
  R.DI := Ofs (Regs);
  Intr ($31, R);
  If R.Flags and FCarry <> 0 then RealIntr := False;
  With RMR, Regs do Begin
    AX := EAX;
    BX := EBX;
    CX := ECX;
    DX := EDX;
    BP := EBP;
    SI := ESI;
    DI := EDI;
    RMR.Flags := Regs.Flags;
    RMR.DS := Regs.DS;
    RMR.ES := Regs.ES
  End;
  RealIntr := True
End;
{$ENDIF}

(*************** DPMI Support functions ***************)

Function IsVGA : Boolean; Assembler;
Asm
  Mov   AX, 1A00h
  Int   10h
  Cmp   AL, 1Ah
  JNE   @@NotVGA
  Cmp   BL, 7
  JE    @@VGA
  Cmp   BL, 8
  JE    @@VGA
@@NotVGA:
  Mov   AL, 0
  Jmp   @@Quit
@@VGA:
  Mov   AL, 1
@@Quit:
End;

Function IsVESA : Boolean;
Var VESAInfo : TVESAInfo;
Begin
  IsVESA := GetVESAInfo (VESAInfo) and (VESAInfo.ID = 'VESA')
End;

Function GetVESAInfo (Var VESAInfo : TVESAInfo) : Boolean;
Type
  TPP = Record
    O, S : Word;
  End;
Var
  R : Registers;
  P : TPP;
Begin
  R.AX := $4F00;
{$IFDEF DPMI}
  R.ES := RMVESAInfoSeg;
  R.DI := 0;
  RealIntr ($10, R);
  VESAInfo := PRMVESAInfo^;
  P := TPP(VESAInfo.POEMName);
  Seg2Sel (P.S);
  VESAInfo.POEMName := Ptr (P.S, P.O);
{$ELSE}
  R.ES := Seg (VESAInfo);
  R.DI := Ofs (VESAInfo);
  Intr ($10, R);
{$ENDIF}
  GetVESAInfo := R.AX = $4F
End;

Function GetVESAModeInfo (Mode : Word; Var VESAModeInfo : TVESAModeInfo) : Boolean;
Var R : Registers;
Begin
  R.AX := $4F01;
  R.CX := Mode;
{$IFDEF DPMI}
  R.ES := RMModeInfoSeg;
  R.DI := 0;
  RealIntr ($10, R);
  VESAModeInfo := PRMModeInfo^;
{$ELSE}
  R.ES := Seg (VESAModeInfo);
  R.DI := Ofs (VESAModeInfo);
  Intr ($10, R);
{$ENDIF}
  If Mode = $13 then with VESAModeInfo do Begin
    FillChar (VESAModeInfo, SizeOf(TVESAModeInfo), 0);
    Attrs := $1f;
    WinAAttrs := 7;
    WinGranul := 64;
    WinSize := 64;
    WinASeg := SegA000;
    BytesPerScanLine := 320;
    Width := 320;
    Height := 200;
    CharWidth := 8;
    CharHeight := 8;
    Planes := 1;
    BitsPerPixel := 8;
    Banks := 1;
    MemoryModel := 4;
    R.AX := $4F
  End;
  GetVESAModeInfo := R.AX = $4F
End;

Procedure SetVESAMode (Mode : Word);
Const
  ValidModes : Array [0..4] of Word = ($13, $100, $101, $103, $105);
  Valid : Boolean = False;
Var
  R : Registers;
  Y : LongInt;
  ModeInfo : TVESAModeInfo;
Begin
  For Y := 0 to 4 do
    If Mode = ValidModes[Y] then Valid := True;
  If not Valid then Exit;
  R.AX := $4F02;
  R.BX := Mode;
  Intr ($10, R);
  GetVESAModeInfo (Mode, ModeInfo);
  GetMaxX := ModeInfo.Width-1;
  GetMaxY := ModeInfo.Height-1;
  _Granularity := ModeInfo.WinGranul;
  For Y := 0 to GetMaxY do
    _YOffs[Y] := Y*(GetMaxX+1);
  _Granule := 0;
  _GMask := $400*_Granularity-1;
  _GShift := 10;
  While _Granularity > 1 do Begin
    Inc (_GShift);
    _Granularity := _Granularity shr 1
  End;
  _Granularity := 64 div ModeInfo.WinGranul;
  R.DX := _Granule;
  R.BX := 0;
  R.AX := $4F05;
  If Mode <> $13 then Intr ($10, R)
End;

Function GetVESAMode : Word;
Var R : Registers;
Begin
  R.AX := $4F03;
  Intr ($10, R);
  GetVESAMode := R.BX
End;

{$F+}
Procedure ClearScreen (Color : Byte); External;
Procedure PutPixel (X, Y : Word; Color : Byte); External;
Function GetPixel (X, Y : Word) : Byte; External;
Procedure LineH (X, Y, L : Word; Color : Byte); External;
Procedure LineV (X, Y, H : Word; Color : Byte); External;
Procedure Box (X, Y, L, H : Word; Color : Byte; Fill : Boolean); External;
Procedure Line (X1, Y1, X2, Y2 : Word; Color : Byte); External;
Procedure GetImage (X, Y, L, H : Word; Var BitMap); External;
Procedure PutImage (X, Y : Word; Var BitMap); External;
Procedure PutTranspImage (X, Y : Word; Var BitMap); External;
Function ImageSize (L, H : Word) : LongInt; External;
Procedure OutString (X, Y : Word; PString : PChar; Color : Byte); External;
Function LSqrt (X : LongInt) : LongInt; External;
{$F-}

Procedure Circle (X, Y, R : Word; C : Byte; Fill : Boolean);
Var
  A, B : Word;
begin
  If R = 0 then Exit;
  If not Fill then
    For A := 0 to R do
      Begin
        B := LSqrt(Sqr(R)-Sqr(A));
        PutPixel (X-A, Y-B, C);
        PutPixel (X+A, Y-B, C);
        PutPixel (X-A, Y+B, C);
        PutPixel (X+A, Y+B, C);
        PutPixel (X-B, Y-A, C);
        PutPixel (X-B, Y+A, C);
        PutPixel (X+B, Y-A, C);
        PutPixel (X+B, Y+A, C)
      End
  Else
    For A := 0 to R do
      Begin
        B := LSqrt(Sqr(R)-Sqr(A));
        LineH (X-B, Y-A, 1+B shl 1, C);
        LineH (X-B, Y+A, 1+B shl 1, C)
      End
End;

Procedure Ellipse (X, Y, A, B : Word; C : Byte; Fill : Boolean);
Var
  I, J : Word;
Begin
  If not Fill then Begin
    For I := 0 to A do Begin
      J := B * LSqrt(Sqr(A) - Sqr(I)) div A;
      PutPixel (X-I, Y-J, C);
      PutPixel (X+I, Y-J, C);
      PutPixel (X-I, Y+J, C);
      PutPixel (X+I, Y+J, C)
    End;
    For J := 0 to B do Begin
      I := A * LSqrt(Sqr(B) - Sqr(J)) div B;
      PutPixel (X-I, Y-J, C);
      PutPixel (X+I, Y-J, C);
      PutPixel (X-I, Y+J, C);
      PutPixel (X+I, Y+J, C)
    End
  End
  Else Begin
    For J := 0 to B do Begin
      I := A * LSqrt(Sqr(B) - Sqr(J)) div B;
      LineH (X-I, Y-J, 1 + I shl 1, C);
      LineH (X-I, Y+J, 1 + I shl 1, C)
    End;
  End
End;

Function Sgn (I : Integer) : Integer; Assembler;
Asm
  Mov   AX, I
  Or    AX, AX
  JZ    @end
  ShL   AX, 1
  JC    @1
  Mov   AX, 1
  Jmp   @end
@1:
  Mov   AX, -1
@end:
End;

Function _Abs (I : Integer) : Integer; Assembler;
Asm
  Mov   AX, I
  Test  AX, 8000h
  JZ    @end
  Neg   AX
@end:
End;

Procedure DrawPoly (Num : Word; PolyPoints : Array of TPoint; C : Byte);
Var I : Word;
Begin
  If Num > 1 then
    For I := 0 to Num-2 do Begin
      Line (PolyPoints[I].X, PolyPoints[I].Y,
            PolyPoints[I+1].X, PolyPoints[I+1].Y, C)
    End
End;

Procedure DrawPoly2 (Num : Word; PolyPoints : Array of TPoint; C : Byte);
Var I : Word;
Begin
  If Num > 0 then Begin
    For I := 0 to Num-2 do Begin
      Line (PolyPoints[I].X, PolyPoints[I].Y,
            PolyPoints[I+1].X, PolyPoints[I+1].Y, C)
    End;
    Line (PolyPoints[Num-1].X, PolyPoints[Num-1].Y,
          PolyPoints[0].X, PolyPoints[0].Y, C)
  End
End;

Procedure FillPoly (Num : Word; PolyPoints : Array of TPoint; C : Byte);
Var I, Y, Ymin, Ymax : Integer;
  Procedure DoSide (X1, Y1, X2, Y2 : Integer);
  Var
    Temp, I, X, Y,
    SX, SY, M, N,
    DX1, DY1, DX2, DY2 : Integer;
  Begin
    SX := X2-X1; SY := Y2-Y1;
    DX1 := Sgn(SX); DY1 := Sgn(SY);
    M := _Abs(SX); N := _Abs(SY);
    DX2 := DX1; DY2 := 0;
    If M < N then Begin
      M := _Abs(SY); N := _Abs(SX);
      DX2 := 0; DY2 := DY1
    End;
    X := X1; Y := Y1;
    Temp := 0;
    For I := 0 to M do Begin
      If (Y >= 0) and (Y <= GetMaxY) then Begin
        If X < _Poly[Y,1] then _Poly[Y,1] := X;
        If X > _Poly[Y,2] then _Poly[Y,2] := X
      End;
      Inc (Temp, N);
      If Temp < M then Begin
        Inc (X, DX2); Inc (Y, DY2)
      End
      Else Begin
        Dec (Temp, M);
        Inc (X, DX1); Inc (Y, DY1)
      End
    End
  End;
Begin
  If Num < 3 then Exit;
  Ymin := PolyPoints[0].Y; Ymax := Ymin;
  For I := 0 to Num-1 do Begin
    If PolyPoints[I].Y < Ymin then Ymin := PolyPoints[I].Y;
    If PolyPoints[I].Y > Ymax then Ymax := PolyPoints[I].Y
  End;
  If (Ymin > GetMaxY) or (Ymax < 0) then Exit;
  If Ymin < 0 then Ymin := 0; If Ymax > GetMaxY then Ymax := GetMaxY;
  For Y := Ymin to Ymax do Begin
    _Poly[Y,1] := GetMaxX+1; _Poly[Y,2] := -1
  End;
  For I := 0 to Num-2 do
    DoSide (PolyPoints[I].X, PolyPoints[I].Y,
            PolyPoints[I+1].X, PolyPoints[I+1].Y);
  DoSide (PolyPoints[Num-1].X, PolyPoints[Num-1].Y,
          PolyPoints[0].X, PolyPoints[0].Y);
  For Y := Ymin to Ymax do Begin
    If _Poly[Y,1] < 0 then _Poly[Y,1] := 0;
    If _Poly[Y,2] > GetMaxX then _Poly[Y,2] := GetMaxX;
    LineH (_Poly[Y,1], Y, _Poly[Y,2]-_Poly[Y,1]+1, C)
  End
End;

Procedure FillPolyPat (Num : Word; PolyPoints : Array of TPoint;
                                                L, H : Word; Var Pat);
Var
  I, X, Y, Ymin, Ymax : Integer;
  PA : Array [0..65534] of byte absolute Pat;
  Procedure DoSide (X1, Y1, X2, Y2 : Integer);
  Var
    Temp, I, X, Y,
    SX, SY, M, N,
    DX1, DY1, DX2, DY2 : Integer;
  Begin
    SX := X2-X1; SY := Y2-Y1;
    DX1 := Sgn(SX); DY1 := Sgn(SY);
    M := _Abs(SX); N := _Abs(SY);
    DX2 := DX1; DY2 := 0;
    If M < N then Begin
      M := _Abs(SY); N := _Abs(SX);
      DX2 := 0; DY2 := DY1
    End;
    X := X1; Y := Y1;
    Temp := 0;
    For I := 0 to M do Begin
      If (Y >= 0) and (Y <= GetMaxY) then Begin
        If X < _Poly[Y,1] then _Poly[Y,1] := X;
        If X > _Poly[Y,2] then _Poly[Y,2] := X
      End;
      Inc (Temp, N);
      If Temp < M then Begin
        Inc (X, DX2); Inc (Y, DY2)
      End
      Else Begin
        Dec (Temp, M);
        Inc (X, DX1); Inc (Y, DY1)
      End
    End
  End;
Begin
  If Num < 3 then Exit;
  Ymin := PolyPoints[0].Y; Ymax := Ymin;
  For I := 0 to Num-1 do Begin
    If PolyPoints[I].Y < Ymin then Ymin := PolyPoints[I].Y;
    If PolyPoints[I].Y > Ymax then Ymax := PolyPoints[I].Y
  End;
  If (Ymin > GetMaxY) or (Ymax < 0) then Exit;
  If Ymin < 0 then Ymin := 0; If Ymax > GetMaxY then Ymax := GetMaxY;
  For Y := Ymin to Ymax do Begin
    _Poly[Y,1] := GetMaxX+1; _Poly[Y,2] := -1
  End;
  For I := 0 to Num-2 do
    DoSide (PolyPoints[I].X, PolyPoints[I].Y,
            PolyPoints[I+1].X, PolyPoints[I+1].Y);
  DoSide (PolyPoints[Num-1].X, PolyPoints[Num-1].Y,
          PolyPoints[0].X, PolyPoints[0].Y);
  For Y := Ymin to Ymax do Begin
    If _Poly[Y,1] < 0 then _Poly[Y,1] := 0;
    If _Poly[Y,2] > GetMaxX then _Poly[Y,2] := GetMaxX;
    I := L * (Y mod H);
    For X := _Poly[Y,1] to _Poly[Y,2] do
      PutPixel (X, Y, PA[I + (X mod 8)])
  End
End;

Procedure SetFont (PFont : Pointer; L, H : Word); { L = 1...16, FontSize<=64K }
Begin
  _PFont := PFont;
  _FontL := L;
  _FontH := H;
  If L <= 8 then _FontHS := 1
  Else _FontHS := 2
End;

Procedure OutTextXY (X, Y : Word; TextString : String; Color : Byte);
Begin
  OutString (X, Y, @TextString, Color)
End;

Procedure WaitRetrace; Assembler;
  { This waits until you are in a Verticle Retrace ... this means that all
    screen manipulation you do only appears on screen in the next verticle
    retrace ... this removes most of the "fuzz" that you see on the screen
    when changing the pallette. It unfortunately slows down your program
    by "synching" your program with your monitor card ... it does mean
    that the program will run at almost the same speed on different
    speeds of computers which have similar monitors. In our SilkyDemo,
    we used a WaitRetrace, and it therefore runs at the same (fairly
    fast) speed when Turbo is on or off. }

Label
  L1, L2;
Asm
    Mov DX, 3DAH
L1:
    In AL,DX
    And AL,08H
    JNZ L1
L2:
    In AL,DX
    And AL,08H
    JZ  L2
End;

Procedure GetCRGB (C : Byte; Var R, G, B : Byte);
Begin
  Port[$3C7] := C;
  R := Port[$3C9];
  G := Port[$3C9];
  B := Port[$3C9]
End;

Procedure SetCRGB (C : Byte; R, G, B : Byte);
Begin
  Port[$3C8] := C;
  Port[$3C9] := R;
  Port[$3C9] := G;
  Port[$3C9] := B
End;

Procedure GetPal (Var Pal); Assembler;
Asm
  LES   DI, Pal
  Mov   CX, 768
  CLD
  Mov   DX, 3C7h
  Xor   AL, AL
  Out   DX, AL
  Inc   DX
  Inc   DX
  Rep   InSB
End;

Procedure SetPal (Var Pal); Assembler;
Asm
  Mov   BX, DS
  LDS   SI, Pal
  Mov   CX, 768
  CLD
  Mov   DX, 3C8h
  Xor   AL, AL
  Out   DX, AL
  Inc   DX
  Rep   OutSB
  Mov   DS, BX
End;

Begin
{$IFDEF DPMI}
  AllocRMInfos;
{$ENDIF}
End.
