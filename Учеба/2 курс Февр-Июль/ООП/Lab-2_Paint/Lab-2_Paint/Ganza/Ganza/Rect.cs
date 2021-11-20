using System.Drawing;

namespace Ganza
{
    class Rect:Shape
    {
        public Rectangle Rectangle { get; set; }
        
        public Rect( )
        {
            Rectangle = new Rectangle();
            _Pen = new Pen(Color.Black);
        }

        public override void Draw(System.Drawing.Graphics graphics)
        {
            if (State) graphics.FillRectangle(new SolidBrush(_Pen.Color),Rectangle);
            graphics.DrawRectangle(_Pen, Rectangle);
        }
    }
}
