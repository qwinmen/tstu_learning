Const
  cmPUSH  = 0;
  cmMINUS = 1;
  cmPLUS  = 2;
  cmMUL   = 3;
  cmDIV   = 4;

Type
  code_mem=record
   a:array[0..1023] of byte;
   p:integer;
  end;

Var
  Stack:array[0..100] of real;

{ ����, ���� �뫮 ⠪: ��� ��� �㭪樨 - Parse ࠧ��ࠥ� ��ࠦ����, � ���-
����� ��� � ������� ������, Calc �� ����᪮� ����� ��⠥� ���祭��... }


{ �� ⠪�� ���� ��ࠦ����?

   ��ࠦ���� = ��� [ + ��� | - ���]
   ��� = ����� [ / ����� | * �����]
   ����� = �᫮ | ��ࠦ����

   �룫廊� ᫨誮� �����祭� ? �������᪨� �몮� �� �룫廊� �ਡ����-
⥫쭮 ⠪: ᬮ�ਬ, �� ���� ��� ��ࠦ����, �㬬� ��� ࠧ����� 祣�-�...
�᫨ ��, � �筮 ⠪�� �ᬠ�ਢ��� �� ��-� �⤥�쭮 ��� �� ��㣠,
�᫨ ���, � ᬮ�ਬ ���� �� ��� �ந��������� ��� ���� 祣�-�...
�᫨ �� � ��ᬠ�ਢ��� �� ��-� �⤥�쭮, �᫨ ���, � ᬮ�ਬ, �� ��
���� ��� ��ࠦ����, �᫮ ��� ��।��� ��ࠦ����...
   ...���, � ������� � �� ����⠫ ⥡� �� ����� ;)) }


Procedure Parse(s:string;var code:code_mem);
Var
  i,j:byte;
  a,b:integer;
Begin

  { ��� ��砫� ��室�� ���� + ��� - ����� ��室���� �� � ᪮����...
    ��祬 ᬮ�ਬ � ����, ⠪ ��� ᠬ�� ��ࢠ� ������, ������ �� ������
    �믮������ � ��᫥���� ��।�...
    j - ���稪 ���������� ᪮���, �᫨ �� �� ���� ;)) }

  j:=0;
  for i:=byte(s[0]) downto 1 do
    case s[i] of
      ')': inc(j);
      '(': dec(j);
      '-': if j=0 then
             begin
               parse(copy(s,1,i-1),code);
               parse(copy(s,i+1,byte(s[0])-i),code);
               code.a[code.p]:=cmMINUS;
               inc(code.p);
               exit;
             end;
      '+': if j=0 then
             begin
               parse(copy(s,1,i-1),code);
               parse(copy(s,i+1,byte(s[0])-i),code);
               code.a[code.p]:=cmPLUS;
               inc(code.p);
               exit;
             end;
    end;

  {������ �筮 ⠪�� �饬 / ��� *, � ���� ࠧ��ࠥ� ��... }
  j:=0;
  for i:=byte(s[0]) downto 1 do
    case s[i] of
      '(': inc(j);
      ')': dec(j);
      '/': if j=0 then
             begin
               parse(copy(s,1,i-1),code);
               parse(copy(s,i+1,byte(s[0])-i),code);
               code.a[code.p]:=cmDIV;
               inc(code.p);
               exit;
             end;
      '*': if j=0 then
             begin
               parse(copy(s,1,i-1),code);
               parse(copy(s,i+1,byte(s[0])-i),code);
               code.a[code.p]:=cmMUL;
               inc(code.p);
               exit;
             end;
    end;

  { ���, �� ����⭮, � �� ��� ���⠫��� - 䠪��...}
  val(s,a,b);

  { � ����� �� ���? }
  if b=0 then
    begin
      { ��� !}
      code.a[code.p]:=cmPUSH;
      inc(code.p);
      code.a[code.p]:=lo(a);
      inc(code.p);
      exit
    end;

  { ���, �᫨ ��� ����ନ�� ���⮩ ��ப��, �㤥� ����� �� �� 0,
  ���� ⠪�� ����஬ �� ���������� �� �஡���� 㭠��� - � + ...,
  �ࠢ�� � ��� ������ 㭠�� * � /  ;))  ����� �뫮 ������ ��-
  ��ଠ�쭮��....}

  if s='' then
    begin
      code.a[code.p]:=cmPUSH;
      inc(code.p);
      code.a[code.p]:=0;
      inc(code.p);
      exit
    end;

  { �᫨ �� �� ���, � ����� �� ��ࠦ����... ��祬� ��� �� ࠧ��ࠫ���
  �ࠧ�? ��⮬� �� ��� �����祭� � ᪮��� !!! }

  if (s[1]='(') and (s[byte(s[0])]=')') then
    begin
      {�� �᫨ ���� ᨬ��� ( , � �������� ) �� �� ��祣� �� �����!
      ��⮬� �� ����� ���� ����� ⨯� (1+2)-(3+4)...� ��� ����� ��
      ���� ⠪��? ���� �㤥� ��� ����� �� ���㣥 ���㬠�� �� �⮬ ;)) }
      i:=2;
      j:=1;
      while (i<(byte(s[0])-1)) and (j>0) do
        begin
          if s[i]='(' then inc(j);
          if s[i]=')' then dec(j);
          inc(i);
        end;
      if j<>0 then
        {�᫨ �� ��ଠ�쭮, ��१��� �ࠩ��� ᪮��� � ���஡����� �
        ������� ��� �� ࠧ...}
        parse(copy(s,2,byte(s[0])-2),code);
    end;
End;

Function Calk(code:code_mem):real;
Var
  i:byte;
  StackPointer:byte;
Begin
  i:=0;
  StackPointer:=0;
  while (i<code.p) do
    Begin
      case code.a[i] of
        cmPUSH :Begin
                 inc(i);
                 Stack[StackPointer]:=code.a[i];
                 inc(StackPointer);
                end;
        cmMINUS:Begin
                 Dec(StackPointer);
                 Stack[StackPointer-1]:=Stack[StackPointer-1]-Stack[StackPointer];
                End;
        cmPLUS :Begin
                 Dec(StackPointer);
                 Stack[StackPointer-1]:=Stack[StackPointer-1]+Stack[StackPointer];
                End;
        cmDIV  :Begin
                 Dec(StackPointer);
                 Stack[StackPointer-1]:=Stack[StackPointer-1]/Stack[StackPointer];
                End;
        cmMUL  :Begin
                 Dec(StackPointer);
                 Stack[StackPointer-1]:=Stack[StackPointer-1]*Stack[StackPointer];
                End;
      End;
      inc(i);
    End;
    Calk:=Stack[0];
End;

Var
 q:code_mem;
 s:string;
BEGIN
 q.p:=0;
 write('Input expression:'); {��ப� ⨯� '((10+6)/(6-2))'}
 readln(s);
 parse(s,q);
 writeln(calk(q):1:5);
END.