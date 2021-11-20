Attribute VB_Name = "Lab3_Poly"
'��� 3 �������

' ------|------------|----------
'   1]         2]         3]

'1] t < 10
'2] 10 <= t <= 15
'3] t > 15

'����� ��������� (����� 1, �������� If)
Sub lr2_1()

 Dim w, t, b As Single
 t = Val(InputBox("������� �������� t"))
 
 If t < 10 Then                     '1] t < 10
    w = (1 / 2) * (t * t) - Sin(t)  '
 ElseIf t > 15 Then                 '3] t > 15
    w = Sin(t * t + 1)              '
 Else                               '2] 10 <= t <= 15
    w = E ^ (t + 1)
 End If
 MsgBox "��������� W = " & w, , "����� ����������� ����� 1"
 
End Sub


'����� ��������� (����� 2, �������� Select Case)
Sub lr2_2()
 
 Dim w, t, b As Single
 t = Val(InputBox("������� �������� t"))
 
 Select Case t
        Case Is < 10                              '1] t < 10
                w = (1 / 2) * (t * t) - Sin(t)    '
        Case Is > 15                              '3] t > 15
                w = Sin(t * t + 1)                '
        Case Else                                 '2] 10 <= t <= 15
                w = E ^ (t + 1)
 End Select
 MsgBox "��������� W = " & w, , "����� ����������� ����� 2"
 
End Sub



'QwinCor