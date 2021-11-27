using System;
using ПауэллаСимплекс;

//http://optimizaciya-sapr.narod.ru/bez_mnogomer/grad.html
namespace Спуск
{
    class ГрадиентныйСпуск
    {
        public ГрадиентныйСпуск(char selector)
        {
            Selector = selector;
            Poisk();
        }
        
        private static char Selector { get; set; }
        private const double _epsilon = 0.01;
        private const double _h = 1.0;

        private void Poisk()
        {
            //[0] - А0 начальная точка
            Point A0 = new Point(2.0,4.0);
            //[1] - Найти производные точки А0
            double dx1_A0 = Program.Sistema_X(A0, Selector);
            double dx2_A0 = Program.Sistema_Y(A0, Selector);
            //[2] - построить следующую точку
            double x1_A1 = A0.X - _h * (dx1_A0);
            double x2_A1 = A0.Y - _h * (dx2_A0);
            Point A1 = new Point(x1_A1, x2_A1);
            int i = 0;
            while (!Exit(A1))
            {
                Console.WriteLine("Итерация {0}", i);
                i++;
                dx1_A0 = Program.Sistema_X(A1, Selector);
                dx2_A0 = Program.Sistema_Y(A1, Selector);
                //[2] - построить следующую точку
                x1_A1 = A1.X - _h * (dx1_A0);
                x2_A1 = A1.Y - _h * (dx2_A0);
                A1 = new Point(x1_A1, x2_A1);
                Console.WriteLine("A[{0:0.####};{1:0.####}]", A1.X, A1.Y);
            }
        }

        /// <summary>
        /// Условие выхода
        /// </summary>
        private bool Exit(Point An)
        {
            if(Math.Abs(Program.Sistema_X(An, Selector))+Math.Abs(Program.Sistema_Y(An, Selector)) < _epsilon)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Выход при A[{0:0.###};{1:0.###}]",An.X,An.Y);
                Console.BackgroundColor = ConsoleColor.Black;
                return true;
            }
            return false;
        }

    }
}
