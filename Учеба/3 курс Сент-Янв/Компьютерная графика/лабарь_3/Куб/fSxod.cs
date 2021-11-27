using System;
using System.Windows.Forms;

namespace Куб
{
    public partial class fSxod : Form
    {
        public fSxod()
        {
            InitializeComponent();

            SxodX = false;
            SxodY = false;
            SxodZ = false;
        }

        /// <summary>
        /// Закрыть форму
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            //пройтись по списку с пунктами
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                switch (i)
                {
                    case 0://X
                        SxodX = checkedListBox1.GetItemChecked(i);
                        break;
                    case 1://Y
                        SxodY = checkedListBox1.GetItemChecked(i);
                        break;
                    case 2://Z
                        SxodZ = checkedListBox1.GetItemChecked(i);
                        break;
                }
            }
            

            this.Close();
        }

        internal bool SxodX { get; private set; }
        internal bool SxodY { get; private set; }
        internal bool SxodZ { get; private set; }

    }
}
