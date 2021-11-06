Uses CRT, VESA;

Const
  PatternImage : array [1..4+8*8] of byte =
  (8,0, 8,0,                            { Length(Word), Height(Word) }
     4,0,0,0,0,0,0,0,
     0,4,0,0,0,0,2,0,
     0,0,4,0,0,2,0,0,
     0,0,0,0,2,0,0,0,
     0,0,0,2,0,0,0,0,
     0,0,2,0,0,4,0,0,
     0,2,0,0,0,0,4,0,
     0,0,0,0,0,0,0,4
  );

Var
  MInfo : TVESAModeInfo;
  PB, P : Pointer;
  X, Y, DX, DY, X0, Y0 : Integer;

Procedure Bum;
Begin
  Sound (1000); Delay(3); NoSound
End;

Begin
  If not IsVESA then Begin
    WriteLn ('VESA VGA card is not found!');
    Exit
  End;
  If not GetVESAModeInfo ($101, MInfo) then Begin
    WriteLn ('VESA VGA card is not found!');
    Exit
  End;
  GetMem (P, ImageSize(24,24));
  GetMem (PB, ImageSize(24,24));
  SetVESAMode ($101);
  SetCRGB (Yellow, 63, 53, 40);
  Circle (12, 12, 11, Yellow, True);
  GetImage (0, 0, 24, 24, P^);
  ClearScreen (Black);
  For Y := 0 to 59 do
    For X := 0 to 79 do
      PutImage (X*8, Y*8, PatternImage);
  X := 0; Y := 0; DX := 4; DY := 4;
  GetImage (X, Y, 24, 24, PB^);
  PutImage (X, Y, P^);
  Repeat
    X0 := X;
    Y0 := Y;
    Inc (X, DX);
    If X > GetMaxX+1-24 then Begin
      X := GetMaxX+1-24;
      DX := -DX;
      Bum
    End;
    If X < 0 then Begin
      X := 0;
      DX := -DX;
      Bum
    End;
    Inc (Y, DY);
    If Y > GetMaxY+1-24 then Begin
      Y := GetMaxY+1-24;
      DY := -DY;
      Bum
    End;
    If Y < 0 then Begin
      Y := 0;
      DY := -DY;
      Bum
    End;
{    Delay (5);}
    WaitRetrace;                                { NO FUZZ! }
    PutImage (X0, Y0, PB^);
    GetImage (X, Y, 24, 24, PB^);
    PutTranspImage (X, Y, P^)
  Until KeyPressed;
  While KeyPressed do ReadKey;
  TextMode (CO80);
  FreeMem (PB, ImageSize(24,24));
  FreeMem (P, ImageSize(24,24));
  {$IFDEF DPMI} FreeRMInfos {$ENDIF}
End.
