Unit Memory;

(* YOU MUST SET "HEAPMIN" AND "HEAPMAX" TO ZERO IN YOUR PROGRAM *)
(*    IF YOU WANT TO USE THESE FUNCTIONS. I.E. WRITE IN YOUR    *)
(*   PROGRAM: {$M STACKSIZE,0,0}. DEFAULT "STACKSIZE" = 16384   *)

Interface

Function MemMaxAvail : LongInt;
{ Returns size of the largest free memory block }

Function MemAlloc (Size : LongInt) : Pointer;
{ Allocates Size bytes of memory and returns pointer to allocated block }

Procedure MemFree (P : Pointer);
{ Deallocates allocated memory block; P is pointer to this block }

Implementation

Function MemMaxAvail : LongInt; Assembler;
Asm
  Mov   BX, 0FFFFh                              { BX = maximum paragraphs }
  Mov   AH, 48h                                 { AH = 48h - function number }
  Int   21h
  Mov   AX, 10h
  Mul   BX                                      { * MaxAvail }
End;

Function MemAlloc (Size : LongInt) : Pointer; Assembler;
Asm
  Mov   AX, Word Ptr Size
  Mov   DX, Word Ptr Size+2
  Test  AX, 0Fh
  JZ    @@1                                     { If whole paragraphs }
  Add   AX, 10h
  Adc   DX, 0
@@1:
  Mov   BX, 10h
  Div   BX
  Mov   BX, AX                                  { BX = size in paragraphs }
  Mov   AH, 48h                                 { AH = 48h - function number }
  Int   21h
  JNC   @@ok                                    { If no error }
  Xor   DX, DX
  Xor   AX, AX                                  { Nil if error }
  Jmp   @@done
@@ok:
  Mov   DX, AX                                  { DX = segment }
  Xor   AX, AX                                  { AX = offset = 0 }
@@done:
End;

Procedure MemFree (P : Pointer); Assembler;
Asm
  Mov   ES, Word Ptr P+2                        { ES = segment to free }
  Mov   AH, 49h                                 { AH = 49h - function number }
  Int   21h
End;

End.
