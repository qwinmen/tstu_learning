VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} mFormLab2 
   Caption         =   "������"
   ClientHeight    =   3135
   ClientLeft      =   45
   ClientTop       =   420
   ClientWidth     =   4710
   OleObjectBlob   =   "mFormLab2.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "mFormLab2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


Option Explicit

'-------------------labar#1-------------------------------
Private txt As String
Private Sub txtBoxForIn_Change()
txt = txtBoxForIn.Text '������� ������
    If Not IsNumeric(txt) Then '��� ��� �����
      txtBoxOut = "�������� ����"
      Else: txtBoxOut = ��������(txt) '�� �����������
    End If
End Sub

Private Function ��������(����� As String) As String
If ����� Mod 2 = 0 Then
   �������� = "������"
   Else: �������� = "�� ������"
End If
End Function
'-------------------labar#1-------------------------------

'-------------------labar#2-------------------------------
Private Sub btnBomb_MouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Single, ByVal Y As Single)
btnBomb.Left = rnd() * Frame1.Height
btnBomb.Top = rnd() * 80
Static index As Integer
       index = index + 1
MultiPage1.Page2.Caption = "���� #" + Str(index)
End Sub

Private Sub btnBomb_Click()
MsgBox ("BOM!")
End Sub

'-------------------labar#2-------------------------------

'-------------------labar#3-------------------------------
Private Sub btnReset_Click()
If cbo_1.Value Or cbo_2.Value Or cbo_3.Value _
               Or cbo_4.Value Or cbo_5.Value Then
   cbo_1.Value = False
   cbo_2.Value = False
   cbo_3.Value = False
   cbo_4.Value = False
   cbo_5.Value = False
End If
End Sub

Private Sub CommandButton2_Click() '���������� �������
Dim val As Integer 'k ���-3
val = 0
If cbo_1.Value Then val = val + 1
If cbo_2.Value Then val = val + 1
If cbo_3.Value Then val = val + 1
If cbo_4.Value Then val = val + 1
If cbo_5.Value Then val = val + 1

If val <> 0 Then MsgBox (val) _
Else: MsgBox ("�� ���� ������ �� ����������")
End Sub

Private Sub btn���_Click() '2-4
cbo_2.Value = True
cbo_4.Value = True
End Sub

Private Sub btn�����_Click()
cbo_1.Value = True
cbo_3.Value = True
cbo_5.Value = True
End Sub

'-------------------labar#3-------------------------------

'-------------------labar#4-------------------------------
Private Sub btnClose_Click()
Unload mFormLab2 'Application.Quit
End Sub

Private Sub btnForm1_Click() '������ fMain
mFormLab2.Hide
fLab2_1.Show
End Sub

Private Sub btnForm2_Click()
mFormLab2.Hide
fLab2_2.Show
End Sub
'-------------------labar#4-------------------------------


Private Sub UserForm_Click()
'���� ���� ���� � �������, ������ ���� � ���������
End Sub
