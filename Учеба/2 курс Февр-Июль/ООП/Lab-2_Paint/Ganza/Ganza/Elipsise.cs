using System.Drawing;

namespace Ganza
{
    class Elipsise : Shape
    {
        public Point Begin { get; set; }
        public Point End { get; set; }
        
        public Elipsise()
        {
            Begin = new Point();
            End = new Point();
            if (_Pen==null)
            {
                _Pen = new Pen(Color.Black);
            }
        }
        public override void Draw(System.Drawing.Graphics graphics)
        {
            graphics.DrawEllipse(_Pen, Begin.X, Begin.Y, End.X - Begin.X, End.Y - Begin.Y);
        }
    }
}
