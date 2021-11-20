using System.Drawing;

namespace Ganza
{
    class PolyGon:Shape
    {
        public Point Begin { get; set; }
        public Point End { get; set; }

        public PolyGon()
        {
            Begin = new Point();
            End = new Point();
            if (_Pen==null)
            {
                _Pen = new Pen(Color.Black);
            }
        }
        /* ПКМ - бросаем начальную точку
         * ЛКМ - конечная точка линии
         */
        public override void Draw(System.Drawing.Graphics graphics)
        {
            graphics.DrawLine(_Pen, Begin, End);
        }
    }
}
