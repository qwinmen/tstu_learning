using System;
using ДихЗолотФибон;

namespace ПауэллаСимплекс
{
    class clPauell
    {
        /// <summary>
        /// По какой функции считать: select = 'f' or 'r'
        /// </summary>
        public clPauell(char select)
        {
            ЧислаФибоначчи.Selector = select;
            Poisk();
        }
        //задать точность определения минимума
        private const double Epsilon = 0.01;

        //[0] - задать область ограничений:
        private enum AB
        {
            AX1 = -1,
            AX2 = -2,//2
            BX1 = 10,
            BX2 = 10
        }
        
        private Point[] _arrK = new Point[500];

        private void Poisk()
        {
            bool stop;//флаг на остановку goto
            int index = 0;

            //[1] - задать точку начального приближения:
            _arrK[index] = new Point(5, 1);//2;2
            
            ЧислаФибоначчи.K = _arrK[index].ToString();
step2:
            index++;//1//
            //[2] - Зафиксировать К0.у и найти min функции при F[АВ.AX1..AB.BX1; К0.x2]
            //получить точку K1 [X1min; K0.x2]
            _arrK[index] = new Point(min(true, _arrK[index - 1].Y), _arrK[index - 1].Y);
            
            ЧислаФибоначчи.K = _arrK[index].ToString();
            index++;//2//
            //[3] - Зафиксировать К1.x1 и найти min функции при F[К1.x1; АВ.AX2..AB.BX2]
            _arrK[index] = new Point(_arrK[index - 1].X, min(false, _arrK[index - 1].X));
            
            //[4] - Рассчитать шаг hx1=|K2x1-K0x1| и hx2=|K2x2-K0x2|
            double hx1 = (_arrK[index].X - _arrK[index - 2].X);//деление шага только при метаниях!!!
            double hx2 = (_arrK[index].Y - _arrK[index - 2].Y);
            
            index++;//3//
            //[5] - Построить следующую точку К3[K2.x1+hx1; K2.x2+hx2]
            _arrK[index] = new Point(_arrK[index-1].X + hx1, _arrK[index-1].Y + hx2);

            //сравнить Kn и Kn-1
            while (Program.F(_arrK[index], ЧислаФибоначчи.Selector) < Program.F(_arrK[index - 1], ЧислаФибоначчи.Selector))
            {//делать большой шаг пока F(n)<F(n-1)
                index= index+1;
                _arrK[index] = new Point(_arrK[index-1].X + hx1, _arrK[index-1].Y + hx2);
            }

            //[stop] - Выход при |f1-f2|<epsilon
            stop = Exit(index);

            //[return] - если не произошел Выход, ТО откат на предыдущую точку:
            if(stop) _arrK[index] = _arrK[index - 1];

if(stop) goto step2;

#region
//[2] - Зафиксировать Кn.у и найти min функции при F[АВ.AX1..AB.BX1; Кn.x2]
            //получить точку Kn+1 [X1min; Kn.x2]
            ЧислаФибоначчи.K = _arrK[index-1].ToString();
            _arrK[index] = new Point(min(true, _arrK[index - 1].Y), _arrK[index - 1].Y);

            //[3] - Зафиксировать К4.x1 и найти min функции при F[К4.x1; АВ.AX2..AB.BX2]
            ЧислаФибоначчи.K = _arrK[index].ToString();
            index++;//5//
            _arrK[index] = new Point(_arrK[index - 1].X, min(false, _arrK[index - 1].X));

            //[4] - Рассчитать шаг hx1=|K5x1-K3x1| и hx2=|K5x2-K3x2|
            hx1 = Math.Abs(_arrK[index].X - _arrK[index-2].X);
            hx2 = Math.Abs(_arrK[index].Y - _arrK[index-2].Y);

            //[stop]
            if (!Exit(index))
            {
                Console.WriteLine("ВЫХОД");
                Console.WriteLine("ВЫХОД");
                Console.WriteLine("ВЫХОД");
            }

            //[5] - Построить следующую точку К3[K2.x1+hx1; K2.x2+hx2]
            _arrK[index] = new Point(_arrK[index-1].X + hx1, _arrK[index-1].Y + hx2);
#endregion
        }

        /// <summary>
        /// Найти минимум на отрезке [A..B] при фиксированой по X2(при gorizont=true) точке X_fiks
        /// </summary>
        private double min(bool gorizont, double X_fiks)
        {
            if(gorizont)
            {//ЧислаФибоначчи.Фибоначи((double) AB.AX1, (double) AB.BX1, epsilon, _arrK[index-1].Y)
                return ЧислаФибоначчи.Фибоначи((double) AB.AX1, (double) AB.BX1, Epsilon, X_fiks, true);
            }
            return ЧислаФибоначчи.Фибоначи((double)AB.AX2, (double)AB.BX2, Epsilon, X_fiks, false);
        }

        /// <summary>
        /// [stop] - Выход при |f1-f2| меньше Epsilon
        /// </summary>
        private bool Exit(int index)
        {
            if (Math.Abs(Program.F(_arrK[index], ЧислаФибоначчи.Selector) -
                Program.F(_arrK[index - 1], ЧислаФибоначчи.Selector)) < Epsilon)
            {
                Console.WriteLine("ВЫХОД");
                Console.WriteLine("ВЫХОД");
                Console.WriteLine("ВЫХОД");
                 return false;
            }
            return true;
        }
    }

    /// <summary>
    /// Класс Точки для хранения [X;Y]
    /// </summary>
    class Point
    {
        private static int index = 0;
        private double _x, _y;
        /// <summary>
        /// [x.X1; X2.y]
        /// </summary>
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
            //Console.WriteLine("new Point[X1={0:0.####}; X2={1:0.####}]", x, y);
            index++;
        }
        /// <summary>
        /// [Point]
        /// </summary>
        public Point(Point A)
        {
            _x = A.X;
            _y = A.Y;
            //Console.WriteLine("new Point[X1={0:0.####}; X2={1:0.####}]", x, y);
            index++;
        }

        public double X { get { return _x; } set { _x = value; } }
        public double Y { get { return _y; } set { _y = value; } }

        public override string ToString()
        {
            return index.ToString();
        }

        public static Point operator + (Point x1, Point x2)
        {
            return new Point(x1.X + x2.X, x1.Y + x2.Y);
        }

        public static Point operator /(Point x1, double x2)
        {
            return new Point(x1.X / x2, x1.Y / x2);
        }

    }


}
