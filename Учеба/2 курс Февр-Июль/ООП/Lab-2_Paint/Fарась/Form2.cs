

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PNGEDIT1
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            
            InitializeComponent();
        }

        internal Point NumerXY { get;  set; }
        internal void button1_Click(object sender, EventArgs e)
        {
            int w = (int)numericUpDown1.Value,
                h = (int)numericUpDown2.Value;
            NumerXY = new Point(970, 709);
            Image im = new Bitmap(970, 709);
            Graphics g = Graphics.FromImage(im);
            g.Clear(Color.White);
            g.Dispose();
            
        }
    }
}
