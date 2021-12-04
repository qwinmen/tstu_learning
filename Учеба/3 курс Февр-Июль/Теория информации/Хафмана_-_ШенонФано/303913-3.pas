unit Haffman;

interface 

Uses
  Forms,ComCtrls, Dialogs;
const
   Count=4096;
   ArchExt='haf';
   dot='.';

//��� �������� ���������� ��� ������ ��������� ����� � ���
//������ ������
var
   FileToRead,FileToWrite: File;
   ProgressBar1:TProgressBar;
// ��������� ��� ������ � ������
// ������ - ����������� �����
procedure RunEncodeHaff(FileName_: string);
// ������ - ������������� �����
procedure RunDecodeHaff(FileName_: string);

implementation

Type
{��� ������� ��� ������������ ��������� ���������� ��������
������������� � �����}
   TByte=^PByte;
   PByte=Record
    //������ (���� �� ������� ASCII)
      Symbol: Byte;
      //������� ��������� ������� � ��������� �����
      SymbolStat: Integer;
      //������������������ �����, � ������� ������������� �������
      //������� ����� ������ ����� (������� �����) (� ���� ������ �� "0" � "1")
      CodWord: String;
   //������ �� ����� � ������ ���������� (�����)
      left, right: TByte;
   End;

{������ �� �������� �� ����������� , �.�. �������� ��������� ��
� ������������ �����}
   BytesWithStat = Array [0..255] of TByte;

   {������, ���������� � ����:
   ������ ��������� ���������� � ���� ���������� ���������,
   ������������� � ����� ���� �� ���� ���
   ���������  ������������� �������
   ��������� ��� ���������� ������� i-�� ��������}
   TStat =Object
      massiv: BytesWithStat;
      CountByte: byte;
      Procedure Create;//��������� ������������� �������
      Procedure Inc(i: Byte);
   End;

// ���������  ������������� ������� ���������� �� ��������� StatFile
   Procedure TStat.Create; //(291)
   var
      i: Byte;
   Begin //������ ������ ������ (ASCII), �������� ����������
   //� ������ ��������� � ��������� �� ����������
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
         //����� ������������� �� ��������� ���� ����������
      End;
   End;

{��������� ���  ���������� ������ ���������
i-�� �������� � ��������� ����� ���������� ������(310)}
   Procedure TStat.Inc(i: Byte);
   Begin //����������� �������� ���������� ������� [i] ���������
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
           // Name_[i]:='!';
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
         While (i>0) And (Name_[i]<>'.') Do //�� ��� ��� ����
         //�� ���������� '.'  !
         Begin
            Dec(i); //��������� ������� �� �������
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
   //�� �������� ������� �����  (743)
procedure SortMassiv(var a: BytesWithStat; LengthOfMass: byte);
   var
      i,j: Byte; //�������� ������
      b: TByte;
   Begin  //���������� �������������
      if LengthOfMass<>0
      Then
         for j:=0 to LengthOfMass-1 do
         Begin
            for i:=0 to LengthOfMass-1 do
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

   //��������� �������� ������������ ��������� ���������� ������
   //�� ������
   Procedure DeleteTree(Root: TByte);
   Begin
      Application.ProcessMessages;
      If Root<>nil
      Then
      Begin
         DeleteTree(Root^.left);
         DeleteTree(Root^.right);
         Dispose(Root);
         Root:=nil;
      End;
   End;

   //�������� ������ ������ ��� ������������� ����� Haffman (777)
   Procedure CreateTree(var Root: TByte; massiv: BytesWithStat;
                      last: byte);
var
Node: TByte;//����
Begin
     //sort_mass(massiv, last);
  If last<>0   //���� �� 0 �� �������� ������� ������
    Then
       Begin
         SortMassiv(massiv, last);//��������� �� ��������
        //������� ��������� �������
         new(Node);//������� ����� ����
         //����������� ��� ��� ���� ����� ����� ��������
         //�.�. ���������� ���������� ���� ���������
         Node^.SymbolStat:=massiv[last-1]^.SymbolStat + massiv[last]^.SymbolStat;
         Node^.left:=massiv[last-1];//�� ���� ������ ������ �� �����
         Node^.right:=massiv[last];//� ������ �����
         massiv[last-1]:=Node;// ������� ��� ��������� ��������
         //�� ������� �� ����� �������������� �� ��� ������
         //�������������� ����
         /////////////////  ��������� �� �������� �� �����
          if last=1//���� =1 �� ��
           Then
            Begin
             Root:=Node; //������������� �������� ����
            End
          Else
            Begin
             CreateTree(Root,massiv,last-1);//���� ��� �� ������
             //����� ������
            End;
       End
  Else//���� �������� last � ����� ������ =0 �.�. ����
  //�������� ���� � ��� �� ������ (���� ���� ������� ���
  //�� ������ ����� ��� �� ����������� ������ ������� �������)
    Root:=massiv[last];//�� ������� ������ ����� �� last
      Application.ProcessMessages;
End;

var
   //��������� ������� ��� �������� ���������� �����
   MainFile: file_;

//��������� ��� ������� ������� ������ ������ ������������� ���� ��
//���� ��� � �������� �����
procedure StatFile(fname: String);
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
   Try    //�� ������ ������
      Reset(f,1);//��������� ���� ��� ������
      MainFile.Stat.create;//�������� ����� ������������� �������
      //��� ������������� ����� (58)
      MainFile.Size:=FileSize(f);//����� ����������� �������
      // ������������� �����. ����������� ������� FileSize
      //���������� ������� � ������
      ///////////////////////
      countbuf:=FileSize(f) div count;//������� ����� �������
      //�� 4096 ���� ���������� � �������� �����
      lastbuf:=FileSize(f) mod count; // ������� �� ��������������
      // �������=(�������� �����)������� � ������ �� 4096
      //////////// ������ ���������� ��� ������� ������� � �����
      For i:=1 to countbuf do //������� ��������� ��� ����� ������(�� )
      Begin
         BlockRead(f,buf,count);
         for j:=1 to count do
         Begin //�� ���� �� ������ ������� �� 1 �� 4096 � � �����
         //����������� �������� ������� Stat.inc(�������)
         //�� �� ����� ������� � ���������� �� ������ ���� �
         //� ������� �������� ���  �� ������ ����������� ��������
         //SymbolStat(������� ���������) �� �������
            MainFile.Stat.inc(buf[j]);//(������ 80)
            Application.ProcessMessages;
         End;
         Application.ProcessMessages;
      End;
      /////////////
      If lastbuf<>0 //����� ������������ ���������� ��� ����������
      //����
      Then
      Begin
         BlockRead(f,buf,lastbuf);
         for j:=1 to lastbuf do
         Begin
            MainFile.Stat.inc(buf[j]);//(80)
            Application.ProcessMessages;
         End;
         Application.ProcessMessages;
      End;
      CloseFile(f);//��������� ����
   Except  //���� ����� �� ��� �� ������� ���������
      ShowMessage('������ ������� � �����!')
   End;
End;

 {������� ������ � ������ Found(Tree: TByte; i: byte): Boolean;
 ��������� Tree:������ ������ ��� ��� ����, i:������ ������� �����
 �������� ����; ���������� ������ �������� � ������� HSymbolToCodWord.
 �������� ������:
 ������� HSymbolToCodWord �������� ������� Found(Tree^.left,i) �.� c
 ���������� ������ �  ����� ����� ������ ������� �� �����. ������� Found
 ����� ���������� �������� ���� ���� �������� �� ����� ������ ����
 �� ����� �� �������� �������. ���� ��� �������� ������� ������ �� Found
 ����� true � � HSymbolToCodWord ��������� ������ ����� ����
 Found(Tree^.left,i):true ��� �������� ����  Found(Tree^.right,i):true
 ����� HSymbolToCodWord �������� Found, �� ��� � ���������� �����������
 �� ������, � �������� �� ��� ����, ����������� ����� ��� ������, �
 ����������� �� ���� ������� ���������� ������ (� ����� ����� �� �����
 ��� ������ ������(���� ����� ��� �� ���� ����� ��� ������))
 ��� ����� ����������� �� ��� ��� ���� HSymbolToCodWord �� �����
 ��������� ������ �.�. ��������� ������� ����� Tree=���� ��� ���������
 ������ (�.�. ��������� �� ����� � ������ ����� =nil)����� ��� ����������
 ������� ��� ���������� �������� ��� Tree=nil. ����� Found ����� ��������
 Tree= ���� ��� �������� ������� ������, ���������� �������� Found=True
 � ������� � ���������� ������� HSymbolToCodWord ��� � ��������
 HSymbolToCodWord � ����� ��������� '+'-���������� ��� ������� �����
 �������. ���� ����� HSymbolToCodWord ����� � ��������� � �������
 SymbolToCodWord  �������� �������� �����+'+'�� ����� ��� �������� ��������
 � ������ '+' ����� �����, � ���������� ����� Stat.massiv[i]^.CodWord
 ����� ���������� �������� �������� �����}
Function Found(Tree: TByte; i: byte): Boolean;
Begin
   Application.ProcessMessages;
   if (Tree=nil)//���� ����� nil ��
    Then
      Found:=False //������� ���������� ������
    Else  //�����
   Begin //���� ��������� �� ����� ����� ����� ���
   //�� ������ nil, � ��������� �� ������ ����� ��������
     if ((Tree^.left=nil) or (Tree^.right=nil))
      and (Tree^.Symbol=i)
       Then
         Found:=True {�� ������� ���������� ����, ��� ������ ������
� ���������� ������ � ���������� � ��������� � ������� }
       Else //����� ������� ���������� ����� �� ������ �����
       //�.�.���������� �������� ���� ���� � ������� �����������
         Found:=Found(Tree^.left, i) or Found(Tree^.right, i);
   End;
End;
//������� ��� ����������� ���������� ������������� ������ ������������������
//����� ��� ��������� ����� i
Function HSymbolToCodWord(Tree: TByte; i: Byte): String;
Begin
   Application.ProcessMessages;
   if (Tree=nil)
   Then
      HSymbolToCodWord:='+=='
   Else
   Begin
      if (Found(Tree^.left,i))//���� ������ ��������� � ����� �����
      //� ����������� �� ���� ��� ������� Found
      Then //�� � ������ ��������� ������ ���� � �������� HSymbolToCodWord
      //�� ���� �������� ������ ����
         HSymbolToCodWord:='0'+HSymbolToCodWord(Tree^.left,i)
      Else
      Begin
         if Found(Tree^.right,i)//���� ������ ��������� � ������ �����
         Then //�� � ������ ��������� ������ ������� � �������� HSymbolToCodWord
      //�� ���� �������� ������� ����
            HSymbolToCodWord:='1'+HSymbolToCodWord(Tree^.right,i)
         Else //�����
         Begin //���� ������ ������
            If (Tree^.left=nil) and (Tree^.right=nil)
               and (Tree^.Symbol=i)
            Then //HSymbolToCodWord  //�������� ������ ������
               HSymbolToCodWord:='+'
            Else  //�����
               HSymbolToCodWord:=''; //������� ���
         End;
      End;
   End;
End;

//��������������� ������� ��� ����������� �������� �����
//������ ������������������ ����� ��� ��������� ����� i (� ������
//���� �������������� ������, ����� �������� ���� ������� ����� �� ������
//� ���� �� �������)
Function SymbolToCodWord(Tree: TByte; i: Byte): String;
var
   s: String;
Begin //������� �-�� ������ ������� ����
   s:=HSymbolToCodWord(Tree, i);
   s:=s;
   If (s='+'){���� ������� HSymbolToCodWord ������� ������
    ���������� '+' �.�. �������� ���� ������� �� ������ � ���� ��
    ������� �� �������� ����� ����������� ������ �� '0' }
     Then
      SymbolToCodWord:='0'
     Else {����� ��������� ������ �� ���� ������ �.�. ������� '+'
     ������� ���� ��� ������ ������}
      SymbolToCodWord:=Copy(s,1,length(s)-1);
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
   For j:=1 to i do //�������� � ������� �� ������� ��������
   //������� �� ����������
   Begin
      buf[j]:=0;//�������� ��� ������� ������ �
      //������� ����� ������
      ///////////////////////////
      For k:=1 to 8 do//�������� � ������
      Begin
         If buffer[(j-1)*8+k]='1'{������� � ������ ��� �������
������� ����� ���������� � ���� ������������������ ���
(����� ������������� � (j-1) �������� ������ buffer ������
�������� �� ��� ��� ����� ������������ ������  ��
������ '0' � '1'. ��� ������ �� �����  ��������������� � ����,
������� ������ ����� ��������� ������� ������������������ ���)}
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
   End; //���������� � ���� ����������� �����
   BlockWrite(FileToWrite,buf,i);
   Delete(buffer,1,i*8);//������� �� �������� ������ �� ��������
   //������� ��� ��������()
End;

//��������� ��� ������������� ������ ���������� ������� ����� � �����
Procedure WriteInFile_(var buffer: String);
var
   a,k: byte;
Begin
{��� ��� ��� ��������� �������� ��������� ������� ������� � ������
������ �� ���� ��������� ����, �� ���� �������� ���������
������� ������ � ����. ����� ������ ������� � buffer ������
������ ����������������� �� �� ����� 8 ��������. �� �����
�� ���������� �������� � ���� ��� �� �� ��� �� ������� ���������.
����� ������������� � ���������� � ��� ���� � 1 � ����� ����������
��������� ��������: ������������� �� ����� �� ��� �������� �
buffer � ���� ������� ������ '0' �� � �������������� ���� ���������� �
��������� �������� xor (�.�. 1 xor 1   ��� ���� 0) �.�. ��������������
��� ����������� � 0 ������������ ���� ���������� � ��������� � ��� ��
��������� ��� � ����. ���������� ���� ����� ���������}
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

//������� ����� ���� Integer � ������ �� ������� ����.
Procedure IntegerToByte(i: Integer; var mass: Integer_);
var
   a: Integer;
   b: ^Integer_;
Begin
   b:=@a;// ��������� ������ ���������� � � b
   a:=i;//� � ���������� ���� �������� ���� integer
   mass:=b^;{�������������� b � ��������� ��������� � mass
� ���������� ������ ����� ���� ����� ���� Integer
������ � ������ �� 4 ����. ��� ��������� ��� ���� ��� ,�� ��
������ � ���� ���������� �� ������}
End;

//������� ������� �� ������� ���� � ����� ���� Integer.
Procedure ByteToInteger(mass: Integer_; var i: Integer);
var
   a: ^Integer;
   b: Integer_;
Begin
   a:=@b;// ��������� ������ ���������� b � �
   b:=mass;//b ����������� �������� mass
   i:=a^;{�������������� � � ��������� ��������� � i
� ���������� ������ ����� ���� ������ �� 4 ����
������ � ����� ���� Integer. ��� ��������� ��� ���� ��� �� ��
����� ������ ���� �������� ���� Integer}
End;

//��������� �������� ��������� ������
Procedure CreateHead;
var
   b: Integer_;
   //a: Integer;
   i: Byte;
Begin
//���������� ������ ��������� �����
   IntegerToByte(MainFile.Size,b);
   BlockWrite(FileToWrite,b,4);

//���������� ���������� ������������ ����
   BlockWrite(FileToWrite,MainFile.Stat.CountByte,1);

{�������� ����� �� ����������� (�� ������ ������ ��������
 �� ���� ����. ������ ���� �������� ��� ������ ����� ����
 4 ����� �� ����������� (Intege �������� 4 �����)}
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
{buffer_ ��� ������ ���������� � ���� ������ �� ���� ArrOfByte
������� ���� ByteCount (��������� ��� ����� �������������
������ ��������������� ���� � ����)� �������� ������� (���������
��� ����������� ����� ���������� ���� ������ ���� ���������������
��� ������ �� ����� ������ ������� ���������� ����� �� �������
���������������� �������)}
   buffer_=object
      ArrOfByte: Array [1..MaxCount] of Byte;
      ByteCount: Integer;
      GeneralCount: Integer;
      Procedure CreateBuf;//��������� �������������
      Procedure InsertByte(a: Byte);//��������� �������
//����������������� ������ � ����
      Procedure FlushBuf;
   End;
      /////////////////////////////
      Procedure buffer_.CreateBuf;
      Begin
         ByteCount:=0;//������������� ����������
         GeneralCount:=0;
      End;
      ////////////////////////////////////////
Procedure buffer_.InsertByte(a: Byte);
{� ���������� � �� ������� �������� ������������������ �����,
������� �������� � ���������� ���������}
      Begin //�� ��� ��� ���� GeneralCount ������
      //������� ���������� ����� �����
         if GeneralCount<MainFile.Size
         Then
         Begin
            inc(ByteCount); //����������� ���������������
            //��������  �� �������
            inc(GeneralCount);
            ArrOfByte[ByteCount]:=a;//�������� � ������ ArrOfByte
//�������� ���������� � ���������� �
            //////////////////////////
            if ByteCount=MaxCount //����  ByteCount=MaxCount
//�� ���������� ���������� ������� � ��������������� ����
            Then
            Begin
               BlockWrite(FileToWrite,ArrOfByte,ByteCount);
               ByteCount:=0;
               //Form1.ProgressBar1.Position:=form1.ProgressBar1.Position+1;
            End;
         End;
      End;
      ////////////////////////////
Procedure Buffer_.FlushBuf;
//��������� ������ ���������� ������� ����
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
   CurrentPoint: TByte;
Begin
//���������� ������� ����� ������� �� 4 ����� � ������
//����� ��� ���������
   CountBuf:=MainFile.FileSizeWOHead div count;
//���������� ������� �������� ���� �� ��������
//� ����� ������ �� 4 ����� � ������ ����� ��� ���������
   LastBuf:=MainFile.FileSizeWOHead mod count;
   MainBuffer.CreateBuf;//������������� ����������
   CurrentPoint:=MainFile.Tree;//���������� �������
//������� �� ������ ������
//�������� ���������
   For i:=1 to CountBuf do
   Begin//��������� �� ������� ����� ������ � �����
      BlockRead(FileToRead,buf,count);
      for j:=1 to Count do //�� ������ ��������
      //������������� �����
      Begin
         for k:=1 to 8 do//������������� ���� �� 1 �� 8
         //���������� �����
         Begin  {�������� ���� � �������. �� ����� �� 1 �� 8
������������� �������� ��� ��� �� 8 �� 1. �� ����� ������������
�������� �������� ������ ����� shl � ��������� �������� and.
� ����� �� ���������� ��������� �������: ������� ���������������
������� ��� (8-�)=1 � ������������ ���������� �������� and,
���� ��� ����� 1 �� (1 and 1)=1 �� ��������� ��������� �������
������� ������ � ������ �� ������ ����, ���� �� ��� ����� 0
�� (0 and 1)=0 � ��������� ��������� ������� ������� ������
� ������ �� ����� ����. ��� ����� ����������� �� ��� ��� ����
�� ���������� �������, ������� ������� ���������� ��������
������� ((CurrentPoint^.left=nil) or (CurrentPoint^.right=nil))
����� ���� ����� ������� ��������� ������� �����, ����� ������
����� �� ������� �� ������� ����� ����� ������������� �� ������}
            If (Buf[j] and (1 shl (8-k)))<>0
            Then
               CurrentPoint:=CurrentPoint^.right
            Else
               CurrentPoint:=CurrentPoint^.left;

            if (CurrentPoint^.left=nil) or (CurrentPoint^.right=nil)
            Then
            Begin
               MainBuffer.InsertByte(CurrentPoint^.Symbol);
               CurrentPoint:=MainFile.Tree;
            End;

            Application.ProcessMessages;
         End;
         Application.ProcessMessages;
      End;
   End;
   If LastBuf<>0
   Then
   Begin//������ ����� ����� ��������� ���������� �����������
      BlockRead(FileToRead,Buf,LastBuf);
      for j:=1 to LastBuf do
      Begin
         for k:=1 to 8 do
         Begin
            If (Buf[j] and (1 shl (8-k)))<>0
            Then
               CurrentPoint:=CurrentPoint^.right
            Else
               CurrentPoint:=CurrentPoint^.left;

            if (CurrentPoint^.left=nil) or (CurrentPoint^.right=nil)
            Then
            Begin
               MainBuffer.InsertByte(CurrentPoint^.Symbol);
               CurrentPoint:=MainFile.Tree;
            End;

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
   b: Integer_; // �������� ������ �����
   SymbolSt: Integer;//���������� �������
   count_, SymbolId, i: Byte;//SymbolId=Symbol ������ �����
   // �� ������ ���������� ���������� � ���������
Begin
   try
//������ �������� ������ �����
      BlockRead(FileToRead,b,4);
      ByteToInteger(b,MainFile.size);

//������ ���������� ������������ ������
      BlockRead(FileToRead,count_,1);
      {}{}{�������� ��������� ������������� �������}
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
//�������� ��������� �������� ������
      CreateTree(MainFile.Tree,MainFile.stat.massiv,MainFile.Stat.CountByte);
      /////////////
//�������� ��������� ���������� �����
      CreateDeArc;
      //////////////
//�������� ��������� ����������� ������
      DeleteTree(MainFile.Tree);

   except
      ShowMessage('����� ��������!');
   End;
End;

//��������� ���������� ������
Procedure ExtractFile;
Begin
   AssignFile(FileToRead,MainFile.Name);
   //��������� ��� ���� ������� ��������� ���������
   //�������� ����� ��������� ����� ����������������� �����
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
   buffer: String;//������ � ������� ����� ������������
//������������������ �� ������� ����
   ArrOfStr: Array [0..255] of String;
   i,j: Integer;
   //////////////
   buf: Array [1..count] of Byte;//������ � �������
//����� ��������� ������ �� ������������� �����
   CountBuf, LastBuf: Integer;
Begin

   Application.ProcessMessages;
   AssignFile(FileToRead,MainFile.Name);
   AssignFile(FileToWrite,MainFile.ArcName);
   Try
      Reset(FileToRead,1);
      Rewrite(FileToWrite,1);
//�������������� ������  ����� � ������� �����
//�������� ������� �����
      For i:=0 to 255 Do ArrOfStr[i]:='';
//�������  � ������ ����� ������� ����� ��������������
//����� ��������
      For i:=0 to MainFile.Stat.CountByte do
      Begin
         ArrOfStr[MainFile.Stat.massiv[i]^.Symbol]:=
         MainFile.Stat.massiv[i]^.CodWord;
         Application.ProcessMessages;
      End;
//����� ����� ����� ���������� ������� �� 4 ����� ����� ���������� �
//��������� �����
      CountBuf:=MainFile.Size div Count;
//������� ��������� ���� ��� ������ �� �������� � �����
//����������� �������� CountBuf
      LastBuf:=MainFile.Size mod Count;
      Buffer:='';//�������� �����
      /////////////
      CreateHead; //�������� ��������� �������� ��������� �����
      /////////////
  //�������� ����� ������� ����
      for i:=1 to countbuf do
      Begin
//��������� �� ����� �� 4 �����
         BlockRead(FileToRead,buf,Count);
         //////////////////////
         For j:=1 to count do
         Begin
//������ ����� �� ������� ����
            buffer:=buffer+ArrOfStr[buf[j]];
//���� ����� buffer �������� ������� 8*4096 (��� ��������
//�������� ������ ��������� ������ ������ �������� 4096����)
//�� �������� ��������� ������ � ����
            If Length(buffer)>8*count
            Then
               WriteInFile(buffer);
            Application.ProcessMessages;
         End;
        // ProgressBar1.Position:=100 div countbuf;
      End;
//������ ���������� ������� ����
      If lastbuf<>0
      Then
      Begin
//��������� � ������ �� ����� ���������� �����
         BlockRead(FileToRead,buf,LastBuf);
//������ buffer ������ �� ������� ����
         For j:=1 to lastbuf do
         Begin
            buffer:=buffer+ArrOfStr[buf[j]];
            If Length(buffer)>8*count
//���� ��� ������ �������� �������� 8*4096 (� ��� ����� �����
//�����), �� �������� ��������� ������ � ����
            Then
               WriteInFile(buffer);
            Application.ProcessMessages;
         End;
      End;
//������� ��������� ������ ���������� ������� ������� ����
      WriteInFile_(buffer);
      CloseFile(FileToRead);
      CloseFile(FileToWrite);
   Except
      ShowMessage('������ �������� ������');
   End;
End;

//������� ��������� ��� �������� ��������� �����
Procedure CreateFile; //(802)
var
   i: Byte;
Begin
   With MainFile do
   Begin
      {���������� ������� ������ � ��������� (192)}
      SortMassiv(Stat.massiv,stat.CountByte);

      {����� ����� ��������������� ������ �� �������
      (ACSII) �������� ��������. � CountByte ����� �������
      ���������� ���� ����� �������� }
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

      Stat.CountByte:=i;{����������� �������� ��������
CountByte. ��� �������� ��� � ������������ �����
������������ ����� ���������� �� 256 ���������
��������. ����� ������������ ��� ���������� ����� ������}

{�������� ������ ������. ������� � ��������� ���������
��������� Tree=nil-��� ���������� ����� ���������
����� ������ ��������� ����� ,Stat.massiv-������ � ���������
� ��������������� �� �����������,� ��� �� ��������� ��
������ � ����� ������,Stat.CountByte-���������� ������������
�������� � ����������� ����� (230)}
      CreateTree(Tree,Stat.massiv,Stat.CountByte);

{��������� � ������ ������ � ������� ��� ������� ���������������
������� �����. ���� ��������� �������� �������
SymbolToCodWord(Tree:TByte(��������� �� ������ ������. �� � ���
����������� � ���������� ������ ��������� CreateTree, Symbol:byte):
String ������� ����� ��� ������ ���������� ������� ����� ()}
      for i:=0 to Stat.CountByte do
       Stat.massiv[i]^.CodWord:=SymbolToCodWord(Tree,stat.massiv[i]^.Symbol);

//����� ��� ����
      CreateArchiv;

//������� ��� �������� ������
      DeleteTree(Tree);

//�������������� ���������� �����
      MainFile.Stat.Create;
   End;
End;
//�������� ��������� ������ �����
procedure RunEncodeHaff(FileName_: string);
begin
   MainFile.Name:=FileName_;//������� ���
//������������� ����� � ���������
   StatFile(MainFile.Name); //�������� ��������� ��������
//���������� (������� ��������� ���� ��� ����� �������)
//��� ����� (������ 274)
   CreateFile; //����� ��������� ������� ��������� ����� (737)
end;
//�������� ��������� ���������������� �����
procedure RunDecodeHaff(FileName_: string);
begin
   MainFile.name:=FileName_;//������� ���
   //������������� ����� � ���������
   ExtractFile;//�������� ��������� ���������� ������
end;
end.
