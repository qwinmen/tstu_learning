using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class CommandForm : Form
    {

        public UserControl1 myCtr;

        public CommandForm()
        {
            InitializeComponent();

        }


        private void CommandForm_Load(object sender, EventArgs e)
        {

        }

        private void CommandForm_Deactivate(object sender, EventArgs e)
        {
            //int i = 0;
        }

        private void CommandForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.myCtr.CloseToolBoox();
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if (!SelectBtn.Checked)
            {
                deselectAll();
                SelectBtn.Checked = true;
            }
            if (SelectBtn.Checked)
            {
                this.myCtr.Option = "select";
                this.Text = this.myCtr.Option;
            }


        }

        private void deselectAll()
        {
            this.SelectBtn.Checked = false;
            this.TboxBtn.Checked = false;
            this.RectBtn.Checked = false;
            this.RrectBtn.Checked = false;
            this.CircBtn.Checked = false;
            this.LineBtn.Checked = false;
            this.ImgBtn.Checked = false;
            

        }

        private void LineBtn_Click(object sender, EventArgs e)
        {
            if (!LineBtn.Checked)
            {
                deselectAll();
                LineBtn.Checked = true;
            }
            if (LineBtn.Checked)
            {
                this.myCtr.Option = "LI";
                this.Text = this.myCtr.Option;
            }


        }

        private void RectBtn_Click(object sender, EventArgs e)
        {
            if (!RectBtn.Checked)
            {
                deselectAll();
                RectBtn.Checked = true;
            }
            if (RectBtn.Checked)
            {
                this.myCtr.Option = "DR";
                this.Text = this.myCtr.Option;
            }


        }

        private void CircBtn_Click(object sender, EventArgs e)
        {
            if (!CircBtn.Checked)
            {
                deselectAll();
                CircBtn.Checked = true;
            }
            if (CircBtn.Checked)
            {
                this.myCtr.Option = "ELL";
                this.Text = this.myCtr.Option;
            }


        }

        private void TboxBtn_Click(object sender, EventArgs e)
        {
            if (!TboxBtn.Checked)
            {
                deselectAll();
                TboxBtn.Checked = true;
            }
            if (TboxBtn.Checked)
            {
                this.myCtr.Option = "TB";
                this.Text = this.myCtr.Option;
            }


        }

        private void RrectBtn_Click(object sender, EventArgs e)
        {
            if (!RrectBtn.Checked)
            {
                deselectAll();
                RrectBtn.Checked = true;
            }
            if (RrectBtn.Checked)
            {
                this.myCtr.Option = "DRR";
                this.Text = this.myCtr.Option;
            }


        }

        private void ImgBtn_Click(object sender, EventArgs e)
        {
            if (!ImgBtn.Checked)
            {
                deselectAll();
                ImgBtn.Checked = true;
            }
            if (ImgBtn.Checked)
            {
                this.myCtr.Option = "IB";
                this.Text = this.myCtr.Option;
            }


        }

        private void PcolBtn1_Click(object sender, EventArgs e)
        {

        }

        private void SelectBtn_MouseEnter(object sender, EventArgs e)
        {

          
            
        }

        private void SelectBtn_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void CommandForm_Click(object sender, EventArgs e)
        {
          
        }

        private void CommandForm_Activated(object sender, EventArgs e)
        {
            
        }
    }
}