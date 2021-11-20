using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Eliza
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ДескрипторИмяПуть();
            ПроцессПотокМодуль();
        }

        private void ДескрипторИмяПуть()
        {
            #region Дескриптор-Имя-Путь
            StringBuilder fileName = new StringBuilder(255);
            //get full path for run application
            ConnectDll.GetModuleFileName(IntPtr.Zero, fileName, fileName.Capacity);
            AddToListViewer("Полный путь до экзешника", fileName.ToString());

            int bufsz = 1;// We'll grow this as necessary
            string sRel =
                @"Eliza.pdb";// Note relative path
            AddToListViewer("Восстановить путь до", sRel);
            StringBuilder sbFull = new StringBuilder(bufsz);          // Full path will go here
            StringBuilder sbFile = new StringBuilder(bufsz);          // Filename will go here

            uint u = ConnectDll.GetFullPathName(sRel, (uint)bufsz, sbFull, out sbFile);  // 1st call: Get necessary bufsz
            if (u > bufsz)                            // 'u' should be >1
            {
                bufsz = (int)u + 10;                       // Required size plus a few
                sbFull = new StringBuilder(bufsz);                 // Re-create objects w/ proper size
                sbFile = new StringBuilder(bufsz);                 // "
                u = ConnectDll.GetFullPathName(sRel, (uint)bufsz, sbFull, out sbFile);    // Try again, this should succeed

                // 'sbFull' should now contain "c:\windows\system32\desktop.ini"
                //    and 'sbFile' should contain "desktop.ini"
            }
            AddToListViewer("Имя файла восстановлено", sbFile.ToString());
            AddToListViewer("Полный путь до " + sbFile, sbFull.ToString());

            string module = "User32.dll";
            IntPtr ModKernel32 = ConnectDll.GetModuleHandle(module);
            AddToListViewer("Дескриптор модуля " + module, ModKernel32.ToString());

            #endregion
        }

        private void ОткрытьЗакрытьТекущийПроцесс()
        {
            #region Открыть-ЗакрытьТекущийПроцесс
            uint MyID = ConnectDll.GetCurrentProcessId();
            AddToListViewer("ID текущего процесса ", MyID.ToString());

            IntPtr hproc = ConnectDll.GetCurrentProcess();
            AddToListViewer("Текущий псевдо дескриптор ", hproc.ToString());

            IntPtr duplicat;
            bool state = ConnectDll.DuplicateHandle(hproc, hproc, hproc, out duplicat, 0, false,
                ConnectDll.DuplicateOptions.DUPLICATE_SAME_ACCESS);
            AddToListViewer(state + " Копия дескриптора " + hproc, duplicat.ToString());

            IntPtr handlPtr = ConnectDll.OpenProcess(ConnectDll.ProcessAccessFlags.DupHandle, true, MyID);
            AddToListViewer("Открытый дескриптор от " + MyID, handlPtr.ToString());

            bool ste = ConnectDll.CloseHandle(duplicat);
            AddToListViewer("Закрыт дескриптор " + duplicat, ste.ToString());

            bool steB = ConnectDll.CloseHandle(handlPtr);
            AddToListViewer("Закрыт дескриптор " + handlPtr, steB.ToString());

            #endregion
            
        }

        private void ПроцессПотокМодуль()
        {
            #region Процесс-Поток-Модуль
            Process pr = CurrentParentProcess;
            AddToListViewer("Родительский ID", pr.Id.ToString(), true);
            AddToListViewer("Родительский Name", pr.ProcessName, true);
            #endregion
        }

        private Process CurrentParentProcess
        {
            get
            {
                return GetParentProcess(Process.GetCurrentProcess().Id);
            }
        }

        private Process GetParentProcess(int pid)
        {
            Process parentProc = null;
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ConnectDll.PROCESSENTRY32 procEntry = new ConnectDll.PROCESSENTRY32();
                procEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(ConnectDll.PROCESSENTRY32));
                handleToSnapshot = ConnectDll.CreateToolhelp32Snapshot(ConnectDll.SnapshotFlags.Process, 0);
                AddToListViewer("Снимок Процессов Системы Колич.", handleToSnapshot.ToString(), true);
                if (ConnectDll.Process32First(handleToSnapshot, ref procEntry))
                {
                    do
                    {
                        if (pid == procEntry.th32ProcessID)
                        {
                            parentProc = Process.GetProcessById((int)procEntry.th32ParentProcessID);
                            break;
                        }
                        ПоказатьСодержимоеСтруктуры(procEntry);//проход по всем процессам снимка
                    } while (ConnectDll.Process32Next(handleToSnapshot, ref procEntry));
                }
                else
                {
                    throw new ApplicationException(string.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error()));
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Can't get the process.", ex);
            }
            finally
            {
                // Must clean up the snapshot object!
                ConnectDll.CloseHandle(handleToSnapshot);
            }
            return parentProc;
        }

        private void ПоказатьСодержимоеСтруктуры(ConnectDll.PROCESSENTRY32 entry)
        {
            AddToListViewer("Имя файла, создавшего процесс", entry.szExeFile, true, true);
            AddToListViewer("ID процесса", entry.th32ProcessID.ToString(), true);
            AddToListViewer("th32DefaultHeapID", entry.th32DefaultHeapID.ToString(), true);
            AddToListViewer("th32ModuleID", entry.th32ModuleID.ToString(), true);
            AddToListViewer("ID родительского по отношению к текущему процесса", entry.th32ParentProcessID.ToString(), true);
            AddToListViewer("Число ссылок на процесс", entry.cntUsage.ToString(), true);
            AddToListViewer("Число потоков, принадлежащих процессу", entry.cntThreads.ToString(), true);
            AddToListViewer("Базовый приоритет процесса", entry.pcPriClassBase.ToString(), true);
            AddToListViewer("dwFlags", entry.dwFlags.ToString(), true);
        }

        private IntPtr GetParentThread(int tid)
        {
            IntPtr hThread = new IntPtr();
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                //threadEntry - описание очередного потока в текущем процессе
                ConnectDll.THREADENTRY32 threadEntry = new ConnectDll.THREADENTRY32();
                threadEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(ConnectDll.THREADENTRY32));
                handleToSnapshot = ConnectDll.CreateToolhelp32Snapshot(ConnectDll.SnapshotFlags.Thread, 0);
                AddToListViewer("Снимок потоков системы Количество", handleToSnapshot.ToString(), true);
                if (ConnectDll.Thread32First(handleToSnapshot, ref threadEntry))
                {
                    do
                    {// относится ли данный поток к нужному процессу 
                        if (tid == threadEntry.th32OwnerProcessID)
                        {
                            // пытаемся получить описатель потока по его идентификатору 
                            hThread = ConnectDll.OpenThread(ConnectDll.ThreadAccess.SUSPEND_RESUME, false, threadEntry.th32ThreadID);
                            AddToListViewer("Oписатель потока идентификатора " + threadEntry.th32ThreadID, hThread.ToString(), true);
                        }
                        ПоказатьСодержимоеПотока(threadEntry);//проход по всем полям снимка
                    } while (ConnectDll.Thread32Next(handleToSnapshot, out threadEntry));
                }
                else
                {
                    throw new ApplicationException(string.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error()));
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Can't get the thread.", ex);
            }
            finally
            {
                // Must clean up the snapshot object!
                ConnectDll.CloseHandle(handleToSnapshot);
            }
            return hThread;
        }

        private void ПоказатьСодержимоеПотока(ConnectDll.THREADENTRY32 threadEntry)
        {
            AddToListViewer("Идентификатор потока", threadEntry.th32ThreadID.ToString(), true, true);
            AddToListViewer("Размер структуры в байтах", threadEntry.dwSize.ToString(),true);
            AddToListViewer("Счетчик ссылок на поток", threadEntry.cntUsage.ToString(), true);
            AddToListViewer("Идентификатор процесса породившего поток", threadEntry.th32OwnerProcessID.ToString(), true);
            AddToListViewer("Начальный приоритет назначенный потоку", threadEntry.tpBasePri.ToString(), true);
            AddToListViewer("Изменение приритетного уровня потока", threadEntry.tpDeltaPri.ToString(), true);
            AddToListViewer("Зарезервированно", threadEntry.dwFlags.ToString(), true);
        }

        private IntPtr GetParentModule(int mid)
        {
            IntPtr parentMod = IntPtr.Zero;
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ConnectDll.MODULEENTRY32 moduleEntry = new ConnectDll.MODULEENTRY32();
                moduleEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(ConnectDll.MODULEENTRY32));

                handleToSnapshot =
                    ConnectDll.CreateToolhelp32Snapshot(//http://pastebin.com/BzD1jdmH
                        ConnectDll.SnapshotFlags.Module | ConnectDll.SnapshotFlags.Module32, 0);
                AddToListViewer("Снимок мoдули системы Количество", handleToSnapshot.ToString(), true);
                if (ConnectDll.Module32First(handleToSnapshot, ref moduleEntry))
                {
                    do
                    {
                        if (mid == moduleEntry.th32ProcessID)
                        {
                            parentMod = (IntPtr)Process.GetProcessById((int)moduleEntry.th32ProcessID).Id;
                        }
                        ПоказатьСодержимоеМодуля(moduleEntry);//проход по всем процессам снимка
                    } while (ConnectDll.Module32Next(handleToSnapshot, ref moduleEntry));
                }
                else
                {
                    throw new ApplicationException(string.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error()));
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Can't get the process.", ex);
            }
            finally
            {
                // Must clean up the snapshot object!
                ConnectDll.CloseHandle(handleToSnapshot);
            }
            return parentMod;
        }

        private void ПоказатьСодержимоеМодуля(ConnectDll.MODULEENTRY32 moduleEntry)
        {
            AddToListViewer("Имя модуля", moduleEntry.szModule, true, true);
            AddToListViewer("Полный путь к файлу", moduleEntry.szExePath, true);
            AddToListViewer("Размер структуры в байтах", moduleEntry.dwSize.ToString(), true);
            AddToListViewer("ID модуля",moduleEntry.th32ModuleID.ToString(), true);
            AddToListViewer("ID процесса модуля",moduleEntry.th32ProcessID.ToString(), true);
            AddToListViewer("Oбщее для системы количество обращений к модулю", moduleEntry.GlblcntUsage.ToString(), true);
            AddToListViewer("Kоличество обращений к модулю, сделанных из текущего процесса",
                            moduleEntry.ProccntUsage.ToString(), true);
            AddToListViewer("Aдрес модуля в адресном пространстве процесса", moduleEntry.modBaseAddr.ToString(), true);
            AddToListViewer("Pазмер модуля", moduleEntry.modBaseSize.ToString(), true);
            AddToListViewer("Дескриптор модуля в контексте процесса", moduleEntry.hModule.ToString(), true);
        }

        private void AddToListViewer(string left, string right, params bool[] flag)
        {
            ListViewItem stroka1 = new ListViewItem(left);
            stroka1.SubItems.Add(right);
            if(flag.Length == 0)listView1.Items.Add(stroka1);
            else
            {
                if (flag.Length != 1) stroka1.BackColor = Color.Red;
                listView2.Items.Add(stroka1);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            columnHeader2.Width = groupBox1.Width - 220;
            columnHeader4.Width = groupBox2.Width - 268;
            if (Form1.ActiveForm != null) groupBox2.Height = Form1.ActiveForm.Height - groupBox1.Height - 95;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            int k = Convert.ToInt32((sender as RadioButton).TabIndex);
            switch (k)
            {
                case 1: //left cheked
                    if(radioButton1.Checked)
                    ДескрипторИмяПуть();
                    break;
                case 2: //right cheked
                    if(radioButton2.Checked)
                    ОткрытьЗакрытьТекущийПроцесс();
                    break;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            int k = Convert.ToInt32((sender as RadioButton).TabIndex);
            switch (k)
            {
                case 3: //left cheked
                    if (radioButton3.Checked)
                        ПроцессПотокМодуль();
                    break;
                case 4: //center cheked
                    if (radioButton4.Checked)
                        GetParentThread(Process.GetCurrentProcess().Id);
                    break;
                case 5: //right cheked
                    if (radioButton5.Checked)
                        GetParentModule(Process.GetCurrentProcess().Id);
                    break;
            }
        }


    }
}
