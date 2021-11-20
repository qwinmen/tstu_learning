using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
   
        public Form1()
        {
            InitializeComponent();
            myInit();
        }

        private void myInit()
        {
            this.toolBox1.setVectShape(this.userControl11);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

  
        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

 




        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

   

        private void label1_Click(object sender, EventArgs e)
        {

        }






        private void button1_Click_1(object sender, EventArgs e)
        {
            this.userControl11.Option = "TB";
        }


  

 

    






        private void label2_Click(object sender, EventArgs e)
        {

        }




        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void userControl11_Load(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.userControl11.HelpForm("");
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            this.userControl11.groupSelected();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.userControl11.deGroupSelected();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.userControl11.SaveSelected();
        }

        private void loadObj_Click(object sender, EventArgs e)
        {
            this.userControl11.LoadObj();
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            //userControl11.extPoints();
            userControl11.Mirror();
        }

       // private void Form1_Resize(object sender, EventArgs e)
       // {
       //     this.userControl11.Width = this.Width - panel1.Width - 25;
       //     this.userControl11.Height = this.Height - 1 ;
        // }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void toolBox1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_5(object sender, EventArgs e)
        {
            //deselectAll();
            //CirciBtn.Checked = true;
            //this.s.Option = "ELL";
            this.userControl11.Option = "PEN";
        }

        private void button1_Click_6(object sender, EventArgs e)
        {
            //this.userControl11.Option = "GRAPH";

            // test : saving to *bmp
            //this.userControl11.saveBmp();
            this.userControl11.delNodes();
            

        }

        private void userControl11_Load_1(object sender, EventArgs e)
        {

        }



   

    }
}
