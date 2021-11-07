using System;
//http://optimizaciya-sapr.narod.ru/bez_mnogomer/grad.html
namespace Спуск
{
    class ГрадиентныйСпуск
    {
        

        static double F(double x, double y)
        { return (2 * (x * x) + 2 * (y * y) + 2 * x * y + 20 * x + 10 * y + 10); }

        static double Sistema_X(double x, double y)
        {
            return 4 * x + 2 * y + 20;
        }
        static double Sistema_Y(double x, double y)
        {
            return 4 * y + 2 * x + 10;
        }
        
        static double Kriterii(double x, double y)
        { return Math.Sqrt((x * x) + (y * y)); }

        public static void GradF(double x0, double y0, double epsilon)
        {//epsilon=0.1//X0=[0;0]
            if (epsilon < 0) { Console.WriteLine("Значение epsilon меньше нуля!"); return; }
            //Найти градиент функции в точке [x0;y0]=X0
            //Итерация 0
            double[] x_X = new double[50], x_Y = new double[50];
            int k = 0;
            x_X[k] = x0; x_Y[k] = y0;
            double fX0 = F(x0, y0);//f(X^0)=10
            Console.Write("f(X°)={0}\n", fX0);
            Console.WriteLine(@"       ┌      ┐
▼f(X°)=│{0:f3}│
       │{1:f3}│
       └      ┘", Sistema_X(x0, y0), Sistema_Y(x0, y0));
            double[] kritPoiska = new double[50];
            double sistVerxn_X, sistNizn_Y;
        //Шаг 1
        step1:
            sistVerxn_X = Sistema_X(x_X[k], x_Y[k]);//20
            sistNizn_Y = Sistema_Y(x_X[k], x_Y[k]);//10
            //kritPoiska[k] это delta f(X^k)
            kritPoiska[k] = Kriterii(sistVerxn_X, sistNizn_Y);//22.3607
            Console.WriteLine("║▼f(X^{1})║={0:f3}", kritPoiska[k],k);
            
            //Console.WriteLine("[n*m]");
            //Console.CursorLeft = 40;

            //Шаг 2);
            if (kritPoiska[k] < epsilon)
            { Console.WriteLine("*x={0:f5},  f(X*)={1}", kritPoiska[k],F(x_X[k],x_Y[k])); }
            else
            {    //Шаг 3
                double t0 = 0.1;//"Введите шаг поиска t"
            //Шаг 4
            step4:
                //X^1=[-2;-1]
                x_X[k + 1] = x_X[k] - t0 * sistVerxn_X;//-2
                //Console.WriteLine("-2=={0}", x_X[k + 1]);
                x_Y[k + 1] = x_Y[k] - t0 * sistNizn_Y;//-1
                //Console.WriteLine("-1=={0}", x_Y[k + 1]);

                Console.WriteLine(@"       ┌      ┐           ┌      ┐
  X^{2:d2}=│{0:f3}│  ▼f(X^{2:d2})=│{3:f3} │
       │{1:f3}│           │{4:f3}│
       └      ┘           └      ┘", x_X[k + 1], x_Y[k + 1], k + 1, Sistema_X(x_X[k + 1], x_Y[k + 1]), Sistema_Y(x_X[k + 1], x_Y[k + 1]));
                //Шаг 5+
                //f(X^1)= -26
                double fX1 = F(x_X[k + 1], x_Y[k + 1]);//f(X^1)=-26
                Console.WriteLine("f(X^{1})={0:f3}", fX1,k+1);
                //Шаг 5. Проверить выполнение условия f(X^1)-f(X^0) < 0
                if (fX1 - fX0 < 0)
                { k = k + 1; goto step1; }
                else
                {
                    t0 = t0 / 2;
                    goto step4;
                }
            }



        }

    }
}
