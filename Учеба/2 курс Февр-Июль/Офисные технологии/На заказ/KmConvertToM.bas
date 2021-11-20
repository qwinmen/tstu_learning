Attribute VB_Name = "KmConvertToM"
'перевести киломераж в метраж
Sub lr1()
 Const km_In_m = 1000 '1000 метров на км
 Dim km, Metrov As Long
 km = Val(InputBox("¬ведите количество километров"))
 Metrov = km * km_In_m
 MsgBox (km & " километров составл€ет " & Format(Metrov, "#,#") & " метров")
End Sub

'QwinCor