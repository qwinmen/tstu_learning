using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WindowsApplication1
{
    public partial class PropEditForm : Form
    {
        public PropEditForm()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarValue = this.vectShapes1.getPointSet();
            Close();
            
        }


        private void _Closed(object sender, System.EventArgs e)
        {
            _wfes.CloseDropDown();

        }

        private void PropEditForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            //BarValue = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.s.Option = "ELL";
            this.vectShapes1.Option = "ELL";
        }

    }
}
