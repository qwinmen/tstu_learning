using System;

//Вариант 17 конгратуэнтный метод - генератор
namespace Razbor
{
    /// <summary>
    /// метод генератор
    /// </summary>
    class clГСЧ
    {
        
        //Количество чисел ряда
        private int _N = 200;
        //дисперсия:
        private double _G0 = 0.4;
        private double _a0 = 0.071;
        //задать 1
        private double _A1 = 1d;
        //математическое ожидание:
        private double _M0 = 1.0;
        //длина трубы в статике
        private double _Lmin = 2.8;//m
        //скорость распространения в трубе
        private double _U = 0.1;//m\c

        public clГСЧ()
        {
            double x0 = _N;
            //случайный ряд:
            var arrL = new double[_N];
            //центрируем ряд
            arrL = Xi(arrL, ref x0);

            var sum = 0.0;
            for (int i = 0; i < _N; i++)
                sum += arrL[i];

            //Расчитать матожидание Mx
            var Mx = this.Mx(sum);

            double w = 0.0;
            double sun = 0.0;

            for (int i = 0; i < _N; i++)
                w = Math.Pow((arrL[i] - Mx), 2);
            sun += w;

            var z = new double[1590];//Случайный процес
            var v = 0.0;
            double Ns = 10.0;
            var tauSrednee = _Lmin / _U;    //среднее время пребывания, c
            z = Z(arrL, (int) Ns, 0.0);

            NaGrafik = new PointD[_N-10];
            for (int i = 0; i < _N-10; i++)
                NaGrafik[i] = new PointD(i, z[i]);

            //рассчитаные случайные процессы вернуть на метод характеристик
            ГСЧрезульт = z;
        }

        internal double [] ГСЧрезульт { get; set; }

        /// <summary>
        /// Расчитать случайный процесс z(t)=>z(k)
        /// k=1, Ns=200
        /// K = 0.4exp(-0.071dt)
        /// </summary>
        /// <returns></returns>
        private double[] Z(double[] arr, double Ns, double tauSrednee)
        {
            var z = new double[_N];
            var v = 0d;
            //Расчитать случайный процесс z(t)=>z(k)
            for (int i = (int)tauSrednee; i < _N-10; i++)
            {
                for (int j = i; j < i + 10; j++)
                {   
                    v += arr[j] * _G0 * Math.Exp(-_a0 * (j - i));
                }
                z[i] = (_A1 / Ns * v + _M0);
                v = 0;
            }
            return z;
        }

        /// <summary>
        /// Расчитать матожидание Mx
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private double Mx(double sum)
        {
            return 1.0/_N*sum;
        }

        /// <summary>
        /// Расчитать X[0.._N]
        /// Центрированная последовательность случайных чисел
        /// </summary>
        private double[] Xi(double[] arrL, ref double x0)
        {
            //Центрированная последовательность случайных чисел
            for (int i = 0; i < _N; i++)
                arrL[i] = Metod(ref x0) - 0.5061;

            return arrL;
        }

        /// <summary>
        /// Найти лямбда[0.._N]
        /// Случайные числа
        /// </summary>
        private double Metod(ref double x)
        {
            const double m = 1000000.0;
            double a = 8; double inc = 65.0;
            x = ((a * x) + inc) % m;
            return x / m;
        }

        internal PointD[] NaGrafik { get; set; }
        

        
       

    }
}
