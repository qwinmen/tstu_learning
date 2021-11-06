Unit Vesa_as;

Interface
 type
     CType=array[0..255]of char;
     CPtr=^CType;
     WType=array[0..255]of word;
     WPtr=^WType;
     VesaInfoBlock = record
       VESASignature : array[0..3]of char;
       VESAVersion : word;
       OEMStringPtr : CPtr;
       Capabilities : dword;
       VideoModePtr : WPtr;
       TotalMemory : word;
       Reserved : array[0..235]of byte;
     END;

       ModeInfoBlock = record
         ModeAttributes : word;
         WinAAttributes : byte;
         WinBAttributes : byte;
         WinGranularity : word;
         WinSize : word;
         WinASegment : word;
         WinBSegment : word;
         WinFuncPtr : pointer;
         BytesPerScanLine : word;
         XResolution : word;
         YResolution : word;
         XCharSize : byte;
         YCharSize : byte;
         NumberOfPlanes : byte;
         BitsPerPixel : byte;
         NumberOfBanks : byte;
         MemoryModel : byte;
         BankSize : byte;
         NumberOfImagePages : byte;
         ReservedPage : byte;
         RedMaskSize : byte;
         RedFieldPosition : byte;
         GreenMaskSize : byte;
         GreenFieldPosition : byte;
         BlueMaskSize : byte;
         BlueFieldPosition : byte;
         RsvdMaskSize : byte;
         RsvdFieldPosition : byte;
         DirectColorModeInfo : byte;
         PhysBasePtr : dword;
         OffScreenMemOffset : pointer;
         OffScreenMemSize : word;
         Reserved : array[0..205]of byte;
       END;

function GetVESAInfo(var Buffer: VesaInfoBlock):boolean;
function GetModeInfo(Mode:word; Buffer:pointer):boolean;
function SetVESAMode(Mode:word):boolean;
{-}function SetVESABank(Bank,Window:word):boolean;
function SetVESALenLine(var PLength,BLength,NLines: dword):boolean;
function SetVESAStart(XStart,YStart:word):boolean;
{+}function LinAddr(PhysAddr: dword; SizeBlock: dword):dword;

Implementation
Uses LOW_MEM, DOS_INT;
function GetVESAInfo(var Buffer: VesaInfoBlock):boolean;
 var
  Seg, Sel:word;
  RetCode:word;
  SizeBl:dword;
  begin
  SizeBl:=256;
  GetLowMem(Seg,Sel,SizeBl);
  segs.ESSeg:=Seg;
   asm
   push edi
    mov eax, $4f00
    mov edi, 0
    push dword ptr $10
    call DosInt
    mov RetCode, ax
   pop edi
   end;
  if RetCode=$004F then begin
     move(Mem[Seg*16],Buffer,256);
     GetVESAInfo:=TRUE;
    with buffer do begin
        VideoModePtr:=pointer(( (dword(VideoModePtr)and $FFFF0000) shr 12)
        +(dword(VideoModePtr)and $FFFF) );
        OEMStringPtr:=pointer(( (dword(OEMStringPtr)and $FFFF0000) shr 12)
        +(dword(OEMStringPtr)and $FFFF) );
    end;
  end;
end;

function GetModeInfo(Mode:word; Buffer:pointer):boolean;
var
 Seg,Sel:word;
 RetCode:word;
 SizeBl:dword;
 begin
  SizeBl:=256;
  GetLowMem(Seg,Sel,SizeBl);
  segs.ESSeg:=Seg;
  asm
  push ecx
    push edi
    mov eax, $4f01
    mov cx, mode
    mov edi, 0
     push dword ptr $10
    call DosInt
    mov RetCode, ax
    pop edi
  pop ecx
  end;
 if RetCode=$004F then begin
    move(Mem[Seg*16],Buffer^,256);
  GetModeInfo:=TRUE;
  end else GetModeInfo:=FALSE;
  FreeLowMem(Sel);{Уничтожаем временый Буфер}
 end;

 function SetVESAMode(Mode:word):boolean;
 var RetCode:word;
  begin
   asm
   mov ax, $4f02
   mov bx, mode
   int $10
   mov RetCode, ax
   end;
   SetVESAMode:=RetCode=$004f;
  end;

const NumBank: integer=-1;
function SetVESABank(Bank,Window:word):boolean;
var RetCode:word;
 begin
  if Bank=NumBank then
  SetVESABank:=TRUE
  else begin
  asm
  mov ax, $4f05
  mov bx, Window
  mov dx, Bank
  int $10
  mov RetCode, ax
  end;
   if RetCode=$004f then begin
     SetVESABank:=TRUE;
     NumBank:=Bank;
   end
    else SetVESABank:=FALSE;
   end;
     end;

function SetVESALenLine(var PLength,BLength,NLines:dword):boolean;
var RetCode:word;
 begin
  asm
  push di
    push bx
      push cx
        push dx
        mov ax, $4f06
        mov edi, PLength
        mov cx, [edi]
        xor bx, bx
        int $10
        mov edi, PLength
        mov [edi], cx
        mov edi, BLength
        mov [edi], bx
        mov edi, NLines
        mov [edi], dx
        mov RetCode, ax
        pop dx
      pop cx
    pop bx
  pop di
  end;
  SetVESALenLine:=RetCode=$004f;
 end;

 function LinAddr(PhysAddr:dword; SizeBlock:dword):dword;
 var LinAddr2:dword;
 begin
  if PhysAddr>$100000 then begin
     asm
      push ebx
        push ecx
        mov cx, word ptr PhysAddr
        mov bx, word ptr PhysAddr+2
        mov di, word ptr SizeBlock
        mov si, word ptr SizeBlock+2
        mov ax, $800
        int $31
        mov word ptr LinAddr2, cx
        mov word ptr LinAddr2+2, bx
        pop ecx
      pop ebx
     end;
     LinAddr:=LinAddr2;
  end else LinAddr:=$FFFFFFFF;
 end;

 function SetVESAStart(XStart,YStart:word):boolean;
 var RetCode:word;
  begin
   asm
   mov ax, $4f07
   xor bx, bx
   mov cx, XStart
   mov dx, YStart
   int $10
   mov RetCode, ax
   end;
   SetVESAStart:=RetCode=$004f;
  end;





End.