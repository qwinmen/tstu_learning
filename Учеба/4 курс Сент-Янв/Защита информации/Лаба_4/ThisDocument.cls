VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ThisDocument"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = True
Sub Макрос1()
'
' Макрос1 Макрос
'
Dim slovo As String
slovo = InputBox("Введите слово", Title, "", 100, 100)
Selection.Find.ClearFormatting
With Selection.Find
.Text = slovo '""
.Replacement.Text = ""
.Forward = True
.Wrap = wdFindContinue
.Format = False
.MatchCase = False
.MatchWholeWord = False
.MatchWildcards = False
.MatchSoundsLike = False
.MatchAllWordForms = False
End With
Selection.Find.Execute
Selection.Font.Size = Slider1.Value '9
Selection.MoveRight Unit:=wdCharacter, Count:=1
End Sub


Private Sub Slider1_Click()
Label1 = Slider1.Value
End Sub
