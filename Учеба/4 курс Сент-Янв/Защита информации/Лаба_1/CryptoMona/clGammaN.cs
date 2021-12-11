using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//http://www.altaev-aa.narod.ru/security/XOR.html
//http://edu.dvgups.ru/METDOC/ENF/PRMATEM/INFORMAT/METOD/KRIPTOGR_MET/Kom_4.htm
//http://edu.dvgups.ru/METDOC/ENF/PRMATEM/INFORMAT/METOD/KRIPTOGR_MET/Kom_5.htm
namespace CryptoMona
{
    /// <summary>
    /// Шифрование метод гаммирования по модулю N
    /// N - количество символов алфавита
    /// </summary>
    class clGammaN
    {
        public clGammaN(int n)
        {
            _N = n;
        }
        /// <summary>
        /// Колличество букв алфавита+цифр+пробел
        /// </summary>
        private int _N;

        /// <summary>
        /// Выполнить зашифровку входного текста
        /// </summary>
        /// <param name="textIn">Строка для шифровки</param>
        /// <param name="gamma">Ключ для шифровки</param>
        /// <param name="flag">true - режим шифровки вкл</param>
        internal string CriptoTextIn(string textIn, string gamma, bool flag)
        {
            //index+1 равен позиций символа в алфавите
            string alf = global::CryptoMona.Properties.Settings.Default.Ru;

            //выравниваем строки
            if (textIn.Length > gamma.Length) while (gamma.Length < textIn.Length) gamma += gamma;
            int i = textIn.Length;

            //перегнать символы в числа a=1, b=2, ...// 0 такого символа нет меняем на 34 пробел
            string numT =
                (textIn.Aggregate("",
                                  (current, c) =>
                                  current + (alf.IndexOf(c.ToString(), StringComparison.OrdinalIgnoreCase) + 1 + " "))).
                    Replace(" 0", " 34");
            string numG =
                (gamma.Aggregate("",
                                 (current, c) =>
                                 current + (alf.IndexOf(c.ToString(), StringComparison.OrdinalIgnoreCase) + 1 + " "))).
                    Replace(" 0", " 34");

            return !flag ? Cripto(numT, numG, i) : Decripto(numT, numG, i);
        }

        /// <summary>
        /// Формула (Символ[i]+Гамма[i])mod_N
        /// </summary>
        /// <param name="numT"></param>
        /// <param name="numG"></param>
        /// <returns></returns>
        private string Cripto(string numT, string numG, int index)
        {
            string alf = global::CryptoMona.Properties.Settings.Default.Ru;
            var t = numT.Split(' ');
            var g = numG.Split(' ');
            string outText = "";
            //складываем
            for (int i = 0; i < index; i++)
            {
                var sum = int.Parse(t[i]) + int.Parse(g[i]);
                var mod = sum%_N;
                t[i] = mod == 0 ? _N.ToString() : mod.ToString();
                //перегнать числа в буквы
                outText += alf[int.Parse(t[i])-1];
            }

            return outText;
        }

        /// <summary>
        /// Формула (Символ[i]-Гамма[i]+N)mod_N
        /// </summary>
        /// <param name="textIn"></param>
        /// <param name="gamma"></param>
        /// <returns></returns>
        private string Decripto(string numT, string numG, int index)
        {
            string alf = global::CryptoMona.Properties.Settings.Default.Ru;
            var t = numT.Split(' ');
            var g = numG.Split(' ');
            string outText = "";
            //складываем
            for (int i = 0; i < index; i++)
            {
                var ras = int.Parse(t[i]) - int.Parse(g[i]);
                var mod = (ras + _N)%_N;
                t[i] = mod == 0 ? _N.ToString() : mod.ToString();
                //перегнать числа в буквы
                outText += alf[int.Parse(t[i]) - 1];
            }

            return outText;
        }

    }
}
