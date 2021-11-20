using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ConsMemTest
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MForm());
        }
    }
}
