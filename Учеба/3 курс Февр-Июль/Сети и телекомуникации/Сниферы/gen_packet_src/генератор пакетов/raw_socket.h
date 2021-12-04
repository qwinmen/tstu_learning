//---------------------------------------------------------------------------

#ifndef raw_socketH
#define raw_socketH
//---------------------------------------------------------------------------
#include "WinSock2.h"
////////////////////////////////////////////////////////////////////////////////



/***************************************************************************

	This program is free software; you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation; either version 2 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
	General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program; see the file COPYING.  If not, write to
	the Free Software Foundation, Inc., 59 Temple Place - Suite 330,
	Boston, MA 02111-1307, USA.

***************************************************************************/ 



////////////////////////////////////////////////////////////////////////////////

# define RS_IP_VERSION			4

// IP fragmentation flags.
# define MAY_FRAG			0x0000
# define MORE_FRAG			0x2000
# define LAST_FRAG			0x5000
# define DONT_FRAG			0x4000

// IP type-of-service.
# define IP_TOS_0x00			0x00
# define IP_TOS_0x02			0x02
# define IP_TOS_0x04			0x04
# define IP_TOS_0x08			0x08
# define IP_TOS_0x10			0x10

// TCP flags.
# define TCP_FIN			1
# define TCP_SYN			2
# define TCP_RST			4
# define TCP_PSH			8
# define TCP_ACK			16
# define TCP_URG			32
# define TCP_ECE			64
# define TCP_CWR			128

// ICMP types.
# define ICMP_ECHO_REPLY		0
# define ICMP_UNREACHABLE		3
# define ICMP_QUENCH			4
# define ICMP_REDIRECT			5
# define ICMP_ECHO			8
# define ICMP_TIME			11
# define ICMP_PARAMETER			12
# define ICMP_TIMESTAMP			13
# define ICMP_TIMESTAMP_REPLY		14
# define ICMP_INFORMATION		15
# define ICMP_INFORMATION_REPLY		16

// ICMP codes for ICMP_UNREACHABLE
# define ICMP_UNREACHABLE_NET		0
# define ICMP_UNREACHABLE_HOST		1
# define ICMP_UNREACHABLE_PROTOCOL	2
# define ICMP_UNREACHABLE_PORT		3
# define ICMP_UNREACHABLE_FRAGMENTATION	4
# define ICMP_UNREACHABLE_SOURCE	5
# define ICMP_UNREACHABLE_SIZE		8

// ICMP codes for ICMP_TIME
# define ICMP_TIME_TRANSIT		0
# define ICMP_TIME_FRAGMENT		1

// ICMP codes for ICMP_REDIRECT
# define ICMP_REDIRECT_NETWORK		0
# define ICMP_REDIRECT_HOST		1
# define ICMP_REDIRECT_SERVICE_NETWORK	2
# define ICMP_REDIRECT_SERVICE_HOST	3

// IP packet header.
struct ip_header
{
 unsigned char		version;
 unsigned char		tos;
 unsigned short		length;
 unsigned short		id;
 unsigned short		flags;
 unsigned char		ttl;
 unsigned char		proto;
 unsigned short		crc;
 unsigned int		src_addr;
 unsigned int		dst_addr;
};

// TCP packet header.
struct tcp_header
{
 unsigned short		src_port;
 unsigned short		dst_port;
 unsigned int		seq_n;
 unsigned int		ack_n;
 unsigned char		offset;
 unsigned char		flags;
 unsigned short		win;
 unsigned short		crc;
 unsigned short		urg_ptr;
};

// UDP packet header.
struct udp_header
{
 unsigned short		src_port;
 unsigned short		dst_port;
 unsigned short		length;
 unsigned short		crc;
};

// ICMP packet header.
struct icmp_header
{
 unsigned char		type;
 unsigned char		code;
 unsigned short		crc;

 union {
	struct { unsigned char	uc1, uc2, uc3, uc4; } s_uc;
	struct { unsigned short	us1, us2; } s_us;
	unsigned long s_ul;
       } s_icmp;

 unsigned long		orig_timestamp;
 unsigned long		recv_timestamp;
 unsigned long		trns_timestamp;
};

// Additional pseudo header for calculating TCP & UDP checksum.
struct pseudo_header
{
 unsigned int		src_addr;
 unsigned int		dst_addr;
 unsigned char		zero;
 unsigned char		proto;	
 unsigned short		length;
};
//необходимые функции для работы с RAW сокетами
int rs_set_raw (SOCKET s);
int rs_set_tos (SOCKET s, unsigned char new_tos);
int rs_send_ip (SOCKET s, struct ip_header iph, unsigned char * data, int data_length, unsigned short dst_port_raw);
int rs_init (int v_major, int v_minor);
int rs_send_tcp (SOCKET s, struct ip_header iph, struct tcp_header tcph, unsigned char * data, int data_length);
int rs_send_udp (SOCKET s, struct ip_header iph, struct udp_header udph, unsigned char * data, int data_length);
int rs_send_icmp (SOCKET s, struct ip_header iph, struct icmp_header icmph, unsigned char * data, int data_length);

////////////////////////////////////////////////////////////////////////////////

# endif
////////////////////////////////////////////////////////////////////////////////





