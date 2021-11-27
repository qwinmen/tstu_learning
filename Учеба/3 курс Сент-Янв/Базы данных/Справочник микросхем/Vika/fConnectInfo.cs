using System.Windows.Forms;

namespace Vika
{
    public partial class fConnectInfo : Form
    {
        public fConnectInfo()
        {
            InitializeComponent();
        }

        internal void Count(string count)
        {
            label4.Text = "Колличество записей: " + count;
        }
    }
}
