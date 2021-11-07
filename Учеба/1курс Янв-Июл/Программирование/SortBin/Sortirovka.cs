using System;

namespace SortBin
{
    class Sortirovka
    {
        /*         
         * Массив из класса SedlovTochka.Arr[][] переписывается в odnomernMassiv[]
         * Метод SortBinInsert() принимает odnomernMassiv[] на вход
         * сортирует методом бинарных вставок
         * выводит результат
         */
        public static int[] odnomernMassivXY = new int[SedlovTochka.nN * SedlovTochka.mM]; //Новый масив [X*Y]
        public static void ConvertArr_In_OdnomernMassiv()
        {
            int razmerMasivaXY = SedlovTochka.nN*SedlovTochka.mM;
            int n = 0, mm = 0;
            for (int j = 0; j < razmerMasivaXY; j++) //(0; 0<16; 0++)
            {
                    if (mm < SedlovTochka.mM) //0<=4
                    {
                        odnomernMassivXY[j] = SedlovTochka.arr[n][mm];//Заполняем
                        Console.Write(odnomernMassivXY[j]+" ");//Вывод элемента и пробела
                        mm++; //0++
                    }
                    if (mm >= SedlovTochka.mM) //4>=4
                    {
                        n++; //0++
                        mm = 0;//Обнуляем [индекс в строке]
                    }
            }
            SortBinInsert(odnomernMassivXY);//Выполняем Метод Сортировки
        }

        public static void SortBinInsert(int[] list)
        {//На входе получаем odnomernMassiv[]
            for (int i = 1; i < list.Length; i++)
            {
                int low = 0;
                int righ = i - 1;
                int Temp = list[i];

                //Find
                while (low <= righ)
                {
                    int mid = (low + righ)/2;
                    if (Temp < list[mid])
                        righ = mid - 1;
                    else
                        low = mid + 1;
                }

                //backward shift
                for (int j = i - 1; j >= low; j--)
                    list[j + 1] = list[j];

                list[low] = Temp;
            }
            Console.WriteLine("\nОтсортированный массив:");
            foreach (int i in list)
                Console.Write(" " + i);
        }


    }
}
