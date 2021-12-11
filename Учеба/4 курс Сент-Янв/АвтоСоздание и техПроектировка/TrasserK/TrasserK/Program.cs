using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrasserK
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 4 - количество вершин
             * 6 - количество ребер
             * Х Х Х -номер вершин ребра и его вес
             */

            Kruskal k = new Kruskal(@"4
6
1 2 1
2 3 3
3 4 2
4 1 5
1 3 4
2 4 6");

            k.BuildSpanningTree();
            Console.WriteLine("Цена в сумме: " + k.Cost);
            k.DisplayInfo();
            Console.WriteLine("Press any key...");
            Console.ReadKey();


        }
    }
}
