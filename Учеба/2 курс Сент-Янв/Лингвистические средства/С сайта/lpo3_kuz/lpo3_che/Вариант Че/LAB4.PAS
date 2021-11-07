Program Laba4;
 Const ReservTypes: array[1..7] of String[7] = ('BYTE','WORD','INTEGER','REAL',
                                                'LONGINT','BOOLEAN','ARRAY');
       RecStr: array[1..4] of String[3] = ('VAR',',',':',';');
               { 5 - Тип }
               { 6 - ARRAY }
               { 7 - Переменная }
       Selector: Word = 0;
       N = 20;

 Type TCanRec = set of Byte;
      TFileRec = Record
                  Name : String[16];
                  Size : String[40];
                  Chain: Byte;
                 End;

 Var WorkString: String;
     F: Text;
     CanRec: TCanRec;
     VarCheck: Byte;

     THash: array[1..24] of Byte;
     Hash: array[0..N-1] of Byte;
     FileRec: array[1..24] of TFileRec;

Function UpString(S: String): String;
 Var TS: String;
      i: Byte;
 Begin
  TS[0]:=Chr(Length(S));
  If Length(S)>0 then For i:=1 to Length(S) do TS[i]:=UpCase(S[i])
  Else TS:='';
  UpString:=TS;
 End;

Procedure DestroySpace(Var S: String);
 Begin
  While S[1]=' ' do Delete(S,1,1);
  While S[Length(S)]=' ' do Delete(S,Length(S),1);
 End;

Procedure Error(aText: String);
 Begin
  WriteLn;
  WriteLn('ERROR: ',aText);
  Halt;
 End;

Function GetHash(Variable: String): Byte;
 Var Chk: Word;
       i: Byte;
 Begin
  Chk:=0;
  For i:=1 to Length(Variable) do Chk:=Chk+Ord(Variable[i]);
  GetHash:=Chk mod N;
 End;

Procedure Recognize;
 Var i: Integer;
     Reco: Byte;
     MinPos: Byte;
     TS, VS: String;
     Point, HashT: Byte;
 Begin
  Reco:=0;
  TS:='';
  For i:=2 to 4 do If WorkString[1]=RecStr[i] then Reco:=i;
  If Reco>0 then Delete(WorkString,1,1)
  Else Begin
   MinPos:=255;
   If (Pos(' ',WorkString)>0) then MinPos:=Pos(' ',WorkString);
   For i:=2 to 4 do If (Pos(RecStr[i],WorkString)<MinPos) and
     (Pos(RecStr[i],WorkString)>0) then MinPos:=Pos(RecStr[i],WorkString);
   If MinPos=0 then MinPos:=Length(WorkString)+1;
   TS:=Copy(WorkString,1,MinPos-1);
   If TS=RecStr[1] then Reco:=1
   Else Begin
    For i:=1 to 6 do If TS=ReservTypes[i] then Reco:=5;
    If Reco=0 then Begin
     If Pos(ReservTypes[7],TS)=1 then Reco:=6
     Else Reco:=7;
    End;
   End;
   If Reco<>6 then Delete(WorkString,1,Length(TS));
  End;
  If Reco in CanRec then
  Else Error('Syntax error');
  Case Reco of
   0: Error('Unknown command');
   1,2: CanRec:=[7];
   3: CanRec:=[5,6];
   4: CanRec:=[1,7];
   5,6: CanRec:=[4];
   7: CanRec:=[2,3];
  End;
  If Reco = 7 then Begin
   Inc(VarCheck);
   HashT:=GetHash(TS);
   THash[Selector+1]:=HashT;
   If Hash[HashT]=0 then Begin
    Inc(Selector);
    Hash[HashT]:=Selector;
    FileRec[Selector].Name:=TS;
    FileRec[Selector].Chain:=0;
   End
   Else Begin
    Reco:=Hash[HashT];
    Repeat
     If TS=FileRec[Reco].Name then Error('Duplicate identifier -> '+TS);
     If FileRec[Reco].Chain<>0 then Reco:=FileRec[Reco].Chain;
    Until FileRec[Reco].Chain=0;
    Inc(Selector);
    FileRec[Reco].Chain:=Selector;
    FileRec[Selector].Name:=TS;
    FileRec[Selector].Chain:=0;
   End;
  End
  Else If Reco in [5,6] then Begin
   If Reco = 5 then For i:=Selector-VarCheck+1 to Selector do FileRec[i].Size:=TS
   Else Begin
    TS:='';
    TS:=ReservTypes[7] + ' (';
    Delete(WorkString,1,Length(ReservTypes[7]));
    DestroySpace(WorkString);
    If WorkString[1]<>'[' then Error('Incorrect array initialization');
    Delete(WorkString,1,1);
    Repeat
     VS:=Copy(WorkString,1,Pos('..',WorkString)-1);
     TS:=TS+VS+'-';
     Delete(WorkString,1,Length(VS)+2);
     Reco:=Pos(']',WorkString);
     If Reco=0 then Error('Incorrect array initialization');
     If (Pos(',',WorkString)>0) and (Pos(',',WorkString)<Reco) then
      Reco:=Pos(',',WorkString);
     VS:=Copy(WorkString,1,Reco-1);
     TS:=TS+VS;
     Delete(WorkString,1,Length(VS));
     If WorkString[1]=',' then Begin
      TS:=TS+',';
      Delete(WorkString,1,1);
     End;
    Until WorkString[1] = ']';
    TS:=TS+') OF ';
    Delete(WorkString,1,1);
    DestroySpace(WorkString);
    Delete(WorkString,1,2);
    DestroySpace(WorkString);
    For i:=1 to 6 do If Pos(ReservTypes[i],WorkString)=1 then Reco:=i;
    Delete(WorkString,1,Length(ReservTypes[Reco]));
    TS:=TS+ReservTypes[Reco];
    For i:=Selector-VarCheck+1 to Selector do FileRec[i].Size:=TS
   End;
   VarCheck:=0;
  End;
 End;

Procedure FileWork;
 Var i: Byte;
 Begin
  For i:=0 to N-1 do Hash[i]:=0;
  For i:=1 to 24 do With FileRec[i] do Begin
   Name:='';
   Size:='';
   Chain:=0;
  End;
  Assign(F,'PROGA2.LNG');
  Reset(F);
  CanRec:=[1];
  Repeat
   WorkString:='';
   ReadLn(F,WorkString);
   WorkString:=UpString(WorkString);
   Repeat
    DestroySpace(WorkString);
    Recognize;
   Until WorkString = '';
  Until EoF(F);
 End;

Procedure Show;
 Var i: Byte;
     F: Text;
     S: String;
 Begin
  WriteLn;
  WriteLn('----- Program: ');
  Assign(F,'PROGA2.LNG');
  Reset(F);
  While not EoF(F) do Begin
   ReadLn(F,S);
   WriteLn(S);
  End;
  Close(F);
  WriteLn('----- Press ENTER...');
  ReadLn;
  WriteLn;
  Write('HASH TABLE:');
  For i:=0 to N-1 do Write(Hash[i]:3);
  WriteLn;
  WriteLn('Number   Identifier            Type               CHAIN    Hash meaning');
  WriteLn('------------------------------------------------------------------------');
  For i:=1 to Selector do With FileRec[i] do Begin
   Write(i:3);
   Write(' |');
   Write(Name:10);
   Write(Size:30);
   Write(Chain:8);
   Write(' |');
   WriteLn(THash[i]:10);
  End;
 End;

BEGIN
 FileWork;
 Show;
 WriteLn;
END.