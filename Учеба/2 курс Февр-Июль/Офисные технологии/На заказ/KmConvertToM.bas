Attribute VB_Name = "KmConvertToM"
'��������� ��������� � ������
Sub lr1()
 Const km_In_m = 1000 '1000 ������ �� ��
 Dim km, Metrov As Long
 km = Val(InputBox("������� ���������� ����������"))
 Metrov = km * km_In_m
 MsgBox (km & " ���������� ���������� " & Format(Metrov, "#,#") & " ������")
End Sub

'QwinCor