Uses CRT, VESA, Memory;
{$M 16384,0,0}

Var
  P : Pointer;
  S : LongInt;
  MInfo : TVESAModeInfo;

Begin
  If not IsVESA then Begin
    WriteLn ('VESA VGA card is not found!');
    Exit
  End;
  If not GetVESAModeInfo ($101, MInfo) then Begin
    WriteLn ('VESA VGA card is not found!');
    Exit
  End;
  SetVESAMode ($101);
  S := ImageSize (GetMaxX+1, GetMaxY+1);
  P := MemAlloc (S);
  If P = Nil then Begin
    TextMode (CO80);
    WriteLn ('Couldn''t allocate ', S, ' bytes.');
    Exit
  End;
  ClearScreen (Green);
  Box (0, 0, GetMaxX+1, GetMaxY+1, 15, false);
  GetImage (0, 0, GetMaxX+1, GetMaxY+1, P^);
  ReadLn;
  ClearScreen (Red);
  ReadLn;
  PutImage (0, 0, P^);
  ReadLn;
  MemFree (P);
  TextMode (CO80);
End.
