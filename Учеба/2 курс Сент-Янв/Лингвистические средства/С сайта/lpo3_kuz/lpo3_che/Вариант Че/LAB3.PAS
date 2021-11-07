Program Laba3; { ã†°† 3 ØÆ ãèé ëÄèê }
 Const wTable: array[1..10] of String[7] = ('IF',
                                             '.GT.',
                                             'TYPE',
                                             '(',
                                             ')',
                                             '=',
                                             '*',
                                             ',',
                                             '_Id',
                                             '_CONSt');
       BufSize: Byte = 0;
       Position: Byte = 0;
       TableSize: Byte = 0;
       ForthNum: Byte = 0;
       RouteVar: Byte = 0;
       PTPos: Byte = 0;
       JmpPos: Byte = 0;
       ForPos: Byte = 0;
 Var Buffer: array[1..200] of Byte;
     Table: array[1..10] of String[30];
     Forth: array[1..50,1..4] of String[10];
     Priorit: array[1..15,1..15] of Char;
     PT: array[1..50] of Char;

Procedure ReadBuffer;
 Var F: Text;
     c: Char;
     i, j: Byte;
 Begin
  For i:=1 to 200 do Buffer[i]:=0;
  Assign(F,'PROGA.OUT');
  Reset(F);
  While not EoF(F) do Begin
   While not EoLN(F) do Begin
    Inc(BufSize);
    Read(F,Buffer[BufSize]);
    Read(F,c,c);
   End;
   ReadLn(F);
  End;
  Close(F);
  Write('CODE: ');
  For i:=1 to BufSize do Write(Buffer[i],' ');
  WriteLn;

  Assign(F,'TABLE.OUT');
  Reset(F);
  While not EoF(F) do Begin
   Inc(TableSize);
   ReadLn(F,Table[TableSize]);
  End;
  Close(F);

  Assign(F,'PRIORIT.OUT');
  Reset(F);
  For i:=1 to 10 do Begin
   For j:=1 to 10 do Read(F,Priorit[i,j]);
   ReadLn(F);
  End;
  Close(F);

  Write('      ');
  For i:=1 to 10 do Write(Copy(wTable[i],1,5):6);
  WriteLn;
  For i:=1 to 10 do Begin
   Write(wTable[i]:6);
   For j:=1 to 10 do Begin
    If Priorit[i,j]='z' then c:=' '
    Else c:=Priorit[i,j];
    Write(c:6);
   End;
   WriteLn;
  End;
 End;

Procedure DelSymbol(Posit: Byte);
 Var i: Byte;
 Begin
  For i:=Posit to BufSize-1 do Buffer[i]:=Buffer[i+1];
  Buffer[BufSize]:=0;
  Dec(BufSize);
 End;

Function FindCode(Posit: Byte): Byte;
 Var k: Byte;
 Begin
  k:=Posit;
  Inc(k);
  If Buffer[k-1] in [9,10] then Inc(k);
  FindCode:=k;
 End;

Function GetRString: String;
 Var S: String;
 Begin
  Str(RouteVar,S);
  GetRString:='N'+S;
 End;

Function ReturnCode(Posit: Byte): String;
 Var S: String;
 Begin
  S:='';
  Case Buffer[Posit] of
   9:  Begin
        If Buffer[Posit+1]<=TableSize then S:=Table[Buffer[Posit+1]];
{        Else Begin
         Str(Buffer[Posit+1]-TableSize,S);
         S:='N'+S;
        End;}
       End;
   10: Begin
        Str(Buffer[Posit+1],S);
        S:='#'+S;
       End;
  End;
  ReturnCode:=S;
 End;

Procedure InitForth(Posit: Byte);
 Var a,b: String;
     i: Byte;
 Begin
  Inc(ForthNum);
  If (Buffer[Posit] <> 4) then Begin
   If ForPos=1 then ForPos:=2
   Else If ForPos=2 then Begin
    ForPos:=0;
    Str(ForthNum,a);
    Forth[JmpPos,4]:=Forth[JmpPos,4]+a;
   End;
  End;
  If Buffer[Posit] = 6 then Begin
   Forth[ForthNum,1]:=wTable[Buffer[Posit]];
   Forth[ForthNum,4]:=ReturnCode(Posit-2);
   Forth[ForthNum,2]:=ReturnCode(Posit+1);
   Dec(Posit,2);
   For i:=1 to 5 do DelSymbol(Posit);
   Position:=Position-2;
  End
  Else If Buffer[Posit] = 2 then Begin
   Forth[ForthNum,1]:=wTable[Buffer[Posit]];
   Forth[ForthNum,2]:=ReturnCode(Posit-2);
   Forth[ForthNum,3]:=ReturnCode(Posit+1);
   Inc(RouteVar);
   Forth[ForthNum,4]:=GetRString;
   Dec(Posit,2);
   For i:=1 to 5 do DelSymbol(Posit);
   Position:=Position-3;
  End
  Else If Buffer[Posit] = 8 then Begin
   Forth[ForthNum,1]:='PRINT';
   Inc(ForthNum);
   Forth[ForthNum,1]:=ReturnCode(Posit+1);
   Dec(Posit,2);
   For i:=1 to 5 do DelSymbol(Posit);
   Position:=Position-2;
  End
  Else If Buffer[Posit] = 4 then Begin
   Forth[ForthNum,1]:='NOT';
   Forth[ForthNum,2]:=GetRString;
   Forth[ForthNum,4]:='GOTO ';
   Dec(Posit,1);
   For i:=1 to 3 do DelSymbol(Posit);
   Position:=Position-2;
   JmpPos:=ForthNum;
   ForPos:=1;
  End;
 End;

Procedure ShowForth;
 Var i: Byte;
 Begin
  For i:=1 to BufSize do Write(Buffer[i],' ');
  WriteLn;

  For i:=1 to ForthNum do Begin
   Write(i:2);
   Write(Forth[i,1]:10);
   Write(Forth[i,2]:10);
   Write(Forth[i,3]:10);
   WriteLn(Forth[i,4]:10);
  End;
 End;

Function SetInTable(Pos1,Pos2: Byte): Byte;
 Var a,b: Byte;
 Begin
  a:=Buffer[Pos1];
  b:=Buffer[Pos2];
  If Priorit[b,a] = 'z' then Begin
   WriteLn('Error in combination:  ',wTable[a],' : ',wTable[b]);
   WriteLn('Position: ',Pos1,' : ',Pos2);
  End;
  If (Priorit[b,a]='<') or (Priorit[b,a]='>') then Begin
   Inc(PTPos);
   PT[PTPos]:=Priorit[b,a];
   If (PT[PTPos-1]='<') and (PT[PTPos]='>') then Begin
    SetInTable:=Pos1;
    PTPos:=PTPos-2;
   End
   Else SetInTable:=0
  End
  Else SetInTable:=0;
 End;

Procedure Process;
 Var i,k: Byte;
       S: String;
 Begin
  Repeat
   i:=SetInTable(Position,FindCode(Position));
   If i>0 then InitForth(i);
   If Buffer[Position] in [9,10] then Inc(Position);
   If i=0 then Inc(Position);
  Until Position>=BufSize;
 End;

BEGIN
 WriteLn;
 ReadBuffer;
 ReadLn;
 Position:=1;
 Process;
 WriteLn('Total Result: ');
 ShowForth;
END.