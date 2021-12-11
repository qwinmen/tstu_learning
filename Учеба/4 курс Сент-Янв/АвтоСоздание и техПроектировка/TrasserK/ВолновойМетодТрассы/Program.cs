using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//http://ucxodnuku.ru/algoritm/volnovoy-algoritm-ili-kratchayshiy-put-mezhdu-dvumya-tochkami.html
namespace ВолновойМетодТрассы
{
    class Program
    {
        static void Main(string[] args)
        {
            // 0 – конечная точка
            // 51 – непроходимая точка
            // 50 – проходимая точка
            // 49 –начальная точка
            // инициализируем массив с игровым полем
            int M = 7;
            int N = 7;
            int[,] POLE = new int[,]
                              {
                                  {51, 51, 51, 51, 51, 51, 51},
                                  {51, 49, 50, 50, 50, 51, 51},
                                  {51, 50, 50, 51, 50, 50, 51},
                                  {51, 51, 50, 50, 50, 0, 51},
                                  {51, 50, 50, 50, 51, 50, 51},
                                  {51, 50, 51, 50, 50, 50, 51},
                                  {51, 51, 51, 51, 51, 51, 51}
                              };
            // инициализируем рабочий массив
            int[,] RAB = new int[,]
                             {
                                 {51, 51, 51, 51, 51, 51, 51},
                                 {51, 49, 50, 50, 50, 51, 51},
                                 {51, 50, 50, 51, 50, 50, 51},
                                 {51, 51, 50, 50, 50, 0, 51},
                                 {51, 50, 50, 50, 51, 50, 51},
                                 {51, 50, 51, 50, 50, 50, 51},
                                 {51, 51, 51, 51, 51, 51, 51}
                             };

            int iter = 0;// количество итераций
            int iterk = 49;//не должна быть больше размера начальной точки(в нашем случае 49)//равную максимальному числу итераций

            while (iter < iterk)
            {
                for (int i = 0; i <= RAB.GetUpperBound(1); i++) 
                {
                    for (int j = 0; j <= RAB.GetUpperBound(0); j++)
                    {
                        Console.Write(RAB[i, j]+" ");
                        if(RAB[i, j]==iter)
                        {// то просматриваются соседние элементы
                            var list = SeeBabyElements(i, j, RAB);
                            foreach (KeyValuePair<int, int> keyValuePair in list)//то RAB(i-1,j)=iter+1
                                RAB[keyValuePair.Key, keyValuePair.Value] = iter + 1;
                        }
                    }Console.WriteLine();

                    iter++;//покидаем построчный просмотр массива мы должны увеличить количество итераций на 1
                }
                //Console.ReadLine();
            }

            if (iter > iterk)
            {
                Console.WriteLine(
                    "Нахождений кратчайшего пути невозможно, следовательно, волновой алгоритм не выполняется для введенных точек и нужно покинуть программу, ну и в следующий раз указать уже другие точки.");
                return;
            }
            WriteConsArr(RAB);
            //переходим к построению пути перемещения.
            int x = 0, y = 0, x1 = 0, y1 = 0;
            int min = 51;

            while (true)
            {
                if(RAB[x+1,y]<min)
                {
                    min = RAB[x + 1, y];
                    x1 = x + 1;
                    y1 = y;
                }
                if(RAB[x-1,y]<min)
                {
                    min = RAB[x - 1, y];
                    x1 = x - 1;
                    y1 = y;
                }
                if (RAB[x,y+1]<min)
                {
                    min = RAB[x, y + 1];
                    x1 = x;
                    y1 = y + 1;
                }
                if (RAB[x,y-1]<min)
                {
                    min = RAB[x, y - 1];
                    x1 = x;
                    y1 = y - 1;
                }
                x = x1;
                y = y1;
                if(RAB[x1,y1]==0)break;
                POLE[x1, y1] = -1;
            }

            //ага, нуда, глянем кратчайший путь, нуну
            for (int i = 0; i <= POLE.GetUpperBound(1); i++)
            {
                for (int j = 0; j <= POLE.GetUpperBound(0); j++)
                {
                    switch (POLE[i,j])
                    {
                        case 51://#
                            Console.Write("#");
                            break;
                        case 50://.
                            Console.Write(".");
                            break;
                        case 49://A
                            Console.Write("A");
                            break;
                        case 0://B
                            Console.Write("B");
                            break;
                        case -1://>
                            Console.Write(">");
                            break;
                        default: Console.Write(POLE[i,j]);
                            break;
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static void WriteConsArr(int[,] RAB)
        {
            Console.WriteLine("После нахождения while():");
            for (int i = 0; i <= RAB.GetUpperBound(1); i++)
            {
                for (int j = 0; j <= RAB.GetUpperBound(0); j++)
                {
                    Console.Write(RAB[i, j] + " ");
                } Console.WriteLine();
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Вернет список из пар [Х;У]
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="massiv"></param>
        /// <returns></returns>
        private static List<KeyValuePair<int,int>> SeeBabyElements(int i, int j, int[,] massiv)
        {
            var retList = new List<KeyValuePair<int, int>>();
            int sizeX = massiv.GetUpperBound(1)+1;
            int sizeY = massiv.GetUpperBound(0)+1;
            //RAB(i+1,j), RAB(i-1,j), RAB(i,j+1), RAB(i,j-1))
            for (int k = 0; k < 4; k++)
            {
                int n = i, m = j;
                switch (k)
                {
                    case 0://RAB(i+1,j)
                        n += 1;
                        break;
                    case 1://RAB(i-1,j)
                        n -= 1;
                        break;
                    case 2://RAB(i,j+1)
                        m += 1;
                        break;
                    case 3://RAB(i,j-1)
                        m -= 1;
                        break;
                }
                if (n > sizeX || n < 0 || m > sizeY || m < 0) continue;

                var elsement = massiv[n, m];
                switch (elsement)
                {
                    case 50://1) Если RAB(i-1,j)==50 , то есть точка является проходимой то RAB(i-1,j)=iter+1 
                        //massiv[n, m] = iter + 1;
                        retList.Add(new KeyValuePair<int, int>(n, m));
                        break;
                    case 49://2)Если RAB(i-1,j)==49, то выходим из данного, так как мы дошли до начальной точки.
                        break;
                }
            }

            return retList;
        }

    }
}
