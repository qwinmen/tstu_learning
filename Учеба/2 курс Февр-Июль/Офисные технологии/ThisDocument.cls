VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ThisDocument"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = True
'!!!������ �� FormLvl_3!!!!
'------------------Laben_3-5--------------
Private Sub btnSelectTxt_Click()
'����������� ���� �������������\����������\������������������ ���������
'����������� ���� �������������\Ctrl+C\����������\����������������� ��������

'���������� http://www.cyberforum.ru/vba/thread317161.html
'��� ������ � ������� ������ Windows ���������� VBA Word
'���� ������������ ������ DataObject.
'������ � ����������� ������ ���������� ������ DataObject.
'����� ���������� � ���� � ������� ���������� �����.
Dim ����� As New DataObject
Dim ���������� As String
'�������� � DataObject ������ �� ������ ������ Windows.
�����.GetFromClipboard
'�������� ������ �� DataObject � ����������.
���������� = �����.GetText
 If Not CheckBox1.value Then
    Cheats.StrToArr (����������)
 Else '6 lab On
    FormLvl_3.Show
    Cheats.PrintTBox (����������)
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

