using System;

namespace ДихЗолотФибон
{
    class Program
    {
        static void Main(string[] args)
        {
            Дихотомия.HalfDivision(4, 10, 0.01);//[4;10]
            Console.WriteLine("====================================");
            ЗолотоеСечение.GoldMain(4, 10, 0.01);
            Console.WriteLine("====================================");
            ЧислаФибоначчи.Фибоначи(4, 10, 0.01);
            Console.ReadKey();
        }

        public static double F(double x)
        {
            //return Math.Pow(x, 3) + 10.5 * Math.Pow(x, 2) + 30 * x + 13;//корень -2 [-4.5; 4]
            return Math.Pow(x, 3) - 12 * Math.Pow(x, 2) + 45 * x + 10;//корень 5 [4; 10]
        }

        public static void SetColor(int k)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Итерация {0}", k);
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}
