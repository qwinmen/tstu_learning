using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//https://sites.google.com/site/anisimovkhv/learning/kripto/lecture/tema4&sa=U&ved=0ahUKEwiVgKaSrcjKAhUnnnIKHb-5DagQFggTMAA&sig2=et4Tt7ICiFfGLoVZHSsZ4g&usg=AFQjCNEJC0ys71qnQl4-YKPgwRJYnONnsQ
//Совмещенный шифр (совмещенная таблица)
namespace BitwinCripto
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            var regEx = new Regex(@"^[а-яёА-ЯЁ]+[^\d^\s]*$");//Весь рус алф кроме цифр кроме пробела
            var globalKey = "";
            var globalResult = "";
            while (flag)
            {
                {//Шифрование
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Шифруем. Введите ключ (rus):");
                    var key = Console.ReadLine();
                    while (!regEx.IsMatch(key)) key = Console.ReadLine();
                    globalKey = key;
                    Console.WriteLine("Введите текст (rus):");
                    var text = Console.ReadLine();
                    index = -1;//clear static
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    var result = CriptoText(text, key);
                    globalResult = result;
                    Console.WriteLine("Текст зашифрован в последовательность: {0}", result);
                }
                Console.WriteLine("==================================================");
                {//Дешифрование
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("ДеШифруем. Введите ключ ({0}):", globalKey);
                    var key = Console.ReadLine();
                    while (!regEx.IsMatch(key)) key = Console.ReadLine();
                    Console.WriteLine("Введите шифр-текст ({0}):", globalResult);
                    var text = Console.ReadLine();
                    index = -1;//clear static
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    var res = DeCriptoText(text, key);
                    Console.WriteLine(res);
                }
                Console.WriteLine("==================================================");
            }

        }

        /// <summary>
        /// Дешифровка
        /// </summary>
        /// <param name="text">283457203</param>
        /// <param name="key">Ключ которым шифровали</param>
        private static string DeCriptoText(string text, string key)
        {
            //по ключу восстанавливаем таблицу, тоесть шаги такиеже 
            //как и при шифровании, поэтому используем старую таблицу _arrTable
            var tempList = new List<char>();
            Console.Write("Key: ");
            //ключ вписать без повторов символов
            foreach (char ch in key)
            {//Дядина => Дяина
                if (tempList.Contains(char.ToUpper(ch)) || tempList.Contains(char.ToLower(ch))) continue;
                tempList.Add(ch);
                Console.Write(ch);
            }
            Console.WriteLine();

            var resStr = "";
            //первая цифра равна 0..2? Да - то Первая и Вторая цифры дают букву в _arrTable[,]
            //Нет - то первая цифра это столбец в ключе tempList[столбец]
            for (int i = 0; i < text.Length;)
            {
                var ch = text[i];
                if (ch == '0' || ch == '1' || ch == '2')
                {//Yes
                    if (i + 1 >= text.Length)
                    {
                        resStr += tempList[int.Parse(ch.ToString())];
                        break;
                    }
                    resStr += _arrTable[int.Parse(text[i + 1].ToString()), int.Parse(ch.ToString())];
                    i+=2;
                }
                else
                {//No
                    resStr += tempList[int.Parse(ch.ToString())];
                    i++;
                }
            }

            return resStr;
        }

        private static char[,] _arrTable;
        private static string _alphabit = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        static int index = -1;

        /// <summary>
        /// Метод шифрования
        /// </summary>
        /// <param name="textIn">текст для шифрования</param>
        /// <param name="key">ключ для шифровки</param>
        private static string CriptoText(string textIn, string key)
        {
            _arrTable = new char[10,3];//под русский алфавит
            var tempList = new List<char>();
            Console.Write("Key: ");
            //ключ вписать без повторов символов
            foreach (char ch in key)
            {//Дядина => Дяина
                if (tempList.Contains(char.ToUpper(ch)) || tempList.Contains(char.ToLower(ch))) continue;
                tempList.Add(ch);
                Console.Write(ch);
            }
            Console.WriteLine();

            //Заполнить строки _arrTable[,] оставшимися буквами алфавита);
            for (int i = 0; i <= _arrTable.GetUpperBound(1); i++)
            {
                for (int j = 0; j <= _arrTable.GetUpperBound(0); j++)
                {
                    _arrTable[j, i] = GetRelayChar(tempList);
                    Console.Write(_arrTable[j, i]+" ");
                }
                Console.WriteLine();
            }

            //Текст по символам: символ есть в ключе? Да - берем номер столбца/Нет - берем строку' 'столбец
            string result = GetCharInKey(textIn, tempList);
            
            return result;
        }

        private static string GetCharInKey(string text, List<char> keyList)
        {
            var resultStr = "";
            foreach (char ch in text)
            {
                if (keyList.Contains(char.ToUpper(ch)) || keyList.Contains(char.ToLower(ch)))
                {//Yes
                    resultStr += keyList.IndexOf(char.ToUpper(ch)) == -1
                                     ? keyList.IndexOf(char.ToLower(ch))
                                     : keyList.IndexOf(char.ToUpper(ch));
                }
                else
                {//No
                    resultStr += IndexOf(ch);
                }
            }
            return resultStr;
        }

        /// <summary>
        /// Поиск по таблице 3*10
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        private static string IndexOf(char  ch)
        {
            for (int i = 0; i <= _arrTable.GetUpperBound(1); i++)
            {
                for (int j = 0; j <= _arrTable.GetUpperBound(0); j++)
                {
                    if (_arrTable[j, i] == char.ToUpper(ch))
                        return string.Concat(i, j);
                }
            }

            return "-1";
        }

        /// <summary>
        /// Вернуть уникальный символ
        /// </summary>
        /// <returns></returns>
        private static char GetRelayChar(List<char> keyList)
        {
            index++;
            if (index >= _alphabit.Length) return '-';

            var ch = _alphabit[index];
            //символ есть в ключе?Да - берем след символ\Нет - вернуть символ
            if (keyList.Contains(char.ToUpper(ch)) || keyList.Contains(char.ToLower(ch)))
            {//Yes
                return GetRelayChar(keyList);
            }
            
            return ch;
        }

    }
}
