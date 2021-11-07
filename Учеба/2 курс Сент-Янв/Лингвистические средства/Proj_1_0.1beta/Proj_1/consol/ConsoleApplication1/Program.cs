using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {/*
      * Код находит ПОВТОРЯЮЩИЕСЯ БУКВЫ\СЛОВА из word
      * и ВСЕ повторяющиеся заменяет на ноль в
      * конечном Masssiv[]
      */
        static void Main(string[] args)
        {
            string[] word = {"OR","Y","END","Y","SUM","OR"};
            string[] Massiv = new string[word.Length+1];
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

            

            /*
            if (sost_ts.Contains(Massiv[i]))
                Console.WriteLine("A есть");
            */
            

            Console.WriteLine("____________"+Massiv[0]);

            
            foreach (string ss in Massiv)
            {
                if(ss!=null)
                Console.Write(ss+" ");    
            }


            string[] names = new string[] { "AND", "AND", "SUB" };
            var groups = names.Select((name, Index) => new { name, Index }).GroupBy(a => a.name);

            int search = Array.BinarySearch(names, "SUB");
            Console.WriteLine("находится на {0} позиции", search + 1);


            int dex = 0;
            //Сколько null от начала до vvv
            for (int k = 0; k <= 10; k++)
            {
                //if (Massiv[k] == null)//[1]=null
                    dex++;//+1
            }
            //Вычтем подсчитаное количество нулов (x-dex)
            Console.WriteLine(dex);

        }
    }
}

/*
                if(flag==1)//Вып 1 раз!
                {//Для 0 позиций
                    Massiv[0] = ts;//A
                    flag = 0;
                }
                else
                {
                    if (ts == "B")
                        Massiv[i] = ts;

                    i++;
                }

                */


/* for(int j=0;j<i;j++)//0<1
{
    if(ts==Massiv[j])//A==A
    {
        Console.WriteLine("ts=Massiv");
    }
    else
    {
        Massiv[i] = ts;
        i++;
        Console.WriteLine("---");
    }
}
*/



/*for (int i=index;i<word.Length ; )//0;0<5;
                {
                    foreach (string s in Massiv)
                    {
                        if (ts == s)//or==or
                            Console.WriteLine(" " + ts + " "); //или s
                        else
                        {//Добавление и Вывод
                            Massiv[i] = ts;
                            Console.Write(" " + Massiv[i] + " ");
                            break;
                        }
                        
                    }
                    
                }
                index++;
                */

/*
for (int k = 0; k < Massiv.Length; k++)
{
    if (Massiv[0] == "or") //ts==[0..i]
    {//Есть совпадение В Масив НеПишем
        Console.WriteLine("DUBL_" + Massiv[0] + "_");

    }
    else //Если нет совпадений Пишем в Масив
    {
        Massiv[k] = ts; //[0]=or
        Console.WriteLine(ts + "fff");
        //break; //тормозит выполнение for
    }
}
*/