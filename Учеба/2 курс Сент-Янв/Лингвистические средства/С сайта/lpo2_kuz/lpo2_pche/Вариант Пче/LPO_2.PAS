 const
  ReWrite_err  = ' Ошибка в операторе REWRITE: ';
  Put_err      = ' Ошибка в операторе PUT: ';
  Approp_err   = ' Ошибка в операторе присваивания';
  f_ep: boolean= false;
 var
  FN: string[80];
  f_in,f_out: text;
  i,j,pt: byte;
  ch: char;
 function GetCode: byte;
 begin
  if not SeekEOF(f_in) then Read(f_in,j)
  else j:=0;
  GetCode:= j
 end;
 {-------}
 procedure ScanReWrite;
 begin
  WriteLn(f_out,' REWRITE');
  if GetCode=3 then begin
   if GetCode=12 then begin
    if GetCode=1 then begin
     WriteLn(f_out,' PARAM1 F');
     if GetCode=5 then begin
      if GetCode=11 then begin
       WriteLn(f_out,' PARAM2 '#39'F.DAT'#39);
       GetCode;
       if GetCode=4 then begin
        i:= GetCode;
        if i=7 then f_ep:= true
        else if i<>6 then WriteLn(f_out,' Ошибка после оператора REWRITE: не найден знак-разделитель'#13#10)
       end
       else WriteLn(f_out,ReWrite_err+'нет закрывающейся скобки'#13#10);
      end
      else WriteLn(f_out,ReWrite_err+'вторым параметром должна быть константа'#13#10)
     end
     else WriteLn(f_out,ReWrite_err+'между параметрами нет запятой'#13#10)
    end
    else WriteLn(f_out,ReWrite_err+'первый параметр должен быть файловой переменной'#13#10)
   end
   else WriteLn(f_out,ReWrite_err+'первый параметр - неправильный идентификатор'#13#10)
  end
  else WriteLn(f_out,ReWrite_err+'нет открывающейся скобки'#13#10);
  if not EOF(f_in) then begin
   Read(f_in,ch);
   while not EOF(f_in) and (ch<>#10) do Read(f_in,ch)
  end
 end;
 {-------}
 procedure ScanApprop(j: byte);
 begin
  pt:= 0;
  if j=12 then begin
   if GetCode=1 then begin
    if GetCode<>9 then begin
     inc(pt);
     WriteLn(f_out,Approp_err+': несоответствие типов'#13#10)
    end
    else pt:= 2
   end;
   if pt<>1 then begin
    if GetCode=8 then begin
     if GetCode=12 then begin
      if GetCode=2 then begin
       i:= GetCode;
       if i=10 then begin
        if GetCode=12 then begin
         if GetCode=2 then begin
          Write(f_out,' * K K REZ1'#13#10' := REZ1 ');
          if pt=2 then WriteLn(f_out,'F^')
          else WriteLn(f_out,'K');
          i:= GetCode;
          if i=7 then f_ep:= true
          else if i<>6 then WriteLn(f_out,' Ошибка после оператора присваивания: не найден знак-разделитель'#13#10)
         end
         else WriteLn(f_out,Approp_err+': несоответствие типов'#13#10)
        end
        else WriteLn(f_out,Approp_err+': после знака "*" должен следовать идентификатор'#13#10)
       end
       else if (i=6) or (i=7) then begin
        if i=7 then f_ep:= true;
        Write(f_out,' := K ');
        if pt=2 then WriteLn(f_out,'F^')
        else WriteLn(f_out,'K');
       end
       else WriteLn(f_out,Approp_err)
      end
      else WriteLn(f_out,Approp_err+': несоответствие типов'#13#10)
     end
     else WriteLn(f_out,Approp_err+': после оператора должен следовать идентификатор'#13#10)
    end
    else WriteLn(f_out,Approp_err+': неправильное обозначение оператора'#13#10)
   end
  end
  else WriteLn(f_out,Approp_err+': результат этой операции заносится в неправильный идентификатор'#13#10);
  if not EOF(f_in) then begin
   Read(f_in,ch);
   while not EOF(f_in) and (ch<>#10) do Read(f_in,ch)
  end
 end;
 {-------}
 procedure ScanPut;
 begin
  WriteLn(f_out,' PUT');
  if GetCode=3 then begin
   if GetCode=12 then begin
    if GetCode=1 then begin
     WriteLn(f_out,' PARAM F');
     if GetCode=4 then begin
      i:= GetCode;
      if i=7 then f_ep:= true
      else if i<>6 then WriteLn(f_out,' Ошибка после оператора PUT: не найден знак-разделитель'#13#10)
     end
     else WriteLn(f_out,Put_err+'нет закрывающейся скобки'#13#10)
    end
    else WriteLn(f_out,Put_err+'параметр - неправильный идентификатор'#13#10)
   end
   else WriteLn(f_out,Put_err+'параметр должен быть идентификатором'#13#10)
  end
  else WriteLn(f_out,Put_err+'нет открывающейся скобки'#13#10);
  if not EOF(f_in) then begin
   Read(f_in,ch);
   while not EOF(f_in) and (ch<>#10) do Read(f_in,ch)
  end
 end;
 {---}
 begin
  Write(' Введите имя файла с кодами лексем > ');
  ReadLn(FN);
  assign(f_in,FN);
  {$i-} Reset(f_in); {$i+}
  if IOresult<>0 then begin
   WriteLn(#13#10' Ошибка открытии этого файла'#13#10);
   exit
  end;
  Write(' Введите имя нового файла > ');
  ReadLn(FN);
  assign(f_out,FN);
  {$i-} ReWrite(f_out); {$i+}
  if IOresult<>0 then begin
   WriteLn(#13#10' Возникла ошибка создании этого файла'#13#10);
   close(f_in);
   exit
  end;
  repeat
   i:= GetCode;
   case i of
    0: break;
    1: ScanReWrite;
    2: ScanPut
    else ScanApprop(i)
   end;
   if f_ep then break
  until false;
  Close(f_in); Close(f_out)
 end.