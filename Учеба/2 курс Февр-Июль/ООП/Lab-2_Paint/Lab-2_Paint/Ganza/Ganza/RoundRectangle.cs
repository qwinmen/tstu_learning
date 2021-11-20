using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ganza
{
    class RoundRectangle:Shape
    {
        public Rectangle Rectangle { get; set; }

        public RoundRectangle()
        {
            Rectangle = new Rectangle();
            _Pen = new Pen(Color.Black);
        }

        private void DrawRoundRect(Graphics g, Pen p, float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Дуга
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Дуга
            gp.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Дуга
            gp.CloseFigure();
            
            if(State) g.FillPath(new SolidBrush(_Pen.Color),gp);
            g.DrawPath(p, gp);
            
            gp.Dispose();
        }

        public override void Draw(System.Drawing.Graphics graphics)
        {
            DrawRoundRect(graphics,_Pen,Rectangle.X,Rectangle.Y,Rectangle.Width,Rectangle.Height,15);
        }
    }
}
