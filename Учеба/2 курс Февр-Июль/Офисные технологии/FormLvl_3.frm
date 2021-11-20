VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} FormLvl_3 
   Caption         =   "Глобальный делёж"
   ClientHeight    =   3510
   ClientLeft      =   45
   ClientTop       =   420
   ClientWidth     =   4800
   OleObjectBlob   =   "FormLvl_3.frx":0000
   StartUpPosition =   2  'CenterScreen
End
Attribute VB_Name = "FormLvl_3"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

'------------------Laben_3-6--------------
Private Sub btnForDecript_Click()
Cheats.DeCript (txtBoxForCript.value)
End Sub
'------------------Laben_3-6--------------

'------------------Laben_3-4--------------
Private Sub ScrollBar1_Change()
Dim length As Byte
length = ScrollBar1.value 'итого min[5*(10\5)]
Cheats.Masker (length)
End Sub
'------------------Laben_3-4--------------

'------------------Laben_3-3--------------
Private Sub CommandButton2_Click()
Dim s As String, Arr() As String
Snovo:
s = InputBox("Прошу количество слов")
 If Cheats.isCorrectInput(s) Then 'Эт число
 ReDim Arr(s) '[грани]
  For i = 0 To s
    Arr(i) = InputBox("Пиши бред")
    lblForResultAdivB = Cheats.Exec(Arr(i)) 'сразу читирим
  Next
  Call Cheats.InputToWord(Arr)   'call для этож массив
 Else: GoTo Snovo
 End If
End Sub
'------------------Laben_3-3--------------

'------------------Laben_3-2--------------
Private Sub CommandButton1_Click()
Dim s As String
Abort:
s = InputBox("Вводи")
If Cheats.isCorrectInput(s) Then 'Эт число
    If Len(s) = 4 And Not Cheats.is247(s) Then 'Длина 4 и нет 2-4-7
Kaskad2:
    s = InputBox("Еще") '2 kaskad
        If Cheats.isCorrectInput(s) Then
            If Len(s) = 5 And Not Cheats.isPovtor(s) Then 'Длина 5 и нет повтора
            lblForResultAdivB = "Ok"
            Else: GoTo Kaskad2
            End If
        End If
    Else: GoTo Abort
    End If
End If
End Sub
'------------------Laben_3-2--------------

'------------------Laben_3-1--------------
Private Sub txtBoxForB_Change()
On Error Resume Next 'игнорим все ошибки
If Cheats.isCorrectInput(txtBoxForB.Text) And Cheats.isCorrectInput(txtBoxForA.Text) Then _
lblForResultAdivB = "Итого:" & Str(txtBoxForA / txtBoxForB)
End Sub
'------------------Laben_3-1--------------





Private Sub UserForm_Click()
';;;;;;;;;;;;;;;;;;;;;;;;;;
End Sub
