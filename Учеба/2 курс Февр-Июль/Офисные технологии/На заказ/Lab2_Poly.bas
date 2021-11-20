Attribute VB_Name = "Lab2_Poly"
'заданий лабораторной работы #2
' a = Ln(y^(-sqrt(abs(x)))) * (sin(x) + e^(x+y)) + sqrt[(2 * cos^(2)x + 3) / (5 * sin(x))]

'= Ln(y^(-sqrt(abs(x))))
'* (sin(x) + e^(x+y))
'c= + sqrt[AA / BB]
'AA = (2 * cos^(2)x + 3)
'BB = (5 * sin(x))

Sub Lab2()
 Dim x, y, a, b, c, AA, BB, Result As Single
 x = Val(InputBox("Введите значение х"))
 y = Val(InputBox("Введите значение y"))
 
 a = y ^ (-Math.Sqr(Abs(x))) '= Ln(a) *
 b = (Sin(x) + E ^ (x + y)) '* b +
 CC = (Cos(2 * x) + 1) / 2 'аналог cos^(2)x --> (cos(2*x)+1)/2
 AA = (2 * CC + 3)
 BB = (5 * Sin(x))

 Select Case BB
 Case 0: MsgBox "Попытка деления на ноль", vbCritical, "Ошибка"
 Case Is < 0: MsgBox "Попытка деления на отрицательное число", vbCritical, "Ошибка"
 Case Else ' иначе допускать к делению
    c = Math.Sqr(AA / BB) '+ c
    Result = Log(a) * b + c
    MsgBox ("Результат а = " & Result)
 End Select

' или тоже самое без select_case:
'If BB = 0 Then
'    MsgBox "Попытка деления на ноль", vbCritical, "Ошибка"
'  ElseIf BB < 0 Then
'    MsgBox "Попытка деления на отрицательное число", vbCritical, "Ошибка"
'  Else ' иначе допускать к делению
'    c = Math.Sqr(AA / BB) '+ c
'    Result = Log(a) * b + c
'    MsgBox ("Результат а = " & Result)
'  End If
' ---------

End Sub



'QwinCor
