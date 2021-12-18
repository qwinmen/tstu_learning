using System;
using System.Windows.Forms;

namespace TestFile
{
    /// <summary>
    /// определить открытый делегат
    /// </summary>
    public delegate void rbcEventHandler(object sender, EventArgs e);
    public partial class UCРазрядРаботы : UserControl
    {
        public UCРазрядРаботы()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие которое высвитится в событиях контрола	
        /// </summary>
        public event rbcEventHandler РазрядРабот_Event;

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                РазрядРабот = int.Parse(((RadioButton)sender).Tag.ToString());
                РазрядРабот_Event(sender, e);
            }
            catch (NullReferenceException)
            {
            }
        }

        internal int РазрядРабот { get; private set; }

    }
}
