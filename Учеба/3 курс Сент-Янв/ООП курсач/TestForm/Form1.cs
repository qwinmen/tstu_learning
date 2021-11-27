using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;

 

namespace TestForm
{
    public partial class Form1 : DevComponents.DotNetBar.Office2007Form
    {
         
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                if (i < 20) _list.Add(i);
                else
                {
                    ReWriteList();
                    i = 0;
                }
                
                
            }
            
        }

        private List<int> _list = new List<int>(20);
        private void ReWriteList()
        {
            List<int> tmp = new List<int>(10);
            tmp = _list.GetRange(10, 10);
            _list.Clear();
            _list = tmp;
        }

        int[] _arrList = new int[20];
        private int index = 0;
        private int i = 0;
        private void button1_Click_1(object sender, EventArgs e)
        {
            _arrList[i] = index;
            labelX1.Text = index.ToString();
            index++;
            i++;
        }


    }
}
