using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace OS5
{
    /// <summary>
    /// Общий ресурс - переменая Count, а также мютекс - управляющий доступом к ней
    /// </summary>
    internal class SharedRes
    {
        public static int Count = 0;
        public static Mutex Mtx = new Mutex();
    }

    /// <summary>
    /// В этом потоке переменая Shared.Count инкрементируется
    /// </summary>
    internal class IncThread
    {
        
        private int num;
        public Thread Thrd;
        public IncThread (string name,int n)
        {
            Thrd=new Thread(this.Run);
            num = n;
            Thrd.Name = name;
            Thrd.Start();
        }

        /// <summary>
        /// Точка входа в поток
        /// </summary>
        void Run()
        {
            Form1.console.Add(Thrd.Name+" ожидает мьютекс");
            //получить мютекс
            if (!Form1.State) SharedRes.Mtx.WaitOne();
            Form1.console.Add(Thrd.Name + " получает мьютекс");
            do
            {
                Thread.Sleep(500);
                SharedRes.Count++;
                Form1.console.Add("В потоке "+Thrd.Name + ", SharedRes.Count="+SharedRes.Count);
                num--;
            } while (num>0);
            Form1.console.Add(Thrd.Name + " освобождает мьютекс");
            //освободить мютекс
            if (!Form1.State) SharedRes.Mtx.ReleaseMutex();
        }
    }
    
    /// <summary>
    /// В этом потоке переменная SharedRes.Count дектементируется
    /// </summary>
    internal class DecThread
    {
        private int num;
        public Thread Thrd;

        public DecThread(string name,int n)
        {
            Thrd=new Thread(new ThreadStart(this.Run));
            num = n;
            Thrd.Name = name;
            Thrd.Start();
        }

        //точка входа в поток
        void Run()
        {
            Form1.console.Add(Thrd.Name+" ожидает мютекс");
            //получить мютекс
            if (!Form1.State) SharedRes.Mtx.WaitOne();
            Form1.console.Add(Thrd.Name + " получает мютекс");
            do
            {
                Thread.Sleep(500);
                SharedRes.Count--;
                Form1.console.Add("В потоке " +Thrd.Name + ", SharedRes.Count="+SharedRes.Count);
                num--;
            } while (num>0);
            Form1.console.Add(Thrd.Name + " освобождает мютекс");
            //освободить мютекс
            if (!Form1.State) SharedRes.Mtx.ReleaseMutex();
        }

    }

    class MutexEx
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, bool bInitialOwner, string lpName);

        [DllImport("kernel32.dll")]
        public static extern bool ReleaseMutex(IntPtr hMutex);
    }
}
