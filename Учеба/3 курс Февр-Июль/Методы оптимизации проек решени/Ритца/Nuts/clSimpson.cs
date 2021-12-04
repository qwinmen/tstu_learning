using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuts
{
    /// <summary>
    /// Вычисление интеграла по методу Симпсона
    /// </summary>
    class clSimpson
    {

        public clSimpson()
        {}


        #region ИнтегралСимпсона

        /// <summary>
        /// Метод
        /// </summary>
        /// <param name="a">Отрезок интегрирования - лево = -1.0</param>
        /// <param name="b">Отрезок интегрирования - право = 1.0</param>
        /// <param name="h">шаг 0.1</param>
        internal double Simpson(double a, double b, double h, double t, double производX, double производY)
        {//a =-1.0//b =1.0//n=(1.0-(-1.0))/0.1 =20//h =0.1

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

            //(Math.Log(x * x + 1) / x);//(Math.Cos(Math.Pow(x, 2))) / (x + 1);//Math.Tan(x * x) / (x * x + 1);//
        }

       

        #endregion








    }




}
