using System;
using System.Windows.Forms;

namespace Korsar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int key = 0;
        private void bAktivator_Click(object sender, EventArgs e)
        {
            key = 1;
            bAktivator.Text = "Stop";
            
        }
        private void bUbegaet_MouseMove(object sender, MouseEventArgs e)
        {
            
            
            
        }
    }
}
