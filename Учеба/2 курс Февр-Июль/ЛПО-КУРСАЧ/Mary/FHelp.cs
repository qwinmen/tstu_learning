using System.Windows.Forms;

namespace Mary
{
    public partial class FHelp : Form
    {
        public FHelp()
        {
            InitializeComponent();
            tbText.Select(0, 0);
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(panel1,"Открыть сайт автора программы");
        }

        private void panel1_Click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.qwinmen.narod.ru");
            this.Close();
        }
    }
}
