using System.Drawing;

namespace Ganza
{
    class Rect:Shape
    {
        public Rectangle Rectangle { get; set; }

        public Rect()
        {
            Rectangle = new Rectangle();
            _Pen = new Pen(Color.Black);
        }

        public override void Draw(System.Drawing.Graphics graphics)
        {
            graphics.DrawRectangle(_Pen, Rectangle);
        }
    }
}
