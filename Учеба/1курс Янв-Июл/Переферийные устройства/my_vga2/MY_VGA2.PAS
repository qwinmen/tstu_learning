UNIT MY_VGA2;
interface
  Procedure SetMode(Mode:word);
  Procedure PutPixel(x,y:word;c:byte);
  Function  GetPixel(x,y:word):word;
  Procedure Bar(x1,y1,x2,y2:word;c:byte);
  Procedure HLine(x1,x2,y:word;c:byte);
  Procedure VLine(x,y1,y2:word;c:byte);
  Procedure Rectangle(x1,y1,x2,y2:word;c:byte);
  Procedure GetImage(x1,y1,x2,y2:word;var A);
  Procedure PutImage(x,y:word;var A);
  Procedure PutImageF(x,y:word;var A);

  Procedure GetImageFromImage(x1,y1,x2,y2:word;var Src,Dest);
  Procedure PutImageToImage(x,y:word;var Src,Dest);
  Procedure PutImageToImageF(x,y:word;var Src,Dest);

  Function  ImageSize(x1,y1,x2,y2:word):word;
  Procedure SetColor(colnum,red,green,blue:byte);
  Procedure GetColor(colnum:byte;var red,green,blue:byte);
  Procedure Line(x1,y1,x2,y2:word; n:byte);
  Procedure WaitVR;
  Procedure LoadPal(FileName:string);
  Procedure SetPal(seg_table,off_table:word);
  Procedure OutTextXY(x,y:word;s:string;c,h:byte;seg_tab,off_tab:word);
  Procedure Set4pixel(ARGn:word);
  Procedure Ellipse(ARGxc,ARGyc,ARGa,ARGb:word; ARGn:byte);
{---------------- }
implementation
  uses crt,dos;
{---------------- }

Procedure SetMode(Mode:word);assembler;
asm
  mov ax,Mode
  int 10h
end;
{--------------- }

Procedure PutPixel(x,y:word;c:byte);assembler;
asm
  mov ax,y
  mov bx,x
  mov dx,0A000h
  mov es,dx
  mov dx,320
  mul dx
  add bx,ax
  mov al,c
  mov es:[bx],al
end;
(* -------- *)
Function GetPixel(x,y:word):word;assembler;
asm
  mov ax,y
  mov bx,x
  mov dx,0A000h
  mov es,dx
  mov dx,320
  mul dx
  add bx,ax
  xor ah,ah
  mov al,es:[bx]
end;
(* -------- *)
Procedure Bar(x1,y1,x2,y2:word;c:byte);assembler;
asm
 mov  ax,320
 mul  y1
 mov  di,x1
 add  di,ax
 mov  ax,0A000h
 mov  es,ax

 mov  cx,x2
 sub  cx,x1
 inc  cx
 mov  si,cx
 mov  bx,320
 sub  bx,cx

 mov  dx,y2
 sub  dx,y1
 inc  dx
 mov  al,c
 cld
@Go:
 rep     stosb
 mov  cx,si
 add  di,bx
 dec  dx
 jnz  @Go
end;
(* -------- *)
Procedure HLine(x1,x2,y:word;c:byte);assembler;
asm
     mov ax,320
     mul y
     add ax,x1

     mov di,ax
     mov ax,0A000h
     mov es,ax

     mov cx,x2
     sub cx,x1
     inc cx
     mov al,c
     cld
rep  stosb
end;
(* -------- *)
Procedure VLine(x,y1,y2:word;c:byte);assembler;
asm
     mov ax,320
     mul y1
     add ax,x

     mov bx,ax
     mov ax,0A000h
     mov es,ax

     mov cx,y2
     sub cx,y1
     inc cx
     mov al,c
     cld
@go: mov es:[bx],al
     add bx,320
     loop @go
end;
(* -------- *)
Procedure Rectangle(x1,y1,x2,y2:word;c:byte);
begin
     HLine(x1,x2,y1,c);
     HLine(x1,x2,y2,c);
     VLine(x1,y1,y2,c);
     VLine(x2,y1,y2,c);
end;
(* -------- *)
Procedure GetImage(x1,y1,x2,y2:word;var A);assembler;
asm
        push ds
        mov  ax,320
        mul  y1
        mov  si,x1
        add  si,ax
        mov  ax,0A000h
        mov  ds,ax

        les  di,A
        cld
        mov  cx,x2
        sub  cx,x1
        inc  cx
        mov  ax,cx
        stosw

        mov  dx,y2
        sub  dx,y1
        inc  dx
        mov  ax,dx
        stosw

        mov  bx,320
        sub  bx,cx

        mov  ax,cx
@Go:
rep     movsb
        mov  cx,ax
        add  si,bx
        dec  dx
        jnz  @Go

        pop  ds
end;
(* -------- *)
Procedure PutImage(x,y:word;var A);assembler;
asm
        push ds
        mov  ax,320
        mul  y
        mov  di,x
        add  di,ax
        mov  ax,0A000h
        mov  es,ax

        lds  si,A
        cld
        lodsw
        mov  cx,ax
        lodsw
        mov  dx,ax

        mov  bx,320
        sub  bx,cx

        mov  ax,cx
@Go:
rep     movsb
        mov  cx,ax
        add  di,bx
        dec  dx
        jnz  @Go

        pop  ds
end;
(* -------- *)
Procedure PutImageF(x,y:word;var A);assembler;
asm
        push ds
        push bp
        mov  ax,320
        mul  y
        mov  di,x
        add  di,ax
        mov  ax,0A000h
        mov  es,ax

        lds  si,A
        cld
        lodsw
        mov  cx,ax
        lodsw
        mov  dx,ax

        mov  bx,320
        sub  bx,cx

        mov  bp,cx
@Go:    lodsb
        cmp  al,0
        jne  @store
        inc  di
        loop @Go
        jmp  @done
@store: stosb
        loop @Go
@done:  mov  cx,bp
        add  di,bx
        dec  dx
        jnz  @Go

        pop  bp
        pop  ds
end;
(* -------- *)
Function ImageSize(x1,y1,x2,y2:word):word;
begin
     ImageSize:=(abs(x2-x1)+1)*(abs(y2-y1)+1)+4;
end;
(* -------- *)
Procedure GetImageFromImage(x1,y1,x2,y2:word;var Src,Dest);assembler;
asm
        push ds
        cli

        les  di,Dest
        mov  cx,x2
        sub  cx,x1
        inc  cx               (* Dest Image Width -> CX *)
        mov  ax,cx
        stosw                 (* Dest Image Width *)

        lds  si,Src
        lodsw                 (* Src Image Width -> AX *)
        mov  bx,ax            (* Src Image Width -> BX *)
        sub  bx,cx

        mul  y1
        add  ax,x1
        add  ax,2
        add  si,ax            (* Start Adr *)

        mov  dx,y2
        sub  dx,y1
        inc  dx
        mov  ax,dx
        stosw                 (* Dest Image Height *)

        mov  ax,cx
@Go:
rep     movsb
        mov  cx,ax
        add  si,bx
        dec  dx
        jnz  @Go

        pop  ds
end;
(* -------- *)
Procedure PutImageToImage(x,y:word;var Src,Dest);assembler;
asm
        push ds
        cli

        les  di,Dest
        mov  ax,es:[di]      (* Dest Image Width -> AX *)
        mov  bx,ax
        mul  y
        add  ax,4
        add  ax,x
        add  di,ax

        lds  si,Src
        lodsw
        mov  cx,ax            (* Src Image Width ->CX *)
        sub  bx,cx
        lodsw
        mov  dx,ax            (* Src Image Height ->DX *)

        mov  ax,cx
@Go:
rep     movsb
        mov  cx,ax
        add  di,bx
        dec  dx
        jnz  @Go

        pop  ds
end;
(* -------- *)
Procedure PutImageToImageF(x,y:word;var Src,Dest);assembler;
asm
        push ds
        push bp
        cli

        les  di,Dest
        mov  ax,es:[di]      (* Dest Image Width -> AX *)
        mov  bx,ax
        mul  y
        add  ax,4
        add  ax,x
        add  di,ax

        lds  si,Src
        lodsw
        mov  cx,ax            (* Src Image Width ->CX *)
        sub  bx,cx
        lodsw
        mov  dx,ax            (* Src Image Height ->DX *)

        mov  bp,cx

@Go:    lodsb
        cmp  ax,0
        jne  @store
        inc  di
        loop @Go
        jmp  @done
@store: stosb
        loop @Go
@done:  mov  cx,bp
        add  di,bx
        dec  dx
        jnz  @Go

        pop  bp
        pop  ds
end;
{-------------}
Procedure SetColor(colnum,red,green,blue:byte);assembler;
asm
     mov ax,1010h
     mov bl,colnum
     xor bh,bh
     mov dh,red
     mov ch,green
     mov cl,blue
     int 10h
end;
{-------------}
Procedure GetColor(colnum:byte;var red,green,blue:byte);
var rr,gg,bb:byte;
begin
     asm
        mov ax,1015h
        mov bl,colnum
        xor bh,bh
        int 10h
        mov rr,dh
        mov gg,ch
        mov bb,cl
     end;
     red:=rr;green:=gg;blue:=bb;
end;
{-----------------------------------------------}
Procedure Line(x1,y1,x2,y2:word; n:byte);
var
  VARincr1,VARincr2,VARroutine : word;
begin
  asm
     {; check for vertical line}
                mov  dx,0A000h
                mov  es,dx
                mov  dx,320

		mov	si,320   	{; initial y-increment}
		mov	cx,x2
		sub	cx,x1	{; CX := x2 - x1}
		jz	@VertLine13	{; jump if vertical line}

    {; force x1 < x2}

		jns	@L01		{; jump if x2 > x1}
		neg	cx		{; CX := x1 - x2     }
		mov	bx,x2	{; exchange x1 and x2}
		xchg	bx,x1
		mov	x2,bx
		mov	bx,y2	{; exchange y1 and y2}
		xchg	bx,y1
		mov	y2,bx

    {; calculate dy = ABS(y2-y1)}

@L01:		mov	bx,y2
		sub	bx,y1	{; BX := y2 - y1      }
		jz	@HorizLine13	{; jump if horizontal line   }
		jns	@L03		{; jump if slope is positive }
		neg	bx		{; BX := y1 - y2             }
		neg	si		{; negate y-increment        }

      {; select appropriate routine for slope of line}

@L03:		push	si		{; preserve y-increment}
		mov	VARroutine,offset @LoSlopeLine13
		cmp	bx,cx
		jle	@L04		{; jump if dy <= dx (slope <= 1)}
		mov	VARroutine,offset @HiSlopeLine13
		xchg	bx,cx		{; exchange dy and dx}

      {; calculate initial decision variable and increments          }

@L04:		shl	bx,1		{; BX := 2 * dy              }
		mov	VARincr1,bx	{; incr1 := 2 * dy           }
		sub	bx,cx
		mov	si,bx		{; SI := d = 2 * dy - dx     }
		sub	bx,cx
		mov	VARincr2,bx	{; incr2 := 2 * (dy - dx)    }

    {; calculate first pixel address}

		mov	ax,y1	{; AX := y                   }
		mov	bx,x1	{; BX := x                   }

      mul dx
      add bx,ax

		mov	di,bx		{; ES:DI -> buffer           }
		inc	cx		{; CX := # of pixels to draw }
		pop	bx		{; BX := y-increment         }
		jmp	VARroutine	{ jump to appropriate routine for slope}


      {; routine for vertical lines}

@VertLine13:	mov	ax,y1	{ AX := y1                   }
		mov	bx,y2	{ BX := y2                   }
		mov	cx,bx
		sub	cx,ax	{ CX := dy                   }
		jge	@L31	{ jump if dy >= 0            }
		neg	cx	{ force dy >= 0              }
		mov	ax,bx	{ AX := y2                   }

@L31:		inc	cx	{ CX := # of pixels to draw  }
		mov	bx,x1	{ BX := x                    }

      mul dx
      add bx,ax

		mov	di,bx	{ ES:DI -> video buffer      }
		dec	si	{ SI := bytes/line - 1       }
		mov	al,n	{ AL := pixel value          }
@L32:		stosb		{ set pixel value in buffer  }
		add	di,si	{ increment to next line     }
		loop	@L32
		jmp	@Lexit

   { routine for horizontal lines (slope = 0)}

@HorizLine13:
		mov	ax,y1
		mov	bx,x1

      mul dx
      add bx,ax

		mov	di,bx		{ ES:DI -> buffer               }
		inc	cx		{ CX := number of pixels to draw}
		mov	al,n		{ AL := pixel value             }
		rep	stosb		{ update the video buffer       }
		jmp	@Lexit


   {; routine for dy <= dx (slope <= 1)	  ES:DI -> video buffer         }
					{ BX = y-increment              }
					{ CX = # pixels to draw         }
					{ SI = decision variable        }
@LoSlopeLine13:

		mov	al,n		{ AL := pixel value             }
@L11:		stosb			{ store pixel, increment x      }
		or	si,si		{ test sign of d                }
		jns	@L12		{ jump if d >= 0                }
		add	si,VARincr1	{ d := d + incr1                }
		loop	@L11
		jmp	@Lexit
@L12:		add	si,VARincr2	{ d := d + incr2                }
		add	di,bx		{ increment y                   }
		loop	@L11
		jmp	@Lexit

{; routine for dy > dx (slope > 1)	  ES:DI -> video buffer         }
					{ BX = y-increment              }
					{ CX = # pixels to draw         }
					{ SI = decision variable        }
@HiSlopeLine13:
		mov	al,n		{ AL := pixel value             }
@L21:		stosb			{ update next pixel, increment x}
		add	di,bx		{ increment y                   }
@L22:		or	si,si		{ test sign of d                }
		jns	@L23		{ jump if d >= 0                }
		add	si,VARincr1	{ d := d + incr1                }
		dec	di		{ decrement x (already incremented}
					{  by stosb)                      }
		loop	@L21
		jmp	@Lexit
@L23:		add	si,VARincr2	{ d := d + incr2                  }
		loop	@L21
@Lexit:
end;         { asm  }
end;         { line }
{-------------------------------------}
Procedure WaitVR; assembler;
asm
    cli
    mov  dx,3dah
 @L1:
    in    al,dx
    and   al,08h
    jnz   @L1
 @L2:
    in    al,dx
    and   al,08h
    jz    @L2
    sti
end;
{------------------------------------}
Procedure LoadPal(FileName : string);

var
  numread: word;
  colar : array [0..767] of byte;
  Fil : file ;
  pp :  pointer;
begin
  assign(fil,FileName);
  reset(fil);
  blockread(fil,colar,sizeof(colar),numread);
  close(fil);
  pp:=@colar[0];
  asm
    push  es
    les   dx,pp
    mov   ax,1012h
    mov   bx,0
    mov   cx,000ffh
    int   10h
    pop   es
  end;
end;
{------------------------------------}
Procedure SetPal(seg_table,off_table:word);assembler;
  asm
    push  ds
    push  es
    xor   ax,ax
    mov   es,ax
    mov   dx,es:[463h]
    add   dx,6
    pop   es

    in    al,dx
    test  al,08h
    jz    @wait_on
 @wait_off:
    in    al,dx
    test  al,08h
    jnz   @wait_off
 @wait_on:
    in    al,dx
    test  al,08h
    jz    @wait_on
    mov   dx,3c8h
    mov   ax,0
    out   dx,al
    mov   ax,seg_table
    mov   ds,ax
    mov   si,off_table
    mov   cx,300h
    mov   dx,3c9h
    cld
 @get_reg:
    lodsb
    out   dx,al
    loop  @get_reg
    pop  ds

end;
(* ------------------------------------------------------------------------ *)
Procedure OutTextXY(x,y:word;s:string;c,h:byte;seg_tab,off_tab:word);
var
  i,cb,off_t : word;
begin
  for i:=1 to ord(s[0]) do
  begin
    cb:=ord(s[i]);
    off_t:=off_tab+cb*h;
    asm
      mov  ax,y
      mov  bx,x
      mov  dx,0a000h
      mov  es,dx
      mov  dx,320
      mul  dx
      add  bx,ax    {ES:BX -> Video Buffer}

      mov  dx,seg_tab
      mov  ds,dx
      mov  si,off_t {DS:SI -> start of character}

      mov  ah,c
      mov  cx,0
      mov  cl,h

@L10: push cx
      mov  cx,8
      lodsb
@L11: shl  al,1
      jnc  @L12

      mov  es:[bx],ah
@L12: inc  bx
      loop @L11
      add  bx,312
      pop  cx
      loop @L10

    end;
    x:=x+8;
  end;
end;
{~~~~~~~~~~~~~~~~~~~~~}
Procedure Set4pixel(ARGn:word);assembler;
asm

   push bx
   push cx

   sub	si,cx
   sub	di,bx   {x0,y0}

   mov  dx,320
   mov	ax,di
   mul	dx
   add	ax,si     {offset xy0}
   shl  cx,1

   push ax
   push bx
   mov  dx,argn
   mov  bx,ax
   mov  es:[bx],dl
   add  bx,cx
   mov  es:[bx],dl

   pop  bx
   mov  ax,640
   mul	bx
   pop  bx
   add  bx,ax
   mov  dx,argn
   mov  es:[bx],dl
   add  bx,cx
   mov  es:[bx],dl

   pop     cx
   pop     bx
end;
{~~~~~~~~~~}

Procedure Ellipse(ARGxc,ARGyc,ARGa,ARGb:word; ARGn:byte);assembler;

var
VARd,vd,VARdx,vdx,VARdy,vdy,Asquared,aa,
Bsquared,bb,TwoAsquared,ta,TwoBsquared,tb :word;


asm

{; initial constants}

                mov     ax,0a000h
                mov     es,ax

		mov	ax,ARGa
		mul	ax
		mov	Asquared,ax
		mov	Asquared+2,dx	 { a^2}
		shl	ax,1
		rcl	dx,1
		mov	TwoAsquared,ax
		mov	TwoAsquared+2,dx { 2*a^2}

		mov	ax,ARGb
		mul	ax
		mov	Bsquared,ax
		mov	Bsquared+2,dx	 { b^2   }
		shl	ax,1
		rcl	dx,1
		mov	TwoBsquared,ax
		mov	TwoBsquared+2,dx { 2*b^2}


{ initial decision variables       }

		xor	ax,ax
		mov	VARdx,ax
		mov	VARdx+2,ax	{ dx = 0                          }

		mov	ax,TwoAsquared
		mov	dx,TwoAsquared+2
		mov	cx,ARGb
       	push	ax		{; preserve u2                         }
        mov	ax,dx		{; AX :=                               }
	mul	cx		{; AX := high-order word of result     }
	xchg	ax,cx		{; AX := v1, CX := high-order word     }
	pop	dx		{; DX := u2                            }
	mul	dx		{; AX := low-order word of result      }
				{; DX := carry                         }
	add	dx,cx		{; CX := high-order word of result     }
		mov	VARdy,ax
		mov	VARdy+2,dx	{ dy = TwoAsquared * b             }

		mov	ax,Asquared
		mov	dx,Asquared+2	{ DX:AX = Asquared                 }
		sar	dx,1
		rcr	ax,1
		sar	dx,1
		rcr	ax,1		{ DX:AX = Asquared/4               }

		add	ax,Bsquared
		adc	dx,Bsquared+2	{ DX:AX = Bsquared + Asquared/4    }
		mov	VARd,ax
		mov	VARd+2,dx

		mov	ax,Asquared
		mov	dx,Asquared+2
		mov	cx,ARGb
       	push	ax		{; preserve u2                         }
        mov	ax,dx		{; AX :=                               }
	mul	cx		{; AX := high-order word of result     }
	xchg	ax,cx		{; AX := v1, CX := high-order word     }
	pop	dx		{; DX := u2                            }
	mul	dx		{; AX := low-order word of result      }
				{; DX := carry                         }
	add	dx,cx		{; CX := high-order word of result     }
		sub	VARd,ax
		sbb	VARd+2,dx	{ d = Bsquared - Asquared*b + Asquared/4}

{ loop until dy/dx >= -1}

		mov	bx,ARGb		{ BX := initial y-coordinate}

		xor	cx,cx		{ CH := 0 (initial y-increment)}
					{ CL := 0 (initial x-increment)}
@L10:		mov	ax,VARdx
		mov	dx,VARdx+2
		sub	ax,VARdy
		sbb	dx,VARdy+2
		jns	@L20		{ jump if dx>=dy                }


                mov     si,argxc
                mov     di,argyc
                mov     al,argn
                push    ax
                call    set4pixel


		cmp	VARd+2,0
		js	@L11		{ jump if d < 0                 }

		dec	bx		{ decrement current y-coordinate}

		mov	ax,VARdy
		mov	dx,VARdy+2
		sub	ax,TwoAsquared
		sbb	dx,TwoAsquared+2 { DX:AX := dy - TwoAsquared    }
		mov	VARdy,ax
		mov	VARdy+2,dx	{ dy -= TwoAsquared             }

		sub	VARd,ax
		sbb	VARd+2,dx	{ d -= dy                       }

@L11:		mov	ax,VARdx
		mov	dx,VARdx+2
		add	ax,TwoBsquared
		adc	dx,TwoBsquared+2 { DX:AX := dx + TwoBsquared    }
		mov	VARdx,ax
		mov	VARdx+2,dx	{ dx += TwoBsquared             }

		add	ax,Bsquared
		adc	dx,Bsquared+2	{ DX:AX := dx + Bsquared       }
		add	VARd,ax
		adc	VARd+2,dx	{ d += dx + Bsquared           }
                inc     cx              {iiooii}

		jmp	@L10
{
{ plot pixels from current (x,y) until y < 0
{

{ initial buffer address and bit mask                                  }

@L20:		push	bx		{ preserve current y-coordinate}
		push	cx		{ preserve x- and y-increments }

		mov	ax,Asquared
		mov	dx,Asquared+2
		sub	ax,Bsquared
		sbb	dx,Bsquared+2	{ DX:AX := Asquared-Bsquared   }

		mov	bx,ax
		mov	cx,dx		{ CX:BX := (Asquared-Bsquared) }

		sar	dx,1
		rcr	ax,1		{ DX:AX := (Asquared-Bsquared)/2}
		add	ax,bx
		adc	dx,cx		{ DX:AX := 3*(Asquared-Bsquared)/2}

		sub	ax,VARdx
		sbb	dx,VARdx+2
		sub	ax,VARdy
		sbb	dx,VARdy+2	{ DX:AX := 3*(Asquared-Bsquared)/2 - (dx+dy)}

		sar	dx,1
		rcr	ax,1		{ DX:AX :=                        }
					{  ( 3*(Asquared-Bsquared)/2 - (dx+dy) )/2}
		add	VARd,ax
		adc	VARd+2,dx	{ update d                        }

{ loop until y < 0}

		pop	cx		{ CH,CL := y- and x-increments    }
		pop	bx		{ BX := y                         }

@L21:
                mov     si,argxc
                mov     di,argyc
                mov     al,argn
                push    ax
                call    set4pixel

		cmp	VARd+2,0
		jns	@L22		{ jump if d >= 0                  }


		mov	ax,VARdx
		mov	dx,VARdx+2
		add	ax,TwoBsquared
		adc	dx,TwoBsquared+2 { DX:AX := dx + TwoBsquared      }
		mov	VARdx,ax
		mov	VARdx+2,dx	{ dx += TwoBsquared               }

		add	VARd,ax
		adc	VARd+2,dx	{ d += dx                         }
                inc     cx              {IOIOIOIO}

@L22:		mov	ax,VARdy
		mov	dx,VARdy+2
		sub	ax,TwoAsquared
		sbb	dx,TwoAsquared+2 { DX:AX := dy - TwoAsquared     }
		mov	VARdy,ax
		mov	VARdy+2,dx	{ dy -= TwoAsquared              }

		sub	ax,Asquared
		sbb	dx,Asquared+2	{ DX:AX := dy - Asquared         }
		sub	VARd,ax
		sbb	VARd+2,dx	{ d += Asquared - dy             }

		dec	bx		{ decrement y                    }
		jns	@L21		{ loop if y >= 0                 }


{ restore default Graphics Controller registers                          }

@Lexit:

end;

{~~~~~~~~~~~~~~~~~~~~~~~~~~~}
function TestVGA:word;assembler;
asm
   mov ax,$1A00
   int $10
   cmp bl,$07
   jl @NotVGA
   mov ax,$0000
   jmp @Exit
@NotVGA:
   mov ax, $FFFF
@Exit:
end;


{---------------------------------}
BEGIN
END.
{---------------------------------}

