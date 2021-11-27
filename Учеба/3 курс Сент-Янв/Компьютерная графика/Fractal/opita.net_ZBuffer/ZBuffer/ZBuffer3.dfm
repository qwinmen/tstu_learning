object Form1: TForm1
  Left = 249
  Top = 159
  BorderStyle = bsToolWindow
  Caption = 'Z-buffering demo'
  ClientHeight = 278
  ClientWidth = 309
  Color = clNavy
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWhite
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = [fsBold]
  OldCreateOrder = False
  Position = poScreenCenter
  PixelsPerInch = 96
  TextHeight = 13
  object SpeedButton2: TSpeedButton
    Left = 164
    Top = 232
    Width = 137
    Height = 33
    Caption = 'Quit'
    Flat = True
    OnClick = SpeedButton2Click
  end
  object SpeedButton1: TSpeedButton
    Left = 12
    Top = 232
    Width = 137
    Height = 33
    Caption = 'Z-buffering'
    Flat = True
    OnClick = SpeedButton1Click
  end
end
