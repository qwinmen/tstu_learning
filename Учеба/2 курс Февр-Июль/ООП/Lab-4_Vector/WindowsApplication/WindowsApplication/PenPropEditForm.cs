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
    public partial class PenPropEditForm : Form
    {
        public PenPropEditForm()
        {
            InitializeComponent();
            this.TopLevel = false;
        }



        private void _Closed(object sender, System.EventArgs e)
        {
            _wfes.CloseDropDown();

        }

        private void PropEditForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



    }
}
