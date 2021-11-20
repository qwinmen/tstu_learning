Attribute VB_Name = "ModuleSkilProc"
Public Function UserInput(UserNumber As Integer) As String
Dim str_Name As String
Dim byt_Age As Byte
str_Name = InputBox("¬веди свое им€:")
byt_Age = InputBox("а возраст чЄ:")
UserInput = str_Name
End Function
