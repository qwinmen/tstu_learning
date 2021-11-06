Unit LOW_MEM;

Interface
procedure GetLowMem(var LowSeg, LowSel:word;var Len:dword);
procedure FreeLowMem(LowSel:word);

Implementation
procedure GetLowMem(var LowSeg, LowSel:word;var Len:dword);
var j:word;
begin
 j:=(len+15)div 16;
  asm
   push ebx
   push edx
   mov ax, $0100
   mov bx, j
   int $31
 {  RCL CF, 1}

   mov edi, LowSel
   mov [edi], dx
   mov edi, LowSeg
   mov [edi], ax
   shl ebx, 4
   mov edi, Len
   mov [edi], ebx
   pop edx
   pop ebx
  end;
end;

procedure FreeLowMem(LowSel:word);
begin
 asm
  push edx
  mov ax, $0101
  mov dx, LowSel
  int $31
  pop edx
 end;
end;


END.

