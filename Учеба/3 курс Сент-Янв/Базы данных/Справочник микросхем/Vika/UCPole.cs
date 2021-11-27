using System;
using System.Drawing;
using System.Windows.Forms;

namespace TreeControll
{
    /// <summary>
    /// определить открытый делегат button_Click
    /// </summary>
    public delegate void MyEventHandler(object sender, EventArgs e);

    public partial class UCPole : UserControl
    {
        /// <summary>
        /// Событие которое высвитится в событиях контрола --button
        /// </summary>
        public event MyEventHandler MyEvent;
        /// <summary>
        /// Событие выбора ПОЛЯ --comboBox
        /// </summary>
        public event MyEventHandler SelectPole;
        /// <summary>
        /// Событие выбора МАСКИ --comboBox
        /// </summary>
        public event MyEventHandler SelectMaska;
        /// <summary>
        /// Событие ввода текста в поле --textBox
        /// </summary>
        public event MyEventHandler InputTextBox;
        /// <summary>
        /// Событие ввода чисел в поле --doubleInput
        /// </summary>
        public event MyEventHandler InputDoubleBox;

        public UCPole()
        {
            InitializeComponent();

            m_ExpandedHeight = this.Height;
            this.Height = comboBox1.Height+button1.Height;

            //MyEvent += new MyEventHandler(button1_Click);
        }
        
        private bool m_Expanded = false;
        private int m_ExpandedHeight = 0;

        private void linkLabelName_Click(object sender, EventArgs e)
        {
            this.Expanded = !this.Expanded;
        }

        /// <summary>
        /// Имя заголовка окна
        /// </summary>
        public string EmployeeName
        {
            get { return linkLabelName.Text; }
            set { linkLabelName.Text = value; }
        }

        /// <summary>
        /// Что выбранно в комбоБоксе Parametr
        /// </summary>
        public string EmployeeTitle
        {
            get { return comboBox1.Text; }
            set { comboBox1.Text = value; }
        }

        /// <summary>
        /// Что выбранно в комбоБоксе Maska
        /// </summary>
        public string EmployeeMaska
        {
            get { return comboBoxМаска.Text; }
            set { comboBoxМаска.Text = value; }
        }

        /// <summary>
        /// ТекстБокс доступен?
        /// </summary>
        public bool isTextBox
        {
            get { return textBoxX1.Visible; }
            set { textBoxX1.Visible = value; }
        }

        /// <summary>
        /// Что было введено
        /// </summary>
        public string InputText
        {
            get 
            {
                if (textBoxX1.Visible)
                {
                    return textBoxX1.Text;
                }
                return doubleInput1.Value.ToString();
            }
            set
            {
                if (textBoxX1.Visible)
                {
                    textBoxX1.Text = value;
                }
                else doubleInput1.Text = value;
            }
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
                    size.Height = comboBox1.Height;
                this.Size = size;
            }
        }

        /// <summary>
        /// В боксе выбран элемент поиска
        /// </summary>
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EmployeeTitle = comboBox1.Text;
            try
            {
                SelectPole(sender, e);
            }
            catch (NullReferenceException){}

            textBoxX1.Text = "";
            doubleInput1.Text = "";
            if(comboBox1.Text.Contains("name")||comboBox1.Text.Contains("h21")||comboBox1.Text.Contains("title")||comboBox1.Text.Contains("picture"))
            {
                isTextBox = true;
                doubleInput1.Visible = false;
                textBoxX1.Visible = true;
            }
            else
            {
                isTextBox = false;
                textBoxX1.Visible = false;
                doubleInput1.Visible = true;
            }

        }

        /// <summary>
        /// Выбор маски
        /// </summary>
        private void comboBoxМаска_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                SelectMaska(sender, e);
            }
            catch (NullReferenceException){}

        }

        /// <summary>
        /// Выполнить построение ЛОГИКИ
        /// </summary>
        public bool AddLogik{ get; set; }

        /// <summary>
        /// Выполнить переход к элементу ЛОГИКА
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            AddLogik = true;
            try
            {
                MyEvent(sender, e);
            }
            catch (NullReferenceException)
            {
                //MessageBox.Show("Нет подписашихся");
            }
            
        }

        
        /// <summary>
        /// Вводим значения в текстовое поле
        /// </summary>
        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxX1.Visible)
            {
                try
                {
                    InputTextBox(sender, e);
                    InputText = textBoxX1.Text;
                }
                catch (NullReferenceException)
                {
                    //MessageBox.Show("Нет подписашихся");
                }
            }
        }

        /// <summary>
        /// Вводим цифровые значения в поле
        /// </summary>
        private void doubleInput1_ValueObjectChanged(object sender, EventArgs e)
        {
            if (doubleInput1.Visible)
            {
                try
                {
                    InputDoubleBox(sender, e);
                    InputText = doubleInput1.Value.ToString();
                }
                catch (NullReferenceException)
                {
                    //MessageBox.Show("Нет подписашихся");
                }
            }
        }

        


    }
}
