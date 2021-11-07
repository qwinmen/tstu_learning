using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            main();
        }

        static int main()
        {
            int[] leks = {
                             1, 2, 10, 1, 4, 10, 2, 4, 10, 3, 3, 5, 10, 4, 6, 11, 1, 5, 10, 5, 6, 10, 4, 7, 10, 1, 7, 2, 10
                             , 2, 7, 10, 2, 8, 10, 3, 7, 10, 3, 8, 10, 2, 7, 10, 3, 9, 11, 2
                         };
            int i = 0, k = 0, z = 0, j = 0, h = 0, m = 0;
            Console.Write("+---------------------------------------+  \n");
            Console.Write("¦Операция  ¦  Оп1   ¦   Оп2  ¦ Результат¦   \n");
            Console.Write("+----------+--------+--------+----------¦");
            for (i = 0; i < leks.Length; i++)
            {
                if (leks[11] == 5 && leks[17] == 5)
                {
                    if (leks[i] == 1 && leks[i] != 10 && leks[i] != 11)//A==1 && A!=10 && A!=11
                    {
                        //Если найден то выводить его и искать параметры
                        if (leks[i + 1] == 2 && leks[i + 9] == 3)
                        {
                            Console.Write("\n¦READ      ¦        ¦        ¦          ¦\n");
                            for (k = i; k < i + 10; k++)
                            {
                                if (leks[k] == 10 && leks[k + 1] == 1 && leks[k + 2] == 4) z = 1;
                                if (leks[k] == 10 && leks[k + 1] == 2 && leks[k + 2] == 4) j = 1;
                                if (leks[k] == 10 && leks[k + 1] == 3) h = 1;
                            }
                            if (z == 1 && j == 1 && h != 1) Console.Write("Не найден третий параметр READ\n");
                            if (z == 1 && j != 1 && h == 1) Console.Write("Не найден второй параметр READ\n");
                            if (z != 1 && j == 1 && h == 1) Console.Write("Не найден первый параметр READ\n");
                            if (z == 1 && j != 1 && h != 1 || z != 1 && j != 1 && h == 1 || z != 1 && j == 1 && h != 1)
                                Console.Write("Неверные параметры READ\n");
                            if (z != 1 && j != 1 && h != 1) Console.Write("Нет ни одного параметра ReAD\n");
                            if (z == 1 && j == 1 && h == 1)
                            {
                                Console.Write("¦PARAM1    ¦  H     ¦        ¦          ¦\n");
                                Console.Write("¦PARAM2    ¦  B     ¦        ¦          ¦\n");
                                Console.Write("¦PARAM3    ¦  M     ¦        ¦          ¦\n");
                            }
                        }
                        //else Console.Write("Не хватает скобки\n");
                    }
                    if (leks[i] == 6)
                    {
                        if (leks[i - 1] == 4 && leks[i - 2] == 10 && leks[i + 1] == 11 && leks[i + 2] == 1)
                            Console.Write("¦:=        ¦  #3.14 ¦        ¦ PI       ¦\n");
                        if (leks[i - 1] != 4 && leks[i - 2] != 10 && leks[i + 1] == 11 && leks[i + 2] == 1)
                            Console.Write("Операция :=ничему не соответствует\n");
                    }
                    
                    
                        k = i + 10; //позиции для умножения
                        if (leks[k] == 7 && leks[k - 1] == 2 && leks[k - 2] == 10 && leks[k + 1] == 10 && leks[k + 2] == 2)
                            Console.Write("¦*         ¦  B     ¦  B     ¦ i1       ¦\n");
                        k = i + 16;
                        if (leks[k] == 7 && leks[k - 1] == 3 && leks[k - 2] == 10 && leks[k + 1] == 10 && leks[k + 2] == 3)
                            Console.Write("¦*         ¦  M     ¦  M     ¦ i2       ¦\n");
                        k = i + 22;
                        if (leks[k] == 7 && leks[k - 1] == 2 && leks[k - 2] == 10 && leks[k + 1] == 10 && leks[k + 2] == 3)
                            Console.Write("¦*         ¦  B     ¦  M     ¦ i3       ¦\n");
                        k = i + 13;
                        if (leks[k] == 8 && leks[k - 1] == 2 && leks[k - 2] == 10 && leks[k + 1] == 10 && leks[k + 2] == 3)
                            Console.Write("¦+         ¦  i1    ¦  i2    ¦ i4       ¦\n");
                        k = i + 19;
                        if (leks[k] == 8 && leks[k - 1] == 3 && leks[k - 2] == 10 && leks[k + 1] == 10 && leks[k + 2] == 2)
                            Console.Write("¦+         ¦  i3    ¦  i4    ¦ i5       ¦\n");
                        k = i + 6;
                        if (leks[k] == 7 && leks[k - 1] == 1 && leks[k - 2] == 10 && leks[k + 1] == 2) 
                            Console.Write("¦*         ¦  H     ¦  i5    ¦ i6       ¦\n");
                        k = i + 3;
                        if (leks[k] == 7 && leks[k - 1] == 4 && leks[k - 2] == 10 && leks[k + 1] == 10 && leks[k + 2] == 1)
                            Console.Write("¦*         ¦  i6    ¦  PI    ¦ i7       ¦\n");
                        k = i + 25;
                        if (leks[k] == 9 && leks[k - 1] == 3  && leks[k + 1] == 11 && leks[k + 2] == 2)
                            Console.Write("¦/         ¦  i7    ¦  #3    ¦ i8       ¦\n");
                        k = i;
                        if (leks[k] == 6 && leks[k - 1] == 5 && leks[k - 2] == 10)
                        { Console.Write("¦:=        ¦  i8    ¦	     ¦  V       ¦\n"); break; }
                    
                }
                else Console.Write("В конце строки не хватает ;\n");
            }
            Console.Write("+---------------------------------------+\n");
            
            return 0;
        }

    }
}