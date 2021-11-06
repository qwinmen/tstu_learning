uses crt,dos;

{ Работа с полной палитрой }
Type pPal=record
      r,g,b:byte;
end;

Var originalpal:array[0..255] of pPal;

{Сохранение палитры}
Procedure SGetPal(Start: byte; Anz: word; pal: pointer); assembler;
asm
  les di,pal
  mov al,start
  mov dx,3c7h
  out dx,al
  inc dx
  mov ax,anz
  mov cx,ax
  add cx,ax
  add cx,ax

  mov dx,3c9h
  cld
  rep insb
end;

{Восстановление сохраненной палитры}
Procedure SSetPal(Start: byte; Anz: word; pal: pointer); assembler;
asm
  push ds
  cld
  lds si,pal
  mov dx,3c8h
  mov al,start
  out dx,al
  inc dx
  mov ax,anz
  mov cx,ax
  add cx,ax
  add cx,ax
  rep outsb
  pop ds
end;



{Установка произвольной палитры для цвета "col"}
Procedure SetPal(col,r,g,b:byte);assembler;
asm
        mov dx,3c8h
        mov al,col
        out dx,al
        mov dx,3c9h
        mov al,r
        out dx,al
        mov al,g
        out dx,al
        mov al,b
        out dx,al
end;

{Плавное гашение (True) и восстановление (False) экрана}
Procedure FadePal(FadeOut : Boolean);
Var
  r,g,b   : byte;
  Fade    : word;
  Pct     : real;
  I       : byte;
begin
  For Fade := 0 to 19 do begin
    Pct := Fade / 19;
    If FadeOut then Pct := 1 - Pct;
    For I := 0 to 255 do begin
      r := Round(OriginalPal[I].R * Pct);
      g := Round(OriginalPal[I].G * Pct);
      b := Round(OriginalPal[I].B * Pct);
      asm
        mov dx,3c8h
        mov al,i
        out dx,al
        mov dx,3c9h
        mov al,r
        out dx,al
        mov al,g
        out dx,al
        mov al,b
        out dx,al
      end;
    end;
    delay(30);
  end;
end;



begin { Мэйн. МЭЙ !  МЭ-Э-Э-Й !!! }
  ClrScr;
  randomize;
  SGetPal(0,255,@originalpal);
  writeln('');
  writeln('Эта программа ( курсач  ;) состряпана Студентом первого курса : Шантар В.В.');
  writeln('При помощи его же ( Ш.В.В. ;) интерфейса ~Water~');
  writeln('(Который писАлся 3 суток в отличие от 4х часов за которые написан этот');
  writeln(' #@$%!^ курсач ;)');
  writeln('');
  writeln(' Жмем <Enter> - а когда все погаснет, жмем еще раз!');
  Readln;

  FadePal(true); {Плавное гашение палитры}

  Readln;

  FadePal(False); {Плавное восстановление палитры}

  writeln('');
  writeln(' Ну, вот и восстановили :-)');
  writeln('');
  writeln(' Теперь жмем <Enter> - и видим переливание цветов палитры!');
  Readln;

  ClrScr;
  writeln('                      )_(');
  writeln('                     (@ @)');
  writeln('╔═════════════════ooO═(_)─Ooo────────────────────────────────────────────┐');
  writeln('│   ┌─┐ ┌┐┌┐ ┌─┬─┐ ┌─┐ ┬─┐                 [ Team Daemon''s Hedgehog ]    │');
  writeln('│ <<├─┤ │└┘│   │   │ │ ├┬┘ ┌┐┌┐┌┐┌┐  >>     {2:5054/666.66@Fidonet  }    │');
  writeln('│   ╩ ╩ ╩  ╩   ╩   ╚═╝ ╩╚═ └─┴┴┴─┼┴ *       Real Name : Виктор Шантар    │');
  writeln('└───────────────────────────────────────────────═════════════════════════╝');
  writeln('         /   /');
  writeln('      \\()   \/_/');
  writeln('    \\\\ @_. /');
  writeln('   \\\\   /`/         { Hа все , здесь продемонстрированное , наложен БАЛШОЙ ');
  writeln('   \\\\ ||-<            CopyRight.  Увижу свои измышления не в своих программ-');
  writeln('   \\\\ ^//             ах БУДУ СИЛЬО ВОЗМУЩАТЬСЯ и пинать (если прийдется) }');
  writeln('  <--/|_|_                                     Perm''96');
  writeln('                     Origin :  ~Умирают свирепые ежики...~');
  writeln(' Когда мельтешение надоест - Жмем <Enter> - и демонстрация завершается!');

  FadePal(false);
  repeat
    SetPal(7,random(64),random(64),random(64));
    delay(5);
  until keypressed;

  SSetPal(0,255,@originalpal);

end.
