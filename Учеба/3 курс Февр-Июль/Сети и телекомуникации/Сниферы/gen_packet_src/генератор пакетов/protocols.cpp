//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "protocols.h"
#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TFprotocol *Fprotocol;
//---------------------------------------------------------------------------
__fastcall TFprotocol::TFprotocol(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TFprotocol::BitBtn1Click(TObject *Sender)
{
Fprotocol->Close();
Fmain->BitBtn1->Enabled=true;
}
//---------------------------------------------------------------------------
