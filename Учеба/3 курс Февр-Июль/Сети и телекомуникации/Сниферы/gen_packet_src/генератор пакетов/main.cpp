//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "raw_socket.h"
#include "protocols.h"
#include "data.h"
#include <winsock2.h>
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TFmain *Fmain;
//---------------------------------------------------------------------------
__fastcall TFmain::TFmain(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TFmain::BitBtn3Click(TObject *Sender)
{
Application->Terminate();
}
////////////////////////////////////////////////////////////////////////////////

SOCKET rs_create_socket (void)
{
 SOCKET new_socket = WSASocket (AF_INET, SOCK_RAW, IPPROTO_RAW,NULL, 0,
                         WSA_FLAG_OVERLAPPED);

 if (new_socket == INVALID_SOCKET)
    {
     ShowMessage ("Ошибка создания сокета!\n");
    }
	
 return new_socket;
}

////////////////////////////////////////////////////////////////////////////////

int rs_close_socket (SOCKET s)
{
 return closesocket (s);
}

////////////////////////////////////////////////////////////////////////////////

//---------------------------------------------------------------------------
void send_packet (void)
{
 char str [20];
 char * _data;
 SOCKET s;
 struct ip_header iph;
 struct udp_header udph;
 struct tcp_header tcph;
 struct icmp_header icmph;

 // Заполнение загаловка IP
 iph.version=RS_IP_VERSION;
 iph.length = htons (StrToInt(Fmain->packet_size->Text));
 iph.id = htons (StrToInt(Fmain->ip_ident->Text));
 iph.ttl = atoi(Fmain->ip_ttl->Text.c_str());
 iph.ttl = atoi(Fmain->ip_ttl->Text.c_str());

 if (Fmain->ip_flags->Text=="Не фрагментировать") iph.flags = DONT_FRAG;
 if (Fmain->ip_flags->Text=="Можно фрогментировать")  iph.flags = MAY_FRAG;
 if (Fmain->ip_flags->Text=="Больше фрагментировать")  iph.flags = MORE_FRAG;
 if (Fmain->ip_flags->Text=="Фрагментировать последний")  iph.flags = LAST_FRAG;

  if (Fmain->ip_tos->Text=="Нормальный")  iph.tos= IP_TOS_0x00;
  if (Fmain->ip_tos->Text=="Минимальные задержки")  iph.tos = IP_TOS_0x02;
  if (Fmain->ip_tos->Text=="Максимальная производительность")  iph.tos = IP_TOS_0x04;
  if (Fmain->ip_tos->Text=="Максимальная надежность")  iph.tos = IP_TOS_0x08;
  if (Fmain->ip_tos->Text=="Минимальные затраты")  iph.tos = IP_TOS_0x10;

 iph.src_addr = inet_addr(Fmain->ip_sour_adr->Text.c_str());
 iph.dst_addr = inet_addr(Fmain->ip_dest_adr->Text.c_str());

 // Создание пустого буфера для данных.
 if (Fdata->data_size->Value) _data =(char *) calloc (Fdata->data_size->Value, sizeof (char));

 // Созлание RAW сокета.
 s = rs_create_socket ();
 rs_set_tos (s, 0);
 rs_set_raw (s);
 //******формирование загаловка протокола верхнего уровня и отправка пакета*********************
 //отсылаем "чистый" IP пакет (без вложений)
 if (Fmain->tip_proto->Text=="")
   {
   iph.proto = IPPROTO_IP;
   if (Fdata->data_size->Value) //если в пакете есть данные
     rs_send_ip (s, iph, _data, Fdata->data_size->Value, 0); //отсылаем пакет с данными
   else rs_send_ip (s, iph, NULL, 0, 0);   //отсылаем пустой пакет

   }
 // Заполнение заголовков протоколов верхнего уровня.
if (Fmain->tip_proto->Text=="TCP") //протокол верхнего уровня TCP
  {
  iph.proto = IPPROTO_TCP;
  tcph.src_port = htons (StrToInt(Fprotocol->tcp_s_port->Text));
  tcph.dst_port = htons (StrToInt(Fprotocol->tcp_d_port->Text));
  tcph.seq_n = htonl (StrToInt(Fprotocol->tcp_secv->Text));
  tcph.ack_n = htonl (StrToInt(Fprotocol->tcp_asknumber->Text));
  tcph.win = htons (StrToInt(Fprotocol->tcp_window->Text));
  // No urgent data,
  tcph.urg_ptr = 0;
  tcph.flags = 0;
  if (Fprotocol->URG->Checked) tcph.flags |= TCP_URG;
  if (Fprotocol->ASK->Checked) tcph.flags |= TCP_ACK;
  if (Fprotocol->PSH->Checked) tcph.flags |= TCP_PSH;
  if (Fprotocol->RST->Checked) tcph.flags |= TCP_RST;
  if (Fprotocol->SYN->Checked) tcph.flags |= TCP_SYN;
  if (Fprotocol->FIN->Checked) tcph.flags |= TCP_FIN;
  if (Fprotocol->ECE->Checked) tcph.flags |= TCP_ECE;
  if (Fprotocol->CWR->Checked) tcph.flags |= TCP_CWR;

  //отправляем готовы TCP пакет
  if (Fdata->data_size->Value) rs_send_tcp (s, iph, tcph, _data, Fdata->data_size->Value);
        else rs_send_tcp (s, iph, tcph, NULL, 0);
  }
if (Fmain->tip_proto->Text=="UDP") //протокол верхнего уровня UDP
  {
  //заполняем заголовок UDP пакета
  iph.proto = IPPROTO_UDP;
  udph.src_port = atoi (Fprotocol->udp_s_port->Text.c_str());
  udph.dst_port = atoi  (Fprotocol->udp_d_port->Text.c_str());
  //отправляем UDP пакет
  if (Fdata->data_size->Value) rs_send_udp (s, iph, udph, _data, Fdata->data_size->Value);
    else rs_send_udp (s, iph, udph, NULL, 0);
  }
if (Fmain->tip_proto->Text=="ICMP") //протокол верхнего уровня ICMP
  {
  //заполняем заголовок ICMP пакета
  iph.proto = IPPROTO_ICMP;
  if (Fprotocol->icmp_tip->Text=="ICMP_ECHO_REPLY") icmph.type =ICMP_ECHO_REPLY;
  if (Fprotocol->icmp_tip->Text=="ICMP_UNREACHABLE") icmph.type =ICMP_UNREACHABLE;
  if (Fprotocol->icmp_tip->Text=="ICMP_QUENCH") icmph.type =ICMP_QUENCH;
  if (Fprotocol->icmp_tip->Text=="ICMP_REDIRECT") icmph.type =ICMP_REDIRECT;
  if (Fprotocol->icmp_tip->Text=="ICMP_ECHO") icmph.type =ICMP_ECHO;
  if (Fprotocol->icmp_tip->Text=="ICMP_TIME") icmph.type =ICMP_TIME;
  if (Fprotocol->icmp_tip->Text=="ICMP_PARAMETER") icmph.type =ICMP_PARAMETER;
  if (Fprotocol->icmp_tip->Text=="ICMP_TIMESTAMP") icmph.type =ICMP_TIMESTAMP;
  if (Fprotocol->icmp_tip->Text=="ICMP_TIMESTAMP_REPLY") icmph.type =ICMP_TIMESTAMP_REPLY;
  if (Fprotocol->icmp_tip->Text=="ICMP_INFORMATION") icmph.type =ICMP_INFORMATION;
  if (Fprotocol->icmp_tip->Text=="ICMP_INFORMATION_REPLY") icmph.type =ICMP_INFORMATION_REPLY;

  if (Fprotocol->icmp_code->Text=="ICMP_UNREACHABLE_NET")  icmph.code=ICMP_UNREACHABLE_NET;
  if (Fprotocol->icmp_code->Text=="ICMP_UNREACHABLE_HOST")  icmph.code=ICMP_UNREACHABLE_HOST;
  if (Fprotocol->icmp_code->Text=="ICMP_UNREACHABLE_PROTOCOL")  icmph.code=ICMP_UNREACHABLE_PROTOCOL;
  if (Fprotocol->icmp_code->Text=="ICMP_UNREACHABLE_PORT")  icmph.code=ICMP_UNREACHABLE_PORT;
  if (Fprotocol->icmp_code->Text=="ICMP_UNREACHABLE_FRAGMENTATION")  icmph.code=ICMP_UNREACHABLE_FRAGMENTATION;
  if (Fprotocol->icmp_code->Text=="ICMP_UNREACHABLE_SOURCE")  icmph.code=ICMP_UNREACHABLE_SOURCE;
  if (Fprotocol->icmp_code->Text=="ICMP_UNREACHABLE_SIZE")  icmph.code=ICMP_UNREACHABLE_SIZE;
  if (Fprotocol->icmp_code->Text=="ICMP_TIME_TRANSIT")  icmph.code=ICMP_TIME_TRANSIT;
  if (Fprotocol->icmp_code->Text=="ICMP_TIME_FRAGMENT")  icmph.code=ICMP_TIME_FRAGMENT;
  if (Fprotocol->icmp_code->Text=="ICMP_REDIRECT_NETWORK")  icmph.code=ICMP_REDIRECT_NETWORK;
  if (Fprotocol->icmp_code->Text=="ICMP_REDIRECT_HOST")  icmph.code=ICMP_REDIRECT_HOST;
  if (Fprotocol->icmp_code->Text=="ICMP_REDIRECT_SERVICE_NETWORK")  icmph.code=ICMP_REDIRECT_SERVICE_NETWORK;
  if (Fprotocol->icmp_code->Text=="ICMP_REDIRECT_SERVICE_HOST")  icmph.code=ICMP_REDIRECT_SERVICE_HOST;

  icmph.orig_timestamp = htonl (StrToInt(Fprotocol->orig_t->Text));
  icmph.recv_timestamp = htonl (StrToInt(Fprotocol->recv_t->Text));
  icmph.trns_timestamp = htonl (StrToInt(Fprotocol->tx_t->Text));
  //отправляем ICMP пакет
  rs_send_icmp (s, iph, icmph, NULL, 0);
  }



 // Закрытие RAW сокета.
 rs_close_socket (s);
}

//---------------------------------------------------------------------------
void __fastcall TFmain::BitBtn1Click(TObject *Sender)
{
//инициализация WinSock2
rs_init(2,2);
//цикл генерации пакетов
int i;
Fmain->col_send_packet=0;
Fmain->send_error=false;
for (i=0;i<StrToInt(Fmain->col_packet->Text);i++)
  send_packet();
ShowMessage("Сгенерировано и отправлено "+IntToStr(Fmain->col_send_packet)+" пакетов");
}
//---------------------------------------------------------------------------



void __fastcall TFmain::BitBtn4Click(TObject *Sender)
{
if (Fmain->tip_proto->Text=="TCP")
  {
  //изменение размеров формы
  Fprotocol->Height=292;
  Fprotocol->Width=249;
  //положение кнопки
  Fprotocol->BitBtn1->Top=240;
  Fprotocol->BitBtn1->Left=72;

  Fprotocol->TCPHeader->Visible=true;
  Fprotocol->ShowModal();
  Fprotocol->TCPHeader->Visible=false;
  }
if (Fmain->tip_proto->Text=="UDP")
  {
  //изменение размеров формы
  Fprotocol->Height=172;
  Fprotocol->Width=249;
  //положение кнопки
  Fprotocol->BitBtn1->Top=120;
  Fprotocol->BitBtn1->Left=40;
  Fprotocol->UDPHeader->Visible=true;
  Fprotocol->ShowModal();
  Fprotocol->UDPHeader->Visible=false;
  }
if (Fmain->tip_proto->Text=="ICMP")
  {
    //изменение размеров формы
  Fprotocol->Height=205;
  Fprotocol->Width=249;
  //положение кнопки
  Fprotocol->BitBtn1->Top=149;
  Fprotocol->BitBtn1->Left=72;
  Fprotocol->ICMPHeader->Visible=true;
  Fprotocol->ShowModal();
  Fprotocol->ICMPHeader->Visible=false;
  }

}
//---------------------------------------------------------------------------

void __fastcall TFmain::tip_protoChange(TObject *Sender)
{
if (Fmain->tip_proto->Text=="TCP")
  {
  Fmain->BitBtn4->Caption="Заголовок TCP";
  Fmain->BitBtn4->Enabled=true;
  Fmain->BitBtn1->Enabled=false;
  }
if (Fmain->tip_proto->Text=="UDP")
  {
  Fmain->BitBtn4->Caption="Заголовок UDP";
  Fmain->BitBtn4->Enabled=true;
  Fmain->BitBtn1->Enabled=false;
  }
if (Fmain->tip_proto->Text=="ICMP")
  {
  Fmain->BitBtn4->Caption="Заголовок ICMP";
  Fmain->BitBtn4->Enabled=true;
  Fmain->BitBtn1->Enabled=false;
  }

if (Fmain->tip_proto->Text=="")
  {
  Fmain->BitBtn4->Enabled=false;
  Fmain->BitBtn1->Enabled=true;
  }

}
//---------------------------------------------------------------------------

void __fastcall TFmain::BitBtn5Click(TObject *Sender)
{
Fdata->crash_crc->Checked=false;
Fdata->data_size->Value=0;
Fdata->ShowModal();
if (Fdata->ModalResult==mrOk)
  {
   data_size=Fdata->data_size->Value;
   if (Fdata->crash_crc->Checked) crash_crc=true;
  }
}
//---------------------------------------------------------------------------

void __fastcall TFmain::BitBtn2Click(TObject *Sender)
{
Application->HelpCommand(1,1);
}
//---------------------------------------------------------------------------

