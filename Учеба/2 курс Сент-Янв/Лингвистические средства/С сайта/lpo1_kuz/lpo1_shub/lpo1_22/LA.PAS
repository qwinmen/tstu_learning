Program LA;
uses crt;
var str,slovo,kod,sravn:string;
    ish,tablica,kodfile:text;
    i,j:integer;
begin
clrscr;
assign(ish,'ishalf.txt');
reset(ish);
assign(tablica,'tablalf.txt');
assign(kodfile,'kodalf.txt');
rewrite(kodfile);

repeat
 readln(ish,str);
 for i:=1 to length(str) do       begin
  reset(tablica);
repeat
  readln(tablica,slovo);
  readln(tablica,kod);
  if str[i]=slovo[1] then
    for j:=i to i+length(slovo)-1 do
      sravn:=sravn+str[j];
      if sravn=slovo     then     begin
         write(kodfile,kod,' ');
         write(kod,' ');
         i:=i+length(slovo)-1;     end;

      sravn:='';
until eof(tablica);
 end;
 writeln;
until eof(ish);
close(ish);
close(tablica);
close(kodfile);
end.