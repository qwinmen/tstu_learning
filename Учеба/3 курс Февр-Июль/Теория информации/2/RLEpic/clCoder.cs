using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RLEpic
{
    /// <summary>
    /// Выполнить сжатие
    /// </summary>
    class clCoder
    {
        public clCoder()
        {
        }

        /// <summary>
        /// char n = (char)Cods.n;
        /// </summary>
        private enum Cods
        {
            n = 10,
            t = 9,
            r = 13,
            
        }

        /// <summary>
        /// Разделители: \n=n // \t=t // \r=r
        /// </summary>
        private string RChar(char inCh)
        {
            string str = inCh.ToString();
            switch (inCh)
            {
                case 'n':
                    str = ((char) Cods.n).ToString();
                    break;
                case 'r':
                    str = ((char) Cods.r).ToString();
                    break;
                case 't':
                    str = ((char) Cods.t).ToString();
                    break;
                case '-':
                    str = "";
                    break;
            }
            return str;
        }

        /// <summary>
        /// Выполнить компрессию содержимого массива array
        /// Схема 1
        /// </summary>
        /// <param name="array">Что сжимать</param>
        /// <param name="x">Размер массива на входе</param>
        /// <param name="y">Размер массива на входе</param>
        /// <param name="razd1">первый разделитель</param>
        /// <param name="razd2">второй разделитель</param>
        /// <returns>Вернет сжатый массив</returns>
        internal int[,] Compress(int[,] array, int x, int y, char razd1, char razd2)
        {
            //Разделители: \n=n // \t=t // \r=r
            var razdel1 = RChar(razd1);
            var razdel2 = RChar(razd2);
            int pls = razdel1!=""? 3 : 2;
            if (razdel2 != "") pls++;
            

            //Выходной массив может быть Меньше или Больше Входного
            int maxXLength = 0;//самая длинная строка
            int povtorVal = 0;//счетчик повторов
            int tmpVal = 0;//временный символ
            List<string> outarr = new List<string>();
            List<int> val = new List<int>();
            int[] len = new int[y];
            int[,] retArr = new int[x * pls, y];

            //у строк по х столбцов
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (j == 0)
                    {
                        tmpVal = array[j, i];//начало строки берем первый символ
                        len[i] = maxXLength;
                        povtorVal = 0;
                        povtorVal++;
                        Koeff += maxXLength;
                        maxXLength = 0;
                    }
                    else//иначе сравним символ с тикущим
                    {
                        if (tmpVal == array[j, i])//если предыдущий равен текущему
                        {
                            povtorVal++;
                            if (povtorVal == x)//если вся строка из повторного символа
                            {
                                //outarr.Add(povtorVal + razdel1 + tmpVal + razdel2);
                                val.Add(povtorVal);
                                if (razdel1 != "") val.Add(Convert.ToChar(razdel1));
                                val.Add(tmpVal);
                                if (razdel2 != "") val.Add(Convert.ToChar(razdel2));

                                povtorVal = 0;
                                maxXLength += pls;
                                len[i] = maxXLength;
                            }
                            else if (j == x - 1 && povtorVal > 0)//не вся строка но конец
                            {
                                //outarr.Add(povtorVal + razdel1 + tmpVal + razdel2);
                                val.Add(povtorVal);
                                if (razdel1 != "") val.Add(Convert.ToChar(razdel1));
                                val.Add(tmpVal);
                                if (razdel2 != "") val.Add(Convert.ToChar(razdel2));

                                povtorVal = 0;
                                maxXLength += pls;
                                len[i] = maxXLength;
                            }
                        }
                        else//неравен
                        {
                            if (povtorVal == 0) povtorVal++;
                            //outarr.Add(povtorVal + razdel1 + tmpVal + razdel2);
                            val.Add(povtorVal);
                            if(razdel1!="") val.Add(Convert.ToChar(razdel1));
                            val.Add(tmpVal);
                            if (razdel2 != "") val.Add(Convert.ToChar(razdel2));
                            
                            maxXLength += pls;
                            len[i] = maxXLength;
                            tmpVal = array[j, i];
                            if (j == x - 1)
                            {
                                //outarr.Add(1 + razdel1 + tmpVal + razdel2);
                                val.Add(1);
                                if (razdel1 != "") val.Add(Convert.ToChar(razdel1));
                                val.Add(tmpVal);
                                if (razdel2 != "") val.Add(Convert.ToChar(razdel2));

                                maxXLength += pls;
                                len[i] = maxXLength;
                            }

                            povtorVal = 1;
                        }
                    }
                }

                int er = 0;
                //переход на след строку//заполнить массив сжатыми значениями
                foreach (int i1 in val)
                {
                    retArr[er, i] = i1;
                    er++;
                }
                val.Clear();
            }
            maxXLength = len.Max();
            XY = new Point(y, x * pls);
            ArrToSaveFile = retArr;

            if (x * y * pls>= Koeff)
            {
                double tmp = (Koeff / (x * y * pls)) * 100.0;
                Koeff = Math.Round(tmp, 2);
            }
            else
            {
                double tmp = ((x * y * pls) / Koeff) * 100.0;
                Koeff = Math.Round(tmp, 2);
            }
            

            len = null;
            outarr.Clear();
            return retArr;
        }

        /// <summary>
        /// Определить коэф сжатия
        /// Передать в лейбл
        /// Длина строки+разделители
        /// </summary>
        internal double Koeff { get; set; }

        /// <summary>
        /// Передать для сохранения в файл
        /// </summary>
        internal int[,] ArrToSaveFile { get; set; }

        /// <summary>
        /// Размерность сжатого массива
        /// </summary>
        internal Point XY { get; set; }

        /// <summary>
        /// Выполнить компрессию содержимого массива array
        /// Схема 2
        /// </summary>
        /// <param name="array">Что сжимать</param>
        /// <param name="x">Размер массива на входе</param>
        /// <param name="y">Размер массива на входе</param>
        /// <returns>Вернет сжатый массив</returns>
        internal int[,] Compress(int[,] array, int x, int y)
        {
            int[,] retArr = null;

            return retArr;
        }


    }
}
