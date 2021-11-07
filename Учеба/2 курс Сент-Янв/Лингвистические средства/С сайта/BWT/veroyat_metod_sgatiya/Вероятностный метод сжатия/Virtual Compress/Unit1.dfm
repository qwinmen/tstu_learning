object Form1: TForm1
  Left = 193
  Top = 105
  Width = 536
  Height = 457
  Caption = 'Form1'
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
    Left = 0
    Top = 0
    Width = 528
    Height = 22
    Align = alTop
    Alignment = taCenter
    Caption = #1042#1077#1088#1086#1103#1090#1085#1086#1089#1090#1085#1086#1077' '#1089#1078#1072#1090#1080#1077
    Color = clBtnFace
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Courier New'
    Font.Style = [fsBold]
    ParentColor = False
    ParentFont = False
  end
  object Button1: TButton
    Left = 32
    Top = 40
    Width = 81
    Height = 25
    Caption = 'Pack'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 144
    Top = 40
    Width = 81
    Height = 25
    Caption = 'Unpack'
    TabOrder = 1
    OnClick = Button2Click
  end
  object Edit1: TEdit
    Left = 24
    Top = 192
    Width = 209
    Height = 217
    TabOrder = 2
  end
  object Edit2: TEdit
    Left = 296
    Top = 192
    Width = 209
    Height = 217
    TabOrder = 3
  end
  object Button3: TButton
    Left = 248
    Top = 280
    Width = 33
    Height = 57
    Caption = '>>'
    TabOrder = 4
    OnClick = Button3Click
  end
  object Edit3: TEdit
    Left = 24
    Top = 88
    Width = 97
    Height = 21
    TabOrder = 5
  end
  object Button4: TButton
    Left = 432
    Top = 40
    Width = 73
    Height = 25
    Caption = 'Exit'
    TabOrder = 6
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 144
    Top = 88
    Width = 81
    Height = 25
    Caption = 'Arxiv'
    TabOrder = 7
    OnClick = Button5Click
  end
  object OpenDialog1: TOpenDialog
    Left = 248
    Top = 8
  end
end
