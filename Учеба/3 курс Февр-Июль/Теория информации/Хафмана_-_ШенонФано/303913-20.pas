unit Shannon;

interface


Uses
  Forms, Dialogs;
const
   Count=4096;
   ArchExt='she';
   dot='.';

//��� �������� ���������� ��� ������ ��������� ����� � ���
//������ ������
var
   FileToRead,FileToWrite: File;
   Str1:String='';

// ��������� ��� ������ � ������
// ������ - ����������� �����
procedure RunEncodeShan(FileName_: string);
// ������ - ������������� �����
procedure RunDecodeShan(FileName_: string);


implementation

Type
   //��� ������� ��� ������������ ��������� ���������� ������
   TByte=^PByte;
   PByte=Record
 //������ (���� �� ������� ASCII)
      Symbol: Byte;
 //���������� �������
      SymbolStat: Integer;
 //������������������ �����, � ������� ������������� �������
 //������� ����� ������ ����� (������� �����) (� ���� ������ �� "0" � "1")
      CodWord: String;
 //������ �� ����� � ������ ���������� (�����)
      left, right: TByte;
   End;

//������ �� �������� �� ����������� , �.�. �������� ��������� ��
//� ������������ �����
   BytesWithStat = Array [0..255] of TByte;

   //������, ���������� � ����:
   // ������ ��������� ���������� � ���� ���������� ���������,
   // ������������� � ����� ���� �� ���� ���
   // ���������  ������������� �������
   // ��������� ��� ���������� ������� i-�� ��������
   TStat =Object
      massiv: BytesWithStat;
      CountByte: byte;
      Procedure Create;//������� ������������� �������
      Procedure Inc(i: Byte);
   End;
//��������� ������������� ������� ���������� ��
   Procedure TStat.Create;
   var
      i: Byte;
   Begin
      CountByte:=255;
      For i:=0 to CountByte do
      Begin
         New(massiv[i]);//������ ������������ ����������
         //� ������������� ��������� �� ��
         massiv[i]^.Symbol:=i;
         massiv[i]^.SymbolStat:=0;
         massiv[i]^.left:=nil;
         massiv[i]^.right:=nil;
         Application.ProcessMessages;//������������ �������
         //����� ���������� �� �������� ��������, ����� ��� ������ ����������
         //���� ������������� �� ��������� ���� ����������
      End;
   End;

//  ��������� ��� ��� ���������� ������ ���������
// i-�� �������� � ��������� �����. ���������� ��
   Procedure TStat.Inc(i: Byte);
   Begin
      massiv[i]^.SymbolStat:=massiv[i]^.SymbolStat+1;
   End;

Type
   //������ ���������� � ����:
   //��� � ���� � ������������� �����
   //������ ������������� �����
   //������ ���������� ������ ������
   //������ ������ ������
   //������� ��������� �� ����� ����� ����� ������
   //������� ��������� �� ����� ������ ����� ��������� �����
   //������� ��� ����������� ������� ����� ��� ���������
   //����� ������� ������������ �������� � �������� �����
   //������ ���������� ������ ������
   File_=Object
      Name: String;
      Size: Integer;
      Stat: TStat;
      Tree: TByte;
      Function ArcName: String;
      Function DeArcName: String;
      Function FileSizeWOHead: Integer;
   End;

   // ��������� �� ����� ����� ����� ������
Function File_.ArcName: String;
   Var
      i: Integer;
      name_: String;
   Const
      PostFix=ArchExt;
   Begin
      name_:=name;
      i:=Length(Name_);

      While (i>0) And not(Name_[i] in ['/','\','.']) Do
      Begin
         Dec(i);
         Application.ProcessMessages;
      End;

      If (i=0) or (Name_[i] in ['/','\'])
      Then
         ArcName:=Name_+'.'+PostFix
      Else
         If Name_[i]='.'
         Then
         Begin
            Name_[i]:='.';
            //Name_[i]:='!';
            ArcName:=Name_+'.'+PostFix;
         End;
   End;

 // ��������� �� ����� ������ ����� ��������� �����
Function File_.DeArcName: String;
   Var
      i: Integer;
      Name_: String;
   Begin
      Name_:=Name;
      if pos(dot+ArchExt,Name_)=0
      Then
      Begin
         ShowMessage('������������ ��� ������,'#13#10'��� ������ ������������� �� ".'+ArchExt+'"');
         Application.Terminate;
      End
      Else
      Begin
         i:=Length(Name_);
         While (i>0) And (Name_[i]<>'!') Do
         Begin
            Dec(i);
            Application.ProcessMessages;
         End;
         If i=0
         Then
         Begin
            Name_:=copy(Name_,1,pos(dot+ArchExt,Name_)-1);
            If Name_=''
            Then
            Begin
               ShowMessage('������������ ��� ������');
               Application.Terminate;
            End
            Else
               DeArcName:=Name_;
         End
         Else
         Begin
            Name_[i]:='.';
            Delete(Name_,pos(dot+ArchExt,Name_),4);
            DeArcName:=Name_;
         End;
      End;
   End;

Function File_.FileSizeWOHead: Integer;
      Begin
         FileSizeWOHead:=FileSize(FileToRead)-4-1-
         (Stat.CountByte+1)*5;
        //������ ��������� ����� ������������ � 4 ������
        //���������� ������������ ���� ������������ � 1�����
        //���������� ������ �� ����������� - �������� �������
      End;
   //��������� ���������� ������� � ������� (���������� ������������
   //�� �������� ������� �����
procedure SortMassiv(var a: BytesWithStat; length_mass: byte);
   var
      i,j: Byte;
      b: TByte;
   Begin
      if length_mass<>0
      Then
         for j:=0 to length_mass-1 do
         Begin
            for i:=0 to length_mass-1 do
            Begin
               If a[i]^.SymbolStat < a[i+1]^.SymbolStat
               Then
               Begin
                  b:=a[i]; a[i]:=a[i+1]; a[i+1]:=b;
               End;
               Application.ProcessMessages;
            End;
            Application.ProcessMessages;
         End;
   End;

   {��������� ���������� ����� ������ Shennon}
procedure CreateTree(var Root: TByte;massiv: BytesWithStat;
                      last: byte);
//�������� ������� ������
procedure DivGroup(i1, i2: byte);
{��������� �������� ������� ����. ���������� ����� ���� ���
���������� ��������� ������� ������� �� ������. � ����������
������ ������� �� �� ���� ������ ������ ��������� ������ '0'
�� ������ ������ �������}
procedure CreateCodWord(i1, i2: byte;Value:string);
 var
 i:integer;
begin
  for i:=i1 to i2 do
  massiv[i]^.CodWord:=massiv[i]^.CodWord+Value;
end;
//�������� ������� �������
var
k, i : byte;
c, oldc, s, g1, g2 :Single;
begin
  //����������� �������, ����� �������� � ���
  // �� ���� �����������
  if (i1<i2) then
  begin
    s := 0;
    for i := i1 to i2 do
    s := s + massiv[i]^.SymbolStat;//��������� ���������� ������
//��������� �������� � �����
    k := i1; //����� �������������� ����������
    g1 := 0;
    g2 := s;
    c := g2 - g1;
{��������: ���������� i1 � i2 ��� �������
���������� � �������������� ��������� �������� �������.
� k ����� ������������ ������ ������������ �������� �������
�� �������� �� ��� ����� ������. � ���������� � ������ �����
�������� �������� ����� g2 � g1. ����������� ��� �����������
k. ������� ��������� ���������� ��������� �������� � �����
(��� ��� �� ������� ����� ����� ������� ����� =: �.�.
���������� ���� � ��)). ����� �������������� ����������.
����� ���� � ������� ���������� ��������� � g1 �������
���������� ���������� ��������� massiv[k] �������� �������
massiv[k], � �� g2 �������� �� �� ����������. ����� oldc:=c
��� ��� ���� ��� ����������� ����� �� �� �������� k ���
���������� ����� ������ ������� �����. c := abs(g2-g1)
������ �� ������ ����� � ��� �� ���������� ������� (c >= oldc)
� ��� ������ ����� (g2<g1). ����� ����������� ������� c > oldc,
���� ��� ����� ��  �� ��������� k  �� �������, ���� �� ��
��������� k ����� ���� ��� � ����� �������� �������� � �������
���� ��������� ������� �������� �����. ����� ������ ����������
�������� ��� �� ���������  ���� ������� ��������� �� ����������
�� ��������� �������� ��� ������    }
    repeat
      g1 := g1 + massiv[k]^.SymbolStat;
      g2 := g2  - massiv[k]^.SymbolStat;
      oldc := c;
      c := abs(g2-g1);
      Inc(k);
    until (c >= oldc) or (k = i2);
    if c > oldc then
      begin
       Dec(k); //������������ �������� k2
      end;
    CreateCodWord(i1, k-1,'0'); //��������� ������ ������
    //����������
    CreateCodWord(k, i2,'1'); //��������� ������ ������
    //����������
    DivGroup(i1, k-1);//����� �������� ���������
    //������� ������� (������ �����)
    DivGroup(k, i2);// �������� ���������
   end;

end;

begin

 DivGroup(0,last);

end;

var
   //��������� ������� ��� �������� ���������� �����
   MainFile: file_;

//��������� ��� ������� ������� ������ ������ ������������� ���� ��
//���� ��� � �������� �����
procedure StatFile(Fname: String);
var
   f: file;  //���������� ���� file � �� ����� ������
   i,j: Integer;
   buf: Array [1..count] of Byte;//������=4�� ���������� �
   //���� ����� ������������� ����� �� 4�� �������� ��� ��� ���������
   //������ ��������
   countbuf, lastbuf: Integer;//countbuf ���������� ������� ����������
   //����� ����� ���������� �������=4�� ���������� � �������� �����
   //��� ������� ������  �������� ����������� � �������� �����
   //lastbuf ������� ���� ������� ��������� ����� ����������������
Begin
   AssignFile(f,fname);//��������� �������� ��������� f
   //� ������������ ������
   Try
      Reset(f,1);//��������� ����
      MainFile.Stat.create;//�������� ����� ������������� �������
      //��� ������������� �����
      MainFile.Size:=FileSize(f);//����� ����������� �������
      // ������������� �����
      ///////////////////////
      countbuf:=FileSize(f) div count;//������� ����� �������
      //�� 4096 ���� ���������� � �������� �����
      lastbuf:=FileSize(f) mod count; // ������� (�������� �����)�������
      //� ������ �� 4096
      ////////////
      For i:=1 to countbuf do
      Begin
         BlockRead(f,buf,count);
         for j:=1 to count do
         Begin
            MainFile.Stat.inc(buf[j]);
            Application.ProcessMessages;
         End;
         Application.ProcessMessages;
      End;
      /////////////
      If lastbuf<>0 //������������ ���������� ��� ����������
      //����
      Then
      Begin
         BlockRead(f,buf,lastbuf);
         for j:=1 to lastbuf do
         Begin
            MainFile.Stat.inc(buf[j]);
            Application.ProcessMessages;
         End;
         Application.ProcessMessages;
      End;
      CloseFile(f);
   Except
      ShowMessage('������ ������� � �����!')
   End;
End;

//��������� ������ ������� ������ ����� � �����
Procedure WriteInFile(var buffer: String);
var
   i,j: Integer;
   k: Byte;
   buf: Array[1..2*count] of byte;
Begin
   i:=Length(buffer) div 8; // ������ ������� ���������
   //���� � ������ ������������������
   //////////////////////////
   For j:=1 to i do //  �������� � �������
   Begin
      buf[j]:=0;// �������� ��� ������� ������ �
      //������� ����� ������
      ///////////////////////////
      For k:=1 to 8 do  //�������� � ������
{������� � ������ ��� �������
������� ����� ���������� � ���� ������������������ ���
(����� ������������� � (j-1) �������� ������ buffer ������
�������� �� ��� ��� ����� ������������ ������  ��
������ '0' � '1'. ��� ������ �� �����  ��������������� � ����,
������� ������ ����� ��������� ������� ������������������ ���)}
      Begin
         If buffer[(j-1)*8+k]='1'
         Then
{�������������� ����� ����������� � ������� �������� ��������
������ ����� shl � ���������� ��������� ��� (or). ��������
��� ��� ���������� ������� buffer[(j-1)*8+k]='1' ���� �
���������� ������ �� ������ �������� (�� ������������� � ��
����� �� ������� �������� �� ��������), �������, ������
�������� ����� �������� ����� �, ����� �������, �� �
���������������� ���� (����� �������� � ����� �����
���������� ����� �) ����� ��������� �������� or (0 or 1=1)
�.�. ��� ��� ������ �������� 1. ���� � ������ �����
���� �� � ��������������� ��� ����� ����� ����. (��� ��� ��
��������� ������������� �.�. � ������ ������ � ������ ������
�� ��� ��������)}
            buf[j]:=buf[j] or (1 shl (8-k));
         Application.ProcessMessages;
      End;
      Application.ProcessMessages;
   End;
   BlockWrite(FileToWrite,buf,i);
   Delete(buffer,1,i*8);
End;

//��������� ��� ������������� ������ ���������� ������� ����� � �����
Procedure WriteInFile_(var buffer: String);
var
   a,k: byte;
Begin
   WriteInFile(buffer);
   If length(buffer)>=8
   Then
      ShowMessage('������ � ���������� ������')
   Else
      If Length(buffer)<>0
      Then
      Begin
         a:=$FF;
         for k:=1 to Length(buffer) do
         If buffer[k]='0'
         Then
            a:=a xor (1 shl (8-k));
         BlockWrite(FileToWrite,a,1);
      End;
End;

Type
   Integer_=Array [1..4] of Byte;

//������� ������ ����� � ������ �� ������� ����.
Procedure IntegerToByte(i: Integer; var mass: Integer_);
var
   a: Integer;
   b: ^Integer_;
Begin
   b:=@a;
   a:=i;
   mass:=b^;
End;

//������� ������� �� ������� ���� � ����� �����.
Procedure ByteToInteger(mass: Integer_; var i: Integer);
var
   a: ^Integer;
   b: Integer_;
Begin
   a:=@b;
   b:=mass;
   i:=a^;
End;

//��������� �������� ��������� ������
Procedure CreateHead;
var
   b: Integer_;
   //a: Integer;
   i: Byte;
Begin
   //������ ��������� �����
   IntegerToByte(MainFile.Size,b);
   BlockWrite(FileToWrite,b,4);

   //���������� ������������ ����
   BlockWrite(FileToWrite,MainFile.Stat.CountByte,1);

   //����� �� �����������
   For i:=0 to MainFile.Stat.CountByte do
   Begin
      BlockWrite(FileToWrite,MainFile.Stat.massiv[i]^.Symbol,1);
      IntegerToByte(MainFile.Stat.massiv[i]^.SymbolStat,b);
      BlockWrite(FileToWrite,b,4);
   End;
End;


const
   MaxCount=4096;
type
   buffer_=object
      ArrOfByte: Array [1..MaxCount] of Byte;
      ByteCount: Integer;
      GeneralCount: Integer;
      Procedure CreateBuf;
      Procedure InsertByte(a: Byte);
      Procedure FlushBuf;
 End;
      /////////////////////////////
      Procedure buffer_.CreateBuf;
      Begin
         ByteCount:=0;
         GeneralCount:=0;
      End;

      ////////////////////////////////////////
Procedure buffer_.InsertByte(a: Byte); //� � ������� ���
// ��������������� ������ ������ ���� �������� � ����
      Begin
         if GeneralCount<MainFile.Size
         Then
         Begin
            inc(ByteCount);
            inc(GeneralCount);
            ArrOfByte[ByteCount]:=a;
            //////////////////////////
            if ByteCount=MaxCount
            Then
            Begin
               BlockWrite(FileToWrite,ArrOfByte,ByteCount);
               ByteCount:=0;
            End;
         End;
      End;

      ////////////////////////////
Procedure Buffer_.FlushBuf; //����� ������
      Begin
         If ByteCount<>0
         Then
            BlockWrite(FileToWrite,ArrOfByte,ByteCount);
      End;
//�������� ����������������� �����
Procedure CreateDeArc;
var
   i,j: Integer;
   k: Byte;
   //////////////
   Buf: Array [1..Count] of Byte;
   CountBuf, LastBuf: Integer;
   MainBuffer: buffer_;
   BufSearch:string;
{��������� ������ �������, ������ ��������������������
����� ������� ��������� ���������� �������� ��� ��������.
��������: ���������� �-�� CreateDeArc ������������ ��������
������� �� ���������������� ����� � �������� �-��
SearchSymbol (Str:string); � ���������� Str � ������� ���������
����������� ������. �-�� SearchSymbol ���������� ���� ������ �
������ Str1 � ������� ����������� ������� �����}
Procedure SearchSymbol (Str:string);
var
v:integer;
SearchStr:String;//��������������� ���������� � �������
//���������� ������� ����� ��� ��������� �� � Str1
a:byte;//���������� � ������� ����� ��������� ���������
//������
begin
  Str1:=Str1+Str;//������ ������� �����
  For v:=0 to  MainFile.Stat.CountByte do
    begin //���������� ����� � �������
     SearchStr:=MainFile.Stat.massiv[v]^.CodWord ;
       If (SearchStr=Str1) Then
        begin
//���� ����� �� � � �������� �������� �������
          a:=MainFile.Stat.massiv[v]^.Symbol;
//�������� ��������� ������ �������
          MainBuffer.InsertByte(a);
//�������� ��������� ����������
          Str1:='';
//������� �� �����
          Break;
        end;
    end;
end;

Begin
   BufSearch:='';{���������� � ������� ��������
������������ ������, ������� ����� ����������� �
��������� SearchSymbol}
   CountBuf:=MainFile.FileSizeWOHead div count;
   LastBuf:=MainFile.FileSizeWOHead mod count;
   MainBuffer.CreateBuf;

   For i:=1 to CountBuf do
     Begin
      BlockRead(FileToRead,buf,count);
      for j:=1 to Count do
       Begin
{�������� ���� � �������. �� ����� �� 1 �� 8
������������� �������� ��� ��� c 8 �� 1. ��� ����� ������������
�������� �������� ������ ����� shl � ��������� �������� and.
� ����� �� ���������� ��������� �������: ������� ���������������
������� ��� (8-�)=7 � ������������ ���������� �������� and,
���� ��� ����� 1 �� (1 and 1)=1 � � BufSearch:='1', ���� ��
��� ����� 0 � (0 and 1)=0 � � BufSearch:='1' }
        for k:=1 to 8 do
         Begin
            If ((Buf[j] and (1 shl (8-k)))<>0 ) Then
              begin
               BufSearch:='1';
//�������� ��������� SearchSymbol
               SearchSymbol (BufSearch);
//�������� ��������� ����������
               BufSearch:='';
              end
             Else
              begin
               BufSearch:=BufSearch+'0';
               SearchSymbol (BufSearch);
               BufSearch:='';
            Application.ProcessMessages;
              End;
          Application.ProcessMessages;
          End;
        Application.ProcessMessages;
       End;
     Application.ProcessMessages;
   End;
  If LastBuf<>0
  Then //���������� ��������������
   Begin
      BlockRead(FileToRead,Buf,LastBuf);
      for j:=1 to LastBuf do
      Begin
       for k:=1 to 8 do
         Begin
            If ((Buf[j] and (1 shl (8-k)))<>0 )
            Then
             begin
               BufSearch:=BufSearch+'1';
               SearchSymbol (BufSearch);
               BufSearch:='';
              end
             Else
              begin
               BufSearch:=BufSearch+'0';
               SearchSymbol (BufSearch);
               BufSearch:='';
              end;
            Application.ProcessMessages;
         End;
         Application.ProcessMessages;
      End;
   End;
   MainBuffer.FlushBuf;
End;


//��������� ������ ��������� ������
Procedure ReadHead;
var
   b: Integer_;
   SymbolSt: Integer;
   count_, SymbolId, i: Byte;
Begin
   try
      //������ �������� ������ �����
      BlockRead(FileToRead,b,4);
      ByteToInteger(b,MainFile.size);

      //������ ���������� ������������ ������
      BlockRead(FileToRead,count_,1);
      {}{}{}
      MainFile.Stat.create;
      MainFile.Stat.CountByte:=count_;
      //�������� ������� � ������
      for i:=0 to MainFile.Stat.CountByte do
      Begin
         BlockRead(FileToRead,SymbolId,1);
         MainFile.Stat.massiv[i]^.Symbol:=SymbolId;
         BlockRead(FileToRead,b,4);
         ByteToInteger(b,SymbolSt);
         MainFile.Stat.massiv[i]^.SymbolStat:=SymbolSt;
      End;

      CreateTree(MainFile.Tree,MainFile.stat.massiv,MainFile.Stat.CountByte);
      /////////////
      CreateDeArc;
      //////////////
     // DeleteTree(MainFile.Tree);

   except
      ShowMessage('����� ��������!');
   End;
End;

//��������� ���������� ������
Procedure ExtractFile;
Begin
   AssignFile(FileToRead,MainFile.Name);
   AssignFile(FileToWrite,MainFile.DeArcName);
   try
      Reset(FileToRead,1);
      Rewrite(FileToWrite,1);

//��������� ������ ����� �����
      ReadHead;

      Closefile(FileToRead);
      Closefile(FileToWrite);

   Except
      ShowMessage('������ ���������� �����');
   End;
End;

//��������������� ��������� ��� �������� ������
Procedure CreateArchiv;
var
   buffer: String;
   ArrOfStr: Array [0..255] of String;
   i,j: Integer;
   //////////////
   buf: Array [1..count] of Byte;
   CountBuf, LastBuf: Integer;
Begin

   Application.ProcessMessages;
   AssignFile(FileToRead,MainFile.Name);
   AssignFile(FileToWrite,MainFile.ArcName);
   Try
      Reset(FileToRead,1);
      Rewrite(FileToWrite,1);
      For i:=0 to 255 Do ArrOfStr[i]:='';
      For i:=0 to MainFile.Stat.CountByte do
      Begin
         ArrOfStr[MainFile.Stat.massiv[i]^.Symbol]:=
         MainFile.Stat.massiv[i]^.CodWord;
         Application.ProcessMessages;
      End;
      CountBuf:=MainFile.Size div Count;
      LastBuf:=MainFile.Size mod Count;
      Buffer:='';
      /////////////
      CreateHead;
      /////////////
      for i:=1 to countbuf do
      Begin
         BlockRead(FileToRead,buf,Count);
         //////////////////////
         For j:=1 to count do
         Begin
            buffer:=buffer+ArrOfStr[buf[j]];
            If Length(buffer)>8*count
            Then
               WriteInFile(buffer);
            Application.ProcessMessages;
         End;
      End;
      If lastbuf<>0
      Then
      Begin
         BlockRead(FileToRead,buf,LastBuf);
         For j:=1 to lastbuf do
         Begin
            buffer:=buffer+ArrOfStr[buf[j]];
            If Length(buffer)>8*count
            Then
               WriteInFile(buffer);
            Application.ProcessMessages;
         End;
      End;
      WriteInFile_(buffer);
      CloseFile(FileToRead);
      CloseFile(FileToWrite);
   Except
      ShowMessage('������ �������� ������');
   End;
End;

//������� ��������� ��� �������� ��������� �����
Procedure CreateFile;
var
   i: Byte;
Begin
   With MainFile do
   Begin
      {���������� ������� ������ � ���������}
      SortMassiv(Stat.massiv,stat.CountByte);

      {����� ����� ��������������� ������ ��
      ������� �������� ��������. � count_byte ����� �������
      ���������� ���� ����� ���� }
      i:=0;//�������� �������
      While (i<Stat.CountByte) //�� ��� ��� ���� �������
      //������ ���������� �������������� ���� CountByte
      //� ���������� ����� (������� ��������� � �����)
      //�� ����� ����  ������
        and (Stat.massiv[i]^.SymbolStat<>0) do
      Begin
         Inc(i); //����������� ������� �� �������
      End;

      //////////////////////
      If Stat.massiv[i]^.SymbolStat=0 //���� ����� �� �������
      //� ������� �������������� � ����� ��
      Then
          Dec(i); //��������� ������� �� ������� ������ ������������
           //����� ��� ����� ��������� �������
      //////////////////////

      Stat.CountByte:=i;//����������� �������� ��������
      //count_byte. ��� �������� ��� � ������������ �����
      //������������ ����� ���������� �� 256 ���������
      //��������. ����� ������������ ��� ���������� ����� ������

      {�������� ������ ������. ������� � ��������� ���������
      ��������� Tree=nil-��� ���������� ����� ���������
      ����� ������ ��������� ����� ,Stat.massiv-������ � ���������
      � ��������������� �� �����������,� ��� �� ��������� ��
      ������ � ����� ������,Stat.CountByte-���������� ������������
      �������� � ����������� ����� }
      CreateTree(Tree,Stat.massiv,Stat.CountByte);

      //����� ��� ����
      CreateArchiv;

      //������� ��� �������� ������
      //DeleteTree(Tree);

      //�������������� ���������� �����
      MainFile.Stat.Create;
   End;
End;

procedure RunEncodeShan(FileName_: string);
begin
   MainFile.Name:=FileName_;//������� ���
   //������������� ����� � ���������
   StatFile(MainFile.Name); //�������� ��������� ��������
 //���������� (������� ��������� ���� ��� ����� �������)��� �����
   CreateFile; //����� ��������� ������� ��������� �����
end;

procedure RunDecodeShan(FileName_: string);
begin
   MainFile.name:=FileName_;//������� ���
   //������������� ����� � ���������
   ExtractFile;//�������� ��������� ���������� ������
end;
end.
