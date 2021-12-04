using System;
using System.Collections.Generic;
using System.Linq;
using ZedGraph;

namespace Karma
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
            int countList = 0;

            //note: вычислим производные по X и Y
            for (double tt = 0.0; tt < 1.0; tt += delta, countList++)
            {
                double proizvodX = Form1.ПроизводнаяПоИкс(a1, tt, tt + delta, a2);//x
                производныеX.Add(proizvodX);

            }

            List<double> listX = new List<double>();

            //note: решаем систему, находим X и Y
            for (double tt = 0.0; tt < 1.0; tt += delta)
            {
                double x = Form1.X(a1, tt, a2);
                listX.Add(x);
            }

            List<double> Integral = new List<double>();
            Integro = new PointPairList();

            int index = 0;
            //note: решаем интеграл
            for (double t = 0.0; t < 1.0; t += delta)
            {
                //t=[0.0; 1.0]
                double integrl = Simpson(производныеX[index], false);
                Integral.Add(integrl);
                index++;

                Integro.Add(t, integrl);//x(t)
            }
            //Площадь интеграла
            double sumInteg = Integral.Sum();
            
            return sumInteg;
        }

        internal static PointPairList Integro { get; set; }

        #region ИнтегралСимпсона

        /// <summary>
        /// Метод
        /// </summary>
        private static double Simpson(double производX, bool f)
        {//a =0.0//b =1.0//
            //n=(1.0-0)/0.1 =10 отрезков разбиения с шагом h =0.1
            double a = 0.0;
            double b = 1.0;
            double h = 0.1;

            double n = (b - (a))/h;

            double s1 = 0, s2 = 0;
            int i;
            for (i = 1; i <= n; i++)
            {
                //суммы четных и нечетных узлов
                if ((i % 2 == 0) && (i != n))
                    s2 += FIntegral(a + i * h, производX);//2-4-6-8//узлы
                else
                    s1 += FIntegral(a + i * h, производX);//1-3-5-7//узлы
            }
            // [(b-a)/3n]*[f(a) + 2*(s2) + 4*(s1) + f(b)]
            //для произвольного четного числа узлов n=2m получим составную формулу:
            return (
                    ((b - a)/(3.0*n))*
                    (FIntegral(a, производX) + 2.0*s2 + 4.0*s1 +
                     FIntegral(a + n*h, производX))
                    );
        }

        /// <summary>
        /// Определенный интеграл, который решаем
        /// </summary>
        /// <param name="x"></param>
        /// <param name="t">шаг</param>
        /// <param name="производX">Производная по Икс''</param>
        /// <returns></returns>
        private static double FIntegral(double x, double производX)
        {//f(x)
            return (x + производX*производX);
            //return (2.0 * t * x) - (производX * производX) + (производY * производY * производY) / 3.0;
            //return 1.0+2.0*x*x-x*x*x;
            //return Math.Cos(x*x)/(x + 1.0);
            //return (2 - x*x) - x*x;
            //return (2.0*t*x - Math.Pow(производX, 2) + производY/3.0);
        }

       

        #endregion








    }




}
