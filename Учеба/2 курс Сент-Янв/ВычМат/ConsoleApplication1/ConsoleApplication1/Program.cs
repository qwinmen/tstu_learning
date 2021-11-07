using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Вычислить значение для 550 с помощью второй интер.ф-лы.Ньютона
Таблица 1
x 300 400 500 600
Y 52.88 65.61 78.07 99.24*/
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] X = { 1,2,3,4,5};//{300, 400, 500, 600};
            double[] Y = { 6,5,9,2,8};//{52.88, 65.61, 78.07, 99.24};
            int n = 3;
            double testX = 0; 
            Console.Write("Вводим проверяемый Х\n");
            string tX = Console.ReadLine();
            testX = Convert.ToDouble(tX);
            if (testX > X[3] || testX < X[0])
            {
                Console.Write("Недопустимое значение\n");
                //return 0;
            }
            double [][] razn = new double[n + n + 1][]; /*создание динамического массива для
                                                      * таблицы конечных разностей
                                                       [n+n+1]столько у нас строк в таблице*/
            int k = 0;
            for (int i = 0; i <= n; ++i)
            {
                razn[i] = new double[n + 1 + k];
                --k;// выделяем память для каждой строки определенное кол столбцов [n+n+1+k]
                //к- уменьшает число столбцов в строчке на 1, т.к.
                //таблица разностей имеет диагональный вид
            }
            for (int i = 0; i <= n; ++i)// заполняем нулевой столбец массива значениями функции в узлах
            {
                razn[i][0] = Y[i];
                Console.Write(razn[i][0]+" ");
            }
            Console.WriteLine("\n--------------------------");
            int r = n;
            for (int j = 1; j <= n + n; ++j)
            {
                for (int i = 0; i < r; ++i)
                {
                    int s = -i;
                    razn[i][j] = razn[-(s - 1)][j - 1] - razn[i][j - 1];//получаем таблицу разностей
                    Console.Write("r[ " + i + "][ " + j + "]" + razn[i][j]+" ");
                }
                Console.Write("\n---------------------------\n");
                r--;//это чтобы уменьшать число столбцов, в строке, приводить к диагональному виду таблицу разности
                if (r == 0) break;
            }
            double sum,sum1,sum3,sum2;
            double st = X[1] - X[0];
            unsafe
            {
                double[] q=new double[10];
                //float* q = new float;   
                double tmp = 1;
                sum = Y[n];
                int p = 1, u = n;
                for (int i = 0; i <= n; i++)
                {
                    q[i] = (testX - X[u]);
                    tmp *= q[i];
                    sum1 = razn[u - 1][i + 1] * tmp;
                    sum2 = Math.Pow(st, p) * factorial(p);//A в степени Б
                    sum3 = sum1 / sum2;
                    sum = sum + sum3;
                    Console.Write("sum= "+sum+"\n");
                    p++; u--;
                    if (u - 1 < 0) break;//чтобы не выйти за границы таблицы конечн.разностей
                }
                Console.Write("Результата вычислений Р(" + testX + ")= " + sum+"\n");
            }

        }
        static int factorial(int f)
        {
            int product = 1;
            while (f > 0) { product = f * product; f--; }
            return product;
        }
    }
}
