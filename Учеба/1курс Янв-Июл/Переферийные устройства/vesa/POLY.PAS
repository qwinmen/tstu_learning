Uses CRT, VESA;

Const
  scr : array [1..4] of TPoint = ((X:0;Y:0), (X:639;Y:0), (X:639;Y:479), (X:0;Y:479));
  pat : array [0..7,0..7] of byte =
  (
    (4,0,0,0,0,0,0,0),
    (0,4,0,0,0,0,2,0),
    (0,0,4,0,0,2,0,0),
    (0,0,0,0,2,0,0,0),
    (0,0,0,2,0,0,0,0),
    (0,0,2,0,0,4,0,0),
    (0,2,0,0,0,0,4,0),
    (0,0,0,0,0,0,0,4)
  );
  T: array [1..3] of TPoint = ((X: 50; Y: 100), (X: 100; Y:100),
    (X: 150; Y: 150));
  S : array [1..6] of TPoint = ( (X:40; Y:20), (X:60; Y:30), (X:60; Y:50),
    (X:40; Y:60), (X:20; Y:50), (X:20; Y:30) );
  tpat : array [0..7,0..7] of byte =
  (
    (2,2,2,2,2,2,2,2),
    (2,2,2,2,2,2,2,2),
    (2,2,2,1,1,2,2,2),
    (2,2,1,7,7,1,2,2),
    (2,2,1,7,7,1,2,2),
    (2,2,2,1,1,2,2,2),
    (2,2,2,2,2,2,2,2),
    (2,2,2,2,2,2,2,2)
  );
  Star : Array [0..9] of TPoint = (
    (X:320;Y:140),
    (X:350;Y:215),
    (X:470;Y:215),
    (X:370;Y:260),
    (X:420;Y:340),
    (X:320;Y:290),
    (X:220;Y:340),
    (X:270;Y:260),
    (X:170;Y:215),
    (X:290;Y:215)
  );

Var
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
  FillPolyPat (4, scr, 8, 8, pat);
  DrawPoly2 (4, scr, Yellow);
  FillPoly (6, S, Blue);
  DrawPoly2 (6, S, Yellow);
  FillPolyPat (3, T, 8, 8, tpat);
  DrawPoly2 (3, T, White);
  DrawPoly2 (10, Star, LightRed);
  ReadLn;
  TextMode (CO80);
  {$IFDEF DPMI} FreeRMInfos; {$ENDIF}
End.
