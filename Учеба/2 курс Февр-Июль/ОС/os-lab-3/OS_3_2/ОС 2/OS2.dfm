object Form1: TForm1
  Left = 183
  Top = 114
  Caption = #1055#1088#1086#1094#1077#1089#1089#1099' '#1080' '#1087#1086#1090#1086#1082#1080
  ClientHeight = 531
  ClientWidth = 778
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 35
    Top = 360
    Width = 3
    Height = 13
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 762
    Height = 346
    FixedCols = 0
    RowCount = 10
    TabOrder = 0
    OnSelectCell = StringGrid1SelectCell
    ColWidths = (
      109
      134
      161
      154
      160)
  end
  object Button1: TButton
    Left = 32
    Top = 416
    Width = 121
    Height = 65
    Caption = #1055#1086#1082#1072#1079#1072#1090#1100' '#1087#1088#1086#1094#1077#1089#1089#1099
    TabOrder = 1
    OnClick = Button1Click
  end
  object StringGrid2: TStringGrid
    Left = 392
    Top = 360
    Width = 360
    Height = 137
    DefaultColWidth = 70
    TabOrder = 2
  end
  object Button2: TButton
    Left = 208
    Top = 416
    Width = 113
    Height = 65
    Caption = #1059#1073#1080#1090#1100' '#1087#1088#1086#1094#1077#1089#1089'!'
    TabOrder = 3
    OnClick = Button2Click
  end
end
