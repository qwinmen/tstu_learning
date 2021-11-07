using System;

namespace SortBin
{
    class SedlovTochkaPosleSortirovki
    {
        /*
         *Перегоняем odnomernMassivXY[] в двумерный arr[n][m] 
         *Ищем седловые точки
         */

        struct Indexes { public int row; public int col; }
        private static int[][] arr;

        public static void Line()
        {
            int n = SedlovTochka.nN;//Контроль размерности
            int m = SedlovTochka.mM;//Контроль размерности
            arr = new int[n][];
            int value = 0;
            for (int r = 0; r < n; r++)//Изменение по столбцамм
            {
                arr[r] = new int[m];
                for (int c = 0; c < m; c++)//Изменение по колонкам
                {
                    arr[r][c] = Sortirovka.odnomernMassivXY[value]; //Вбивка чисел в масив arr[r][c]
                    value++;
                }
            }
            ShowMatrix(arr);
            Indexes[] rw, cl;
            rw = IndexMinRow(arr, n, m);
            cl = IndexMaxCol(arr, n, m);
            SaddlePoint(rw, n, cl, m);
            Console.ReadKey();
        }
        static void ShowMatrix(int[][] arr)
        {//Вывод значений масива
            Console.WriteLine();
            foreach (var ar in arr)
            {
                Console.WriteLine();
                foreach (var a in ar)
                    Console.Write("{0,4}", a);//Пробелы между числами [a]
            }
            Console.WriteLine();
        }
        static Indexes[] IndexMinRow(int[][] arr, int rows, int cols)
        {
            Indexes[] min = new Indexes[rows];
            int minElement;
            for (int n = 0; n < rows; n++)
            {
                minElement = int.MaxValue;
                for (int m = 0; m < cols; m++)
                    if (minElement > arr[n][m])
                    {
                        minElement = arr[n][m];
                        min[n].row = n;
                        min[n].col = m;
                    }
            } return min;
        }
        static Indexes[] IndexMaxCol(int[][] arr, int rows, int cols)
        {
            Indexes[] max = new Indexes[cols];
            int maxElement;
            for (int m = 0; m < cols; m++)
            {
                maxElement = int.MinValue;
                for (int n = 0; n < rows; n++)
                    if (maxElement < arr[n][m])
                    {
                        maxElement = arr[n][m];
                        max[m].row = n;
                        max[m].col = m;
                    }
            } return max;
        }
        static void SaddlePoint(Indexes[] min, int mnr, Indexes[] max, int mxr)
        {
            int count = 0;
            for (int n = 0; n < mnr; n++)
                for (int m = 0; m < mxr; m++)
                    if (min[n].row == max[m].row && min[n].col == max[m].col)
                    {
                        ++count;
                        int znachenie = arr[min[n].row][min[n].col];
                        Console.WriteLine("{0}. array[{1}][{2}] - седловая точка матрицы, значение= {3}", count, min[n].row, min[n].col,znachenie);
                    }
            if (count == 0)
                Console.WriteLine("Нет таких точек");
        }

    }
}
