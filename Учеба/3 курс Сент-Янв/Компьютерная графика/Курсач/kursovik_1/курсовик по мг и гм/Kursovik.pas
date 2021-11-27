Program _3D_;
{$M 16384,0,$100}
Uses nVBE,hDriver,Crt,nAccess ;
{$I TOOLS.INC}
{$I COLORRGB.INC}
{$I MATRIX.INC}
{$R+,Q+}
{---------------------------------------------------------------------------}
Type
  Vector=Record  x,y,z : Real;  End;
  OVertex=Record
            x,y,z   : Real; {координаты}
            tx,ty   : Integer; {координаты в текстуре}
            nx,ny,nz: Real; {направляющие косинусы вектора нормали}
          End;
  MVertex=Record
            {координаты}
            x,y,z: Real;
            tx,ty: Integer; {координаты в текстуре}
            c    : Real; {освещенность}
          End;
  OTriangle=Record
              A,B,C: OVertex;
            End;
  MTriangle=Record
              A,B,C: MVertex;
            End;
  LPoint=Record
           x,z: Real;
           tx,ty: Integer;
           c: Real;
         End;
  SLine=Record
          A,B: LPoint;
        End;
  Interval=Record
             n: Integer;
             x,z: Real;
           End;
Const
  TCount : Integer=0; {счетчик треугольников}
  MTCount: Integer=0; {счетчик треугольников}
  LCount : Integer=0; {счетчик линий сканирования}
  ICount : Integer=0; {счетчик интервалов}
  y      : Integer=0; {счетчик линий сканирования}
  LV1    : Vector=(x: 0; y:0; z:2);{вектор освещения}
  LV2    : Vector=(x: 0; y:-1; z:0);{вектор освещения}
  n = 50;
  Texture: String='cat.bmp';
  fone   : LongInt=0;
  XRes   = 350;
  YRes   = 250;
Var
  T:  Array[0..n] Of OTriangle;
  MT: Array[0..n] Of MTriangle;
  L:  Array[0..n] Of SLine;
  ZBuf:  Array[0..XRes] Of Real;
  Screen,TBuf: PBitmap16;
  H          : Integer;
  Tex,Logo,WW : PBitmap;
  R,M,Res  : Matrica;
  Key      : Word;
{----------------------------------------------------------------------------}
Procedure fntFONT;external;{$L FONT.obj}
Procedure ActivateScreen(Mode:Word);
  begin
    vActivateDriver(@vHighDriver);
    vSetMode(Mode);
  end;
{----------------------------------------------------------------------------}
Procedure Out_Text(Str:String; y: Integer);
 Var x,i,N: Integer;
  Begin
   vSetFont(@fntFont,8,1);
   N:=Length(Str);
   x:=320-N*10;
   vSetColor(blue);
   For i:=1 to N Do
     Begin
       vTextAsSprite(x,y,Str[i]);
       Inc(x,10);
       Delay(800);
     End;
  End;
{----------------------------------------------------------------------------}
Procedure ProgramInit;
  Var i,j: Integer; c: LongInt;
  Begin
    ActivateScreen(vDetectMode(640,480,16));
    vSetColor(0); vClearScreen;
    {-----------------------------------}
    vLoadFromBMP('fon.bmp',WW,Palette);
    For j:=0 To 479 Do
      For i:=0 To 639 Do
        Begin
          C:=WW^.GetPixel(i,j);
          C:=vColor((Palette[C].r shl 2), (Palette[C].g shl 2), (Palette[C].b shl 2));
          vSetColor(c);
          vPutPixel(i,j);
        End;
    Dispose(WW,Done);
    vSetColor(65535);
    Out_Text('КУРСОВАЯ РАБОТА ПО МГ И ГМ',320);
    Out_Text('Выполнил студент гр.В-41',350);
    Out_Text('Садовов Андрей',380);
{    Delay(3000);}
    TBuf := New(PBitmap16,Init(XRes,YRes));
    TBuf^.GetFromScreen(50,30);
    {--------------------------------------}
    vLoadFromBMP(Texture,Tex,Palette);
    For i:=0 To 255 Do
      Begin
        Palette[i].R:=Palette[i].R shl 2;
        Palette[i].G:=Palette[i].G shl 2;
        Palette[i].B:=Palette[i].B shl 2;
      End;
    Screen := New(PBitmap16,Init(XRes,YRes));
  End;
{----------------------------------------------------------------------------}
Procedure ProgramDone;
  Begin
    Dispose(Screen,Done);
    Dispose(Tex,Done);
    vCloseGraph;
    vReleaseDriver(vCurrentDriver);
  End;
{----------------------------------------------------------------------------}
Procedure ReadObject(FileName:String);
  Var F: File of OTriangle;
  Begin
    Assign(F,FileName);
    Reset(F);
    While not EOF(F) Do
      Begin
        Read(F,T[TCount]);
        Inc(TCount);
      End;
    Close(F);
  End;
{----------------------------------------------------------------------------}
Procedure GuroZLine(Buf: PBitmap16; Ax,Az,Bx,Bz: Real; y: Integer; Atx,Aty,Btx,Bty: Real;
                    Ac, Bc : Real);
Var
  I,x : Integer;
  L: Real;
  dC,C : Real;
  z,dz: Real;
  dtx,dty: Real;
  tx,ty: Real;
  Color: LongInt;
Begin
  L := Bx-Ax+1;
  dC := (Bc-Ac)/L;
  dz := (Bz-Az)/L;
  dtx := (Btx-Atx)/L;
  dty := (Bty-Aty)/L;
  tx:=Atx;
  ty:=Aty;
  C:=Ac;
  z:=Az;
  For i := Round(Ax) To Round(Bx) Do
    Begin
      C:=C+dC;
      x:=i;
      z:=z+dz;
      tx:=tx+dtx;
      ty:=ty+dty;
      If (x<0)or(x>xres) Then Continue;
      If z>ZBuf[x] Then Continue
      Else ZBuf[x]:=z;
      Color:=Tex^.GetPixel(Round(tx),Round(ty));
      Color:=vColor(Round((Palette[Color].r)*c),
                    Round((Palette[Color].g)*c),
                    Round((Palette[Color].b)*c));
      Buf^.PutPixel(x,y,Color);
    End;
End;
{----------------------------------------------------------------------------}
Procedure SortTriangle;
  Var i: Integer;
      t: MVertex;
  Begin
    { Сортировка вершин по возростанию координаты `y` }
    For i:=0 To MTCount-1 Do
      Begin
        With MT[i] Do
          Begin
            If A.y>B.y Then Begin  t:=A; A:=B; B:=t;  End;
            If B.y>C.y Then Begin  t:=B; B:=C; C:=t;  End;
            If A.y>B.y Then Begin  t:=A; A:=B; B:=t;  End;
          End;
      End;
  End;
{----------------------------------------------------------------------------}
Procedure SortLine;
  Var i: Integer;
      t: LPoint;
  Begin
    { Сортировка концов отрезков по возростанию координаты `x` }
    For i:=0 To LCount-1 Do
      If L[i].A.x>L[i].B.x Then
        Begin t:=L[i].A; L[i].A:=L[i].B; L[i].B:=t; End;
  End;
{----------------------------------------------------------------------------}
Procedure TransTriangle(M: Matrica);
  Var nx,ny,nz,NLen,znormal,VectCos,VectCos1,VectCos2: Real; i: Integer;
  Begin
    MTCount:=0;
    For i:=0 To TCount-1 Do
      Begin
        MT[MTCount].A.x:=T[i].A.x*M[1,1] + T[i].A.y*M[1,2] + T[i].A.z*M[1,3] +M[1,4];
        MT[MTCount].A.y:=T[i].A.x*M[2,1] + T[i].A.y*M[2,2] + T[i].A.z*M[2,3] +M[2,4];
        MT[MTCount].A.z:=T[i].A.x*M[3,1] + T[i].A.y*M[3,2] + T[i].A.z*M[3,3] +M[3,4];
        {---}
        MT[MTCount].B.x:=T[i].B.x*M[1,1] + T[i].B.y*M[1,2] + T[i].B.z*M[1,3] +M[1,4];
        MT[MTCount].B.y:=T[i].B.x*M[2,1] + T[i].B.y*M[2,2] + T[i].B.z*M[2,3] +M[2,4];
        MT[MTCount].B.z:=T[i].B.x*M[3,1] + T[i].B.y*M[3,2] + T[i].B.z*M[3,3] +M[3,4];
        {---}
        MT[MTCount].C.x:=T[i].C.x*M[1,1] + T[i].C.y*M[1,2] + T[i].C.z*M[1,3] +M[1,4];
        MT[MTCount].C.y:=T[i].C.x*M[2,1] + T[i].C.y*M[2,2] + T[i].C.z*M[2,3] +M[2,4];
        MT[MTCount].C.z:=T[i].C.x*M[3,1] + T[i].C.y*M[3,2] + T[i].C.z*M[3,3] +M[3,4];
        {ОТБРАСЫВАНИЕ НЕЛИЦЕВЫХ ГРАНЕЙ}
        znormal:=(MT[MTCount].B.x-MT[MTCount].A.x)*(MT[MTCount].C.y-MT[MTCount].A.y)-
                 (MT[MTCount].B.y-MT[MTCount].A.y)*(MT[MTCount].C.x-MT[MTCount].A.x);
        If znormal <= 0 Then  Continue;
        {---}
        MT[MTCount].A.tx:=T[i].A.tx;  MT[MTCount].A.ty:=T[i].A.ty;
        MT[MTCount].B.tx:=T[i].B.tx;  MT[MTCount].B.ty:=T[i].B.ty;
        MT[MTCount].C.tx:=T[i].C.tx;  MT[MTCount].C.ty:=T[i].C.ty;
        {A}
        nx:=T[i].A.nx*M[1,1] + T[i].A.ny*M[1,2] + T[i].A.nz*M[1,3];
        ny:=T[i].A.nx*M[2,1] + T[i].A.ny*M[2,2] + T[i].A.nz*M[2,3];
        nz:=T[i].A.nx*M[3,1] + T[i].A.ny*M[3,2] + T[i].A.nz*M[3,3];
        NLen:=Sqrt( Sqr(nx)+ Sqr(ny)+ Sqr(nz) );
        if NLen<>0 Then Begin nx:=nx/NLen; ny:=ny/NLen; nz:=nz/NLen; End;
        VectCos1:=nx*LV1.x + ny*LV1.y + nz*LV1.z;
        VectCos2:=nx*LV2.x + ny*LV2.y + nz*LV2.z;
        VectCos:=VectCos1+VectCos2;
        If VEctCos>1 Then VectCos:=1;
        If VEctCos<0 Then VectCos:=0;
        MT[MTCount].A.c:=VectCos;
        {B}
        nx:=T[i].B.nx*M[1,1] + T[i].B.ny*M[1,2] + T[i].B.nz*M[1,3];
        ny:=T[i].B.nx*M[2,1] + T[i].B.ny*M[2,2] + T[i].B.nz*M[2,3];
        nz:=T[i].B.nx*M[3,1] + T[i].B.ny*M[3,2] + T[i].B.nz*M[3,3];
        NLen:=Sqrt( Sqr(nx)+ Sqr(ny)+ Sqr(nz) );
        if NLen<>0 Then Begin nx:=nx/NLen; ny:=ny/NLen; nz:=nz/NLen; End;
        VectCos1:=nx*LV1.x + ny*LV1.y + nz*LV1.z;
        VectCos2:=nx*LV2.x + ny*LV2.y + nz*LV2.z;
        VectCos:=VectCos1+VectCos2;
        If VEctCos>1 Then VectCos:=1;
        If VEctCos<0 Then VectCos:=0;
        MT[MTCount].B.c:=VectCos;
        {C}
        nx:=T[i].C.nx*M[1,1] + T[i].C.ny*M[1,2] + T[i].C.nz*M[1,3];
        ny:=T[i].C.nx*M[2,1] + T[i].C.ny*M[2,2] + T[i].C.nz*M[2,3];
        nz:=T[i].C.nx*M[3,1] + T[i].C.ny*M[3,2] + T[i].C.nz*M[3,3];
        NLen:=Sqrt( Sqr(nx)+ Sqr(ny)+ Sqr(nz) );
        if NLen<>0 Then Begin nx:=nx/NLen; ny:=ny/NLen; nz:=nz/NLen; End;
        VectCos1:=nx*LV1.x + ny*LV1.y + nz*LV1.z;
        VectCos2:=nx*LV2.x + ny*LV2.y + nz*LV2.z;
        VectCos:=VectCos1+VectCos2;
        If VEctCos>1 Then VectCos:=1;
        If VEctCos<0 Then VectCos:=0;
        MT[MTCount].C.c:=VectCos;
        inc(MTCount);
      End;
  End;
{----------------------------------------------------------------------------}
Procedure CreatLineList;
Var   i: Integer;
      x1,x2,z1,z2,L1,L2: Real;
      tx1,ty1,tx2,ty2: Integer;
  Begin
    LCount:=0;
    For i:=0 To MTCount-1 Do
      Begin
        If (y<MT[i].A.y) or (y>MT[i].C.y) Then Continue;
        With MT[i] Do
          Begin
            x1:=A.x+(y-A.y)*(C.x-A.x) /(C.y-A.y);
            z1:=A.z+(y-A.y)*(C.z-A.z)/(C.y-A.y);
            L1:=A.c+(y-A.y)*(C.c-A.c) /(C.y-A.y);
            tx1:=Round(A.tx+(y-A.y)*(C.tx-A.tx) / (C.y-A.y));
            ty1:=Round(A.ty+(y-A.y)*(C.ty-A.ty) / (C.y-A.y));
            If y<B.y Then
              Begin
                x2:=A.x+(y-A.y)*(B.x-A.x) / (B.y-A.y);
                z2:=A.z+(y-A.y)*(B.z-A.z)/(B.y-A.y);
                L2:=A.c+(y-A.y)*(B.c-A.c) / (B.y-A.y);
                tx2:=Round(A.tx+(y-A.y)*(B.tx-A.tx) / (B.y-A.y));
                ty2:=Round(A.ty+(y-A.y)*(B.ty-A.ty) / (B.y-A.y));
              End
            else
              If C.y=B.y Then
                Begin
                  x2:=B.x; z2:=B.z; L2:=B.c; tx2:=B.tx; ty2:=B.ty;
                End
              else
                Begin
                  x2:=B.x+(y-B.y)*(C.x-B.x) / (C.y-B.y);
                  z2:=B.z+(y-B.y)*(C.z-B.z)/(C.y-B.y);
                  L2:=B.c+(y-B.y)*(C.c-B.c) / (C.y-B.y);
                  tx2:=Round(B.tx+(y-B.y)*(C.tx-B.tx) / (C.y-B.y));
                  ty2:=Round(B.ty+(y-B.y)*(C.ty-B.ty) / (C.y-B.y));
                End;
            L[LCount].A.x:=Round(x1); L[LCount].A.z:=z1;
            L[LCount].A.tx:=tx1; L[LCount].A.ty:=ty1; L[LCount].A.c:=L1;
            L[LCount].B.x:=Round(x2); L[LCount].B.z:=z2;
            L[LCount].B.tx:=tx2; L[LCount].B.ty:=ty2; L[LCount].B.c:=L2;
            Inc(LCount);
          End;
      End;
  End;
{----------------------------------------------------------------------------}
Procedure LZBuf(y: Integer);
  var i: Integer;
  Begin
    For i:=0 To XRes Do ZBuf[i]:=876786756;
    For i:=0 To LCount-1 Do
      With L[i] Do
        GuroZLine(Screen,A.x,A.z, B.x,B.z, y, A.tx,A.ty, B.tx,B.ty, A.c,B.c);
  End;
{----------------------------------------------------------------------------}
Procedure DrawScene(M: Matrica);
  Begin
    TransTriangle(Res);
    SortTriangle;
    Screen^.Fill(fone);
    TBuf^.StampToBitmap(Screen,0,0);
    For y:=0 To YRes Do
      Begin
        CreatLineList;
        If LCount>0 Then
          Begin
            SortLine;
            LZBuf(y);
          End;
      End;
    Screen^.Stamp(50,30);
  End;
{----------------------------------------------------------------------------}
Var alfa: Integer;
{----------------------------------------------------------------------------}
BEGIN
  If ParamCount>0 Then Texture:=ParamStr(1);
  ProgramInit;
  ReadObject('Obj.3d');
  H:=0;
  alfa:=0;
  M:=Ed;  R:=Ed;
  Repeat
      If KeyHit Then
        Begin
          Key:=KeyGet;
          If ShiftPressed Then
              case Key of
                kbRight: Rot(R,'y',355);
                kbLeft:  Rot(R,'y',5);
                kbUp:    Rot(R,'x',5);
                kbDown:  Rot(R,'x',355);
              end
           else
             case Key of
               kbEsc:   Break;
               kbLeft:  Move(M,-15,0,0);
               kbRight: Move(M,15,0,0);
               kbUp:    Move(M,0,-15,0);
               kbDown:  Move(M,0,15,0);
               kbPgUp:  Scale(M,1.2,1.2,1.2);
               kbPgDn:  Scale(M,1/1.2,1/1.2,1/1.2);
               kbCtrlRight: Rot(R,'z',5);
               kbCtrlLeft:  Rot(R,'z',355);
               kbGrayPlus:  Begin
                              If LV1.z<5.9 Then LV1.z:=LV1.z+0.1;
                              If LV2.z<5.9 Then LV2.z:=LV2.z+0.1;
                            End;
               kbGrayMinus: Begin
                              If LV1.z>0.1 Then LV1.z:=LV1.z-0.1;
                              If LV2.z<5.9 Then LV2.z:=LV2.z-0.1;
                            End;
             end;
        End;
    Mult(M,R,Res);
    Move(Res,100,80,100);
    DrawScene(Res);
    alfa:=(alfa +5) mod 65535;
  Until False;
  ProgramDone;
END.
