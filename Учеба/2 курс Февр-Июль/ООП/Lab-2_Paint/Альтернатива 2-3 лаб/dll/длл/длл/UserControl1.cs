using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace длл
{
    public partial class UserControl1 : UserControl
    {



        public UserControl1()
        {

            InitializeComponent();
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Form1 fPic = new Form1();
            fPic.ActiveControl = fPic.pictureBox1;             
            fPic.ShowDialog();
            
        }


        

    }
}
