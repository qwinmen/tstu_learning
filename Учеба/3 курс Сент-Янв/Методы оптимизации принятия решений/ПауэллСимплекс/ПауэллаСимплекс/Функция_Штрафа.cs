using System;
using Спуск;

//http://dit.isuct.ru/ivt/sitanov/Literatura/M171/Pages/Glava3_2.htm
namespace ПауэллаСимплекс
{
    class Функция_Штрафа
    {
        private char _select;
        private const double _epsilon = 0.01;

        public Функция_Штрафа(char select)
        {
            _select = select;
            Poisk();
        }

        private void Poisk()
        {
            double k = 1.0;
            Point A0 = new Point(0.0, -5.0);

            ГрадиентныйСпуск grad = new ГрадиентныйСпуск(A0, k);
        }

        /// <summary>
        /// Функция ограничитель
        /// </summary>
        private static double FLimit(double x1, double x2)
        {
            var tmp = x2 * x2 * x2 - x1;//*x1 + 3*x2*x2 - x1 + 1.0;
            //if (x2 <= 0.0 && tmp <= 0.0)
                return tmp;
            
           //throw new Exception("Число x2 или tmp меньше ноля");
        }

        private static double FLimit(Point A)
        {
            var tmp = (A.Y * A.Y * A.Y) - (A.X);// * A.X) + 3.0 * A.Y * A.Y - A.X + 1.0;
            //if (A.Y <= 0.0 && tmp <= 0.0)
                return tmp;

            //throw new Exception("Число x2 или tmp меньше ноля");
        }

        private static double FLimit1(double X)
        {
            return X;
        }

        private static double FLimit1(Point X)
        {
            return X.X;
        }

        public static double R(Point A0, double k)
        {
            /*var fun = Program.F(A0, 'h');
            Console.WriteLine("Program.F={0:0.###} - ", fun);
            var fun1 = (1/k)*(Math.Log(-FLimit(A0)) + Math.Log(-FLimit(A0)));
            Console.WriteLine("- fun1={0:0.###} + ", fun1);
            var fun2 = k*(FLimit1(A0)*FLimit1(A0));
            Console.WriteLine("+ fun2={0:0.###}", fun2);*/

            //return (Program.F(A0, 'h') + k / (FLimit(A0))););
            return (Program.F(A0, 'h') - (1/k)*(Math.Log10(-FLimit(A0)) + Math.Log10(-FLimit(A0))) +
                    k*(FLimit1(A0)*FLimit1(A0)));
        }
        public static double R(double X, double Y, double k)
        {
            //return (Program.F(X,Y, 'h') + k / (FLimit(X,Y)));
            return (Program.F(X, Y, 'h') - (1/k)*(Math.Log10(-FLimit(X, Y)) + Math.Log10(-FLimit(X, Y))) +
                    k*(FLimit1(X)*FLimit1(X)));
        }
    }

    class ГрадиентныйСпуск
    {
        public ГрадиентныйСпуск(Point A0, double k)
        {
            //Selector = selector;
            _k = k;
            double tmp = Функция_Штрафа.R(A0, _k);
            Poisk(A0);
        }

        public double _k = 1.0;
        
        public double Sistema_X(Point A)
        {
            return (Функция_Штрафа.R(A.X + 0.001, A.Y, _k) - Функция_Штрафа.R(A, _k)) / 0.001;
            //return (F(A.X + 0.001, A.Y, selector) - F(A, selector)) / 0.001;
        }
        public double Sistema_Y(Point A)
        {
            return (Функция_Штрафа.R(A.X, A.Y + 0.001, _k) - Функция_Штрафа.R(A, _k)) / 0.001;
            //return (F(A.X, A.Y + 0.001, selector) - F(A, selector)) / 0.001;
        }

        private static char Selector { get; set; }
        private const double _epsilon = 0.1;
        private const double _h = 0.1;

        private void Poisk(Point A0)
        {
            //[0] - А0 начальная точка
            //Point A0 = new Point(2.0, 4.0);
            //[1] - Найти производные точки А0
            double dx1_A0 = Sistema_X(A0);
            double dx2_A0 = Sistema_Y(A0);
            //[2] - построить следующую точку
            double x1_A1 = A0.X - _h * (dx1_A0);
            double x2_A1 = A0.Y - _h * (dx2_A0);
            Point A1 = new Point(x1_A1, x2_A1);
            int i = 0;
            while (!Exit(A1))
            {
                Console.WriteLine("Итерация {0}", i);
                i++;
                dx1_A0 = Sistema_X(A1);
                dx2_A0 = Sistema_Y(A1);
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
            if (Math.Abs(Sistema_X(An)) + Math.Abs(Sistema_Y(An)) < _epsilon)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Выход при A[{0:0.###};{1:0.###}]", An.X, An.Y);
                Console.BackgroundColor = ConsoleColor.Black;
                return true;
            }
            return false;
        }

    }
}
