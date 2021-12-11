using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//http://habrahabr.ru/post/116716/

namespace CryptoMona
{
    /// <summary>
    /// Шифр ADFGX
    /// </summary>
    class clAdfgx
    {
        
        public clAdfgx()
        {
            _list = new KeyValuePair<char, KeyValuePair<char, char>>[25];
        }

        private KeyValuePair<char, KeyValuePair<char, char>>[] _list;

        /// <summary>
        /// Получить таблицу с рандомным алфавитом
        /// </summary>
        /// <param name="listView_Aalf"></param>
        /// <returns></returns>
        internal ListView ListAlf(ListView listView_Aalf)
        {
            string alf = global::CryptoMona.Properties.Settings.Default.En;
            var rnd = new Random();
            var navigate = new [] {'A', 'D', 'F', 'G', 'X'};

            for (int j = 0, k = 0, indx = 0; j < alf.Length-1; j+=5, indx++)
            {
                var mass = new char[5];
                //пять букв
                string tmp = alf.Substring(j, 5);
                for (int i = 0; i < 5; i++)
                {
                    int pos;
                    //берем первую
                    char a = tmp[i];
                    do//проверить полученное
                    {//зарандомить
                        pos = rnd.Next(0, 5);
                    } while (!mass[pos].Equals('\0'));
                    //записать в ячейку
                    mass[pos] = a;
                }
                var item =
                    new ListViewItem(new[]
                                     {
                                         mass[0].ToString(), mass[1].ToString(), mass[2].ToString(), mass[3].ToString(),
                                         mass[4].ToString()
                                     });
                listView_Aalf.Items.Add(item);
                for (var i = 0; i < 5; i++, k++)
                {
                    _list[k] = new KeyValuePair<char, KeyValuePair<char, char>>(mass[i], new KeyValuePair<char, char>(navigate[indx], navigate[i]));
                }
                
            }
            
            return listView_Aalf;
        }

        /// <summary>
        /// Зашифровать сообщение
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        internal string Cripton(string text, string key, bool flagCriptoOn)
        {
            return flagCriptoOn ? Расшифровать(text, key) : Зашифровать(text, key);
        }

        private string Зашифровать(string textIn, string key)
        {
            //выдернуть все пробелы
            var txt = textIn.Replace(" ", "");
            //количество строк в массиве
            var len = Math.Ceiling(((double)(2 * txt.Length) / key.Length));
            var arr = new char[(int) len,key.Length];
            var flagGroupX = false; var flagGroupY = false;
            //Записать под ключем
            for (int i = 0, k = 0, groupXY = 0; i < (int)len; i++)//строки
            {
                for (int j = 0; j < key.Length; j++, groupXY++)//столбцы
                {
                    if (k == txt.Length) break;
                    if (groupXY % 2 == 0)
                    {
                        arr[i, j] = XY(txt[k]).Key;
                        flagGroupX = true;
                    }
                    else
                    {
                        arr[i, j] = XY(txt[k]).Value;
                        flagGroupY = true;
                    }
                    if (flagGroupX == flagGroupY)
                    {
                        k++;
                        flagGroupX = flagGroupY = false;
                    }
                }
            }

            //сортировать по алфавиту ключ и столбцы
            var akey = KeyAlfSort(key);
            
            //переставить столбцы
            return ReversColl(key, akey, arr, (int)len, key.Length);
        }

        /// <summary>
        /// Сортировка без учета регистра
        /// </summary>
        /// <param name="key">Строка для сортировки</param>
        /// <returns>Строка по алфавиту</returns>
        private string KeyAlfSort(IEnumerable<char> key)
        {
            var sort = key.OrderBy(n => n.ToString(), StringComparer.OrdinalIgnoreCase);
            return sort.Aggregate("", (current, srt) => current + srt);
        }

        /// <summary>
        /// Переставить столбцы ориентир ключ по алфавиту
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="akey">Отсортированный ключ</param>
        /// <param name="arr">Таблица координат</param>
        /// <param name="arrRow">Количество строк в таблице</param>
        /// <param name="arrCol">Количество столбцов в таблице</param>
        /// <returns>Вернет шифрованую последовательность</returns>
        private string ReversColl(string key, string akey, char[,] arr, int arrRow, int arrCol)
        {
            var arrNew = new char[arrRow, arrCol];

            //первый символ нового ключа//какой индекс у этого символа в исходном ключе
            for (var i = 0; i < key.Length; i++)
            {
                var chr = key[i];
                var indx = akey.IndexOf(chr, 0);
                
                akey = String.Concat(akey.Substring(0, indx+1).Replace(chr, ' '), akey.Substring(indx+1));//занулить найденое
                //по индексу найти столбец и записать первым
                for (var j = 0; j < arrRow; j++)//по строке
                    arrNew[j, i] = arr[j, indx];//[str, stolb]
            }
            //выписать по столбцам
            var res = "";
            for (var i0 = 0; i0 < arrCol; i0++)
                for (var i1 = 0; i1 < arrRow; i1++)
                    res += arrNew[i1, i0];
            //глушим пустые ячейки при key=3_5_7..
            return res.Replace('\0', '0');
        }

        private string Расшифровать(string textIn, string key)
        {
            if (textIn.Length % 2 != 0) return "";
            //ключ выстраиваем по алфавиту
            var akey = KeyAlfSort(key);
            
            //выдернуть все пробелы\неликвид<=>0
            //var txt = textIn.Replace("0", "");
            //количество строк в массиве
            var len = Math.Ceiling(((double)textIn.Length / key.Length));
            var arr = new char[(int)len, key.Length];
            
            //textIn записать по столбцам
            for (int i = 0, indx = 0; i < key.Length; i++)//фиксируем столбец
                for (var j = 0; indx < textIn.Length & j < (int)len; j++, indx++)//идем по строке
                    arr[j, i] = textIn[indx];

            //выполнить перестановку с восстановлением индексов по ключу
            //переставить столбцы
            var str = ReversColl(key, akey, arr, (int)len, key.Length);
            /*str = str.Replace("0", "");*/
            var arrOut = new char[(int)len, key.Length];
            
            //записать в столбцы
            for (int i = 0, indx = 0; i < key.Length; i++)//фикс столб
            {
                for (int j = 0; /*indx < str.Length & */j < (int)len; j++, indx++)//переб строк
                {
                    //[0,0]F [1,0]A [2,0]D [3,0]A
                    //FADA
                    arrOut[j, i] = str[indx];
                }
            }
            

            var strOut = "";
            var pairA = ' '; var pairB = ' ';
            var flagGroupX = false; var flagGroupY = false;
            for (int i = 0, groupXY = 0; i < (int)len; i++)//строки
            {
                for (int j = 0; j < key.Length; j ++, groupXY++)//cтолбцы
                {
                    
                    if (groupXY % 2 == 0)
                    {
                        pairA = arrOut[i, j];
                        flagGroupX = true;
                    }
                    else
                    {
                        pairB = arrOut[i, j];
                        flagGroupY = true;
                    }
                    if (flagGroupX == flagGroupY)
                    {
                        strOut += Simbol(new KeyValuePair<char, char>(pairA, pairB));
                        flagGroupX = flagGroupY = false;
                        pairA = ' '; pairB = ' ';
                    }
                    
                }
            }

            return strOut.Replace('0', ' ');
        }

        /// <summary>
        /// Запросить координаты символа
        /// </summary>
        /// <param name="simbol"></param>
        /// <returns>строка_столбец</returns>
        private KeyValuePair<char,char > XY(char simbol)
        {
            foreach (var keyValuePair in
                _list.Where(keyValuePair => String.Equals(keyValuePair.Key.ToString(), simbol.ToString(), StringComparison.OrdinalIgnoreCase)))
            {
                return keyValuePair.Value;
            }
            return new KeyValuePair<char, char>('0', '0');
        }

        /// <summary>
        /// Запросить символ по координате
        /// </summary>
        /// <param name="coordinate">Координаты</param>
        /// <returns>символ</returns>
        private char Simbol(KeyValuePair<char, char> coordinate)
        {
            foreach (var keyValuePair in _list.Where(keyValuePair => keyValuePair.Value.Equals(coordinate)))
                return keyValuePair.Key;

            return '0';
        }
    }
}
