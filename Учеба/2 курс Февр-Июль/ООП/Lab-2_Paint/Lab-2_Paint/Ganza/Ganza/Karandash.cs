using System.Drawing;

namespace Ganza
{
    class Karandash:Shape
    {
        public Point Begin { get; set; }
        public Point End { get; set; }

        public Karandash()
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
            graphics.DrawLine(_Pen, Begin.X, Begin.Y, End.X, End.Y);
        }
    }
}
