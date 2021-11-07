using System;

namespace SortBin
{
    class Program
    {
        static void Main()
        {
            SedlovTochka.Line();//Получаем размеры матрицы
            Sortirovka.ConvertArr_In_OdnomernMassiv();
            SedlovTochkaPosleSortirovki.Line();//Поиск седловых точек_2
        }
    }
}
