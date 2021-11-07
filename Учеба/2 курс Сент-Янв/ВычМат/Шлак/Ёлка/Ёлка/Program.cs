using System;

namespace Ёлка
{
    class Program
    {
        static void Main()
        {
            bool exit = false;
            while (!exit)
            {Lagranj();} 
        }
        #region Лагранж из задания на сумму
        static void Lagranj()
        {
            double[] X = { 1, 2, 3, 4, 5, 6, 7, 8 };
            double[] Y = { -6.80, -9.20, -11.20, -12.80, -14.00, -15.30, -17.10, -19.20 };
            Console.WriteLine("Введите X");
            double x = Convert.ToDouble(Console.ReadLine());
            if (x > 4)
                Console.WriteLine("L="+xUp4(x, X, Y));
            else
                Console.WriteLine("L="+xDn4(x, X, Y));
            Console.WriteLine("Выполнила________Солдатова В.Р.");
            Console.WriteLine("Проверил ________Дубровин В.В.");
            Console.ReadLine();
        }
        static double xUp4(double x,double[] X, double[] Y)
        {//x>4
            double l4, l5, l6, l7;
            l4 = ((x - X[5]) * (x - X[6] * (x - X[7])) / ((X[4] - X[5]) * (X[4] - X[6]) * (X[4] - X[7])));
            l5 = ((x - X[4]) * (x - X[6] * (x - X[7])) / ((X[5] - X[4]) * (X[5] - X[6]) * (X[5] - X[7])));
            l6 = ((x - X[4]) * (x - X[5] * (x - X[7])) / ((X[6] - X[4]) * (X[6] - X[5]) * (X[6] - X[7])));
            l7 = ((x - X[4]) * (x - X[5] * (x - X[6])) / ((X[7] - X[4]) * (X[7] - X[5]) * (X[7] - X[6])));
            return l4*Y[4] + l5*Y[5] + l6*Y[6] + l7*Y[7];
        }
        static double xDn4(double x,double[] X, double[] Y)
        {//x<4
            double l0, l1, l2, l3;
            l0 = ((x - X[1]) * (x - X[2] * (x - X[3])) / ((X[0] - X[1]) * (X[0] - X[2]) * (X[0] - X[3])));
            l1 = ((x - X[0]) * (x - X[2] * (x - X[3])) / ((X[1] - X[0]) * (X[1] - X[2]) * (X[1] - X[3])));
            l2 = ((x - X[0]) * (x - X[1] * (x - X[3])) / ((X[2] - X[0]) * (X[2] - X[1]) * (X[2] - X[3])));
            l3 = ((x - X[0]) * (x - X[1] * (x - X[2])) / ((X[3] - X[0]) * (X[3] - X[1]) * (X[3] - X[2])));
            return l0*Y[0] + l1*Y[1] + l2*Y[2] + l3*Y[3];
        }
        #endregion

    }
}