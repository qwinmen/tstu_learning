// stdafx.cpp : source file that includes just the standard includes
//	sniff.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"

//Функция проверки того, что запущен единственный процесс программы
BOOL AreWeAlone(LPSTR szName) {
    HANDLE hMutex = CreateMutex(0, TRUE, szName);

    if(GetLastError() == ERROR_ALREADY_EXISTS) {
        CloseHandle(hMutex);
        return FALSE;
    }

    return TRUE;
}

//Функция проверяет, является ли пользователь администратором;
//Возвращает TRUE, если пользователь - администратор.
BOOL IsCurrentUserAdmin() {
    WCHAR wcsUserName[UNLEN + 1];
    DWORD dwUserNameLen = UNLEN + 1;

    if (GetUserNameW(wcsUserName, &dwUserNameLen) > 0) {
        USER_INFO_1 *userInfo;

        if (NetUserGetInfo(NULL, wcsUserName, 1, (BYTE**)&userInfo) == NERR_Success) {
            BOOL bReturn = (userInfo->usri1_priv == USER_PRIV_ADMIN);

            NetApiBufferFree(userInfo);
            return bReturn;
        }
    }

    return FALSE;
}

//Функция обработки сообщений окна помощи
INT_PTR CALLBACK AboutDialogProc(HWND hwndDlg, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    switch (uMsg) {
    case WM_COMMAND:
        WORD loWord;
        
        loWord = LOWORD(wParam);
        if (loWord == IDOK || loWord == IDCANCEL) {
            SendMessage(hwndDlg, WM_CLOSE, 0, 0);
        }
        return TRUE;

    case WM_CLOSE:
        EndDialog(hwndDlg, 0);
        return TRUE;
    }
    return FALSE;
}
