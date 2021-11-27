unit k_b;
interface
{$I scancod.inc}
{Events}
function          EventKey:word;
function KeyDown(key:word):boolean;
function           ReadKey:char;
var
    StatShift:byte absolute $40:$17;

implementation
var
    b:byte;
    StatShift1:byte absolute $40:$18;

 function StatShiftDown(a:byte):boolean;
 begin
 StatShiftDown:=(StatShift and $0f)=a;
 end;


function EventKey;assembler;
asm
        in      al,60h{}
        mov     bh,al
        mov     ah,02h
        int     16h
        mov     ah,bh
        and     al,0fh
        mov     bx,ax
@@Loop: mov     ah,1
        int     16h
        jz      @end

        xor     ax,ax
        int     16h
        jmp     @@Loop
@end:
        mov     ax,bx
end;



function KeyDown;
begin
keyDown:=EventKey=key;
end;


function readkey;assembler;asm
    mov ah,0h
    int 16h
    cmp al,0h
 jz @end1
    jmp @end
@end1:
    int 16h
    mov al,ah
@end:
end;


Begin
End.