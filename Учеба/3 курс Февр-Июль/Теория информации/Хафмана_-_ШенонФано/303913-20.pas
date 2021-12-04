unit Shannon;

interface


Uses
  Forms, Dialogs;
const
   Count=4096;
   ArchExt='she';
   dot='.';

//две файловые переменные для чтения исходного файла и для
//записи архива
var
   FileToRead,FileToWrite: File;
   Str1:String='';

// Процедуры для работы с файлом
// Первая - кодирование файла
procedure RunEncodeShan(FileName_: string);
// Вторая - декодирование файла
procedure RunDecodeShan(FileName_: string);


implementation

Type
   //тип элемета для динамической обработки статистики байтов
   TByte=^PByte;
   PByte=Record
 //Символ (один из символв ASCII)
      Symbol: Byte;
 //статистика символа
      SymbolStat: Integer;
 //последовательность битов, в которые преобразуется текущий
 //элемент после работы древа (Кодовое слово) (в виде строки из "0" и "1")
      CodWord: String;
 //ссылки на левое и правое поддеревья (ветки)
      left, right: TByte;
   End;

//массив из символов со статистикой , т.е. частотой появления их
//в архивируемом файле
   BytesWithStat = Array [0..255] of TByte;

   //объект, включающий в себя:
   // массив элементов содержащий в себе количество элементов,
   // встречающихся в файле хотя бы один раз
   // процедура  инициализации объекта
   // процедура для увеличения частоты i-го элемента
   TStat =Object
      massiv: BytesWithStat;
      CountByte: byte;
      Procedure Create;//процера инициализации обьекта
      Procedure Inc(i: Byte);
   End;
//процедура инициализации объекта вызввается из
   Procedure TStat.Create;
   var
      i: Byte;
   Begin
      CountByte:=255;
      For i:=0 to CountByte do
      Begin
         New(massiv[i]);//создаём динамическую переменную
         //и устанавливаем указатель на неё
         massiv[i]^.Symbol:=i;
         massiv[i]^.SymbolStat:=0;
         massiv[i]^.left:=nil;
         massiv[i]^.right:=nil;
         Application.ProcessMessages;//Высвобождаем ресурсы
         //чтобы приложение не казалось зависшим, иначе все ресуры процессора
         //будт задействованы на обработку кода приложения
      End;
   End;

//  процедура для для вычисления частот появления
// i-го элемента в сжимаемом файле. Вызывается из
   Procedure TStat.Inc(i: Byte);
   Begin
      massiv[i]^.SymbolStat:=massiv[i]^.SymbolStat+1;
   End;

Type
   //объект включающий в себя:
   //имя и путь к архивируемому файлу
   //размер архивируемого файла
   //массив статистики частот байтов
   //дерево частот байтов
   //функцию генерации по имени файла имени архива
   //функцию генерации по имени архива имени исходного файла
   //функцию для определения размера файла без заголовка
   //иными словами возвращающую смещение в архивном файле
   //откуда начинаются сжатые данные
   File_=Object
      Name: String;
      Size: Integer;
      Stat: TStat;
      Tree: TByte;
      Function ArcName: String;
      Function DeArcName: String;
      Function FileSizeWOHead: Integer;
   End;

   // генерация по имени файла имени архива
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

 // генерация по имени архива имени исходного файла
Function File_.DeArcName: String;
   Var
      i: Integer;
      Name_: String;
   Begin
      Name_:=Name;
      if pos(dot+ArchExt,Name_)=0
      Then
      Begin
         ShowMessage('Неправильное имя архива,'#13#10'оно должно заканчиваться на ".'+ArchExt+'"');
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
               ShowMessage('Неправильное имя архива');
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
        //размер исходного файла записывается в 4 байтах
        //количество оригинальных байт записывается в 1байте
        //количество байтов со статистикой - величина массива
      End;
   //процедура сортировки массива с байтами (сортировка производится
   //по убыванию частоты байта
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

   {Процедура построения древа частот Shennon}
procedure CreateTree(var Root: TByte;massiv: BytesWithStat;
                      last: byte);
//процедуа деления группы
procedure DivGroup(i1, i2: byte);
{процедура создания кодовых слов. Вызывается после того как
отработала процедура деления массива на группы. В полученном
первом массиве мы ко всем одовым словам добавляем символ '0'
во втором символ единицы}
procedure CreateCodWord(i1, i2: byte;Value:string);
 var
 i:integer;
begin
  for i:=i1 to i2 do
  massiv[i]^.CodWord:=massiv[i]^.CodWord+Value;
end;
//Процедуа деления массива
var
k, i : byte;
c, oldc, s, g1, g2 :Single;
begin
  //Пограничное условие, чтобы рекурсия у нас
  // не была бесконечной
  if (i1<i2) then
  begin
    s := 0;
    for i := i1 to i2 do
    s := s + massiv[i]^.SymbolStat;//Суммируем статистику частот
//появления символов в файле
    k := i1; //Далее инициализируем переменные
    g1 := 0;
    g2 := s;
    c := g2 - g1;
{Алгоритм: Переменные i1 и i2 это индексы
начального и соответственно конечного элемента массива.
в k будем вырабатывать индекс пограничного элемента массива
по которому мы его будем делить. с переменная в кторой будет
хранится разность между g2 и g1. Потребуется для определения
k. Сначала суммируем статистику появления символов в файле
(Она как ни странно будет равна размеру файла =: т.е.
количеству байт в нём)). Далее инициализируем переменные.
Затем цикл в котором происходит следующее к g1 нулевая
статистика прибавляем статстику massiv[k] элемента массива
massiv[k], а из g2 вычитаем ту же статистику. Далее oldc:=c
это нам надо для определения дошли мы до значения k где
статистика обойх частей массива равна. c := abs(g2-g1)
именно по модулю иначе у нас не выполнится условие (c >= oldc)
в том случае когда (g2<g1). Далее проверяется условие c > oldc,
если оно верно то  мы уменьшаем k  на единицу, если не то
оставляем k какое есть это и будет значение элемента в котором
сумм статистик масивов примерно равны. Далее просто рекурсивно
вызываем Эту же процедуру  пока массивы полностью не разделятся
на одиночные элементы или листья    }
    repeat
      g1 := g1 + massiv[k]^.SymbolStat;
      g2 := g2  - massiv[k]^.SymbolStat;
      oldc := c;
      c := abs(g2-g1);
      Inc(k);
    until (c >= oldc) or (k = i2);
    if c > oldc then
      begin
       Dec(k); //вырабатываем значение k2
      end;
    CreateCodWord(i1, k-1,'0'); //Заполняем первый массив
    //элементами
    CreateCodWord(k, i2,'1'); //Заполняем второй массив
    //элементами
    DivGroup(i1, k-1);//снова вызываем процедуру
    //деления массива (первой части)
    DivGroup(k, i2);// вызываем процедуру
   end;

end;

begin

 DivGroup(0,last);

end;

var
   //экземпляр объекта для текущего сжимаемого файла
   MainFile: file_;

//процедура для полного анализа частот байтов встречающихся хотя бы
//один раз в исходном файле
procedure StatFile(Fname: String);
var
   f: file;  //переменная типа file в неё будем писать
   i,j: Integer;
   buf: Array [1..count] of Byte;//массив=4кБ содержащий в
   //себе часть архивируемого файла до 4кБ делается это для ускорения
   //работы програмы
   countbuf, lastbuf: Integer;//countbuf переменная которая показывает
   //какое целое количество буферов=4кБ содержится в исходном файле
   //для анализа частот  символов встречающих в исходнлм файле
   //lastbuf остаток байт которые неободимо будет проанализировать
Begin
   AssignFile(f,fname);//связываем файловую переменню f
   //с архивируемым файлом
   Try
      Reset(f,1);//открываем файл
      MainFile.Stat.create;//вызываем метод инициализации объекта
      //для архивируемого файла
      MainFile.Size:=FileSize(f);//метод определения размера
      // архивируемого файла
      ///////////////////////
      countbuf:=FileSize(f) div count;//столько целых буферов
      //по 4096 байт содержится в исходном файле
      lastbuf:=FileSize(f) mod count; // остаток (последий буфер)разница
      //в байтах до 4096
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
      If lastbuf<>0 //просчитываем статистику для оставшихся
      //байт
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
      ShowMessage('ошибка доступа к файлу!')
   End;
End;

//процедура записи сжатого потока битов в архив
Procedure WriteInFile(var buffer: String);
var
   i,j: Integer;
   k: Byte;
   buf: Array[1..2*count] of byte;
Begin
   i:=Length(buffer) div 8; // узнаем сколько получится
   //байт в каждой последовательности
   //////////////////////////
   For j:=1 to i do //  работаем с байтами
   Begin
      buf[j]:=0;// обнуляем тот элемент мссива в
      //который будем писать
      ///////////////////////////
      For k:=1 to 8 do  //работаем с битами
{находим в строке тот элемент
который будем записывать в виде последовательности бит
(будем просматривать с (j-1) элемента строки buffer восемь
элментов за ним тем самым сформируется строка  из
восьми '0' и '1'. Эту строку мы будем  преобразовывать в байт,
который должен будет содержать такуюже последовательность бит)}
      Begin
         If buffer[(j-1)*8+k]='1'
         Then
{Преобразование будем производить с помощью операции битового
сдвига влево shl и логической опереоции или (or). Делается
это так поверяется условие buffer[(j-1)*8+k]='1' если в
выделенной строке из восьми символов (мы просматриваем её по
циклу от первого элемента до восьмого), элемент, индекс
которого равен счётчику цикла к, равен единице, то к
соответствующему биту (номер которого в байте равен
переменной цикла к) будет применена операция or (0 or 1=1)
т.е. это бит примет значение 1. Если в строке будет
ноль то и соответствующий бит будет равен нулю. (нам его не
требуется устанавливать т.к. в начале работы с каждым байтом
мы его обнуляем)}
            buf[j]:=buf[j] or (1 shl (8-k));
         Application.ProcessMessages;
      End;
      Application.ProcessMessages;
   End;
   BlockWrite(FileToWrite,buf,i);
   Delete(buffer,1,i*8);
End;

//процедура для окончательной записи остаточной цепочки битов в архив
Procedure WriteInFile_(var buffer: String);
var
   a,k: byte;
Begin
   WriteInFile(buffer);
   If length(buffer)>=8
   Then
      ShowMessage('ошибка в вычислении буфера')
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

//перевод целого числа в массив из четырех байт.
Procedure IntegerToByte(i: Integer; var mass: Integer_);
var
   a: Integer;
   b: ^Integer_;
Begin
   b:=@a;
   a:=i;
   mass:=b^;
End;

//перевод массива из четырех байт в целое число.
Procedure ByteToInteger(mass: Integer_; var i: Integer);
var
   a: ^Integer;
   b: Integer_;
Begin
   a:=@b;
   b:=mass;
   i:=a^;
End;

//процедура создания заголовка архива
Procedure CreateHead;
var
   b: Integer_;
   //a: Integer;
   i: Byte;
Begin
   //Размер несжатого файла
   IntegerToByte(MainFile.Size,b);
   BlockWrite(FileToWrite,b,4);

   //Количество оригинальных байт
   BlockWrite(FileToWrite,MainFile.Stat.CountByte,1);

   //Байты со статистикой
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
Procedure buffer_.InsertByte(a: Byte); //в а передаём уже
// раскодированный символ котрый надо записать в файл
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
Procedure Buffer_.FlushBuf; //сброс буфера
      Begin
         If ByteCount<>0
         Then
            BlockWrite(FileToWrite,ArrOfByte,ByteCount);
      End;
//создание деархивированного файла
Procedure CreateDeArc;
var
   i,j: Integer;
   k: Byte;
   //////////////
   Buf: Array [1..Count] of Byte;
   CountBuf, LastBuf: Integer;
   MainBuffer: buffer_;
   BufSearch:string;
{Процедура поиска символа, кторый соотвествуеткодовому
слову которое передаётся вызывающей функцией как параметр.
Алгоритм: Вызывающая ф-ия CreateDeArc вырабатывает значение
символа из разархивируемого файла и вызывает ф-ию
SearchSymbol (Str:string); с параметром Str в котором находится
выработанны символ. Ф-ия SearchSymbol прибавляет этот символ к
строке Str1 в которой формируется кодовое слово}
Procedure SearchSymbol (Str:string);
var
v:integer;
SearchStr:String;//вспомогательная переменная в которую
//загоняются кодовые слова для сравнения их с Str1
a:byte;//переменная в которой будет находится найденный
//символ
begin
  Str1:=Str1+Str;//растим кодовое слово
  For v:=0 to  MainFile.Stat.CountByte do
    begin //производим поиск в массиве
     SearchStr:=MainFile.Stat.massiv[v]^.CodWord ;
       If (SearchStr=Str1) Then
        begin
//если нашли то в а загоняем значение символа
          a:=MainFile.Stat.massiv[v]^.Symbol;
//вызываем процедуру записи символа
          MainBuffer.InsertByte(a);
//обнуляем строковую переменную
          Str1:='';
//выходим из цикла
          Break;
        end;
    end;
end;

Begin
   BufSearch:='';{переменная в которой хранится
выработанный символ, который будет передаватся в
процедуру SearchSymbol}
   CountBuf:=MainFile.FileSizeWOHead div count;
   LastBuf:=MainFile.FileSizeWOHead mod count;
   MainBuffer.CreateBuf;

   For i:=1 to CountBuf do
     Begin
      BlockRead(FileToRead,buf,count);
      for j:=1 to Count do
       Begin
{Выделяем байт в массиве. По циклу от 1 до 8
просматриваем значения его бит c 8 до 1. Для этого используется
операция битового сдвига влево shl и логиеская операция and.
В цикле всё происходит следующим образом: Сначала просматривается
старший бит (8-к)=7 и производится логическая операция and,
если бит равен 1 то (1 and 1)=1 и в BufSearch:='1', если же
бит равен 0 и (0 and 1)=0 и в BufSearch:='1' }
        for k:=1 to 8 do
         Begin
            If ((Buf[j] and (1 shl (8-k)))<>0 ) Then
              begin
               BufSearch:='1';
//вызываем процедуру SearchSymbol
               SearchSymbol (BufSearch);
//обнуляем поисковую переменную
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
  Then //аналогично вышесказанному
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


//процедура чтения заголовка архива
Procedure ReadHead;
var
   b: Integer_;
   SymbolSt: Integer;
   count_, SymbolId, i: Byte;
Begin
   try
      //узнаем исходный размер файла
      BlockRead(FileToRead,b,4);
      ByteToInteger(b,MainFile.size);

      //узнаем количество оригинальных байтов
      BlockRead(FileToRead,count_,1);
      {}{}{}
      MainFile.Stat.create;
      MainFile.Stat.CountByte:=count_;
      //загоняем частоты в массив
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
      ShowMessage('архив испорчен!');
   End;
End;

//процедура извлечения архива
Procedure ExtractFile;
Begin
   AssignFile(FileToRead,MainFile.Name);
   AssignFile(FileToWrite,MainFile.DeArcName);
   try
      Reset(FileToRead,1);
      Rewrite(FileToWrite,1);

//процедура чтения шапки файла
      ReadHead;

      Closefile(FileToRead);
      Closefile(FileToWrite);

   Except
      ShowMessage('Ошибка распаковки файла');
   End;
End;

//вспомогательная процедура для создания архива
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
      ShowMessage('Ошибка создания архива');
   End;
End;

//главная процедура для создания архивного файла
Procedure CreateFile;
var
   i: Byte;
Begin
   With MainFile do
   Begin
      {сортировка массива байтов с частотами}
      SortMassiv(Stat.massiv,stat.CountByte);

      {поиск числа задействованных байтов из
      таблицы возмжных символов. В count_byte будем хранить
      количество этох самых байт }
      i:=0;//обнуляем счётчик
      While (i<Stat.CountByte) //до тех пор пока счётчик
      //меньше количества задействовнных байт CountByte
      //и статистика байта (частота появления в файле)
      //не равна нулю  делаем
        and (Stat.massiv[i]^.SymbolStat<>0) do
      Begin
         Inc(i); //увеличиваем счётчик на единицу
      End;

      //////////////////////
      If Stat.massiv[i]^.SymbolStat=0 //если дошли до символа
      //с нулевой встречаемостью в файле то
      Then
          Dec(i); //уменьшаем счётчик на единицу тоесть возвращаемся
           //назад это будет последний элемент
      //////////////////////

      Stat.CountByte:=i;//присваиваем значение счётчика
      //count_byte. Это означает что в архивируемом файле
      //используется такое количество из 256 возможных
      //символов. Будет исползоватся для построения древа частот

      {создание дерева частот. Передаём в процедуру начальные
      параметры Tree=nil-эта переменная будет содержать
      после работы процедуры древо ,Stat.massiv-массив с символами
      и соответствующей им статистикой,а так же указанием на
      правое и левой дерево,Stat.CountByte-количество используемых
      символов в архивирумом файле }
      CreateTree(Tree,Stat.massiv,Stat.CountByte);

      //пишем сам файл
      CreateArchiv;

      //Удаляем уже ненужное дерево
      //DeleteTree(Tree);

      //Инициализируем статистику файла
      MainFile.Stat.Create;
   End;
End;

procedure RunEncodeShan(FileName_: string);
begin
   MainFile.Name:=FileName_;//передаём имя
   //архивируемого файла в программу
   StatFile(MainFile.Name); //запускем процедуру создания
 //статистики (частоты появления того или иного символа)для файла
   CreateFile; //вызов процедуры созданя архивного файла
end;

procedure RunDecodeShan(FileName_: string);
begin
   MainFile.name:=FileName_;//передаём имя
   //архивируемого файла в программу
   ExtractFile;//Вызываем процедуру извлечения архива
end;
end.
