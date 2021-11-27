using System;
using System.Windows.Forms;

namespace Куб
{
    public partial class fProecion : Form
    {
        public fProecion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) Kabinet = radioButton1.Checked;
            if (radioButton2.Checked) Voennik = radioButton2.Checked;

            //Закрыть окно
            this.Close();
        }

        internal bool Kabinet { get; private set; }
        internal bool Voennik { get; private set; }
    }
}
