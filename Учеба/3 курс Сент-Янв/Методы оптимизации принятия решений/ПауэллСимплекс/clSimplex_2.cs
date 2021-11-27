using System;

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
        private const double _alfa = 1.0;
        //задать коэфф растяжения
        private const double _gamma = 2.0;
        //задать коэфф сжатия
        private const double _beta = 0.5;
        //задать мерность 2d,3d,...
        private const double _n = 2.0;

        private Point[] _tmp_x = new Point[3];
        private Point _tmpXx;

        private void Poisk(char selector)
        {
            Point x1 = new Point(0.0, 0.0);Point x2 = new Point(0.0, 0.0);
            Point x3 = new Point(0.0, 0.0);Point Xl = new Point(0.0, 0.0);
            Point Xg = new Point(0.0, 0.0);Point Xh = new Point(0.0, 0.0);
            Point Xp = new Point(0.0, 0.0);Point Xr = new Point(0.0, 0.0);
            Point Xc = new Point(0.0, 0.0);Point X1 = new Point(0.0, 0.0);
            Point X2 = new Point(0.0, 0.0);Point X3 = new Point(0.0, 0.0);
            double f_Xp = 0.0, f_Xc = 0.0, f_X1 = 0.0, f_X2 = 0.0, f_X3 = 0.0;
            bool perexod = false, XpXlXg = false, XrXlXg = false, XcXlXg = false, X1X2X3 = false;

step2:      //[1] - строится начальный симплекс.
            if(!perexod)
            {
                x1 = new Point(2.0, -1.0);//(-1.0, -1.0);
                x2 = new Point(5.0, 3.0);//(4.0, 4.0);
                x3 = new Point(-8.0, 1.0);//(9.0, 9.0);
            }
            else
            {
                x1 = Xl;
                x2 = Xg;
                if(XpXlXg)
                {
                    x3 = Xp;
                    XpXlXg = false;
                }else if(XrXlXg)
                {
                    x3 = Xr;
                    XrXlXg = false;
                }else if (XcXlXg)
                {
                    x3 = Xc;
                    XcXlXg = false;
                }
                else if (X1X2X3)
                {
                    x1 = X1;
                    x2 = X2;
                    x3 = X3;
                    X1X2X3 = false;
                }

            }

            Console.Write("x1=[{0:0.####};{1:0.####}], x2=[{2:0.####};{3:0.####}], x3=[{4:0.####};{5:0.####}]\n", x1.X,
                          x1.Y, x2.X, x2.Y, x3.X, x3.Y);
            //В вершинах симплекса вычисляем значения функции
            double f_x1 = Program.F(x1, selector); Console.WriteLine("f(x1)={0:0.####}", f_x1);
            double f_x2 = Program.F(x2, selector); Console.WriteLine("f(x2)={0:0.####}", f_x2);
            double f_x3 = Program.F(x3, selector); Console.WriteLine("f(x3)={0:0.####}", f_x3);

            //[2] - Среди точек симплекса ищем f_x = max, f_x = min, f_x = средн
            double[] f_x = new[] { f_x1, f_x2, f_x3 };
            Array.Sort(f_x);//f_Xl//f_Xg//f_Xh//сортировать по возрастанию 1/2/3/..
            #region Xl, Xg, Xh
            if(f_x[0] == f_x1)      Xl = new Point(x1.X, x1.Y);
            else if(f_x[0] == f_x2) Xl = new Point(x2.X, x2.Y);
            else if(f_x[0] == f_x3) Xl = new Point(x3.X, x3.Y);
            double f_Xl = Program.F(Xl, selector);
            Console.WriteLine("[2] Xl[{0:0.####};{1:0.####}] F(Xl)={2:0.####}", Xl.X,Xl.Y, f_Xl);
            
            if (f_x[1] == f_x1)      Xg = new Point(x1.X, x1.Y);
            else if (f_x[1] == f_x2) Xg = new Point(x2.X, x2.Y);
            else if (f_x[1] == f_x3) Xg = new Point(x3.X, x3.Y);
            double f_Xg = Program.F(Xg, selector);
            Console.WriteLine("[2] Xg[{0:0.####};{1:0.####}] F(Xg)={2:0.####}", Xg.X, Xg.Y,f_Xg);
            
            if (f_x[2] == f_x1)      Xg = new Point(x1.X, x1.Y);
            else if (f_x[2] == f_x2) Xg = new Point(x2.X, x2.Y);
            else if (f_x[2] == f_x3) Xg = new Point(x3.X, x3.Y);
            double f_Xh = Program.F(Xh, selector);
            Console.WriteLine("[2] Xh[{0:0.####};{1:0.####}] F(Xh)={2:0.####}", Xh.X, Xh.Y, f_Xh);
            #endregion

            //[3] - Ищется центр тяжести всех точек, кроме Xh(тоесть центр между Xg и Xl)
            Point X0 = new Point((1.0/_n)*(Xl.X + Xg.X), (1.0/_n)*(Xl.Y + Xg.Y));
            double f_X0 = Program.F(X0, selector);
            Console.WriteLine("[3] X0[{0:0.####};{1:0.####}] F(X0)={2:0.####}", X0.X, X0.Y, f_X0);

            //[4] - Выполняют отражение точки Xh относительно точки X0 с коэфф. alpha>0
            Xr = new Point(X0.X + _alfa*(X0.X - Xh.X), X0.Y + _alfa*(X0.Y - Xh.Y));
            double f_Xr = Program.F(Xr, selector);
            Console.WriteLine("[4] Xr[{0:0.####};{1:0.####}] F(Xr)={2:0.####}", Xr.X, Xr.Y, f_Xr);

            //[5] - Если f_Xr < f_Xl то направление из точки Х0 в точку Xr наиболее удобно для перемещения.
            //Поэтому выполняют операцию растяжения с коэфф. gamma > 0
            bool flag = false;
            if(f_Xr < f_Xl)
            {
                Xp = new Point(X0.X + _gamma * (Xr.X - X0.X), X0.Y + _gamma * (Xr.Y - X0.Y));
                f_Xp = Program.F(Xp, selector);
                Console.WriteLine("[5] Xp[{0:0.####};{1:0.####}] F(Xp)={2:0.####}", Xp.X, Xp.Y, f_Xp);
                flag = true;
            }

            //[6] - Если растяжение прошло удачно, т.е. f_Xp < f_Xl, то новый симплекс будет построен
            //из точки Xp и оставшихся точек Xg Xl предыдущего симплекса.
            if(f_Xp < f_Xl && flag)
            {//Xp//Xl//Xg
                perexod = true;
                XpXlXg = true;
                if (!Exit(Xp, Xl, Xg, selector)) goto step2;
                Environment.Exit(0);//прерывание программы
            }
            //В противном случае когда f_Xp > f_Xl вместо точки Xh в новом симплексе берем точку Xr.
            if(f_Xp > f_Xl)
            {//Xr//Xl//Xg
                perexod = true;
                XrXlXg = true;
                if (!Exit(Xr, Xl, Xg, selector)) goto step2;
                Environment.Exit(0);//прерывание программы
            }

            //[7] - Если отражение было не удачным (f_Xr > f_Xl) то сравнивают f_Xr и f_Xg.
            //Если f_Xr < f_Xg то новый симплекс строят используя вместо точки Xh точку Xr
            //и после проверки условия сходимости возвращаются на шаг 2
            if(!flag && f_Xr < f_Xg)
            {//Xr//Xl//Xg
                perexod = true;
                XrXlXg = true;
                if (!Exit(Xr, Xl, Xg, selector)) goto step2;
                Environment.Exit(0);//прерывание программы
            }
            //Если же f_Xr > f_Xg то переходят к операции сжатия симплекса (шаг 8).
            if(f_Xr > f_Xg)
            {
                //[8] - Сравнивают f_Xr и f_Xh. По результатам сравнения оставляют начальный
                //симплекс без изменения (если f_Xr > f_Xh) либо строят новый, используя вместо
                //Xh точку Xr (при f_Xr < f_Xh).
                if(f_Xr > f_Xh)
                {//Xh//Xl//Xg
                    //Для выбранного симплекса выполняют операцию сжатия с параметром betta > 0
                    Xc = new Point(X0.X + _beta * (Xh.X - X0.X), X0.Y + _beta * (Xh.Y - X0.Y));
                    f_Xc = Program.F(Xc, selector);
                    Console.WriteLine("[8] Xc[{0:0.####};{1:0.####}] F(Xc)={2:0.####}", Xc.X, Xc.Y, f_Xc);
                }else if(f_Xr < f_Xh)
                {//Xr//Xl/Xg
                    //Для выбранного симплекса выполняют операцию сжатия с параметром betta > 0
                    Xc = new Point(X0.X + _beta * (Xr.X - X0.X), X0.Y + _beta * (Xr.Y - X0.Y));
                    f_Xc = Program.F(Xc, selector);
                    Console.WriteLine("[8] Xc[{0:0.####};{1:0.####}] F(Xc)={2:0.####}", Xc.X, Xc.Y, f_Xc);
                }
                //[9] - Выполнив сжатие проверяют успешно ли прошла эта операция.
                //Если f_Xc < f_Xh то сжатие прошло удачно и для нового симплекса (заменяя Xh на Xc) 
                //проверяют условие сходимости. 
                //Если же неудачно, то осуществляют редукцию симплекса (f_Xc > f_Xh)
                if(f_Xc < f_Xh)
                {//Xc//Xl//Xg
                    perexod = true;
                    XcXlXg = true;
                    if (!Exit(Xc, Xl, Xg, selector)) goto step2;
                    Environment.Exit(0);//прерывание программы
                }else if(f_Xc > f_Xh)
                {
                    //[10] - Операция редукции заключается в уменьшении размеров симплекса по формулам.
                    X1 = (x1 + Xl)/2.0;
                    f_X1 = Program.F(X1, selector);
                    Console.WriteLine("[10] X1[{0:0.####};{1:0.####}] F(X1)={2}", X1.X, X1.Y, f_X1);
                    X2 = (x2 + Xl) / 2.0;
                    f_X2 = Program.F(X2, selector);
                    Console.WriteLine("[10] X2[{0:0.####};{1:0.####}] F(X2)={2:0.####}", X2.X, X2.Y, f_X2);
                    X3 = (x3 + Xl) / 2.0;
                    f_X3 = Program.F(X3, selector);
                    Console.WriteLine("[10] X3[{0:0.####};{1:0.####}] F(X3)={2:0.####}", X3.X, X3.Y, f_X3);
                    
                    //После вычисления значений функций f_x снова проверяют условия сходимости и шаг 2
                    //X1//X2//X3
                    perexod = true;
                    X1X2X3 = true;
                    if (!Exit(X1, X2, X3, selector)) goto step2;
                    Environment.Exit(0);//прерывание программы

                }
                
            }
            
        }

        /// <summary>
        /// if(Exit)то конец программы
        /// </summary>
        private bool Exit(Point x1, Point x2, Point x3, char selector)
        {
            double fP = (Program.F(x1, selector) + Program.F(x2, selector) + Program.F(x3, selector))/(_n + 1.0);

            double deta =
                Math.Sqrt((1.0/(_n + 1.0))*
                          Math.Pow(
                              ((Program.F(x1, selector) + Program.F(x2, selector) + Program.F(x3, selector)) - fP), 2.0));
            if (deta < _epsilon)
            {
                Console.WriteLine(
                    "ПОИСК ЗАКОНЧЕН. x1[{0:0.####}; {1:0.####}] x2[{2:0.####}; {3:0.####}] x3[{4:0.####}; {5:0.####}]",
                    x1.X, x1.Y, x2.X, x2.Y, x3.X, x3.Y);
                return true; //то поиск ЗАВЕРШЕН
            }
            return false;//ТО поиск продолжить
        }

    }
}
