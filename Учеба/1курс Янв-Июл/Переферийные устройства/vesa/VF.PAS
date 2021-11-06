uses crt, vesa;

type
  tfont = record
    name : string[12];
    l, h : word
  end;

const
  fonts : array [1..9] of tfont = (
    (name:'6x7.fnt';l:6;h:7),
    (name:'6x8.fnt';l:6;h:8),
    (name:'8x8altm.fnt';l:8;h:8),
    (name:'8x14altm.fnt';l:8;h:14),
    (name:'8x15altm.fnt';l:8;h:15),
    (name:'8x16altm.fnt';l:8;h:16),
    (name:'9x16.fnt';l:9;h:16),
    (name:'16x16.fnt';l:16;h:16),
    (name:'16x32.fnt';l:16;h:32));

procedure loadfile (name : string; var p : pointer; var s : word);
var f : file;
label lerr;
begin
  p := nil; s := 0;
  {$I-}
  assign (f, name);
  reset (f, 1);
  if ioresult <> 0 then goto lerr;
  s := filesize (f);
  if ioresult <> 0 then goto lerr;
  if maxavail < s then goto lerr;
  getmem (p, s);
  blockread (f, p^, s);
  if ioresult <> 0 then goto lerr;
  close (f);
  exit;
lerr:
  if p <> nil then begin
    freemem (p, s);
    p := nil;
    s := 0
  end;
  close (f)
  {$I+}
end;

var
  minfo : TVESAModeInfo;
  fp : pointer;
  fs : word;
  name : string;
  l, h,
  fn, linesmax, i : word;

begin
  if not isvesa then begin
    writeln ('VESA VGA card is not found!');
    exit
  end;
  if not getvesamodeinfo ($101, minfo) then begin
    writeln ('VESA VGA card is not found!');
    exit
  end;
  randomize;
  setvesamode ($101);
  for fn := 1 to 9 do begin
    clearscreen (black);
    box (0, 0, 640, 480, 15, false);
    loadfile (fonts[fn].name, fp, fs);
    if fp = nil then continue;
    name := fonts[fn].name;
    l := fonts[fn].l;
    h := fonts[fn].h;
    setfont (fp, l, h);
    linesmax := 480 div h;
    i := 0;
    repeat
      outtextxy ((640-36*l) div 2, i*h,
                 '0123456789-ABCDEFGHIJKLMOPQRSTUVWXYZ', 1+random(15));
      inc (i)
    until i = linesmax div 2;
    repeat
      outtextxy ((640-32*l) div 2, i*h,
                 'ÄÅÇÉÑÖÜáàâäãåçéèêëíìîïñóòôöõúùûü', 1+random(15));
      inc (i)
    until i = linesmax;
    box (0, 0, l*(length(name)+5)+4, h+4, blue, true);
    box (0, 0, l*(length(name)+5)+4, h+4, lightcyan, false);
    outtextxy (2, 2, 'Font:'+name, lightcyan);
    readkey;
    freemem (fp, fs)
  end;
  textmode (co80);
  {$IFDEF DPMI} FreeRMInfos {$ENDIF}
end.
