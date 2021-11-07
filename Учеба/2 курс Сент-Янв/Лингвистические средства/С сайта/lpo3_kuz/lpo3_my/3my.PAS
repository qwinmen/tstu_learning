uses crt;

var st:array[1..20] of string;
    k:string;
    ch:char;
    f,ff:text;
    c,p,i:integer;

procedure mul;
          begin
            writeln(ff,#9,'mov   ',st[p-2],',r1');
            writeln(ff,#9,'mov   ',st[p-1],',r0');
            writeln(ff,#9,'mul   r0,r1');
            writeln(ff,#9,'mov   r1,var',c);
            str(c,k);
            st[p-2]:='var'+k;
            p:=p-1;
            c:=c+1
            end;

procedure add;
          begin
            writeln(ff,#9,'clr   r0');
            writeln(ff,#9,'add   ',st[p-2],',r1');
            writeln(ff,#9,'add   ',st[p-1],',r1');
            writeln(ff,#9,'mov   r1,var',c);
            str(c,k);
            st[p-2]:='var'+k;
            p:=p-1;
            c:=c+1
            end;

procedure sub;
          begin
            writeln(ff,#9,'clr   r0');
            writeln(ff,#9,'mov   ',st[p-2],',r1');
            writeln(ff,#9,'sub   ',st[p-1],',r1');
            writeln(ff,#9,'mov   r1,var',c);
            str(c,k);
            st[p-2]:='var'+k;
            p:=p-1;
            c:=c+1
            end;

procedure del;
          begin
            writeln(ff,#9,'mov   ',st[p-2],',r1');
            writeln(ff,#9,'mov   ',st[p-1],',r0');
            writeln(ff,#9,'div   r0,r1');
            writeln(ff,#9,'mov   r1,var',c);
            str(c,k);
            st[p-2]:='var'+k;
            p:=p-1;
            c:=c+1
            end;

procedure move;
          begin
            writeln(ff,#9,'mov   ',st[p-2],',',st[p-1]);
            end;

begin
  assign(f,'21.txt');
  reset(f);
  assign(ff,'22.txt');
  rewrite(ff);
  writeln(ff,#9,'.MCALL, .EXIT');
  writeln(ff,'START:');

  p:=1;
  c:=1;
  repeat
    read(f,ch);
    case ch of
     '*' : mul;
     '/' : del;
     '+' : add;
     '-' : sub;
     ':' : move;
     else begin
            st[p]:=ch;
            p:=p+1
            end
     end
   until ch=':';
  writeln(ff,'x:word');
  writeln(ff,'y:word');
  writeln(ff,'z:word');
  for i:=1 to c-1 do writeln(ff,#9,'var',i,':word');
  close(f);
  close(ff);
  end.