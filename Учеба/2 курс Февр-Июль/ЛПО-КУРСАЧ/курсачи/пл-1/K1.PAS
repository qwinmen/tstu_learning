uses crt;

{*********************************����������*********************************}

var z,k,l,kollex,kolid,kolkod,flag,flag1,m,n,a:integer;
    f,f1:text;
    stroka,lexema,idorconst:string;
    kodtab,simtab:array[1..25]of string;
    lextab:array[1..570]of string[2];

{*********************************���������*********************************}

procedure osibka(q,w:string);{ᮮ�饭�� �� �訡���}
begin
  textcolor(5);
  if z<>100 then writeln('���⠪��᪨� �訡��:');
  textcolor(7);
  writeln('   ',q,w);
  z:=100;
end;

procedure obr_arifm;
begin
  a:=0;
  if lextab[k-2]<>'26'then osibka('������ "=" �ਬ������ ⮫쪮 � �����䨪��ࠬ !','');
  if (lextab[k+1]<>'15')and(lextab[k+1]<>'26')and(lextab[k+1]<>'27')then osibka('��䬥��᪠� �訡�� !','');
  repeat
    inc(k);
    if lextab[k]='15'then
       begin inc(a);
         if(lextab[k+1]<>'26')and(lextab[k+1]<>'27')then osibka('��䬥��᪠� �訡�� !','');
       end;
    if lextab[k]='16'then
       begin dec(a);
         if(lextab[k-2]<>'26')and(lextab[k-2]<>'27')then osibka('��䬥��᪠� �訡�� !','');
         if(lextab[k+1]<>'11')and(lextab[k+1]<>'20')and(lextab[k+1]<>'21')and
           (lextab[k+1]<>'22')and(lextab[k+1]<>'23')then osibka('��䬥��᪠� �訡�� !','');
       end;
    if (lextab[k]='20')or(lextab[k]='21')or(lextab[k]='22')or(lextab[k]='23')then
       begin
         if (lextab[k+1]<>'26')and(lextab[k+1]<>'27')and(lextab[k+1]<>'15')then osibka('��䬥��᪠� �訡�� !','');
         if (lextab[k-2]<>'26')and(lextab[k-2]<>'27')and(lextab[k-1]<>'16')then osibka('��䬥��᪠� �訡�� !','');
       end;
    if a<0 then a:=-100;
  until (lextab[k]='11')and(lextab[k-1]<>'27');
  if a>0 then osibka('�� 墠⠥� ᪮��� ")" !','');
  if a<0 then osibka('�� 墠⠥� ᪮��� "(" !','');
end;

procedure obr_skob;          {��ࠡ��稪 ᪮���}
begin
  if lextab[k]='17' then inc(l) else dec(l);
  if l<0 then osibka('������ "]" �� ����� ����� ࠭�� ᪮��� "[" !','');
end;

procedure obr_viv;           {��ࠡ��稪 �㭪樨 "�뢮�"}
begin
  if (lextab[k+2]<>'26')and(lextab[k+2]<>'27')then osibka('������ ��ࠬ���� �㭪樨 "�뢮�" !','');
  if lextab[k+4]='13'then begin inc(k,3);obr_viv;exit;end;
  if lextab[k+4]<>'16'then osibka('�� 墠⠥� ")" ��� �㭪樨 "�뢮�" !','');
  if lextab[k+5]<>'11'then osibka('�� 墠⠥� ";" ��᫥ �㭪樨 "�뢮�" !','');

end;

procedure obr_prog;          {��ࠡ��稪 ��������� �ணࠬ��}
begin
  if k<>2 then osibka('������ "�ணࠬ��" �� ����� ��室����� ����� �ணࠬ��!','');
  if lextab[k+1]<>'26'then osibka('�������⨬� ��������� �ணࠬ��!','');
  if lextab[k+3]<>'11'then osibka('�� 墠⠥� ";"',' ��᫥ �㭪樨 "�ணࠬ��"');
end;

procedure obr_esli;          {��ࠡ��稪 �㭪樨 "�᫨"}
begin
  if ((lextab[k+1]<>'26')and(lextab[k+1]<>'27'))or((lextab[k+3]<>'24')and
  (lextab[k+3]<>'25')and(lextab[k+3]<>'19'))or((lextab[k+4]<>'26')and
  (lextab[k+4]<>'27'))then osibka('����୮� �᫮��� � �㭪樨 "�᫨" !','');
  if lextab[k+6]<>'6' then osibka('�� 墠⠥� ���祢��� ᫮�� "�" ��᫥ �㭪樨 "�᫨" !','');
  inc(k,6);
end;

procedure obr_perem;         {��ࠡ��稪 ࠧ���� ��६�����}
begin
    if(lextab[k+1]<>'26')and(lextab[k+1]<>'9')then osibka('� ࠧ���� ��६����� ��� �����䨪��஢ !','');
    if lextab[k+3]='13'then
         begin
           if lextab[k+4]<>'26'then osibka('������ �ଠ� �����䨪��� !','');
              inc(k,3);obr_perem;
         end
    else begin
           inc(k,3);
           if (lextab[k]<>'12')and(lextab[k]<>'15')then osibka('��� ":" !','');
           if (lextab[k+1]<>'3')and(lextab[k+1]<>'26')then osibka('����७ ⨯ ������ !','');
           if (lextab[k+2]<>'11')and(lextab[k+2]<>'2')then osibka('�� 墠⠥� ";" � ࠧ���� ��६����� !','');
           if (lextab[k+2]='11')and(lextab[k+3]<>'4')then begin inc(k,2);obr_perem;end;
         end;
end;

procedure obr_chit;          {��ࠡ��稪 �㭪樨 "����"}
begin
  if (lextab[k+2]<>'26')and(lextab[k+2]<>'27')then osibka('������ ��ࠬ���� �㭪樨 "����" !','');
  if lextab[k+4]='13'then begin inc(k,3);obr_chit;exit;end;
  if lextab[k+4]<>'16'then osibka('�� 墠⠥� ")" ��� �㭪樨 "����" !','');
  if lextab[k+5]<>'11'then osibka('�� 墠⠥� ";" ��᫥ �㭪樨 "����" !','');
end;

procedure tabsim;            {�࣠������ ⠡���� ᨬ�����}
begin
  for n:=0 to kolid do
    begin
      if flag1<>100 then
        begin
          if idorconst=simtab[n] then begin m:=1;break;end;
        end
      else
        if idorconst=simtab[n] then begin m:=3;break;end
        else m:=2;
    end;
  case m of
    0:begin
        inc(n);
        inc(kolid);
        simtab[kolid]:=idorconst;
      end;
    1:begin osibka('������� ���ᠭ�� ��६����� ',idorconst);z:=100;end;
    2:osibka('�� ���ᠭ� ��६����� ',idorconst);
  end;
end;

procedure id_or_const;     {�ਭ���������� ���ᥬ� � ������ ID ��� CONST}
begin
 val(idorconst,m,n);
 if n=0 then begin (*write({CONST:}' ',kollex+2,' ',idorconst);*)
                   writeln(f1,kollex+2);
                   writeln(f1,idorconst);
                   inc(kolkod,2);
                   inc(a);str(kollex+2,lextab[a]);
                   inc(a);lextab[a]:=idorconst;
             end
 else begin
        val(idorconst[1],m,n);
        if n<>0 then
            begin tabsim;
                  (*write({ID:}' ',kollex+1,' ',n);*)
                  writeln(f1,kollex+1);
                  writeln(f1,n);
                  inc(kolkod,2);
                  inc(a);str(kollex+1,lextab[a]);
                  inc(a);str(n,lextab[a]);
            end
        else osibka('��������� �ଠ� ���ᥬ� ',idorconst);
      end;
 idorconst:='';
end;

procedure lexan;              {�����᪨� ���������}
begin
 repeat
   readln(f,stroka);
   k:=1;
   repeat
    if stroka[k]<>' ' then
      begin
        for l:=1 to kollex do
          begin
            if stroka[k]=kodtab[l,1] then
                begin
                  lexema:=copy(stroka,k,length(kodtab[l]));
                  if lexema=kodtab[l] then
                      begin
                        flag:=1;
                        inc(k,length(kodtab[l]));
                        if idorconst<>'' then id_or_const;
                        (*write(' ',{lexema,}l);*)
                        writeln(f1,l);
                        inc(kolkod);
                        inc(a);str(l,lextab[a]);
                        if l=9 then flag1:=100;
                        break;
                      end;
                end
              else flag:=0;
           end;
        if flag<>1 then begin idorconst:=idorconst+stroka[k];inc(k);end;
      end
    else inc(k);
   until k>length(stroka);
(*writeln;*)
until eof(f);
end;

procedure sinan;                  {ᨭ⠪��᪨� ���������}
begin
 l:=0;
 for k:=1 to kolkod+1 do
   begin
     if(lextab[k]='1')and(lextab[k-1]<>'26')and(lextab[k-1]<>'27')then obr_prog;
     if(lextab[k]='2')and(lextab[k-1]<>'26')and(lextab[k-1]<>'27')then obr_perem;
     if(lextab[k]='9')and(lextab[k-1]<>'26')and(lextab[k-1]<>'27')then flag:=50;
     if(lextab[k]='4')and(lextab[k-1]<>'26')and(lextab[k-1]<>'27')then
       begin
         if(lextab[k+1]='15')and(lextab[k+2]='16')and(lextab[k+3]='11')then continue;
         if lextab[k+1]<>'15'then osibka('�� 墠⠥� "(" ��� �㭪樨 "����" !','');
         obr_chit;
       end;
     if(lextab[k]='5')and(lextab[k-1]<>'26')and(lextab[k-1]<>'27')then obr_esli;
     if(lextab[k]='8')and(lextab[k-1]<>'26')and(lextab[k-1]<>'27')then
       begin
         if(lextab[k+1]='15')and(lextab[k+2]='16')and(lextab[k+3]='11')then continue;
         if lextab[k+1]<>'15'then osibka('�� 墠⠥� "(" ��� �㭪樨 "�뢮�" !','');
         obr_viv;
       end;
     if (lextab[k]='17')or(lextab[k]='18') then obr_skob;
     if lextab[k]='19' then obr_arifm;
   end;
 if (lextab[k-1]<>'10')and(lextab[k]<>'14')then osibka('�� 墠⠥� ���祢�� ᫮� "�����" � "." � ���� �ணࠬ�� !','');
end;

{*****************************�������� ���������*****************************}

BEGIN
clrscr;
kollex:=0;kolid:=0;kolkod:=0;flag1:=1;a:=1;
assign(f,'tabkod.txt');reset(f);
while not eof(f) do             {���������� ⠡���� �����}
  begin
    inc(kollex);
    readln(f,kodtab[kollex]);
  end;
close(f);
assign(f1,'kod.txt');rewrite(f1);
assign(f,'ish.txt');reset(f);
lexan;
sinan;
close(f);
close(f1);
for k:=1 to abs(l) do
     begin
        if l<0 then osibka('�� 墠⠥� ᪮��� "["','');
        if l>0 then osibka('�� 墠⠥� ᪮��� "]"','');
     end;
if z<>100 then
   begin
     textcolor(3);writeln('���⠪��᪨� �訡�� ���!');textcolor(7);
   end;
assign(f,'tabid.txt');rewrite(f);
writeln(f,kolid);
for a:=1 to kolid do writeln(f,simtab[a]);
close(f);
write(#10'������ ���� ������ ��� ��室�...');readkey;
END.