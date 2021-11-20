using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace Atom
{
    class clAPI
    {
        #region CreateFile
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern SafeFileHandle CreateFile(string fileName,//имя файла
            [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess,//доступ r\w
            [MarshalAs(UnmanagedType.U4)] FileShare fileShare,//общий доступ yes\no
            IntPtr securityAttributes,//атрибуты безопасности файла
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,//режим открыть\создать\перезаписать
            [MarshalAs(UnmanagedType.U4)] FileAttributes flags,//атрибут архив\скрытый\дляЧтения
            IntPtr template);//!= 0 копирует атрибуты с указаного шаблона файла
        #endregion

        #region GetFileSize
        [DllImport("Kernel32.dll")]
        public static extern uint GetFileSize(int hFile, int lpFileSizeHigh);
        #endregion

        #region CreateFileMapping

        public enum FileMapProtection : uint
        {
            PageReadonly = 0x02,
            PageReadWrite = 0x04,
            PageWriteCopy = 0x08,
            PageExecuteRead = 0x20,
            PageExecuteReadWrite = 0x40,
            SectionCommit = 0x8000000,
            SectionImage = 0x1000000,
            SectionNoCache = 0x10000000,
            SectionReserve = 0x4000000,
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern SafeFileHandle CreateFileMapping(
            IntPtr hFile,//Дескриптор файла, из которого создается "проецируемый" объект
            IntPtr lpFileMappingAttributes,//атрибут безопасности
            FileMapProtection flProtect,//эт отображение доступно для r\w\rw\copy\
            int dwMaximumSizeHigh,//размер для файлового отображения
            int dwMaximumSizeLow,//размер для файлового отображения
            [MarshalAs(UnmanagedType.LPStr)] string lpName);//имя обьекта файлового отображения

        internal static SafeFileHandle CreateFileMapping(/*FileStream*/IntPtr File, FileMapProtection flProtect, Int64 ddMaxSize, string lpName)
        {
            int Hi = (Int32) (ddMaxSize/Int32.MaxValue);
            int Lo = (Int32) (ddMaxSize%Int32.MaxValue);
            return CreateFileMapping( File/*File.SafeFileHandle.DangerousGetHandle()*/, IntPtr.Zero, flProtect, Hi, Lo, lpName);
        }

        #endregion

        #region MapViewOfFile вернет указатель на отображенный файл, переданый в первом параметре

        public enum FileMapAccess : uint
        {
            FileMapCopy = 0x0001,
            FileMapWrite = 0x0002,
            FileMapRead = 0x0004,
            FileMapAllAccess = 0x001f,
            fileMapExecute = 0x0020,
        }
          [DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        unsafe public static extern IntPtr/*LPVOID*/ MapViewOfFile(IntPtr hFileMapping, FileMapAccess dwDesiredAccess,
                                                   Int32 dwFileOffsetHigh, Int32 dwFileOffsetLow,
                                                   Int32 dwNumberOfBytesToMap);
        #endregion

          #region CopyMemory
          /*CopyMemory копирует блок памяти из одного места в другой с использованием указателей.
           * Очень удобная функция для копирования массивов.*/
        [DllImport("Kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr Куда, IntPtr Откуда, uint count);
        //Указатель на адрес памяти для использования
        //Указатель на адрес памяти из которого будут копироваться данные
        //Число копируемых байтов
          #endregion


        [DllImport("Kernel32.dll")]
        unsafe public static extern void CopyMemory(void* Куда, void* Откуда, int length);
        unsafe public static Char[] CloneCharArrayMemcpy(Char[] a)
        {
            Char[] ret = new Char[a.Length];

            fixed (Char* src = a, dest = ret)
            {
                CopyMemory(dest, src, a.Length*sizeof (Char));
            }
            return (ret);
        }











        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool ReadFile(IntPtr hFile, char[] lpBuffer,
                                            uint nNumberOfBytesToRead, ref int N, int N1);

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool WriteFile(IntPtr hFile, char[] lpBuffer,
                                             uint nNumberOfBytesToWrite, ref int N, int N1);
        
        [DllImport("Kernel32.dll", CharSet=CharSet.Auto)]
        static extern bool CloseHandle(IntPtr hObject);

    }
}
