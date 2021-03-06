object Form1: TForm1
  Left = 324
  Top = 111
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = #1054#1057', '#1083#1072#1073#1086#1088#1072#1090#1086#1088#1085#1072#1103' '#1088#1072#1073#1086#1090#1072' '#8470'4'
  ClientHeight = 520
  ClientWidth = 886
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  PixelsPerInch = 96
  TextHeight = 13
  object ProcessHandleLabel: TLabel
    Left = 88
    Top = 240
    Width = 98
    Height = 13
    Caption = 'ProcessHandleLabel'
  end
  object PaintBoxWhole: TPaintBox
    Left = 288
    Top = 248
    Width = 256
    Height = 256
    OnMouseDown = PaintBoxWholeMouseDown
    OnPaint = PaintBoxWholePaint
  end
  object Label1: TLabel
    Left = 224
    Top = 248
    Width = 59
    Height = 13
    Caption = '0x00000000'
  end
  object Label2: TLabel
    Left = 224
    Top = 492
    Width = 59
    Height = 13
    Caption = '0xFFFFFFFF'
  end
  object Label3: TLabel
    Left = 224
    Top = 376
    Width = 59
    Height = 13
    Caption = '0x80000000'
  end
  object Label4: TLabel
    Left = 224
    Top = 360
    Width = 59
    Height = 13
    Caption = '0x7FFFFFFF'
  end
  object lbSelectedRange: TLabel
    Left = 616
    Top = 230
    Width = 237
    Height = 13
    Caption = #1042#1099#1073#1088#1072#1085#1085#1099#1081' '#1076#1080#1072#1087#1072#1079#1086#1085': 0x00000000-0x00000000'
  end
  object lbLowestSelected: TLabel
    Left = 552
    Top = 248
    Width = 59
    Height = 13
    Caption = '0x00000000'
  end
  object lbMiddleSelectedLow: TLabel
    Left = 552
    Top = 360
    Width = 59
    Height = 13
    Caption = '0x7FFFFFFF'
  end
  object lbMiddleSelectedHigh: TLabel
    Left = 552
    Top = 376
    Width = 59
    Height = 13
    Caption = '0x80000000'
  end
  object lbHighestSelected: TLabel
    Left = 552
    Top = 492
    Width = 59
    Height = 13
    Caption = '0xFFFFFFFF'
  end
  object PaintBoxSelected: TPaintBox
    Left = 616
    Top = 248
    Width = 256
    Height = 256
    OnMouseDown = PaintBoxSelectedMouseDown
    OnPaint = PaintBoxSelectedPaint
  end
  object Label14: TLabel
    Left = 616
    Top = 216
    Width = 249
    Height = 13
    Caption = #1050#1072#1088#1090#1072' '#1074#1099#1073#1088#1072#1085#1085#1086#1075#1086' '#1076#1080#1072#1087#1072#1079#1086#1085#1072' ('#1087#1086' 4 '#1050#1073' '#1085#1072' '#1103#1095#1077#1081#1082#1091')'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlue
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label15: TLabel
    Left = 288
    Top = 216
    Width = 253
    Height = 29
    AutoSize = False
    Caption = 
      #1050#1072#1088#1090#1072' '#1074#1080#1088#1090#1091#1072#1083#1100#1085#1086#1081' '#1087#1072#1084#1103#1090#1080' '#1074#1089#1077#1075#1086' '#1087#1088#1086#1094#1077#1089#1089#1072' ('#1082#1072#1078#1076#1086#1081' '#1103#1095#1077#1081#1082#1077' '#1089#1086#1086#1090#1074#1077#1090#1089#1090 +
      #1074#1091#1077#1090' 4 '#1052#1073' '#1087#1072#1084#1103#1090#1080')'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlue
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    WordWrap = True
  end
  object Label16: TLabel
    Left = 616
    Top = 504
    Width = 145
    Height = 13
    Caption = #1040#1076#1088#1077#1089' '#1074#1099#1073#1088#1072#1085#1085#1086#1081' '#1089#1090#1088#1072#1085#1080#1094#1099':'
  end
  object lbSelectedPage: TLabel
    Left = 768
    Top = 504
    Width = 53
    Height = 13
    Caption = #1085#1077' '#1074#1099#1073#1088#1072#1085
  end
  object MemoryChart: TChart
    Left = 8
    Top = 8
    Width = 217
    Height = 193
    AllowPanning = pmNone
    AllowZoom = False
    BackWall.Brush.Color = clWhite
    BackWall.Brush.Style = bsClear
    BackWall.Pen.Visible = False
    Title.Text.Strings = (
      #1055#1072#1084#1103#1090#1100)
    AxisVisible = False
    ClipPoints = False
    Frame.Visible = False
    Legend.Alignment = laTop
    View3DOptions.Elevation = 315
    View3DOptions.Orthogonal = False
    View3DOptions.Perspective = 0
    View3DOptions.Rotation = 360
    View3DWalls = False
    TabOrder = 0
    object Series1: TPieSeries
      Marks.ArrowLength = 8
      Marks.Style = smsPercent
      Marks.Visible = True
      SeriesColor = clRed
      Title = 'MemorySeries'
      OtherSlice.Text = 'Other'
      PieValues.DateTime = False
      PieValues.Name = 'Pie'
      PieValues.Multiplier = 1.000000000000000000
      PieValues.Order = loNone
    end
  end
  object PhysicalChart: TChart
    Left = 232
    Top = 8
    Width = 209
    Height = 193
    AllowPanning = pmNone
    AllowZoom = False
    BackWall.Brush.Color = clWhite
    BackWall.Brush.Style = bsClear
    BackWall.Pen.Visible = False
    Title.Text.Strings = (
      #1060#1080#1079#1080#1095#1077#1089#1082#1072#1103' '#1087#1072#1084#1103#1090#1100)
    AxisVisible = False
    ClipPoints = False
    Frame.Visible = False
    Legend.Alignment = laTop
    View3DOptions.Elevation = 315
    View3DOptions.Orthogonal = False
    View3DOptions.Perspective = 0
    View3DOptions.Rotation = 360
    View3DWalls = False
    TabOrder = 1
    object PieSeries1: TPieSeries
      Marks.ArrowLength = 8
      Marks.Style = smsPercent
      Marks.Visible = True
      SeriesColor = clRed
      Title = 'PhisycalSeries'
      OtherSlice.Text = 'Other'
      PieValues.DateTime = False
      PieValues.Name = 'Pie'
      PieValues.Multiplier = 1.000000000000000000
      PieValues.Order = loNone
    end
  end
  object PageFileChart: TChart
    Left = 448
    Top = 8
    Width = 209
    Height = 193
    AllowPanning = pmNone
    AllowZoom = False
    BackWall.Brush.Color = clWhite
    BackWall.Brush.Style = bsClear
    BackWall.Pen.Visible = False
    Title.Text.Strings = (
      #1060#1072#1081#1083' '#1087#1086#1076#1082#1072#1095#1082#1080)
    AxisVisible = False
    ClipPoints = False
    Frame.Visible = False
    Legend.Alignment = laTop
    View3DOptions.Elevation = 315
    View3DOptions.Orthogonal = False
    View3DOptions.Perspective = 0
    View3DOptions.Rotation = 360
    View3DWalls = False
    TabOrder = 2
    object PieSeries2: TPieSeries
      Marks.ArrowLength = 8
      Marks.Style = smsPercent
      Marks.Visible = True
      SeriesColor = clRed
      Title = 'PageFileSeries'
      OtherSlice.Text = 'Other'
      PieValues.DateTime = False
      PieValues.Name = 'Pie'
      PieValues.Multiplier = 1.000000000000000000
      PieValues.Order = loNone
    end
  end
  object VirtualChart: TChart
    Left = 664
    Top = 8
    Width = 209
    Height = 193
    AllowPanning = pmNone
    AllowZoom = False
    BackWall.Brush.Color = clWhite
    BackWall.Brush.Style = bsClear
    BackWall.Pen.Visible = False
    Title.Text.Strings = (
      #1042#1080#1088#1090#1091#1072#1083#1100#1085#1072#1103' '#1087#1072#1084#1103#1090#1100)
    AxisVisible = False
    ClipPoints = False
    Frame.Visible = False
    Legend.Alignment = laTop
    View3DOptions.Elevation = 315
    View3DOptions.Orthogonal = False
    View3DOptions.Perspective = 0
    View3DOptions.Rotation = 360
    View3DWalls = False
    TabOrder = 3
    object PieSeries3: TPieSeries
      Marks.ArrowLength = 8
      Marks.Style = smsPercent
      Marks.Visible = True
      SeriesColor = clRed
      Title = 'VirtualSeries'
      OtherSlice.Text = 'Other'
      PieValues.DateTime = False
      PieValues.Name = 'Pie'
      PieValues.Multiplier = 1.000000000000000000
      PieValues.Order = loNone
    end
  end
  object ProcessesComboBox: TComboBox
    Left = 8
    Top = 216
    Width = 217
    Height = 21
    ItemHeight = 13
    Sorted = True
    TabOrder = 4
    OnChange = ProcessesComboBoxChange
  end
  object RefreshProcessesButton: TButton
    Left = 8
    Top = 240
    Width = 75
    Height = 17
    Caption = #1054#1073#1085#1086#1074#1080#1090#1100
    TabOrder = 5
    OnClick = RefreshProcessesButtonClick
  end
  object gbLegend: TGroupBox
    Left = 8
    Top = 265
    Width = 209
    Height = 208
    Caption = #1058#1080#1087#1099' '#1073#1083#1086#1082#1086#1074' '#1087#1072#1084#1103#1090#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlue
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 6
    object ShapeUnknown: TShape
      Left = 8
      Top = 24
      Width = 21
      Height = 17
    end
    object Label5: TLabel
      Left = 36
      Top = 24
      Width = 69
      Height = 13
      Caption = #1053#1077#1080#1079#1074#1077#1089#1090#1085#1099#1081
      Color = clBtnFace
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlack
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
    end
    object ShapeFree: TShape
      Left = 8
      Top = 46
      Width = 21
      Height = 17
    end
    object Label6: TLabel
      Left = 36
      Top = 46
      Width = 57
      Height = 13
      Caption = #1057#1074#1086#1073#1086#1076#1085#1099#1081
      Color = clBtnFace
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlack
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
    end
    object ShapeMixed: TShape
      Left = 8
      Top = 176
      Width = 21
      Height = 17
    end
    object Label7: TLabel
      Left = 36
      Top = 176
      Width = 88
      Height = 13
      Caption = #1053#1077#1089#1082#1086#1083#1100#1082#1086' '#1090#1080#1087#1086#1074
      Color = clBtnFace
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlack
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
    end
    object ShapeSystem: TShape
      Left = 8
      Top = 68
      Width = 21
      Height = 17
    end
    object Label8: TLabel
      Left = 36
      Top = 68
      Width = 58
      Height = 13
      Caption = #1057#1080#1089#1090#1077#1084#1085#1099#1081
      Color = clBtnFace
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlack
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
    end
    object ShapePrivate: TShape
      Left = 8
      Top = 110
      Width = 21
      Height = 17
    end
    object ShapeMapped: TShape
      Left = 8
      Top = 132
      Width = 21
      Height = 17
    end
    object ShapeImage: TShape
      Left = 8
      Top = 154
      Width = 21
      Height = 17
    end
    object Label9: TLabel
      Left = 36
      Top = 154
      Width = 105
      Height = 13
      Caption = #1048#1089#1087#1086#1083#1085#1103#1077#1084#1099#1081' '#1086#1073#1088#1072#1079
      Color = clBtnFace
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlack
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
    end
    object ShapeReserved: TShape
      Left = 8
      Top = 90
      Width = 21
      Height = 17
    end
    object Label10: TLabel
      Left = 36
      Top = 90
      Width = 105
      Height = 13
      Caption = #1047#1072#1088#1077#1079#1077#1088#1074#1080#1088#1086#1074#1072#1085#1085#1099#1081
      Color = clBtnFace
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlack
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
    end
    object Label11: TLabel
      Left = 36
      Top = 110
      Width = 165
      Height = 13
      Caption = #1055#1088#1080#1085#1072#1076#1083#1077#1078#1080#1090' '#1076#1072#1085#1085#1086#1084#1091' '#1087#1088#1086#1094#1077#1089#1089#1091
      Color = clBtnFace
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlack
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
    end
    object Label12: TLabel
      Left = 36
      Top = 132
      Width = 72
      Height = 13
      Caption = #1054#1073#1088#1072#1079' '#1076#1072#1085#1085#1099#1093
      Color = clBtnFace
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlack
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
    end
  end
  object btnRefreshProcessMap: TButton
    Left = 8
    Top = 480
    Width = 209
    Height = 25
    Caption = #1054#1073#1085#1086#1074#1080#1090#1100' '#1082#1072#1088#1090#1091' '#1087#1088#1086#1094#1077#1089#1089#1072
    TabOrder = 7
    OnClick = btnRefreshProcessMapClick
  end
  object DiagramsTimer: TTimer
    Interval = 500
    OnTimer = DiagramsTimerTimer
  end
end
