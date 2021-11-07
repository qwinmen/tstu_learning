using System;
//http://optimizaciya-sapr.narod.ru/bez_mnogomer/naiskpok.html
namespace Спуск
{
    class НаискорейшегоПокоординатногоСпуска
    {
        static double F(double x, double y)
        { return 2 * x * x + y * y + x * y; }
        static double Grad_Числит(double x, double y)
        { return 4 * x + y; }
        static double Grad_Знаменат(double x, double y)
        { return x + 2 * y; }
        static double Kriterii(double x, double y)
        { return Math.Sqrt((x * x) + (y * y)); }

        public static void NPokSpusk(double x0, double y0, double epsilon)
        {//Задать [x;y], e>0
            double[] x_X = new double[50];
            double[] x_Y = new double[50];
            x_X[0] = x0;
            x_Y[0] = y0;
            double t0=0.25;
            double[] kritPoiska = new double[50];
            //Найти градиент функции F в [x0;y0]  Grad_
            Console.WriteLine("▼f(X00)=[{0};{1}]", Grad_Числит(x_X[0], x_Y[0]), Grad_Знаменат(x_X[0], x_Y[0]));
            int j = 0;
            //Шаг 1
            step1:
            int k = 0;
            if (k<=j-1)//n-1
            {
                goto step3;
            }
            if (k==j)
            {
                j = j + 1;
                goto step1;
            }
        step3:
            double grad_fX = Grad_Числит(x_X[0], x_Y[0]);//3
            double grad_fY = Grad_Знаменат(x_X[0], x_Y[0]);//2.5
            //Console.WriteLine("▼f(X00)=[{0};{1}]", grad_fX, grad_fY);
            //Проверим выполнение критерия окончания
            kritPoiska[k] = Kriterii(grad_fX, grad_fY);//3.9
            Console.WriteLine("║▼f(X^{1})║={0:f3}", kritPoiska[k], k);
            if (kritPoiska[k] < epsilon)
            { Console.WriteLine("*x={0:f5}", kritPoiska[k]); }
            else
            {
                //Найдем величину шага 
                double e1 = 1.0, e2 = 0.0;//единичный вектор//const
                t0 = t0+k;
                if (t0<0)
                {
                    t0 = t0 - k - k;
                }
                double dx= x_X[k] - t0*e1;
                double dy = x_Y[k] - t0*e2;
                Console.WriteLine(dx+" "+dy);
                k = k + 1;
                //goto step3;
            }

        }
       
    }
}
