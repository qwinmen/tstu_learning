using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Eliza
{
    class ConnectDll
    {
        #region Дескриптор-Имя-Путь
        /// <summary>
        /// get full path for run application
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        [PreserveSig]//SysProperty_defoult = true
        public static extern uint GetModuleFileName([In]IntPtr hModule, [Out]StringBuilder lpFilename,
                                                     [In][MarshalAs(UnmanagedType.U4)]int nSize);

        /// <summary>
        /// GetFullPathName не ищёт файл на диске, а только составляет полное имя.по короткому
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern uint GetFullPathName(string lpFileName, uint nBufferLength,
           [Out] StringBuilder lpBuffer, out StringBuilder lpFilePart);

        /// <summary>
        /// Vозвращаемое значение - дескриптор указанного модуля.(или .dll или .exe файл)
        /// </summary>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion

        #region Открыть-ЗакрытьТекущийПроцесс
        /// <summary>
        /// Функция GetCurrentProcessId извлекает идентификатор вызывающего процесса.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentProcessId();

        /// <summary>
        /// Функция GetCurrentProcess извлекает псевдодескриптор для текущего процесса.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetCurrentProcess();

        /// <summary>
        /// Функция DuplicateHandle делает копию дескриптора объекта.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DuplicateHandle(IntPtr hSourceProcessHandle,
            IntPtr hSourceHandle, IntPtr hTargetProcessHandle, out IntPtr lpTargetHandle,
            uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, DuplicateOptions dwOptions);
        [Flags]
        public enum DuplicateOptions : uint
        {
            DUPLICATE_CLOSE_SOURCE = (0x00000001),// Закрывает исходный дескриптор.
            DUPLICATE_SAME_ACCESS = (0x00000002), //Игнорирует параметр dwDesiredAccess.
        }

        /// <summary>
        ///  величина возвращаемого значения - открытый дескриптор заданного процесса.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess,
            [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }

        /// <summary>
        /// Функция CloseHandle закрывает дескриптор открытого объекта.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);
        #endregion

        #region Процесс-Поток-Модуль
        /// <summary>
        /// создает снимок-структуру указанного процесса
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateToolhelp32Snapshot(SnapshotFlags dwFlags, uint th32ProcessID);
        [Flags]
        public enum SnapshotFlags : uint
        {
            HeapList = 0x00000001,
            Process = 0x00000002,/*TH32CS_SNAPPROCESS*/
            Thread = 0x00000004,
            Module = 0x00000008,
            Module32 = 0x00000010,
            All = (HeapList | Process | Thread | Module),
            Inherit = 0x80000000,
            NoHeaps = 0x40000000
        }

        /// <summary>
        /// Первый в снимке
        /// </summary>
        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool Process32First([In]IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        /// <summary>
        /// Последующий в снимке
        /// </summary>
        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool Process32Next([In]IntPtr hSnapshot, ref PROCESSENTRY32 lppe);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct PROCESSENTRY32
        {
            const int MAX_PATH = 260;
            internal UInt32 dwSize;//размер структуры в байтах
            internal UInt32 cntUsage;//число ссылок на процесс
            internal UInt32 th32ProcessID;//является идентификатором процесса
            internal IntPtr th32DefaultHeapID;// 
            internal UInt32 th32ModuleID;// .
            internal UInt32 cntThreads;//число потоков, принадлежащих процессу.
            internal UInt32 th32ParentProcessID;//идентификатор родительского по отношению к текущему процесса
            internal Int32 pcPriClassBase;//cодержит базовый приоритет процесса.
            internal UInt32 dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            internal string szExeFile;//cодержит имя файла, создавшего процесс
        }

        [DllImport("kernel32.dll")]
        public static extern bool Thread32First(IntPtr hSnapshot, ref THREADENTRY32 lpte);

        [DllImport("kernel32.dll")]
        public static extern bool Thread32Next(IntPtr hSnapshot, out THREADENTRY32 lpte);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct THREADENTRY32
        {
            internal UInt32 dwSize;//Размер структуры в байтах
            internal UInt32 cntUsage;//Счетчик ссылок на поток
            internal UInt32 th32ThreadID;//Идентификатор потока
            internal UInt32 th32OwnerProcessID;//Идентификатор процесса породившего поток
            internal UInt32 tpBasePri;//Начальный приоритет назначенный потоку
            internal UInt32 tpDeltaPri;//Изменение приритетного уровня потока
            internal UInt32 dwFlags;//Зарезервированно
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle,
            uint dwThreadId);
        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }

        [DllImport("kernel32.dll")]
        public static extern bool Module32First([In]IntPtr hSnapshot, ref MODULEENTRY32 lpme);

        [DllImport("kernel32.dll")]
        public static extern bool Module32Next([In]IntPtr hSnapshot, ref MODULEENTRY32 lpme);
        public struct MODULEENTRY32
        {//http://pastebin.com/BzD1jdmH
            private const int MAX_PATH = 255;
           internal uint dwSize;    //размер структуры в байтах
           internal uint th32ModuleID;//ID модуля
           internal uint th32ProcessID;//ID процесса модуля
           internal uint GlblcntUsage;//общее для системы количество обращений к модулю
           internal uint ProccntUsage;//количество обращений к модулю, сделанных из текущего процесса
           internal IntPtr modBaseAddr;//адрес модуля в адресном пространстве процесса
           internal uint modBaseSize;//размер модуля
           internal IntPtr hModule;//дескриптор модуля в контексте процесса
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
           internal string szModule;//имя модуля
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH+5)]
           internal string szExePath;//полный путь к файлу
        }

        #endregion
    }
}
