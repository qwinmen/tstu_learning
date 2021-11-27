using System;

namespace рандом
{
    class Program
    {
        //Заполнить одномерный массив случайными числами без их повтора

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int tmp = 0;

            int[] arr = new int[8];
            

            for(int i=1; i < 8; i++)
			{
                if (i == 1) { arr[0] = rnd.Next(1, 8);  tmp = arr[0]; }				
				
				//пройти от начала до конца
				for(int j=0; j<arr.Length;j++)
				{
					//если tmp уже есть
					while(tmp==arr[j])
					{						
						//то опять рандомить
                        tmp = rnd.Next(1, 9);//от 1 включительно ДО 8 исключительно
                        //возможны [1-2-3-4-5-6-7]
					    j = 0;
					}
				}
				//в итоге получим уникальное число
				arr[i] = tmp;
			}

            Array.Sort(arr);
            foreach (int i in arr)
            {
                Console.Write(", {0}, ", i);
            }
            Console.ReadKey();
        }
    }
}
