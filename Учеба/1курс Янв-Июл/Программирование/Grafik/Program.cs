using System;
using System.Globalization;

namespace Grafik
{
    class Program
    {
        delegate float f(float x);
        private static double k;

        static Tuple<float, float> yMinMax(f func, float xmin, float xmax, float step)
        {//шаблон и метод()
            float min = func(xmin), max = func(xmin);
            for (float x = xmin; x < xmax; x += step)
            {
                float cy = func(x);
                if (cy < min) min = cy;
                if (cy > max) max = cy;
            }
            return Tuple.Create(min, max);
        }
        static void SwapNumbers(ref float first, ref float second)
        {
            float tmp = first;
            first = second;
            second = tmp;
        }
        static float Distance(float v1, float v2)
        {//Вернет абсолютное значение числа
            return (float)Math.Abs(v1 - v2);
        }
        static bool IsOwned(float x, float min, float max)
        {//Вернет true если
            return x >= min && x <= max;
        }
        static float Display(float x, float minA, float maxA, float minB, float maxB)
        {
            if (minA > maxA)
                SwapNumbers(ref minA, ref maxA);
            if (minB > maxB)
                SwapNumbers(ref minB, ref maxB);
            if (!IsOwned(x, minA, maxA)) 
                return 0f; //throw new ArgumentOutOfRangeException();
            float lenA = Distance(minA, maxA);
            float lenB = Distance(minB, maxB);
            float y = lenB * (x - minA) / lenA + minB;
            return y;
        }
        static void build(f func, float xmin, float xmax, float step)
        {//Метод вывода графика
            Tuple<float, float> ymm = yMinMax(func, xmin, xmax, step);
            for (float x = xmin; x <= xmax; x += step)//(-5f; -5f<=+5f; -5f=-5f+1)
            {
                int cx = (int)Display(x, xmin, xmax, 50, 0);//Отступ по Х
                float y = ymm.Item2 - func(x);

                int cy = (int)Display(y, ymm.Item1, ymm.Item2, 0, 50);//Отступ по У
                Console.SetCursorPosition(cx, cy);
                Console.Write('*');
            }
        }
        static float f1(float x)
        {//Функция
            return (float)k / ((float)Math.Pow(x, 2f) + 1);//1. y = k/(x^2)+1
        }
        static void Main()
        {
            f function = f1;
            Console.Write("Введите К:");
            string s = Console.ReadLine();
            float step = 0f;//Шаг
            while (!float.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out step))
            {//На выходе s--> step или Ошибка
                Console.WriteLine("Error: Wrong input!");
                Console.Write("Try again: ");
                s = Console.ReadLine();
            }
            Console.Clear();
            k = Convert.ToDouble(s);
            build(function, -5f, 5f, step);//-+3f//build(f func, float xmin, float xmax, float step)
            Console.ReadKey();
        }
    }
    public class Tuple<T1, T2>
    {
        public T1 Item1 { get; set; }//Свойство Item1 и типа Т1
        public T2 Item2 { get; set; }
    }
    public class Tuple
    {
        public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
        {//Возвращает новый экземпляр класса Tuple типа <T1,T2> и значениями из свойства {,}
         return new Tuple<T1, T2> { Item1 = item1, Item2 = item2 };
        }
    }
}
