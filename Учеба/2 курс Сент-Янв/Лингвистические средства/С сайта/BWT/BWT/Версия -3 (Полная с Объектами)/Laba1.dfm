object Form1: TForm1
  Left = 343
  Top = 187
  Width = 339
  Height = 410
  HelpContext = 2
  ActiveControl = Memo1
  BorderIcons = [biSystemMenu, biHelp]
  Caption = 'BWT'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 8
    Width = 300
    Height = 23
    Caption = #1042#1074#1077#1076#1080#1090#1077' '#1082#1086#1076#1080#1088#1091#1077#1084#1086#1077' '#1089#1086#1086#1073#1097#1077#1085#1080#1077':'
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clPurple
    Font.Height = -20
    Font.Name = 'Times New Roman'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label2: TLabel
    Left = 8
    Top = 144
    Width = 270
    Height = 13
    Caption = #1048#1089#1093#1086#1076#1085#1072#1103' '#1089#1090#1088#1086#1082#1072' '#1074#1089#1090#1088#1077#1095#1072#1077#1090#1089#1103' '#1074' '#1089#1090#1088#1086#1082#1077' '#1087#1086#1076' '#1085#1086#1084#1077#1088#1086#1084
  end
  object Label3: TLabel
    Left = 8
    Top = 240
    Width = 52
    Height = 13
    Caption = #1056#1077#1079#1091#1083#1100#1090#1072#1090
  end
  object Edit2: TEdit
    Left = 8
    Top = 168
    Width = 97
    Height = 21
    TabOrder = 1
  end
  object Memo1: TMemo
    Left = 8
    Top = 32
    Width = 313
    Height = 105
    ScrollBars = ssVertical
    TabOrder = 0
  end
  object Memo2: TMemo
    Left = 8
    Top = 224
    Width = 313
    Height = 105
    ScrollBars = ssVertical
    TabOrder = 2
  end
  object MainMenu1: TMainMenu
    Left = 128
    Top = 168
    object N1: TMenuItem
      Caption = #1060#1072#1081#1083
      object N4: TMenuItem
        Caption = #1054#1090#1082#1088#1099#1090#1100
        OnClick = N4Click
      end
      object N5: TMenuItem
        Caption = #1042#1099#1093#1086#1076
        OnClick = N5Click
      end
    end
    object N2: TMenuItem
      Caption = #1050#1086#1076#1080#1088#1086#1074#1072#1085#1080#1077
      OnClick = N2Click
    end
    object N3: TMenuItem
      Caption = #1044#1077#1082#1086#1076#1080#1088#1086#1074#1072#1085#1080#1077
      OnClick = N3Click
    end
  end
  object OpenDialog1: TOpenDialog
    Left = 168
    Top = 168
  end
end
