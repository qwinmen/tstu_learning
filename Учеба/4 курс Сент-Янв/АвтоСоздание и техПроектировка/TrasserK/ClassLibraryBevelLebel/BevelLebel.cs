using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibraryBevelLebel
{
    public enum BevelStyle
    {
        Lowered,
        Raised
    } ;

    public enum BevelShape
    {
        Box,
        Frame,
        TopLine,
        BottomLine,
        LeftLine,
        RightLine,
        VerticalLine,
        HorizontalLine
    } ;

    /// <summary>
    /// определить открытый делегат button_Click
    /// </summary>
    public delegate void ClickEventHandler(object sender, EventArgs e);
    /// <summary>
    /// определить открытый делегат MouseDown
    /// </summary>
    public delegate void MouseDwnEventHandler(object sender, MouseEventArgs e);
    public delegate void MouseMovEventHandler(object sender, MouseEventArgs e);
    public delegate void MouseUpEventHandler(object sender, MouseEventArgs e);


    [ToolboxBitmap(typeof(BevelLebel))]
    [System.ComponentModel.DesignerCategory("code")]
    [Description("Компонент типо панель плюс лейбл в углу")]
    [DefaultProperty("Style")]
    public partial class BevelLebel : UserControl
    {
        private Pen pen1, pen2;

        /// <summary>
        /// Событие которое высвитится в событиях контрола	
        /// </summary>
        public event ClickEventHandler CliclEvent;

        public BevelLebel()
        {
            InitializeComponent();

            //по умолчанию
            Style = BevelStyle.Lowered;
            Shape = BevelShape.Box;

            BevelColor = SystemColors.ButtonHighlight;
            BevelShadowColor = SystemColors.ButtonShadow;

            Width = 40;
            Height = 40;

            label1.Parent = this;
        }

        /// <summary>
        /// Клик по панели завязан на внутренем событии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BevelLebel_Click(object sender, EventArgs e)
        {
            try
            {
                CliclEvent(sender, e);
            }
            catch (NullReferenceException)
            {
                //MessageBox.Show("Нет подписавшихся");
            }
        }

        #region Properties

        //свойство которое будет определять стиль обрамления
        private BevelStyle style;
        [Category("Style"), Description("Свойство которое будет определять стиль обрамления")]
        [DefaultValue(typeof(BevelStyle), "Lowered")]
        public BevelStyle Style
        {
            get { return style; }
            set { style = value; Invalidate(); }
        }

        //свойство определяющее форму обрамления
        private BevelShape shape;
        [Category("Style"), Description("Свойство определяющее форму обрамления")]
        [DefaultValue(typeof(BevelShape), "Box")]
        public BevelShape Shape
        {
            get { return shape; }
            set { shape = value; Invalidate(); }
        }

        //цвет обрамления
        [Category("Style"), Description("Цвет обрамления")]
        [DefaultValue(typeof(Color), "ButtonHighlight")]
        public Color BevelColor { get; set; }

        //цвет тени
        [Category("Style"), Description("Цвет тени")]
        [DefaultValue(typeof(Color), "ButtonShadow")]
        public Color BevelShadowColor { get; set; }

        [DefaultValue(typeof(String), "1")]
        public string NumLabel
        {
            get { return label1.Text; }
            set { label1.Text = value; Invalidate(); }
        }
        
        #endregion

        /// <summary>
        /// метод для рисования рамки с тенью
        /// </summary>
        void BevelRect(Graphics g, Rectangle rect)
        {
            g.DrawLine(pen1, new Point(rect.Left, rect.Top), new Point(rect.Left, rect.Bottom));
            g.DrawLine(pen1, new Point(rect.Left, rect.Top), new Point(rect.Right, rect.Top));

            g.DrawLine(pen2, new Point(rect.Right, rect.Top), new Point(rect.Right, rect.Bottom));
            g.DrawLine(pen2, new Point(rect.Right, rect.Bottom), new Point(rect.Left, rect.Bottom));
        }

        //событие onPaint которое вызывается при необходимости прорисовки
        protected override void OnPaint(PaintEventArgs e)
        {
            #region Рамка по контуру
            if (style == BevelStyle.Lowered)
            {
                pen1 = new Pen(BevelShadowColor, 1);
                pen2 = new Pen(BevelColor, 1);
            }
            else
            {
                pen1 = new Pen(BevelColor, 1);
                pen2 = new Pen(BevelShadowColor, 1);
            }

            //в зависимости от формы обрамления выводим рисунок
            switch (shape)
            {
                case BevelShape.Box:
                    BevelRect(e.Graphics, new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
                case BevelShape.Frame:
                    Pen temp = pen1;
                    pen1 = pen2;
                    BevelRect(e.Graphics, new Rectangle(0, 0, Width - 2, Height - 2));
                    pen1 = temp;
                    pen2 = temp;
                    BevelRect(e.Graphics, new Rectangle(1, 1, Width - 2, Height - 2));
                    break;
                case BevelShape.TopLine:
                    e.Graphics.DrawLine(pen1, new Point(0, 0), new Point(Width - 1, 0));
                    e.Graphics.DrawLine(pen2, new Point(0, 1), new Point(Width - 1, 1));
                    break;
                case BevelShape.BottomLine:
                    e.Graphics.DrawLine(pen1, new Point(0, Height - 2), new Point(Width - 1, Height - 2));
                    e.Graphics.DrawLine(pen2, new Point(0, Height - 1), new Point(Width - 1, Height - 1));
                    break;
                case BevelShape.LeftLine:
                    e.Graphics.DrawLine(pen1, new Point(0, 0), new Point(0, Height - 1));
                    e.Graphics.DrawLine(pen2, new Point(1, 0), new Point(1, Height - 1));
                    break;
                case BevelShape.RightLine:
                    e.Graphics.DrawLine(pen1, new Point(Width - 2, 0), new Point(Width - 2, Height - 1));
                    e.Graphics.DrawLine(pen2, new Point(Width - 1, 0), new Point(Width - 1, Height - 1));
                    break;
                case BevelShape.VerticalLine:
                    e.Graphics.DrawLine(pen1, new Point(Width / 2, 0), new Point(Width / 2, Height - 1));
                    e.Graphics.DrawLine(pen2, new Point(Width / 2 + 1, 0), new Point(Width / 2 + 1, Height - 1));
                    break;
                case BevelShape.HorizontalLine:
                    e.Graphics.DrawLine(pen1, new Point(0, Height / 2), new Point(Width - 1, Height / 2));
                    e.Graphics.DrawLine(pen2, new Point(0, Height / 2 + 1), new Point(Width - 1, Height / 2 + 1));
                    break;
            }
            #endregion

        }



    }
}
