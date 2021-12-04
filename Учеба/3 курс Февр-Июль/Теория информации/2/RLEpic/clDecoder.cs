using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RLEpic
{
    /// <summary>
    /// Выполнить распаковку
    /// </summary>
    class clDecoder
    {
        public clDecoder()
        {}

        /// <summary>
        /// Восстановить сжатые последовательности
        /// На вход массив из clFile->LoadProjectCoder()
        /// </summary>
        internal int[,] DeCodArr(out int xLen, out int yLen, int[,] codArr, Point xyCodArr, int sxemaRazbora)
        {
            //sxemaRazbora влияет на то в какой ячейке\ках codArr ставится разделитель
            //sxemaRazbora=2::[povt|0][znak|1][razd2|2]
            //значения в sxemaRazbora=2 не распаковывать\не обрабатывать на вывод

            //№-строки И int[] значений
            Dictionary<int, int[]> decod = new Dictionary<int, int[]>();
            int maxStrLen = 0;//самая длинная цепоцка

            for (int j = 0; j < xyCodArr.Y; j++)//по строке
            {
                string posled = "";
                for (int i = 0; i < xyCodArr.X; i += (sxemaRazbora + 1)) //по ячейке в строке
                {
                    //повторы
                    int colPovtr = codArr[i, j]; //0//3
                    //знак
                    int znak = codArr[i + 1 , j]; //0+1//3+1

                    //распаковать знак N-раз
                    for (int k = 0; k < colPovtr; k++)
                    {
                        posled += znak;//цепочка из 0 и 1
                    }
                }

                if (maxStrLen < posled.Length) maxStrLen = posled.Length;

                var tmp = new int[posled.Length];
                for (int i = 0; i < tmp.Length; i++)
                {//пишем по символам//в строке 0 или 1
                    tmp[i] = int.Parse(posled[i].ToString());
                }

                decod.Add(j, tmp);
            }

            int[,] array = new int[maxStrLen, xyCodArr.Y];

            //перегнать <j, int[i]> в int[i, j]
            for (int j = 0; j < xyCodArr.Y; j++)
            {
                int[] tmp = decod[j]; //j-строка = []

                for (int i = 0; i < tmp.Length; i++)
                {
                    array[i, j] = tmp[i];
                }
            }

            //выходные значения для холста
            xLen = maxStrLen;
            yLen = xyCodArr.Y;//строк
            decod.Clear();

            //на холст
            return array;
        }


    }
}
