VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} fLab2_1 
   Caption         =   "������ � ��������"
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
n = Filter(5, n) '5-��� �����, n-��� ������� ������� �����
Dim DArr() As Integer
ReDim DArr(n) '[�����]
  For c1 = 0 To n '������
    DArr(c1) = Int((n * 3 * rnd) + 1)
  Next c1

For i = 0 To 3 '������ ������
Selection.MoveDown '�.�. ������ � ������
Next

For i = LBound(DArr) To UBound(DArr) '���� �� ������ ������� ������� �� ������� ������� �������
 If i <> UBound(DArr) Then
    Selection.Text = Str(DArr(i)) + ", " '��� �������
    Else: Selection.Text = Str(DArr(i)) + ". " '��� �����
 End If
 Selection.Move '������� ������
Next i

End Sub
'-------------------labar#5-------------------------------
Public Function Filter(key As Byte, n As String) As Integer
ThisStart: '��������� �� ����� � �� �������
Select Case key
Case 5
  n = InputBox("����� ����� > 1")
    Do While Not IsNumeric(n)
       n = InputBox("����� ���� �����")
    Loop
  If n <= 1 Then GoTo ThisStart '���� ����� ����������
Case 6
 n = InputBox("����� ����� �� 2 �� 20")
    Do While Not IsNumeric(n)
       n = InputBox("����� ���� �����")
    Loop
  If n <= 2 Or n >= 20 Then GoTo ThisStart
Case 8
 n = InputBox("����� �����")
    Do While Not IsNumeric(n)
       n = InputBox("����� ���� �����")
    Loop
  If n <= 1 Then GoTo ThisStart
End Select

Filter = n '�����
End Function

'-------------------labar#6-------------------------------
Private Sub btn�����������_Click()
Dim nTwo As String, Max As Integer
nTwo = Filter(6, nTwo) '6-��� �����, n-��� ������� ������� �����
Dim DArr() As Integer
ReDim DArr(nTwo) '[�����]
For c1 = 0 To nTwo '������
    DArr(c1) = val(InputBox(c1 & ":"))
Next c1

Max = 0
 For i = 0 To nTwo
   If DArr(i) > Max Then Max = DArr(i)
 Next
lblForMax = ("�������� �����: " & Max)
End Sub
'-------------------labar#6-------------------------------

'-------------------labar#7-------------------------------
Private Sub btn�������_Click()
Dim arr(10) As Integer, ��� As Byte, ���� As Byte
 For i = 1 To 10
     arr(i) = Fix(rnd() * 100) ' ������ ������ ��������� �������, ������� �� 1 �� 99
    If ��������(arr(i)) = "������" Then
    ��� = ��� + 1
    Else:
    ���� = ���� + 1
    End If
 Next
 lblForMax = "������ = " & ��� & vbCrLf & "�� ������ = " & ����
End Sub

Public Function ��������(����� As Integer) As String
If ����� Mod 2 = 0 Then
   �������� = "������"
   Else: �������� = "��_������"
End If
End Function
'-------------------labar#7-------------------------------





Private Sub UserForm_Click()
'pffffffff
End Sub
