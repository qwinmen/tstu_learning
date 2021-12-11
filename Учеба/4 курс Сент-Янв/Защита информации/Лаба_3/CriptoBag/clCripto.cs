using System;
using System.Linq;
using System.Text;

namespace CriptoBag
{
    class clCripto
    {
        public clCripto(){}

        /// <summary>
        /// Сгенерит закрытый ключ
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        public void Cripto(int value, out string key, out int m, out int n)
        {
            //вычислить стартовый закрытый ключ
            key = GenerateCloseKey(value);
            m = this.m;
            n = this.n;
            //вычислить открытую последовательность ключ
            _openKey = GenerateOpenKey(key, n, m);
        }

        /// <summary>
        /// Открытый ключ, внутренние операции
        /// </summary>
        private string _openKey { get; set; }

        /// <summary>
        /// Cгенерировать открытый ключ
        /// </summary>
        /// <param name="closeKey">Закрытый ключ</param>
        /// <param name="_n">Взаимно простое</param>
        /// <param name="_m">Сумма++</param>
        /// <returns></returns>
        private string GenerateOpenKey(string closeKey, int _n, int _m)
        {
            var resCloseKey = "";
            foreach (string val in closeKey.Split(' '))
            {
                var tmpKey = 0;
                if (int.TryParse(val, out tmpKey))
                    resCloseKey += (tmpKey * _n % _m) + " ";
            }
            return resCloseKey;
        }

        /// <summary>
        /// Закрытый ключ
        /// Cумма m=E++
        /// Взаимно простое n
        /// </summary>
        private string GenerateCloseKey(int value)
        {
            Random rnd = new Random();
            var sum = 2;
            var result = "";
            for (int i = 0; i < value; i++)
            {
                var element = rnd.Next(sum, sum + 3);//2..7
                sum += element;
                result += (element + " ");
                if (element < 0 || sum + value < 0) throw new ApplicationException("Элемент ключа в минусе! " + element);
            }
            //Выбрать m>E(res)
            m = rnd.Next(sum + 2, sum + value);
            n = rnd.Next(value, value+value);
            
            //Вычислить взаимно простое n
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    if (m % i == 0)/*найдено взаимно простое*/
                    {
                        n = rnd.Next(value, value * i);
                        i = 1;
                    }
                
            }
            return result;
        }

        /// <summary>
        /// m>E(res)
        /// </summary>
        internal int m { get; private set; }

        /// <summary>
        /// n - взаимно простое с m
        /// </summary>
        internal int n { get; private set; }

        /// <summary>
        /// Шифруем тексты
        /// </summary>
        /// <param name="text"></param>
        public void Cripto(string text, out string result, int value)
        {
            result = ConvertToBin(text, value);
        }

        /// <summary>
        /// Перевести текст в двоичный вид
        /// </summary>
        /// <param name="txtIn">Input string</param>
        /// <param name="value">Размер блока</param>
        internal string ConvertToBin(string txtIn, int value)
        {
            var sum = "";
            var sb = new StringBuilder();
            //текст==>10100011 10010101 ...
            foreach (byte b in Encoding.Unicode.GetBytes(txtIn))
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));//.Append(' ');//0000_100_' '
            //готовые бинарные блоки
            var binaryStrArr = sb.ToString();
            
            for (int i = 0, indx = 0; i < Math.Ceiling((double)binaryStrArr.Length / value); i++, indx+=value)
            {
                //дополнить блок до длины value
                if (indx + value > binaryStrArr.Length) binaryStrArr = binaryStrArr.PadRight(indx + value, '0');
                var part = binaryStrArr.Substring(indx, value);
                var index = 0;
                var sumBlock = 0;
                foreach (var ch in part)
                {
                    if (ch == '1')//присутствие
                        sumBlock += int.Parse(_openKey.Split(' ')[index]);
                    index++;
                }
                sum += sumBlock + " ";
            }
            
            return sum;
        }

        
        

    }
}
