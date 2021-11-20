using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace OS5
{
    /// <summary>
    /// Этот поток уведомляет о том, что событие передано его конструктору
    /// </summary>
    internal class MyThreadEvent
    {
        public Thread Thrd;
        private ManualResetEvent mre;
        public static List<string > text=new List<string>(50);

        public MyThreadEvent(string name,ManualResetEvent evt)
        {
            Thrd=new Thread(this.Run);
            Thrd.Name = name;
            mre = evt;
            Thrd.Start();
        }

        /// <summary>
        /// точка входа в поток
        /// </summary>
        void Run()
        {
            text.Add("Внутри потока "+Thrd.Name);
            for (int i = 0; i < 5; i++)
            {
                text.Add(Thrd.Name);
                Thread.Sleep(500);
            }
            text.Add(Thrd.Name+" завершен!");
            //уведомить о событии
            mre.Set();
        }
    }


    class EventEx
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateEvent(IntPtr lpEventAttributes, bool bManualReset, bool bInitialState, string lpName);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        public static extern bool SetEvent(IntPtr hEvent);


        [DllImport("kernel32.dll")]
        public static extern bool ResetEvent(IntPtr hEvent);

        [DllImport("kernel32.dll")]
        public static extern bool PulseEvent(IntPtr hEvent);
    }
}
