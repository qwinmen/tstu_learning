using System;
//http://optimizaciya-sapr.narod.ru/bez_mnogomer/naisk.html
namespace Спуск
{
    class НаискорейшийСпуск
    {
        static double F(double x, double y)
        { return (2 * (x * x) + 2 * (y * y) + 2 * x * y + 20 * x + 10 * y + 10); }
        static double Sistema_X(double x, double y)
        { return 4 * x + 2 * y + 20; }
        static double Sistema_Y(double x, double y)
        { return 4 * y + 2 * x + 10; }
        static double Kriterii(double x, double y)
        { return Math.Sqrt((x * x) + y * y); }

        static double _f_a(double x, double y)
        { return 2.0 * x * x + 2.0 * y * y + 2.0 * x * y; }//1400a
        static double _f_b(double x, double y)
        { return 20.0 * x + 10.0 * y; }//-500b

        public static void N_Spusk(double x0, double y0, double epsilon)
        {
//epsilon=0.1//X0=[0;0]
            if (epsilon < 0)
            {
                Console.WriteLine("Значение epsilon меньше нуля!");
                return;
            }
            //Найти градиент функции в точке [x0;y0]=X0
            //Итерация 0
            double[] x_X = new double[100], x_Y = new double[100];
            int k = 0;
            double[] t = new double[100];
            x_X[k] = x0;
            x_Y[k] = y0;
            double fX0 = F(x0, y0); //f(X^0)=10
            Console.Write("f(X°)={0}\n", fX0);
            
            double[] kritPoiska = new double[100];
            double sistVerxn_X, sistNizn_Y;
            //Шаг 1
       step1:
            sistVerxn_X = Sistema_X(x_X[k], x_Y[k]); //20//2.14//2.1428
            sistNizn_Y = Sistema_Y(x_X[k], x_Y[k]); //10//-4.28//7.3723
            Console.WriteLine("▼f(X^{2})--->{0:f3}---->{1:f3}", Sistema_X(x_X[k], x_Y[k]), Sistema_Y(x_X[k], x_Y[k]),k);
            //kritPoiska[k] это delta f(X^k)
            kritPoiska[k] = Kriterii(sistVerxn_X, sistNizn_Y); //22.3607//4.7916//7.67
            Console.WriteLine("║▼f(X^{1})║={0:f3}", kritPoiska[k], k);
            //Шаг 2
            if (kritPoiska[k] < epsilon)
            {
                Console.WriteLine("*x={0:f5}", kritPoiska[k]);
            }
            else
            {
                //Шаг 4
                //step4:
                //X^1=[-20;-10]//!!!ШАГ ЕЩЕ НЕОПРЕДЕЛЕН!!!поэтому 1.0
                x_X[k + 1] = x_X[k] - 1.0*sistVerxn_X; //-20*t0
                //Console.WriteLine("-2=={0}", x_X[k + 1]);
                x_Y[k + 1] = x_Y[k] - 1.0*sistNizn_Y; //-10*t0
                //Console.WriteLine("-1=={0}", x_Y[k + 1]);

                //нашли [-20t0;-10t0], ищем минимум, т.е. шаг
                Console.WriteLine("{0:f3}a" + (_f_b(x_X[k + 1], x_Y[k + 1]) >= 0 ? "+{1:f3}b" : "{1:f3}b") + " + 10",
                                  _f_a(x_X[k + 1], x_Y[k + 1]), _f_b(x_X[k + 1], x_Y[k + 1]));
                    //упращеное выражение f(x)
                t[k] = -(_f_b(x_X[k + 1], x_Y[k + 1]))/(2*_f_a(x_X[k + 1], x_Y[k + 1]));
                    //X^1=[x_X[k + 1];x_Y[k + 1]] 
                Console.WriteLine("Шаг={0}", t[k]);

                //ШАГ 4
                //X^1=[-20;-10]//!!!ШАГ ОПРЕДЕЛЕН!!!поэтому t[k]
                x_X[k+1] = x_X[k] - t[k]*sistVerxn_X; //-3.75
                Console.Write("X^---->>{0:f3}", x_X[k + 1]);
                x_Y[k+1] = x_Y[k] - t[k]*sistNizn_Y; //-1.78
                Console.WriteLine("   ---->>{0:f3}", x_Y[k + 1]);

                fX0 = F(x_X[k+1], x_Y[k+1]); //f(X^0)=-34.64
                Console.WriteLine("f(X)={0}", fX0);

                

                k = k + 1;
                goto step1;
            }

        }//metod END
    }
}
