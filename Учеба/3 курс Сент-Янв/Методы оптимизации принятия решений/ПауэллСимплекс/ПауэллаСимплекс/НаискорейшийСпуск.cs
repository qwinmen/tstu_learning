using System;
using ПауэллаСимплекс;

//http://optimizaciya-sapr.narod.ru/bez_mnogomer/naisk.html
//http://dit.isuct.ru/ivt/sitanov/Literatura/M171_2.html
namespace Спуск
{
    class НаискорейшийСпуск
    {
        public НаискорейшийСпуск(char selector)
        {
            Selector = selector;
            Poisk();
        }

        private char Selector{get; set;}
        private const double _epsilon = 0.01;

        private void Poisk()
        {
            Point A0 = new Point(2.0, 4.0);//(8.4, -1.3);

            double f_A0 = Program.F(A0, Selector);//f(A0)
            //[1]
            double dx1 = Program.Sistema_X(A0, Selector);//производная по Х
            double dx2 = Program.Sistema_Y(A0, Selector);//производная по У
            Console.WriteLine("A0 [{0:0.###};{1:0.###}], f(A0)={2:0.###}", A0.X, A0.Y, f_A0);
            //[2]
            Point A1; double f_A1;
            double lambda = Lambda(A0, 0.5, out A1, out f_A1);//для точки A1
            Console.WriteLine("lambda={0:0.###}, A1 [{1:0.###};{2:0.###}], f(A1)={3:0.###}", lambda, A1.X, A1.Y, f_A1);
            int i = 0; double lambda1 = 0.0;
            while (!Exit(A0, A1, _epsilon))
            {
                Console.WriteLine("Итерация {0}", i);
                //[3]
                double dx1_A1 = Program.Sistema_X(A1, Selector);//производная по Х
                double dx2_A1 = Program.Sistema_Y(A1, Selector);//производная по У
                double cos_a1 = CosAlfa(dx1, dx2, dx1_A1, dx2_A1);

                
                if (cos_a1 < 30) lambda1 = 2.0 * lambda;
                if (cos_a1 > 90) lambda1 = (1.0 / 3.0) * lambda;
                if (cos_a1 >= 30 && cos_a1 <= 90) lambda1 = lambda;

                Point A2; double f_A2;
                lambda = Lambda(A1, lambda1, out A2, out f_A2);//для точки A2
                //lambda = Lambda(A1, lambda, out A2, out f_A2);//для точки A2
                Console.WriteLine("lambda={0:0.###}, A2 [{1:0.###};{2:0.###}], f(A2)={3:0.###}", lambda, A2.X, A2.Y, f_A2);
                if (lambda < _epsilon) Console.ReadLine();
                //Console.WriteLine("f(A2)={0} < f(A1)={1}", f_A2, f_A1);
                Console.WriteLine("A1[{0:0.###};{1:0.###}]   A2[{2:0.###};{3:0.###}]", A1.X, A1.Y, A2.X, A2.Y);
                i++;
                A0 = A1;
                A1 = A2;
            }

        }

        /// <summary>
        /// true - пора выходить
        /// </summary>
        private bool Exit(Point A0, Point A1, double epsilon)
        {
//            if (Math.Sqrt(((A1.X - A0.X) * (A1.X - A0.X)) - ((A1.Y - A0.Y) * (A1.Y - A0.Y))) < epsilon)
            if (Math.Abs(Program.Sistema_X(A0, Selector)) + Math.Abs(Program.Sistema_Y(A1, Selector)) < _epsilon)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Выход при A[{0:0.###};{1:0.###}]", A1.X, A1.Y);
                Console.BackgroundColor = ConsoleColor.Black;
                return true;
            }
            return false;
        }


        /// <summary>
        /// Вернет число в градусах
        /// </summary>
        private double CosAlfa(double dx1_A0, double dx2_A0, double dx1_A1, double dx2_A1)
        {
            double cosRad = ((dx1_A1*dx1_A0) + (dx2_A1*dx2_A0))/
                            (Math.Sqrt((dx1_A1*dx1_A1) + (dx2_A1*dx2_A1))*Math.Sqrt((dx1_A0*dx1_A0) + (dx2_A0*dx2_A0)));
            //cosRad Радиан перевести в Градус
            return (Math.Acos(cosRad)*(180/Math.PI));
        }

        /// <summary>
        /// Подобрать значение лямбда
        /// </summary>
        private double Lambda(Point A0, double lambda, out Point An, out double f_An)
        {
            bool stop = true;
            double x1_1=0.0, x1_2=0.0, f_A1=0.0;

                while (stop)
                {
                    x1_1 = A0.X - lambda*(Program.Sistema_X(A0, Selector));
                    x1_2 = A0.Y - lambda*(Program.Sistema_Y(A0, Selector));
                    f_A1 = Program.F(x1_1, x1_2, Selector);

                    if (f_A1 > Program.F(A0, Selector)) lambda = lambda/2.0;
                    else stop = false;
                }
            An = new Point(x1_1, x1_2);//вернем расчетную точку
            f_An = f_A1;//вернем f(A)

            return lambda;
        }
    }
}
