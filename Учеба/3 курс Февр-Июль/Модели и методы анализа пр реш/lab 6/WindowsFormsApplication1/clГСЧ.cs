using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// метод произведений
    /// </summary>
    class clГСЧ
    {
        private string _l1 = 0.5549.ToString();
        private string _l2 = 0.2417.ToString();
        private double _m = 4;
        private int _N = 200;
        private string _G0 = 11.ToString();
        private string _a0 = 0.08.ToString();
        private string _A1 = 1.ToString();
        private string _A2 = 1.ToString();
        private string _M0 = 12.ToString();
        private string _Kz = 20.ToString();

        public clГСЧ()
        {
            //случайный ряд:
            var arrL = Metod();
            //центруем:
            var arrX = Xi(arrL);

            var Mx = this.Mx(arrX);
            var Gx = this.Gx(arrX, Mx);

            var zt = Z(arrX, Gx, 1, 200);
        }

        /// <summary>
        /// Расчитать случайный процесс z(t)=>z(k)
        /// k=1, Ns=200
        /// </summary>
        /// <returns></returns>
        private string Z(string[] arr, string Gx, int k, int Ns)
        {
            var sum = 0.0;
            var d = (double)(Convert.ToDecimal(_G0)/
                     (Convert.ToDecimal(Gx)*Convert.ToDecimal(_a0)*Convert.ToDecimal(_A2)*Convert.ToDecimal(_A1)));
            var sqrt = Math.Sqrt(d);
            var tmp = (double)(Convert.ToDecimal(_a0) * (-Convert.ToDecimal(_A2)));
            for (int i = 0; i < arr.Length; i++)
            {
                sum += (double)Convert.ToDecimal(arr[i])*sqrt*Math.Pow(Math.E, tmp*(i - k));
            }

            var t = (1.0 / Ns) * sum + double.Parse(_M0);
            return t.ToString();
        }

        /// <summary>
        /// Расчитать дисперсию Gx
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="Mx"></param>
        /// <returns></returns>
        private string Gx(string[] arr, string  Mx)
        {
            decimal sum = 0m;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += (Convert.ToDecimal(arr[i]) - Convert.ToDecimal(Mx))*
                       (Convert.ToDecimal(arr[i]) - Convert.ToDecimal(Mx));
            }
            var t = (1.0m / _N) * sum;
            return t.ToString();
        }

        /// <summary>
        /// Расчитать матожидание Mx
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private string Mx(string[] arr)
        {
            decimal sum = 0m;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += Convert.ToDecimal(arr[i]);
            }
            var t = (1.0m / _N) * sum;
            return t.ToString();
        }

        /// <summary>
        /// Расчитать X[0..200]
        /// Центрированная последовательность случайных чисел
        /// </summary>
        /// <param name="arr"></param>
        private string[] Xi(string[] arr)
        {
            var arrX = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                var x = Convert.ToDecimal(arr[i]) - 0.5061m;
                arrX[i] = x.ToString();
            }

            return arrX;
        }

        /// <summary>
        /// Найти лямбда[0..200]
        /// Случайные числа
        /// </summary>
        private string[] Metod()
        {
            var arr = new string[_N];
            arr[0] = _l1;
            arr[1] = _l2;
            string q = (Convert.ToDecimal(arr[0]) * Convert.ToDecimal(arr[1])).ToString();

            var tmpA = q.Split(',');
            if (tmpA.Length == 1) new Exception("целочисленное");
            if (tmpA[1].Length < _m) new Exception("это число меньше 4 знаков");

            var str = tmpA[1];
            while (str.Length > _m)
            {
                str = str.Remove(0, 1);
                str = str.Remove(str.Length-1);
            }
            str = "0," + str;
            var l = Convert.ToDecimal(str);
            arr[2] = l.ToString();

            for (int i = 1; i + 2 < arr.Length; i++)
            {
                q = (Convert.ToDecimal(arr[i]) * Convert.ToDecimal(arr[i+1])).ToString();
                tmpA = q.Split(',');
                if (tmpA.Length == 1) new Exception("целочисленное");
                if (tmpA[1].Length < _m) new Exception("это число меньше 4 знаков");

                str = tmpA[1];
                while (str.Length > _m)
                {
                    str = str.Remove(0, 1);
                    str = str.Remove(str.Length - 1);
                }
                str = "0," + str;
                l = Convert.ToDecimal(str);
                arr[i+2] = l.ToString();
            }

            return arr;
        }

    }
}
