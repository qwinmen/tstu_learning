using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestFile
{
    /// <summary>
    /// определить открытый делегат
    /// </summary>
    public delegate void rbnEventHandler(object sender, EventArgs e);
    public partial class UCКодУсловийТруда : UserControl
    {
        public UCКодУсловийТруда()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие которое высвитится в событиях контрола	
        /// </summary>
        public event rbnEventHandler КодУсловийТруда_Event;

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                КодУсловийТруда = int.Parse(((RadioButton)sender).Tag.ToString());
                КодУсловийТруда_Event(sender, e);
            }
            catch (NullReferenceException)
            {
            }
        }

        internal int КодУсловийТруда { get; private set; }
    }
}
