using System;
using Спуск;

namespace ПауэллаСимплекс
{
    class Program
    {
        static void Main(string[] args)
        {
            //f=[8; -1]//r=[1; 1]
            //clPauell clPauell = new clPauell('f');//f или r
            //clSimplex clSimplex = new clSimplex('f');//f или r
            //НаискорейшийСпуск spusk = new НаискорейшийСпуск('f');
            Спуск.ГрадиентныйСпуск grad = new Спуск.ГрадиентныйСпуск('f');

            //Функция_Штрафа fshtraf = new Функция_Штрафа('h');
            
            Console.ReadKey();
        }

        /// <summary>
        /// select = 'f' or 'r'
        /// </summary>
        public static double F(double x1, double x2, char select)
        {
            switch (select)
            {
                case 'f':
                    {
                        return (((x1 - 8)*Math.Cos(170) + (x2 - (-1))*Math.Sin(170))*
                                ((x1 - 8)*Math.Cos(170) + (x2 - (-1))*Math.Sin(170)))/4
                               +
                               (((x2 - (-1))*Math.Cos(170) - (x1 - 8)*Math.Sin(170))*
                                ((x2 - (-1))*Math.Cos(170) - (x1 - 8)*Math.Sin(170)))/25;
                    }
                case 'r'://Функция Розенброка
                    {
                        return 100*(x2 - x1*x1)*(x2 - x1*x1) + (1 - x1)*(1 - x1);
                    }
                case 'h'://Для аглоритма функции штрафа
                    {
                   /*     return (((x1 - (-1.0)) * Math.Cos(65) + (x2 - (-2.0)) * Math.Sin(65)) *
                                ((x1 - (-1.0)) * Math.Cos(65) + (x2 - (-2.0)) * Math.Sin(65))) / 1.0
                               +
                               (((x2 - (-2.0)) * Math.Cos(65) - (x1 - (-1.0)) * Math.Sin(65)) *
                                ((x2 - (-2.0)) * Math.Cos(65) - (x1 - (-1.0)) * Math.Sin(65))) / 16.0;
                     */   return (((x1 - (-1.0)) * Math.Cos(60) + (x2 - (-2.0)) * Math.Sin(60)) *
                                ((x1 - (-1.0)) * Math.Cos(60) + (x2 - (-2.0)) * Math.Sin(60))) / 4.0
                               +
                               (((x2 - (-2.0)) * Math.Cos(60) - (x1 - (-1.0)) * Math.Sin(60)) *
                                ((x2 - (-2.0)) * Math.Cos(60) - (x1 - (-1.0)) * Math.Sin(60))) / 25.0;
                    }
            }
            return 0;
        }

        public static double F(double x1, double x2, double a, double b, double c, double d, double alfa)
        {
            return (((x1 - a) * Math.Cos(alfa) + (x2 - (b)) * Math.Sin(alfa)) *
                    ((x1 - a) * Math.Cos(alfa) + (x2 - (b)) * Math.Sin(alfa))) / c*c
                   +
                   (((x2 - (b)) * Math.Cos(alfa) - (x1 - a) * Math.Sin(alfa)) *
                    ((x2 - (b)) * Math.Cos(alfa) - (x1 - a) * Math.Sin(alfa))) / d*d;
        }

        public static double F(Point K, char select)
        {
            switch (select)
            {
                case 'f':
                    {
                        return (((K.X - 8.0)*Math.Cos(170) + (K.Y - (-1.0))*Math.Sin(170))*
                                ((K.X - 8.0)*Math.Cos(170) + (K.Y - (-1.0))*Math.Sin(170)))/4.0
                               +
                               (((K.Y - (-1.0))*Math.Cos(170) - (K.X - 8.0)*Math.Sin(170))*
                                ((K.Y - (-1.0))*Math.Cos(170) - (K.X - 8.0)*Math.Sin(170)))/25.0;
                    }
                case 'r'://Функция Розенброка
                    {
                        return 100.0*(K.Y - K.X*K.X)*(K.Y - K.X*K.X) + (1 - K.X)*(1 - K.X);
                    }
                case 't'://Функция для тестирования работы алгоритма
                    {
                        return K.X * K.X + 6.0 * K.X + K.Y * K.Y + 9.0 * K.Y + 1.0 * ((1.0 / K.X) + (1.0 / K.Y));
                        //return 4 * (K.X - 5) * (K.X - 5) + (K.Y - 6) * (K.Y - 6);
                    }
                case 'h'://Для аглоритма функции штрафа
                    {
              /*          return (((K.X - (-1.0)) * Math.Cos(65) + (K.Y - (-2.0)) * Math.Sin(65)) *
                                ((K.X - (-1.0)) * Math.Cos(65) + (K.Y - (-2.0)) * Math.Sin(65))) / 1.0
                               +
                               (((K.Y - (-2.0)) * Math.Cos(65) - (K.X - (-1.0)) * Math.Sin(65)) *
                                ((K.Y - (-2.0)) * Math.Cos(65) - (K.X - (-1.0)) * Math.Sin(65))) / 16.0;
               */
                        return (((K.X - (-1.0)) * Math.Cos(60) + (K.Y - (-2.0)) * Math.Sin(60)) *
                                ((K.X - (-1.0)) * Math.Cos(60) + (K.Y - (-2.0)) * Math.Sin(60))) / 4.0
                               +
                               (((K.Y - (-2.0)) * Math.Cos(60) - (K.X - (-1.0)) * Math.Sin(60)) *
                                ((K.Y - (-2.0)) * Math.Cos(60) - (K.X - (-1.0)) * Math.Sin(60))) / 25.0;
                    }
            }
            return 0;
        }

        /// <summary>
        /// Функция Розенброка
        /// </summary>
        public static double FRoze(double x1, double x2)
        {
            return 100*(x2 - x1*x1)*(x2 - x1*x1) + (1 - x1)*(1 - x1);
        }

        #region Производные
        /// <summary>
        /// производная по X. Общая формула
        /// </summary>
        public static double Sistema_X(double x, double y, char selector)
        {
            return (F(x + 0.001, y, selector) - F(x, y, selector))/0.001;
        }
        public static double Sistema_X(Point A, char selector)
        {
            return (F(A.X + 0.001, A.Y, selector) - F(A, selector)) / 0.001;
        }

        /// <summary>
        /// производная по Y. Общая формула
        /// </summary>
        public static double Sistema_Y(double x, double y, char selector)
        {
            return (F(x, y + 0.001, selector) - F(x, y, selector)) / 0.001;
        }
        public static double Sistema_Y(Point A, char selector)
        {
            return (F(A.X, A.Y + 0.001, selector) - F(A, selector))/0.001;
        }

        #endregion

       
    }
}
