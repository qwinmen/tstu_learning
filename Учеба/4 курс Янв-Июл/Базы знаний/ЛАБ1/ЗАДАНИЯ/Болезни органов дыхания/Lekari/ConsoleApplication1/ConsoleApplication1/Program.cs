using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Вариант 7
namespace ConsoleApplication1
{
    class Program
    {
        private static Bolesni _clBolesni;

        static void Main(string[] args)
        {
            _clBolesni = new Bolesni();

            {//Note: Формируем базу знаний из известных данной болезни симптомов:
                //кат ангина
                ЕСЛИ(clBaseKnow.SimptomMPS.Воспаление_в_небных_миндалинах,
                 clBaseKnow.SimptomMPS.Слабость, clBaseKnow.SimptomMPS.Головная_боль,
                 clBaseKnow.SimptomMPS.Температура, clBaseKnow.SimptomMPS.Першение_сухость_боль_при_глотании,
                 clBaseKnow.SimptomMPS.Увеличенные_небные_миндалины);

                //лакунарная ангина
                ЕСЛИ(clBaseKnow.SimptomMPS.Воспаление_в_небных_миндалинах,
                     clBaseKnow.SimptomMPS.Слабость, clBaseKnow.SimptomMPS.Головная_боль, clBaseKnow.SimptomMPS.Температура,
                     clBaseKnow.SimptomMPS.Першение_сухость_боль_при_глотании, clBaseKnow.SimptomMPS.На_поверхности_покрасневших_миндалин_белесовато_желтый_налет);

                //фолликулярная ангина
                ЕСЛИ(clBaseKnow.SimptomMPS.Воспаление_в_небных_миндалинах,
                     clBaseKnow.SimptomMPS.Слабость, clBaseKnow.SimptomMPS.Головная_боль,
                     clBaseKnow.SimptomMPS.Температура, clBaseKnow.SimptomMPS.Першение_сухость_боль_при_глотании,
                     clBaseKnow.SimptomMPS.На_поверхности_покрасневших_миндалин_нагноившиеся_пузырьки_фолликулы);

                //ларингит
                ЕСЛИ(clBaseKnow.SimptomMPS.Воспаление_слизистой_оболочки_гортани, clBaseKnow.SimptomMPS.Головная_боль,
                     clBaseKnow.SimptomMPS.Температура, clBaseKnow.SimptomMPS.Царапанье_в_горле,
                     clBaseKnow.SimptomMPS.Сухой_кашель, clBaseKnow.SimptomMPS.Голос_хриплый_грубый_или_пропадает);

                //абцесс легкого
                ЕСЛИ(clBaseKnow.SimptomMPS.Лихорадка,
                     clBaseKnow.SimptomMPS.Озноб, clBaseKnow.SimptomMPS.Обильный_пот, 
                     clBaseKnow.SimptomMPS.Мучительный_кашель_с_умеренным_количеством_мокроты, 
                     clBaseKnow.SimptomMPS.Боли_в_боку, clBaseKnow.SimptomMPS.Малоподвижность, 
                     clBaseKnow.SimptomMPS.Отдышка, clBaseKnow.SimptomMPS.Слабость);

                //альвоепит
                ЕСЛИ(clBaseKnow.SimptomMPS.Лихорадка, clBaseKnow.SimptomMPS.Кашель_с_мокротой_и_быстро_нарастающая_отдышка,
                     clBaseKnow.SimptomMPS.Чувство_стеснения_в_груди);

                //бронх астма
                ЕСЛИ(clBaseKnow.SimptomMPS.Приступы_или_периодические_состояния_удушья);

                //бронхит
                ЕСЛИ(clBaseKnow.SimptomMPS.Сухой_кашель, clBaseKnow.SimptomMPS.Отдышка, 
                    clBaseKnow.SimptomMPS.Головная_боль, clBaseKnow.SimptomMPS.Слабость);

                //бронхиолит
                ЕСЛИ(clBaseKnow.SimptomMPS.Температура, clBaseKnow.SimptomMPS.Мучительный_кашель_с_умеренным_количеством_мокроты,
                    clBaseKnow.SimptomMPS.Бледность_и_синюшность_кожи);

                //гайморит
                ЕСЛИ(clBaseKnow.SimptomMPS.Головная_боль, clBaseKnow.SimptomMPS.Насморк);


                //сухой плеврит
                ЕСЛИ(clBaseKnow.SimptomMPS.Боли_в_заднебоковых_отделах_нижней_части_грудной_клетки,
                    clBaseKnow.SimptomMPS.Ограничение_дыхательных_движений,
                    clBaseKnow.SimptomMPS.Слабость);

                //серозный плеврит
                ЕСЛИ(clBaseKnow.SimptomMPS.Боли_в_заднебоковых_отделах_нижней_части_грудной_клетки, clBaseKnow.SimptomMPS.Ограничение_дыхательных_движений,
                    clBaseKnow.SimptomMPS.Отдышка, clBaseKnow.SimptomMPS.Выбухание_межреберных_промежутков);

                //пневмония
                ЕСЛИ(clBaseKnow.SimptomMPS.Головная_боль, clBaseKnow.SimptomMPS.Слабость,
                    clBaseKnow.SimptomMPS.Температура, clBaseKnow.SimptomMPS.Озноб, clBaseKnow.SimptomMPS.Боли_в_грудной_клетке_при_вдохе_и_кашле);

                //трахет
                ЕСЛИ(clBaseKnow.SimptomMPS.Сухой_кашель, clBaseKnow.SimptomMPS.Головная_боль,
                    clBaseKnow.SimptomMPS.Температура);

                //тонзелит
                ЕСЛИ(clBaseKnow.SimptomMPS.Першение_сухость_боль_при_глотании, clBaseKnow.SimptomMPS.Покраснение_и_рыхлость_в_лакунах_миндалин,
                   clBaseKnow.SimptomMPS.Температура, clBaseKnow.SimptomMPS.Сухой_кашель);

            }

            {
                for (var i = clBaseKnow.Bolesni.start + 1; i < clBaseKnow.Bolesni.end; i++)
                {
                    var outres = 0;//если цифра парсится, то пропускаем, эт не болезнь
                    if (int.TryParse(i.ToString(), out outres)) continue;

                    var bolesn = i.ToString();//дергаем болезнь из списка
                    //получить список симптомов для очередной болезни
                    var d = _clBolesni.GetSimptomesByName((clBaseKnow.Bolesni)Enum.Parse(typeof(clBaseKnow.Bolesni), bolesn)); 
                    //флаги есть\нет симптома
                    var activStatesFl = new List<bool>();
                    foreach (var mps in d)//вывод симптомов для болезни
                    {
                        var numBlsn = "";
                        //если симптом не выставлен в true, то на подтверждение
                        if (!_clBolesni.isActivateSimptom(mps.Key))
                        {
                            Console.Write("Симптом " + mps + " есть? y/n \r\n");
                            numBlsn = Console.ReadLine();//yes\no
                        }
                        else numBlsn = "y";//если был ранее активен, то true
                        //результирующий флаг в список
                        activStatesFl.Add(numBlsn == "y" ? true : false);
                    }
                    Console.WriteLine();
                    //выставить симптомы//передаем имя очередной_болезни и список флагов для симптомов
                    var res = _clBolesni.SetActivSimptom((clBaseKnow.Bolesni)Enum.Parse(typeof(clBaseKnow.Bolesni), bolesn), activStatesFl);
                    //true если найдена болезнь
                    if (res)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Болезнь {0} подтверждена!", (clBaseKnow.Bolesni)Enum.Parse(typeof(clBaseKnow.Bolesni), bolesn));
                        foreach (var keyVal in _clBolesni.GetSimptomesByName(
                                              (clBaseKnow.Bolesni)Enum.Parse(typeof(clBaseKnow.Bolesni), bolesn)))
                            Console.WriteLine("Симптомы {0}", keyVal);
                        
                        Console.WriteLine("Справка: {0}",clBaseKnow.Лечение((clBaseKnow.Bolesni)Enum.Parse(typeof(clBaseKnow.Bolesni), bolesn)));
                        break;
                    }
                }
            }
               
            Console.ReadKey();
        }

        private static clBaseKnow.Bolesni ЕСЛИ(params clBaseKnow.SimptomMPS[] obj)
        {
            //суммируем цифровые поля переданных симптомов
            var sum = obj.Sum(simptomMps => (int)simptomMps);

             for (var i = clBaseKnow.Bolesni.start; i <= clBaseKnow.Bolesni.end; i++)
                 if ((int)i == sum)//сумма совпала с полем болезни
                 {
                     //заполняем базу связкой Болезнь-Симптомы
                     _clBolesni = new Bolesni(i, obj);
                     return i;
                 }

                //заглушка
            return clBaseKnow.Bolesni.start;
        }
    }
}
