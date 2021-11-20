using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Дескриптор-Имя-Путь
            StringBuilder fileName = new StringBuilder(255);
            //get full path for run application
            ConnectDll.GetModuleFileName(IntPtr.Zero, fileName, fileName.Capacity);
            Console.WriteLine("Полный путь до экзешника: {0}",fileName);
            
            int bufsz = 1;// We'll grow this as necessary
            string sRel =
                @"ConsoleApplication1.pdb";// Note relative path
            StringBuilder sbFull = new StringBuilder(bufsz);          // Full path will go here
            StringBuilder sbFile  = new StringBuilder(bufsz);          // Filename will go here
            
            uint u = ConnectDll.GetFullPathName(sRel, (uint)bufsz, sbFull,out sbFile);  // 1st call: Get necessary bufsz
            if (u > bufsz)                            // 'u' should be >1
            {
                bufsz = (int)u + 10;                       // Required size plus a few
                sbFull = new StringBuilder(bufsz);                 // Re-create objects w/ proper size
                sbFile = new StringBuilder(bufsz);                 // "
                u = ConnectDll.GetFullPathName(sRel, (uint)bufsz, sbFull, out sbFile);    // Try again, this should succeed
                
                // 'sbFull' should now contain "c:\windows\system32\desktop.ini"
                //    and 'sbFile' should contain "desktop.ini"
            }
            Console.WriteLine("sbFile={0}, sbFull={1}",sbFile,sbFull);

            IntPtr ModKernel32 = ConnectDll.GetModuleHandle("User32.dll");
            Console.WriteLine("Дескриптор модуля User32.dll ={0}",ModKernel32);
            #endregion
            Console.ReadKey();
            #region Открыть-ЗакрытьТекущийПроцесс
            uint MyID = ConnectDll.GetCurrentProcessId();
            Console.WriteLine("ID текущего процесса = {0}",MyID);

            IntPtr hproc = ConnectDll.GetCurrentProcess();
            Console.WriteLine("ПсевдоДескрипт = {0}",hproc);

            IntPtr duplicat;
            bool state = ConnectDll.DuplicateHandle(hproc, hproc, hproc,out duplicat, 0, false,
                ConnectDll.DuplicateOptions.DUPLICATE_SAME_ACCESS);
            Console.WriteLine("Duplicate state = {0}", state);//Если функция завершается с ошибкой, величина возвращаемого значения - ноль

            IntPtr handlPtr = ConnectDll.OpenProcess(ConnectDll.ProcessAccessFlags.DupHandle, true, MyID);
            Console.WriteLine("OpenProc state = {0}", handlPtr);//Если функция завершается с ошибкой, величина возвращаемого значения ПУСТО (NULL).

            bool ste = ConnectDll.CloseHandle(duplicat);
            Console.WriteLine("StateCloseA = {0}", ste);//Если функция завершается с ошибкой, величина возвращаемого значения - нуль.

            bool steB = ConnectDll.CloseHandle(handlPtr);
            Console.WriteLine("StateCloseB = {0}", steB);//Если функция завершается успешно, величина возвращаемого значения - не нуль.
            #endregion
            Console.ReadKey();
            #region Процесс-Поток-Модуль
            Process pr = CurrentParentProcess;
            Console.WriteLine("Parent Proc. ID: {0}, Parent Proc. name: {1}", pr.Id, pr.ProcessName);

            IntPtr emptyThread = CurrentParentThread;

            emptyThread = CurrentParentModule;

            #endregion
            Console.ReadKey();
        }

        public static Process CurrentParentProcess
        {
            get
            {
                return GetParentProcess(Process.GetCurrentProcess().Id);
            }
        }

        public static Process GetParentProcess(int pid)
        {
            Process parentProc = null;
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ConnectDll.PROCESSENTRY32 procEntry = new ConnectDll.PROCESSENTRY32();
                procEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(ConnectDll.PROCESSENTRY32));
                handleToSnapshot = ConnectDll.CreateToolhelp32Snapshot(ConnectDll.SnapshotFlags.Process, 0);
                Console.WriteLine("СнимокПроцевСистемыКолич = {0}", handleToSnapshot);
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

        private static void ПоказатьСодержимоеСтруктуры(ConnectDll.PROCESSENTRY32 entry)
        {
            Console.WriteLine("\n\nth32ProcessID = {0}", entry.th32ProcessID);
            Console.WriteLine("\nth32DefaultHeapID = {0}", entry.th32DefaultHeapID);
            Console.WriteLine("\nth32ModuleID = {0}", entry.th32ModuleID);
            Console.WriteLine("\nth32ParentProcessID = {0}", entry.th32ParentProcessID);
            Console.WriteLine("\ncntUsage = {0}", entry.cntUsage);
            Console.WriteLine("\ncntThreads = {0}", entry.cntThreads);
            Console.WriteLine("\npcPriClassBase = {0}", entry.pcPriClassBase);
            Console.WriteLine("\ndwFlags = {0}", entry.dwFlags);
            Console.WriteLine("\nszExeFile = {0}", entry.szExeFile);
        }

        public static IntPtr CurrentParentThread
        {
            get
            {
                return GetParentThread(Process.GetCurrentProcess().Id);
            }
        }

        private static IntPtr GetParentThread(int tid)
        {
           IntPtr hThread = new IntPtr();
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                //threadEntry - описание очередного потока в текущем процессе
                ConnectDll.THREADENTRY32 threadEntry = new ConnectDll.THREADENTRY32();
                threadEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(ConnectDll.THREADENTRY32));
                handleToSnapshot = ConnectDll.CreateToolhelp32Snapshot(ConnectDll.SnapshotFlags.Thread, 0);
                Console.WriteLine("СнимокПотокаСистемыКолич = {0}", handleToSnapshot);
                if (ConnectDll.Thread32First(handleToSnapshot, ref threadEntry))
                {
                    do
                    {// относится ли данный поток к нужному процессу 
                        if (tid == threadEntry.th32OwnerProcessID)
                        {
                            // пытаемся получить описатель потока по его идентификатору 
                        hThread = ConnectDll.OpenThread(ConnectDll.ThreadAccess.SUSPEND_RESUME, false, threadEntry.th32ThreadID);
                        Console.WriteLine("Oписатель потока = " + hThread);
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

        private static void ПоказатьСодержимоеПотока(ConnectDll.THREADENTRY32 threadEntry)
        {
            Console.WriteLine("Размер структуры в байтах = {0}", threadEntry.dwSize);
            Console.WriteLine("Счетчик ссылок на поток = {0}", threadEntry.cntUsage);
            Console.WriteLine("Идентификатор потока = {0}", threadEntry.th32ThreadID);
            Console.WriteLine("Идентификатор процесса породившего поток = {0}", threadEntry.th32OwnerProcessID);
            Console.WriteLine("Начальный приоритет назначенный потоку = {0}", threadEntry.tpBasePri);
            Console.WriteLine("Изменение приритетного уровня потока = {0}", threadEntry.tpDeltaPri);
            Console.WriteLine("Зарезервированно = {0}", threadEntry.dwFlags);
        }

        public static IntPtr CurrentParentModule
        {
            get
            {
                return GetParentModule(Process.GetCurrentProcess().Id);
            }
        }

        public static IntPtr GetParentModule(int mid)
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
                Console.WriteLine("СнимокMoдулСистемыКолич = {0}", handleToSnapshot);
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

        private static void ПоказатьСодержимоеМодуля(ConnectDll.MODULEENTRY32 moduleEntry)
        {
            Console.WriteLine("размер структуры в байтах"+moduleEntry.dwSize);
            Console.WriteLine("ID модуля" + moduleEntry.th32ModuleID);
            Console.WriteLine("ID процесса модуля" + moduleEntry.th32ProcessID);
            Console.WriteLine("общее для системы количество обращений к модулю" + moduleEntry.GlblcntUsage);
            Console.WriteLine("количество обращений к модулю, сделанных из текущего процесса" + moduleEntry.ProccntUsage);
            Console.WriteLine("адрес модуля в адресном пространстве процесса" + moduleEntry.modBaseAddr);
            Console.WriteLine("размер модуля" + moduleEntry.modBaseSize);
            Console.WriteLine("дескриптор модуля в контексте процесса" + moduleEntry.hModule);
            Console.WriteLine("имя модуля" + moduleEntry.szModule);
            Console.WriteLine("полный путь к файлу" + moduleEntry.szExePath);
        }

        private static void DumpModuleInfo(int hProcess)
        {
            int pid = Process.GetProcessById(hProcess).Id;
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.Id == pid)
                {
                    foreach (ProcessModule pm in proc.Modules)
                    {
                        Console.WriteLine("MODULE:{0:X8} {1:X8} {2:X8} {3}", (int)pm.BaseAddress,
                        (int)pm.EntryPointAddress, (int)pm.BaseAddress + pm.ModuleMemorySize, pm.ModuleName);
                    }
                }
            }
        }

        static void EnumProcessModules(int procIDDDDDDDDDDDDD)
        {
            var snapshot = ConnectDll.CreateToolhelp32Snapshot(ConnectDll.SnapshotFlags.Module | ConnectDll.SnapshotFlags.Module32, (uint)procIDDDDDDDDDDDDD);
            ConnectDll.MODULEENTRY32 mod = new ConnectDll.MODULEENTRY32() { dwSize = (uint)Marshal.SizeOf(typeof(ConnectDll.MODULEENTRY32)) };
            if (!ConnectDll.Module32First(snapshot, ref mod))
                return;

            List<string> modules = new List<string>();
            do
            {
                modules.Add(mod.szModule);
            }
            while (ConnectDll.Module32Next(snapshot, ref mod));
            Console.WriteLine("OK");
        }




    }

}
