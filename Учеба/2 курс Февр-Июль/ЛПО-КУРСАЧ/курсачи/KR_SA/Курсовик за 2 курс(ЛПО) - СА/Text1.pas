program k;
label 1;
var
 n,f,i:integer;
begin
 read(n);
 f:=1;
 i:=1;
1:f:=f*i;
 i:=i+1;
 if i<n then goto 1;
 write(f);
end.