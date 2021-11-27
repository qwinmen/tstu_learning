//---------------------------------------------------------------------------

#ifndef ZBuffer3H
#define ZBuffer3H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
#include <Buttons.hpp>
#include <Grids.hpp>
#include <Dialogs.hpp>
#include <Menus.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TSpeedButton *SpeedButton2;
	TSpeedButton *SpeedButton1;

		void __fastcall N2Click(TObject *Sender);
		void __fastcall SpeedButton2Click(TObject *Sender);
		void __fastcall SpeedButton1Click(TObject *Sender);

private:	// User declarations
public:		// User declarations
		__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
