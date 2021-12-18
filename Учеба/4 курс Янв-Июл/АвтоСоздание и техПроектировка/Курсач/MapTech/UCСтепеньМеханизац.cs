using System.Windows.Forms;

namespace TestFile
{
    /// <summary>
    /// определить открытый делегат radioButton1_CheckedChanged
    /// </summary>
    public delegate void rbEventHandler(object sender, System.EventArgs e);

    public partial class UCСтепеньМеханизац : UserControl
    {
        public UCСтепеньМеханизац()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие которое высвитится в событиях контрола	
        /// </summary>
        public event rbEventHandler КодСтепеньМеханизацииEvent;

        internal int КодСтепеньМеханизации { get; private set; }

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                КодСтепеньМеханизации = int.Parse(((RadioButton)sender).Tag.ToString());
                КодСтепеньМеханизацииEvent(sender, e);
            }
            catch (System.NullReferenceException)
            {
            }
        }

    }
}
