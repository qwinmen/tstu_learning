using System.Collections.Generic;
using System.Linq;

namespace testerCnsl
{
    /// <summary>
    /// Вычисление интеграла по методу Симпсона
    /// </summary>
    class clSimpson
    {
        public clSimpson()
        {
        }

        public static double Simpson(double a1, double a2)
        {
            //шаг t
            double delta = 0.1;

            List<double> производныеX = new List<double>();
            List<double> производныеY = new List<double>();
            int countList = 0;

            //note: вычислим производные по X и Y
            for (double tt = -1.0; tt < 1.0; tt += delta, countList++)
            {
                double proizvodX = Program.ПроизводнаяПоИкс(a1, tt);
                производныеX.Add(proizvodX);

                double proizvodY = Program.ПроизводнаяПоИгрек(a2, tt);
                производныеY.Add(proizvodY);
            }

            List<double> listX = new List<double>();
            List<double> listY = new List<double>();

            //note: решаем систему, находим X и Y
            for (double tt = -1.0; tt < 1.0; tt += delta)
            {
                double x = Program.X(a1, tt);
                listX.Add(x);

                double y = Program.Y(a2, tt);
                listY.Add(y);
            }

            List<double> Integral = new List<double>();

            int index = 0;
            //note: решаем интеграл
            for (double t = -1.0; t < 1.0; t += delta)
            {
                //t=[-1.0; 1.0]
                double integrl = Simpson(t, производныеX[index], производныеY[index]);
                Integral.Add(integrl);
                index++;
            }
            //Площадь интеграла
            double sumInteg = Integral.Sum();

            return sumInteg;
        }


        #region ИнтегралСимпсона

        /// <summary>
        /// Метод
        /// </summary>
        private static double Simpson(double t, double производX, double производY)
        {//a =-1.0//b =1.0//n=(1.0-(-1.0))/0.1 =20//h =0.1
            double a = -1.0;
            double b = 1.0;
            double h = 0.1;
            


            double n = (b - (a))/h;

            double s1 = 0, s2 = 0;
            int i;
            for (i = 1; i <= n; i++)
            {
                if ((i % 2 == 0) && (i != n))
                    s2 += FIntegral(a + i * h, t, производX, производY);//2-4-6-8//узлы
                else
                    s1 += FIntegral(a + i * h, t, производX, производY);//1-3-5-7//узлы
            }
            // [(b-a)/3n]*[f(a) + 2*(s2) + 4*(s1) + f(b)]
            //для произвольного четного числа узлов n=2m получим составную формулу:
            return (
                    ((b - a)/(3.0*n))*
                    (FIntegral(a, t, производX, производY) + 2.0*s2 + 4.0*s1 +
                     FIntegral(a + n*h, t, производX, производY))
                     );
        }

        /// <summary>
        /// Определенный интеграл, который решаем
        /// </summary>
        /// <param name="x"></param>
        /// <param name="t">шаг</param>
        /// <param name="производX">Производная по Икс</param>
        /// <param name="производY">Производная по Игрек</param>
        /// <returns></returns>
        private static double FIntegral(double x, double t, double производX, double производY)
        {//f(x)
            return (2.0 * t * x - (производX * производX) + (производY * производY * производY) / 3.0);
        }

       

        #endregion








    }




}
