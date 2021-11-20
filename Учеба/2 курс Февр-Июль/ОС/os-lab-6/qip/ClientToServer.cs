using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace qip
{
    public partial class ClientToServer : Form
    {
        public ClientToServer()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter && textBox1.Text.Length > 1)
            {
                StrClientToServB = textBox1.Text;
                this.Close();
            }
        }

        internal string StrClientToServB { get; private set; }

        private readonly KeyPressEventArgs _eEnter = new KeyPressEventArgs((char)Keys.Enter);
        private void btnOk_Click(object sender, EventArgs e)
        {
            textBox1_KeyPress(sender,_eEnter);
        }
    }
}
