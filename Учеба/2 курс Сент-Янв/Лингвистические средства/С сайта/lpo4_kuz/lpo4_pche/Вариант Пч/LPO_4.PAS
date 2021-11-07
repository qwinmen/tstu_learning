 const
  TablSize=8;
  HashSize=6;
  k: byte =0;
 type
  Zap= record
   name : string;
   _type: string;
   chain: byte
  end;
 var
  VarTabl   : array[1..TablSize] of Zap;
  HashTabl  : array[1..HashSize] of byte;
  err       : array[1..TablSize+2] of byte;
  f_in,f_out: text;
  i,j,n     : byte;
  str,t,id  : string;
 {------}
 function hash(a: string): byte;
 var sum: word;
 begin
  sum := 0;
  for j:= 1 to ord(a[0]) do sum:= sum+ord(a[j]);
  hash:= sum mod HashSize+1
 end;
 {-------}
 procedure insert;
 begin
  i:= hash(id); n:= i; j:= HashTabl[i];
  for i:= 1 to TablSize do if VarTabl[i].name='' then break;
  if j<>0 then begin
   while (VarTabl[j].chain<>0) and (VarTabl[j].name<>id) do j:= VarTabl[j].chain;
   if VarTabl[j].name=id then begin err[k]:= j; exit end;
   VarTabl[j].chain:= i
  end
  else HashTabl[n]:= i;
  VarTabl[i]._type:= t;
  VarTabl[i].chain:= 0;
  VarTabl[i].name := id
 end;
 {---}
 begin
  assign(f_in,'in.txt');
  reset(f_in);
  while not SeekEOF(f_in) do
  begin
   inc(k);
   readln(f_in,str); n:= length(str)-1;
   t := '';
   for i:= 1 to n do if str[i]=':' then begin
    for j:= i+1 to n do t:= t+str[j];
    break
   end;
   i:= 1; id:='';
   while str[i]<>':' do begin
    id:= id+str[i];
    inc(i)
   end;
   insert
  end;
  close(f_in);
  assign(f_out,'out.txt');
  rewrite(f_out);
  n:= 0;
  for i:= 1 to k do
   if err[i]<>0 then with VarTabl[err[i]] do
    WriteLn(f_out,'№',i,#9,'Ошибка: идентификатор ',name,' уже объявлен')
   else begin
    inc(n);
    with VarTabl[n] do
     WriteLn(f_out,'№',i,#9,'hash=',hash(name),#9,'ID=',name,#9,'Type=',_type,#9,'Chain=',chain)
   end;
  close(f_out)
 end.