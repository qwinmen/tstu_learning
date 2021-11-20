using System.Drawing;

namespace Ganza
{
    public abstract class Shape
    {//отрисовка
        public abstract void Draw(Graphics graphics);
        public Pen _Pen { get; set; }
        public bool State { get; set; }//заливка контроль
    }
}
