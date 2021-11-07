using System;
//Lab_2
namespace L2Kasatelne
{//info http://kurs.ido.tpu.ru/courses/informat_chem_2/modul_2.htm#3.
    class Program
    {//Метод Ньютона(или касательных) x*(x+1)^2=1
        static double f_x(double X)
        {//f(x)
            return (X*Math.Pow(X + 1, 2) - 1);
        }
        static double f1_x(double X)
        {//f'(x)
            return 3*Math.Pow(X, 2) + 4*X + 1;
        }
        static double f2_x(double X)
        {//f''(x)
            return 6*X + 4;
        }
        static void Main()
        {
            double x = 0.4, f_x, f_2x;
            f_x = Program.f_x(x);//f(0.4)=-0.216
            f_2x = f2_x(x);//f''(0.4)=6.4
            //также для 0.5
            double x05 = 0.5, f_05, f_205;
            f_05 = Program.f_x(x05);//f(0.5)=0.125
            f_205 = f2_x(x05);//f''(0.5)=7

            //далее
            double f_xof_2x;//-1.3824
            f_xof_2x = f_x * f_2x;//-0.216*6.4=-1.3824
            double f_05of_205;//0.875
            f_05of_205 = f_05*f_205;//0.125*7=0.875
            
            if (f_xof_2x>0)
            {//подходит// -1.3824>0
                Poisk(f_xof_2x);
            }else if (f_05of_205>0)
            {//подходит// 0.875>0
                Poisk(f_05of_205);
            }else Console.WriteLine("Значения [{0};{1}] неподходят!",x,x05);
        }
        static void Poisk(double X0)//X0=0.5
        {//X0 уже определен из [0.4;0.5]
            double e = 0.001, result;
            do
            {
                double X1 = Program.X1(X0);//0.4666...//X0=0.5
                result = Math.Abs(X0 - X1);//|0.5-0.4666...|
                Console.Write("Разница= "+result + "  Корень= " + X1+"\n");
                X0 = X1;//X0=0.4666...
            } while (result>e);
        }
        static double X1(double X0)
        {//Xn+1= X0-( f(X0)/f'(X0) )
            return X0 - (f_x(X0)/f1_x(X0));//0.4666...
        }
    }
}
