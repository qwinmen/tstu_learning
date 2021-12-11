using System;
using System.Collections.Generic;
using ZedGraph;

namespace Razbor
{
    class Дихотомия
    {
        public const double _A1 = 8000;
        public const double _A2 = 4000;
        public const double _A3 = 300000;

        public const double _E1 = 72600;//Дж\моль
        public const double _E2 = 77000;//Дж\моль
        public const double _E3 = 87000;//Дж\моль

        public const double _R = 8.31;

        public const double _C1_нафВх = 1.09;//моль\м3
        public const double _C2_О2вв = 8.75;//моль\м3
        public const double _C3_вых = 6.62;//моль\м3

        public const double _dL = 0.1;//метр
        public const double _U = 0.1;//м\с
        public const double _Ct = 1100;//Дж\кг*град
        public const double _p = 1.4;//кг\м3
        public const double _Kt = 500;//Вт\м2*град
        public const double _D = 0.025;//метр

        public Дихотомия(double len)
        {
            Temperature = halfDivision(len);
        }

        private int[] halfDivision(double len)
        {
            var maxDegres = new int[5];
            HiComerce = new double[5];
            
            var result = 0d;
            //Делим len на пять отрезков
            var mass = new PointD[5];
            var tmp = len/5.0;

            for (var i = 0; i < mass.Length; i++)
                mass[i] = new PointD((i == 0 ? 0.0 : mass[i - 1].Y), (i == 0 ? tmp : mass[i - 1].Y + tmp));//0..2//от до
            
            ResultLen = Console.WriteLine("При начальной длине {0:#0.##}m и {1}°C", len, 260);

            var t_p = 260;//цельси

            var e1 = C3(mass[0].X, mass[0].Y, t_p);
            ResultLen += Console.WriteLine("Участок А {0:#0.##}m и {1}°C", Lmin, trass);
            HiComerce[0] = Ttmax-273.15;

            var e = C3(mass[1].X, mass[1].Y, t_p);
            ResultLen += Console.WriteLine("Участок B {0:#0.##}m и {1}°C", Lmin, trass);
            HiComerce[1] = Ttmax - 273.15;

            e = C3(mass[2].X, mass[2].Y, t_p);
            ResultLen += Console.WriteLine("Участок C {0:#0.##}m и {1}°C", Lmin, trass);
            HiComerce[2] = Ttmax - 273.15;

            e = C3(mass[3].X, mass[3].Y, t_p);
            ResultLen += Console.WriteLine("Участок D {0:#0.##}m и {1}°C", Lmin, trass);
            HiComerce[3] = Ttmax - 273.15;

            e = C3(mass[4].X, mass[4].Y, t_p);
            ResultLen += Console.WriteLine("Участок E {0:#0.##}m и {1}°C", Lmin, trass);
            HiComerce[4] = Ttmax - 273.15;

            return maxDegres;
        }

        internal double[] HiComerce;

        private PointD C3(double a, double b, double temper)
        {
            var flag = !false;

            var lenArr = 7000;
            var C1i = new double[lenArr];
            C1i[0] = Form1._C1_нафВх;
            var C2i = new double[lenArr];
            C2i[0] = Form1._C2_О2вв;
            var C3i = new double[lenArr];
            C3i[0] = 0.0;//_C3_вых;
            var Ti = new double[lenArr];
            Ti[0] = 650.0;//Кельвин//Tвх
            var _dL = 0.001;
            var limitC3 = ((4.0 * Form1._p) / (100.0 * 0.148));// 4%==>0.37моль\м3

            var Qp1 = 1.47 * Math.Pow(10, 7);
            var Qp2 = 1.4 * Math.Pow(10, 8);
            var Qp3 = 19.6 * Math.Pow(10, 6);

            //var temper = 260;//Цельси
            var Tt = temper + 273.15;//в кельвин

            var j = a;//для шага по трубе [0..max]
            
            for (int i = 1; j < b; i++)
            {
                var k1 = K1(Ti[i - 1] - 273.15);//в цельси т.к. метод преобразует
                var k2 = K2(Ti[i - 1] - 273.15);
                var k3 = K3(Ti[i - 1] - 273.15);

                
                var rp1 = k1 * C1i[i - 1] * C2i[i - 1];//_C1_нафВх * _C2_О2вв;
                var rp2 = k2 * C1i[i - 1] * C2i[i - 1] * C3i[i - 1];//_C1_нафВх * _C2_О2вв * _C3_вых;
                var rp3 = k3 * C1i[i - 1] * C2i[i - 1];//_C1_нафВх * _C2_О2вв;

                Ti[i] = Ti[i - 1] +
                        ((rp1*Qp1)/(_Ct*_p) - ((4*_Kt)/(_Ct*_p*_D))*(Ti[i - 1] - Tt) + (rp2*Qp2)/(_Ct*_p) +
                         (rp3*Qp3)/(_Ct*_p))/_U*_dL;

                C1i[i] = C1i[i - 1] + (-2.0*k1*C1i[i - 1]*C2i[i - 1] - k2*C1i[i - 1]*C2i[i - 1])/_U*_dL;
                C2i[i] = C2i[i - 1] +
                         (-9.0*k1*C1i[i - 1]*C2i[i - 1] - 12.0*k2*C1i[i - 1]*C2i[i - 1] - 9.0*k3*C3i[i - 1]*C2i[i - 1])/
                         _U*_dL;
                C3i[i] = C3i[i - 1] + (-k3*C3i[i - 1]*C2i[i - 1] + 2.0*k1*C1i[i - 1]*C2i[i - 1])/_U*_dL;

                var res = C3i[i];

                j += _dL;//шаг по трубе

                //Если достигнут порог вещества на выходе
                if (res >= limitC3)//моль\м3 >= моль\м3
                {
                    if (j < (b - a))
                    {
                        //поднять температуру
                        //Tt += 283.15;// 10°C=283.15 Kельвин
                        Ttmax = Tt;
                        trass = temper;
                        Lmin = j;
                        normal.Add(temper);
                        return new PointD(j, Tt);
                    }
                    else//иначе переход на след отрезок
                    {
                        Ttmax = Tt;
                        trass = temper;
                        Lmin = j;
                        normal.Add(temper);
                        return new PointD(j, Tt);
                    }
                    
                }
                
            }

            C3(a, b, temper + 1.0);

            return new PointD(j, Ttmax);
        }

        #region Расчер k

        /// <summary>
        /// k1=A1exp(-E1/RTt)
        /// </summary>
        /// <returns></returns>
        private double K1(double Tt)
        {
            //+градус в кельвин
            return Form1._A1 * Math.Exp(-Form1._E1 / (Form1._R * (Tt + 273.15)));
        }

        /// <summary>
        /// k2=A2exp(-E2/RTt)
        /// </summary>
        /// <returns></returns>
        private double K2(double Tt)
        {
            return Form1._A2 * Math.Exp(-Form1._E2 / (Form1._R * (Tt + 273.15)));
        }

        /// <summary>
        /// k3=A3exp(-E3/RTt)
        /// </summary>
        /// <returns></returns>
        private double K3(double Tt)
        {
            return Form1._A3 * Math.Exp(-Form1._E3 / (Form1._R * (Tt + 273.15)));
        }

        #endregion
        
        private double Ttmax=0;
        private double trass = 0;
        private double Lmin = 0;

        internal PointPairList _list = new PointPairList();
        private List<double> normal = new List<double>();

        internal string ResultLen { get; set; }
        internal int[] Temperature { get; set; }
        internal string ResultDxt { get; set; }

    }

    class Console
    {
        public static string WriteLine(string msg, double val, params object[] a)
        {
            return String.Format(msg, val==0?' ':val, a.Length>0?a[0]:' ')+Environment.NewLine;
        }
    }

    /// <summary>
    /// Класс Точки для хранения [X;Y]
    /// </summary>
    public class PointD
    {
        private static int index = 0;
        private double _x, _y;
        /// <summary>
        /// [x.X1; X2.y]
        /// </summary>
        public PointD(double x, double y)
        {
            _x = x;
            _y = y;
            //Console.WriteLine("new Point[X1={0:0.####}; X2={1:0.####}]", x, y);
            index++;
        }
        /// <summary>
        /// [Point]
        /// </summary>
        public PointD(PointD A)
        {
            _x = A.X;
            _y = A.Y;
            //Console.WriteLine("new Point[X1={0:0.####}; X2={1:0.####}]", x, y);
            index++;
        }

        public double X { get { return _x; } set { _x = value; } }
        public double Y { get { return _y; } set { _y = value; } }

        public override string ToString()
        {
            return index.ToString();
        }

        public static PointD operator +(PointD x1, PointD x2)
        {
            return new PointD(x1.X + x2.X, x1.Y + x2.Y);
        }

        public static PointD operator /(PointD x1, double x2)
        {
            return new PointD(x1.X / x2, x1.Y / x2);
        }

    }

    

}
