using System;

namespace SortBin
{
    class SedlovTochka
    {
        /*
         * Создается n*m массив
         * заполняется рандомно числами от 1..100
         * проверяется наличие седловых точек в массиве
         */
        struct Indexes { public int row; public int col; }
        public static int[][] arr;//Забивается числами из Random
        public static int nN, mM;

        public static void Line()
        {
            Console.WriteLine("Задаем размер матрицы N*M");
            Console.Write("Введите N: ");//Строки
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите M: ");//Колонки
            int m = Convert.ToInt32(Console.ReadLine());
            
            nN = n;
            mM = m;
            
            Random rand = new Random();//Генератор случайных чисел (с условием 1..100)
            arr= new int[n][];
            for (int r = 0; r < n; r++)
            {
                arr[r] = new int[m];
                for (int c = 0; c < m; c++)
                    arr[r][c] = rand.Next(1, 100);
            }
            ShowMatrix(arr);//Отображение матрицы
            Indexes[] rw, cl;
            rw = IndexMinRow(arr, n, m);//Определение индекса строки
            cl = IndexMaxCol(arr, n, m);//Определение индекса столб
            SaddlePoint(rw, n, cl, m);//Определение возможных седловых точет
            Console.ReadKey();
        }
        static void ShowMatrix(int[][] arr)
        {
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
        {//Нахождение всех min значений в строках
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
        {//Нахождение всех max значений в столбцах
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
        static void SaddlePoint(Indexes[] min, int mnr, Indexes[] max, int mxr)//(rw, n, cl, m)
        {
            int count = 0;
            for (int n = 0; n < mnr; n++) //0<3; 0++
                for (int m = 0; m < mxr; m++) //0<3; 0++
                    if (min[n].row == max[m].row && min[n].col == max[m].col)
                    {//
                        ++count;
                        Console.WriteLine("{0}. array[{1}][{2}] - седловая точка матрицы", count, min[n].row, min[n].col);
                    }
            if (count == 0)
                Console.WriteLine("Нет таких точек");
        }
    }
}
