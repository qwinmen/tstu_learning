﻿using System;
using ПауэллаСимплекс;

namespace ДихЗолотФибон
{
    class ЧислаФибоначчи
    {
        /// <summary>
        /// Для переключений между функциями
        /// </summary>
        public static char Selector { get; set; }
        /// <summary>
        /// Вывод для какой точки найден минимум
        /// </summary>
        public static string K { private get; set; }

        static int[] ЧислаФибо = new int[40];
        public static int Fibo(double n)
        {//n=6;
            int a = 1; int b = 1; int temp = 1; int i;
            ЧислаФибо[0] = ЧислаФибо[1] = 1;
            for (i = 1; i < n; i++)
            {
                temp = a + b;
                a = b;
                b = temp;
                ЧислаФибо[i + 1] = temp;
                if (temp >= n) break;
            }
            //Console.WriteLine("F={0} > n={1} ==>N={2}", temp, n, i + 1);
            return i + 1;
        }
        
        static double A_F_F(double a, double b, double F_числит, double F_знаменат)
        { return a + (F_числит / F_знаменат) * (b - a); }

        public static double Фибоначи(double a0, double b0, double epsilon, double X_fiks, bool X2_fiks)
        {//Число X_fiks при флаге X2_fiks=true зафиксированно по оси X2

            //[1]По заданной точности рассчитывается вспомогательное число N:
            double n = (b0 - a0) / epsilon;//6
            //[2]Для полученного значения N находится такое число Фибоначчи Fs, для которого выполняется неравенство:
            // Fs-1 < N < Fs
            int N = Fibo(n), k = 0;
            double f_y, f_z;
            double[] y = new double[N], a = new double[N], z = new double[N], b = new double[N];
            a[k] = a0; b[k] = b0;
            y[k] = A_F_F(a[k], b[k], ЧислаФибо[N - 2], ЧислаФибо[N]);
            z[k] = A_F_F(a[k], b[k], ЧислаФибо[N - 1], ЧислаФибо[N]);
      step5:
            if (X2_fiks)
            {//X2_fiks=true, то надо передать в F(x1; X_fiks)
                f_y = Program.F(y[k], X_fiks, Selector);
                f_z = Program.F(z[k], X_fiks, Selector);
            }
            else
            {// ИНАЧЕ F(X_fiks; x2)
                f_y = Program.F(X_fiks, y[k], Selector);
                f_z = Program.F(X_fiks, z[k], Selector);
            }
            
            if (f_y <= f_z)
            {
                a[k + 1] = a[k];
                b[k + 1] = z[k];
                z[k + 1] = y[k];
                y[k + 1] = A_F_F(a[k + 1], b[k + 1], ЧислаФибо[N - k - 3], ЧислаФибо[N - k - 1]);
            }
            else
            {
                a[k + 1] = y[k];
                b[k + 1] = b[k];
                y[k + 1] = z[k];
                z[k + 1] = A_F_F(a[k + 1], b[k + 1], ЧислаФибо[N - k - 2], ЧислаФибо[N - k - 1]);
            }

            if (k != N - 3)
            {
                k = k + 1;
                goto step5;
            }
            else
            {
                y[N - 2] = z[N - 2] = (a[N - 2] + b[N - 2]) / 2;
                y[N - 1] = y[N - 2] = z[N - 2];
                z[N - 1] = y[N - 1] + epsilon;

                if (X2_fiks)
                {//X2_fiks=true, то надо передать в F(x1; X_fiks)
                    if (Program.F(y[N - 1], X_fiks, Selector) <= Program.F(z[N - 1], X_fiks, Selector))
                    {
                        a[N - 1] = a[N - 2];
                        b[N - 1] = z[N - 1];
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("***Метод Фибоначчи. Минимум в точке {0}***", K);
                        Console.WriteLine("Xe[{0:0.####};{1:0.####}]", a[N - 1], b[N - 1]);
                        Console.WriteLine("({0:0.####}+{1:0.####})/2={2:0.####}", a[N - 1], b[N - 1], (a[N - 1] + b[N - 1]) / 2.0);
                        Console.BackgroundColor = ConsoleColor.Black;
                        return (a[N - 1] + b[N - 1]) / 2.0;
                    }
                }
                else
                {// ИНАЧЕ F(X_fiks; x2)
                    if (Program.F(X_fiks, y[N - 1], Selector) <= Program.F(X_fiks, z[N - 1], Selector))
                    {
                        a[N - 1] = a[N - 2];
                        b[N - 1] = z[N - 1];
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("***Метод Фибоначчи. Минимум в точке {0}***", K);
                        Console.WriteLine("Xe[{0:0.####};{1:0.####}]", a[N - 1], b[N - 1]);
                        Console.WriteLine("({0:0.####}+{1:0.####})/2={2:0.####}", a[N - 1], b[N - 1], (a[N - 1] + b[N - 1]) / 2.0);
                        Console.BackgroundColor = ConsoleColor.Black;
                        return (a[N - 1] + b[N - 1]) / 2.0;
                    }
                }
                
                a[N - 1] = y[N - 1];
                b[N - 1] = b[N - 2];
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("***Метод Фибоначчи. Минимум в точке {0}***", K);
                Console.WriteLine("Xe[{0:0.####};{1:0.####}]", a[N - 1], b[N - 1]);
                Console.WriteLine("({0:0.####}+{1:0.####})/2={2:0.####}", a[N - 1], b[N - 1], (a[N - 1] + b[N - 1]) / 2.0);
                Console.BackgroundColor = ConsoleColor.Black;
                return (a[N - 1] + b[N - 1]) / 2.0;
            }

        }

    }
}
