using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grafik
{
    class TurboGraf
    {
        private int k = 0;
        double f(double x)
        {
            return k/((Math.Pow(x,2))+1);
        }
        public void Begin_1()
        {
            int i;
            double a, b, min, max, x, y, h, k;
            Console.Clear();//clrscr()
            string strA =Console.ReadLine();//scanf("%f", &a);
            a = Convert.ToDouble(strA);
            string strB = Console.ReadLine();//scanf("%f", &b);
            b = Convert.ToDouble(strB);
            min = f(a);
            max = f(b);
            h = Math.Abs(b - a)/80;
            for(x=a;x<=b;x=x+h)
            {
                if (max <= f(x))
                { max = f(x); }
                else if (min > f(x))
                    min = f(x);
            }
            Console.Clear();
            k = 25/Math.Abs(max - min);
            i = 0;
            for(x=a+h;x<=b;x+=h)
            {
                i++;
                y = f(x);
                Console.SetCursorPosition(25 - (int)k*((int)y - (int)min),i);
                //Console.CursorLeft = 40 - (int)k * ((int)y - (int)min);
                //Console.CursorLeft =i;
                //for (int o = 0; o<20;o++ )
                //    Console.CursorTop = 20 - o;
                Console.Write("*");
            }
        }
        public void Begin_2()
        {
            for (int it = 40; it >= 0; it--)
            {
                Console.CursorTop = it;
                for (int il = 0; il >= 40; il++)
                {
                    Console.CursorLeft = il;
                }
                Console.Write("*");
            }
        }
    }
}
