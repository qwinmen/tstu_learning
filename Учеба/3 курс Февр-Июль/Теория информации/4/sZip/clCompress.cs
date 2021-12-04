using System;
using System.Collections.Generic;

namespace sZip
{
    class clCompress
    {
        private List<KeyValuePair<string, int>> _list = new List<KeyValuePair<string,int>>();

        public clCompress(string str)
        {
            if(String.IsNullOrEmpty(str))
                return;

            if(StartDicton != null)StartDicton.Clear();
            var lst = new List<string>();
            var index = 0;
            _list.Add(new KeyValuePair<string, int>(str[index].ToString(), index));
            lst.Add(str[index].ToString());
            //выпилить буквы без повтора, формируем начальный словарь;

            foreach (char c in str)
            {
                if (lst.Contains(c.ToString()))
                    continue;
                index++;
                lst.Add(c.ToString());
                _list.Add(new KeyValuePair<string, int>(c.ToString(), index));
            }
            StartDicton = _list;
            Process(str, lst);
        }

        internal static List<KeyValuePair<string, int>> StartDicton { get; set; }

        private void Process(string str, List<string > list)
        {
            Cod = new List<int>();
            int index = 2;
            var flag = true;
            //взять первый символ сообщения и проверить его наличие в словаре
            for (int i = 0; i < str.Length; i++)
            {
                string tmp = str[i].ToString();
                if (list.Contains(tmp) && i < str.Length - 1)
                    flag = true;
                else flag = false;

                if (list.Contains(tmp) && i < str.Length - 1)
                {
                    //символ уже есть в словаре
                    //тогда берем tmp как два символа из str
                    tmp = str.Substring(i, index);
                    while (list.Contains(tmp))
                    {
                        index++;
                        try
                        {
                            flag = true;
                            tmp = str.Substring(i, index);
                        }
                        catch (Exception)
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        list.Add(tmp);
                    }

                    Cod.Add(list.IndexOf(tmp.Substring(0, index - 1)));

                }
                else
                {
                    //символа нет в словаре
                    if (flag)
                    {
                        list.Add(tmp);
                    }
                    Cod.Add(list.IndexOf(tmp.Substring(0, index - 1)));
                }
                
                //сместить положение курсора на позицию ++);
                if (index > 2)
                {
                    i += (index - 2);
                }

                flag = true;
                index = 2;
            }

            #region povtorы
            //Проверить совпадения, если есть, то алгоритм ошибся
            index = 0;
            string[] Massiv = new string[list.Count + 1];
            int ie = 0, j = 0;
            foreach (string ts in list)
            {
                Massiv[j] = ts;
                j++;
                for (int e = 0; e < ie; e++)
                    if (ts.CompareTo(Massiv[e]) == 0)
                    {//Если есть результ, то есть совпадение с текущим значением ts!
                        index++;//MessageBox.Show(ts);
                        Massiv[e] = null;//Занулим все совпадения
                    }
                ie++;
            }
            #endregion

            Repit = index;
            Dictonary = list;
        }

        internal int Repit { get; set; }

        internal List<string> Dictonary { get; set; }

        internal List<int> Cod { get; set; }
    }
}
