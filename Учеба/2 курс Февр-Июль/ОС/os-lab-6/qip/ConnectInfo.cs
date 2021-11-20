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
    public partial class ConnectInfo : Form
    {
        public ConnectInfo()
        {
            InitializeComponent();
        }

        private void txtBoxNameMail_MouseClick(object sender, MouseEventArgs e)
        {
            txtBoxNameMail.Text = "";
        }


        private void txtBoxNameMail_KeyPress(object sender, KeyPressEventArgs e)
        {//btnOk and txtBox.Enter event:
            if (e.KeyChar == (char)Keys.Enter && txtBoxNameMail.Text.Length > 1)
            {
                StrMailBox = txtBoxNameMail.Text;
                this.Close();
            }
        }

        internal string StrMailBox { get; private set; }

        private readonly KeyPressEventArgs eEnter = new KeyPressEventArgs((char)Keys.Enter);
        private void btnOk_Click(object sender, EventArgs e)
        {//закольцевали на txtBoxNameMail_KeyPress
            txtBoxNameMail_KeyPress(sender, eEnter);
        }

        
    }
}
