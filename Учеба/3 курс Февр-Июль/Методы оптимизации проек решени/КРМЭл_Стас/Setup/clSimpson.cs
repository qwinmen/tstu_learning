using System.Collections.Generic;
using System.Linq;
using ZedGraph;

namespace Setup
{
    /// <summary>
    /// Вычiсленiе iнтеграла по методу Сiмпсона
    /// </summary>
    class clSimpson
    {
        public clSimpson(){}

        public static double Simpson(double a1, double a2, double tmp, int TODO)
        {
            //шаг t
            double delta = tmp;//0.67

            List<double> проiзводныеX = new List<double>();
            List<double> проiзводныеY = new List<double>();
            int countList = 0;

            //note: вычiслiм проiзводные по X i Y
            for (double tt = 0.0; tt < 1.0; tt += delta, countList++)
            {
                double proizvodX = Form1.ПроiзводнаяПоiкс(a1, tt, tt + delta, tmp);//
                проiзводныеX.Add(proizvodX);

                double proizvodY = Form1.ВтораяПроiзводнаяПоiкс(a2, tt, tt + delta, tmp);//
                проiзводныеY.Add(proizvodY);
            }

            List<double> listX = new List<double>();
            //List<double> listY = new List<double>();

            //note: решаем сiстему, находiм X i Y
            for (double tt = 0.0; tt < 1.0; tt += delta)
            {
                double x = Form1.X(a1, tt, a2);
                listX.Add(x);

                //double y = Form1.Y(a2, tt);
                //listY.Add(y);
            }

            List<double> Integral = new List<double>();
            Integro = new PointPairList();

            int index = 0;
            //note: решаем iнтеграл
            for (double t = 0.0; t < 1.0; t += delta)
            {
                //t=[-1.0; 1.0]
                double integrl = Rectangles(2, проiзводныеX[index], проiзводныеY[index], tmp, TODO);
                Integral.Add(integrl);
                index++;

                Integro.Add(t, integrl);//x(t)
            }
            //Площадь iнтеграла
            double sumInteg = Integral.Sum();
            
            return sumInteg;
        }

        internal static PointPairList Integro { get; set; }

        #region iнтегралСiмпсона

        /// <summary>
        /// По методу прямоугольнiков
        /// </summary>
        /// <param name="t"></param>
        /// <param name="проiзводX"></param>
        /// <param name="проiзводY"></param>
        /// <param name="tmp"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static double Rectangles(double t, double проiзводX, double проiзводY, double tmp, int n)
        {
            var s = 0.0;
            for (int i = 0; i < n; i++)
            {
                s = s + FIntegral(i, t, проiзводX, проiзводY) * tmp;
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
        /// Определенный iнтеграл, который решаем
        /// </summary>
        /// <param name="x"></param>
        /// <param name="t">шаг</param>
        /// <param name="проiзводX">Проiзводная по iкс</param>
        /// <param name="проiзводY">Проiзводная по iгрек</param>
        /// <returns></returns>
        private static double FIntegral(double x, double t, double проiзводX, double проiзводY)
        {//f(x)
            return (x + проiзводY*проiзводY);
            //return (2.0 * t * x) - (проiзводX * проiзводX) + (проiзводY * проiзводY * проiзводY) / 3.0;
            //return 1.0+2.0*x*x-x*x*x;
            //return Math.Cos(x*x)/(x + 1.0);
            //return (2 - x*x) - x*x;
            //return (2.0*t*x - Math.Pow(проiзводX, 2) + проiзводY/3.0);
        }

       

        #endregion








    }




}
