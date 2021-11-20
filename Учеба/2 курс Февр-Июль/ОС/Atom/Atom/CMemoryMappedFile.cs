using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Atom
{
    public class CMemoryMappedFile : IDisposable
    {
        IntPtr _hMMF = IntPtr.Zero;
        FileStream _fs;
        public uint _AllocationGranularity;
        BinaryFormatter _Formatter = new BinaryFormatter();

        public CMemoryMappedFile(string FileName, string Name)
        {
            _hMMF = Win32API.OpenFileMapping(Win32API.FileMapAccess.FileMapAllAccess, false, Name);
            if (_hMMF == IntPtr.Zero)
            {
                _fs = File.Open(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                _hMMF = Win32API.CreateFileMapping(_fs, Win32API.FileMapProtection.PageReadWrite, Int64.MaxValue, Name);
                if (_hMMF == IntPtr.Zero)
                    throw new Win32Exception();
            }

            Win32API.SYSTEM_INFO sysinfo = new Win32API.SYSTEM_INFO();
            Win32API.GetSystemInfo(ref sysinfo);
            _AllocationGranularity = sysinfo.dwAllocationGranularity;
        }

        public long Length
        {
            get
            {
                if (_fs == null) return -1;
                return _fs.Length;
            }
        }

        unsafe public void Write(Object o, Int64 AtOffset)
        {
            IntPtr hMVF = IntPtr.Zero;
            try
            {
                Int64 FileMapStart = (AtOffset / _AllocationGranularity) * _AllocationGranularity;
                Int64 MapViewSize = (AtOffset % _AllocationGranularity) + _AllocationGranularity;
                Int64 iViewDelta = AtOffset - FileMapStart;

                hMVF = Win32API.MapViewOfFile(_hMMF, Win32API.FileMapAccess.FileMapWrite, FileMapStart, (Int32)MapViewSize);
                if (hMVF == IntPtr.Zero)
                    throw new Win32Exception();
                byte* p = (byte*)hMVF.ToPointer() + iViewDelta;
                UnmanagedMemoryStream ums = new UnmanagedMemoryStream(p, MapViewSize, MapViewSize, FileAccess.Write);
                _Formatter.Serialize(ums, o);
                Win32API.FlushViewOfFile(hMVF, (Int32)MapViewSize);
            }
            finally
            {
                if (hMVF != IntPtr.Zero)
                    Win32API.UnmapViewOfFile(hMVF);
            }
        }

        unsafe public object Read(Int64 AtOffset)
        {
            IntPtr hMVF = IntPtr.Zero;
            try
            {
                Int64 FileMapStart = (AtOffset / _AllocationGranularity) * _AllocationGranularity;
                Int64 MapViewSize = (AtOffset % _AllocationGranularity) + _AllocationGranularity;
                Int64 iViewDelta = AtOffset - FileMapStart;
                hMVF = Win32API.MapViewOfFile(_hMMF, Win32API.FileMapAccess.FileMapRead, FileMapStart, (Int32)MapViewSize);
                if (hMVF == IntPtr.Zero)
                    throw new Win32Exception();
                byte* p = (byte*)hMVF.ToPointer() + iViewDelta;
                UnmanagedMemoryStream ums = new UnmanagedMemoryStream(p, MapViewSize, MapViewSize, FileAccess.Read);
                object o = _Formatter.Deserialize(ums);
                return o;
            }
            finally
            {
                if (hMVF != IntPtr.Zero)
                    Win32API.UnmapViewOfFile(hMVF);
            }
        }


        unsafe public void Write(byte[] Buffer, int BytesToWrite, Int64 AtOffset)
        {
            IntPtr hMVF = IntPtr.Zero;
            try
            {
                Int64 FileMapStart = (AtOffset / _AllocationGranularity) * _AllocationGranularity;
                Int64 MapViewSize = (AtOffset % _AllocationGranularity) + _AllocationGranularity;
                Int64 iViewDelta = AtOffset - FileMapStart;

                hMVF = Win32API.MapViewOfFile(_hMMF, Win32API.FileMapAccess.FileMapWrite, FileMapStart, (Int32)MapViewSize);
                if (hMVF == IntPtr.Zero)
                    throw new Win32Exception();
                byte* p = (byte*)hMVF.ToPointer() + iViewDelta;
                UnmanagedMemoryStream ums = new UnmanagedMemoryStream(p, MapViewSize, MapViewSize, FileAccess.Write);
                ums.Write(Buffer, 0, BytesToWrite);
                Win32API.FlushViewOfFile(hMVF, (Int32)MapViewSize);
            }
            finally
            {
                if (hMVF != IntPtr.Zero)
                    Win32API.UnmapViewOfFile(hMVF);
            }
        }
        unsafe public int Read(byte[] Buffer, int BytesToRead, Int64 AtOffset)
        {
            IntPtr hMVF = IntPtr.Zero;
            try
            {
                Int64 FileMapStart = (AtOffset / _AllocationGranularity) * _AllocationGranularity;
                Int64 MapViewSize = (AtOffset % _AllocationGranularity) + _AllocationGranularity;
                Int64 iViewDelta = AtOffset - FileMapStart;

                hMVF = Win32API.MapViewOfFile(_hMMF, Win32API.FileMapAccess.FileMapRead, FileMapStart, (Int32)MapViewSize);
                if (hMVF == IntPtr.Zero)
                    throw new Win32Exception();
                byte* p = (byte*)hMVF.ToPointer() + iViewDelta;
                UnmanagedMemoryStream ums = new UnmanagedMemoryStream(p, MapViewSize, MapViewSize, FileAccess.Read);
                byte[] ba = new byte[BytesToRead];
                return ums.Read(Buffer, 0, BytesToRead);
            }
            finally
            {
                if (hMVF != IntPtr.Zero)
                    Win32API.UnmapViewOfFile(hMVF);
            }
        }
        public long Size(Object T)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, T);
            return ms.Length;
        }

        public void Dispose()
        {
            if (_hMMF != IntPtr.Zero)
                Win32API.CloseHandle(_hMMF);
            _hMMF = IntPtr.Zero;
            if (_fs != null)
                _fs.Close();
        }
    }

    internal sealed class Win32API
    {
        [DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CreateFileMapping(IntPtr hFile, IntPtr lpAttributes, FileMapProtection flProtect, Int32 dwMaxSizeHi, Int32 dwMaxSizeLow, string lpName);
        internal static IntPtr CreateFileMapping(System.IO.FileStream File, FileMapProtection flProtect, Int64 ddMaxSize, string lpName)
        {
            int Hi = (Int32)(ddMaxSize / Int32.MaxValue);
            int Lo = (Int32)(ddMaxSize % Int32.MaxValue);
            return CreateFileMapping(File.SafeFileHandle.DangerousGetHandle(), IntPtr.Zero, flProtect, Hi, Lo, lpName);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr OpenFileMapping(FileMapAccess DesiredAccess, bool bInheritHandle, string lpName);

        [Flags]
        internal enum FileMapProtection : uint
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

        [DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr MapViewOfFile(IntPtr hFileMapping, FileMapAccess dwDesiredAccess, Int32 dwFileOffsetHigh, Int32 dwFileOffsetLow, Int32 dwNumberOfBytesToMap);
        internal static IntPtr MapViewOfFile(IntPtr hFileMapping, FileMapAccess dwDesiredAccess, Int64 ddFileOffset, Int32 dwNumberOfBytesToMap)
        {
            int Hi = (Int32)(ddFileOffset / Int32.MaxValue);
            int Lo = (Int32)(ddFileOffset % Int32.MaxValue);
            return MapViewOfFile(hFileMapping, dwDesiredAccess, Hi, Lo, dwNumberOfBytesToMap);
        }

        [Flags]
        internal enum FileMapAccess : uint
        {
            FileMapCopy = 0x0001,
            FileMapWrite = 0x0002,
            FileMapRead = 0x0004,
            FileMapAllAccess = 0x001f,
            fileMapExecute = 0x0020,
        }

        [DllImport("kernel32.dll")]
        internal static extern bool FlushViewOfFile(IntPtr lpBaseAddress,
           Int32 dwNumberOfBytesToFlush);

        [DllImport("kernel32")]
        internal static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr hFile);

        [DllImport("kernel32.dll")]
        internal static extern void GetSystemInfo([MarshalAs(UnmanagedType.Struct)] ref SYSTEM_INFO lpSystemInfo);

        [StructLayout(LayoutKind.Sequential)]
        internal struct SYSTEM_INFO
        {
            internal _PROCESSOR_INFO_UNION uProcessorInfo;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public IntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort dwProcessorLevel;
            public ushort dwProcessorRevision;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct _PROCESSOR_INFO_UNION
        {
            [FieldOffset(0)]
            internal uint dwOemId;
            [FieldOffset(0)]
            internal ushort wProcessorArchitecture;
            [FieldOffset(2)]
            internal ushort wReserved;
        }
    }





}
