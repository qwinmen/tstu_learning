using System;
using System.Collections.Generic;
using System.Text;

namespace ПауэллаСимплекс
{
    class clSimplex
    {
        public clSimplex(char selector)
        {
            Poisk(selector);
        }

        //задать точность определения минимума
        private const double _epsilon = 0.001;
        //задать коэфф отражения
        private const double _alfa = 1;
        //задать коэфф растяжения
        private const double _gamma = 2;
        //задать коэфф сжатия
        private const double _beta = 0.5;
        //задать мерность 2d,3d,...
        private const double _n = 2;

        private Point[] _tmp_x = new Point[3];
        private Point _tmpXx;

        private void Poisk(char selector)
        {
            //флаг на выход
            bool stop = true;

            //[0] - задать начальные три точки
            Point x1 = new Point(1, 1);
            Point x2 = new Point(2, 2);
            Point x3 = new Point(2, 1);
            double f_x1, f_x2, f_x3;
            int flagXx = 0;
step1:
            if(_tmp_x[0]!= null)
            {
                x1 = _tmp_x[0];
                x2 = _tmp_x[1];
                x3 = _tmp_x[2];
            }

            if(_tmpXx!=null)
            {
                if (flagXx == 1) x1 = _tmpXx;
                else if (flagXx == 2) x2 = _tmpXx;
                else if (flagXx == 3) x3 = _tmpXx;
            }

            //[1] - Вычислить значение функции во всех точках многогранника и выбрать лучшую и худшую точки
            f_x1 = Program.F(x1, selector); Console.WriteLine("f_x1={0}", f_x1);
            f_x2 = Program.F(x2, selector); Console.WriteLine("f_x2={0}",f_x2);
            f_x3 = Program.F(x3, selector);Console.WriteLine("f_x3={0}",f_x3);
            double[] f_x = new[] {f_x1, f_x2, f_x3};
            Array.Sort(f_x);//сортировать по возрастанию

            Point Хл;//Лучшая точка - минимальное значение
            if (f_x[0] == f_x1) Хл = new Point(x1.X, x1.Y);
            else if (f_x[0] == f_x2) Хл = new Point(x2.X, x2.Y);
            else Хл = new Point(x3.X, x3.Y);

            flagXx = 0; _tmp_x[0] = null;
            Point Xx;//Худшая точка - максимальное значение
            if (f_x[2] == f_x1){Xx = new Point(x1.X, x1.Y); flagXx = 1;}
            else if (f_x[2] == f_x2){Xx = new Point(x2.X, x2.Y); flagXx = 2;}
            else{Xx = new Point(x3.X, x3.Y);flagXx = 3;}

            Point Нн = new Point(0,0);//То что осталось
            if (f_x[1] == f_x1) Нн = new Point(x1.X, x1.Y);
            else if (f_x[1] == f_x2) Нн = new Point(x2.X, x2.Y);
            else Нн = new Point(x3.X, x3.Y);

            //Xц - Центр тяжести многограника
            Point Хц = new Point(_beta * (Хл.X + Нн.X), _beta * (Хл.Y + Нн.Y));
            double f_Хц = Program.F(Хц, selector);

            stop = Exit(x1, x2, x3, Хц, selector);
            
            if(!stop) Console.WriteLine("Exit");
            else
            {
                //[3] - Выполним операцию отражения худшей точки через центр тяжести
                Point Xotr = new Point(Хц.X + _alfa * (Хц.X - Xx.X), Хц.Y + _alfa * (Хц.Y - Xx.Y));
                double f_Xotr = Program.F(Xotr, selector);

                if (f_Xotr < Program.F(Хл, selector))
                {//то выполнить растяжение
                    Point Xrast = new Point(Хц.X + _gamma * (Xotr.X - Хц.X), Хц.Y + _gamma * (Xotr.Y - Хц.Y));
                    double f_Xrast = Program.F(Xrast, selector);

                    if (f_Xrast < f_Xotr) { Xx = Xrast; _tmpXx = Xx; }
                    else { Xx = Xotr; _tmpXx = Xx; }

                    goto step1;
                }

                if (Program.F(Хл, selector) <= f_Xotr && f_Xotr < Program.F(Xx, selector))
                {//то выполнить сжатие
                    Point Xsjat = new Point(Хц.X + _beta * (Xx.X - Хц.X), Хц.Y + _beta * (Xx.Y - Хц.Y));
                    double f_Xsjat = Program.F(Xsjat, selector);

                    if (f_Xsjat < f_Xotr) { Xx = Xsjat; _tmpXx = Xx; }
                    else { Xx = Xotr; _tmpXx = Xx; }

                    goto step1;
                }

                if (f_Xotr >= Program.F(Xx, selector))
                {//то выполнить редукцию
                    _tmp_x[0] = new Point(Хл.X + _beta * (x1.X - Хл.X), Хл.Y + _beta * (x1.Y - Хл.Y));
                    _tmp_x[1] = new Point(Хл.X + _beta * (x2.X - Хл.X), Хл.Y + _beta * (x2.Y - Хл.Y));
                    _tmp_x[2] = new Point(Хл.X + _beta * (x3.X - Хл.X), Хл.Y + _beta * (x3.Y - Хл.Y));

                    goto step1;
                }
            }

        }


        private bool Exit(Point x1, Point x2, Point x3, Point Хц, char selector)
        {
            if (Math.Pow((((Program.F(x1, selector) - Program.F(Хц, selector)) * (Program.F(x1, selector) - Program.F(Хц, selector)) +
                           (Program.F(x2, selector) - Program.F(Хц, selector)) * (Program.F(x2, selector) - Program.F(Хц, selector)) +
                           (Program.F(x3, selector) - Program.F(Хц, selector)) * (Program.F(x3, selector) - Program.F(Хц, selector))) * (1 / (_n + 1))), 0.5) <= _epsilon)
            {
                Console.WriteLine("ПОИСК ЗАКОНЧЕН. [{0}; {1}]", Хц.X, Хц.Y);
                return false;//то поиск ЗАВЕРШЕН
            }
            return true;//ТО поиск продолжить
        }

    }
}
