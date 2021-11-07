using System; 
//метод вычмат симпсона
namespace Simpsona
{
    class Program
    {
        static void Main( )
        {
            double x, a, b, h, s = 0; int n, index=0;
            Console.Write("Отрезок интегрирования [a,b] -> (a) ="); a = Double.Parse(Console.ReadLine());
            Console.Write("Отрезок интегрирования [a,b] -> (b) ="); b = Double.Parse(Console.ReadLine());
            Console.Write("На сколько частей нужно разделить отрезок? n="); n = int.Parse(Console.ReadLine());
            
            h = (b - a) / n;
            x = a + h;
            while (x < b)
            {
                s = s + 4 * Y(x);
                Console.WriteLine("Площадь{1} равна {0}",s, index);
                x += h;
                s += 2 * Y(x);
                Console.WriteLine("Площадь{1} равна {0}", s, index++);
                x += h;
            }
            s = h / (3.0 * (s + Y(a) - Y(b)));
            Console.WriteLine("Интеграл = {0}", s);

        }

        static double Y(double p){return 1 / (1 + p * p);}
    }
}
