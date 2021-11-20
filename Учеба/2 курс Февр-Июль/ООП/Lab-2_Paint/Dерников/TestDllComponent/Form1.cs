using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;



namespace TestDllComponent
{
    public partial class Former1 : Form
    {
        public Former1()
        {
            InitializeComponent();
            /*Ничего умней не придумал как опрос свойства в потоке 2
             *Как вариант можно заюзать Event, т.е. как только StateClose=true произойдет уведомление
             *но лень*/
            DelegateFunc = new CloseApp(this.Close);
            Thread thread = new Thread(new ThreadStart(threadCloseForm))
                                {IsBackground = true, Priority = ThreadPriority.Lowest};
            thread.Start();
        }

        private delegate void CloseApp();

        private CloseApp DelegateFunc;
        void threadCloseForm()
        {
            while (!(form11.StateClose)){}
            this.Invoke(DelegateFunc);
        }

        
    }
}
