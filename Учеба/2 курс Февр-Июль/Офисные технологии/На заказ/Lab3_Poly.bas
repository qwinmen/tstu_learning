Attribute VB_Name = "Lab3_Poly"
'лаб 3 система

' ------|------------|----------
'   1]         2]         3]

'1] t < 10
'2] 10 <= t <= 15
'3] t > 15

'Текст программы (Часть 1, оператор If)
Sub lr2_1()

 Dim w, t, b As Single
 t = Val(InputBox("Введите значение t"))
 
 If t < 10 Then                     '1] t < 10
    w = (1 / 2) * (t * t) - Sin(t)  '
 ElseIf t > 15 Then                 '3] t > 15
    w = Sin(t * t + 1)              '
 Else                               '2] 10 <= t <= 15
    w = E ^ (t + 1)
 End If
 MsgBox "Результат W = " & w, , "Вывод результатов часть 1"
 
End Sub


'Текст программы (Часть 2, оператор Select Case)
Sub lr2_2()
 
 Dim w, t, b As Single
 t = Val(InputBox("Введите значение t"))
 
 Select Case t
        Case Is < 10                              '1] t < 10
                w = (1 / 2) * (t * t) - Sin(t)    '
        Case Is > 15                              '3] t > 15
                w = Sin(t * t + 1)                '
        Case Else                                 '2] 10 <= t <= 15
                w = E ^ (t + 1)
 End Select
 MsgBox "Результат W = " & w, , "Вывод результатов часть 2"
 
End Sub



'QwinCor