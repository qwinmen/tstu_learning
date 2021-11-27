using System;

namespace ДихЗолотФибон
{
    class ЗолотоеСечение
    {
        static double Delta(double a, double b){ return Math.Abs(b - a); }

        static double A_B_Z(double a, double b, char znak)
        {
            if (znak == '+') return a + 0.382 * (b - a);
            return b - 0.382 * (b - a);
        }

        static public void GoldMain(double a0, double b0, double epsilon)
        {//[a;b]            
            if (epsilon < 0) Console.WriteLine("Точность не ниже нуля!!");
            //step 2
            int k = 0;
            double a = a0;
            double b = b0;
            //[1]Вычисляется значение функции f(x1), где x1=a+0,382*(b-a).
            double y = a + 0.382 * (b - a);
            //[2]Вычисляется значение функции f(x2), где x1=b-0,382*(b-a).
            double z = b - 0.382 * (b - a);
            
            double f_y = Program.F(y);
            double f_z = Program.F(z);

            do
            {
                //[3]Определяется новый интервал (a,x2) или (x1,b), в котором локализован минимум.
                Console.WriteLine("f(y)={0:#.###},\tf(z)={1:#.###}", f_y, f_z);
                if (f_y < f_z)
                {
                    //[4]Внутри полученного интервала находится новая точка (x1 в случае 1) 
                    //или (x2 в случае 2), отстоящая от его конца на расстоянии, составляющем 0,382 от его длины
                    b = z;
                    z = y;
                    y = A_B_Z(a, b, '+');
                    f_z = f_y;
                    //[5]В этой точке рассчитывается значение f(x).
                    f_y = Program.F(y);
                    Console.WriteLine("a={0:#.###},\tb={1:#.###},\ty={2:#.###},\tz={3:#.###}", a, b, y, z);
                }
                else
                {
                    a = y;
                    y = z;
                    z = A_B_Z(a, b, '-');
                    f_y = f_z;
                    //[5]В этой точке рассчитывается значение f(x).
                    f_z = Program.F(z);
                    Console.WriteLine("a={0:#.###},\tb={1:#.###},\ty={2:#.###},\tz={3:#.###}", a, b, y, z);
                }
                //Затем вычисления повторяются, начиная с пункта 3, до тех пор,
                //пока величина интервала неопределенности станет меньше или равна e,
                //где e - заданное сколь угодно малое положительное число.	
                Program.SetColor(k = k + 1);
            } while (Delta(a, b) > epsilon);
            
            Console.WriteLine("***Метод Золотого Сечения***\nКоличество итерации {0}", k + 1);
            Console.WriteLine("Xe[{0:#.###};{1:#.###}]", a, b);
            Console.WriteLine("(a+b)/2= {0}", (a + b) / 2.0);
        }

        

    }
}
