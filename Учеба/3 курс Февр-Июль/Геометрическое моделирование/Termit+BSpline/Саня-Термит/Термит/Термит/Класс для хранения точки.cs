 

/// <summary>
    /// Класс Точки для хранения [X;Y]
    /// </summary>
    class PointD
    {
        private static int index = 0;
        private double _x, _y;
        /// <summary>
        /// [x.X1; X2.y]
        /// </summary>
        public PointD(double x, double y)
        {
            _x = x;
            _y = y;
            //Console.WriteLine("new Point[X1={0:0.####}; X2={1:0.####}]", x, y);
            index++;
        }
        /// <summary>
        /// [Point]
        /// </summary>
        public PointD(PointD A)
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

        public static PointD operator +(PointD x1, PointD x2)
        {
            return new PointD(x1.X + x2.X, x1.Y + x2.Y);
        }

        public static PointD operator /(PointD x1, double x2)
        {
            return new PointD(x1.X / x2, x1.Y / x2);
        }

    }
