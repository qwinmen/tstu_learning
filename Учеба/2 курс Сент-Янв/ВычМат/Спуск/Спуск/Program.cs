using System;

namespace Спуск
{
    class Program
    {
        static double F(double x, double y)
        { return 2 * x * x + y * y + x * y; }
        static void Main(string[] args)
        {
            #region Градиентный Спуск
            Console.WriteLine("***Метод градиентного спуска с постоянным шагом***");
            ГрадиентныйСпуск.GradF(1.0,1.0,0.01);
            #endregion

            #region Наискорейший Спуск
            //Console.WriteLine("***Метод наискорейшего спуска***");
            //НаискорейшийСпуск.N_Spusk(0.0,0.0,0.1);
            #endregion

            #region Наискорейший Покоординатный Спуск
            //Console.WriteLine("***Метод наискорейшего спуска***");
            //НаискорейшегоПокоординатногоСпуска.NPokSpusk(0.5,1.0,0.1);
            //Console.WriteLine("x*=[{1};{2}]\nf(x*)={0:f5}", F(-0.00488, 0.016),-0.00488,0.0189);
            #endregion

            Console.ReadLine();
        }
    }
}
