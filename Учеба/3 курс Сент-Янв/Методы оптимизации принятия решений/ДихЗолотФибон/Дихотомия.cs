using System;

namespace ДихЗолотФибон
{
    class Дихотомия
    {
        public static void HalfDivision(double a, double b, double epsilon)
        {
            int i = 0;
            double y, z;
            Console.WriteLine("***Метод половинного деления***\nПромежуточные значения");
            while (b - a > epsilon)
            {
                Program.SetColor(i++);
                //i++;
                y = a + 0.25 * (b - a);
                z = b - 0.25 * (b - a);
                Console.WriteLine("y{2}={0:#.##}\t z{2}={1:#.##}", y, z, i);
                if (Program.F(y) < Program.F(z))
                    b = z;
                else
                    a = y;
            }
            Console.WriteLine("Количество итераций {0}", i);
            Console.WriteLine("Приближенное значение корня {0}", (a + b) / 2.0);
        }

    }
}
