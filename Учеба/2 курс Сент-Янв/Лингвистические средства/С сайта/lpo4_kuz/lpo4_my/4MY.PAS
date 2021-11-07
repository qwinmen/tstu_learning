uses crt;

type _type_ = record
	   name:   string;
	   tip:    string;
	   cepochka:  byte;
end;

var tabl:         array[1..18] of _type_;
    tablhash:     array[1..6] of integer;
    f, t:         text;
    i, j:         byte;
    str, _a, id:  string;

function hash(a: string): byte;
    var i:   byte;
    	rez: integer;
    begin
      rez:= 0;
      for i:= 1 to ord(a[0]) do rez:= rez+ord(a[i]);
      hash:= (rez mod 6)+1;
      end;

procedure insert(s: string);
     var curhash: byte;
         i, j:    integer;
     begin
       curhash:= hash(s);
       for i:=1 to 6 do
       if tabl[i].name='' then
          begin
            tabl[i].name:=s;
            tabl[i].tip:=_a;
            tabl[i].cepochka:=0;
            if tablhash[curhash] = 0 then
            tablhash[curhash]:= i
            else
              begin
                j:= tablhash[curhash];
                while tabl[j].cepochka <> 0 do j:= tabl[j].cepochka;
                tabl[j].cepochka:= i;
                end;
            break;
         end;
  end;

begin
  assign(f,'41.txt');
  reset(f);
  readln(f);
  while not (seekeof(f)) do
        begin
          _a:='';
          readln(f,str);
          for i:= ord(str[0]) downto 1 do
              begin
                if str[i]=':' then
                   begin
                     for j:= i+1 to ord(str[0]) do _a:=_a+str[j];
                     break;
                     end;
                end;
          i:=0;
          while (str[i]<>':') do
                begin
                  inc(i);
                  id:='';
                  while not(str[i] in [':',',']) do
                        begin
                          id:= id+str[i];
                          inc(i);
                          end;
          insert(id);
          end;
       end;
begin
  assign(t,'42.txt');
  rewrite(t);
  writeln(t,'nn',#9,'Хеш',#9,'Имя',#9,'Тип','                 ','Цепочка');
  for i:=1 to 6 do
  with tabl[i] do
  writeln(t,i,#9,hash(name),#9,name,#9,tip,'                  ',cepochka);
  close(t);
  end;
end.

