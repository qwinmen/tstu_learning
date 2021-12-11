object Form1: TForm1
  Left = 398
  Top = 212
  Width = 187
  Height = 198
  Caption = #1040#1050#1080#1058#1055
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 8
    Width = 55
    Height = 13
    Caption = #1044#1083#1080#1085#1072', '#1084#1084
  end
  object Label2: TLabel
    Left = 8
    Top = 48
    Width = 61
    Height = 13
    Caption = #1064#1080#1088#1080#1085#1072', '#1084#1084
  end
  object Edit1: TEdit
    Left = 8
    Top = 24
    Width = 137
    Height = 21
    TabOrder = 0
    Text = '500'
    OnKeyPress = Edit1KeyPress
  end
  object UpDown1: TUpDown
    Left = 145
    Top = 24
    Width = 16
    Height = 21
    Associate = Edit1
    Min = 100
    Max = 800
    Increment = 10
    Position = 500
    TabOrder = 1
    Wrap = False
  end
  object Edit2: TEdit
    Left = 8
    Top = 64
    Width = 137
    Height = 21
    TabOrder = 2
    Text = '500'
    OnKeyPress = Edit1KeyPress
  end
  object UpDown2: TUpDown
    Left = 145
    Top = 64
    Width = 16
    Height = 21
    Associate = Edit2
    Min = 100
    Max = 800
    Increment = 10
    Position = 500
    TabOrder = 3
    Wrap = False
  end
  object BitBtn1: TBitBtn
    Left = 8
    Top = 91
    Width = 153
    Height = 25
    Caption = #1053#1086#1074#1099#1081' '#1087#1088#1086#1077#1082#1090
    ModalResult = 8
    TabOrder = 4
    OnClick = BitBtn1Click
    NumGlyphs = 2
  end
  object BitBtn2: TBitBtn
    Left = 8
    Top = 128
    Width = 153
    Height = 25
    Cancel = True
    Caption = #1042#1099#1093#1086#1076
    ModalResult = 7
    TabOrder = 5
    OnClick = BitBtn2Click
    NumGlyphs = 2
  end
end
