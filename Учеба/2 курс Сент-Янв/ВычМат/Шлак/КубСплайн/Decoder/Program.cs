using System;

namespace Decoder
{
    class Program
    {
        static void Main(string[] args)
        {
            #region РасШифрование

            string numletter = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string password = numletter[11] + numletter[12].ToString();

            password = password + numletter[18] + numletter[19];
            password = password + numletter[23] + numletter[24];
            password = password + numletter[16] + numletter[17];
            password = password + numletter[24] + numletter[25];
            password = password + numletter.Substring(1, 3); //[1] + numletter[4];

            #endregion

            #region КубическийСплайн

            Console.WriteLine(password + "\nКубический сплайн:");

            double[] x = {1, 2, 3, 4, 5}, y = {6, 3, 4, 10, 4};//y = {6, 5, 9, 2, 8};
            CubicSpline cubicSpline = new CubicSpline();
            cubicSpline.BuildSpline(x, y, x.Length);
            Console.WriteLine("\nP(x)={0}", cubicSpline.Interpolate(5.0));

            #endregion

            #region Дихотомия

            //double a=1.0, b=3.0, epsilon=0.1;
            Дихотомия.halfDivision(1.0, 3.0, 0.1);

            #endregion

            #region Золотое Сечение

            ЗолотоеСечение.GoldMain(0.0, 10.0, 1.0);

            #endregion

            #region Числа Фибоначчи
            //Console.WriteLine(ЧислаФибоначчи.Fibo(10));
            ЧислаФибоначчи.Фибоначи(0.0, 10.0, 0.01, 1.0);
            #endregion
        }
    }
}
