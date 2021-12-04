object Fdata: TFdata
  Left = 426
  Top = 284
  Width = 299
  Height = 116
  AutoSize = True
  Caption = #1044#1086#1073#1072#1074#1083#1077#1085#1080#1077' '#1076#1072#1085#1085#1099#1093
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
  object GroupBox1: TGroupBox
    Left = 0
    Top = 0
    Width = 145
    Height = 57
    TabOrder = 0
    object Label1: TLabel
      Left = 16
      Top = 8
      Width = 112
      Height = 13
      Caption = #1056#1072#1079#1084#1077#1088' '#1073#1083#1086#1082#1072' '#1076#1072#1085#1085#1099#1093
    end
    object data_size: TCSpinEdit
      Left = 16
      Top = 24
      Width = 113
      Height = 22
      MaxValue = 100000
      TabOrder = 0
    end
  end
  object GroupBox2: TGroupBox
    Left = 152
    Top = 0
    Width = 137
    Height = 57
    TabOrder = 1
    object crash_crc: TCheckBox
      Left = 16
      Top = 24
      Width = 97
      Height = 17
      Caption = #1048#1089#1087#1086#1088#1090#1080#1090#1100' CRC'
      TabOrder = 0
    end
  end
  object Button1: TButton
    Left = 136
    Top = 64
    Width = 75
    Height = 25
    Caption = 'Ok'
    ModalResult = 1
    TabOrder = 2
  end
  object Button2: TButton
    Left = 216
    Top = 64
    Width = 75
    Height = 25
    Caption = #1054#1090#1084#1077#1085#1072
    ModalResult = 2
    TabOrder = 3
  end
end
