using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OS5
{
    class TickTok
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct CRITICAL_SECTION { public int dummy; }

        // INIT CRITICAL SECTION
        [DllImport("kernel32.dll")]
        public static extern bool InitializeCriticalSectionAndSpinCount(ref CRITICAL_SECTION lpCriticalSection, uint dwSpinCount);

        // DELETE CRITICAL SECTION
        [DllImport("kernel32.dll")]
        public static extern void DeleteCriticalSection(ref CRITICAL_SECTION lpCriticalSection);

        // ENTER CRITICAL SECTION
        [DllImport("kernel32.dll")]
        public static extern void EnterCriticalSection(ref CRITICAL_SECTION lpCriticalSection);

        // LEAVE CRITICAL SECTION
        [DllImport("kernel32.dll")]
        public static extern void LeaveCriticalSection(ref CRITICAL_SECTION lpCriticalSection);

        public static List<string> Ticker = new List<string>(50);
        readonly object lockOn = new object();
        public void Tick(bool  running)
        {
            lock (lockOn)
            {
                if(!running)
                {//остановить часы
                    if(!Form1.State) Monitor.Pulse(lockOn);//Уведомить любые ожидающие потоки
                    return;
                }
                Ticker.Add("ТИК");
                if (!Form1.State)
                {
                    Monitor.Pulse(lockOn);//Разрешить выполнение метода Tock()
                    Monitor.Wait(lockOn);//Ожидать завершения метода Tock()
                }
                
            }
        }

        public void Tock(bool running)
        {
            lock (lockOn)
            {
                if (!running)
                {//остановить часы
                    if (!Form1.State) Monitor.Pulse(lockOn);//Уведомить любые ожидающие потоки
                    return;
                }
                Ticker.Add("ТАК");
                if (!Form1.State)
                {
                    Monitor.Pulse(lockOn);//Разрешить выполнение метода Tock()
                    Monitor.Wait(lockOn);//Ожидать завершения метода Tock()
                }
                
            }
        }

    }
    internal class MyThread
    {
        public Thread Thrd;
        private readonly TickTok ttOb;

        //сконструировать новый поток
        public MyThread(string name, TickTok tt)
        {
            Thrd=new Thread(this.Run);
            ttOb = tt;
            Thrd.Name = name;
            Thrd.Start();
        }

        void Run()//начать выполнение нового потока
        {
            if(Thrd.Name=="Tick")
            {
                for (int i = 0; i < 10; i++)
                {
                    ttOb.Tick(true);
                }
                ttOb.Tick(false);
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    ttOb.Tock(true);
                }
                ttOb.Tock(false);
            }

        }


    }

}
