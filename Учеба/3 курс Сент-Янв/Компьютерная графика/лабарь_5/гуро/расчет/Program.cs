using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace расчет
{
    class Program
    {
        static void Main(string[] args)
        {
            //искомая точка
            Point u = new Point(258, 152);
            //фигура триугольник
            Point v1 = new Point(253, 133);
            Point v4 = new Point(304, 370);
            Point v2 = new Point(584, 191);
            //цвета в вершинах
            ConsoleColor colorV1 = ConsoleColor.Red;
            ConsoleColor colorV4 = ConsoleColor.Blue;
            ConsoleColor colorV2 = ConsoleColor.Green;

            Point tmpU = U(v4, v1, u);
            Console.WriteLine("u = [{0};{1}]", tmpU.X, tmpU.Y);

            Console.ReadKey();
        }

        /// <summary>
        /// Коэффициент искомой точки
        /// </summary>
        /// <returns></returns>
        private static Point U(Point v4, Point v1, Point u)
        {
            //U = |v4*u|/|v4*v1|
            //U = |v4-u|/|v4-v1| длина чтоли?
            return (Point.Abs(v4-u)/Point.Abs(v4-v1));
            //в интервале от 0 до 1
        }

        /// <summary>
        /// Интенсивность свечения искомой точки
        /// </summary>
        /// <returns></returns>
        private static ConsoleColor Iu(Point u, ConsoleColor Iv4, ConsoleColor Iv1)
        {
            //Iu = (1-u)*Iv4 + u*Iv1
            Point odin = new Point(1.0, 1.0);
            Point tmp = (odin - u);



        }




    }
}
