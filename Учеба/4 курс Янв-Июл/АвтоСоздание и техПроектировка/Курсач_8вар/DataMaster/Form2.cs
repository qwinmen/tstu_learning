using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;

namespace DataMaster
{
    public partial class Form2 : Office2007Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private int index = 1;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (index > pageSlider1.PageCount-1) index = 0;
            pageSlider1.SelectedPageIndex = index++;
        }
    }
}
