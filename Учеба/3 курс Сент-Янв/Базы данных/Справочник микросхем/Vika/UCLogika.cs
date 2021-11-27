using System;
using System.Drawing;
using System.Windows.Forms;

namespace TreeControll
{
    /// <summary>
    /// определить открытый делегат button_Click
    /// </summary>
    public delegate void MyEventHandlerClick(object sender, EventArgs e);

    public partial class UCLogika : UserControl
    {
        
        /// <summary>
        /// Событие которое высвитится в событиях контрола
        /// </summary>
        public event MyEventHandlerClick LogikaEvent;

        private bool m_Expanded = false;
        private int m_ExpandedHeight = 0;
        /// <summary>
        /// Логика
        /// </summary>
        public UCLogika()
        {
            InitializeComponent();

            m_ExpandedHeight = this.Height;
            this.Height = linkLabel1.Height + button1.Height;
        }

        /// <summary>
        /// Имя заголовка окна
        /// </summary>
        public string EmployeeName
        {
            get { return linkLabel1.Text; }
            set { linkLabel1.Text = value; }
        }

        /// <summary>
        /// Что выбранно в radioButonAND
        /// </summary>
        public bool isANDChecked
        {
            get
            {
                if (radioButtonAND.Checked)
                    return radioButtonAND.Checked;
                return radioButtonAND.Checked;
            }
            set { radioButtonAND.Checked = value; }
        }

        /// <summary>
        /// Что выбранно в radioButonOR
        /// </summary>
        public bool isORChecked
        {
            get
            {
                if (radioButtonOR.Checked)
                    return radioButtonOR.Checked;
                return radioButtonOR.Checked;
            }
            set { radioButtonOR.Checked = value; }
        }

        /// <summary>
        /// Раскрыть форму
        /// </summary>
        private void linkLabel1_Click(object sender, EventArgs e)
        {
            this.Expanded = !this.Expanded;
        }

        public bool Expanded
        {
            get
            {
                return m_Expanded;
            }
            set
            {
                m_Expanded = value;
                Size size = this.Size;
                if (this.Parent is DevComponents.Tree.TreeGX)
                    size = ((DevComponents.Tree.TreeGX)this.Parent).GetLayoutRectangle(this.Bounds).Size;

                if (m_Expanded)
                    size.Height = m_ExpandedHeight;
                else
                    size.Height = linkLabel1.Height;
                this.Size = size;
            }
        }

        /// <summary>
        /// Выполнить построение ПОЛЕ
        /// </summary>
        public bool AddPole { get; set; }

        /// <summary>
        /// Выполнить переход к элементу ПОЛЕ
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            AddPole = true;
            try
            {
                LogikaEvent(sender, e);
            }
            catch (NullReferenceException)
            {
                //MessageBox.Show("Нет подписашихся");
            }
        }


        /// <summary>
        /// TRUE при AND, и false при OR
        /// </summary>
        public bool isAND
        {
            get
            {
                if (radioButtonAND.Checked)
                {
                    return true;
                }
                return false;
            }
            private set { }

        }

        /// <summary>
        /// Стал активен AND
        /// </summary>
        private void radioButtonAND_CheckedChanged(object sender, EventArgs e)
        {
            isAND = true;
        }
        /// <summary>
        /// Стал активен OR
        /// </summary>
        private void radioButtonOR_CheckedChanged(object sender, EventArgs e)
        {
            isAND = false;
        }

    }
}
