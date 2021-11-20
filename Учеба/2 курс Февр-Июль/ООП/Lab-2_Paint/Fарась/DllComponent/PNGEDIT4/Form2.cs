using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PNGEDIT4
{
    class Form2
    {
        internal Point NumerXY { get; set; }
        internal void button1_Click(object sender, EventArgs e)
        {
            NumerXY = new Point(970, 709);
            Image im = new Bitmap(970, 709);
            Graphics g = Graphics.FromImage(im);
            g.Clear(Color.White);
            g.Dispose();
        }

    }
}
