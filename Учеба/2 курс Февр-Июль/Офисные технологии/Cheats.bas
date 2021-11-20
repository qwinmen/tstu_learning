Attribute VB_Name = "Cheats"
Public Function ЧетНечет(число As String) As String
If число Mod 2 = 0 Then
   ЧетНечет = "Четное"
   Else: ЧетНечет = "Не четное"
End If
End Function

Public Function isCorrectInput(value As String) As Boolean
    If value <> "" Then
     If Not IsNumeric(value) Then
      isCorrectInput = False
      Else: isCorrectInput = True
     End If
    End If
End Function

Public Function is247(value As String) As Boolean
    If InStr(value, "2") <> 0 Or InStr(value, "4") <> 0 Or InStr(value, "7") <> 0 _
    Then is247 = True
End Function

Public Function isPovtor(txt As String) As Boolean
 Dim i, s As Byte
    For i = 0 To 9 'i=[1..9,0]
        If InStr(txt, i) > 0 Then 'i есть в txt
           s = InStr(txt, i) 'снять позицию
            If InStr(Val(s + 1), txt, i) > 0 Then 'повтор с s-позиций
                isPovtor = True 'есть контакт
                Exit For 'поехали
            End If
        End If
    Next
End Function

Public Sub InputToWord(ByRef Arr() As String)
 For i = LBound(Arr) To UBound(Arr)
  If i <> UBound(Arr) Then
    Selection.Text = (Arr(i)) & ", "
    Else: Selection.Text = (Arr(i)) & ". "
  End If
  Selection.Move 'двинуть курсор
 Next
End Sub

Public Function Exec(Text As String) As String
Dim Letter As String, MaxБуква As String
Dim length As Byte, MaxКоличество As Byte, i As Byte
MaxКоличество = 0
MaxБуква = Left(Text, 1)
Do
    length = Len(Text)
    Letter = Left(Text, 1)
    Text = Replace(Text, Letter, "")
    If length - Len(Text) > MaxКоличество Then
        MaxКоличество = length - Len(Text)
        MaxБуква = Letter
    ElseIf length - Len(Text) = MaxКоличество Then
        MaxБуква = MaxБуква & "," & Letter
    End If
Loop Until Text = ""
Exec = "Буква " & MaxБуква & " найдена с " & MaxКоличество & " повторов."
'переделка http://www.cyberforum.ru/vba/thread236942.html
End Function

Public Sub Masker(v As Byte)
Dim Mass() As String, c As Byte
ReDim Mass(v)
 For i = 0 To v
  Mass(i) = Fix(Rnd() * 115)
 Next
 c = 5
 Do While v > c
 c = c + 5
 Loop
 c = c / 5
 'MsgBox (c)
ReDim MatrixArr(4, c) As String '5 столбов и c строк
'Рисуем таблицу
 Set Range1 = ThisDocument.Range(Start:=0, End:=0)
 Dim Table1 As Table
 Set Table1 = ThisDocument.Tables.Add(Range1, c + 1, 5) 'c_strok & 5_stolb
 f = 0 'аля v
 For k = 0 To 4
    For j = 0 To c
     If f > v Then
      MatrixArr(k, j) = 0 'Эт излишек перевода в двумерный
     Else: MatrixArr(k, j) = Mass(f)
     End If
          
     If MatrixArr(k, j) > 50 And ЧетНечет(MatrixArr(k, j)) = "Четное" Then
     Table1.Cell(j + 1, k + 1).Range.InsertAfter MatrixArr(k, j) '1_str 1_stolb
     Table1.Cell(j + 1, k + 1).Range.Font.Color = wdColorBlue
     Else: Table1.Cell(j + 1, k + 1).Range.InsertAfter MatrixArr(k, j)
     End If
     f = f + 1 '[0..c][c..c+c]&etc.
    Next j
 Next k
End Sub

'------------------Laben_3-5--------------
Public Sub StrToArr(txt As String)
'Через байтовый массив
'Реализация http://howtoo.ru/stroki-v-vba/
Dim Mass() As Byte, n As Long, Zam As String
Mass = StrConv(txt, vbFromUnicode)
 For n = 0 To UBound(Mass)
   If Mass(n) <> 46 And Mass(n) <> 44 Then Zam = Zam + Chr$(Mass(n))
 Next

Dim Arr() As String
ReDim Arr(Len(Zam))
Arr = Split(Zam, " ") 'пробелы как разделитель

'Сортировка возрастание длинны строки
nw = UBound(Arr) + 1
    For i = 0 To nw - 1 Step 1
        For j = 0 To nw - 2 - i Step 1
            If Len(Arr(j)) > Len(Arr(j + 1)) Then
                Temp = Arr(j)
                Arr(j) = Arr(j + 1)
                Arr(j + 1) = Temp
            End If
        Next j
    Next i
'Решено http://www.cyberforum.ru/vba/thread356662.html

For n = 0 To UBound(Arr)
   Selection.EndKey Unit:=wdStory, Extend:=wdMove
   Selection.Text = " #" & n & " " & Arr(n) & " Len" & Len(Arr(n)) & vbNewLine
 Next
End Sub
'------------------Laben_3-5--------------

'------------------Laben_3-6--------------
Public Sub PrintTBox(txt As String)
FormLvl_3.txtBoxForBuffer.Text = txt
'Через байтовый массив
'Реализация http://howtoo.ru/stroki-v-vba/
Dim Mass() As Byte, n As Long, Zam As String
Mass = StrConv(txt, vbFromUnicode)
 For n = 0 To UBound(Mass) 'я=255 + 3 = 0 + 3
    ch = Mass(n)
    
    If (ch + Int(ThisDocument.ScrollBarKeyCript.value)) > 255 Then ch = 0 + _
                                    Int(ThisDocument.ScrollBarKeyCript.value)
    'MsgBox (ch)
    Zam = Zam & Chr$(ch + Int(ThisDocument.ScrollBarKeyCript.value))
 Next
FormLvl_3.txtBoxForCript.Text = Zam
End Sub

Public Sub DeCript(txt As String)
Dim Mass() As Byte, n As Long, Zam As String, i, m As Byte
Mass = StrConv(txt, vbFromUnicode)
 For n = 0 To UBound(Mass)
    ch = Mass(n)
    For i = 0 To 9
     If ch = i Then
     ch = 264 - i '255 + [9] = 264
     m = i
     Exit For
     End If
    Next
    If (ch - Int(FormLvl_3.ScrollBarForУгадайKey.value)) > 255 Or ch < 0 Then ch = 256 - i
    Zam = Zam & Chr$(ch - Int(FormLvl_3.ScrollBarForУгадайKey.value))
 
 Next
FormLvl_3.Label1 = Zam

End Sub
'------------------Laben_3-6--------------










