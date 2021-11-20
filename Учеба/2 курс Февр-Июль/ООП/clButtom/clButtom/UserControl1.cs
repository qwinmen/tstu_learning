using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace clButtom
{
    public partial class UserControl1 : ButtonBase
    {
        public enum ButtomStyle
        {
            Lowered,
            Raised
        } ;

        public enum ButtomShape
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

        public UserControl1()
        {//конструктор
            InitializeComponent();
            
            Style = ButtomStyle.Lowered;
            Shape = ButtomShape.Box;

            ButtomColor = SystemColors.WindowFrame;
            ButtomShadowColor = SystemColors.Highlight;

            Width = 40;
            Height = 30;
        }

        //свойство которое будет определять стиль обрамления
        private ButtomStyle style;
        public ButtomStyle Style
        {
            get { return style; }
            set { style = value; Invalidate(); }
        }

        //свойство определяющее форму обрамления
        private ButtomShape shape;
        public ButtomShape Shape
        {
            get { return shape; }
            set { shape = value; Invalidate(); }
        }

        //цвет обрамления
        public Color ButtomColor { get; set; }

        //цвет тени
        public Color ButtomShadowColor { get; set; }

        //метод для рисования рамки с тенью
        private Pen pen1, pen2;
        public void ButtomRect(Graphics g, Rectangle rect)
        {
            g.DrawLine(pen1, new Point(rect.Left, rect.Top), new Point(rect.Left, rect.Bottom));
            g.DrawLine(pen1, new Point(rect.Left, rect.Top), new Point(rect.Right, rect.Top));

            g.DrawLine(pen2, new Point(rect.Right, rect.Top), new Point(rect.Right, rect.Bottom));
            g.DrawLine(pen2, new Point(rect.Right, rect.Bottom), new Point(rect.Left, rect.Bottom));
        }

        private string _text;
        public string Message
        {
            get { return _text; }
            set { _text = value; Invalidate(); }
        }
        public void AddTextBtn(string text)
        {
            Message = text;
        }



    }//end class
}
