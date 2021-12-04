//---------------------------------------------------------------------------

#ifndef protocolsH
#define protocolsH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Buttons.hpp>
//---------------------------------------------------------------------------
class TFprotocol : public TForm
{
__published:	// IDE-managed Components
        TGroupBox *TCPHeader;
        TLabel *Label6;
        TLabel *Label7;
        TLabel *Label8;
        TLabel *Label9;
        TLabel *Label10;
        TEdit *tcp_d_port;
        TEdit *tcp_s_port;
        TGroupBox *GroupBox3;
        TCheckBox *SYN;
        TCheckBox *FIN;
        TCheckBox *ASK;
        TCheckBox *RST;
        TCheckBox *PSH;
        TCheckBox *URG;
        TEdit *tcp_window;
        TEdit *tcp_asknumber;
        TEdit *tcp_secv;
        TGroupBox *UDPHeader;
        TLabel *Label11;
        TLabel *Label12;
        TEdit *udp_d_port;
        TEdit *udp_s_port;
        TGroupBox *ICMPHeader;
        TLabel *Label13;
        TLabel *Label14;
        TLabel *Label15;
        TEdit *orig_t;
        TComboBox *icmp_tip;
        TBitBtn *BitBtn1;
        TCheckBox *CWR;
        TCheckBox *ECE;
        TComboBox *icmp_code;
        TLabel *Label1;
        TEdit *recv_t;
        TLabel *Label2;
        TEdit *tx_t;
        void __fastcall BitBtn1Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TFprotocol(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFprotocol *Fprotocol;
//---------------------------------------------------------------------------
#endif
