VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} fLab2_2 
   Caption         =   "UserForm2"
   ClientHeight    =   2040
   ClientLeft      =   45
   ClientTop       =   420
   ClientWidth     =   4140
   OleObjectBlob   =   "fLab2_2.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "fLab2_2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub btnMainAct_Click()
Unload fLab2_2
mFormLab2.Show
End Sub

'-------------------labar#8-9------------------------------
Private Sub btnSum_Click()
Dim nTwo As String, Sum As Integer
nTwo = fLab2_1.Filter(8, nTwo) '8-для кейса, n-для фильтра нужного числа
Dim DArr() As Integer
ReDim DArr(nTwo) '[грани]
 For i = 0 To nTwo
  If Not CheckBoxForSum.Value Then 'lab8
    DArr(i) = Fix(rnd() * 100) ' Задаем массив случайным образом, числами от 1 до 99
    Sum = Sum + DArr(i)
  Else: 'lab9
    DArr(i) = Int((-100 - 100 + 1) * rnd + 100)
    If fLab2_1.ЧетНечет(DArr(i)) = "Четное" And Abs(DArr(i)) > 25 Then
    Sum = Sum + DArr(i)
    End If
  End If
 Next i
 
lblSum = "Итого: " & Sum
End Sub
'-------------------labar#8-9------------------------------

'-------------------labar#9-------------------------------
Private Sub CheckBoxForSum_Click()
If CheckBoxForSum.Value Then
CheckBoxForSum.Caption = "Lab9_Sum On"
Else: CheckBoxForSum.Caption = "Lab9_Sum Off"
End If
End Sub

'-------------------labar#9-------------------------------







Private Sub UserForm_Click()
'brrrrrrrrrrr
End Sub
