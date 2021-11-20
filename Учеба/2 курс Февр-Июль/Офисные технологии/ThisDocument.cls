VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ThisDocument"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = True
'!!!Модуль от FormLvl_3!!!!
'------------------Laben_3-5--------------
Private Sub btnSelectTxt_Click()
'Конструкция типо ВыделилМышкой\НажалКнопу\СнялВыделеныйТекст нефурычит
'Конструкция типо ВыделилМышкой\Ctrl+C\НажалКнопу\СнялТекстыСБуфера возможна

'Реализация http://www.cyberforum.ru/vba/thread317161.html
'Для работы с буфером обмена Windows средствами VBA Word
'надо использовать объект DataObject.
'Создаём в оперативной памяти компьютера объект DataObject.
'Будем обращаться к нему с помощью переменной Буфер.
Dim Буфер As New DataObject
Dim Переменная As String
'Помещаем в DataObject данные из буфера обмена Windows.
Буфер.GetFromClipboard
'Помещаем данные из DataObject в переменную.
Переменная = Буфер.GetText
 If Not CheckBox1.value Then
    Cheats.StrToArr (Переменная)
 Else '6 lab On
    FormLvl_3.Show
    Cheats.PrintTBox (Переменная)
 End If
End Sub
'------------------Laben_3-5--------------

Private Sub CheckBox1_Click()
 If Not CheckBox1.value Then
    CheckBox1.Caption = "Off 6"
 Else
    CheckBox1.Caption = "On 6"
 End If
End Sub

