Attribute VB_Name = "Lab2_Poly"
'������� ������������ ������ #2
' a = Ln(y^(-sqrt(abs(x)))) * (sin(x) + e^(x+y)) + sqrt[(2 * cos^(2)x + 3) / (5 * sin(x))]

'= Ln(y^(-sqrt(abs(x))))
'* (sin(x) + e^(x+y))
'c= + sqrt[AA / BB]
'AA = (2 * cos^(2)x + 3)
'BB = (5 * sin(x))

Sub Lab2()
 Dim x, y, a, b, c, AA, BB, Result As Single
 x = Val(InputBox("������� �������� �"))
 y = Val(InputBox("������� �������� y"))
 
 a = y ^ (-Math.Sqr(Abs(x))) '= Ln(a) *
 b = (Sin(x) + E ^ (x + y)) '* b +
 CC = (Cos(2 * x) + 1) / 2 '������ cos^(2)x --> (cos(2*x)+1)/2
 AA = (2 * CC + 3)
 BB = (5 * Sin(x))

 Select Case BB
 Case 0: MsgBox "������� ������� �� ����", vbCritical, "������"
 Case Is < 0: MsgBox "������� ������� �� ������������� �����", vbCritical, "������"
 Case Else ' ����� ��������� � �������
    c = Math.Sqr(AA / BB) '+ c
    Result = Log(a) * b + c
    MsgBox ("��������� � = " & Result)
 End Select

' ��� ���� ����� ��� select_case:
'If BB = 0 Then
'    MsgBox "������� ������� �� ����", vbCritical, "������"
'  ElseIf BB < 0 Then
'    MsgBox "������� ������� �� ������������� �����", vbCritical, "������"
'  Else ' ����� ��������� � �������
'    c = Math.Sqr(AA / BB) '+ c
'    Result = Log(a) * b + c
'    MsgBox ("��������� � = " & Result)
'  End If
' ---------

End Sub



'QwinCor
