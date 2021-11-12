uses crt;
const MasLex:array[1..12] of String=('программа',';','*',':=','цикл','от','до','выполнить',
                                    'вывод','переменные','вещественные','целые');
      FortMasLex:array[1..8]of String=('PROGRAMM','*','=','DO','CONTINUE','PRINT','REAL','INT');
      LexTable:array[1..11,1..11]of Byte=((0,0,0,0,0,0,0,0,0,1,0),{программа}
                                          (0,0,0,0,0,0,0,0,0,0,0),{;}
                                          (0,3,0,3,0,0,0,0,0,1,0),{*}
                                          (0,3,1,0,0,0,0,0,0,1,1),{:=}
                                          (0,0,0,0,0,2,0,0,0,1,0),{цикл}
                                          (0,0,0,0,0,0,2,0,0,1,1),{от}
                                          (0,0,0,0,0,0,0,2,0,1,1),{до}
                                          (0,3,0,0,0,0,0,0,1,1,0),{выполнить}
                                          (0,3,0,0,0,0,0,0,0,1,1),{вывод}
                                          (0,3,3,2,0,3,3,3,0,0,0),{ид}
                                          (0,3,0,0,0,0,3,3,0,0,0));{конст}
Type Perem=Record
  Arg:String;
  Tip:String;
 end;

var FOut,FIn:Text;
    NStr,Nl:integer;
    Id:array[1..10]of Perem;
    LA:Boolean;
    ColLex:integer;
    LexMas:array[0..40]of byte;
    Metka:integer;

procedure Name(NumChar:integer;Str:String);
 begin
  if Str[Length(Str)]<>';'then
   begin
    Writeln(NStr,' Пунктуационная ошибка ";" ');
    Readln
   end
  else
   Write(FOut,'     PROGRAMMA ',Copy(Str,NumChar+10,Length(Str)-(NumChar+10)));
 end;

procedure PrintPTable;
 var i:integer;
 begin
  for i:=1 to 10 do
   begin
    if Id[i].Arg<>'' then
     begin
      if (Id[i-1].Tip<>Id[i].Tip) then
       begin
        Writeln(FOut);
        if Id[i].Tip=MasLex[11] then
         Write(FOut,'     ',FortMasLex[7],' ',Id[i].Arg);
        if Id[i].Tip=MasLex[12] then
         Write(FOut,'     ',FortMasLex[8],' ',Id[i].Arg)
       end
      else
       Write(FOut,',',Id[i].Arg);
     end;
   end;
 end;

procedure PTable(NumChar:integer;Str:String);
 var ArgStr,TipStr:String;
     j,a,i,k,z,l:integer;
 begin
  j:=0;
  a:=0;
  z:=0;
  ArgStr:='';
  TipStr:='';
  While a<>1 do
   begin
    if (Str[Length(Str)]<>';') or (Pos(':',Str)=0) then
     begin
      Writeln(NStr,' Пунктуационная ошибка ');
      Readln;
      a:=1
     end
    else
     begin
      for i:=NumChar+Length(MasLex[10]) to Length(Str) do
       begin
        if (Str[i]<>' ')and (Str[i]<>',')and (Str[i]<>':') then
         ArgStr:=ArgStr+Str[i];
        if (Str[i]=',') or (Str[i]=':')  then
         begin
          inc(j);
          Id[j].Arg:=ArgStr;
          TipStr:=Copy(Str,Pos(':',Str)+1,Length(Str)-(Pos(':',Str)+1));
          for k:=1 to 12 do
           begin
            if MasLex[k]=TipStr then
             z:=1
           end;
          if z=0 then
           begin
             Writeln(NStr,' Синтаксическая ошибка');
             Readln;
             Halt
           end;
          for l:=0 to j-1 do
           begin
            if Id[l].Arg=Id[j].Arg then
             begin
              Writeln(NStr,' Переменная ',Id[l].Arg,' объявлена дважды');
              Readln;
              Halt
             end;
           end;
          Id[j].Tip:=TipStr;
          ArgStr:='';
          TipStr:='';
          z:=0;
         end;
       end;
     ArgStr:='';
     Readln(FIn,Str);
     inc(NStr);
     for i:=3 to 10 do
      if Pos(MasLex[i],Str)<>0 then a:=1;
     end;
   end;
  PrintPTable;
  Close(FIn);
  Reset(FIn);
  for i:=1 to NStr-1 do Readln(Fin,Str);
 end;

procedure SintAn(Str:String);
 var i,j:integer;
     S:String;
     b,b1:boolean;
     Zn,Code:integer;
 begin
  S:='';
  b:=False;
  Nl:=1;
  for i:=1 to Length(Str)+1 do
   begin
    if S<>'' then
     begin
      for j:=1 to 12 do
       begin
        if MasLex[j]=S then
         begin
          LexMas[Nl]:=j;
          Inc(ColLex);
          S:='';
          Nl:=Nl+2;
          Break;
         end;
       end;
      for j:=1 to 10 do
       begin
        if (Id[j].Arg=S)and(S<>'')  then
         begin
          LexMas[Nl]:=10;
          Inc(ColLex);
          S:='';
          Nl:=Nl+2;
          Break;
         end;
       end;
      Val(S,Zn,Code);
      for j:=1 to 12 do
       if (Str[i]=MasLex[j]) or ((Str[i]=' ')and(Code=0)) then
        begin
         b:=True;
         Break;
        end;
      if (Code=0) and b then
       begin
        LexMas[Nl]:=11;
        Inc(ColLex);
        S:='';
        Nl:=Nl+2;
        b:=False
       end;
     end;
    if Str[i]=' ' then
     begin
      if S<>''then
       begin
        Writeln(NStr,' Синтаксическая ошибка');
        Readln;
        Halt;
       end;
      S:='';
     end
    else
     S:=S+Str[i];
   end;
 end;

procedure LexAn(Str:String);
 var i,j:integer;
     S:String;
     b,b1:boolean;
     Zn,Code:integer;
 begin
  for i:=0 to 40 do
   begin
    LexMas[i]:=0;
   end;
  SintAn(Str);
  LexMas[0]:=1;
  LexMas[Nl-1]:=3;
  for i:=1 to (((Nl-1) div 2)-1) do
   begin
    LexMas[i*2]:=LexTable[LexMas[i*2-1],LexMas[i*2+1]];
   end;
  i:=-1;

  while LexMas[1]<>0 do
   begin
    if (LexMas[i*2]=1) and (LexMas[i*2+2]=3)then
     begin
      j:=i*2+1;
      while j<35 do
       begin
        LexMas[j]:=LexMas[j+2];
        LexMas[j+2]:=0;
        inc(j);
       end;
      if i*2<>0 then
       LexMas[i*2]:=LexTable[LexMas[i*2-1],LexMas[i*2+1]];
      i:=-1;
     end;
    if LexMas[i*2]=2 then
     begin
      if (LexMas[i*2-2]=1) and ((LexMas[i*2+2]=3) or (LexMas[i*2+2]=2))  then
       begin
        j:=i*2-1;
        while j<35 do
         begin
          LexMas[j]:=LexMas[j+4];
          LexMas[j+4]:=0;
          inc(j);
         end;
        if i*2-2<>0 then
         LexMas[i*2-2]:=LexTable[LexMas[i*2-3],LexMas[i*2-1]];
        i:=-1;
       end;
     end;
    if i=-1 then dec(ColLex);
    if ColLex<0 then
     begin
      Writeln(' Лексическая ошибка');
      Readln;
      Halt;
     end;
    inc(i);
   end;
    LexMas[1]:=0;
    ColLex:=1;
 end;

procedure TranslProgr(Str:String);
 var i,j,Zn,Code:integer;
     s:String;
     b,C:Boolean;
 begin
  writeln(FOut);
  write(FOut,'     ');
  S:='';
  C:=False;
  for i:=1 to Length(Str)+1 do
   begin
    if S<>'' then
     begin
      for j:=1 to 10 do
       begin
        if (Id[j].Arg=S)and(S<>'')  then
         begin
          Write(FOut,S);
          S:='';
          Break;
         end;
       end;
      Val(S,Zn,Code);
      for j:=1 to 12 do
       if (Str[i]=MasLex[j]) or ((Str[i]=' ')and(Code=0)) then
        begin
         b:=True;
         Break;
        end;
      if (Code=0) and b then
       begin
        Write(FOut,S);
        S:='';
        b:=False
       end;
     end;
     for j:=1 to 12 do
      begin
       if MasLex[j]=S then
        begin
         if S=':=' then Write(FOut,'=');
         if S=MasLex[9] then Write(FOut,FortMasLex[6],' ');
         if S=MasLex[5] then
          begin
           Write(FOut,FortMasLex[4],' ',Metka,' ');
           C:=True;
          end;
         if S=MasLex[6] then Write(FOut,'=');
         if S=MasLex[7] then Write(FOut,',');
         if S=MasLex[8] then
          begin
           Writeln(FOut,',1');
           Write(FOut,'     ');
          end;
         if S=MasLex[3] then Write(FOut,FortMasLex[2]);
         if (Str[i-1]=';') and C then
          begin
           Writeln(FOut,'     ');
           Write(FOut,Metka,'    ',FortMasLex[5]);
           inc(Metka);
           C:=False;
          end;
         S:='';
         Break;
        end;
      end;
    if Str[i]=' ' then
     begin
      S:='';
     end
    else
     S:=S+Str[i];
   end;
 end;

procedure ReadProgramm(NameInFile:String);
 var Str:String;
     i:integer;
     ch:Char;
 begin
  Assign(FIn,NameInFile);
  Reset(FIn);
  Str:='';
  While Not EOF(FIn) do
   begin
    inc(NStr);
    i:=1;
    Str:='';
    ch:=' ';
    while (ch<>';')and (ch<>'.') do
     begin
      Read(FIn,ch);
      if (ch<>#10) and (ch<>#13) then
       Str:=Str+ch;
      if ch=#26 then
       begin
        Writeln(NStr,' Пунктуационная ошибка');
        Readln;
        Halt;
       end;
      inc(i);
     end;
    Read(Fin,ch);
    Read(Fin,ch);
    if Str='конец.'then
     begin
      LA:=False;
      Writeln(FOut);
      Write(FOut,'     ','END');
     end;
    if LA then LexAn(Str);
    if LA then TranslProgr(Str);
    if Pos(MasLex[1],Str)<>0 then
     begin
      Name(Pos(MasLex[1],Str),Str);
     end;
    if Pos(MasLex[10],Str)<>0 then
     begin
      PTable(Pos(MasLex[10],Str),Str);
      LA:=True;
     end;
   end;
  Close(FIn);
 end;

begin
clrscr;
Metka:=1;
ColLex:=1;
LA:=False;
if ParamCount<2 then
 begin
  writeln('LexAn [InFile] [OutFile]');
  Exit;
 end;
Assign(FOut,ParamStr(2));
Rewrite(FOut);
ReadProgramm(ParamStr(1));
Close(FOut);
end.