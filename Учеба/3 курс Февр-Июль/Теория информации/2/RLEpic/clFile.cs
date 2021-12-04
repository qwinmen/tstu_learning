using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace RLEpic
{
    /// <summary>
    /// Работа с текстовым файлом
    /// </summary>
    class clFile
    {
        public clFile()
        {}

        /// <summary>
        /// Сохранить
        /// </summary>
        /// <param name="fullpath">Куда сохранить</param>
        /// <param name="array">Что сохранить</param>
        /// <param name="x">длинна строки</param>
        /// <param name="y">длинна столбца</param>
        /// <param name="xLen">out array.Len.X</param>
        /// <param name="yLen">out array.Len.Y</param>
        internal void SaveProject(string fullpath, int[,] array, int x, int y, int xLen, int yLen)
        {
            StreamWriter streamWriter = File.CreateText(fullpath);
            //все что больше рамки x;y обрежится
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (j < xLen && i < yLen) streamWriter.Write(array[j, i]);
                    else streamWriter.Write(0);
                }
                streamWriter.WriteLine();
            }

            streamWriter.Close();
        }

        /// <summary>
        /// Сохранить
        /// </summary>
        /// <param name="fullpath">Куда сохранить</param>
        /// <param name="array">Что сохранить</param>
        /// <param name="x">длинна строки</param>
        /// <param name="y">длинна столбца</param>
        /// <param name="xLen">out array.Len.X</param>
        /// <param name="yLen">out array.Len.Y</param>
        internal void SaveProjectCoder(string fullpath, int[,] array, int x, int y, int xLen, int yLen, char razdel2)
        {
            //найти последний разделитель в массиве и сохранять строки до этого разделителя
            int razd2 = RChar(razdel2);
            StreamWriter streamWriter = File.CreateText(fullpath);

            //все что больше рамки x;y обрежится
            for (int i = 0; i < x; i++)
            {
                var tmp = new int[y];
                for (int j = 0; j < y; j++)
                    if (i < xLen && j < yLen)
                        tmp[j] = array[j, i];
                var stop = Array.LastIndexOf(tmp, razd2);
                int indx = 0;
                var flagW = false;
                foreach (int i1 in tmp.TakeWhile(i1 => indx <= stop))
                {
                    streamWriter.Write(i1);
                    indx++;
                    flagW = true;
                }

                if (flagW) streamWriter.Write("00"); else streamWriter.Write(razd2);
                //for (int j = 0; j < y; j++)
                {
                    //пишем по символьно int
                    //if (i < xLen && j < yLen) streamWriter.Write(array[j, i]);
                    //else streamWriter.Write("");
                }
                //новая строка
                streamWriter.WriteLine();
            }

            streamWriter.Close();
        }

        /// <summary>
        /// Загрузить содержимое файла
        /// </summary>
        /// <param name="xLen">размер массива</param>
        /// <param name="yLen">размер массива</param>
        /// <param name="fullPatch">путь до файла</param>
        /// <param name="flagCod">Грузим некодированный?</param>
        /// <returns>Массив со значениями</returns>
        internal int[,] LoadProject(out int xLen, out int yLen, string fullPatch, bool flagCod)
        {
            int[,] array = null;
            var list = new List<int[]>();
            
            var buff = new char[1];
            int i = 0, j = 0;
            var rxNums = new Regex(@"^\d+$"); // любые цифры
            var strReader = new StreamReader(fullPatch);

            //определить длинну строки для массива
            var tmpStr = strReader.ReadLine();
            strReader.Close(); strReader = new StreamReader(fullPatch);
            var arr = new int[tmpStr == null ? 0 : tmpStr.Length];

            //Грузим файл некодированный?
            //будут ли в файле символы разделители?
            if (flagCod)
                while (strReader.Peek() >= 0)
                {
                    strReader.Read(buff, 0, 1);
                    
                    //если это число то его преобразуем из символа в число
                    if (rxNums.IsMatch(buff[0].ToString()))
                    {
                        arr[i] = int.Parse(buff[0].ToString());
                        i++;
                    }

                    if (i == tmpStr.Length)
                    {
                        list.Add(arr);
                        arr = new int[i];
                        i = 0;
                    }
                }

            array = new int[arr.Length,list.Count];

            foreach (int[] intse in list)//10 0 6 1
            {
                for (int k = 0; k < intse.Length; k++)
                {
                    array[k, j] = intse[k];
                }
                j++;
            }
            

            strReader.Close();
            xLen = arr.Length; 
            yLen = list.Count;
            arr = null;
            list.Clear();

            return array;
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
        private int RChar(char inCh)
        {
            int str = inCh;
            switch (inCh)
            {
                case 'n':
                    str = (int)Cods.n;
                    break;
                case 'r':
                    str = (int)Cods.r;
                    break;
                case 't':
                    str = (int)Cods.t;
                    break;
                case '-':
                    str = -1;
                    break;
            }
            return str;
        }


        /// <summary>
        /// Грузим сжатый файл
        /// </summary>
        /// <param name="xLen">Количество столбцов</param>
        /// <param name="yLen">Количество строк</param>
        /// <param name="fullPatch">Полный путь до файла</param>
        /// <param name="flagCod">false</param>
        /// <returns>массив значений с ра3делителями</returns>
        internal int[,] LoadProjectCoder(out int xLen, out int yLen, string fullPatch, bool flagCod, char razdel1, char razdel2)
        {
            if (flagCod) throw new Exception("Этот файл не сжат!");

            int[,] array = null;
            List<string> listStr = new List<string>();//лист для строк из файла
            int maxStrLen = 0;//самая длинная строка

            //считать первую строку//определить длинну
            var strReader = new StreamReader(fullPatch);
            while (strReader.Peek() >= 0)
            {
                string tmp = strReader.ReadLine();

                if (tmp != null)
                    if (tmp.Length > maxStrLen) maxStrLen = tmp.Length;

                listStr.Add(tmp);
            }
            strReader.Close();

            //если -1 то не использовать этот разделитель!
            int razd1 = RChar(razdel1);
            int razd2 = RChar(razdel2);
            //определить схему разбора в зависимости от разделителей

            array = new int[maxStrLen, listStr.Count];
            int index = 0;
            //берем первую строку листа
            foreach (string s in listStr)
            {
                //разобрать по схеме
                int[] tmp = RazborkaStr(s, razd1, razd2, maxStrLen);//80 10 211 0 11 010 11 10 780 10 + [00000000]
                
                for (int i = 0; i < tmp.Length; i++)
                    array[i, index] = tmp[i];

                index++;
            }

            xLen = maxStrLen;
            yLen = listStr.Count;
            listStr.Clear();

            XY = new Point(xLen, yLen);
            CoderArr = array;

            return array;//массив уйдет на холст!!
        }

        /// <summary>
        /// Массив для разобранных кодов 
        /// </summary>
        internal int[,] CoderArr { get; set; }
        /// <summary>
        /// X=количество столбцов
        /// Y=количество строк
        /// CoderArr[X, Y]
        /// </summary>
        internal Point XY { get; set; }
        /// <summary>
        /// По какому варианту был разбор
        /// </summary>
        internal int ShemaRazbora { get; set; }
        
        /// <summary>
        /// Разобрать на части строку
        /// </summary>
        private int[] RazborkaStr(string str, int razdel1, int razdel2, int maxStrLen)
        {
            int chems = -1;
            if (razdel1 == -1 && razdel2 == -1)//схема 1
                chems = 1;
            else if(razdel1 == -1 && razdel2 != -1)//схема 2
                chems = 2;
            else if(razdel1 != -1 && razdel2 == -1)//схема 3
                chems = 3;
            else if(razdel1 != -1 && razdel2 != -1)//схема 4
                chems = 4;

            List<int> povt = new List<int>();
            List<int> znak = new List<int>();
            List<int> razd = new List<int>();
            int lenRazd = razdel2.ToString().Length;

            int[] arrey = new int[maxStrLen];
            for (int i = 0; i < arrey.Length; i++)
                arrey[i] = 0;//для выравнивания строк использую 0 как паразитный символ в конце

            switch (chems)
            {
                case 1://razdel1 == -1 && razdel2 == -1
                    ShemaRazbora = 1;
                    throw new Exception("Эта схема невозможна для восстановления!");
                    break;
                case 2:
                    {
                        ShemaRazbora = 2;
                        bool flag = true;
                        //находим последний разделитель
                        int lastIndxRazd2 = str.LastIndexOf(razdel2.ToString());

                        while (lastIndxRazd2 != -1 && lastIndxRazd2 != 0)
                        {
                            if (lastIndxRazd2 <= -2) break;
                            //обрезать строку - откинуть последний разделитель
                            string sub = str.Remove(lastIndxRazd2);
                            //найти последний разделитель в обрезанной строке
                            lastIndxRazd2 = sub.LastIndexOf(razdel2.ToString());


                            //добавим последний разделитель
                            razd.Add(razdel2);
                            if (lastIndxRazd2 == sub.Length - lenRazd && flag)
                            {//то lastIndxRazd2 указыкает на повтор+знак
                                if (lastIndxRazd2 == sub.IndexOf(razdel2.ToString()))
                                {
                                    string pvtr = sub; //110
                                    povt.Add(int.Parse(pvtr.Remove(pvtr.Length - 1))); //11
                                    znak.Add(int.Parse(pvtr[pvtr.Length - 1].ToString())); //0 or 1
                                    lastIndxRazd2 = lastIndxRazd2 - lenRazd;
                                    flag = false;
                                }
                                else
                                {//"80102110 110"
                                    string pvtr = sub.Remove(0, lastIndxRazd2); //840

                                    string repit = sub.Remove(lastIndxRazd2);//вырезать конец pvtr
                                    int dupl = repit.LastIndexOf(razdel2.ToString());//теперь где 10
                                    int rez = repit.Length - (dupl + lenRazd);//1 неможет быть!

                                    if (pvtr == razdel2.ToString() && rez == 1)
                                    {
                                        pvtr = sub.Remove(0, (dupl + lenRazd));//110
                                        povt.Add(int.Parse(pvtr.Remove(pvtr.Length - 1))); //84
                                        znak.Add(int.Parse(pvtr[pvtr.Length - 1].ToString())); //0 or 1
                                        lastIndxRazd2 = dupl;//lastIndxRazd2 - lenRazd;
                                    }
                                    else
                                    {
                                        povt.Add(int.Parse(pvtr.Remove(pvtr.Length - 1))); //84
                                        znak.Add(int.Parse(pvtr[pvtr.Length - 1].ToString())); //0 or 1
                                        lastIndxRazd2 = lastIndxRazd2 - lenRazd;
                                    }
                                    flag = false;
                                }
                            }
                            else
                            {//то lastIndxRazd2 указывает на разделитель
                                if (lastIndxRazd2 > 0)
                                {
                                    string pvtr = sub.Remove(0, lastIndxRazd2 + lenRazd);//840
                                    if (pvtr == "")//если пусто тогда смещаемся на lenRazd
                                        pvtr = sub.Remove(0, lastIndxRazd2 - lenRazd);

                                    if (pvtr.Length == 1)
                                    {
                                        int lst = sub.LastIndexOf(razdel2.ToString());
                                        pvtr = sub.Remove(0, lst);
                                        lastIndxRazd2 = lst - lenRazd;
                                    }
                                    povt.Add(int.Parse(pvtr.Remove(pvtr.Length - 1)));//84
                                    znak.Add(int.Parse(pvtr[pvtr.Length - 1].ToString()));//0 or 1
                                }
                                else
                                {
                                    povt.Add(int.Parse(sub.Remove(sub.Length - 1)));//10
                                    znak.Add(int.Parse(sub[sub.Length - 1].ToString()));//0 or 1
                                }
                                flag = true;
                            }
                        }//end while()

                        //раскинуть значения листов в массив
                        //arrey[0]=povt[0]//arrey[1]=znak[0]//arrey[2]=razd[0]//[00000000]
                        int index = 0;
                        znak.Reverse();
                        povt.Reverse();

                        for (int i = 0; index < povt.Count; i+=3)
                        {
                            arrey[i] = povt[index];//0//3
                            arrey[i+1] = znak[index];
                            arrey[i+2] = razd[index];
                            index++;
                        }

                        return arrey;
                    }
                    break;
                case 3:
                    ShemaRazbora = 3;
                    break;
                case 4:
                    ShemaRazbora = 4;
                    break;
            }

            return arrey;
        }

    }
}
