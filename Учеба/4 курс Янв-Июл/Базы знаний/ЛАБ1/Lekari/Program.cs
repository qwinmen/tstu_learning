using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Вариант 4
namespace Lekari
{
    class Program
    {
        private static Bolesni _clBolesni;

        static void Main(string[] args)
        {
            //var bolesn = "";
            //{//Note: выбрать болезнь
            //    var indexChuse = 0;
            //    var list = new List<string>();
            //    Console.WriteLine("Предпологаемая болезнь: ");
            //    for (var i = clBaseKnow.Bolesni.start + 1; i < clBaseKnow.Bolesni.end; i++)
            //    {
            //        var outres = 0;
            //        if (int.TryParse(i.ToString(), out outres)) continue;
            //        Console.WriteLine("{1}) {0}", i, indexChuse++);
            //        list.Add(i.ToString());
            //    }
            //    var numBlsn = Console.ReadLine();
            //    bolesn = list[int.Parse(numBlsn)];
            //}

            {//Note: Формируем базу знаний из известных данной болезни симптомов:
                ЕСЛИ(clBaseKnow.SimptomMPS.Артериальное_давление_умеренно_повышено,
                 clBaseKnow.SimptomMPS.Бледность_кожных_покровов, clBaseKnow.SimptomMPS.Головная_боль,
                 clBaseKnow.SimptomMPS.Одутловатость_лица, clBaseKnow.SimptomMPS.Рвота,
                 clBaseKnow.SimptomMPS.Уменьшается_мочеотделение, clBaseKnow.SimptomMPS.Ухудшение_аппетита);

                ЕСЛИ(clBaseKnow.SimptomMPS.Обильные_слизисто_гнойные_бели,
                     clBaseKnow.SimptomMPS.Зуд_наружных_половых_органов, clBaseKnow.SimptomMPS.Нарушение_общего_самочувствия);

                ЕСЛИ(clBaseKnow.SimptomMPS.Интенсивные_боли_в_пояснице,
                     clBaseKnow.SimptomMPS.Интенсивные_боли_в_верхней_части_живота, clBaseKnow.SimptomMPS.Тошнота,
                     clBaseKnow.SimptomMPS.Задержка_стула_и_газов, clBaseKnow.SimptomMPS.Рвота,
                     clBaseKnow.SimptomMPS.Учащенное_иногда_болезненное_мочеиспускание);

                ЕСЛИ(clBaseKnow.SimptomMPS.Температура, clBaseKnow.SimptomMPS.Растройства_мочеиспускания,
                     clBaseKnow.SimptomMPS.Интенсивные_боли_в_пояснице, clBaseKnow.SimptomMPS.Озноб,
                     clBaseKnow.SimptomMPS.Обильный_пот, clBaseKnow.SimptomMPS.Головная_боль, clBaseKnow.SimptomMPS.Тошнота,
                     clBaseKnow.SimptomMPS.Рвота, clBaseKnow.SimptomMPS.Отсутствие_аппетита,
                     clBaseKnow.SimptomMPS.Сурдцебиение, clBaseKnow.SimptomMPS.Отдышка,
                     clBaseKnow.SimptomMPS.Мышечные_и_суставные_боли);

                ЕСЛИ(clBaseKnow.SimptomMPS.Боли_внизу_живота,
                     clBaseKnow.SimptomMPS.Учащенное_иногда_болезненное_мочеиспускание);

                ЕСЛИ(clBaseKnow.SimptomMPS.Нарушение_общего_самочувствия, clBaseKnow.SimptomMPS.Боли_внизу_живота,
                     clBaseKnow.SimptomMPS.Лихорадка);

                ЕСЛИ(clBaseKnow.SimptomMPS.Озноб, clBaseKnow.SimptomMPS.Боли_внизу_живота,
                     clBaseKnow.SimptomMPS.Рвота, clBaseKnow.SimptomMPS.Зуд_наружных_половых_органов);
            }

            //var d = _clBolesni.GetSimptomesByName((clBaseKnow.Bolesni)Enum.Parse(typeof(clBaseKnow.Bolesni), bolesn));
            //foreach (var mps in d)
            //{
            //    Console.WriteLine(mps);
            //}

            {
                for (var i = clBaseKnow.Bolesni.start + 1; i < clBaseKnow.Bolesni.end; i++)
                {
                    var outres = 0;
                    if (int.TryParse(i.ToString(), out outres)) continue;
                    var bolesn = i.ToString();//дергаем болезнь из списка
                    var d = _clBolesni.GetSimptomesByName((clBaseKnow.Bolesni)Enum.Parse(typeof(clBaseKnow.Bolesni), bolesn));
                    var activStatesFl = new List<bool>();
                    foreach (var mps in d)//вывод симптомов для болезни
                    {
                        var numBlsn = "";
                        if (!_clBolesni.isActivateSimptom(mps.Key))
                        {
                            Console.Write("Симптом " + mps + " есть? y/n \r\n");
                            numBlsn = Console.ReadLine();
                        }
                        else numBlsn = "y";
                        activStatesFl.Add(numBlsn == "y" ? true : false);
                    }
                    Console.WriteLine();
                    //выставить симптомы
                    var res = _clBolesni.SetActivSimptom((clBaseKnow.Bolesni)Enum.Parse(typeof(clBaseKnow.Bolesni), bolesn), activStatesFl);
                    if (res)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Болезнь {0} подтверждена!", (clBaseKnow.Bolesni)Enum.Parse(typeof(clBaseKnow.Bolesni), bolesn));
                        foreach (var keyVal in _clBolesni.GetSimptomesByName(
                                              (clBaseKnow.Bolesni) Enum.Parse(typeof (clBaseKnow.Bolesni), bolesn)))
                            Console.WriteLine("Симптомы {0}", keyVal);
                        break;
                    }
                }
            }

            Console.ReadKey();
        }

        private static clBaseKnow.Bolesni ЕСЛИ(params clBaseKnow.SimptomMPS []obj)
        {
            var sum = obj.Sum(simptomMps => (int) simptomMps);
            for (var i = clBaseKnow.Bolesni.start; i <= clBaseKnow.Bolesni.end; i++)
                if ((int)i == sum)
                {
                    //заполняем базу связкой Болезнь-Симптомы
                    _clBolesni = new Bolesni(i, obj);
                    return i;
                }

            return clBaseKnow.Bolesni.start;
        }
    }
}
