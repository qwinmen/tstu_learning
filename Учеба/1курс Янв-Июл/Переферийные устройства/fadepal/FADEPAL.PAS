uses crt,dos;

{ ����� � ������ �����ன }
Type pPal=record
      r,g,b:byte;
end;

Var originalpal:array[0..255] of pPal;

{���࠭���� �������}
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

{����⠭������� ��࠭����� �������}
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



{��⠭���� �ந����쭮� ������� ��� 梥� "col"}
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

{������� ��襭�� (True) � ����⠭������� (False) ��࠭�}
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



begin { ����. ��� !  ��-�-�-� !!! }
  ClrScr;
  randomize;
  SGetPal(0,255,@originalpal);
  writeln('');
  writeln('�� �ணࠬ�� ( �����  ;) ����ﯠ�� ��㤥�⮬ ��ࢮ�� ���� : ����� �.�.');
  writeln('�� ����� ��� �� ( �.�.�. ;) ����䥩� ~Water~');
  writeln('(����� ��ါ�� 3 ��⮪ � �⫨稥 �� 4� �ᮢ �� ����� ����ᠭ ���');
  writeln(' #@$%!^ ����� ;)');
  writeln('');
  writeln(' ���� <Enter> - � ����� �� ����᭥�, ���� �� ࠧ!');
  Readln;

  FadePal(true); {������� ��襭�� �������}

  Readln;

  FadePal(False); {������� ����⠭������� �������}

  writeln('');
  writeln(' ��, ��� � ����⠭����� :-)');
  writeln('');
  writeln(' ������ ���� <Enter> - � ����� ��५������ 梥⮢ �������!');
  Readln;

  ClrScr;
  writeln('                      )_(');
  writeln('                     (@ @)');
  writeln('������������������ooO�(_)�Ooo�������������������������������������������Ŀ');
  writeln('�   �Ŀ ڿڿ ���Ŀ �Ŀ �Ŀ                 [ Team Daemon''s Hedgehog ]    �');
  writeln('� <<�Ĵ ��ٳ   �   � � ��� ڿڿڿڿ  >>     {2:5054/666.66@Fidonet  }    �');
  writeln('�   � � �  �   �   �ͼ ��� �������� *       Real Name : ����� �����    �');
  writeln('������������������������������������������������������������������������ͼ');
  writeln('         /   /');
  writeln('      \\()   \/_/');
  writeln('    \\\\ @_. /');
  writeln('   \\\\   /`/         { H� �� , ����� �த�������஢����� , ������� ������ ');
  writeln('   \\\\ ||-<            CopyRight.  ����� ᢮� ����諥��� �� � ᢮�� �ணࠬ�-');
  writeln('   \\\\ ^//             �� ���� ����� ����������� � ������ (�᫨ �਩�����) }');
  writeln('  <--/|_|_                                     Perm''96');
  writeln('                     Origin :  ~������ ᢨ९� �����...~');
  writeln(' ����� �����襭�� ������� - ���� <Enter> - � ���������� �����蠥���!');

  FadePal(false);
  repeat
    SetPal(7,random(64),random(64),random(64));
    delay(5);
  until keypressed;

  SSetPal(0,255,@originalpal);

end.
