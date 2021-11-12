uses crt;
type
   Tabliza=record
    sim:string;
    typ:string;
    ch:integer;
    c:string;
   end;

type
 compil=object
  tab:array[1..10] of tabliza;
  bp,bp1,lab_met,skobka,then_true:boolean;
  name_ident_error,k,kk,then_oper,name:string;
  name_label,adr:array[1..2] of char;
  znak_id,lk:char;
  uslov_znak:array[1..3] of string[2];
  oper_prisv:array[1..3] of string[5];
  identif,id_usl:array[1..10] of string[5];
  i,err,chislo_begin,index,nomer_id,param
  ,zn_usl,n_id_usl,stroka_err:integer;
  procedure nazvanie;
  procedure metka;
  procedure vvod;
  procedure spisok_perem;
  procedure probel;
  procedure vivod;
  procedure razdel_opisan;
  procedure razdel_perem;
  procedure typ;
  procedure prisvaivanie;
  procedure arif_viragen;
  procedure znachenie;
  procedure razdel_operatorov;
  procedure operator;
  procedure glav_operator;
  procedure uslov_operator;
  procedure log_viragen;
  procedure uslovie;
  procedure log_slag;
  procedure znak_log;
  procedure lexema;
  procedure adres;
  procedure const_label;
  procedure goto_perehod;
  procedure hesh_tab;
  procedure q;
  procedure zz;
  procedure posled_4;
  procedure error;
 end;

procedure compil.probel;
begin zz;
  while (k[i]='2')and(k[i+1]=' ')and(k[i+2]='p')and(k[i+3]=' ') do i:=i+4;zz;q;zz;
end;

procedure compil.nazvanie;
var p:text;
begin
 assign(p,'posled_4.txt');
  rewrite(p);
  close(p);

 assign(p,'texttt.txt');
    reset(p);
    readln(p,k);
    read(p,kk);
    close(p);
    zn_usl:=0;
  bp:=false;err:=0;i:=1;chislo_begin:=0;index:=1;stroka_err:=0;
  zz;adr[1]:=' ';adr[2]:=' ';then_true:=false;
 if k[i]='1' then
        begin
         i:=i+2;
         if k[i]='2'then
               begin
                probel;
                if (k[i]='1')and(k[i+1]='1')then
                     begin
                      i:=i+3;
                      while (k[i]>='a')and(k[i]<='z') do
                         begin name:=name+k[i];inc(i);end;inc(i);
                      probel;
                      if k[i]='4' then
                           begin
                            i:=i+2;bp:=true;
                            probel;
                           end
                      else err:=3;
                     end
                else err:=2;
                end
         else err:=1;
        end
 else
end;

procedure compil.const_label;
var j:integer;
begin
 bp:=false;j:=1;zz;
 while (k[i]='3')and(k[i+1]='3')and(bp=false) do
      begin
       i:=i+3;
       {запись метки}
       name_label[j]:=k[i];
       i:=i+2;inc(j);
       if (k[i]='2')and(k[i+1]='5')then i:=i+3;
       if k[i]='4' then bp:=true;
      end;
      if name_label[1]=name_label[2] then
         begin
          err:=18;
          tab[1].c:=name_label[1];{Идентификатор для ошибки}
         end;
end;

procedure compil.metka;
begin
 bp:=false;zz;
 if k[i]='5' then
        begin
         i:=i+2;
         if k[i]='2'then
               begin
                probel;
                if (k[i]='3')and(k[i+1]='3')then
                     begin
                      const_label;
                      if (k[i]='4')and(err=0) then
                           begin
                             i:=i+2;
                             bp:=true;
                             probel;
                            end
                      else if err=0 then err:=3;
                     end
                else if err=0 then err:=2;
               end
         else if err=0 then err:=1;
        end;
end;


procedure compil.razdel_opisan;
begin
bp:=false;zz;
 if (k[i]='5')and(err=0) then metka;zz;
 if (k[i]='7')and(err=0) then
    begin
     i:=i+2;zz;
     if k[i]='2' then
         begin
          probel;
          if (k[i]='1')and(k[i+1]='1')then
              begin
               hesh_tab;{Хеширование ф-ции}
               while(k[i]='1')and(k[i+1]='1')and(err=0)
                do razdel_perem;
               bp:=true;probel;
              end
          else err:=2;
         end
     else err:=1;
    end
 else if err=0 then err:=1;
end;

procedure compil.razdel_perem;
begin
 if (k[i]='1')and(k[i+1]='1')then
  begin
     spisok_perem;
     if (k[i]='1')and(k[i+1]='4')and(err=0)then
      begin
       i:=i+3; q;
       probel;
       if (k[i]='2')and(k[i+1]='9')then
        begin
         typ;probel;
         if (k[i]='4')and(err=0) then
          begin
           i:=i+2;q;probel;
          end
         else if err=0 then err:=3;
        end
       else err:=5;
      end
     else if err=0 then err:=4;
  end;
end;

procedure compil.spisok_perem;
var index_id,index1:integer;
begin
 for index1:=1 to 10 do identif[index1]:='';
 index1:=1;
 inc(nomer_id);
 param:=1;
if (k[i]='1')and(k[i+1]='1')then
       begin
        i:=i+3;q;
        while (k[i]>='a')and(k[i]<='z') do
           begin
            identif[index1]:=identif[index1]+k[i];
            id_usl[n_id_usl]:=identif[index1];
            inc(i);q;
           end;inc(i);q;
        {Проверка символа}
        for index_id:=1 to 10 do
         begin
          if tab[index_id].sim=identif[index1] then
             begin
              inc(param);
              oper_prisv[nomer_id]:=identif[index1];
              bp:=true;index_id:=10;
             end
          else if (index_id=10)and(bp=false) then err:=5;
         end;

        while (k[i]='2')and(k[i+1]='5')do
             begin
              i:=i+3;q;probel;
              inc(index1);identif[index1]:='';
                 if(k[i]='1')and(k[i+1]='1')then
                     begin
                      i:=i+3;q;
                      while (k[i]>='a')and(k[i]<='z') do
                        begin
                         identif[index1]:=identif[index1]+k[i];
                         inc(i);q;
                        end;inc(i);q;
                      {Проверка символа}
                      bp:=false;
                      for index_id:=1 to 10 do
                       begin
                        if tab[index_id].sim=identif[index1] then
                         begin
                          inc(param);
                          bp:=true;
                          index_id:=10;
                         end
                        else if (index_id=10)and(bp=false) then
                         begin
                          err:=5;{bp:=false;}
                         end;
                       end;
                     end
                 else err:=2;
             end;
       end;
end;

procedure compil.typ;
begin zz;
 if(k[i]='2')and(k[i+1]='9')then begin i:=i+3;q;end;
end;

procedure compil.glav_operator;
var p:text;
begin
 bp:=false;zz;
 if(k[i]='2')and(k[i+1]='6')and(err=0)then
          begin
           i:=i+3;q;inc(chislo_begin);
           if k[i]='2' then
              begin
               q;probel;
               razdel_operatorov;
               i:=i-3;
               if(k[i]='2')and(k[i+1]='2')and(err=0)then
                     begin
                      i:=i+3;q;probel;
                      assign(p,'posled_4.txt');
                      append(p);
                      writeln(p,'           exit');
             if then_oper<>' 'then begin
             writeln(p,'3: ');
             writeln(p,then_oper);
             end;
             close(p);
                      if(k[i]='2')and(k[i+1]='3')then
                          if chislo_begin=0 then
                              begin
                               writeln;
                               writeln('             Ошибок нет')
                              end
                          else err:=13
                      else
                         if k[i]='4' then err:=14
                         else err:=13;
                     end
               else if err=0 then err:=13;
              end
           else err:=3;
          end
 else if err=0 then err:=5;
end;

procedure compil.razdel_operatorov;
begin
bp:=false;zz;
if (k[i]='1')and(k[i+1]='1'){id:=}
 or(k[i]='1')and(k[i+1]='7'){if}
 or(k[i]='3')and(k[i+1]='3'){label}
 or(k[i]='2')and(k[i+1]='0'){goto}
 or(k[i]='2')and(k[i+1]='6'){begin}
 or(k[i]='2')and(k[i+1]='1'){write}
 or(k[i]='9')then{read}
    begin
     adres;
     if(k[i]='2')and(k[i+1]='6')and(err=0) then inc(chislo_begin);
     operator;
     if(k[i]='2')and(k[i+1]='2')and(err=0) then dec(chislo_begin);
     if (k[i]='4')and(err=0) then{;}
         begin
          i:=i+2;q;
          probel;
         end
     else if err=0 then err:=3;

        while (k[i]='9'){read}
            or(k[i]='2')and(k[i+1]='1'){write}
            or(k[i]='1')and(k[i+1]='1'){id:=}
            or(k[i]='1')and(k[i+1]='7'){if}
            or(k[i]='2')and(k[i+1]='0'){goto}
            or(k[i]='3')and(k[i+1]='3'){label}
            or(k[i]='2')and(k[i+1]='6'){begin}
            or(k[i]='2')and(k[i+1]='2'){end} do
                begin
                adres;
                if(k[i]='2')and(k[i+1]='6')and(err=0) then inc(chislo_begin);
                operator;
                if(k[i]='2')and(k[i+1]='2')and(err=0) then
                   begin
                    dec(chislo_begin);
                    i:=i+3;q;
                   end;
                  if (k[i]='4')and(err=0)and(chislo_begin<>0)then
                    begin
                     i:=i+2;q;
                     probel;
                    end
                  else if(err=0)
                      and(k[i]<>'2')and(k[i+1]<>'2')
                      and(chislo_begin<>0) then
                       begin
                        err:=3;
                       end;
                end;
   end;
end;


procedure compil.operator;
begin
 bp:=false;zz;
if (k[i]='9')and(bp=false) then begin vvod;bp:=true;end;
if(k[i]='1')and(k[i+1]='1')and(bp=false)then begin prisvaivanie;bp:=true;end;
if(k[i]='1')and(k[i+1]='7')and(bp=false)then begin uslov_operator;bp:=true;end;
if(k[i]='2')and(k[i+1]='1')and(bp=false)then begin vivod;bp:=true;end;
if(k[i]='2')and(k[i+1]='0')and(bp=false)then begin goto_perehod;bp:=true;end;
end;

procedure compil.adres;
var j:integer;p:text;
begin zz;
 if(k[i]='3')and(k[i+1]='3')then
    begin
     i:=i+3;q;
     for j:=1 to 2 do
      begin
       if k[i]=name_label[j] then{Если метка равна метке из списка меток}
                begin
                 if k[i]<>adr[j] then
                   begin
                    adr[j]:=k[i];i:=i+2;q;probel;
                     if(k[i]='1')and(k[i+1]='4')then {:}
                      begin
                       i:=i+3;q;probel;
                       lk:=adr[j];
                       assign(p,'posled_4.txt');
                       append(p);
                       writeln(p,adr[j],':  ');
                       close(p);
                       j:=2;
                      end
                     else err:=4;
                   end
                 else err:=19;{Двойная метка }
                end
             else if j=2 then err:=5;
      end;
    end;
end;

procedure compil.goto_perehod;
var j:integer;p:text;lk1:string;
begin
 if(k[i]='2')and(k[i+1]='0') then
   begin
    i:=i+3;q;
      if k[i]='2' then
         begin
          probel;
          if(k[i]='3')and(k[i+1]='3')then
             begin
              i:=i+3;q;   bp:=false;
              for j:=1 to 2 do
              begin
               if k[i]=name_label[j] then{Если метка равна метке из списка меток}
                begin
                 if k[i]=adr[j] then
                   begin
                    adr[j]:=k[i];i:=i+2;q;probel;bp:=true;
                   end
                 else err:=10;{ метка отсутствует}
                end
               else if (j=2)and(bp=false) then err:=5;
              end;
              if then_true=true then
                begin
              then_oper:='  goto       '+lk;
                end else
                    begin
                    assign(p,'posled_4.txt');
                    append(p);
                    writeln(p,'  goto       ',lk);
                    close(p);
                    end;
             end
          else err:=12;{Ссылка отсутствует}
         end
      else err:=5;{если нет пробела между goto и 2}
   end
end;

procedure compil.vvod;
var p:text;n_param:integer;
begin
   bp:=false;
    if k[i]='9' then
         begin
          i:=i+2;q;probel;
          if (k[i]='1')and(k[i+1]='0') then
                 begin
                 i:=i+3;q;probel;
                 if (k[i]='1')and(k[i+1]='1') then spisok_perem
                  else err:=6;
                   if (k[i]='1')and(k[i+1]='2')and(err=0) then
                        begin
                         bp:=true;
                         i:=i+3;q;
                          assign(p,'posled_4.txt');
                          append(p);
                          writeln(p,'  read  ');
                           for n_param:=1 to param-1 do writeln(p,'  param   ',identif[n_param]);
                          close(p);
                        end
                   else if err=0 then err:=15;
                 end
           else begin err:=16;end;
          end;
end;


procedure compil.vivod;
var p:text;n_param:integer;
begin
    if (k[i]='2')and(k[i+1]='1') then
         begin
          i:=i+3;q;
          probel;
          if (k[i]='1')and(k[i+1]='0') then
                 begin
                 i:=i+3;q;probel;
                  if (k[i]='1')and(k[i+1]='1') then spisok_perem
                  else err:=9;
                   if (k[i]='1')and(k[i+1]='2')and(err=0)then
                    begin
                     i:=i+3;q;probel;
                     assign(p,'posled_4.txt');
                       append(p);
                       writeln(p,'  write  ');
                       for n_param:=1 to param-1 do writeln(p,'  param   ',identif[n_param]);
                       close(p);
                    end
                   else if err=0 then err:=15;
                 end
          else begin err:=16;end;
         end;
end;

procedure compil.prisvaivanie;
var znak_prisv:string;p:text;
begin
 bp:=false;nomer_id:=0;
 if (k[i]='1')and(k[i+1]='1')then
     begin
      probel;
       spisok_perem;
       probel;
      if (k[i]='1')and(k[i+1]='4')and(err=0)then
          begin
          i:=i+3;q;probel;
          if (k[i]='1')and(k[i+1]='3') then
          begin
           i:=i+3;q;probel;
           znak_prisv:=':=';
           arif_viragen;
           if (nomer_id=2)and(err=0) then {если x:=x;}
            begin
             assign(p,'posled_4.txt');
             append(p);
             writeln(p,'  ',znak_prisv{:=},'  ',oper_prisv[2],'     ',oper_prisv[1]);
             close(p);
            end;
           if (nomer_id=3)and(err=0) then {если x:=x+x}
            begin
             assign(p,'posled_4.txt');
             append(p);
             writeln(p,'  ',znak_id,'  ',oper_prisv[2],'  ',oper_prisv[3],'  s1');
             writeln(p,'  ',znak_prisv{:=},'  s1    ',oper_prisv[1]);
             close(p);
            end;
          end;
          end
      else if err=0 then err:=8;
     end
 else begin err:=7; end;
end;


procedure compil.arif_viragen;
begin
 znachenie;probel;
  if (k[i]='1')and(k[i+1]='5'){*}
   or(k[i]='1')and(k[i+1]='6'){+}
   or(k[i]='2')and(k[i+1]='7'){-}then
       begin
        if(k[i]='1')and(k[i+1]='5'){*} then znak_id:='*';
        if(k[i]='1')and(k[i+1]='6'){+} then znak_id:='+';
        if(k[i]='2')and(k[i+1]='7'){-} then znak_id:='-';
        i:=i+3;q;probel;
        znachenie;
       end;
end;

procedure compil.znachenie;
begin
 bp:=false;
 if (k[i]='1')and(k[i+1]='1')then
          begin
           bp:=true;
           spisok_perem;
          end
 else if(k[i]='3')and(k[i+1]='3') then
        begin
         i:=i+3;q; probel;
         inc(nomer_id);oper_prisv[nomer_id]:='#';
         while (k[i]>='0')and(k[i]<='9') do
            begin
             oper_prisv[nomer_id]:=oper_prisv[nomer_id]+k[i];
             inc(i);q;
             id_usl[n_id_usl]:=oper_prisv[nomer_id];
            end;
         inc(i);q;
        end
      else err:=9;bp1:=true;
end;

procedure compil.uslov_operator;
var p:text;
begin
bp:=false;n_id_usl:=0;
if(k[i]='1')and(k[i+1]='7')then
    begin
     i:=i+3;q;
     if (k[i]='1')and(k[i+1]='0')
        or(k[i]='1')and(k[i+1]='1')
        or(k[i]='3')and(k[i+1]='3')
        or(k[i]='2') then
         begin
          log_viragen;
          if(k[i]='1')and(k[i+1]='9')and(err=0)then
             begin
              i:=i+3;q;then_true:=true;
              if k[i]='2'then
                 begin
                  probel;
                  assign(p,'posled_4.txt');
                      append(p);
                      if zn_usl=1 then
                       begin
writeln(p,'  ',uslov_znak[zn_usl],'  ',id_usl[1],'  ',id_usl[2],'  3');
                       end else
                     if zn_usl=2 then
                      begin
writeln(p,'  ',uslov_znak[1],'  ',id_usl[1],'  ',id_usl[2],'  5');
writeln(p,'5:');
writeln(p,'  ',uslov_znak[2],'  ',id_usl[3],'  ',id_usl[4],'   3');
                      end;
                     close(p);
                    razdel_operatorov;
                  probel;
               end
              else begin err:=5;bp1:=true; end;
             end
          else if err=0 then err:=11;
         end
     else begin err:=9;bp1:=true; end;
    end;
end;

procedure compil.log_viragen;
begin
bp:=false;skobka:=false;
if (k[i]='1')and(k[i+1]='0')
   or(k[i]='2') then
         begin
         probel;
         if (k[i]='1')and(k[i+1]='0') then
          begin i:=i+3;q; skobka:=true; end;
         probel;
          uslovie;
          bp:=true;
          if(k[i]='1')and(k[i+1]='2')and(err=0)and(skobka=true)then
              begin
              i:=i+3;q;skobka:=false; probel;
               while(k[i]='3')and(bp=true)and(err=0)do
                   begin
                    probel;
                    log_slag;
                    if (k[i]='1')and(k[i+1]='0')and(err=0)then
                        begin
                         i:=i+3;q;probel;skobka:=false;
                         uslovie;
                         if (k[i]='1')and(k[i+1]='2')and(err=0)then
                             begin
                              i:=i+3;q;probel;bp:=true;skobka:=true;
                             end
                         else if err=0 then err:=9;
                        end
                    else if err=0 then err:=9;
                   end;
              end
          else if(skobka=true)then if err=0 then err:=15;
         end
else begin err:=9;bp1:=true; end;
end;


procedure compil.uslovie;
begin                        {id_usl[n_id_usl]}
bp:=false;
if (k[i]='1')and(k[i+1]='1')or(k[i]='3')and(k[i+1]='3') then
         begin
          inc(n_id_usl);
          znachenie;probel;
          if(k[i]='1')and(k[i+1]='8')and(err=0)
          or(k[i]='1')and(k[i+1]='3')and(err=0)
          or(k[i]='2')and(k[i+1]='8')and(err=0)then
              begin
               znak_log;probel;
               if (k[i]='1')and(k[i+1]='1')and(err=0)or
                  (k[i]='3')and(k[i+1]='3')and(err=0) then
                   begin
                    inc(n_id_usl);
                    znachenie;probel;q;
                    bp:=true;
                   end
               else if err=0 then err:=9;
              end
          else if err=0 then begin err:=17; end;
         end
else begin err:=9;bp1:=true; end;
end;

procedure compil.znak_log;
begin
bp:=false;
inc(zn_usl);
if(k[i]='1')and(k[i+1]='8')and
  (k[i+3]='1')and(k[i+4]='3')then
    begin
     i:=i+6; uslov_znak[zn_usl]:='<=';
    end else if(k[i]='2')and(k[i+1]='8')and
               (k[i+3]='1')and(k[i+4]='3')then
           begin
            i:=i+6;uslov_znak[zn_usl]:='>=';
           end else if(k[i]='1')and(k[i+1]='8')and
                         (k[i+3]='2')and(k[i+4]='8')then
                  begin i:=i+6;uslov_znak[zn_usl]:='<>';end
else
    if(k[i]='1')and(k[i+1]='8')then
     begin
      i:=i+3;uslov_znak[zn_usl]:='<';
     end else if(k[i]='2')and(k[i+1]='8')then
         begin
          i:=i+3;uslov_znak[zn_usl]:='>';
         end else if(k[i]='1')and(k[i+1]='3')then
             begin
              i:=i+3;uslov_znak[zn_usl]:='=';
             end
    else err:=9;q;
end;

procedure compil.log_slag;
begin
 bp:=false;
 if k[i]='3' then
    begin
     i:=i+2;q;bp:=true;
    end;
end;

procedure compil.hesh_tab;
label 1,2,3,4,5;
var
f_hesh:text;
 a,b,c,d,g:string;
m:array[0..9] of integer;
e,l,s,t,x,j,n,i1:integer;
 begin
 n:=1;b:='var';g:='begin';
 for s:=0 to 9 do begin
  m[s]:=0; end;
tab[1].sim:='.';
assign(f_hesh,'text1.pas');
reset(f_hesh);
3:readln(f_hesh,a);
if a=b then
begin
  while a<>g do begin
 readln(f_hesh,a); i1:=1;
 if a<>g then begin
 x:=x+1; end;
 if a=g then goto 1;
 while a[i1]<>':' do begin i1:=i1+1; end;
 c:=a[i1+1];i1:=i1+2;
 while a[i1]<>';' do
   begin c:=c+a[i1]; i1:=i1+1; end;
 i1:=1;t:=1;
 while a[i1]=' ' do begin i1:=i1+1; end;
 while a[i1]<>':' do begin
 if (a[i1]=',') then begin
   i1:=i1+1; d:=a[i1]; i1:=i1+1;
  end else
   begin d:=a[i1]; i1:=i1+1; end;
 if (a[i1]=',')or(a[i1]=':') then begin
  if tab[1].sim='.' then begin
      s:=ord(d[1])mod 10; x:=1;
      tab[x].typ:=c;
      with tab[x] do begin
      sim:=d; ch:=0;end; m[s]:=x;
       if a[i1]=','then begin x:=x+1; end;
     end  else begin
       s:=ord(d[1])mod 10;
       tab[x].typ:=c;
        with tab[x] do begin
      sim:=d;ch:=0;end; j:=x;
       if m[s]<>0  then begin
        e:=x; x:=m[s]; j:=x;
       4: if tab[x].sim=d then
       {ошибка}   begin tab[n].c:=d;err:=18; n:=n+1;end;
        if tab[x].ch=0 then
         tab[x].ch:=e
         else begin x:=tab[x].ch; goto 4;
          end; x:=e; end; m[s]:=j;
      if a[i1]=','then begin x:=x+1; end;
        end; end else begin
    if a[i1]<>',' then begin
       while a[i1]<>',' do
        begin
        d:=d+a[i1];
        i1:=i1+1;
         if a[i1]=':' then goto 2; end;
     2:  if tab[1].sim='.' then begin
        x:=1; l:=length(d); s:=0;
      for t:=1 to l do begin
        s:=s+ord(d[t]); end;
       s:=s mod 10;
       tab[x].typ:=c;
      with tab[x] do begin
      sim:=d;ch:=0;end;
      m[s]:=x;
      if a[i1]=','then begin x:=x+1; end;
     end else begin
        l:=length(d); s:=0;
      for t:=1 to l do
       begin s:=s+ord(d[t]); end;
       s:=s mod 10;tab[x].typ:=c;
       with tab[x] do begin
      sim:=d;ch:=0;end;
       j:=x;if m[s]<>0  then begin
        e:=x; x:=m[s]; j:=x;
       5:if tab[x].sim=d then
    {ошибка}      begin tab[n].c:=d;err:=18;n:=n+1;end;
       if tab[x].ch=0 then
        tab[x].ch:=e
         else begin
           x:=tab[x].ch; goto 5;
          end; x:=e; end;
      m[s]:=j;if a[i1]=','then begin x:=x+1; end;
      end; end; end; end;
 end; {a<>g}end {a=b} else goto 3;
1:
  end;

procedure compil.lexema;
var f_lex:text;
    o,z,w,id_or:string;
    nomer_str,v,i1,n:integer;
    bb:boolean;
begin
  k:='';w:='';
  bp:=false;n:=1;clrscr;
  assign(f_lex,'texttt.txt');
  rewrite(f_lex);
  close(f_lex);
  assign(f_lex,'text1.pas');
  reset(f_lex);
  readln(f_lex,o); writeln(n,' ',o);
  k:='@'+o;
  while not eof(f_lex) do
  begin inc(n);
   readln(f_lex,o); writeln(n,' ',o);
   k:=k+'@'+o;
  end;
  close(f_lex);v:=length(k);
  nomer_str:=0;
  for i1:=1 to v+1 do
   begin
   if k[i1]='#'then v:=length(k);
   if k[i1]='@'then begin z:='@ ';w:=w+z;inc(nomer_str);end;
   if(k[i1]='l')and(k[i1+1]='a')and(k[i1+2]='b')and(k[i1+3]='e')and(k[i1+4]='l')then
      begin z:='5 ';w:=w+z;i1:=i1+5; end;
    if(k[i1]='i')and(k[i1+1]='n')and(k[i1+2]='t')and(k[i1+3]='e')and(k[i1+4]='g')
    and(k[i1+5]='e')and(k[i1+6]='r')then
    begin z:='29 ';w:=w+z;i1:=i1+7;end;
   if(k[i1]='r')and(k[i1+1]='e')and(k[i1+2]='a')and(k[i1+3]='d')then
      begin z:='9 ';w:=w+z; i1:=i1+4;
       if k[i]='@'then begin z:='@ ';w:=w+z;inc(nomer_str);end;end;
   if(k[i1]='e')and(k[i1+1]='l')and(k[i1+2]='s')and(k[i1+3]='e')then
      begin z:='30 ';w:=w+z;i1:=i1+4;
      if k[i]='@'then begin z:='@ ';w:=w+z;inc(nomer_str);end;end;
   if(k[i1]='v')and(k[i1+1]='a')and(k[i1+2]='r')then
      begin z:='7 ';w:=w+z; i1:=i1+3;
      if k[i1]='@'then begin z:='@ ';w:=w+z;inc(nomer_str);end;
       end;
   if(k[i1]='e')and(k[i1+1]='n')and(k[i1+2]='d')then
      begin z:='22 ';w:=w+z;i1:=i1+3; end;
   if(k[i1]='a')and(k[i1+1]='n')and(k[i1+2]='d')then
      begin z:='3 ';w:=w+z;i1:=i1+3; end;
   if (k[i1]='i')and(k[i1+1]='f')and(k[i1+2]=' ')or(k[i1+2]='(') then
     begin z:='17 ';w:=w+z;i1:=i1+2;end;
   if(k[i1]='t')and(k[i1+1]='h')and(k[i1+2]='e')and(k[i1+3]='n')then
      begin z:='19 ';w:=w+z; i1:=i1+4; end;
   if (k[i1]='b')and(k[i1+1]='e')and(k[i1+2]='g')and(k[i1+3]='i')and(k[i1+4]='n')then
      begin z:='26 '; w:=w+z; i1:=i1+5;
      if k[i1]='@'then begin z:='@ ';w:=w+z;inc(nomer_str);end;
       end;
   if (k[i1]='g')and(k[i1+1]='o')and(k[i1+2]='t')and(k[i1+3]='o')then
      begin z:='20 '; w:=w+z; i1:=i1+4; end;
      if(k[i1]='w')and(k[i1+1]='r')and(k[i1+2]='i')
        and(k[i1+3]='t')and(k[i1+4]='e') then
         begin z:='21 ';w:=w+z;i1:=i1+5;end;
     if (k[i1]='p')and(k[i1+1]='r')and
        (k[i1+2]='o')and(k[i1+3]='g')and
        (k[i1+4]='r')and(k[i1+5]='a')and(k[i1+6]='m') then
         begin z:='1 ';w:=w+z; i1:=i1+7;end;

   if k[i1]='('then begin z:='10 ';w:=w+z; end;
   if k[i1]=')'then begin z:='12 ';w:=w+z; end;
   if k[i1]='<'then begin z:='18 ';w:=w+z; end;
   if k[i1]='='then begin z:='13 ';w:=w+z; end;
   if k[i1]='+'then begin z:='16 ';w:=w+z;end;
   if k[i1]='>'then begin z:='28 ';w:=w+z; end;
   if k[i1]='-'then begin z:='27 ';w:=w+z; end;
   if k[i1]='*'then begin z:='15 ';w:=w+z; end;
   if k[i1]=';'then begin z:='4 ';w:=w+z;end;
   if k[i1]='.'then begin z:='23 ';w:=w+z;end;
   if k[i1]=','then begin z:='25 ';w:=w+z;end;
   if k[i1]=':'then begin z:='14 ';w:=w+z;end;
   if k[i1]=' 'then begin z:='2 p ';w:=w+z; end;
   if(k[i1]>='0')and(k[i1]<='9')then
      begin
       id_or:='';
       while (k[i1]>='0')and(k[i1]<='9') do
          begin id_or:=id_or+k[i1];inc(i1); end;
          dec(i1); id_or:=id_or+' '; z:='33 ';
          w:=w+z+id_or;
      end;
     if (k[i1]>='a')and(k[i1]<='z')then
      begin
       id_or:='';
       while(k[i1]>='a')and(k[i1]<='z') do begin id_or:=id_or+k[i1];inc(i1);end;
       dec(i1);id_or:=id_or+' ';z:='11 ';w:=w+z+id_or;
      end;

     if (i1>102)and(bp=false)then
      begin
       assign(f_lex,'texttt.txt');
       append(f_lex);
       writeln(f_lex,w);
       close(f_lex);w:='';bp:=true;bb:=true;
      end;
       if k[i1]='#'then v:=length(k);
   end;
    assign(f_lex,'texttt.txt');
    append(f_lex);
    writeln(f_lex,w);
    close(f_lex);
    nazvanie;
    razdel_opisan;
    glav_operator;
    if err<>0 then begin
    writeln;
    error;
    end else posled_4;
    writeln('         Нажмите любую клавишу');
    readkey;
end;

procedure compil.error;
var str_error:string;
begin
 case err of
  1: begin str_error:='Ожидается оператор Begin'; end;
  2: begin str_error:='Ожидается идентификатор'; end;
  3: begin str_error:='Ожидается символ ";"'; end;
  4: begin str_error:='Ожидается символ ":"'; end;
  5: begin str_error:='Неизвестный идентификатор'; end;
  6: begin str_error:='Ожидается идентификатор переменной';end;
  7: begin str_error:='Ошибка в операторе'; end;
  8: begin str_error:='Ожидается символ ":="'; end;
  9: begin str_error:='Ошибка в выражении'; end;
  10:begin str_error:='Неопределённая метка в предыдущей части оператора'; end;
  11:begin str_error:='Ожидается THEN '; end;
  12:begin str_error:='Ожидается идентификатор метки'; end;
  13:begin str_error:='Неожиданный конец файла'; end;
  14:begin str_error:='Ожидается символ "."'; end;
  15:begin str_error:='Ожидается символ ")"'; end;
  16:begin str_error:='Ожидается символ "("'; end;
  17:begin str_error:='Ожидается выражение логического типа'; end;
  18:begin str_error:='Повторение идентификатора('+tab[1].c+')'; end;
  19:begin str_error:='Метка уже определена';end;
  end;
write('Ошибка ',err,' : ',str_error,'.  Строка номер ',stroka_err);
end;

procedure compil.posled_4;
var
f,g:text;
x:integer;
zn,a,b,c,call_text,d:string[25];
ss:boolean;
begin
  assign(g,'assemb.txt');
  rewrite(g);
  writeln(g,'title ',name);
  writeln(g,'.mcall .exit');
  writeln(g,'A1:');
  close(g);
  assign(f,'posled_4.txt');
  reset(f);ss:=false;
  while not eof(f) do
  begin
  readln(f,a);
  x:=1;
while a[x]=' ' do x:=x+1;
      if (a[x]='+')or(a[x]='*')or(a[x]='-')then
           begin
            zn:=a[x];
            while a[x]<>' ' do x:=x+1;
            while a[x]=' ' do x:=x+1;
            c:=a[x];inc(x);
            while (a[x]>='a')and(a[x]<='z')
               or (a[x]>='0')and(a[x]<='9')or(a[x]='#') do
               begin c:=c+a[x];inc(x);end;
            while a[x]=' ' do x:=x+1;
            b:=a[x];inc(x);
            while (a[x]>='a')and(a[x]<='z')
               or (a[x]>='0')and(a[x]<='9')or(a[x]='#') do
               begin b:=b+a[x];inc(x);end;
            while a[x]=' ' do x:=x+1;
            d:=a[x]+a[x+1];
            assign(g,'assemb.txt');
            append(g);
            writeln(g,'    mov   ',c,',R1');
            writeln(g,'    mov   ',b,',R2');
            if (zn='+')then writeln(g,'    add   R1,R2');
            if (zn='*')then writeln(g,'    mul   R1,R2');
            if (zn='-')then writeln(g,'    sub   R1,R2');
            writeln(g,'    mov   R2,',d);
            close(g);
           end;
      if(a[x]='1')or(a[x]='2')or(a[x]='3') then
          begin
           assign(g,'assemb.txt');
            append(g);
            writeln(g,a[x],':');
            close(g);
          end;
      if (a[x]=':')and(a[x+1]='=') then
          begin
            while a[x]<>' ' do x:=x+1;
            while a[x]=' ' do x:=x+1;
            c:=a[x];inc(x);
            while (a[x]>='a')and(a[x]<='z')
               or (a[x]>='0')and(a[x]<='9')or(a[x]='#') do
               begin c:=c+a[x];inc(x);end;
            while a[x]=' ' do x:=x+1;
            b:=a[x];
            assign(g,'assemb.txt');
            append(g);
            writeln(g,'    mov   ',c,',R1');
            writeln(g,'    mov   R1,',b);
            close(g);
           end;
      if (a[x]='g')and(a[x+1]='o') then
          begin
            while a[x]<>' ' do x:=x+1;
            while a[x]=' ' do x:=x+1;
            c:=a[x];
            assign(g,'assemb.txt');
            append(g);
            writeln(g,'    br   ',c);
            close(g);
           end;
      if (a[x]='e')and(a[x+1]='x') then
          begin
            assign(g,'assemb.txt');
            append(g);
            writeln(g,'    br   end');
            close(g);
           end;

      if(a[x]='>')or(a[x]='<')or(a[x]='=')or
        (a[x]='<')and(a[x+1]='=')or
        (a[x]='>')and(a[x+1]='=')or
        (a[x]='<')and(a[x+1]='>')then
           begin ss:=false;
            zn:=a[x]+a[x+1];inc(x,2);
             while a[x]=' ' do inc(x);
             c:=a[x];inc(x);
             while a[x]=' ' do inc(x);
             b:=a[x];inc(x);
             while a[x]=' ' do inc(x);
             d:=a[x];
            assign(g,'assemb.txt');
            append(g);
            writeln(g,'    cmp   ',c,',',b);
            if (zn='> ')and(ss=false)then writeln(g,'    bpl   ',d);
            if (zn='< ')and(ss=false)then writeln(g,'    bmi   ',d);
            if (zn='= ')and(ss=false)then writeln(g,'    beq   ',d);
            if (zn='<>')and(ss=false)then writeln(g,'    bne   ',d);
            if (zn='<=')and(ss=false)then writeln(g,'    ble   ',d);
            if (zn='>=')and(ss=false)then writeln(g,'    bge   ',d);
            if (zn='> ')and(ss=true)then writeln(g,'    bpl   ',d);
            if (zn='< ')and(ss=true)then writeln(g,'    bmi   ',d);
            if (zn='= ')and(ss=true)then writeln(g,'    beq   ',d);
            if (zn='<>')and(ss=true)then writeln(g,'    bne   ',d);
            if (zn='<=')and(ss=true)then writeln(g,'    ble   ',d);
            if (zn='>=')and(ss=true)then writeln(g,'    bge   ',d);
            close(g);ss:=true;
           end;
      if(a[x]='r')and(a[x+1]='e')and(a[x+2]='a')and(a[x+3]='d') then
          begin call_text:='    call rd'; end;
      if(a[x]='w')and(a[x+1]='r')and(a[x+2]='i')and(a[x+3]='t') then
          begin call_text:='    call wd'; end;
      if(a[x]='p')and(a[x+1]='a')and(a[x+2]='r')and(a[x+3]='a')and(a[x+4]='m') then
            begin
             while a[x]<>' ' do begin x:=x+1; end;
             while a[x]=' ' do begin x:=x+1; end;
             c:=a[x];
               assign(g,'assemb.txt');
               append(g);
               writeln(g,call_text);
               writeln(g,'    mov   SUM,',c);
               close(g);
             end;
     end;  {eof}
  assign(g,'assemb.txt');
               append(g);
               writeln(g,'end:');
               writeln(g,'.exit');
               writeln(g,'i:word');
               writeln(g,'f:word');
               writeln(g,'n:word');
               writeln(g,'.end A1');
               close(g);
end;

procedure compil.zz;
begin
if k[i]='@'then begin i:=i+2;inc(stroka_err);end;
end;

procedure compil.q;
begin
if (k[i]=#0)or(k[i+1]=#0) then begin k:=kk;i:=1;end;zz;
end;

var
com:compil;
begin
    com.lexema;
end.