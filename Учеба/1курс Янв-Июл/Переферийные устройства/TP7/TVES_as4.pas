program TVES_as4;
uses crt,vesa_as;

var
 LenLineP:dword;
 LenLineB:dword;
 MaxLines:dword;
 LFBPtr:dword;{ÀÄÐÅÑ ÍÀ×ÀËÀ LFB}
procedure putpixel(X,Y,Color:dword);
{var bank,offs:word;{------------------------------------}
begin
 asm
 mov ebx, Y
 imul ebx, LenLineB
 add ebx, X
 mov eax, Color
 add ebx, LFBPtr
 mov [ebx], al
 end;
 {SetVESABank(bank,0);       {------------------------------}
 {Mem[$A000:offs]:=lo(Color); {-----------------------------}
end;

Procedure WaitRetrace;
begin
 while(Port[$3DA]and $08)=0 do;
end;
var
 i,j:dword;
 b1:VesaInfoBlock;
 b2:ModeInfoBlock;
 {NBanks:word;{---------------------------------------}
 begin
  if GetVesaInfo(b1) then begin
     for i:=0 to 3 do write(b1.VesaSignature[i]);
     write(', Ver ',hi(b1.VesaVersion), '.',lo(b1.VesaVersion));
     writeln(', ',b1.TotalMemory*64, 'Kb videoMemory on MBoard');
     i:=0;
     while b1.OEMStringPtr^[i] <> #0 do begin
        write(b1.OEMStringPtr^[i]);
        inc(i);
     end;
     writeln;
     i:=0;
     writeln('Modes:');
     while b1.VideoModePtr^[i] <> $FFFF do begin
       write(b1.VideoModePtr^[i],' ');
       inc(i);
     end;
     writeln;
  end else writeln('Error_0 VESAinfo');

  if GetModeInfo($103,@b2) then begin{GetModeInfo($4103,@b2)}
   writeln('Mode 103h, Granularity:',b2.WinGranularity, 'Kb, Window Size:',
  b2.WinSize, 'Kb, ',b2.XResolution, 'x', b2.YResolution, ', ',
  b2.BitsPerPixel,' bits per pixel');
    if(b2.ModeAttributes and $81)= $81 then begin
      LFBPtr:=LinAddr(b2.PhysBasePtr, b1.TotalMemory*65536);
    end else begin
      writeln('LFB not supported');
      halt;
    end;
{NBanks:=(b1.TotalMemory*64)div b2.WinGranularity;{-----------------------}
   end else writeln('Error_1 MODEinfo');
   readkey;

   if SetVesaMode($103) then begin{SetVesaMode($4103)}
      LenLineB:=b2.BytesPerScanLine;

      for i:=0 to b1.TotalMemory-1{NBanks-1} do {begin}
   {SetVesaBank(i,0);}
     fillchar(mem[LFBPtr+i*65536],65536,char(i+1));
{fillchar(mem[$A000:0],b2.WinGranularity*512,char(i+1));}
{fillchar(mem[$A000:b2.WinGranularity*512],b2.WinGranularity*512,char(i+1));}

  { end;}
      end else writeln('Error_2');
      readkey;

      for i:=0 to 199 do
   for j:=0 to 599 do PutPixel(j+i,j,j);
      readkey;
      LenLineP:=1024;

      SetVesaLenLine(LenLineP,LenLineB,MaxLines);
      readkey;

      for i:=0 to 199 do
   for j:=0 to 1023 do PutPixel(j+i,j,j);
      readkey;

      for i:=0 to (1023-800) do begin
      SetVesaStart(i,0);
      WaitRetrace;
      end;
      readkey;{+}

      for j:=0 to (1023-600) do begin
       SetVesaStart(i,j);
       WaitRetrace;
      end;
      readkey;

      asm
       mov ax, 3
       int $10
      end;


 end.