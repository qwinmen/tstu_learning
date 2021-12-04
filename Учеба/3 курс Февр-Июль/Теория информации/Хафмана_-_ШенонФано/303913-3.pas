unit Haffman;

interface 

Uses
  Forms,ComCtrls, Dialogs;
const
   Count=4096;
   ArchExt='haf';
   dot='.';

//две файловые переменные для чтения исходного файла и для
//записи архива
var
   FileToRead,FileToWrite: File;
   ProgressBar1:TProgressBar;
// Процедуры для работы с файлом
// Первая - кодирование файла
procedure RunEncodeHaff(FileName_: string);
// Вторая - декодирование файла
procedure RunDecodeHaff(FileName_: string);

implementation

Type
{тип элемета для динамической обработки статистики символов
встречающихся в файле}
   TByte=^PByte;
   PByte=Record
    //Символ (один из символв ASCII)
      Symbol: Byte;
      //частота появления символа в сжимаемом файле
      SymbolStat: Integer;
      //последовательность битов, в которые преобразуется текущий
      //элемент после работы древа (Кодовое слово) (в виде строки из "0" и "1")
      CodWord: String;
   //ссылки на левое и правое поддеревья (ветки)
      left, right: TByte;
   End;

{массив из символов со статистикой , т.е. частотой появления их
в архивируемом файле}
   BytesWithStat = Array [0..255] of TByte;

   {объект, включающий в себя:
   массив элементов содержащий в себе количество элементов,
   встречающихся в файле хотя бы один раз
   процедура  инициализации объекта
   процедура для увеличения частоты i-го элемента}
   TStat =Object
      massiv: BytesWithStat;
      CountByte: byte;
      Procedure Create;//процедура инициализации обьекта
      Procedure Inc(i: Byte);
   End;

// процедура  инициализации объекта вызывается из процедуры StatFile
   Procedure TStat.Create; //(291)
   var
      i: Byte;
   Begin //создаём массив симолв (ASCII), обнуляем статистику
   //и ставим указатели в положение не определено
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
         //будут задействованы на обработку кода приложения
      End;
   End;

{процедура для  вычисления частот появления
i-го элемента в сжимаемом файле вызывается строка(310)}
   Procedure TStat.Inc(i: Byte);
   Begin //увеличиваем значение статистики символа [i] наединицу
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
           // Name_[i]:='!';
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
         While (i>0) And (Name_[i]<>'.') Do //до тех пор пока
         //не встритится '.'  !
         Begin
            Dec(i); //уменьшаем счётчик на единицу
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
   //по убыванию частоты байта  (743)
procedure SortMassiv(var a: BytesWithStat; LengthOfMass: byte);
   var
      i,j: Byte; //счётчики циклов
      b: TByte;
   Begin  //сортировка перестановкой
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

   //процедура удаления динамической структуры частотного дерева
   //из памяти
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

   //создание дерева частот для архивируемого файла Haffman (777)
   Procedure CreateTree(var Root: TByte; massiv: BytesWithStat;
                      last: byte);
var
Node: TByte;//узел
Begin
     //sort_mass(massiv, last);
  If last<>0   //если не 0 то начинаем строить дерево
    Then
       Begin
         SortMassiv(massiv, last);//сортируем по убыванию
        //частоты появления символа
         new(Node);//создаёмо новый узел
         //присваиваем ему вес двух самых лёгких эементов
         //т.е. складываем статистику этих элементов
         Node^.SymbolStat:=massiv[last-1]^.SymbolStat + massiv[last]^.SymbolStat;
         Node^.left:=massiv[last-1];//от узла делаем ссылку на левую
         Node^.right:=massiv[last];//и правую ветки
         massiv[last-1]:=Node;// удаляем два последних элемента
         //из массива на место предпоследнего из них ставим
         //сформированный узел
         /////////////////  проверяем не достигли ли корня
          if last=1//если =1 то да
           Then
            Begin
             Root:=Node; //устанавливаем корневой узел
            End
          Else
            Begin
             CreateTree(Root,massiv,last-1);//если нет то строим
             //древо дальше
            End;
       End
  Else//если значение last в самом начале =0 т.е. файл
  //содержит один и тот же символ (если файл состоит или
  //из одного байта или из чередования одного итогоже символа)
    Root:=massiv[last];//то вершина дерева будет от last
      Application.ProcessMessages;
End;

var
   //экземпляр объекта для текущего сжимаемого файла
   MainFile: file_;

//процедура для полного анализа частот байтов встречающихся хотя бы
//один раз в исходном файле
procedure StatFile(fname: String);
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
   Try    //на всякий случай
      Reset(f,1);//открываем файл для чтения
      MainFile.Stat.create;//вызываем метод инициализации объекта
      //для архивируемого файла (58)
      MainFile.Size:=FileSize(f);//метод определения размера
      // архивируемого файла. Стандартная функция FileSize
      //возвращает начение в байтах
      ///////////////////////
      countbuf:=FileSize(f) div count;//столько целых буферов
      //по 4096 байт содержится в исходном файле
      lastbuf:=FileSize(f) mod count; // остаток от целочисленного
      // деления=(последий буфер)разница в байтах до 4096
      //////////// Создаём статистику для каждого символа в файле
      For i:=1 to countbuf do //сначала прогоняем все целые буферы(на )
      Begin
         BlockRead(f,buf,count);
         for j:=1 to count do
         Begin //мы берём из буфера элемент от 1 до 4096 и с этими
         //параметрами вызываем функцию Stat.inc(элемент)
         //он же будет являтся и указателем на самого себя в
         //в массиве символов там  мы просто увеличиваем значение
         //SymbolStat(частоты появления) на единицу
            MainFile.Stat.inc(buf[j]);//(строка 80)
            Application.ProcessMessages;
         End;
         Application.ProcessMessages;
      End;
      /////////////
      If lastbuf<>0 //далее просчитываем статистику для оставшихся
      //байт
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
      CloseFile(f);//Закрываем файл
   Except  //Если чтото не так то выводим сообщение
      ShowMessage('ошибка доступа к файлу!')
   End;
End;

 {функция поиска в дереве Found(Tree: TByte; i: byte): Boolean;
 параметры Tree:корень дерева или его узел, i:символ кодовое слово
 которого ищем; возвращает булево значение в функцию HSymbolToCodWord.
 Алгоритм работы:
 функция HSymbolToCodWord вызывает функцию Found(Tree^.left,i) т.е c
 параметром поиска в  левой ветке дерева начиная от корня. Функция Found
 будет рекурсивно вызывать сама себя двигаясь по узлам дерева пока
 не дойдёт до искомого символа. Если там окажется искомый символ то Found
 вернёт true и в HSymbolToCodWord запишется первый нолик если
 Found(Tree^.left,i):true или единичка если  Found(Tree^.right,i):true
 далее HSymbolToCodWord вызывает Found, но уже в параметрах указывается
 не корень, а седующий за ним узел, находящийся слева или справа, в
 зависимости от пред идущего результата поиска (в какой ветви от корня
 был найден символ(если слева его не было зачем там искать))
 так будет продолжатся до тех пор пока HSymbolToCodWord не будет
 достигнут символ т.е. параметры функции будут Tree=узлу где находится
 символ (т.е. указатели на левую и правую ветви =nil)далее при выполнении
 функции она выработает значение для Tree=nil. Далее Found вернёт значение
 Tree= узлу где нахоится искомый символ, выработает значение Found=True
 и вернётся в вызывающую функцию HSymbolToCodWord где в значение
 HSymbolToCodWord в конец запишется '+'-означающий что кодовое слово
 найдено. Псле этого HSymbolToCodWord вернёт в вызвавшую её функцию
 SymbolToCodWord  значение кодового слова+'+'на конце где произойдё проверка
 и символ '+' будет удалён, в вызывающий метод Stat.massiv[i]^.CodWord
 будет возвращено значение кодового слова}
Function Found(Tree: TByte; i: byte): Boolean;
Begin
   Application.ProcessMessages;
   if (Tree=nil)//если древо nil то
    Then
      Found:=False //функция прекращает работу
    Else  //иначе
   Begin //если указатель на левую часть древа или
   //на правую nil, и указатель на символ равен счётчику
     if ((Tree^.left=nil) or (Tree^.right=nil))
      and (Tree^.Symbol=i)
       Then
         Found:=True {то функция возвращает флаг, что найден символ
и прекращает работу и возвращает в вызвавшую её функцию }
       Else //иначе функция продолжает поиск от других узлов
       //т.е.рекурсивно вызывает сама себя с другими параметрами
         Found:=Found(Tree^.left, i) or Found(Tree^.right, i);
   End;
End;
//функция для определения строкового представления сжатой последовательности
//битов для исходного байта i
Function HSymbolToCodWord(Tree: TByte; i: Byte): String;
Begin
   Application.ProcessMessages;
   if (Tree=nil)
   Then
      HSymbolToCodWord:='+=='
   Else
   Begin
      if (Found(Tree^.left,i))//если символ находится в левой ветви
      //в зависимости от того что вернула Found
      Then //то в строку добавляем символ нуля и вызываем HSymbolToCodWord
      //от ниже лежащего левого узла
         HSymbolToCodWord:='0'+HSymbolToCodWord(Tree^.left,i)
      Else
      Begin
         if Found(Tree^.right,i)//если символ находится в правой ветви
         Then //то в строку добавляем символ единицы и вызываем HSymbolToCodWord
      //от ниже лежащего правого узла
            HSymbolToCodWord:='1'+HSymbolToCodWord(Tree^.right,i)
         Else //иначе
         Begin //если найден символ
            If (Tree^.left=nil) and (Tree^.right=nil)
               and (Tree^.Symbol=i)
            Then //HSymbolToCodWord  //помечаем символ найден
               HSymbolToCodWord:='+'
            Else  //иначе
               HSymbolToCodWord:=''; //символа нет
         End;
      End;
   End;
End;

//вспомогательная функция для определения Кодового слова
//сжатой последовательности битов для исходного байта i (с учетом
//того экстремального случая, когда исходный файл состоит всего из одного
//и того же символа)
Function SymbolToCodWord(Tree: TByte; i: Byte): String;
var
   s: String;
Begin //Вызыаем ф-ию поиска кодовых слов
   s:=HSymbolToCodWord(Tree, i);
   s:=s;
   If (s='+'){если функция HSymbolToCodWord вернула строку
    содержащую '+' т.е. исходный файл состоит из одного и того же
    символа то кодовому слову присваиваем строку из '0' }
     Then
      SymbolToCodWord:='0'
     Else {иначе уменьшаем строку на один символ т.е. убираем '+'
     признак того что символ найден}
      SymbolToCodWord:=Copy(s,1,length(s)-1);
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
   For j:=1 to i do //работаем с байтами от превого элемента
   //массива до последнего
   Begin
      buf[j]:=0;//обнуляем тот элемент мссива в
      //который будем писать
      ///////////////////////////
      For k:=1 to 8 do//работаем с битами
      Begin
         If buffer[(j-1)*8+k]='1'{находим в строке тот элемент
который будем записывать в виде последовательности бит
(будем просматривать с (j-1) элемента строки buffer восемь
элментов за ним тем самым сформируется строка  из
восьми '0' и '1'. Эту строку мы будем  преобразовывать в байт,
который должен будет содержать такуюже последовательность бит)}
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
   End; //записываем в файл получивийся буфер
   BlockWrite(FileToWrite,buf,i);
   Delete(buffer,1,i*8);//удаляем из входного буфера те элементы
   //которые уже записаны()
End;

//процедура для окончательной записи остаточной цепочки битов в архив
Procedure WriteInFile_(var buffer: String);
var
   a,k: byte;
Begin
{Так как эту процедуру вызывает процедура которая передаёт в буфере
отнюдь не один последний байт, то срау вызываем процедуру
обычной записи в файл. После работы которой в buffer должна
остася последвательность из не более 8 символов. По этому
мы производим проверку и если что то не так то выводим сообщение.
Иначе устанавливаем в переменной а все биты в 1 и далее производим
следующие действия: Просматриваем по циклу всё что осталось в
buffer и если найдётся символ '0' то к сответтвующему биту переменной а
применяем операцию xor (т.е. 1 xor 1   что даст 0) т.е. оответствующий
бит установится в 0 всеостальные биты переменной а останутся в том же
состоянии что и были. Оставшиеся биты будут единицами}
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

//перевод числа типа Integer в массив из четырех байт.
Procedure IntegerToByte(i: Integer; var mass: Integer_);
var
   a: Integer;
   b: ^Integer_;
Begin
   b:=@a;// соединяем адресс переменной а с b
   a:=i;//в а перегоняем наше значение типа integer
   mass:=b^;{разименовываем b и соединяем результат с mass
в результате работы этого кода число типа Integer
перейд в массив из 4 байт. Это требуется для того что ,бы мы
запись в файл производим по байтно}
End;

//перевод массива из четырех байт в число типа Integer.
Procedure ByteToInteger(mass: Integer_; var i: Integer);
var
   a: ^Integer;
   b: Integer_;
Begin
   a:=@b;// соединяем адресс переменной b с а
   b:=mass;//b присваиваем значение mass
   i:=a^;{разименовываем а и соединяем результат с i
в результате работы этого кода массив из 4 байт
перейд в число типа Integer. Это требуется для того что бы мы
могли узнать наши значения типа Integer}
End;

//процедура создания заголовка архива
Procedure CreateHead;
var
   b: Integer_;
   //a: Integer;
   i: Byte;
Begin
//Записываем размер несжатого файла
   IntegerToByte(MainFile.Size,b);
   BlockWrite(FileToWrite,b,4);

//Записываем количество оригинальных байт
   BlockWrite(FileToWrite,MainFile.Stat.CountByte,1);

{зисываем байты со статистикой (на каждую запись требуеся
 по пять байт. Первый байт содержит сам символ далее идут
 4 байта со статистикой (Intege занимает 4 байта)}
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
{buffer_ это объект включающий в себя массив из байт ArrOfByte
счётчик байт ByteCount (необходим для учёта промежуточной
запися разархивируемых байт в файл)и основной счётчик (необходим
для отслеживани какое количество байт должно быть разархивировано
как только он стнет равным размеру сжимаемого файла то процесс
разархивирования первётся)}
   buffer_=object
      ArrOfByte: Array [1..MaxCount] of Byte;
      ByteCount: Integer;
      GeneralCount: Integer;
      Procedure CreateBuf;//процедура инициализации
      Procedure InsertByte(a: Byte);//процедура вставки
//разархивированных байтов в файл
      Procedure FlushBuf;
   End;
      /////////////////////////////
      Procedure buffer_.CreateBuf;
      Begin
         ByteCount:=0;//иициализируем переменные
         GeneralCount:=0;
      End;
      ////////////////////////////////////////
Procedure buffer_.InsertByte(a: Byte);
{В переменной а мы передаём значение разархивированного байта,
которое получили в вызывающей процедуре}
      Begin //до тех пор пока GeneralCount меньше
      //размера сжимаемого файла деаем
         if GeneralCount<MainFile.Size
         Then
         Begin
            inc(ByteCount); //увеличиваем соответствующие
            //счётчики  на единицу
            inc(GeneralCount);
            ArrOfByte[ByteCount]:=a;//загоняем в массив ArrOfByte
//значение полученное в переменной а
            //////////////////////////
            if ByteCount=MaxCount //если  ByteCount=MaxCount
//то записываем содержимое массива в разархивируемый файл
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
//Процедура записи остаточной цепочки байт
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
   CurrentPoint: TByte;
Begin
//определяем сколько целых буферов по 4 кбайт в сжатом
//файле без заголовка
   CountBuf:=MainFile.FileSizeWOHead div count;
//определяем сколько останеся байт не вошедших
//в целые буферы по 4 кбайт в сжатом файле без заголовка
   LastBuf:=MainFile.FileSizeWOHead mod count;
   MainBuffer.CreateBuf;//иициализируем переменные
   CurrentPoint:=MainFile.Tree;//присваиаем текущую
//позицию на корень дерева
//начинаем расаковку
   For i:=1 to CountBuf do
   Begin//считываем из сжатого файла данные в буфер
      BlockRead(FileToRead,buf,count);
      for j:=1 to Count do //по байтно начинаем
      //просматривать буфер
      Begin
         for k:=1 to 8 do//просматриваем биты от 1 до 8
         //выеленного байта
         Begin  {Выделяем байт в массиве. По циклу от 1 до 8
просматриваем значения его бит от 8 до 1. ДЛ этого используется
операция битового сдвига влево shl и логиеская операция and.
В цикле всё происходит следующим образом: Сначала просматривается
старший бит (8-к)=1 и производится логическая операция and,
если бит равен 1 то (1 and 1)=1 ио программа установит текущую
позицию поиска в дереве на правый узел, если же бит равен 0
то (0 and 1)=0 и программа установит текущую позицию поиска
в дереве на левый узел. так будет продолжатся до тех пор пока
не выполнится условие, которое ознчает нахождение искомого
символа ((CurrentPoint^.left=nil) or (CurrentPoint^.right=nil))
После этго будет вызвана процедура вставки байта, после возвра
щения из которой мы текущую точку опять устанавливаем на корень}
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
   Begin//работа этого блока программы аналогична предидущему
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

//процедура чтения заголовка архива
Procedure ReadHead;
var
   b: Integer_; // исходный размер файла
   SymbolSt: Integer;//статистика символа
   count_, SymbolId, i: Byte;//SymbolId=Symbol просто чтобы
   // не путать глобальную переменную с локальной
Begin
   try
//узнаем исходный размер файла
      BlockRead(FileToRead,b,4);
      ByteToInteger(b,MainFile.size);

//узнаем количество оригинальных байтов
      BlockRead(FileToRead,count_,1);
      {}{}{Вызываем процедуру инициализации объекта}
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
//вызываем процедуру создания дерева
      CreateTree(MainFile.Tree,MainFile.stat.massiv,MainFile.Stat.CountByte);
      /////////////
//Вызываем процедуру распаковки файла
      CreateDeArc;
      //////////////
//Вызываем процедуру уничтожения дерева
      DeleteTree(MainFile.Tree);

   except
      ShowMessage('архив испорчен!');
   End;
End;

//процедура извлечения архива
Procedure ExtractFile;
Begin
   AssignFile(FileToRead,MainFile.Name);
   //соединяем наш файл файловй переменой передэтим
   //вызываем метод получения имени разархивированого файла
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
   buffer: String;//строка в которой будет формироватся
//последовательность из кодовых слов
   ArrOfStr: Array [0..255] of String;
   i,j: Integer;
   //////////////
   buf: Array [1..count] of Byte;//массив в который
//будем считывать данные из архивируемого файла
   CountBuf, LastBuf: Integer;
Begin

   Application.ProcessMessages;
   AssignFile(FileToRead,MainFile.Name);
   AssignFile(FileToWrite,MainFile.ArcName);
   Try
      Reset(FileToRead,1);
      Rewrite(FileToWrite,1);
//Инициализируем массив  строк в котором будут
//хранится кодовые слова
      For i:=0 to 255 Do ArrOfStr[i]:='';
//Загоням  в массив строк кодовые слова соответсвующие
//своим символам
      For i:=0 to MainFile.Stat.CountByte do
      Begin
         ArrOfStr[MainFile.Stat.massiv[i]^.Symbol]:=
         MainFile.Stat.massiv[i]^.CodWord;
         Application.ProcessMessages;
      End;
//узнаём какое целое количество буферов по 4 кбайт будет содержатся в
//сжимаемом файле
      CountBuf:=MainFile.Size div Count;
//Сколько останется байт для записи не вошедших в ранее
//определённое значение CountBuf
      LastBuf:=MainFile.Size mod Count;
      Buffer:='';//обнуляем буфер
      /////////////
      CreateHead; //вызываем процедуру создания заголовка файла
      /////////////
  //фрмируем буфер кодовых слов
      for i:=1 to countbuf do
      Begin
//считываем из файла по 4 кбайт
         BlockRead(FileToRead,buf,Count);
         //////////////////////
         For j:=1 to count do
         Begin
//растим буфер из кодовых слов
            buffer:=buffer+ArrOfStr[buf[j]];
//если длина buffer превысит значеие 8*4096 (это означает
//превысит размер выходного буфера размер которого 4096байт)
//мы вызываем процедуру записи в файл
            If Length(buffer)>8*count
            Then
               WriteInFile(buffer);
            Application.ProcessMessages;
         End;
        // ProgressBar1.Position:=100 div countbuf;
      End;
//Запись оставшейся цепочки байт
      If lastbuf<>0
      Then
      Begin
//считываем в массив из файла оставшиеся байты
         BlockRead(FileToRead,buf,LastBuf);
//растим buffer строку из кодовых слов
         For j:=1 to lastbuf do
         Begin
            buffer:=buffer+ArrOfStr[buf[j]];
            If Length(buffer)>8*count
//если его размер превысит значение 8*4096 (а это может иметь
//место), то вызываем процедуру записи в файл
            Then
               WriteInFile(buffer);
            Application.ProcessMessages;
         End;
      End;
//выываем процедуру записи оставшейся цепочки кодовых слов
      WriteInFile_(buffer);
      CloseFile(FileToRead);
      CloseFile(FileToWrite);
   Except
      ShowMessage('Ошибка создания архива');
   End;
End;

//главная процедура для создания архивного файла
Procedure CreateFile; //(802)
var
   i: Byte;
Begin
   With MainFile do
   Begin
      {сортировка массива байтов с частотами (192)}
      SortMassiv(Stat.massiv,stat.CountByte);

      {поиск числа задействованных байтов из массива
      (ACSII) возмжных символов. В CountByte будем хранить
      количество этох самых символов }
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

      Stat.CountByte:=i;{присваиваем значение счётчика
CountByte. Это означает что в архивируемом файле
используется такое количество из 256 возможных
символов. Будет исползоватся для построения древа частот}

{создание дерева частот. Передаём в процедуру начальные
параметры Tree=nil-эта переменная будет содержать
после работы процедуры древо ,Stat.massiv-массив с символами
и соответствующей им статистикой,а так же указанием на
правое и левой дерево,Stat.CountByte-количество используемых
символов в архивирумом файле (230)}
      CreateTree(Tree,Stat.massiv,Stat.CountByte);

{запускаем в работу дерево с помощью его нахадим соответствующие
кодовые слова. Суть алгоритма вызываем функцию
SymbolToCodWord(Tree:TByte(указатель на корень дерева. Он у нас
выработался в результате работы процедуры CreateTree, Symbol:byte):
String функция вернёт нам строку содержащую кодовое слово ()}
      for i:=0 to Stat.CountByte do
       Stat.massiv[i]^.CodWord:=SymbolToCodWord(Tree,stat.massiv[i]^.Symbol);

//пишем сам файл
      CreateArchiv;

//Удаляем уже ненужное дерево
      DeleteTree(Tree);

//Инициализируем статистику файла
      MainFile.Stat.Create;
   End;
End;
//Основная процедура сжатия файла
procedure RunEncodeHaff(FileName_: string);
begin
   MainFile.Name:=FileName_;//передаём имя
//архивируемого файла в программу
   StatFile(MainFile.Name); //запускем процедуру создания
//статистики (частоты появления того или иного символа)
//для файла (строка 274)
   CreateFile; //вызов процедуры созданя архивного файла (737)
end;
//Основная процедура разархивирования файла
procedure RunDecodeHaff(FileName_: string);
begin
   MainFile.name:=FileName_;//передаём имя
   //архивируемого файла в программу
   ExtractFile;//Вызываем процедуру извлечения архива
end;
end.
