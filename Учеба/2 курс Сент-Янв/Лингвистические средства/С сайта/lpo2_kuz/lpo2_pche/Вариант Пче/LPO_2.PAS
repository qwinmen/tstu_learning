 const
  ReWrite_err  = ' �訡�� � ������ REWRITE: ';
  Put_err      = ' �訡�� � ������ PUT: ';
  Approp_err   = ' �訡�� � ������ ��ᢠ������';
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
        else if i<>6 then WriteLn(f_out,' �訡�� ��᫥ ������ REWRITE: �� ������ ����-ࠧ����⥫�'#13#10)
       end
       else WriteLn(f_out,ReWrite_err+'��� ����뢠�饩�� ᪮���'#13#10);
      end
      else WriteLn(f_out,ReWrite_err+'���� ��ࠬ��஬ ������ ���� ����⠭�'#13#10)
     end
     else WriteLn(f_out,ReWrite_err+'����� ��ࠬ��ࠬ� ��� ����⮩'#13#10)
    end
    else WriteLn(f_out,ReWrite_err+'���� ��ࠬ��� ������ ���� 䠩����� ��६�����'#13#10)
   end
   else WriteLn(f_out,ReWrite_err+'���� ��ࠬ��� - ���ࠢ���� �����䨪���'#13#10)
  end
  else WriteLn(f_out,ReWrite_err+'��� ���뢠�饩�� ᪮���'#13#10);
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
     WriteLn(f_out,Approp_err+': ��ᮮ⢥��⢨� ⨯��'#13#10)
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
          else if i<>6 then WriteLn(f_out,' �訡�� ��᫥ ������ ��ᢠ������: �� ������ ����-ࠧ����⥫�'#13#10)
         end
         else WriteLn(f_out,Approp_err+': ��ᮮ⢥��⢨� ⨯��'#13#10)
        end
        else WriteLn(f_out,Approp_err+': ��᫥ ����� "*" ������ ᫥������ �����䨪���'#13#10)
       end
       else if (i=6) or (i=7) then begin
        if i=7 then f_ep:= true;
        Write(f_out,' := K ');
        if pt=2 then WriteLn(f_out,'F^')
        else WriteLn(f_out,'K');
       end
       else WriteLn(f_out,Approp_err)
      end
      else WriteLn(f_out,Approp_err+': ��ᮮ⢥��⢨� ⨯��'#13#10)
     end
     else WriteLn(f_out,Approp_err+': ��᫥ ������ ������ ᫥������ �����䨪���'#13#10)
    end
    else WriteLn(f_out,Approp_err+': ���ࠢ��쭮� ������祭�� ������'#13#10)
   end
  end
  else WriteLn(f_out,Approp_err+': १���� �⮩ ����樨 �������� � ���ࠢ���� �����䨪���'#13#10);
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
      else if i<>6 then WriteLn(f_out,' �訡�� ��᫥ ������ PUT: �� ������ ����-ࠧ����⥫�'#13#10)
     end
     else WriteLn(f_out,Put_err+'��� ����뢠�饩�� ᪮���'#13#10)
    end
    else WriteLn(f_out,Put_err+'��ࠬ��� - ���ࠢ���� �����䨪���'#13#10)
   end
   else WriteLn(f_out,Put_err+'��ࠬ��� ������ ���� �����䨪��஬'#13#10)
  end
  else WriteLn(f_out,Put_err+'��� ���뢠�饩�� ᪮���'#13#10);
  if not EOF(f_in) then begin
   Read(f_in,ch);
   while not EOF(f_in) and (ch<>#10) do Read(f_in,ch)
  end
 end;
 {---}
 begin
  Write(' ������ ��� 䠩�� � ������ ���ᥬ > ');
  ReadLn(FN);
  assign(f_in,FN);
  {$i-} Reset(f_in); {$i+}
  if IOresult<>0 then begin
   WriteLn(#13#10' �訡�� ����⨨ �⮣� 䠩��'#13#10);
   exit
  end;
  Write(' ������ ��� ������ 䠩�� > ');
  ReadLn(FN);
  assign(f_out,FN);
  {$i-} ReWrite(f_out); {$i+}
  if IOresult<>0 then begin
   WriteLn(#13#10' �������� �訡�� ᮧ����� �⮣� 䠩��'#13#10);
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