using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace client
{
    class Program
    {
        #region ~ Win32 ~
        static readonly IntPtr INVALID_HANDLE_VALUE = (IntPtr)(-1);

        [DllImport( "kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode )]
        public static extern IntPtr CreateFile (//Открытие канала Mailslot
           string fileName,//передается имя канала Mailslot
           uint fileAccess,//над открываемым каналом будет выполняться операция r/w/rw
           uint fileShare,
           IntPtr securityAttributes,
           uint creationDisposition,//открывает/создает существующий/новый канал
           uint flags,
           IntPtr template
           );

        [DllImport( "kernel32.dll", SetLastError = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        static extern bool WriteFile (//Запись сообщений в канал Mailslot
            IntPtr hFile,//идентификатор канала Mailslot
            byte[] lpBuffer,//определяет адрес буфера с сообщением
            int nNumberOfBytesToWrite,//размер сообщения
            out int lpNumberOfBytesWritten,
            IntPtr lpOverlapped
            );

        [DllImport( "kernel32.dll", SetLastError = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        static extern bool CloseHandle (
            IntPtr hObject
            );
        #endregion

        static void Main ( string[] args )
        {
            string          mailName  = null;
            EventWaitHandle hEvent    = null;
            IntPtr          hMailslot = IntPtr.Zero;
            int             temp      = 0;

            Console.WriteLine( "Enter mail:" );

            hMailslot = CreateFile(
                            @"\\.\mailslot\" + (mailName = Console.ReadLine()),
                            0x40000000U /* GENERIC_WRITE */,
                            0x1U /* FILE_SHARE_READ */,
                            IntPtr.Zero,
                            0x3U /* OPEN_EXISTING */,
                            0x80U /* FILE_ATTRIBUTE_NORMAL */,
                            IntPtr.Zero
                            );

            if ( hMailslot == INVALID_HANDLE_VALUE )
                throw new Win32Exception( Marshal.GetLastWin32Error() );

            hEvent = EventWaitHandle.OpenExisting( @"Global\Mailslot_" + mailName );

            while ( true )
            {
                byte[] msg = null;

                Console.WriteLine( "Write a message:" );

                msg = Encoding.Default.GetBytes( Console.ReadLine() );

                if ( !WriteFile( hMailslot, msg, msg.Length, out temp, IntPtr.Zero ) )
                    Console.WriteLine(
                        "WARNING!!! WriteFile error: {0}.",
                        Marshal.GetLastWin32Error()
                        );
                else
                    hEvent.Set();

                Console.WriteLine( "Continue? Y/N" );

                if ( Console.ReadLine().Equals( "N", StringComparison.InvariantCultureIgnoreCase ) )
                    break;
            }

            CloseHandle( hMailslot );
            hEvent.Close();
        }
    }
}
