using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace server
{
    class Program
    {
        #region ~ Win32 ~
        static readonly IntPtr INVALID_HANDLE_VALUE = (IntPtr)(-1);

        [DllImport( "kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode )]
        static extern IntPtr CreateMailslot (//Создание канала
            string lpName,				// адрес имени канала Mailslot
            int nMaxMessageSize,		// максимальный размер сообщения
            int lReadTimeout,			// время ожидания для чтения
            IntPtr lpSecurityAttributes	// адрес структуры защиты
            );

        [DllImport( "kernel32.dll", SetLastError = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        static extern bool GetMailslotInfo (//Определение состояния канала Mailslot
            IntPtr hMailslot,			// идентификатор канала Mailslot
            out int lpMaxMessageSize,	// адрес максимального размера сообщения
            out int lpNextSize,			// адрес размера следующего сообщения
            out int lpMessageCount,		// адрес количества сообщений
            out int lpReadTimeout		// адрес времени ожидания
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
            BinaryReader    br        = null;
            int[]           mailInfo  = new int[4];

            Console.WriteLine( "Enter mail:" );

            hMailslot = CreateMailslot(
                            @"\\.\mailslot\" + (mailName = Console.ReadLine()),
                            0, -1, IntPtr.Zero
                            );

            if ( hMailslot == INVALID_HANDLE_VALUE )
                throw new Win32Exception( Marshal.GetLastWin32Error() );

            hEvent = new EventWaitHandle(
                            false,
                            EventResetMode.ManualReset,
                            @"Global\Mailslot_" + mailName
                            );
            br = new BinaryReader(//вместо ReadFile
                        new FileStream( hMailslot, FileAccess.ReadWrite ),
                        Encoding.Default
                        );

            while ( true )
            {
                hEvent.WaitOne();

                do
                {
                    if ( !GetMailslotInfo(
                            hMailslot, out mailInfo[0], out mailInfo[1],
                            out mailInfo[2], out mailInfo[3] )
                        )
                    {
                        Console.WriteLine(
                            "WARNING!!! GetMailslotInfo error: {0}.",
                            Marshal.GetLastWin32Error()
                            );
                        Debugger.Break();
                        break;
                    }

                    // No messages
                    if ( mailInfo[1] == -1 )
                        break;

                    Console.WriteLine( "Message:" );
                    Console.WriteLine(
                        Encoding.Default.GetString(
                            br.ReadBytes( mailInfo[1] )
                            )
                        );
                } while ( mailInfo[2] != 0 );

                hEvent.Reset();
                Console.WriteLine( "Continue? Y/N" );

                if ( Console.ReadLine().Equals( "N", StringComparison.InvariantCultureIgnoreCase ) )
                    break;

                Console.Clear();
                Console.WriteLine( "mail: " + mailName );
            }

            br.Close();
            hEvent.Close();
        }
    }
}
