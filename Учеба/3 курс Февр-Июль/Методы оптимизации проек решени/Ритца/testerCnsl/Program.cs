using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testerCnsl
{
    class Program
    {
        static void Main(string[] args)
        {
            //Resenie();
            Poisk();
            Console.ReadLine();
        }

        internal static void Poisk()
        {
            var _h = 1.0;

            //[0] - А0 начальная точка
            Point A0 = new Point(1.0, 1.0);
            //вычислим интеграл по Симпсон
            List<double> Integral = new List<double>();
            Integral.Add(clSimpson.Simpson(A0.X, A0.Y));
            int index = 0;

            A0.X += 0.1;
            Integral.Add(clSimpson.Simpson(A0.X, A0.Y));
            A0.Y += 0.1;
            Integral.Add(clSimpson.Simpson(A0.X, A0.Y));

            //[1] - Найти производные точки А0
            double dx1_A0 = Sistema_X(A0, Integral, index);
            double dx2_A0 = Sistema_Y(A0, Integral, index);
            //[2] - построить следующую точку
            double x1_A1 = A0.X + _h * (dx1_A0);
            Integral.Add(clSimpson.Simpson(x1_A1, A0.Y));

            index++;

            double x2_A1 = A0.Y + _h * (dx2_A0);
            Integral.Add(clSimpson.Simpson(A0.X, x2_A1));

            Point A1 = new Point(x1_A1, x2_A1);
            Integral.Add(clSimpson.Simpson(A1.X, A1.Y));
            //index += 3;

            int i = 0;
            while (!Exit(A1, Integral, index))
            {
                i++;
                dx1_A0 = Sistema_X(A1, Integral, index);
                dx2_A0 = Sistema_Y(A1, Integral, index);

                //[2] - построить следующую точку
                x1_A1 = A1.X + _h * (dx1_A0);//0.78//0.46//0.68//0.53
                Integral.Add(clSimpson.Simpson(x1_A1, A1.Y));

                x2_A1 = A1.Y + _h * (dx2_A0);//2.0//14.0//41.0//122.0
                Integral.Add(clSimpson.Simpson(A1.X, x2_A1));

                A1 = new Point(x1_A1, x2_A1);
                Integral.Add(clSimpson.Simpson(A1.X, A1.Y));
                index+=3;//index += 3;
            }
        }

        private static bool Exit(Point An, List<double > Integral, int index)
        {
            if (Math.Abs(Integral[index-1] - Integral[index+2]) <= 0.01)
            {
                Console.WriteLine("Выход при A[{0:0.###};{1:0.###}]", An.X, An.Y);
                return true;
            }
            return false;

            if (Math.Abs(Sistema_X(An, Integral, index)) + Math.Abs(Sistema_Y(An, Integral, index)) <= 0.01)
            {
                Console.WriteLine("Выход при A[{0:0.###};{1:0.###}]", An.X, An.Y);
                return true;
            }
            return false;
        }

        private static double Sistema_X(Point An, List<double> Integral, int index)
        {
            return (Integral[index] - Integral[index+1])/0.1;
        }

        private static double Sistema_Y(Point An, List<double> Integral, int index)
        {
            return (Integral[index] - Integral[index+2]) / 0.1;
        }

        clSimpson _clSimpson = new clSimpson();

        private static void Resenie()
        {
            var delta = 0.1;
            var h = 1.0;
            var epsilon = 0.01;

            //задали a1, a2
            var a1 = 1.0;
            var a2 = 1.0;

            //вычислим интеграл по Симпсон
            List<double> Integral = new List<double>();
            Integral.Add(clSimpson.Simpson(a1, a2));

            //делаем прирощение по a1 при том же a2
            var tmp1 = a1 + delta;

            //вычислим интеграл по Симпсон
            Integral.Add(clSimpson.Simpson(tmp1, a2));

            //найдем градиент по a1
            var gradA1 = (Integral[0] - Integral[1])/delta;

            //делаем прирощение по a2 при том же a1
            var tmp2 = a2 + delta;

            //вычислим интеграл по Симпсон
            Integral.Add(clSimpson.Simpson(a1, tmp2));

            //найдем градиент по a2
            var gradA2 = (Integral[0] - Integral[2]) / delta;

            var a11 = a1 - gradA1*h;
            var a21 = a2 - gradA2*h;

            //вычислим интеграл по Симпсон
            Integral.Add(clSimpson.Simpson(a11, a21));

            //сравниваем разность последний вычесленный интеграл - самым первым
            if(Math.Abs(Integral[0]-Integral[3]) < epsilon)
            {
                Console.WriteLine("Выход из проги");
            }


        }

        #region Производные X' и Y' по t

        /// <summary>
        /// Производная по t от -t+1+(a1)*(t-1)*(t+1)*sin(t)
        /// </summary>
        public static double ПроизводнаяПоИкс(double a1, double t)
        {//a1*(t^2-1)*cos(t)+2*a1*t*sin(t)-1
            return a1 * (t * t - 1.0) * Math.Cos(t) + 2.0 * a1 * t * Math.Sin(t) - 1.0;
        }

        /// <summary>
        /// Производная по t от t+(a2)*(t-1)*(t+1)*t^2
        /// </summary>
        public static double ПроизводнаяПоИгрек(double a2, double t)
        {//a2*(4*t^3-2*t)+1
            return a2 * (4.0 * (t * t * t) - 2.0 * t) + 1.0;
        }

        #endregion

        #region Система X и Y

        public static double X(double a1, double t)
        {
            return (-t + 1.0 + (a1) * (t - 1.0) * (t + 1.0) * Math.Sin(t));
        }

        public static double Y(double a2, double t)
        {
            return (t + (a2) * (t - 1.0) * (t + 1.0) * (t * t));
        }

        #endregion



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
