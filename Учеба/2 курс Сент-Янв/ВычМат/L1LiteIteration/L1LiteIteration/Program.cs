using System;
//Lab_1
namespace L1LiteIteration
{//info http://kurs.ido.tpu.ru/courses/informat_chem_2/modul_2.htm#4.
    class Program
    {//Решить уравнение методом простых итераций
        static void Main()
        {
            double epsilon = 0.001;//Точность
            Console.Write("Метод простых итераций\n");
            simpleIter(epsilon);
        }
        static void simpleIter(double epsilon)
        {
            int i = 0;
            double x1 = 0.0, x0 = 0.5, r;
            Console.Write("Промежуточные значения:\n");
            do
            {
                i++;
                x1 = g(x0);
                r = Math.Abs(x1 - x0);//Абсолютое значение
                x0 = x1;
                Console.WriteLine(x0);
            } while (r >= epsilon);
            Console.WriteLine("\nКоличество итераций "+i);
            Console.WriteLine("Приближенное значение корня "+x1);
        }
        static double g(double x)
        {//фи от х
            return (2.0-Math.Log(x));//Вар 7
            //(1.0/(Math.Pow(x + 1, 2)));//Вар 15
            //(Math.Pow(1.0/(3.0*Math.Atan(x)), 1.0/3.0));
            //   [1/(3*arctgX)]^1/3
        }
    }
}
