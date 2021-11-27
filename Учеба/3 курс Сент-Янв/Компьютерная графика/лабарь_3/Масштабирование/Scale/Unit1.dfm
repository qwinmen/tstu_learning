object Form1: TForm1
  Left = 310
  Top = 160
  Width = 640
  Height = 460
  Caption = #1052#1072#1089#1096#1090#1072#1073#1080#1088#1086#1074#1072#1085#1080#1077
  Color = clBtnFace
  Constraints.MinHeight = 400
  Constraints.MinWidth = 600
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 0
    Top = 375
    Width = 632
    Height = 55
    Align = alBottom
    TabOrder = 0
    DesignSize = (
      632
      55)
    object Label3: TLabel
      Left = 8
      Top = 5
      Width = 308
      Height = 13
      Caption = #1055#1086#1089#1090#1088#1086#1077#1085#1080#1077' '#1092#1080#1075#1091#1088#1099' '#1089' '#1079#1072#1085#1077#1089#1077#1085#1080#1077#1084' '#1082#1086#1086#1088#1076#1080#1085#1072#1090' '#1074' '#1092#1072#1081#1083' plot.dat'
    end
    object Label4: TLabel
      Left = 392
      Top = 5
      Width = 229
      Height = 13
      Anchors = [akTop, akRight]
      Caption = #1063#1090#1077#1085#1080#1077' '#1080#1079' '#1092#1072#1081#1083#1072' '#1080' '#1087#1086#1089#1090#1088#1086#1077#1085#1080#1077' '#1080#1079#1086#1073#1088#1072#1078#1077#1085#1080#1103
    end
    object btnTreug: TButton
      Left = 9
      Top = 24
      Width = 77
      Height = 25
      Caption = #1058#1088#1077#1091#1075#1086#1083#1100#1085#1080#1082
      TabOrder = 0
      OnClick = btnTreugClick
    end
    object btnCurves: TButton
      Left = 161
      Top = 24
      Width = 56
      Height = 25
      Caption = #1050#1088#1080#1074#1072#1103
      TabOrder = 1
      OnClick = btnCurvesClick
    end
    object btnCircle: TButton
      Left = 86
      Top = 24
      Width = 75
      Height = 25
      Caption = #1054#1082#1088#1091#1078#1085#1086#1089#1090#1100
      TabOrder = 2
      OnClick = btnCircleClick
    end
    object btnStar: TButton
      Left = 217
      Top = 24
      Width = 56
      Height = 25
      Caption = #1047#1074#1077#1079#1076#1099
      TabOrder = 3
      OnClick = btnStarClick
    end
    object btnDraw: TButton
      Left = 548
      Top = 24
      Width = 75
      Height = 25
      Anchors = [akTop, akRight]
      Caption = 'Draw'
      TabOrder = 4
      OnClick = btnDrawClick
    end
    object chbProportion: TCheckBox
      Left = 393
      Top = 27
      Width = 152
      Height = 17
      Anchors = [akTop, akRight]
      Caption = #1057#1086#1093#1088#1072#1085#1103#1090#1100' '#1087#1088#1086#1087#1086#1088#1094#1080#1080
      Checked = True
      State = cbChecked
      TabOrder = 5
    end
    object btnLines: TButton
      Left = 273
      Top = 24
      Width = 62
      Height = 25
      Caption = #1051#1080#1085#1080#1080
      TabOrder = 6
      OnClick = btnLinesClick
    end
  end
  object Panel2: TPanel
    Left = 0
    Top = 25
    Width = 632
    Height = 350
    Align = alClient
    TabOrder = 1
    object Panel3: TPanel
      Left = 1
      Top = 1
      Width = 330
      Height = 348
      Align = alClient
      TabOrder = 0
      object PaintBox1: TPaintBox
        Left = 1
        Top = 1
        Width = 328
        Height = 346
        Align = alClient
      end
    end
    object Panel4: TPanel
      Left = 331
      Top = 1
      Width = 300
      Height = 348
      Align = alRight
      TabOrder = 1
      object Splitter1: TSplitter
        Left = 192
        Top = 1
        Width = 8
        Height = 346
        Align = alRight
      end
      object lbxScale: TListBox
        Left = 200
        Top = 1
        Width = 99
        Height = 346
        Align = alRight
        ItemHeight = 13
        TabOrder = 0
      end
      object lbxReal: TListBox
        Left = 1
        Top = 1
        Width = 191
        Height = 346
        Align = alClient
        ItemHeight = 13
        TabOrder = 1
      end
    end
  end
  object Panel5: TPanel
    Left = 0
    Top = 0
    Width = 632
    Height = 25
    Align = alTop
    TabOrder = 2
    DesignSize = (
      632
      25)
    object Label1: TLabel
      Left = 333
      Top = 8
      Width = 115
      Height = 13
      Anchors = [akTop, akRight]
      Caption = #1056#1077#1072#1083#1100#1085#1099#1077' '#1082#1086#1086#1088#1076#1080#1085#1072#1090#1099
    end
    object Label2: TLabel
      Left = 8
      Top = 8
      Width = 70
      Height = 13
      Caption = #1048#1079#1086#1073#1088#1072#1078#1077#1085#1080#1077
    end
    object Label5: TLabel
      Left = 531
      Top = 8
      Width = 61
      Height = 13
      Anchors = [akTop, akRight]
      Caption = #1042' '#1084#1072#1089#1096#1090#1072#1073#1077
    end
  end
end
