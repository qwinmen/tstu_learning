using System;

namespace расчет
{
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

        public static Point operator -(Point x1, Point x2)
        {
            return new Point(x1.X - x2.X, x1.Y - x2.Y);
        }

        public static Point operator *(Point x1, Point x2)
        {
            return new Point(x1.X*x2.X, x1.Y*x2.Y);
        }

        public static ConsoleColor operator *(Point x1, ConsoleColor x2)
        {
            
            
            return //x1.X*
        }

        public static Point operator /(Point x1, double x2)
        {
            return new Point(x1.X / x2, x1.Y / x2);
        }

        public static Point operator /(Point x1, Point x2)
        {
            return new Point(x1.X / x2.X, x1.Y / x2.Y);
        }

        public static Point Abs(Point A)
        {
            //перегнать число А в положительное_А
            if(A.X >= 0 && A.Y >= 0 )
                return new Point(A);

            if (A.X < 0) A.X = Math.Abs(A.X);
            if (A.Y < 0) A.Y = Math.Abs(A.Y);

            return A;
        }

    }

}

