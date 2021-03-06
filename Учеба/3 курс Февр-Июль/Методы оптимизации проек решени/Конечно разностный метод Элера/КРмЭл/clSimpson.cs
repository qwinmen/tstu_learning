using System;
using System.Collections.Generic;
using System.Linq;
using ZedGraph;
using КРмЭл;

namespace Дубль
{
    /// <summary>
    /// Вычисление интеграла по методу Симпсона
    /// </summary>
    class clSimpson
    {
        public clSimpson()
        {
        }

        public static double Simpson(double a1, double a2, double tmp)
        {
            //шаг t
            double delta = tmp;//0.67

            List<double> производныеX = new List<double>();
            List<double> производныеY = new List<double>();
            int countList = 0;

            //note: вычислим производные по X и Y
            for (double tt = -1.0; tt < 1.0; tt += delta, countList++)
            {
                double proizvodX = Form1.ПроизводнаяПоИкс(a1, tt);//Form1.ПроизводнаяПоИкс(a1, tt, tt + delta);//
                производныеX.Add(proizvodX);

                double proizvodY = Form1.ПроизводнаяПоИгрек(a2, tt);//Form1.ПроизводнаяПоИгрек(a2, tt, tt + delta);//
                производныеY.Add(proizvodY);
            }

            List<double> listX = new List<double>();
            List<double> listY = new List<double>();

            //note: решаем систему, находим X и Y
            for (double tt = -1.0; tt < 1.0; tt += delta)
            {
                double x = Form1.X(a1, tt);
                listX.Add(x);

                double y = Form1.Y(a2, tt);
                listY.Add(y);
            }

            List<double> Integral = new List<double>();
            Integro = new PointPairList();

            int index = 0;
            //note: решаем интеграл
            for (double t = -1.0; t < 1.0; t += delta)
            {
                //t=[-1.0; 1.0]
                double integrl = Rectangles(2, производныеX[index], производныеY[index], tmp);
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
        /// По методу прямоугольников
        /// </summary>
        /// <param name="t"></param>
        /// <param name="производX"></param>
        /// <param name="производY"></param>
        /// <returns></returns>
        private static double Rectangles(double t, double производX, double производY, double tmp)
        {
            var s = 0.0;
            for (int i = 0; i < 3; i++)
            {
                s = s + FIntegral(i, t, производX, производY) * tmp;
            }

            return s;
        }
/*
        /// <summary>
        /// Метод
        /// </summary>
        private static int SimpsonA(double t, double производX, double производY)
        {//a =-1.0//b =1.0//
            //n=(1.0-(-1.0))/0.1 =20 отрезков разбиения с шагом h =0.1
            double a = -1.0;
            double b = 1.0;
            double h = 0.1;//0.67

            double n = (b - (a))/h;

            double s1 = 0, s2 = 0;
            int i;
            for (i = 1; i <= n; i++)
            {
                //суммы четных и нечетных узлов
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
        */
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
            return (2.0 * t * x) - (производX * производX) + (производY * производY * производY) / 3.0;
            //return 1.0+2.0*x*x-x*x*x;
            //return Math.Cos(x*x)/(x + 1.0);
            //return (2 - x*x) - x*x;
            //return (2.0*t*x - Math.Pow(производX, 2) + производY/3.0);
        }

       

        #endregion








    }




}
