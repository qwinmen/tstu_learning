using System.Drawing;

namespace Ganza
{
    class Elipsise : Shape
    {
        public Point Begin { get; set; }
        public Point End { get; set; }
        
        public Elipsise()
        {
            Begin = End = new Point();
            if (_Pen == null)
                _Pen = new Pen(Color.Black);
            
        }

        public override void Draw(System.Drawing.Graphics graphics)
        {
            if (State) graphics.FillEllipse(new SolidBrush(_Pen.Color), Begin.X, Begin.Y, End.X - Begin.X, End.Y - Begin.Y);
            graphics.DrawEllipse(_Pen, Begin.X, Begin.Y, End.X - Begin.X, End.Y - Begin.Y);
        }
    }
}
