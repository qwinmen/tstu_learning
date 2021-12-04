using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZW
{
    class clDecoder
    {
        public clDecoder(string str, List<KeyValuePair<string, int>> dictonar)
        {
            if(dictonar==null) return;

            var arr = str.Split(' ');
            var flag = false;

            //начальный словарь
            var list = dictonar.Select(keyValuePair => keyValuePair.Key).ToList();
            for (int i = 0; i < arr.Length-1; i++)
            {
                var tmp = int.Parse(arr[i]);//0
                if (SearchD(list, tmp))
                {
                    var ses = list[tmp];//a
                    var indx = 1;
                    //проход по ячейкам
                    while (list.Contains(ses))
                    {
                        if (i + indx >= arr.Length-1)
                        {
                            flag = true;
                            break;
                        }
                        tmp = int.Parse(arr[i + indx]);//1
                        if (SearchD(list, tmp))
                        {
                            var tes = 0;
                            //проход по ЭЛЕМЕНТУ в ячейке
                            while (list.Contains(ses))
                            {
                                tes++;
                                if (list[tmp].Length >= tes)
                                    ses += list[tmp].Substring(0, tes);
                                else break;
                            }

                        }
                        indx++;
                    }

                    if(flag) break;
                    list.Add(ses);
                }
                else
                {
                    //list.Add(tmp);
                }
    
            }

            Decod = list;
        }

        private bool SearchD(List<string > list, int i)
        {
            return i < list.Count;
        }

        internal List<string> Decod { get; set; }
    }
}
