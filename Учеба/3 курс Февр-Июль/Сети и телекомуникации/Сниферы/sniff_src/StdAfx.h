// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__A9DB83DB_A9FD_11D0_BFD1_444553540000__INCLUDED_)
#define AFX_STDAFX_H__A9DB83DB_A9FD_11D0_BFD1_444553540000__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <winsock2.h>
#include <mstcpip.h>
#include <lm.h>

#include "resource.h"

//Включаем ws2_32.lib для использования функций WinSock2
#pragma comment(lib, "ws2_32.lib")

//Включаем netapi32.lib для использования функций NetApi
#pragma comment(lib, "netapi32.lib")

//Структура заголовка IP-пакета
typedef struct IPHeader {
	UCHAR   iph_verlen;   // версия и длина заголовка
	UCHAR   iph_tos;      // тип сервиса
	USHORT  iph_length;   // длина всего пакета
	USHORT  iph_id;       // Идентификация
	USHORT  iph_offset;   // флаги и смещения
	UCHAR   iph_ttl;      // время жизни пакета
	UCHAR   iph_protocol; // протокол
	USHORT  iph_xsum;     // контрольная сумма
	ULONG   iph_src;      // IP-адрес отправителя
	ULONG   iph_dest;     // IP-адрес назначения
}IPHeader;

BOOL AreWeAlone(LPSTR szName);
BOOL IsCurrentUserAdmin();
INT_PTR CALLBACK AboutDialogProc(HWND hwndDlg, UINT uMsg, WPARAM wParam, LPARAM lParam);

#define WM_RECV (WM_USER + 1)

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__A9DB83DB_A9FD_11D0_BFD1_444553540000__INCLUDED_)
