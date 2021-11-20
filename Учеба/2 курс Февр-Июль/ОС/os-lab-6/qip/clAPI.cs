using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace qip
{
    class clAPI
    {
        #region Server
        public static readonly IntPtr INVALID_HANDLE_VALUE = (IntPtr)(-1);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr CreateMailslot(//Создание канала
            string lpName,				// адрес имени канала Mailslot
            int nMaxMessageSize,		// максимальный размер сообщения
            int lReadTimeout,			// время ожидания для чтения
            IntPtr lpSecurityAttributes	// адрес структуры защиты
            );

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMailslotInfo(//Определение состояния канала Mailslot
            IntPtr hMailslot,			// идентификатор канала Mailslot
            out int lpMaxMessageSize,	// адрес максимального размера сообщения
            out int lpNextSize,			// адрес размера следующего сообщения
            out int lpMessageCount,		// адрес количества сообщений
            out int lpReadTimeout		// адрес времени ожидания
            );

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(
            IntPtr hObject
            );
        #endregion
        
    }

    internal class clClientAPI
    {
        #region Client

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr CreateFile(//Открытие канала Mailslot
           string fileName,//передается имя канала Mailslot
           uint fileAccess,//над открываемым каналом будет выполняться операция r/w/rw
           uint fileShare,
           IntPtr securityAttributes,
           uint creationDisposition,//открывает/создает существующий/новый канал
           uint flags,
           IntPtr template
           );

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteFile(//Запись сообщений в канал Mailslot
            IntPtr hFile,//идентификатор канала Mailslot
            byte[] lpBuffer,//определяет адрес буфера с сообщением
            int nNumberOfBytesToWrite,//размер сообщения
            out int lpNumberOfBytesWritten,
            IntPtr lpOverlapped
            );

        #endregion
    }
}
