using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Найти повторы в структуре KeyValyePair
//Поиск совпадений по Key
//При нахождении повтора - последняя запись остается
//старая запись нулится.
namespace SearchKeyValuePair
{
    class Program
    {
        static KeyValuePair<string, string>[] _ListPairs = new KeyValuePair<string, string>[]
                                                        {
                                                            new KeyValuePair<string, string>("петя", "123"), 
                                                            new KeyValuePair<string, string>("петя", "323"), 
                                                            new KeyValuePair<string, string>("николай", "323"), 
                                                            new KeyValuePair<string, string>("варвара", "123"), 
                                                            new KeyValuePair<string, string>("петя", "123"), 
                                                            new KeyValuePair<string, string>("варвара", "123")
                                                        };

        static void Main(string[] args)
        {
            string[] word = new string[_ListPairs.Count()];
            int index = 0;
            foreach (var pair in _ListPairs)
            {
                Console.WriteLine(pair.Key+"__"+pair.Value);
                word[index] = pair.Key;
                index++;
            }

            string[] Massiv = new string[word.Length];
            int i = 0, j = 0;
            foreach (string ts in word)//A
            {
                Massiv[j] = ts;
                j++;
                for (int e = 0; e < i; e++)
                    if (ts.CompareTo(Massiv[e]) == 0)
                    {//Если есть результ, то есть совпадение с текущим значением ts!
                        Console.WriteLine("СОВПАДЕНИЕ С " + ts);
                        Massiv[e] = null;//Занулим все совпадения
                    }
                i++;
            }
            index = 0;
            foreach (var pair in Massiv)
            {
                if(pair==null) _ListPairs[index] = new KeyValuePair<string, string>(null, null);
                else _ListPairs[index] = new KeyValuePair<string, string>(pair, "dd");
                Console.WriteLine(_ListPairs[index].Key + "__" + _ListPairs[index].Value);
                index++;
            }
            Console.ReadLine();
        }

    }
}
