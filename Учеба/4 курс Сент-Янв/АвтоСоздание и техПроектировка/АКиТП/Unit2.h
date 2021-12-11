//---------------------------------------------------------------------------

#ifndef Unit2H
#define Unit2H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Menus.hpp>
#include <ExtCtrls.hpp>
#include <ComCtrls.hpp>
#include <Grids.hpp>
#include <Buttons.hpp>
//---------------------------------------------------------------------------
class TForm2 : public TForm
{
__published:	// IDE-managed Components
        TScrollBox *ScrollBox1;
        TMainMenu *MainMenu1;
        TMenuItem *N1;
        TMenuItem *N2;
        TMenuItem *N3;
        TMenuItem *N4;
        TPaintBox *PaintBox1;
        TStatusBar *StatusBar1;
        TMenuItem *N5;
        TMenuItem *N6;
        TMenuItem *N7;
        TMenuItem *N9;
        TMenuItem *N10;
        TMenuItem *N11;
        TScrollBox *ScrollBox2;
        TSpeedButton *SpeedButton1;
        TSpeedButton *SpeedButton2;
        TSpeedButton *SpeedButton3;
        TGroupBox *GroupBox1;
        TStringGrid *StringGrid1;
        TEdit *Edit1;
        TUpDown *UpDown1;
        TGroupBox *GroupBox2;
        TStringGrid *StringGrid2;
        TEdit *Edit2;
        TUpDown *UpDown2;
        TButton *Button2;
        TComboBox *ComboBox1;
        TComboBox *ComboBox2;
        TButton *Button3;
        TGroupBox *GroupBox3;
        TStringGrid *StringGrid3;
        TEdit *Edit3;
        TUpDown *UpDown3;
        TButton *Button1;
        TButton *Button4;
        TMenuItem *N12;
        TMenuItem *N13;
        TButton *Button5;
        TMenuItem *N14;
        TMenuItem *N15;
        TMenuItem *N16;
        TMenuItem *N8;
        TEdit *Edit4;
        TLabel *Label1;
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall N2Click(TObject *Sender);
        void __fastcall PaintBox1Paint(TObject *Sender);
        void __fastcall PaintBox1MouseMove(TObject *Sender,
          TShiftState Shift, int X, int Y);
        void __fastcall PaintBox1MouseDown(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall PaintBox1MouseUp(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall N4Click(TObject *Sender);
        void __fastcall N7Click(TObject *Sender);
        void __fastcall N10Click(TObject *Sender);
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall ComboBox1Change(TObject *Sender);
        void __fastcall ComboBox2Change(TObject *Sender);
        void __fastcall Button3Click(TObject *Sender);
        void __fastcall Button2Click(TObject *Sender);
        void __fastcall N11Click(TObject *Sender);
        void __fastcall Button4Click(TObject *Sender);
        void __fastcall N12Click(TObject *Sender);
        void __fastcall Button5Click(TObject *Sender);
        void __fastcall N15Click(TObject *Sender);
        void __fastcall N16Click(TObject *Sender);
        void __fastcall N8Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm2(TComponent* Owner);
        void __fastcall PaintAll();
        void __fastcall ALG(int num);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm2 *Form2;
//---------------------------------------------------------------------------
#endif
