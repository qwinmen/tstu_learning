//---------------------------------------------------------------------------

#ifndef dataH
#define dataH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include "CSPIN.h"
//---------------------------------------------------------------------------
class TFdata : public TForm
{
__published:	// IDE-managed Components
        TGroupBox *GroupBox1;
        TCSpinEdit *data_size;
        TLabel *Label1;
        TGroupBox *GroupBox2;
        TCheckBox *crash_crc;
        TButton *Button1;
        TButton *Button2;
private:	// User declarations
public:		// User declarations
        __fastcall TFdata(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFdata *Fdata;
//---------------------------------------------------------------------------
#endif
