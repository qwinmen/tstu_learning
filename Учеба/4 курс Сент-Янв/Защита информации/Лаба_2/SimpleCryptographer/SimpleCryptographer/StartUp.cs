using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SimpleCryptographer
{
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();
        }

        private void StartUp_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer1 = new System.Timers.Timer();

            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            timer1.Interval = 2000;
            timer1.Start();
        }

        void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            #region The code for fix Cross-Thread bug.
            if (this.InvokeRequired) // This shouldn't happen since we are on the same thread 
            {
                this.Invoke(new MethodInvoker(CloseForm));
            }
            else
            {
                CloseForm();
            }
            #endregion
        }

        void CloseForm()
        {
            this.Close();
        }
    }
}