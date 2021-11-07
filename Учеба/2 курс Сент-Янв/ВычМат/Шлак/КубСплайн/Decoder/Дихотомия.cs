using System;
//http://optimizaciya-sapr.narod.ru/bez_odnomer/zol_sech.html
namespace Decoder
{
    class Дихотомия
    {
        static double f(double x)
        {
            return (Math.Pow(x,4.0)-6.0*Math.Pow(x,2.0)+10.0);
        }
        public static void halfDivision(double a, double b, double epsilon)
        {
            int i = 0;
            double c;
            Console.WriteLine("***Метод половинного деления***\nПромежуточные значения");
            while (b - a > epsilon)
            {
                i++;
                c = (a + b) / 2.0;
                Console.WriteLine(c);
                if (f(b) * f(c) < 0)
                    a = c;
                else
                    b = c;
            }
            Console.WriteLine("Количество итераций {0}", i);
            Console.WriteLine("Приближенное значение корня {0}", (a + b) / 2.0);
        }
    }
}
