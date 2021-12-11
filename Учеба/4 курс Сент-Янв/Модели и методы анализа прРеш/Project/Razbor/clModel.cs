using System;
using System.Collections.Generic;
using ZedGraph;

//17 varik
namespace Razbor
{
    class clModel
    {
        //--------------------

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

        //public const double _dL = 0.1;//метр
        public const double _U = 0.1;//м\с
        public const double _Ct = 1100;//Дж\кг*град
        public const double _p = 1.4;//кг\м3
        public const double _Kt = 500;//Вт\м2*град
        public const double _D = 0.025;//метр
        //----------------------

        private const double _deltaAlf = 0.01;
        private const double _deltaBet = 0.01;

        public const double _T = 650d;//Кельвин//Tвх

        //дисперсия:
        private double _G0 = 0.4;

        /// <summary>
        /// Метод характеристик
        /// </summary>
        /// <param name="ArrГСЧ">200 чисел с генератора</param>
        /// <param name="Lmin">минимальная длина трубы найдено в статике</param>
        public clModel(double[] ArrГСЧ, double Lmin)
        {
            var zz = new double[1000];
            var tay = new double[1000];
            var count = 0;

            var tao_Max = ArrГСЧ.Length*_U; //c

            var k1 = K1(_T);
            var k2 = K2(_T);
            var k3 = K3(_T);

            var C3_ang = new double[1000];
            var tauSrednee = Lmin/_U; //среднее время пребывания

            double C1;
            var C2 = 8.75; //моль\м3
            var C3 = 0.0;

            //Note: ВТОРАЯ ОБЛАСТЬ
            for (double B = 0; B < (tao_Max - tauSrednee)/2.0; B += _deltaBet)
            {
                if(count>=ArrГСЧ.Length)break;
                C1 = ArrГСЧ[count];
                C2 = 8.75;
                C3 = 0;

                for (double A = B; A < tauSrednee + B; A += _deltaAlf)
                {
                    C1 = C1 + ((-2*k1*C1*C2) - (k2*C1*C2))*_deltaAlf;
                    C2 = C2 + (-9.0*k1*C1*C2 - 12.0*k2*C1*C2 - 9.0*k3*C3*C2)*_deltaAlf;
                    C3 = C3 + (-k3*C3*C2 + k1*C1*C2)*_deltaAlf;
                    tay[count] = A + B;
                    zz[count] = _U*(A - B);
                }
                C3_ang[count] = C3;
                count++;
            }

            //Note: ТРЕТЬЯ ОБЛАСТЬ
            for (double B = (tao_Max - tauSrednee)/2; B < tao_Max/2; B += _deltaBet)
            {
                if (count >= ArrГСЧ.Length) break;
                C1 = ArrГСЧ[count];
                C2 = 8.75;
                C3 = 0;

                for (double A = B; A < tao_Max - B; A += _deltaAlf)
                {
                    C1 = C1 + ((-2*k1*C1*C2) - (k2*C1*C2))*_deltaAlf;
                    C2 = C2 + (-9.0*k1*C1*C2 - 12.0*k2*C1*C2 - 9.0*k3*C3*C2)*_deltaAlf;
                    C3 = C3 + (-k3*C3*C2 + k1*C1*C2)*_deltaAlf;
                    tay[count] = A + B;
                    zz[count] = _U*(A - B);
                }
            }


            NaGrafik2 = new PointD[ArrГСЧ.Length];
            for (int i = 0; i < ArrГСЧ.Length-10; i++)
            {
                //if (2.40 < zz[i] && zz[i] < 3.95) //рассматриваемый интервал
                    NaGrafik2[i] = new PointD(i, C3_ang[i]);
            }

        } 

        internal PointD[] NaGrafik2 { get; set; }
        
        #region Расчер k

        /// <summary>
        /// k1=A1exp(-E1/RTt)
        /// </summary>
        /// <returns></returns>
        public double K1(double Tt)
        {
            //+градус в кельвин
            return _A1 * Math.Exp(-_E1 / (_R * (Tt)));
        }

        /// <summary>
        /// k2=A2exp(-E2/RTt)
        /// </summary>
        /// <returns></returns>
        public double K2(double Tt)
        {
            return _A2 * Math.Exp(-_E2 / (_R * (Tt)));
        }

        /// <summary>
        /// k3=A3exp(-E3/RTt)
        /// </summary>
        /// <returns></returns>
        public double K3(double Tt)
        {
            return _A3 * Math.Exp(-_E3 / (_R * (Tt)));
        }

        #endregion
        

    }
}
