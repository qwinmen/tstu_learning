using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace Atom
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            StartProc();
            //Main();
        }

        private void StartProc()
        {
            unsafe
            {
                #region 1)	Создать текстовый файл и получить дескриптор

                FileStream fs;
                SafeFileHandle handle = clAPI.CreateFile("newFileATOM.txt", FileAccess.Write, 0,
                                       IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);
                if (handle.IsInvalid)
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                else fs = new FileStream(handle,FileAccess.ReadWrite);
                int val = (int)handle.DangerousGetHandle();
                txtBoxAdd("[Дескриптор newFileATOM.txt *int]  ", val.ToString());
                
                #endregion
                
                #region 2)	Создасть объект File на базе созданного в предыдущем пункте файла, используя АРI-функцию CreateFile. Вывести значение дескриптора объекта File.
                uint size = clAPI.GetFileSize(val, 0);
                txtBoxAdd("[Размер newFileATOM.txt *byte]  ", size.ToString());
                #endregion

                #region 3)	Используя дескриптор объекта File-mapping, а также API-функцию MapViewOfFile отобразить части файла в память. Данная функция назначает область виртуальной памяти, выделяемой этому файлу. Базовый адрес выделенной области памяти является дескриптором представления этой области в виде отображения файла.

                fs = File.Open("nnewFileATOM.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                SafeFileHandle myFileMapping = clAPI.CreateFileMapping(fs.SafeFileHandle.DangerousGetHandle(),
                                                                       clAPI.FileMapProtection.PageReadWrite,
                                                                       (int) size, "FileMapping.bin");
                if (myFileMapping.IsInvalid) Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                txtBoxAdd("[Дескриптор FileMapping.bin *int] ", myFileMapping.DangerousGetHandle().ToString());

                IntPtr myFileMapView = clAPI.MapViewOfFile(myFileMapping.DangerousGetHandle(),
                                                            clAPI.FileMapAccess.FileMapWrite, 0, 0, 0);
                if (myFileMapView.ToInt32() == 0) Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                
                txtBoxAdd("[Указатель на отображенный FileMapping.bin *int] ", myFileMapView.ToString());

                #endregion

                #region 4)	Используя базовый адрес и функцию CopyMemory прочитайте ин-формацию из отображаемого файла. Согласно варианту измените текстовый файл и запишите информацию в этот же файл
                txtBoxAdd("[ViewOfFile] ", "изменить регистр содержимого");

               // IntPtr myFileMemory = Marshal.AllocHGlobal((int)size);//char* myFileMemory = new char[myFileSize];
                //char[] buffer = new char[100];
                //Marshal.Copy(myFileMemory, buffer, 0, buffer.Length);
                //txtBoxAdd(buffer[0].ToString(), "-Ok");
                //clAPI.CopyMemory(myFileMemory.ToPointer(), myFileMapView.ToPointer(), (int)size);
                
                //копировать IntPtr в char[]
                char[] managedArray2 = new char[size];
                Marshal.Copy(myFileMapView, managedArray2, 0, (int)size);

                fixed (char* p = &managedArray2[0])
                {
                   clAPI.CopyMemory((IntPtr)p, myFileMapView, size);
                    for (int i = 0; i < size - 1; i++)
                    {
                        char c = p[i];
                        if (Char.IsUpper(c))
                            p[i] = Char.ToLower(c);
                        else if (Char.IsLower(c))
                            p[i] = Char.ToUpper(c);
                        txtBoxAdd("**",p[i].ToString());
                    }
                    //clAPI.CopyMemory(myFileMapView, (IntPtr)p, size);
                }

                //clAPI.CopyMemory(myFileMapView.DangerousGetHandle(), myFileMemory, size);

                txtBoxAdd("[Done] ", "Ok");

                #endregion
            }

            /*{
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName =
                    @"C:\Documents and Settings\Admin\Рабочий стол\ОС\Atom\Atom\bin\Debug\CModule\main.exe";
                proc.EnableRaisingEvents = true;
                proc.Exited += new EventHandler(proc_Exited);
                proc.Start();
                

                var text =
                    File.ReadAllText(
                        @"C:\Documents and Settings\Admin\Рабочий стол\ОС\Atom\Atom\bin\Debug\CModule\CModuleTXT.txt");
                txtBoxForWrite.Text = text;


            }*/
        }

        private void proc_Exited(object Sender, EventArgs e)
        {//сообщает о отработке внешнего модуля на Си
           //txtBoxForWrite.Text += ("[Load Module] Complite") + Environment.NewLine;
        }

        void Main()
        {
            unsafe
            {
                #region 1)	Создать текстовый файл 
/*
                SafeFileHandle handle = clAPI.CreateFile("newFileATOM.txt", FileAccess.Write, 0,
                                                         IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);
                if (handle.IsInvalid)
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                else new FileStream(handle, FileAccess.Read);
                txtBoxAdd("[File handle]  ", handle.ToString());
                #endregion

                #region 2)	Создасть объект File на базе созданного в предыдущем пункте файла, используя АРI-функцию CreateFile. Вывести значение дескриптора объекта File.
                uint size = clAPI.GetFileSize(handle, 0);
                txtBoxAdd("[File size *byte]  ", size.ToString());
                #endregion

                #region 3)	Используя дескриптор объекта File-mapping, а также API-функцию MapViewOfFile отобразить части файла в память. Данная функция назначает область виртуальной памяти, выделяемой этому файлу. Базовый адрес выделенной области памяти является дескриптором представления этой области в виде отображения файла.

                IntPtr myFileMapping = clAPI.CreateFileMapping(handle, IntPtr.Zero,
                                                               clAPI.FileMapProtection.PageReadWrite,
                                                               0, 0, "myFileMapping.txt");
                if (myFileMapping == IntPtr.Zero) Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                txtBoxAdd("[FileMapping Handle] ", myFileMapping.ToString());
*/
               // IntPtr myFileMapView = clAPI.MapViewOfFile(myFileMapping, clAPI.FileMapAccess.FileMapWrite, 0, 0, 0);
               // txtBoxAdd("[ViewOfFile Pointer] ", myFileMapView.ToString());
                
                #endregion

                #region 4)	Используя базовый адрес и функцию CopyMemory прочитайте ин-формацию из отображаемого файла. Согласно варианту измените текстовый файл и запишите информацию в этот же файл
                txtBoxAdd("[ViewOfFile] ", "изменить регистр содержимого");

               // IntPtr myFileMemory = Marshal.AllocHGlobal((int)size);//char* myFileMemory = new char[myFileSize];
                //clAPI.CopyMemory(myFileMemory, myFileMapView, size);
                string str = "pzrk";
                byte[] btr = Encoding.Default.GetBytes(str);

                IntPtr f = IntPtr.Zero;
                
                const int sizeF = 200;
                IntPtr memorySource = Marshal.AllocHGlobal(sizeF);
                

              //  CopyMemory(myFileMemory, memorySource, size);
                
               // CopyMemory(memorySource, myFileMemory, size);
                
                //txtBoxAdd("cm = ", cm._AllocationGranularity);
             //   txtBoxAdd("-> ",myFileMemory.ToString());
                
                txtBoxAdd("[Done] ", "Ok");

                #endregion

            }
        }

        void txtBoxAdd(string punkt, string message)
        {//Вывод в txtBox
            txtBoxForWrite.Text += (punkt + message) + Environment.NewLine;
        }
        
        [DllImport("Kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr КудаКопировать, IntPtr ОткудаКопировать, uint count);

        
    }
}
