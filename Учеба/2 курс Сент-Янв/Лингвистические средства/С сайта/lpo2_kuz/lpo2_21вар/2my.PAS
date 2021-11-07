uses crt;
var f,ff:text;
    t,i,j,c:integer;
    ch:char;
    st,sp:string;
procedure error;
          begin
            writeln(t,' ERROR!');
            halt
            end;
procedure  read_id;
           begin
             st:='';
             for i:=1 to 2 do read(f,ch);
             while ch<>' ' do
                    begin
                     read(f,ch);
                     st:=st+ch
                     end;
             for i:=length(st) to 10 do st:=st+' ';
             end;
procedure prisv;
          begin
           for i:=1 to 3  do read(f,ch);
            read(f,t);
            if t<>6 then error;
            read(f,t);
            if t<>11 then error;
            read(f,ch);

            repeat
              read(f,ch);
             until ch=' ';
            read(f,t);
            if t<>7 then error;
            read(f,t);
            if t<>4 then error;
            read(f,t);
            if t<>11 then error;
            read(f,ch);

            repeat
              read(f,ch);
             until ch=' ';
            read(f,t);
            if t<>8 then error;
            read(f,t);
            if t<>12 then error;
            read(f,ch);

            repeat
              read(f,ch);
             until ch=' ';
            read(f,t);
            if t<>5 then error;
            read(f,t);
            if t<>9 then error;
            read(f,t);
            if t<>11 then error;
            read(f,ch);
              read(f,ch);
            read(f,ch);
            end;
procedure iff1;
          begin
            read(f,t);
            if t<>10 then error;
            read(f,t);
            if t<>12 then error;
            read(f,ch);
            repeat
              read(f,ch);
             until ch=' ';
            read(f,t);
            if t<>5 then error;
            read(f,t);
            if t<>11 then error;
            read(f,ch);
            repeat
              read(f,ch);
             until ch=' ';
            read(f,t);
            if t<>6 then error;
            read(f,t);
            if t<>11 then error;
            read(f,ch);
            repeat
              read(f,ch);
             until ch=' ';
            read(f,t);
            if t<>9 then error;
            read(f,t);
            if t<>11 then error;
            read(f,ch);
            read(f,ch);
              read(f,ch);
            end;
procedure iff2;
          begin
            read(f,t);
            if t<>10 then error;
            read(f,t);
            if t<>12 then error;
            read(f,ch);
            repeat
              read(f,ch);
             until ch=' ';
            read(f,t);
            if t<>5 then error;
            read(f,t);
            if t<>11 then error;
            read(f,ch);
            repeat
              read(f,ch);
             until ch=' ';
            read(f,t);
            if t<>6 then error;
            read(f,t);
            if t<>12 then error;
            read(f,ch);
            repeat
              read(f,ch);
             until ch=' ';
            read(f,t);
            if t<>9 then error;
            read(f,t);
            if t<>11 then error;
            read(f,ch);
            read(f,ch);
              read(f,ch);
            end;
procedure prisv_;
          var s:array [1..6] of string;
          begin
            read_id;
            s[1]:=st;
            for i:=1 to 4 do read(f,ch);
            read_id;
            s[2]:=st;
            for i:=1 to 6 do read(f,ch);
            read_id;
            s[3]:=st;
            for i:=1 to 4 do read(f,ch);
            read_id;
            s[4]:=st;
            for i:=1 to 6 do read(f,ch);
            read_id;
            s[5]:=st;
            clrscr;
            writeln(ff,'-          ',s[3],'#',s[4],'i',c);
            write(ff,'*          ','i',c,'         ',s[5]);inc(c);
            writeln(ff,' i',c);
            write(ff,'+          ',s[2],'i',c);inc(c);
            writeln(ff,'          i',c);
            writeln(ff,':=         i',c,'                      ',s[1]);
            c:=c+1;
            end;
procedure iff1_;
          var s:array [1..10] of string;
          g,simbol:char;
          begin
            s[1]:=ch;
            read_id;
            s[2]:=st;
            for i:=1 to 10 do read(f,ch);
            read_id;
            s[3]:=st;
            for i:=1 to 4 do read(f,ch);
            read_id;
            s[4]:=st;
            writeln(ff,'>          ',s[4],'#',s[2],'10)');
            for i:=1 to 8 do read(f,ch);
            end;
procedure iff2_;
          var s:array [1..10] of string;
          g,simbol:char;
          begin
            s[1]:=ch;
            read_id;
            s[2]:=st;
            for i:=1 to 10 do read(f,ch);
            read_id;
            s[3]:=st;
            for i:=1 to 4 do read(f,ch);
            read_id;
            s[4]:=st;
            for i:=1 to 4 do read(f,ch);
            read_id;
            s[5]:=st;
            c:=3;
            writeln(ff,'<          ',s[5],'#',s[2],'8)');
            write(ff,'*          #',s[4],s[5]);inc(c);
            writeln(ff,'i',c);
            writeln(ff,'=          i',c,'                     ',s[3]);inc(c);
            write(ff,'*          ',s[5],s[3]);
            writeln(ff,' i',c);
            writeln(ff,'=          i',c,'                     ',s[3]);
            end;
begin
  ClrScr;
  assign(f,'21.txt');
  reset(f);
  assign(ff,'22.txt');
  rewrite(ff);
sp:='        ';
  repeat
    read(f,t);
    case t of
      1:begin
      for i:=1 to 13 do read(f,ch);
        case ch of
         '2':iff1;
         '3':iff2;
         end;
        end;
      11 :prisv;
      end;
    read(f,ch);
    if (ch<>' ')and(not eof(f)) then error
   until eof(f);
c:=1;
 reset(f);
  repeat
read(f,t);
    case t of
      1:begin
      for i:=1 to 13 do read(f,ch);
        case ch of
         '2':iff1_;
         '3':iff2_;
         end;
        end;
      11 :prisv_;
      end
   until eof(f);
  close(f);
  close (ff);
  end.