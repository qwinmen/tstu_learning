using System.Windows.Forms;

namespace Trans
{
    public partial class FHelp : Form
    {
        public FHelp()
        {
            InitializeComponent();
            fHelp();
        }
        void fHelp()
        {
            tbText.Select(0,0);
        }
    }
}