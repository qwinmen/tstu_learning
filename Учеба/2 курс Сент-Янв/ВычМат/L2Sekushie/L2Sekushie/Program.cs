using System;
//Lab_2
namespace L2Sekushie
{//Метод Секущих x^3+3x^2-3=0
    class Program
    {//info http://calc-x.com/chm/sec.php
        static void Main()
        {
            //double X0 = 100, X1 = 110, e = 0.01, modul,Xo,Xi;
            double X0 = 0.4, X1 = 0.5, e = 0.001, modul, Xo;
            Console.WriteLine("Xn\tXn+1\t|Xn+1-Xn|\t|f(Xn+1)-f(Xn)|");
            double Xn_1 = f(X1);
            double Xn = f(X0);
            double modulXn_1_Xn = Math.Abs(Xn_1 - Xn);
            Console.Write(X0 + "\t" + X1 + "\t" + (X1 - X0) + "\t\t" + modulXn_1_Xn + "\n");
            do
            {
                Xo = X1;//110
                X1 = Program.Xn_1(X1, X0);//110,100
                modul = Math.Abs(X1 - Xo);//110-158
                double modulXn_2_Xn1 = Math.Abs(f(Xo) - f(X1));
                Console.Write(Xo + "  " + X1 + "  " + modul + "  " + modulXn_2_Xn1 + "\n");
            } while (modul >= e);//|Xo-X1|>=0.001
        }
        static double f(double p)
        {//f(Xn)
            //return 18 - Math.Sqrt(p) - Math.Log(p + 1);
            return Math.Pow(p, 3) + 3*Math.Pow(p, 2) - 3;
        }
        static double Xn_1(double p,double p_1)
        {//Xn+1
            return p - (p - p_1)/(f(p) - f(p_1))*f(p);
        }
    }
}
