using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Magomed
{
    public partial class fParamInterpol : Form
    {
        public fParamInterpol()
        {
            InitializeComponent();
            
        }
               
        private void radioButton_X_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_X.Checked)
            {//Отмечен Х - недоступен У
                textBox_XParam.Enabled = true;
                buttonOK_X.Enabled = true;
            }
            else
            {//Отмечен У - недоступен Х
                textBox_YParam.Enabled = true;
                buttonOK_Y.Enabled = true;
                textBox_XParam.Enabled = false;
                buttonOK_X.Enabled = false;
            }
        }

        public delegate void EventHandler(Object sender,EventArgs e);
        private void buttonOK_X_Click(object sender, EventArgs e)
        {//Опрашиваем ТипМетода\Число .Все по Х
            //MessageBox.Show("Выбран "+comboBox_MetodCheked.SelectedItem+"\n"+textBox_XParam.Text);
            string r = textBox_XParam.Text;
            Age =Convert.ToInt32(r);
            //fMain fm=new fMain();
            //fm.FF(10,10);

        }

        private void buttonOK_Y_Click(object sender, EventArgs e)
        {//Опрашиваем ТипМетода\Число .Все по У
            //MessageBox.Show("Выбран "+comboBox_MetodCheked.SelectedItem+"\n"+textBox_YParam.Text);

        }
//============================================================================//
        public event EventHandler AgeChanged;//обьявляем событие
        private int age = 0;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    throw new Exception("Возраст не может быть отрицательным");//искл ситуация
                age = value;
                if (AgeChanged != null)
                    AgeChanged(this, new EventArgs());
            }
        }
//============================================================================//
        
    }
}
