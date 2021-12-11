using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button_chipmode_Click(object sender, EventArgs e)
        {
            workbench.mode = mode.chip;
        }

        private void button_linemode_Click(object sender, EventArgs e)
        {
            workbench.mode = mode.line;
        }

        private void button_trace_Click(object sender, EventArgs e)
        {
            workbench.trace();
            
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            workbench.clean();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            legend.Visible = !legend.Visible;
        }

        private void Scroll_interspace_Scroll(object sender, ScrollEventArgs e)
        {
            workbench.set_intersapace(e.NewValue);
            label_interspace.Text = Convert.ToString(e.NewValue);
        }
    }
}
