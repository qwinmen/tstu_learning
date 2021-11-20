using System;
using System.Runtime.InteropServices;

namespace ConsMemTest
{
    class clMemTest
    {
        #region GlobalMemoryStatus
        public struct MEMORYSTATUS
        {
            public UInt32 dwLength;// Размер структуры
            public UInt32 dwMemoryLoad;// Процент использования памяти
            public UInt32 dwTotalPhys;// Физическая память, байт
            public UInt32 dwAvailPhys;// Свободная физическая память, байт
            public UInt32 dwTotalPageFile;// Размер файла подкачки, байт
            public UInt32 dwAvailPageFile;// Свободных байт в файле подкачки
            public UInt32 dwTotalVirtual;// Виртуальная память, используемая процессом
            public UInt32 dwAvailVirtual;// Свободная виртуальная память
        }
        /*предоставляет информацию об использовании физической и виртуальной памяти компьютера*/
        [DllImport("Kernel32.dll")]
        public static extern void GlobalMemoryStatus(ref MEMORYSTATUS lpBuffer);
        #endregion


        [DllImport("Core.dll")] //тут непашет
        public static extern int GetSystemMemoryDivision(ref UInt32 lpdwStorePages, ref UInt32 lpdwRamPages,
                                                         ref UInt32 lpdwPageSize);
    }
}
