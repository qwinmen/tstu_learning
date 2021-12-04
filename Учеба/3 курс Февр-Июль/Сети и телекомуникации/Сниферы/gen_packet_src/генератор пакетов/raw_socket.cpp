#pragma hdrstop
#include <vcl.h>
#include "raw_socket.h"
#include "main.h"
#include "data.h"
#include <ws2tcpip.h>
////////////////////////////////////////////////////////////////////////////////
int rs_exit (void)
{
 // �������� ���������� Winsock
 WSACleanup ();

 return 0;
}
//////////////////////////////////////////////////////////////////////////////
int rs_init (int v_major, int v_minor)
{
 WSADATA wsadata;

 // ������������� ���������� WinSock �������� �������
 if (WSAStartup(MAKEWORD(v_major, v_minor), &wsadata))
    {
     ShowMessage("������ ������������� WinSock");
     return 1;
    }

 // �������� ������ WinSock
 if (LOBYTE(wsadata.wVersion) != v_minor || HIBYTE(wsadata.wVersion) != v_major)
    {
     rs_exit ();

     ShowMessage ("�� ������ ������ WinSock");
     return 1;
    }

 return 0;
}

//////////////////////////////////////////////////////////////////////////
int rs_set_raw (SOCKET s)
{
 unsigned int use_own_header = 1;
 // ��������� ����� RAW ��� ������, ��� ������� � ���
 //��� �� ������� ����� ����������� �������� �������
 if ( setsockopt (s, IPPROTO_IP, 2, (char*)&use_own_header, sizeof(use_own_header))== SOCKET_ERROR)
    {
    ShowMessage ("������ ��������� ����� RAW ��� ������");
     return 1;
    }

 return 0;
}

////////////////////////////////////////////////////////////////////////////////

int rs_set_tos (SOCKET s, unsigned char new_tos)
{
 int tos = new_tos;
 int tos_len = sizeof (tos);
 int per=setsockopt(s, IPPROTO_IP, 3, (char *)&tos, tos_len);
 if (per == SOCKET_ERROR)
    {
     ShowMessage("������ ��������� ����� TOS");
     return 1;
    }

 return 0;
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

unsigned short rs_crc (unsigned short * buffer, int length)
{
 unsigned long crc = 0;

 // ���������� CRC.
 while (length > 1)
       {
        crc += *buffer++;
        length -= sizeof (unsigned short);
       }

 // ���� ������� ������ �����.
 if (length) crc += *(unsigned char*) buffer;

 //��������� ����������.
 crc = (crc >> 16) + (crc & 0xffff);
 crc += (crc >> 16);

 // �������� CRC ���� ����������.
 if (1) crc = crc << 1;

 // ���������� �������������� ��������.
 if (Fdata->crash_crc)
   return (unsigned short)(crc); //���� CRC ��������� �� �� ����������� ���
 else return (unsigned short)(~crc);
}

////////////////////////////////////////////////////////////////////////////////
unsigned short rs_pseudo_crc (char * data, int data_length, unsigned int src_addr, unsigned int dst_addr, int packet_length, unsigned char proto)
{
 char * buffer;
 unsigned int full_length;
 unsigned char header_length;
 struct pseudo_header ph;

 unsigned short p_crc = 0;

 // ������  ������ ������������.
 ph.src_addr = src_addr;
 ph.dst_addr = dst_addr;
 ph.zero = 0;
 ph.proto = proto;
 ph.length = htons (packet_length);

 header_length = sizeof (struct pseudo_header);
 full_length = header_length + data_length;

 // ��������� ������.
 buffer =(char *) calloc (full_length, sizeof (char));

 // ��������� ������������.
 memcpy (buffer, &ph, header_length);
 memcpy (buffer + header_length, data, data_length);

 // ���������� CRC.
 p_crc = rs_crc ((unsigned short*) buffer, full_length);

 free (buffer);
 return p_crc;
}

////////////////////////////////////////////////////////////////////////////////


int rs_send_ip (SOCKET s, struct ip_header iph, unsigned char * data, int data_length, unsigned short dst_port_raw)
{
 char * buffer;
 int result;
 sockaddr_in target;

 unsigned char header_length;
 unsigned int packet_length;

 memset (&target, 0, sizeof (target));

 target.sin_family = AF_INET;
 target.sin_addr.s_addr = iph.dst_addr;
 target.sin_port = dst_port_raw;

 // ���������� ����� ������ � ��������� ������.
 header_length = sizeof (struct ip_header); // !!! If IP_OPTIONS, increase...
 packet_length = header_length + data_length;

 // ��������� CRC.
 iph.crc = 0;

 // ���������� ��������� ����� ��������� IP.
 iph.version = header_length / 4 + (unsigned char) atoi ("4") * 16;

 // ���� ����� ������ �� ������ , ��
 //����� ������ ����� ����� ���������
 if (!iph.length) iph.length = htons (packet_length);

 // ��������� ������ ��� ����� �����
 buffer =(char *) calloc (packet_length, sizeof (char));

 // ����������� ��������� � ����� (CRC ����� 0).
 memcpy (buffer, &iph, sizeof (struct ip_header));


 // ����������� ������
 if (data) memcpy (buffer + header_length, data, data_length);

 // ���������� CRC.
 iph.crc = rs_crc ((unsigned short *) buffer, packet_length);

 // ����������� ��������� ������ (CRC ���������).
 memcpy (buffer, &iph, sizeof (struct ip_header));

 // ������� ������������ IP ������.
 result = sendto (s, buffer, packet_length, 0,(struct sockaddr *)&target, sizeof (target));
 if (result==SOCKET_ERROR)
 {
   int SockErr;
   result = GetLastError();
   switch (result)
   {
    case WSANOTINITIALISED : {SockErr=1;break;};//	A successful WSAStartup must occur before using this function.
    case WSAENETDOWN :{SockErr=2;break;};       //      The network subsystem has failed.
    case WSAEACCES : {SockErr=3;break;};        //    	The requested address is a broadcast address, but the appropriate flag was not set.
    case WSAEINVAL: {SockErr=4;break;};         //	An unknown flag was specified, or MSG_OOB was specified for a socket with SO_OOBINLINE enabled.
    case WSAEINTR :{SockErr=5;break;};          //	The (blocking) call was canceled through WSACancelBlockingCall.
    case WSAEINPROGRESS:{SockErr=6;break;};     //	A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.
    case WSAEFAULT: {SockErr=7;break;};         //	The buf or to parameters are not part of the user address space, or the tolen argument is too small.
    case WSAENETRESET :{SockErr=8;break;};      //	The connection has been broken due to the remote host resetting.
    case WSAENOBUFS :{SockErr=9;break;};        //	No buffer space is available.
    case WSAENOTCONN :{SockErr=10;break;};      //	The socket is not connected (connection-oriented sockets only)
    case WSAENOTSOCK: {SockErr=11;break;};      //	The descriptor is not a socket.
    case WSAEOPNOTSUPP:{SockErr=12;break;};     //	MSG_OOB was specified, but the socket is not stream style such as type SOCK_STREAM, out-of-band data is not supported in the communication domain associated with this socket, or the socket is unidirectional and supports only receive operations.
    case WSAESHUTDOWN :{SockErr=13;break;};     //	The socket has been shut down; it is not possible to sendto on a socket after shutdown has been invoked with how set to SD_SEND or SD_BOTH.
    case WSAEWOULDBLOCK	:{SockErr=14;break;};   //      The socket is marked as nonblocking and the requested operation would block.
    case WSAEMSGSIZE :{SockErr=15;break;};      //	The socket is message oriented, and the message is larger than the maximum supported by the underlying transport.
    case WSAEHOSTUNREACH :{SockErr=16;break;};  //	The remote host cannot be reached from this host at this time.
    case WSAECONNABORTED :{SockErr=17;break;};  //	The virtual circuit was terminated due to a time-out or other failure. The application should close the socket as it is no longer usable.
    case WSAECONNRESET :{SockErr=18;break;};    //	The virtual circuit was reset by the remote side executing a "hard" or "abortive" close. For UPD sockets, the remote host was unable to deliver a previously sent UDP datagram and responded with a "Port Unreachable" ICMP packet. The application should close the socket as it is no longer usable.
    case WSAEADDRNOTAVAIL: {SockErr=19;break;}; //	The specified address is not available from the local machine.
    case WSAEAFNOSUPPORT :{SockErr=20;break;};  //	Addresses in the specified family cannot be used with this socket.
    case WSAEDESTADDRREQ :{SockErr=21;break;};  //	A destination address is required.
    case WSAENETUNREACH	:{SockErr=22;break;};   //      The network cannot be reached from this host at this time.
    case WSAETIMEDOUT :{SockErr=23;break;};
   }
 if (!Fmain->send_error) ShowMessage("������ �������� ������: "+IntToStr(SockErr));
 Fmain->send_error=true;
 }
 else Fmain->col_send_packet++;
 free (buffer);
 return result;
}

////////////////////////////////////////////////////////////////////////////////

int rs_send_tcp (SOCKET s, struct ip_header iph, struct tcp_header tcph, unsigned char * data, int data_length)
{
 char * buffer;
 int result;

 unsigned char header_length;
 unsigned int packet_length;

 // ���������� ������� ������.
 header_length = sizeof (struct tcp_header);
 packet_length = header_length + data_length;

 // ��������� ���������� �������� CRC.
 tcph.crc = 0;

 // ��������� ���� offset.
 tcph.offset = (header_length / 4) << 4;

 // ��������� ������ ��� ����� �����
 buffer =(char *) calloc (packet_length, sizeof (char));

 // ����������� ��������� ������ (CRC ����� 0).
 memcpy (buffer, &tcph, sizeof (struct tcp_header));

 // ����������� ������ ��������� ����� �������� ������
 if (data) memcpy (buffer + header_length, data, data_length);

 // ���������� CRC.
 tcph.crc = rs_pseudo_crc (buffer, packet_length, iph.src_addr, iph.dst_addr, packet_length, IPPROTO_TCP);

 // ����������� ��������� � �����, ������ � ����������� CRC.
 memcpy (buffer, &tcph, sizeof (struct tcp_header));

 // ������� IP ������.
 result = rs_send_ip (s, iph, buffer, packet_length, tcph.dst_port);

 free (buffer);
 return result;
}
////////////////////////////////////////////////////////////////////////////////

int rs_send_udp (SOCKET s, struct ip_header iph, struct udp_header udph, unsigned char * data, int data_length)
{
 char * buffer;
 int result;

 unsigned char header_length;
 unsigned int packet_length;

 // ���������� ����� ������ � ���������.
 header_length = sizeof (struct udp_header);
 packet_length = header_length + data_length;

 // ��������� CRC.
 udph.crc = 0;

 // ���� ����� ������ �� ������ (��� ������)
 //�� ����� ������ ����� ����� ���������
 if (!udph.length) udph.length = htons (packet_length);

 // ��������� ������ ��� ����� �����
 buffer =(char *) calloc (packet_length, sizeof (char));

 // ����������� ��������� (CRC ����� 0).
 memcpy (buffer, &udph, sizeof (struct udp_header));

 // ����������� ������ � �����
 if (data) memcpy (buffer + header_length, data, data_length);

 // ���������� CRC.
 udph.crc = rs_pseudo_crc (buffer, packet_length, iph.src_addr, iph.dst_addr, packet_length, IPPROTO_UDP);

 // ����������� ��������� ������ (CRC ����������).
 memcpy (buffer, &udph, sizeof (struct udp_header));

 // �������� IP ������ �� ��������� UDP.
 result = rs_send_ip (s, iph, buffer, packet_length, udph.dst_port);

 free (buffer);
 return result;
}

////////////////////////////////////////////////////////////////////////////////
int rs_send_icmp (SOCKET s, struct ip_header iph, struct icmp_header icmph, unsigned char * data, int data_length)
{
 char * buffer;
 int result;

 unsigned char header_length;
 unsigned int packet_length;

 data_length = 0; // !!!

 // ���������� ����� ������ � ��������� ������.
 header_length = sizeof (struct icmp_header);
 packet_length = header_length + data_length;

 // ��������� ��������� CRC.
 icmph.crc = 0;

 // ��������� ������ ��� ����� �����,
 buffer = (char *)calloc (packet_length, sizeof (char));

 // ����������� ��������� � ����� (���� CRC ����� 0).
 memcpy (buffer, &icmph, sizeof (struct icmp_header));

 // ����������  CRC.
 icmph.crc = rs_crc ((unsigned short *) buffer, packet_length);

 // ����������� ��������� � ����� (CRC ���������).
 memcpy (buffer, &icmph, sizeof (struct icmp_header));

 // �������� IP ������ �� ��������� ICMP.
 result = rs_send_ip (s, iph, buffer, packet_length, 0);

 free (buffer);
 return result;
}

////////////////////////////////////////////////////////////////////////////////



