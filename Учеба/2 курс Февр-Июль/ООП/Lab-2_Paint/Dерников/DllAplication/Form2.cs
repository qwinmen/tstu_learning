using System;
using System.Drawing;
using System.Windows.Forms;

namespace DllAplication
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        internal Point NumerXY { get; private set; }
        internal void button1_Click(object sender, EventArgs e)
        {
            int w = (int)numericUpDown1.Value,
                h = (int)numericUpDown2.Value;
            NumerXY = new Point(w, h);
            Image im = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(im);
            g.Clear(Color.White);
            g.Dispose();
        }
    }
}
