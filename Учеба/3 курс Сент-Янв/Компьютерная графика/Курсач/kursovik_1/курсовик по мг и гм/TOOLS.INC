{=========================================================================}
{ TOOLS.INC                                                  ASY/VBE 1.20 }
{ Same useful rountines (keyboard, strings...)                            }
{=========================================================================}
{ Copyright (C) 1997,98 ASY                                               }
{ Coded by ASY (Andrey Samoilov)                                          }
{=========================================================================}

{=========================================================================}
{ Keyboard }

Const
  kbEsc       = $011B;  kbAltSpace  = $0200;  kbCtrlIns   = $0400;
  kbShiftIns  = $0500;  kbCtrlDel   = $0600;  kbShiftDel  = $0700;
  kbBack      = $0E08;  kbCtrlBack  = $0E7F;  kbShiftTab  = $0F00;
  kbTab       = $0F09;  kbAltQ      = $1000;  kbAltW      = $1100;
  kbAltE      = $1200;  kbAltR      = $1300;  kbAltT      = $1400;
  kbAltY      = $1500;  kbAltU      = $1600;  kbAltI      = $1700;
  kbAltO      = $1800;  kbAltP      = $1900;  kbCtrlEnter = $1C0A;
  kbEnter     = $1C0D;  kbAltA      = $1E00;  kbAltS      = $1F00;
  kbAltD      = $2000;  kbAltF      = $2100;  kbAltG      = $2200;
  kbAltH      = $2300;  kbAltJ      = $2400;  kbAltK      = $2500;
  kbAltL      = $2600;  kbAltZ      = $2C00;  kbAltX      = $2D00;
  kbAltC      = $2E00;  kbAltV      = $2F00;  kbAltB      = $3000;
  kbAltN      = $3100;  kbAltM      = $3200;  kbF1        = $3B00;
  kbF2        = $3C00;  kbF3        = $3D00;  kbF4        = $3E00;
  kbF5        = $3F00;  kbF6        = $4000;  kbF7        = $4100;
  kbF8        = $4200;  kbF9        = $4300;  kbF10       = $4400;
  kbHome      = $4700;  kbUp        = $4800;  kbPgUp      = $4900;
  kbGrayMinus = $4A2D;  kbLeft      = $4B00;  kbRight     = $4D00;
  kbGrayPlus  = $4E2B;  kbEnd       = $4F00;  kbDown      = $5000;
  kbPgDn      = $5100;  kbIns       = $5200;  kbDel       = $5300;
  kbShiftF1   = $5400;  kbShiftF2   = $5500;  kbShiftF3   = $5600;
  kbShiftF4   = $5700;  kbShiftF5   = $5800;  kbShiftF6   = $5900;
  kbShiftF7   = $5A00;  kbShiftF8   = $5B00;  kbShiftF9   = $5C00;
  kbShiftF10  = $5D00;  kbCtrlF1    = $5E00;  kbCtrlF2    = $5F00;
  kbCtrlF3    = $6000;  kbCtrlF4    = $6100;  kbCtrlF5    = $6200;
  kbCtrlF6    = $6300;  kbCtrlF7    = $6400;  kbCtrlF8    = $6500;
  kbCtrlF9    = $6600;  kbCtrlF10   = $6700;  kbAltF1     = $6800;
  kbAltF2     = $6900;  kbAltF3     = $6A00;  kbAltF4     = $6B00;
  kbAltF5     = $6C00;  kbAltF6     = $6D00;  kbAltF7     = $6E00;
  kbAltF8     = $6F00;  kbAltF9     = $7000;  kbAltF10    = $7100;
  kbCtrlPrtSc = $7200;  kbCtrlLeft  = $7300;  kbCtrlRight = $7400;
  kbCtrlEnd   = $7500;  kbCtrlPgDn  = $7600;  kbCtrlHome  = $7700;
  kbAlt1      = $7800;  kbAlt2      = $7900;  kbAlt3      = $7A00;
  kbAlt4      = $7B00;  kbAlt5      = $7C00;  kbAlt6      = $7D00;
  kbAlt7      = $7E00;  kbAlt8      = $7F00;  kbAlt9      = $8000;
  kbAlt0      = $8100;  kbAltMinus  = $8200;  kbAltEqual  = $8300;
  kbCtrlPgUp  = $8400;  kbAltBack   = $0800;  kbNoKey     = $0000;
  kbSpace     = $3920;

  kb1        = $0231;   kb2        = $0332;   kb3        = $0433;
  kb4        = $0534;   kb5        = $0635;   kb6        = $0736;
  kb7        = $0837;   kb8        = $0938;   kb9        = $0A39;
  kb0        = $0B30;   kbQ        = $1071;

  kbRightShift  = $0001;
  kbLeftShift   = $0002;
  kbCtrlShift   = $0004;
  kbAltShift    = $0008;
  kbScrollState = $0010;
  kbNumState    = $0020;
  kbCapsState   = $0040;
  kbInsState    = $0080;

var
  ShiftState    : Byte absolute $40:$17;

Function KeyHit:Boolean; assembler;
asm
        mov     ax,00040h
        mov     es,ax
        mov     bx,es:[0001Ah]
        xor     ax,ax
        cmp     bx,es:[0001Ch]
        jz      @@Done
        inc     ax
@@Done:
end;

Function KeyGet:Word; assembler;
asm
        xor     ax,ax
        int     16h
end;

Procedure ClearKeyBuffer; assembler;
asm
@@Loop: mov     ah,1
        int     16h
        jz      @end

        xor     ax,ax
        int     16h
        jmp     @@Loop
@end:
end;

Function GetShiftState:Byte; assembler;
asm
        MOV     ES,Seg0040
        MOV     AL,ES:ShiftState
end;

Function ShiftPressed:Boolean;
begin
  ShiftPressed := GetShiftState and (kbRightShift + kbLeftShift) <> 0;
end;

{=========================================================================}
{ Strings }

Const hexChars: array [0..$F] of Char = '0123456789ABCDEF';

Function StrHex(AValue:Byte):String;
begin
  StrHex := hexChars[AValue shr 4] + hexChars[AValue and $F];
end;

Function StrWHex(AValue:Word):String;
begin
  StrWHex := hexChars[Hi(AValue) shr 4] + hexChars[Hi(AValue) and $F] +
             hexChars[Lo(AValue) shr 4] + hexChars[Lo(AValue) and $F];
end;

Function StrReal(AValue:Real;Width,Digits:Byte):String;
var S : String;
begin
  Str(AValue:Width:Digits,S);
  StrReal := S;
end;

Function StrInt(AValue:Longint;Width:Byte):String;
var S : String;
begin
  Str(AValue:Width,S);
  StrInt := S;
end;
