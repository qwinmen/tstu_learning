VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} fLab2_1 
   Caption         =   "Работа с массивом"
   ClientHeight    =   2910
   ClientLeft      =   45
   ClientTop       =   420
   ClientWidth     =   4905
   OleObjectBlob   =   "fLab2_1.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "fLab2_1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub btnFMainActivate_Click()
Unload fLab2_1
mFormLab2.Show
End Sub

'-------------------labar#5-------------------------------
Private Sub btnForNAdd_Click()
Dim n As String
n = Filter(5, n) '5-для кейса, n-для фильтра нужного числа
Dim DArr() As Integer
ReDim DArr(n) '[грани]
  For c1 = 0 To n 'строка
    DArr(c1) = Int((n * 3 * rnd) + 1)
  Next c1

For i = 0 To 3 'курсор пониже
Selection.MoveDown 'т.к. работа с кнопки
Next

For i = LBound(DArr) To UBound(DArr) 'цикл от нижней границе массива до верхней границы массива
 If i <> UBound(DArr) Then
    Selection.Text = Str(DArr(i)) + ", " 'для запятой
    Else: Selection.Text = Str(DArr(i)) + ". " 'для точки
 End If
 Selection.Move 'двинуть курсор
Next i

End Sub
'-------------------labar#5-------------------------------
Public Function Filter(key As Byte, n As String) As Integer
ThisStart: 'проверить на число и на пределы
Select Case key
Case 5
  n = InputBox("Вводи число > 1")
    Do While Not IsNumeric(n)
       n = InputBox("Число блин введи")
    Loop
  If n <= 1 Then GoTo ThisStart 'ниче умней непридумал
Case 6
 n = InputBox("Вводи число от 2 до 20")
    Do While Not IsNumeric(n)
       n = InputBox("Число блин введи")
    Loop
  If n <= 2 Or n >= 20 Then GoTo ThisStart
Case 8
 n = InputBox("Вводи число")
    Do While Not IsNumeric(n)
       n = InputBox("Число блин введи")
    Loop
  If n <= 1 Then GoTo ThisStart
End Select

Filter = n 'итого
End Function

'-------------------labar#6-------------------------------
Private Sub btnДваДвадцать_Click()
Dim nTwo As String, Max As Integer
nTwo = Filter(6, nTwo) '6-для кейса, n-для фильтра нужного числа
Dim DArr() As Integer
ReDim DArr(nTwo) '[грани]
For c1 = 0 To nTwo 'строка
    DArr(c1) = val(InputBox(c1 & ":"))
Next c1

Max = 0
 For i = 0 To nTwo
   If DArr(i) > Max Then Max = DArr(i)
 Next
lblForMax = ("Максимум равен: " & Max)
End Sub
'-------------------labar#6-------------------------------

'-------------------labar#7-------------------------------
Private Sub btnОдинСто_Click()
Dim arr(10) As Integer, чет As Byte, нечт As Byte
 For i = 1 To 10
     arr(i) = Fix(rnd() * 100) ' Задаем массив случайным образом, числами от 1 до 99
    If ЧетНечет(arr(i)) = "Четное" Then
    чет = чет + 1
    Else:
    нечт = нечт + 1
    End If
 Next
 lblForMax = "Четное = " & чет & vbCrLf & "Не четное = " & нечт
End Sub

Public Function ЧетНечет(число As Integer) As String
If число Mod 2 = 0 Then
   ЧетНечет = "Четное"
   Else: ЧетНечет = "Не_четное"
End If
End Function
'-------------------labar#7-------------------------------





Private Sub UserForm_Click()
'pffffffff
End Sub
