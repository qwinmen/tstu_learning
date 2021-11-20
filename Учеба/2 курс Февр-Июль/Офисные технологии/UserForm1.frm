VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} UserForm1 
   Caption         =   "Че происходит то"
   ClientHeight    =   3225
   ClientLeft      =   45
   ClientTop       =   420
   ClientWidth     =   5160
   OleObjectBlob   =   "UserForm1.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "UserForm1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'----------Laba 5-6---------------
Private Function Resize()
MultiPage1.Width = UserForm1.Width - 20
MultiPage1.Height = UserForm1.Height - 35
lblWH = str(UserForm1.Width) + " : " + str(UserForm1.Height)
txtBoxForWH.Text = "Ширина текущей формы - " + str(UserForm1.Width) + " пикселей"
End Function

Private Sub btnResize_Click()
'300}{400
UserForm1.Width = 400
UserForm1.Height = 300
Dim a As Integer
a = Resize()
End Sub

Private Sub btnSbros_Click()
UserForm1.Width = 262.5
UserForm1.Height = 184.5
Dim a As Integer 'заглушка
a = Resize()
End Sub
'----------Laba 5-6---------------

'----------Laba 4----------------
Private Sub btnOpros_Click()
lblMetkaForName = "Доровэ! " + UserInput(1)
End Sub
'----------Laba 4----------------

'----------Laba 3----------------
Private Sub btnGo_Click()
MultiPage1.SelectedItem.Caption = txtBoxForLabel.Text
End Sub
'----------Laba 3----------------

'----------Laba 2----------------
Private Sub btnResult_Click()
lblSum = Val(txtBox2.Text) + Val(txtBox1.Text)
End Sub
'----------Laba 2----------------

'----------Laba 1----------------
Public Sub cmd_UserData_Click()
If Len(TextBox1.Text) > 0 Then Label1 = "Прувэт " + TextBox1.Text
End Sub

Private Sub TextBox1_MouseDown(ByVal Button As Integer, ByVal Shift _
As Integer, ByVal X As Single, ByVal Y As Single)
TextBox1.Text = ""
cmd_UserData.Enabled = True
End Sub


Private Sub UserForm_Initialize()
    Frame1.Caption = "Лабух2-1"
    TextBox1.Text = "Вводи как тя звать:"
    cmd_UserData.Enabled = False
End Sub
'----------Laba 1----------------
