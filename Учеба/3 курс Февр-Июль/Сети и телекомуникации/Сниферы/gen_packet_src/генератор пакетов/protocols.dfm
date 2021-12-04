object Fprotocol: TFprotocol
  Left = 445
  Top = 254
  Width = 249
  Height = 292
  Caption = #1047#1072#1087#1086#1083#1085#1077#1085#1080#1077' '#1079#1072#1075#1086#1083#1086#1074#1082#1072
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
  object TCPHeader: TGroupBox
    Left = 0
    Top = 0
    Width = 241
    Height = 233
    Caption = #1047#1072#1075#1086#1083#1086#1074#1086#1082' TCP'
    TabOrder = 0
    Visible = False
    object Label6: TLabel
      Left = 8
      Top = 24
      Width = 85
      Height = 13
      Caption = #1055#1086#1088#1090' '#1087#1086#1083#1091#1095#1072#1090#1077#1083#1103
    end
    object Label7: TLabel
      Left = 8
      Top = 64
      Width = 92
      Height = 13
      Caption = #1055#1086#1088#1090' '#1086#1090#1087#1088#1072#1074#1080#1090#1077#1083#1103
    end
    object Label8: TLabel
      Left = 136
      Top = 24
      Width = 66
      Height = 13
      Caption = #1056#1072#1079#1084#1077#1088' '#1086#1082#1085#1072
    end
    object Label9: TLabel
      Left = 112
      Top = 64
      Width = 116
      Height = 13
      Caption = #1053#1086#1084#1077#1088' '#1087#1086#1076#1090#1074#1077#1088#1078#1076#1077#1085#1080#1103
    end
    object Label10: TLabel
      Left = 48
      Top = 104
      Width = 143
      Height = 13
      Caption = #1053#1086#1084#1077#1088' '#1087#1086#1089#1083#1077#1076#1086#1074#1072#1090#1077#1083#1100#1085#1086#1089#1090#1080
    end
    object tcp_d_port: TEdit
      Left = 8
      Top = 40
      Width = 97
      Height = 21
      TabOrder = 0
      Text = '1300'
    end
    object tcp_s_port: TEdit
      Left = 8
      Top = 80
      Width = 97
      Height = 21
      TabOrder = 1
      Text = '402'
    end
    object GroupBox3: TGroupBox
      Left = 8
      Top = 144
      Width = 225
      Height = 81
      Caption = #1060#1083#1072#1075#1080
      TabOrder = 2
      object SYN: TCheckBox
        Left = 8
        Top = 24
        Width = 57
        Height = 17
        Caption = 'SYN'
        TabOrder = 0
      end
      object FIN: TCheckBox
        Left = 8
        Top = 48
        Width = 57
        Height = 17
        Caption = 'FIN'
        TabOrder = 1
      end
      object ASK: TCheckBox
        Left = 56
        Top = 48
        Width = 65
        Height = 17
        Caption = 'ACK'
        TabOrder = 2
      end
      object RST: TCheckBox
        Left = 56
        Top = 24
        Width = 65
        Height = 17
        Caption = 'RST'
        TabOrder = 3
      end
      object PSH: TCheckBox
        Left = 112
        Top = 24
        Width = 49
        Height = 17
        Caption = 'PSH'
        TabOrder = 4
      end
      object URG: TCheckBox
        Left = 112
        Top = 48
        Width = 57
        Height = 17
        Caption = 'URG'
        TabOrder = 5
      end
      object CWR: TCheckBox
        Left = 168
        Top = 24
        Width = 49
        Height = 17
        Caption = 'CWR'
        TabOrder = 6
      end
      object ECE: TCheckBox
        Left = 168
        Top = 48
        Width = 41
        Height = 17
        Caption = 'ECE'
        TabOrder = 7
      end
    end
    object tcp_window: TEdit
      Left = 112
      Top = 40
      Width = 121
      Height = 21
      TabOrder = 3
      Text = '4096'
    end
    object tcp_asknumber: TEdit
      Left = 112
      Top = 80
      Width = 121
      Height = 21
      TabOrder = 4
      Text = '0'
    end
    object tcp_secv: TEdit
      Left = 8
      Top = 120
      Width = 225
      Height = 21
      TabOrder = 5
      Text = '875968000'
    end
  end
  object UDPHeader: TGroupBox
    Left = 0
    Top = 0
    Width = 169
    Height = 113
    Caption = #1047#1072#1075#1072#1083#1086#1074#1086#1082' UDP '
    TabOrder = 1
    Visible = False
    object Label11: TLabel
      Left = 40
      Top = 24
      Width = 85
      Height = 13
      Caption = #1055#1086#1088#1090' '#1087#1086#1083#1091#1095#1072#1090#1077#1083#1103
    end
    object Label12: TLabel
      Left = 40
      Top = 64
      Width = 92
      Height = 13
      Caption = #1055#1086#1088#1090' '#1086#1090#1087#1088#1072#1074#1080#1090#1077#1083#1103
    end
    object udp_d_port: TEdit
      Left = 24
      Top = 40
      Width = 121
      Height = 21
      TabOrder = 0
      Text = '1123'
    end
    object udp_s_port: TEdit
      Left = 24
      Top = 80
      Width = 121
      Height = 21
      TabOrder = 1
      Text = '123'
    end
  end
  object ICMPHeader: TGroupBox
    Left = 0
    Top = 0
    Width = 241
    Height = 145
    Caption = #1047#1072#1075#1072#1083#1086#1074#1086#1082' ICMP '
    TabOrder = 2
    Visible = False
    object Label13: TLabel
      Left = 10
      Top = 96
      Width = 59
      Height = 13
      Caption = 'ORIG_TIME'
    end
    object Label14: TLabel
      Left = 96
      Top = 16
      Width = 60
      Height = 13
      Caption = #1050#1086#1076' '#1087#1072#1082#1077#1090#1072' '
    end
    object Label15: TLabel
      Left = 96
      Top = 56
      Width = 57
      Height = 13
      Caption = #1058#1080#1087' '#1087#1072#1082#1077#1090#1072
    end
    object Label1: TLabel
      Left = 88
      Top = 96
      Width = 61
      Height = 13
      Caption = 'RECV_TIME'
    end
    object Label2: TLabel
      Left = 176
      Top = 96
      Width = 46
      Height = 13
      Caption = 'TX_TIME'
    end
    object orig_t: TEdit
      Left = 8
      Top = 112
      Width = 65
      Height = 21
      TabOrder = 0
      Text = '49241890'
    end
    object icmp_tip: TComboBox
      Left = 8
      Top = 72
      Width = 225
      Height = 21
      ItemHeight = 13
      TabOrder = 1
      Text = 'ICMP_ECHO'
      Items.Strings = (
        'ICMP_ECHO_REPLY'
        'ICMP_UNREACHABLE'
        'ICMP_QUENCH'
        'ICMP_REDIRECT'
        'ICMP_ECHO'
        'ICMP_TIME'
        'ICMP_PARAMETER'
        'ICMP_TIMESTAMP'
        'ICMP_TIMESTAMP_REPLY'
        'ICMP_INFORMATION'
        'ICMP_INFORMATION_REPLY')
    end
    object icmp_code: TComboBox
      Left = 8
      Top = 32
      Width = 225
      Height = 21
      ItemHeight = 13
      TabOrder = 2
      Text = 'ICMP_UNREACHABLE_NET'
      Items.Strings = (
        'ICMP_UNREACHABLE_NET'
        'ICMP_UNREACHABLE_HOST'
        'ICMP_UNREACHABLE_PROTOCOL'
        'ICMP_UNREACHABLE_PORT'
        'ICMP_UNREACHABLE_FRAGMENTATION'
        'ICMP_UNREACHABLE_SOURCE'
        'ICMP_UNREACHABLE_SIZE'
        'ICMP_TIME_TRANSIT'
        'ICMP_TIME_FRAGMENT'
        'ICMP_REDIRECT_NETWORK'
        'ICMP_REDIRECT_HOST'
        'ICMP_REDIRECT_SERVICE_NETWORK'
        'ICMP_REDIRECT_SERVICE_HOST')
    end
    object recv_t: TEdit
      Left = 88
      Top = 112
      Width = 65
      Height = 21
      TabOrder = 3
      Text = '49241890'
    end
    object tx_t: TEdit
      Left = 168
      Top = 112
      Width = 65
      Height = 21
      TabOrder = 4
      Text = '49241890'
    end
  end
  object BitBtn1: TBitBtn
    Left = 72
    Top = 240
    Width = 97
    Height = 25
    Caption = #1047#1072#1082#1088#1099#1090#1100
    TabOrder = 3
    OnClick = BitBtn1Click
    Glyph.Data = {
      76010000424D7601000000000000760000002800000020000000100000000100
      04000000000000010000120B0000120B00001000000000000000000000000000
      800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
      FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00330000000000
      03333377777777777F333301111111110333337F333333337F33330111111111
      0333337F333333337F333301111111110333337F333333337F33330111111111
      0333337F333333337F333301111111110333337F333333337F33330111111111
      0333337F3333333F7F333301111111B10333337F333333737F33330111111111
      0333337F333333337F333301111111110333337F33FFFFF37F3333011EEEEE11
      0333337F377777F37F3333011EEEEE110333337F37FFF7F37F3333011EEEEE11
      0333337F377777337F333301111111110333337F333333337F33330111111111
      0333337FFFFFFFFF7F3333000000000003333377777777777333}
    NumGlyphs = 2
  end
end
