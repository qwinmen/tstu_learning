using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Градиентный
{
    class ГрадиентныйСпуск
    {

        public ГрадиентныйСпуск(char selector)
        {
            Selector = selector;
            Poisk();
        }

        private static char Selector { get; set; }
        private const double _epsilon = 0.01;
        private const double _h = 1.0;

        private void Poisk()
        {
            //[0] - А0 начальная точка
            Point A0 = new Point(4.0, 5.0);
            //[1] - Найти производные точки А0
            double dx1_A0 = Program.Sistema_X(A0, Selector);
            double dx2_A0 = Program.Sistema_Y(A0, Selector);
            //[2] - построить следующую точку
            double x1_A1 = A0.X - _h * (dx1_A0);
            double x2_A1 = A0.Y - _h * (dx2_A0);
            Point A1 = new Point(x1_A1, x2_A1);
            int i = 0;
            while (!Exit(A1))
            {
                Console.WriteLine("Итерация {0}", i);
                i++;
                dx1_A0 = Program.Sistema_X(A1, Selector);
                dx2_A0 = Program.Sistema_Y(A1, Selector);
                //[2] - построить следующую точку
                x1_A1 = A1.X - _h * (dx1_A0);
                x2_A1 = A1.Y - _h * (dx2_A0);
                A1 = new Point(x1_A1, x2_A1);
                Console.WriteLine("A[{0:0.####};{1:0.####}]", A1.X, A1.Y);
            }
        }

        /// <summary>
        /// Условие выхода
        /// </summary>
        private bool Exit(Point An)
        {
            if (Math.Abs(Program.Sistema_X(An, Selector)) + Math.Abs(Program.Sistema_Y(An, Selector)) < _epsilon)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Выход при A[{0:0.###};{1:0.###}]", An.X, An.Y);
                Console.BackgroundColor = ConsoleColor.Black;
                return true;
            }
            return false;
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
