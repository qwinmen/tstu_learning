Unit Dos_int;

Interface
 type
  dosseg=record
  ESSeg : word;
  DSSEG : word;
 end;
 var
  segs : dosseg;

Procedure DOSint(IntN:byte);

Implementation
Procedure DOSint(IntN:byte);assembler;
asm
  push dword ptr 0
  lea esp, [esp-8]
  push segs
  pushf
   pushad
   mov edi, esp
   mov ax, 0300h
   xor cx, cx
   movzx ebx, IntN
   int 31h
   popad
  popf
  pop segs
  lea esp, [esp+12]
end;


END.