using System;

namespace Градиентный
{
    class Program
    {
        static void Main(string[] args)
        {
            double a1 = 1, a2 = 1;
            var t = -0.5;//[-1...+1]
            
            Градиент(a1,a2, t);
            Console.WriteLine("------------------------");
            ГрадиентныйСпуск gr = new ГрадиентныйСпуск('0');
            
            Console.ReadLine();
        }

        private static double _t;
        private static double da1 = 0.01, da2 = 0.01;

        /// <summara2>
        /// Найти градиент
        /// </summara2>
        /// <param name="a1">a1</param>
        /// <param name="a2">a2</param>
        /// <param name="t">[-1...+1]</param>
        private static void Градиент(double a1, double a2, double t)
        {
            _t = t;
            
            double h1 = 1.0, h2 = 1.0;

            while (Math.Abs(da1F(a1, a2, da1) - da1F(a1, a2, da1 / 2.0)) > 0.01)
            {
                da1 = da1 / 2.0;

            }
            while (Math.Abs(da2F(a1, a2, da2) - da2F(a1, a2, da2 / 2.0)) > 0.01)
            {
                da2 = da2 / 2.0;
            }

            int n = 0;
            while ((Math.Abs(da1F(a1, a2, da1)) + Math.Abs(da2F(a1, a2, da2))) > 0.01)
            {
                a1 = a1 - h1 * da1F(a1, a2, da1);
                a2 = a2 - h2 * da2F(a1, a2, da2);
                n++;

                double pow = Math.Pow(da1F(a1, a2, da1), 2);
                double pow2 = Math.Pow(da2F(a1, a2, da2), 2);
                Console.WriteLine("{0}   ", (pow + pow2));
                Console.WriteLine("\n\n minF({0},{1}) = {2}\n", a1, a2, F(a1, a2));
            }
            Console.WriteLine("\n\n minF({0},{1}) = {2}\n", a1, a2, F(a1, a2));
            Console.WriteLine("\nИтерации {0}", n);
        }

        /// <summara2>
        /// Интеграл
        /// </summara2>
        /// <param name="a1">a1</param>
        /// <param name="a2">a2</param>
        /// <returns></returns>
        private static double F(double a1, double a2)
        {
            double x = -_t + 1.0 + a1 * (_t - 1.0) * (_t + 1.0) * Math.Sin(_t);//
            
            double xPrz = (a1 * (2.0 * _t * Math.Sin(_t) + ((_t * _t) - 1.0) * Math.Cos(_t)) - 1.0);
            double yPrz = (4.0 * a2 * (_t * _t * _t) - 2.0 * a2 * _t + 1.0);
            
            return (2.0*_t*x - (xPrz*xPrz) + (yPrz*yPrz*yPrz)/3.0);
        }

        private static double da1F(double a1, double a2, double da1)
        {
            return (F(a1 + da1, a2) - F(a1, a2)) / da1;
        }

        private static double da2F(double a1, double a2, double da2)
        {
            return (F(a1, a2 + da2) - F(a1, a2)) / da2;
        }














        public static double Sistema_X(Point A, char selector)
        {
            return (F(A.X + 0.01, A.Y, selector) - F(A, selector)) / 0.01;
        }

        public static double Sistema_Y(Point A, char selector)
        {
            return (F(A.X, A.Y + 0.01, selector) - F(A, selector)) / 0.01;
        }

        public static double F(double a1, double a2, char select)
        {
            double x = -_t + 1.0 + a1 * (_t - 1.0) * (_t + 1.0) * Math.Sin(_t);//

            double xPrz = (a1 * (2.0 * _t * Math.Sin(_t) + ((_t * _t) - 1.0) * Math.Cos(_t)) - 1.0);
            double yPrz = (4.0 * a2 * (_t * _t * _t) - 2.0 * a2 * _t + 1.0);

            return (2.0 * _t * x - (xPrz * xPrz) + (yPrz * yPrz * yPrz) / 3.0);
        }

        public static double F(Point K, char select)
        {
            double x = -_t + 1.0 + K.X * (_t - 1.0) * (_t + 1.0) * Math.Sin(_t);//

            double xPrz = (K.X * (2.0 * _t * Math.Sin(_t) + ((_t * _t) - 1.0) * Math.Cos(_t)) - 1.0);
            double yPrz = (4.0 * K.Y * (_t * _t * _t) - 2.0 * K.Y * _t + 1.0);

            return (2.0 * _t * x - (xPrz * xPrz) + (yPrz * yPrz * yPrz) / 3.0);
        }

    }
}
