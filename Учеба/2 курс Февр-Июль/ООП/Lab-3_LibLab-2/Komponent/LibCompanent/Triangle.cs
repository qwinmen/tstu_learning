using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ganza
{
    class Triangle:Shape
    {
        public List<GraphicsPath> Triangles { get; set; }

        public Triangle()
        {
            Triangles=new List<GraphicsPath>();
            
            if (_Pen==null)
            {
                _Pen = new Pen(Color.Black);
            }
        }
        
        public override void Draw(Graphics graphics)
        {//Рисуем треугольники из списка;
               foreach (GraphicsPath gp in Triangles)
                {
                    if (State) graphics.FillPath(new SolidBrush(_Pen.Color), gp);
                    graphics.DrawPath(_Pen, gp);
                }
        }
    }
}
