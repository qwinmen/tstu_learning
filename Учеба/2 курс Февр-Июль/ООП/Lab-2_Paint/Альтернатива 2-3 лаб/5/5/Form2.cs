

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

        internal void button1_Click(object sender, EventArgs e)
        {
            int w = (int)numericUpDown1.Value,
                h = (int)numericUpDown2.Value;
            Image im = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(im);
            g.Clear(Color.White);
            g.Dispose();
           PictureBox p = Owner.Controls["panel1"].Controls["pictureBox1"]
              as PictureBox;
            if (p.Image != null)
                p.Image.Dispose();
            p.Image = im;
  

        }
    }
}
