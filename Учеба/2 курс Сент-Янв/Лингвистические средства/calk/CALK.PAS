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

{ Короче, дело было так: тут две функции - Parse разбирает выражение, и пере-
водит его в польскую запись, Calc по польской записи считает значение... }


{ Что такое есть выражение?

   Выражение = Терм [ + Терм | - Терм]
   Терм = Фактор [ / Фактор | * Фактор]
   Фактор = число | выражение

   Выглядит слишком заморочено ? Человеческим языком это выглядит приблизи-
тельно так: смотрим, что есть наше выражение, сумма или разность чего-то...
если да, то точно также расматриваем эти что-то отдельно друг от друга,
если нет, то смотрим является ли оно произведением или частным чего-то...
если да то рассматриваем эти что-то отдельно, если нет, то смотрим, что же
есть наше выражение, число или очередное выражение...
   ...Мда, я надеюсь я не запутал тебя еще больше ;)) }


Procedure Parse(s:string;var code:code_mem);
Var
  i,j:byte;
  a,b:integer;
Begin

  { Для начала находим первый + или - который находится не в скобках...
    Причем смотрим с конца, так как самая первая операция, которую мы найдем
    выполнится в последнюю очередь...
    j - счетчик вложенности скобок, если кто не понял ;)) }

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

  {Теперь точно также ищем / или *, то есть разбираем терм... }
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

  { Так, все понятно, то что нам досталось - фактор...}
  val(s,a,b);

  { А может это цифра? }
  if b=0 then
    begin
      { АГА !}
      code.a[code.p]:=cmPUSH;
      inc(code.p);
      code.a[code.p]:=lo(a);
      inc(code.p);
      exit
    end;

  { Так, если нас накормили пустой строкой, будем считать что это 0,
  кстати таким макаром мы избавились от проблемы унарных - и + ...,
  правда у нас появились унарные * и /  ;))  Облом было делать по-
  нормальному....}

  if s='' then
    begin
      code.a[code.p]:=cmPUSH;
      inc(code.p);
      code.a[code.p]:=0;
      inc(code.p);
      exit
    end;

  { Если это не цифра, то значит это выражение... Почему оно не разобралось
  сразу? Потому что оно заключено в скобки !!! }

  if (s[1]='(') and (s[byte(s[0])]=')') then
    begin
      {Но если первый символ ( , а поледний ) это еще ничего не значит!
      Потому что может быть ситуация типа (1+2)-(3+4)...А хотя может ли
      быть такое? Надо будет как нибудь на досуге подумать об этом ;)) }
      i:=2;
      j:=1;
      while (i<(byte(s[0])-1)) and (j>0) do
        begin
          if s[i]='(' then inc(j);
          if s[i]=')' then dec(j);
          inc(i);
        end;
      if j<>0 then
        {Если все нормально, обрезать крайние скобки и попробовать р
        азобрать его еще раз...}
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
 write('Input expression:'); {Строка типа '((10+6)/(6-2))'}
 readln(s);
 parse(s,q);
 writeln(calk(q):1:5);
END.