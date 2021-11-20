using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomColoredComboBox
{
    class ColoredComboBox : ComboBox
    {
        //the default colors from list        
        private  string[] arr_MyColors = { "Black", "Red", "Blue", "Green" };  

        protected int inMargin;  
        protected int boxWidth;
        private Color c;
        
        //public properties to interact with control from properties window
        public string[] MyColors  
        {
            get { return arr_MyColors; }
            set 
            {
                int col_numbers = value.Length;
                arr_MyColors = new string[col_numbers];
                for (int i = 0; i < col_numbers; i++)
                    arr_MyColors[i] = value[i];
                this.Items.Clear();
                InitCombo();
            }
        }
        public ColoredComboBox()  //constructor
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            inMargin = 2;
            boxWidth = 3;
            BeginUpdate();
            InitCombo();
            EndUpdate();
        }

        private void InitCombo() //add items 
        {
            if (arr_MyColors == null) return;
            foreach (string color in arr_MyColors)
            {
                try
                {
                    if (Color.FromName(color).IsKnownColor)
                        this.Items.Add(color);
                }
                catch 
                {
                    throw new Exception("Invalid Color Name: " + color);
                }
            }
        }
        
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if ((e.State & DrawItemState.ComboBoxEdit) != DrawItemState.ComboBoxEdit)
                e.DrawBackground();

            Graphics g = e.Graphics;
            if (e.Index == -1)  //if index is -1 do nothing
                return;
            c = Color.FromName((string)base.Items[e.Index]);

            //the color rectangle
            g.FillRectangle(new SolidBrush(c), e.Bounds.X + this.inMargin, e.Bounds.Y + 
                this.inMargin, e.Bounds.Width / this.boxWidth - 2 * this.inMargin, 
                e.Bounds.Height - 2 * this.inMargin);
            //draw border around color rectangle
            g.DrawRectangle(Pens.Black, e.Bounds.X + this.inMargin, 
                e.Bounds.Y + this.inMargin, e.Bounds.Width / this.boxWidth - 
                2 * this.inMargin, e.Bounds.Height - 2 * this.inMargin);
            //draw strings
            g.DrawString(c.Name, e.Font, new SolidBrush(ForeColor), 
                (float)(e.Bounds.Width / this.boxWidth + 5 * this.inMargin), 
                (float)e.Bounds.Y);
        }
    }
}





Пример использования
public string[] MyColors  
{
    get { return arr_MyColors; }
    set 
    {
        int col_numbers = value.Length;
        arr_MyColors = new string[col_numbers];
        for (int i = 0; i < col_numbers; i++)
        arr_MyColors[i] = value[i];
        this.Items.Clear();
        InitCombo();
    }
}