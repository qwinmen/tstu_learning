using System;
//http://optimizaciya-sapr.narod.ru/bez_odnomer/zol_sech.html
namespace Decoder
{
    class ЗолотоеСечение
    {
        static double f(double x)
        {return (2.0 * Math.Pow(x, 2) - 12.0 * x);}
        static double Delta(double a,double b)
        {return Math.Abs(a - b);}
        static double A_B_Z(double a,double b,double y_z)
        {return a + b - y_z;}

        static public void GoldMain(double a0, double b0, double epsilon)
        {//[a;b]            
            if (epsilon < 0) Console.WriteLine("Точность не ниже нуля!!");
            //step 2
            int k = 0;
            double f_y, f_z;
            double[] y=new double[10],a=new double[10],z=new double[10], b=new double[10];
            a[k] = a0;b[k] = b0;
            y[k] = a[k] + 0.382*(b[k] - a[k]);
            z[k] = A_B_Z(a[k], b[k], y[k]);
        step4:
            Console.WriteLine("Итерация {0}",k);
            f_y = f(y[k]);
            f_z = f(z[k]);
            Console.WriteLine("f(y)={0}, f(z)={1}",f_y,f_z);
            if (f_y<=f_z)
            {
                a[k + 1] = a[k];
                b[k + 1] = z[k];
                y[k + 1] = A_B_Z(a[k + 1], b[k + 1], y[k]);
                z[k + 1] = y[k];
                Console.WriteLine("a[k+1]={0}, b[k+1]={1}, y[k+1]={2}, z[k+1]={3}",a[k+1],b[k+1],y[k+1],z[k+1]);
            }
            else
            {
                a[k + 1] = y[k];
                b[k + 1] = b[k];
                y[k + 1] = z[k];
                z[k + 1] = A_B_Z(a[k + 1], b[k + 1], z[k]);
                Console.WriteLine("a[k+1]={0}, b[k+1]={1}, y[k+1]={2}, z[k+1]={3}", a[k + 1], b[k + 1], y[k + 1], z[k + 1]);
            }
            if (Delta(a[k+1],b[k+1])<=epsilon)
            {
                Console.WriteLine("***Метод Золотого Сечения***\nКоличество итерации {0}",k+1);
                Console.WriteLine("Xe[{0};{1}]",a[k+1],b[k+1]);
                Console.WriteLine("(a+b)/2= {0}",(a[k+1]+b[k+1])/2.0);
            }
            else
            {
                k = k + 1;
                goto step4;
            }
        }
    }
}
