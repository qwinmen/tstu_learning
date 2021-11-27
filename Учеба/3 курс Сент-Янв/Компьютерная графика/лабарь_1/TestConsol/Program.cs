using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsol
{
    class Program
    {
        static void Main(string[] args)
        {
            tocka.Add(50,"odin");
            for (int i = 0; i < 5; i++)
            {
                FF(i);
            }
            
        }

        static void FF(int i)
        {
            tocka.Add(i, "----");
            Console.WriteLine(tocka.Last());
        }

        static Dictionary<int, string> tocka = new Dictionary<int, string>();
    }
}
