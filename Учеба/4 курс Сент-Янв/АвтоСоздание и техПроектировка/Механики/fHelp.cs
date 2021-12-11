using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Механики
{
    public partial class fHelp : Form
    {
        public fHelp()
        {
            InitializeComponent();
        }

        private bool down = false;
        private void groupPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (!down) 
                down = true;
        }

        private void groupPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(!down)return;
            pageSlider1.SelectedPage = pageSliderPage2;
            this.labelX9.Symbol = "";//up
            two = false;
        }

        private void groupPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
        }

        private bool two = true;
        private void labelX9_Click(object sender, EventArgs e)
        {
            if(two)
            {
                this.labelX9.Symbol = "";//up
                pageSlider1.SelectedPage = pageSliderPage2;
                two = !two;
            }
            else
            {
                this.labelX9.Symbol = "";//down
                pageSlider1.SelectedPage = pageSliderPage1;
                two = !two;
            }
            
            
        }
       
    }
}
