using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delit
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "Да будет мир во всём Мире!", b = "Пусть все будут здоровы!";
            Console.Write(Console.ReadLine());
            
        }

        private delegate string StrMod(string s);
        static void Maina(string[] args)
        {
            string[] Massiv = { "Program", "var", "i", ",", "n", ":", "integer", ";",
                                                   "begin", "end" };
            int iVar = 1, iBegin = 8, iTemp=iVar;
            string str = "";

            for (int i = iVar; i < iBegin; i++)
            {
                if (Massiv[i] == ";")
                {
                    Console.WriteLine("Есть ; на позиции {0}", i);

                    for (int j = iTemp; j < i; j++)
                    {
                        //Console.WriteLine("перестановка c {0} do {1} содержит {2}",iTemp,i, str);
                        if (Massiv[j]==":")
                        {
                            Console.WriteLine("Есть : на позиции {0}",j);
                            //переставить местами А[iTemp..j]:B[j..i];
                            Console.WriteLine(" iTemp{0}, j{1}, i{2}", iTemp, j, i);
                            for (int k = j+1; k < i; k++)//+1 = непишем :
                            {//<тип>
                                str += Massiv[k];
                                for (int l = iTemp+1; l < j; l++)//+1 = непишем var||;
                                {//<ID,>
                                    str += Massiv[l];
                                }
                            }

                        }
                        //break;
                    }
                    iTemp = i;
                    
                }
            }
            Console.WriteLine("________________"+str);

        }



        /// <summary>
        /// переставляет местами id,id:type НА type id,id
        /// </summary>
        void Тип( /*нужны индексы от var до begin*/ )
        {//нужны индексы от var до begin
            string[] Massiv = { "Program", "var", "i", ",", "n", ":", "integer", ";",
                                                   "begin", "end" };
            int iVar = 1, iBegin = 8, iTemp = iVar;
            string str = "";

            for (int i = iVar; i < iBegin; i++)
            {
                if (Massiv[i] == ";")
                {
                    Console.WriteLine("Есть ; на позиции {0}", i);

                    for (int j = iTemp; j < i; j++)
                    {
                        //Console.WriteLine("перестановка c {0} do {1} содержит {2}",iTemp,i, str);
                        if (Massiv[j] == ":")
                        {
                            Console.WriteLine("Есть : на позиции {0}", j);
                            //переставить местами А[iTemp..j]:B[j..i];
                            Console.WriteLine(" iTemp{0}, j{1}, i{2}", iTemp, j, i);
                            for (int k = j + 1; k < i; k++)//+1 = непишем :
                            {//<тип>
                                str += Massiv[k];
                                for (int l = iTemp + 1; l < j; l++)//+1 = непишем var||;
                                {//<ID,>
                                    str += Massiv[l];
                                }
                            }

                        }
                        //break;
                    }
                    iTemp = i;

                }
            }
            Console.WriteLine("________________" + str);

        }

        void Lambda()
        {
            StrMod aa = s =>
            {
                string temp = "";
                int index = 0;
                bool flag = false;
                foreach (char ch in s)
                {

                    if (!flag && index + 1 < s.Length)
                        switch (ch)
                        {
                            case ':':
                                if (s[index + 1] == '=')//смотрим следущий за ':' символ
                                {//если за ':' идет '='
                                    temp += "-:=-";
                                    flag = true;
                                }
                                else
                                {//если за ':' идет лаб:уда
                                    temp += "_:_";
                                }


                                break;
                            default: temp += ch;
                                break;
                        }
                    else flag = false;
                    index++;
                }
                return temp;
            };
            StrMod strOp = aa;
            string str = strOp("jd:=seeiu:=y:");
            Console.WriteLine(str);

            /* 
                        string s = "abc:=dv", str = "";
                        int index = 0;
                                  foreach (char ch in s)
                                  {
                                      if (ch == '=')
                                      {
                                          if (s[index-1] == ':' && s[index]=='=') 
                                              str += "-:=-";
                                      }
                                      else str += ch;
                                      index++;
                                  }
                                  Console.WriteLine(str);
                       */
        }
    }
}
