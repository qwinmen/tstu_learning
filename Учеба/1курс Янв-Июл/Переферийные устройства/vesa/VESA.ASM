.386

FALSE   EQU     0
TRUE    EQU     1

Locals  @@

@Push	Macro	RegList
	IRP	Reg, <RegList>
		Push	Reg
	EndM
EndM

@Pop	Macro	RegList
	IRP	Reg, <RegList>
		Pop	Reg
	EndM
EndM

@SgnAbs Macro
Local   @@lend
        Mov     BX, AX
        JZ      @@lend
        Mov     AX, 1
        JNC     @@lend
        Neg     AX
        Neg     BX
@@lend:
EndM

@ChangeGran Macro DataSegment:=<DS>
Local @@lend
        Mov     DataSegment:_Granule, DX
        Xor     BX, BX
        Mov     AX, 4F05h
        Int     10h
        Mov     AX, 4F05h
        Inc     BL
        Int     10h
@@lend:
EndM

Extrn   SegA000, SelectorInc : Word, _YOffs : DWord, TranspColor : Byte
Extrn   GetMaxX, GetMaxY, _Granularity, _Granule, _GMask:Word, _GShift:Byte
Extrn   _PFont : DWord, _FontL, _FontH, _FontHS : Word

Public  Putpixel, GetPixel, LineH, LineV, Box, Line, ClearScreen
Public  OutString
Public  GetImage, PutImage, PutTranspImage, ImageSize, LSqrt

Code    Segment Byte Public Use16
        Assume CS:Code

PutPixel Proc Pascal Far        X : Word, Y : Word, Color : Byte
        Mov     SI, Y
        ShL     SI, 2
        Add     SI, Offset _YOffs
        Mov     ESI, DS:[SI]
        MovZX   EDI, X
        Add     EDI, ESI
        Mov     EDX, EDI
        Mov     CL, DS:_GShift
        ShR     EDX, CL
        And     DI, DS:_GMask
        Cmp     DX, DS:_Granule
        JE      @@lplot
        @ChangeGran <>
@@lplot:
        Mov     ES, DS:SegA000
        Mov     AL, Color
        STOSB
        Ret
PutPixel EndP

GetPixel Proc Pascal Far        X : Word, Y : Word
        Mov     SI, Y
        ShL     SI, 2
        Add     SI, Offset _YOffs
        Mov     ESI, DS:[SI]
        MovZX   EDI, X
        Add     EDI, ESI
        Mov     EDX, EDI
        Mov     CL, DS:_GShift
        ShR     EDX, CL
        And     DI, DS:_GMask
        Cmp     DX, DS:_Granule
        JE      @@lplot
        @ChangeGran <>
@@lplot:
        Mov     ES, DS:SegA000
        Mov     AL, ES:[DI]
        Ret
GetPixel EndP

LineH   Proc Pascal Far         X : Word, Y : Word, L : Word, Color : Byte
        Mov     SI, Y
        ShL     SI, 2
        Add     SI, Offset _YOffs
        Mov     ESI, DS:[SI]
        MovZX   EDI, X
        Add     EDI, ESI                ;EDI = physical offset of 1-st pixel
        Mov     EDX, EDI
        Mov     CL, DS:_GShift
        ShR     EDX, CL                 ;DX = 1-st pixel granule
        And     DI, DS:_GMask
        Cmp     DX, DS:_Granule
        JE      @@lprepared
        @ChangeGran <>
@@lprepared:
        CLD
        Mov     ES, DS:SegA000
        Mov     AL, Color
        Mov     AH, AL
        Mov     CX, L
        JCXZ    @@lend
        Mov     SI, DI
        Dec     CX
        Add     SI, CX
        JC      @@lsplited
        Inc     CX
@@llast:ShR     CX, 1
        Rep     STOSW
        JNC     @@lend
        STOSB
@@lend:
        Ret
@@lsplited:
        Inc     CX
        Inc     SI
        Sub     CX, SI
        ShR     CX, 1
        Rep     STOSW
        JNC     @@lsecond
        STOSB
@@lsecond:
        Mov     CX, AX
        Add     DX, DS:_Granularity
        @ChangeGran <>
        Mov     AX, CX
        Mov     CX, SI
        Xor     DI, DI
        Jmp     @@llast
LineH   EndP

LineV   Proc Pascal Far         X : Word, Y : Word, H : Word, Color : Byte
        Mov     SI, Y
        ShL     SI, 2
        Add     SI, Offset _YOffs
        Mov     ESI, DS:[SI]
        MovZX   EDI, X
        Add     EDI, ESI                ;EDI = physical offset of 1-st pixel
        Mov     EDX, EDI
        Mov     CL, DS:_GShift
        ShR     EDX, CL                 ;DX = 1-st pixel granule
        And     DI, DS:_GMask
        Cmp     DX, DS:_Granule
        JE      @@lprepared
        @ChangeGran <>
@@lprepared:
        Mov     ES, DS:SegA000
        Mov     AL, Color
        Mov     CX, H
        JCXZ    @@lend
        Mov     SI, Word Ptr DS:_YOffs[4]
@@cycle:
        Mov     ES:[DI], AL
        Add     DI, SI
        JNC     @@lnochange
        Add     DX, DS:_Granularity
        @ChangeGran <>
        Mov     AL, Color
@@lnochange:
        Loop    @@cycle
@@lend:
        Ret
LineV   EndP

Box     Proc Pascal Far         X, Y, L, H : Word, Color, Fill : Byte
        Cmp     Fill, TRUE
        JE      @@lfilled
        @Push   <X, Y, L, Color>
        Call    LineH
        Mov     AX, X
        Add     AX, L
        Dec     AX
        @Push   <AX, Y, H, Color>
        Call    LineV
        Mov     AX, Y
        Add     AX, H
        Dec     AX
        @Push   <X, AX, L, Color>
        Call    LineH
        @Push   <X, Y, H, Color>
        Call    LineV
        Jmp     @@lend
@@lfilled:
        Mov     CX, H
@@cycle:
        @Push   <CX, X, Y, L, Color>
        Call    LineH
        Pop     CX
        Inc     Y
        Loop    @@cycle
@@lend:
        Ret
Box     EndP

Line    Proc Pascal Far         X1:Word,Y1:Word,X2:Word,Y2:Word,Color:Byte
Local   M:Word, N:Word, DX1:Word, DY1:Word, DX2:Word, DY2:Word
        Mov     AX, X2
        Sub     AX, X1
        @SgnAbs
        Mov     DX1, AX
        Mov     M, BX
        Mov     AX, Y2
        Sub     AX, Y1
        @SgnAbs
        Mov     DY1, AX
        Mov     N, BX
        Mov     AX, DX1
        Mov     DX2, AX
        Mov     DY2, 0
        Mov     AX, M
        Cmp     AX, N
        JNC     @@lprepared
        Xchg    AX, M
        Xchg    N, AX
        Xchg    AX, M
        Mov     AX, DY1
        Mov     DY2, AX
        Mov     DX2, 0
@@lprepared:
        Mov     CX, M
        Inc     CX
        Xor     DX, DX
        Mov     SI, X1
        Mov     DI, Y1
        Mov     AL, Color
@@cycle:
        PushA
        @Push    <SI, DI, AX>
        Call    PutPixel
        PopA
        Add     DX, N
        Cmp     DX, M
        JNC     @@ld1
        Add     SI, DX2
        Add     DI, DY2
        Jmp     @@llooping
@@ld1:
        Sub     DX, M
        Add     SI, DX1
        Add     DI, DY1
@@llooping:
        Loop    @@cycle
        Ret
Line    EndP

ClearScreen Proc Pascal Far     Color : Byte
        Xor     CX, CX
        Mov     AX, GetMaxX
        Inc     AX
@@cycle:
        @Push   <AX, CX, 0, CX, AX, Word Ptr Color>
        Call    LineH
        @Pop    <CX, AX>
        Inc     CX
        Cmp     CX, GetMaxY
        JBE     @@cycle
        Ret
ClearScreen EndP

LSqrt   Proc Pascal Far         X : DWord
        Mov     EAX, X
        Or      EAX, EAX
        JZ      @@LDone
        Cmp     EAX, 1
        JE      @@LDone
        Mov     ECX, EAX
        Mov     EBX, EAX
        ShR     EBX, 1
        Mov     ESI, EBX
@@LNext:
        Xor     EDX, EDX
        Mov     EAX, ECX
        Div     EBX
        Add     EAX, EBX
        ShR     EAX, 1
        Cmp     EAX, EBX
        JE      @@LDone2
        Cmp     EAX, ESI
        JE      @@LDone2
        Mov     ESI, EBX
        Mov     EBX, EAX
        Jmp     @@LNext
@@LDone2:
        Mov     EAX, ESI
        Cmp     ESI, EBX
        JC      @@LDone
        Mov     EAX, EBX
@@LDone:
        Mov     EDX, EAX
        ShR     EDX, 16
        Ret
LSqrt   EndP

GetImage Proc Pascal Far        X:Word, Y:Word, L:Word, H:Word, BitMap:DWord
        Mov     AX, L
        Or      AX, AX
        JZ      @@lend
        Mov     AX, H
        Or      AX, AX
        JZ      @@lend
        CLD
        LES     DI, BitMap
        Mov     AX, L
        STOSW
        Mov     AX, H
        STOSW
        Mov     SI, Y
        ShL     SI, 2
        Add     SI, Offset _YOffs
        Mov     ESI, DS:[SI]
        MovZX   EAX, X
        Add     ESI, EAX
        Mov     EDX, ESI
        Mov     CL, DS:_GShift
        ShR     EDX, CL
        And     SI, DS:_GMask
        Cmp     DX, DS:_Granule
        JE      @@lplot
        @ChangeGran <>
@@lplot:
        Push    DS
        Pop     FS
        Mov     DS, DS:SegA000
@@cycle:
        Mov     CX, L
        Call    GetLine
        Dec     H
        JZ      @@lend2
        Mov     AX, FS:GetMaxX
        Inc     AX
        Sub     AX, L
        Add     SI, AX
        JNC     @@cycle
        Add     DX, FS:_Granularity
        @ChangeGran <FS>
        Jmp     @@cycle
@@lend2:
        Push    FS
        Pop     DS
@@lend:
        Ret
GetImage EndP

GetLine Proc Near
@@cycle:Cmp     SI, DI
        RCL     AL, 1           ;AL0 = SI < DI
        Cmp     SI, DI
        JC      @@1
        Mov     BX, SI
        Jmp     @@2
@@1:    Mov     BX, DI
@@2:    Neg     BX
        JZ      @@llast
        Cmp     BX, CX
        JNC     @@llast
        Xchg    BX, CX
        Sub     BX, CX
        ShR     CX, 1
        Rep     MOVSW
        JNC     @@3
        MOVSB
@@3:    Xchg    BX, CX
        Cmp     SI, DI
        JE      @@lboth
        RCR     AL, 1
        JC      @@lselector
        Add     DX, FS:_Granularity
        @ChangeGran <FS>
        Jmp     @@cycle
@@lselector:
        Mov     AX, ES
        Add     AX, FS:SelectorInc
        Mov     ES, AX
        Jmp     @@cycle
@@lboth:
        Add     DX, FS:_Granularity
        @ChangeGran <FS>
        Mov     AX, ES
        Add     AX, FS:SelectorInc
        Mov     ES, AX
        Jmp     @@cycle
@@llast:ShR     CX, 1
        Rep     MOVSW
        JNC     @@4
        MOVSB
@@4:    Or      SI, SI
        JNZ     @@lend
        Add     DX, FS:_Granularity
        @ChangeGran <FS>
@@lend:
        Ret
GetLine EndP

PutImage Proc Pascal Far        X : Word, Y : Word, BitMap : DWord
Local   L : Word, H : Word
        CLD
        Push    DS
        LDS     SI, BitMap
        LODSW
        Mov     L, AX
        LODSW
        Mov     H, AX
        Pop     DS

        Mov     DI, Y
        ShL     DI, 2
        Add     DI, Offset _YOffs
        Mov     EDI, DS:[DI]
        MovZX   EAX, X
        Add     EDI, EAX
        Mov     EDX, EDI
        Mov     CL, DS:_GShift
        ShR     EDX, CL
        And     DI, DS:_GMask
        Cmp     DX, DS:_Granule
        JE      @@lplot
        @ChangeGran <>
@@lplot:
        Push    DS
        Pop     FS
        Mov     ES, DS:SegA000
        Mov     DS, Word Ptr BitMap+2
@@cycle:
        Mov     CX, L
        Call    PutLine
        Dec     H
        JZ      @@lend2
        Mov     AX, FS:GetMaxX
        Inc     AX
        Sub     AX, L
        Add     DI, AX
        JNC     @@cycle
        Add     DX, FS:_Granularity
        @ChangeGran <FS>
        Jmp     @@cycle
@@lend2:
        Push    FS
        Pop     DS
@@lend:
        Ret
PutImage EndP

PutLine Proc Near
@@cycle:Cmp     SI, DI
        RCL     AL, 1           ;AL0 = SI < DI
        Cmp     SI, DI
        JC      @@1
        Mov     BX, SI
        Jmp     @@2
@@1:    Mov     BX, DI
@@2:    Neg     BX
        JZ      @@llast
        Cmp     BX, CX
        JNC     @@llast
        Xchg    BX, CX
        Sub     BX, CX
        ShR     CX, 1
        Rep     MOVSW
        JNC     @@3
        MOVSB
@@3:    Xchg    BX, CX
        Cmp     SI, DI
        JE      @@lboth
        RCR     AL, 1
        JNC     @@lselector
        Add     DX, FS:_Granularity
        @ChangeGran <FS>
        Jmp     @@cycle
@@lselector:
        Mov     AX, DS
        Add     AX, FS:SelectorInc
        Mov     DS, AX
        Jmp     @@cycle
@@lboth:
        Add     DX, FS:_Granularity
        @ChangeGran <FS>
        Mov     AX, DS
        Add     AX, FS:SelectorInc
        Mov     DS, AX
        Jmp     @@cycle
@@llast:ShR     CX, 1
        Rep     MOVSW
        JNC     @@4
        MOVSB
@@4:    Or      DI, DI
        JNZ     @@lend
        Add     DX, FS:_Granularity
        @ChangeGran <FS>
@@lend:
        Ret
PutLine EndP

PutTranspImage Proc Pascal Far        X : Word, Y : Word, BitMap : DWord
Local   L : Word, H : Word
        CLD
        Push    DS
        LDS     SI, BitMap
        LODSW
        Mov     L, AX
        LODSW
        Mov     H, AX
        Pop     DS

        Mov     DI, Y
        ShL     DI, 2
        Add     DI, Offset _YOffs
        Mov     EDI, DS:[DI]
        MovZX   EAX, X
        Add     EDI, EAX
        Mov     EDX, EDI
        Mov     CL, DS:_GShift
        ShR     EDX, CL
        And     DI, DS:_GMask
        Cmp     DX, DS:_Granule
        JE      @@lplot
        @ChangeGran <>
@@lplot:
        Push    DS
        Pop     FS
        Mov     ES, DS:SegA000
        Mov     DS, Word Ptr BitMap+2
@@cycle:
        Mov     CX, L
        Call    PutTranspLine
        Dec     H
        JZ      @@lend2
        Mov     AX, FS:GetMaxX
        Inc     AX
        Sub     AX, L
        Add     DI, AX
        JNC     @@cycle
        Add     DX, FS:_Granularity
        @ChangeGran <FS>
        Jmp     @@cycle
@@lend2:
        Push    FS
        Pop     DS
@@lend:
        Ret
PutTranspImage EndP

PutTranspLine Proc Near
@@cycle:Cmp     SI, DI
        RCL     AL, 1           ;AL0 = SI < DI
        Cmp     SI, DI
        JC      @@1
        Mov     BX, SI
        Jmp     @@2
@@1:    Mov     BX, DI
@@2:    Neg     BX
        JZ      @@llast
        Cmp     BX, CX
        JNC     @@llast
        Xchg    BX, CX
        Sub     BX, CX
@@Mov1:
        Mov     AH, DS:[SI]
        Cmp     AH, FS:TranspColor
        JNE     @@Mov11
        Inc     SI
        Inc     DI
        Jmp     @@Mov12
@@Mov11:
        MOVSB
@@Mov12:
        Loop    @@Mov1
@@3:    Xchg    BX, CX
        Cmp     SI, DI
        JE      @@lboth
        RCR     AL, 1
        JNC     @@lselector
        Add     DX, FS:_Granularity
        @ChangeGran <FS>
        Jmp     @@cycle
@@lselector:
        Mov     AX, DS
        Add     AX, FS:SelectorInc
        Mov     DS, AX
        Jmp     @@cycle
@@lboth:
        Add     DX, FS:_Granularity
        @ChangeGran <FS>
        Mov     AX, DS
        Add     AX, FS:SelectorInc
        Mov     DS, AX
        Jmp     @@cycle
@@llast:
@@Mov2:
        Mov     AH, DS:[SI]
        Cmp     AH, FS:TranspColor
        JNE     @@Mov21
        Inc     SI
        Inc     DI
        Jmp     @@Mov22
@@Mov21:
        MOVSB
@@Mov22:
        Loop    @@Mov2
@@4:    Or      DI, DI
        JNZ     @@lend
        Add     DX, FS:_Granularity
        @ChangeGran <FS>
@@lend:
        Ret
PutTranspLine EndP

ImageSize Proc Pascal Far               L, H : Word
       MovZX    EAX, L
       MovZX    EBX, H
       Mul      EBX
       Add      EAX, 4
       Mov      EDX, EAX
       ShR      EDX, 16
       Ret
ImageSize EndP

OutChar Proc Pascal Near                X:Word, Y:Word, Char:Byte, Color:Byte
Local   XC : Byte, YC : Byte
        Mov     SI, Y
        ShL     SI, 2
        Add     SI, Offset _YOffs
        Mov     ESI, DS:[SI]
        MovZX   EDI, X
        Add     EDI, ESI
        Mov     EDX, EDI
        Mov     CL, DS:_GShift
        ShR     EDX, CL
        And     DI, DS:_GMask
        Cmp     DX, DS:_Granule
        JE      @@lprepared
        @ChangeGran <>
@@lprepared:
        Mov     ES, DS:SegA000
        LFS     SI, DS:_PFont
        Mov     AL, Byte Ptr Char
        Xor     AH, AH
        Mul     DS:_FontH
        Mov     CL, Byte Ptr DS:_FontHS
        Dec     CL
        ShL     AX, CL
        Add     SI, AX
        Mov     DX, DS:_Granule
        Mov     AL, Byte Ptr DS:_FontH
        Mov     YC, AL
@@CycleY:
        Mov     AL, Byte Ptr DS:_FontL
        Mov     XC, AL
        Mov     CX, FS:[SI]
        Xchg    CH, CL
@@CycleX:
        ShL     CX, 1
        JNC     @@LBlank
        Mov     AL, Color
        Mov     ES:[DI], AL
@@LBlank:
        Inc     DI
        JNZ     @@LOldGran1
        Add     DX, DS:_Granularity
        @ChangeGran <>
@@LOldGran1:
        Dec     XC
        JNZ     @@CycleX
        Add     SI, DS:_FontHS
        Mov     AX, DS:GetMaxX
        Inc     AX
        Sub     AX, DS:_FontL
        Add     DI, AX
        JNC     @@OldGran2
        Add     DX, DS:_Granularity
        @ChangeGran <>
@@OldGran2:
        Dec     YC
        JNZ     @@CycleY
        Ret
OutChar EndP

OutString Proc Pascal Far               X, Y : Word, aStr : DWord, C : Byte
Local   Len : Byte
        LGS     SI, aStr
        Mov     AL, GS:[SI]
        Or      AL, AL
        JZ      @@LEnd
        Mov     Len, AL
        Inc     SI
@@Cycle:
        Mov     AL, GS:[SI]
        @Push   <SI, X, Y, AX, Word Ptr C>
        Call    OutChar
        Pop     SI
        Inc     SI
        Mov     AX, X
        Add     AX, DS:_FontL
        Mov     X, AX
        Dec     Len
        JNZ     @@Cycle
@@LEnd:
        Ret
OutString EndP

Code    EndS

End
