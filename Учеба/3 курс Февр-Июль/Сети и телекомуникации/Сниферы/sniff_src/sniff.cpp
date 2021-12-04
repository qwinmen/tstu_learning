// sniff.cpp : Defines the entry point for the application.
//

#include "stdafx.h"

//Функция обработки сообщений диалогового окна
INT_PTR CALLBACK DialogProc(HWND hwndDlg, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    static HANDLE hLogFile;
    static SOCKET s;

    static HWND hStartButton;
    static HWND hStopButton;

    static HWND hIDC_CHECK_PROTO_IPWnd;
    static HWND hIDC_CHECK_PROTO_ICMPWnd;
    static HWND hIDC_CHECK_PROTO_IGMPWnd;
    static HWND hIDC_CHECK_PROTO_GGPWnd;
    static HWND hIDC_CHECK_PROTO_TCPWnd;
    static HWND hIDC_CHECK_PROTO_PUPWnd;
    static HWND hIDC_CHECK_PROTO_UDPWnd;
    static HWND hIDC_CHECK_PROTO_IDPWnd;
    static HWND hIDC_CHECK_PROTO_IPv6Wnd;
    static HWND hIDC_CHECK_PROTO_NDWnd;
    static HWND hIDC_CHECK_PROTO_ICLFXBMWnd;
    static HWND hIDC_CHECK_PROTO_ICMPv6Wnd;
    static HWND hIDC_CHECK_PROTO_ALLWnd;

    static HWND hIDC_CHECK_OPTION_LOG_TARGET_IPWnd;
    static HWND hIDC_CHECK_OPTION_LOG_SENDER_IPWnd;
    static HWND hIDC_CHECK_OPTION_WRITE_PROTO_NAMEWnd;
    static HWND hIDC_CHECK_OPTION_WRITE_PACKET_LENWnd;

    static HWND hIDC_EDIT_LOG_FILENAMEWnd;

    switch (uMsg) {
    case WM_INITDIALOG:
        
        CheckDlgButton(hwndDlg, IDC_CHECK_PROTO_ALL, BST_CHECKED);
        CheckDlgButton(hwndDlg, IDC_CHECK_OPTION_LOG_TARGET_IP, BST_CHECKED);
        CheckDlgButton(hwndDlg, IDC_CHECK_OPTION_LOG_SENDER_IP, BST_CHECKED);
        CheckDlgButton(hwndDlg, IDC_CHECK_OPTION_WRITE_PROTO_NAME, BST_CHECKED);
        CheckDlgButton(hwndDlg, IDC_CHECK_OPTION_WRITE_PACKET_LEN, BST_CHECKED);

        SendDlgItemMessage(hwndDlg, IDC_EDIT_LOG_FILENAME, EM_LIMITTEXT, _MAX_FNAME - 1, 0);
        SetDlgItemText(hwndDlg, IDC_EDIT_LOG_FILENAME, "sniff.log");

        hStartButton = GetDlgItem(hwndDlg, IDC_BUTTON_START);
        hStopButton = GetDlgItem(hwndDlg, IDC_BUTTON_STOP);
        hIDC_CHECK_PROTO_IPWnd = GetDlgItem(hwndDlg, IDC_CHECK_PROTO_IP);
        hIDC_CHECK_PROTO_ICMPWnd = GetDlgItem(hwndDlg, IDC_CHECK_PROTO_ICMP);
        hIDC_CHECK_PROTO_IGMPWnd = GetDlgItem(hwndDlg, IDC_CHECK_PROTO_IGMP);
        hIDC_CHECK_PROTO_GGPWnd = GetDlgItem(hwndDlg, IDC_CHECK_PROTO_GGP);
        hIDC_CHECK_PROTO_TCPWnd = GetDlgItem(hwndDlg, IDC_CHECK_PROTO_TCP);
        hIDC_CHECK_PROTO_PUPWnd = GetDlgItem(hwndDlg, IDC_CHECK_PROTO_PUP);
        hIDC_CHECK_PROTO_UDPWnd = GetDlgItem(hwndDlg, IDC_CHECK_PROTO_UDP);
        hIDC_CHECK_PROTO_IDPWnd = GetDlgItem(hwndDlg, IDC_CHECK_PROTO_IDP);
        hIDC_CHECK_PROTO_IPv6Wnd = GetDlgItem(hwndDlg, IDC_CHECK_PROTO_IPv6);
        hIDC_CHECK_PROTO_NDWnd = GetDlgItem(hwndDlg, IDC_CHECK_PROTO_ND);
        hIDC_CHECK_PROTO_ICLFXBMWnd = GetDlgItem(hwndDlg, IDC_CHECK_PROTO_ICLFXBM);
        hIDC_CHECK_PROTO_ICMPv6Wnd = GetDlgItem(hwndDlg, IDC_CHECK_PROTO_ICMPv6);
        hIDC_CHECK_PROTO_ALLWnd = GetDlgItem(hwndDlg, IDC_CHECK_PROTO_ALL);

        hIDC_CHECK_OPTION_LOG_TARGET_IPWnd = GetDlgItem(hwndDlg, IDC_CHECK_OPTION_LOG_TARGET_IP);
        hIDC_CHECK_OPTION_LOG_SENDER_IPWnd = GetDlgItem(hwndDlg, IDC_CHECK_OPTION_LOG_SENDER_IP);
        hIDC_CHECK_OPTION_WRITE_PROTO_NAMEWnd = GetDlgItem(hwndDlg, IDC_CHECK_OPTION_WRITE_PROTO_NAME);
        hIDC_CHECK_OPTION_WRITE_PACKET_LENWnd = GetDlgItem(hwndDlg, IDC_CHECK_OPTION_WRITE_PACKET_LEN);

        hIDC_EDIT_LOG_FILENAMEWnd = GetDlgItem(hwndDlg, IDC_EDIT_LOG_FILENAME);

        WSADATA wsadata;

        //Инициализация сокетов
        if (WSAStartup(MAKEWORD(2, 2), &wsadata) != 0) {
            SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Ошибка. Не удается инициализировать сокеты.");
        } else {
            SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Сокеты инициализированы.");
        }

        //Создание сокета
	    s = socket(AF_INET, SOCK_RAW, IPPROTO_IP);
        if (s == INVALID_SOCKET) {
            SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Ошибка. Не удается создать сокет.");
        } else {
            SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Сокет создан.");

            CHAR szHostName[16];

            //Получение имени локального хоста
            if (gethostname(szHostName, sizeof szHostName) != 0) {
                SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Ошибка. Не удается определить имя хоста.");
            } else {
                SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Имя хоста получено.");

                //Получение информаций о локальном хосте
                HOSTENT *phe = gethostbyname(szHostName);

                if (phe == NULL) {
                    SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Ошибка. Не удается получить описание хоста.");
                } else {
                    SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Описание хоста получено.");

                    SOCKADDR_IN sa; //Адрес хоста

	                ZeroMemory(&sa,sizeof sa);
	                sa.sin_family = AF_INET;
	                sa.sin_addr.s_addr = ((struct in_addr*)phe->h_addr_list[0])->s_addr;

                    //Связывание локального адреса и сокета
                    if (bind(s, (SOCKADDR*)&sa, sizeof SOCKADDR) != 0) {
                        SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Ошибка. Не удается осуществить привязку сокета.");;
                    } else {
                        SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Сокет привязан.");

                        //Включение promiscuous mode
                        DWORD flag = TRUE;     //Флаг PROMISC Вкл/Выкл

                        //if (ioctlsocket(s, SIO_RCVALL, &flag) == SOCKET_ERROR) {
                          //  SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Ошибка. Не удается включить режим promiscuous.");
                        //} else {
                            SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Режим promiscuous включен.");

                            //Разблокирование кнопки "Старт"
                            EnableWindow(hStartButton, TRUE);
                        //}
                    }
                }
            }
        }
        return TRUE;

    case WM_COMMAND:
        switch (HIWORD(wParam)) {
        case EN_UPDATE:
            if (LOWORD(wParam) == IDC_EDIT_LOG_FILENAME) {
                CHAR szFileName[_MAX_FNAME];
                DWORD dwFileSize = 0;

                GetDlgItemText(hwndDlg, IDC_EDIT_LOG_FILENAME, szFileName, _MAX_FNAME);

                HANDLE hFile = CreateFile(szFileName, GENERIC_READ, FILE_SHARE_READ|FILE_SHARE_WRITE, NULL, OPEN_EXISTING, 0, 0);
                if (hFile != INVALID_HANDLE_VALUE) {
                    dwFileSize = GetFileSize(hFile, NULL);
                    CloseHandle(hFile);
                }
                SetDlgItemInt(hwndDlg, IDC_EDIT_LOG_SIZE, dwFileSize, FALSE);
            }
            break;
        }

        switch (LOWORD(wParam)) {
        case IDC_CHECK_PROTO_ALL: {
                BOOL bChecked = IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_ALL);

                EnableWindow(hIDC_CHECK_PROTO_IPWnd, !bChecked);
                EnableWindow(hIDC_CHECK_PROTO_ICMPWnd, !bChecked);
                EnableWindow(hIDC_CHECK_PROTO_IGMPWnd, !bChecked);
                EnableWindow(hIDC_CHECK_PROTO_GGPWnd, !bChecked);
                EnableWindow(hIDC_CHECK_PROTO_TCPWnd, !bChecked);
                EnableWindow(hIDC_CHECK_PROTO_PUPWnd, !bChecked);
                EnableWindow(hIDC_CHECK_PROTO_UDPWnd, !bChecked);
                EnableWindow(hIDC_CHECK_PROTO_IDPWnd, !bChecked);
                EnableWindow(hIDC_CHECK_PROTO_IPv6Wnd, !bChecked);
                EnableWindow(hIDC_CHECK_PROTO_NDWnd, !bChecked);
                EnableWindow(hIDC_CHECK_PROTO_ICLFXBMWnd, !bChecked);
                EnableWindow(hIDC_CHECK_PROTO_ICMPv6Wnd, !bChecked);
            }
            break;

        case IDC_BUTTON_START:
            //Создаем файл лога
            CHAR szFileName[_MAX_FNAME];

            GetDlgItemText(hwndDlg, IDC_EDIT_LOG_FILENAME, szFileName, _MAX_FNAME);

            hLogFile = CreateFile(szFileName, GENERIC_WRITE, FILE_SHARE_READ|FILE_SHARE_WRITE, NULL, OPEN_ALWAYS, 0, 0);
            if (hLogFile == INVALID_HANDLE_VALUE) {
                SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Ошибка. Не удается создать лог-файл.");
            } else {
                SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Лог-файл создан (открыт).");

                SetFilePointer(hLogFile, 0, NULL, FILE_END);

                EnableWindow(hStartButton, FALSE);
                EnableWindow(hStopButton, TRUE);

                EnableWindow(hIDC_CHECK_PROTO_IPWnd, FALSE);
                EnableWindow(hIDC_CHECK_PROTO_ICMPWnd, FALSE);
                EnableWindow(hIDC_CHECK_PROTO_IGMPWnd, FALSE);
                EnableWindow(hIDC_CHECK_PROTO_GGPWnd, FALSE);
                EnableWindow(hIDC_CHECK_PROTO_TCPWnd, FALSE);
                EnableWindow(hIDC_CHECK_PROTO_PUPWnd, FALSE);
                EnableWindow(hIDC_CHECK_PROTO_UDPWnd, FALSE);
                EnableWindow(hIDC_CHECK_PROTO_IDPWnd, FALSE);
                EnableWindow(hIDC_CHECK_PROTO_IPv6Wnd, FALSE);
                EnableWindow(hIDC_CHECK_PROTO_NDWnd, FALSE);
                EnableWindow(hIDC_CHECK_PROTO_ICLFXBMWnd, FALSE);
                EnableWindow(hIDC_CHECK_PROTO_ICMPv6Wnd, FALSE);
                EnableWindow(hIDC_CHECK_PROTO_ALLWnd, FALSE);

                EnableWindow(hIDC_CHECK_OPTION_LOG_TARGET_IPWnd, FALSE);
                EnableWindow(hIDC_CHECK_OPTION_LOG_SENDER_IPWnd, FALSE);
                EnableWindow(hIDC_CHECK_OPTION_WRITE_PROTO_NAMEWnd, FALSE);
                EnableWindow(hIDC_CHECK_OPTION_WRITE_PACKET_LENWnd, FALSE);

                EnableWindow(hIDC_EDIT_LOG_FILENAMEWnd, FALSE);

                //Связываем событие FD_READ с окном
                WSAAsyncSelect(s, hwndDlg, WM_RECV, FD_READ);

                SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Прием пакетов.");
            }
            break;

        case IDC_BUTTON_STOP:
            DWORD flag;
            BOOL bChecked;

            CloseHandle(hLogFile);

            EnableWindow(hIDC_EDIT_LOG_FILENAMEWnd, TRUE);

            EnableWindow(hIDC_CHECK_OPTION_LOG_TARGET_IPWnd, TRUE);
            EnableWindow(hIDC_CHECK_OPTION_LOG_SENDER_IPWnd, TRUE);
            EnableWindow(hIDC_CHECK_OPTION_WRITE_PROTO_NAMEWnd, TRUE);
            EnableWindow(hIDC_CHECK_OPTION_WRITE_PACKET_LENWnd, TRUE);

            EnableWindow(hStopButton, FALSE);

            EnableWindow(hIDC_CHECK_PROTO_ALLWnd, TRUE);

            bChecked = IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_ALL);

            EnableWindow(hIDC_CHECK_PROTO_IPWnd, !bChecked);
            EnableWindow(hIDC_CHECK_PROTO_ICMPWnd, !bChecked);
            EnableWindow(hIDC_CHECK_PROTO_IGMPWnd, !bChecked);
            EnableWindow(hIDC_CHECK_PROTO_GGPWnd, !bChecked);
            EnableWindow(hIDC_CHECK_PROTO_TCPWnd, !bChecked);
            EnableWindow(hIDC_CHECK_PROTO_PUPWnd, !bChecked);
            EnableWindow(hIDC_CHECK_PROTO_UDPWnd, !bChecked);
            EnableWindow(hIDC_CHECK_PROTO_IDPWnd, !bChecked);
            EnableWindow(hIDC_CHECK_PROTO_IPv6Wnd, !bChecked);
            EnableWindow(hIDC_CHECK_PROTO_NDWnd, !bChecked);
            EnableWindow(hIDC_CHECK_PROTO_ICLFXBMWnd, !bChecked);
            EnableWindow(hIDC_CHECK_PROTO_ICMPv6Wnd, !bChecked);

            //Включение promiscuous mode
            flag = TRUE;     //Флаг PROMISC Вкл/Выкл

            //if (ioctlsocket(s, SIO_RCVALL, &flag) == SOCKET_ERROR) {
              //  SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Ошибка. Не удается включить режим promiscuous.");
            //} else {
                SetDlgItemText(hwndDlg, IDC_EDIT_STATUS, "Режим promiscuous включен.");

                EnableWindow(hStartButton, TRUE);
            //}

            break;

        case IDC_BUTTON_ABOUT:
            DialogBox(GetModuleHandle(NULL), MAKEINTRESOURCE(IDD_DIALOG_ABOUT), hwndDlg, AboutDialogProc);
            break;

        case IDC_BUTTON_CLOSE:
            SendMessage(hwndDlg, WM_CLOSE, 0, 0);
            break;
        }
        return TRUE;

    case WM_RECV:
        if (WSAGETSELECTERROR(lParam)) {
        } else {
            if (WSAGETSELECTEVENT(lParam) == FD_READ) {
                //Буфер размера 64 Кб
                CHAR btBuffer[65536];

                    //Получаем входящие данные
                    if (recv(s, btBuffer, sizeof(btBuffer), 0) >= sizeof(IPHeader)) {
                        IPHeader* hdr = (IPHeader*)btBuffer;

                        //Вычисляем размер. Т.к. в сети принят прямой порядок байт,
                        //а не обратный, то придется поменять байты местами.
	                    WORD size = (hdr->iph_length << 8) + (hdr->iph_length >> 8);

                        //Получен пакет?
                        if (size >= 60 && size <= 1500) {
                            //Проверяем протокол
                            if (IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_ALL) != TRUE) {
                                if (IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_IP) == TRUE && hdr->iph_protocol == IPPROTO_IP) {
                                } else if (hdr->iph_protocol == IPPROTO_ICMP && IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_ICMP) == TRUE) {
                                } else if (hdr->iph_protocol == IPPROTO_IGMP && IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_IGMP) == TRUE) {
                                } else if (hdr->iph_protocol == IPPROTO_GGP && IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_GGP) == TRUE) {
                                } else if (hdr->iph_protocol == IPPROTO_TCP && IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_TCP) == TRUE) {
                                } else if (hdr->iph_protocol == IPPROTO_PUP && IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_PUP) == TRUE) {
                                } else if (hdr->iph_protocol == IPPROTO_UDP && IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_UDP) == TRUE) {
                                } else if (hdr->iph_protocol == IPPROTO_IDP && IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_IDP) == TRUE) {
                                } else if (hdr->iph_protocol == IPPROTO_IPV6 && IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_IPv6) == TRUE) {
                                } else if (hdr->iph_protocol == IPPROTO_ND && IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_ND) == TRUE) {
                                } else if (hdr->iph_protocol == IPPROTO_ICLFXBM && IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_ICLFXBM) == TRUE) {
                                } else if (hdr->iph_protocol == IPPROTO_ICMPV6 && IsDlgButtonChecked(hwndDlg, IDC_CHECK_PROTO_ICMPv6) == TRUE) {
                                } else {
                                    return TRUE;
                                }
                            }

                            DWORD dwWritten;

                            //Записываем данные
                            WriteFile(hLogFile, "--Packet begin--\r\n", 18, &dwWritten, 0);

                            if (IsDlgButtonChecked(hwndDlg, IDC_CHECK_OPTION_LOG_TARGET_IP) == TRUE) {
                                IN_ADDR ia;

                                ia.s_addr = hdr->iph_dest;
		                        CHAR *pszTargetIP = inet_ntoa(ia);

		                        WriteFile(hLogFile, "To: ", 4, &dwWritten, 0);
		                        WriteFile(hLogFile, pszTargetIP, lstrlen(pszTargetIP), &dwWritten, 0);
		                        WriteFile(hLogFile, "\r\n", 2, &dwWritten, 0);
                            }

                            if (IsDlgButtonChecked(hwndDlg, IDC_CHECK_OPTION_LOG_SENDER_IP) == TRUE) {
                                IN_ADDR ia;

                                ia.s_addr = hdr->iph_src;
		                        CHAR *pszSourceIP = inet_ntoa(ia);

		                        WriteFile(hLogFile, "From: ", 6, &dwWritten, 0);
		                        WriteFile(hLogFile, pszSourceIP, lstrlen(pszSourceIP), &dwWritten, 0);
		                        WriteFile(hLogFile, "\r\n", 2, &dwWritten, 0);
                            }

                            if (IsDlgButtonChecked(hwndDlg, IDC_CHECK_OPTION_WRITE_PROTO_NAME) == TRUE) {
		                        WriteFile(hLogFile, "Protocol: ", 10, &dwWritten, 0);

                                switch (hdr->iph_protocol) {
                                case IPPROTO_IP:
			                        WriteFile(hLogFile, "IP\r\n", 4, &dwWritten, 0);
			                        break;

                                case IPPROTO_ICMP:
			                        WriteFile(hLogFile, "ICMP\r\n", 6, &dwWritten, 0);
			                        break;

                                case IPPROTO_IGMP:
                                    WriteFile(hLogFile, "IGMP\r\n", 6, &dwWritten, 0);
                                    break;

                                case IPPROTO_GGP:
                                    WriteFile(hLogFile, "GGP\r\n", 5, &dwWritten, 0);
                                    break;

                                case IPPROTO_TCP:
                                    WriteFile(hLogFile, "TCP\r\n", 5, &dwWritten, 0);
                                    break;

                                case IPPROTO_PUP:
                                    WriteFile(hLogFile, "PUP\r\n", 5, &dwWritten, 0);
                                    break;

                                case IPPROTO_UDP:
                                    WriteFile(hLogFile, "UDP\r\n", 5, &dwWritten, 0);
                                    break;

                                case IPPROTO_IDP:
                                    WriteFile(hLogFile, "IDP\r\n", 5, &dwWritten, 0);
                                    break;

                                case IPPROTO_IPV6:
                                    WriteFile(hLogFile, "IPv6\r\n", 6, &dwWritten, 0);
                                    break;

                                case IPPROTO_ND:
                                    WriteFile(hLogFile, "ND\r\n", 4, &dwWritten, 0);
                                    break;

                                case IPPROTO_ICLFXBM:
                                    WriteFile(hLogFile, "ICLFXBM\r\n", 9, &dwWritten, 0);
                                    break;

                                case IPPROTO_ICMPV6:
                                    WriteFile(hLogFile, "ICMPv6\r\n", 8, &dwWritten, 0);
                                    break;
                                }
                            }

                            if (IsDlgButtonChecked(hwndDlg, IDC_CHECK_OPTION_WRITE_PACKET_LEN) == TRUE) {
                                CHAR szTemp[17];

		                        WriteFile(hLogFile, "Packet length: ", 15, &dwWritten, 0);
                                wsprintf(szTemp, "%d\r\n", size);
                                WriteFile(hLogFile, szTemp, lstrlen(szTemp), &dwWritten, 0);
                            }

                            WriteFile(hLogFile, "Contents:\r\n\r\n", 13, &dwWritten, 0);
                            WriteFile(hLogFile, &btBuffer[sizeof(IPHeader) * 2], size - sizeof(IPHeader) * 2, &dwWritten, 0);
	                        WriteFile(hLogFile, "\r\n--Packet end--\r\n", 18, &dwWritten, 0);

                            SetDlgItemInt(hwndDlg, IDC_EDIT_LOG_SIZE, GetFileSize(hLogFile, NULL), FALSE);
                        }
                    }
            }
        }
        return TRUE;

    case WM_CLOSE:
        //Конец работы с сокетами
        closesocket(s);
        WSACleanup();

        //Конец работы с логом
        CloseHandle(hLogFile);

        //Закрытие окна
        EndDialog(hwndDlg, 0);
        return TRUE;
    }
    return FALSE;
}

int APIENTRY WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow) {
    //Проверяем версию системы
    if (LOBYTE(LOWORD(GetVersion())) < 5) {
        MessageBox(0, "Данный сниффер работает только в системе Windows 2000 и младше.", "sniff", MB_ICONEXCLAMATION);
        return 0;
    }

    //Проверяем, что запущен единственный процесс сниффера
    if (AreWeAlone("-=sniff=-") == FALSE) {
        MessageBox(0, "Сниффер уже запущен.", "sniff", MB_ICONEXCLAMATION);
        return 0;
    }

    //Устанавливаем текущую директорию
    CHAR szCurDir[MAX_PATH];

    GetModuleFileName(NULL, szCurDir, MAX_PATH);
    *strrchr(szCurDir, '\\') = 0;
    SetCurrentDirectory(szCurDir);

    if (IsCurrentUserAdmin() == FALSE) {
        MessageBox(0, "У Вас нет прав администратора. Вы не сможете включить promiscuous mode.", "sniff", MB_ICONEXCLAMATION);
    }

    //Создаем главное окно программы
    if (DialogBox(hInstance, MAKEINTRESOURCE(IDD_DIALOG), NULL, DialogProc) != 0) {
        MessageBox(0, "Не удается создать главное окно сниффера.", "sniff", MB_ICONERROR);
        return 0;
    }
	return 0;
}
