using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TestForm
{
    public static class Clipboard
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        private static extern int OpenClipboard(
            IntPtr hWndNewOwner
        );

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        private static extern int CloseClipboard();

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        private static extern int EmptyClipboard();

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr GetClipboardData(
            uint uFormat
        );

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SetClipboardData(
            uint uFormat,
            IntPtr hMem
        );

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr GlobalLock(
            IntPtr hMem
        );

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern int GlobalUnlock(
            IntPtr hMem
        );

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr GlobalAlloc(
            uint uFlags,
            ulong dwBytes
        );

        [DllImport("msvcrt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern int wcscpy(char str1, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder str2);

        private const uint CF_UNICODETEXT = 13;
        private const uint GMEM_DDESHARE = 8192;

        public static void SetText(string strText)
        {
            if (OpenClipboard(IntPtr.Zero) != 0)
            {
                IntPtr hgBuffer;
                char chBuffer;
                EmptyClipboard();
                hgBuffer = GlobalAlloc(GMEM_DDESHARE, 2 * Convert.ToUInt64(strText.Length + 1)); // 2 = sizeof(wchar_t) -- C++; sizeof(char) -- C#
                chBuffer = (char)GlobalLock(hgBuffer);
                wcscpy(chBuffer, new StringBuilder(strText));
                GlobalUnlock(hgBuffer);
                SetClipboardData(CF_UNICODETEXT, hgBuffer);
                CloseClipboard();
            }
        }

        public static string GetText()
        {
            if (OpenClipboard(IntPtr.Zero) != 0)
            {
                IntPtr hData = GetClipboardData(CF_UNICODETEXT);
                char[] chBuffer = new char[] { (char)GlobalLock(hData) };
                string strResult = new string(chBuffer);
                GlobalUnlock(hData);
                CloseClipboard();
                return strResult;
            }
            return "";
        }
    }

}
