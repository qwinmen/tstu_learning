using System;
using System.Windows.Forms;


//http://optimizaciya-sapr.narod.ru/bez_mnogomer/grad.html
namespace Nuts
{
    /// <summary>
    /// Градиентный спуск
    /// </summary>
    class clGradient
    {
        public clGradient(TextBox txt)
        {
            _txt = txt;
        }

        private void _AddText(string str)
        {
            _txt.Text += str + "\r\n";
        }

        TextBox _txt;

        private const double _epsilon = 0.1;
        private const double _h = 1.0;
        private double _t;

        /// <summary>
        /// Метод
        /// </summary>
        /// <param name="A0">А0 начальная точка = [a1;a2]</param>
        internal void Poisk(Point A0, double t)
        {
            _t = t;
            
            //[0] - А0 начальная точка
            //Point A0 = new Point(2.0, 4.0);
            //[1] - Найти производные точки А0
            double dx1_A0 = Sistema_X(A0);
            double dx2_A0 = Sistema_Y(A0);
            //[2] - построить следующую точку
            double x1_A1 = A0.X - _h * (dx1_A0);
            double x2_A1 = A0.Y - _h * (dx2_A0);
            Point A1 = new Point(x1_A1, x2_A1);
            int i = 0;
            while (!Exit(A1))
            {
                _iteracii = i;
                i++;
                dx1_A0 = Sistema_X(A1);
                dx2_A0 = Sistema_Y(A1);
                //[2] - построить следующую точку
                x1_A1 = A1.X + _h * (dx1_A0);//0.78//0.46//0.68//0.53
                x2_A1 = A1.Y - _h * (dx2_A0);//2.0//14.0//41.0//122.0
                A1 = new Point(x1_A1, x2_A1);
                //_AddText(String.Format("A[{0:0.####};{1:0.####}]", A1.X, A1.Y));
            }
        }

        private int _iteracii = 0;

        /// <summary>
        /// Условие выхода
        /// </summary>
        private bool Exit(Point An)
        {
            if (Math.Abs(Sistema_X(An)) + Math.Abs(Sistema_Y(An)) <= _epsilon)
            {
                _AddText("Градиент");
                _AddText("Итерация " + _iteracii + " t=" + _t);
                _AddText(String.Format("Выход при A[{0:0.###};{1:0.###}]", An.X, An.Y));
                return true;
            }
            return false;
        }

        /*
        #region Производные

        /// <summary>
        /// -t+1+(a)*(t-1)*(t+1)*sin(t)
        /// </summary>
        private double Sistema_X(double a1, double t)
        {
            return (a1 * (2.0 * t * Math.Sin(t) + ((t * t) - 1.0) * Math.Cos(t)) - 1.0);
        }

        /// <summary>
        /// t+(a)*(t-1)*(t+1)*t^2
        /// </summary>
        private double Sistema_Y(double a2, double t)
        {
            return (4.0 * a2 * (t * t * t) - 2.0 * a2 * t + 1.0);
        }

        #endregion
        */

        public double Sistema_X(Point A)
        {
            return (F(A.X + 0.01, A.Y) - F(A)) / 0.01;
        }

        public double Sistema_Y(Point A)
        {
            return (F(A.X, A.Y + 0.01) - F(A)) / 0.01;
        }

        public double F(double a1, double a2)
        {
            double x = -_t + 1.0 + a1 * (_t - 1.0) * (_t + 1.0) * Math.Sin(_t);//

            //(a1 * (2.0 * _t * Math.Sin(_t) + ((_t * _t) - 1.0) * Math.Cos(_t)) - 1.0);
            double xPrz = 2.0 * a1 * _t * Math.Sin(_t) + (a1 * (_t * _t) - a1) * Math.Cos(_t) - 1.0;
            //(4.0 * a2 * (_t * _t * _t) - 2.0 * a2 * _t + 1.0);
            double yPrz = a2 * (4.0 * (_t * _t * _t) - 2.0 * _t) + 1.0;

            return (2.0 * _t * x - (xPrz * xPrz) + (yPrz * yPrz * yPrz) / 3.0);
        }

        public double F(Point K)
        {
            double x = -_t + 1.0 + K.X * (_t - 1.0) * (_t + 1.0) * Math.Sin(_t);

            //(K.X * (2.0 * _t * Math.Sin(_t) + ((_t * _t) - 1.0) * Math.Cos(_t)) - 1.0);
            double xPrz = 2.0 * K.X * _t * Math.Sin(_t) + (K.X * (_t * _t) - K.X) * Math.Cos(_t) - 1.0;
            //(4.0 * K.Y * (_t * _t * _t) - 2.0 * K.Y * _t + 1.0);
            double yPrz = K.Y * (4.0 * (_t * _t * _t) - 2.0 * _t) + 1.0;

            return (2.0 * _t * x - (xPrz * xPrz) + (yPrz * yPrz * yPrz) / 3.0);
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

        public static Point operator +(Point x1, Point x2)
        {
            return new Point(x1.X + x2.X, x1.Y + x2.Y);
        }

        public static Point operator /(Point x1, double x2)
        {
            return new Point(x1.X / x2, x1.Y / x2);
        }

    }



}
