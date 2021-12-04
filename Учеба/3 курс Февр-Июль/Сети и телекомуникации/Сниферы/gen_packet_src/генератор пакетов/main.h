//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Mask.hpp>
#include <Buttons.hpp>

//#include <winsock2.h>
//---------------------------------------------------------------------------
class TFmain : public TForm
{
__published:	// IDE-managed Components
        TGroupBox *IPHeader;
        TLabel *Label1;
        TLabel *Label2;
        TLabel *Label3;
        TLabel *Label4;
        TEdit *ip_ttl;
        TComboBox *tip_proto;
        TLabel *Label5;
        TEdit *ip_ident;
        TGroupBox *Param_packet;
        TEdit *packet_size;
        TLabel *Label16;
        TEdit *col_packet;
        TLabel *Label17;
        TLabel *Label18;
        TBitBtn *BitBtn1;
        TBitBtn *BitBtn2;
        TBitBtn *BitBtn3;
        TEdit *ip_dest_adr;
        TEdit *ip_sour_adr;
        TComboBox *ip_tos;
        TLabel *Label19;
        TComboBox *ip_flags;
        TLabel *Label20;
        TEdit *Edit1;
        TLabel *Label21;
        TBitBtn *BitBtn4;
        TBitBtn *BitBtn5;
        void __fastcall BitBtn3Click(TObject *Sender);
        void __fastcall BitBtn1Click(TObject *Sender);
        void __fastcall BitBtn4Click(TObject *Sender);
        void __fastcall tip_protoChange(TObject *Sender);
        void __fastcall BitBtn5Click(TObject *Sender);
        void __fastcall BitBtn2Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TFmain(TComponent* Owner);
        int data_size;
        bool crash_crc;
        int col_send_packet;
        bool send_error;
};
//---------------------------------------------------------------------------
extern PACKAGE TFmain *Fmain;
//---------------------------------------------------------------------------
#endif
