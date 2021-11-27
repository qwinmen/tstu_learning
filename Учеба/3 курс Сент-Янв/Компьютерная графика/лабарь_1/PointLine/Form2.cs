using System.Drawing;
using System.Windows.Forms;

namespace PointLine
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private fMain _fMain = new fMain();
        public static bool CheckedBox{ get; private set;}

        private void checkBoxВклМышку_CheckedChanged(object sender, System.EventArgs e)
        {
            if((sender as CheckBox).Checked)
            {
                CheckedBox = true;
                MouseEventArgs ee = new MouseEventArgs(MouseButtons.Left, 0, (int)numUpDownX_1.Value, (int)numUpDownY_1.Value,0);
                _fMain.OGlControl_MouseUp(sender, ee);
            }
            else CheckedBox = false;

        }

        private void numUpDownX_0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((Keys)e.KeyChar == Keys.Enter & !CheckedBox)
            {
                _fMain.NewCoordinates((int)numUpDownX_0.Value, (int)numUpDownY_0.Value, (int)numUpDownX_1.Value, (int)numUpDownY_1.Value);
            }

        }

    }
}
