Attribute VB_Name = "ModuleSkilProc"
Public Function UserInput(UserNumber As Integer) As String
Dim str_Name As String
Dim byt_Age As Byte
str_Name = InputBox("����� ���� ���:")
byt_Age = InputBox("� ������� ��:")
UserInput = str_Name
End Function
