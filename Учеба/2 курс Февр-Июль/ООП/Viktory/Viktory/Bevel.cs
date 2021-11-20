using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
/*---Bevel-control---
 Четыре свойства компонента:
 * Style - стиль контура типа BevelStyle
 * Shape - форма контура типа BevelShape
 * BevelColor - цвет контура
 * BevelShadowColor - цвет тени контура
 Метод onPaint() для отрисовки контура 
 */

namespace ClassLibrary1
{
    public enum BevelStyle
    {
        Lowered,//Вдавленный контур
        Raised//Выпуклый контур
    } ;

    public enum BevelShape
    {//тип контура
        Box,
        Frame,
        TopLine,
        BottomLine,
        LeftLine,
        RightLine,
        VerticalLine,
        HorizontalLine
    } ;
    [ToolboxBitmap(typeof(Bevel))]
    [System.ComponentModel.DesignerCategory("code")]
    [Description("It is a component to decorate your WinForms")]
    [DefaultProperty("Style")]

    public partial class Bevel : UserControl//Panel
    {
        private Pen pen1, pen2;
        //конструктор класса
        public Bevel()
        {
            //InitializeComponent();
            //по умолчанию
            Style = BevelStyle.Lowered;
            Shape = BevelShape.Box;

            BevelColor = SystemColors.ButtonHighlight;
            BevelShadowColor = SystemColors.ButtonShadow;

            Width = 40;
            Height = 40;
            
        }

        //свойство которое будет определять стиль обрамления
        private BevelStyle style;
        [Category("Style"),Description("Bevel style property")]
        [DefaultValue(typeof(BevelStyle),"Lowered")]
        public BevelStyle Style
        {
            get { return style; }
            set { style = value;Invalidate(); }
        }

        //свойство определяющее форму обрамления
        private BevelShape shape;
        [Category("Style"),Description("Bevel shape")]
        [DefaultValue(typeof(BevelShape),"Box")]
        public BevelShape Shape
        {
            get { return shape; }
            set { shape = value;Invalidate(); }
        }

        //цвет обрамления
        [Category("Style"), Description("Bevel color")]
        [DefaultValue(typeof(Color), "ButtonHighlight")]
        public Color BevelColor { get; set; }

        //цвет тени
        [Category("Style"), Description("Bevel shadow")]
        [DefaultValue(typeof(Color), "ButtonShadow")]
        public Color BevelShadowColor { get; set; }

        //метод для рисования рамки с тенью
        void BevelRect(Graphics g,Rectangle rect)
        {
            g.DrawLine(pen1,new Point(rect.Left,rect.Top),new Point(rect.Left,rect.Bottom));
            g.DrawLine(pen1,new Point(rect.Left,rect.Top),new Point(rect.Right,rect.Top));

            g.DrawLine(pen2,new Point(rect.Right,rect.Top),new Point(rect.Right,rect.Bottom));
            g.DrawLine(pen2,new Point(rect.Right,rect.Bottom),new Point(rect.Left,rect.Bottom));
        }

        //событие onPaint которое вызывается при необходимости прорисовки
        protected override void OnPaint(PaintEventArgs e)
        {
            if (style==BevelStyle.Lowered)
            {
                pen1=new Pen(BevelShadowColor,1);
                pen2=new Pen(BevelColor,1);
            }
            else
            {
                pen1=new Pen(BevelColor,1);
                pen2=new Pen(BevelShadowColor,1);
            }

            //в зависимости от формы обрамления выводим рисунок
            switch (shape)
            {
                case BevelShape.Box:
                    BevelRect(e.Graphics,new Rectangle(0,0,Width-1,Height-1));
                    break;
                case BevelShape.Frame:
                    Pen temp = pen1;
                    pen1 = pen2;
                    BevelRect(e.Graphics,new Rectangle(0,0,Width-2,Height-2));
                    pen1 = temp;
                    pen2 = temp;
                    BevelRect(e.Graphics,new Rectangle(1,1,Width-2,Height-2));
                    break;
                case BevelShape.TopLine:
                    e.Graphics.DrawLine(pen1, new Point(0, 0), new Point(Width - 1, 0));
                    e.Graphics.DrawLine(pen2, new Point(0, 1), new Point(Width - 1, 1));
                    break;
                case BevelShape.BottomLine:
                    e.Graphics.DrawLine(pen1,new Point(0,Height-2),new Point(Width-1,Height-2));
                    e.Graphics.DrawLine(pen2,new Point(0,Height-1),new Point(Width-1,Height-1));
                    break;
                case BevelShape.LeftLine:
                    e.Graphics.DrawLine(pen1,new Point(0,0),new Point(0,Height-1));
                    e.Graphics.DrawLine(pen2,new Point(1,0),new Point(1,Height-1));
                    break;
                case BevelShape.RightLine:
                    e.Graphics.DrawLine(pen1,new Point(Width-2,0),new Point(Width-2,Height-1));
                    e.Graphics.DrawLine(pen2,new Point(Width-1,0),new Point(Width-1,Height-1));
                    break;
                case BevelShape.VerticalLine:
                    e.Graphics.DrawLine(pen1,new Point(Width/2,0),new Point(Width/2,Height-1));
                    e.Graphics.DrawLine(pen2,new Point(Width/2+1,0),new Point(Width/2+1,Height-1));
                    break;
                case BevelShape.HorizontalLine:
                    e.Graphics.DrawLine(pen1,new Point(0,Height/2),new Point(Width-1,Height/2));
                    e.Graphics.DrawLine(pen2,new Point(0,Height/2+1),new Point(Width-1,Height/2+1));
                    break;
            }
        }



//-------------------------------------------
        private string str;
        private int dR, dG, dB, sign;
        private Timer _Tmr;
        public String BevelText { get { return str; } set { str = value; } }
        void BevelTxt()
        {
            dR = this.BackColor.R - this.ForeColor.R;
            dG = this.BackColor.G - this.ForeColor.G;
            dB = this.BackColor.B - this.ForeColor.B;
            sign = 1;
            _Tmr=new Timer();
            _Tmr.Interval = 1000;
            _Tmr.Tick+=new EventHandler(timer_tick);
            _Tmr.Start();
        }

        void timer_tick(object sender,EventArgs e)
        {
            if (Math.Abs(this.ForeColor.R-this.BackColor.R)<Math.Abs(dR/10))
            {
                sign *= -1;
                this.Text = "Bla-Bla";
            }
            this.ForeColor = Color.FromArgb(255, this.ForeColor.R + sign*dR/10, this.ForeColor.G + sign*dG/10,
                                            this.ForeColor.B + sign*dB/10);

            if(this.BackColor.R==this.ForeColor.R+dR)
            {
                ((Timer)sender).Stop();
            }
        }
    }

}
