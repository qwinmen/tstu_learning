using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeCriptoBag
{
    class clDeCropto
    {
        public clDeCropto(){}

        internal string Decript(int n, int m, string codText, string CloseKey)
        {
            if (CloseKey.Length < 1 || n == -1 || m == -1 || codText.Length < 1) return "";

            var x = ReversN(n, m);

            var bitRes = "";

            foreach (var s in codText.Split(' '))
            {
                var val = 0;
                if (!int.TryParse(s, out val)) continue;

                val = (val*x)%m;//итоговое 174*61 mod 105 = 9
                var arrInt = new List<int>();
                //берем числа закрытого ключа меньше val
                foreach (var elemK in CloseKey.Split(' '))
                {
                    var elem = 0;
                    if (!int.TryParse(elemK, out elem)) continue;
                    if(elem > val) break;

                    arrInt.Add(elem);
                }

                //сумма чисел из массива должна равняться val
                //val 9 = 3 + 6 arrInt
                //если val = 0 то 0000.len = CloseKey.Split(' ').Len
                var resListLinks = new List<string>();
                var indx = arrInt.BinarySearch(val);
                //2 5 10
                if(indx<0) resListLinks = SearchSum(arrInt, val);
                var des = resListLinks.Aggregate("", (current, resListLink) => current + (resListLink + " "));
                bitRes += BinBlocks(CloseKey, (indx < 0) ? des : arrInt[indx].ToString()) + " ";
            }

            return ConvertToText(bitRes);
        }

        /// <summary>
        /// Перевести текст в двоичный вид
        /// </summary>
        /// <param name="txtIn"></param>
        internal string ConvertToText(string binaryStr)
        {
            //готовые бинарные блоки "000100 100000 010000 "
            //binaryStr = "00010010 00000100 00000000";
            var newString = "";
            var remSpb = binaryStr.Replace(" ", "");
            const int value = 8;
            for (int k = 0, indx = 0; k < Math.Ceiling((double)remSpb.Length) / value; k++, indx += value)
            {
                //дополнить блок до длины value
                if (indx + value > remSpb.Length) remSpb = remSpb.PadRight(indx + value, '0');
                var part = remSpb.Substring(indx, value);//0..8
                newString += part + " ";
            }

            //Процесс восстановление из бинарного в строку:
            var sd = new byte[newString.Split(' ').Length];
            int i = 0;
            foreach (string s in newString.Split(' '))
            {
                if (s.Length > 0)
                    sd[i] = Convert.ToByte(s, 2);
                i++;
            }

            return encUnic.GetString(sd);
        }

        private static Encoding encUnic = Encoding.Unicode;

        /// <summary>
        /// Бинарные блоки
        /// </summary>
        /// <param name="CloseKey"></param>
        /// <param name="block"></param>
        /// <returns></returns>
        private string BinBlocks(string CloseKey, string block)
        {
            var sumBlock = "";
            int index = 0;
            var el = "";
            {//5
                //когда indx указывает на ячейку с значением в ключе
                //2 4 5 6..  indx=5  ==> 0 0 1 0 ..
                foreach (var ch in CloseKey.Split(' '))//4 7 15 28 57 114 229 
                {
                    if(ch=="")continue;
                    if (index < block.Split(' ').Length) el = block.Split(' ')[index];
                    if (ch == el)//присутствие
                    {
                        sumBlock += "1";
                        index++;
                    }
                    else sumBlock += "0";
                }
            }

            return sumBlock;
        }

        /// <summary>
        /// Найти элементы ключа, дающие в сумме значение value
        /// </summary>
        /// <param name="arr"></param>
        /// /// <param name="value"></param>
        /// <returns>Вернет последовательности</returns>
        private List<string> SearchSum(List<int> arr, int value)
        {
            //arr = new List<int>() { 2, 3, 6, 13, 27, 52, 105, 210 };
            var links = new List<string>();//для элементов
            //var result = new List<int>();//для сумм
            var razn = value;
            //берем самое крайнее число - оно и самое большое
            for (int i = arr.Count - 1; i >= 0; i--)
            {
                var elem = arr[i];
                if (elem > razn) continue;
                links.Add(elem.ToString());//ложим первым самый большой
                razn = razn - elem;//204-113
                //result.Add(razn);
                if (razn == 0)
                {//Значения с большего к меньшему необходимо переставить
                    links.Reverse();
                    //значения от меньшего к большему
                    return links;
                }
                
            }
            
            //Иначе не сходится!На нулях например
            return links;
        }

        /// <summary>
        /// Подобрать обратное n число
        /// </summary>
        /// <param name="n">31</param>
        /// <param name="m">105</param>
        /// <returns></returns>
        private int ReversN(int n, int m)
        {
            var X = -1;
            //подобрать обратное число n
            for (int i = 1; i < m/*int.MaxValue*/; i++)
            {
                if ((n * i) % m != 1) continue;
                X = i;
                break;
            }
            if (X == -1) new Exception("Не подобрано обратное n число!");
            return X;
        }






    }
}
