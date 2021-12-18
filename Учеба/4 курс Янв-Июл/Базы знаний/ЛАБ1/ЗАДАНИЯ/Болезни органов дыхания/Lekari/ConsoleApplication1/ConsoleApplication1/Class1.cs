using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class clBaseKnow
    {
        /// <summary>
        /// Симптомы органов дыхания
        /// </summary>
        public enum SimptomMPS : int
        {//---------------1=MPS--------------------------
            Бледность_и_синюшность_кожи = 1,
            Боли_в_боку = 2,
            Боли_в_грудной_клетке_при_вдохе_и_кашле = 3,
            Боли_в_заднебоковых_отделах_нижней_части_грудной_клетки = 4,
            Воспаление_в_небных_миндалинах = 5,
            Воспаление_слизистой_оболочки_гортани = 6,
            Выбухание_межреберных_промежутков = 7,
            Головная_боль = 8,
            Голос_хриплый_грубый_или_пропадает = 9,
            Кашель_с_мокротой_и_быстро_нарастающая_отдышка = 10,
            Лихорадка = 11,
            Малоподвижность = 12,
            Мучительный_кашель_с_умеренным_количеством_мокроты = 13,
            На_поверхности_покрасневших_миндалин_белесовато_желтый_налет = 14,
            На_поверхности_покрасневших_миндалин_нагноившиеся_пузырьки_фолликулы = 15,
            Насморк = 16,
            Обильный_пот = 17,
            Ограничение_дыхательных_движений = 18,
            Озноб = 19,
            Отдышка = 20,
            Першение_сухость_боль_при_глотании = 21,
            Покраснение_и_рыхлость_в_лакунах_миндалин = 22,
            Приступы_или_периодические_состояния_удушья = 23,
            Слабость = 24,
            Сухой_кашель = 25,
            Температура = 26,
            Увеличенные_небные_миндалины = 27,
            Царапанье_в_горле = 28,
            Чувство_стеснения_в_груди = 29
            //---------------2=--------------------------
        }

        /// <summary>
        /// Болезнь = раздел_болезни
        /// </summary>
        public enum Bolesni : int
        {
            start = 0,
            end = 200,

            //----------1=MPS-----------------------
            абцесс_легкого = 118,//5 118
            альвеолит = 50,//6 50
            бронхиальная_астма = 23,//7 23
            бронхит = 77,//8 77
            бронхиолит = 40,//9 40
            гайморит = 24,//10 24
            катаральная_ангина = 111,//1 111
            лакунарная_ангина = 98,//2  98
            сухой_плеврит = 46,//11 46
            серозный_плеврит = 49,//12 49
            ларингит = 102,//4  102
            пневмония = 80,//13 80
            тонзилит = 94,//15 94
            трахеит = 59,//14 59
            фолликулярная_ангина = 99 //3  99
            //----------2=-----------------------

        }

        public static string Лечение(Bolesni name)
        {
            switch (name)
            {
                case Bolesni.абцесс_легкого:
                    return Properties.Settings.Default.абсцесс_легкого;
                case Bolesni.альвеолит:
                    return Properties.Settings.Default.альвеолит;
                case Bolesni.бронхиальная_астма:
                    return Properties.Settings.Default.бронхиальная_астма;
                case Bolesni.бронхит:
                    return Properties.Settings.Default.бронхит;
                case Bolesni.бронхиолит:
                    return Properties.Settings.Default.бронхиолит;
                case Bolesni.гайморит:
                    return Properties.Settings.Default.гайморит;
                case Bolesni.катаральная_ангина:
                    return Properties.Settings.Default.катаральная_ангина;
                case Bolesni.лакунарная_ангина:
                    return Properties.Settings.Default.лакунарная_ангина;
                case Bolesni.сухой_плеврит:
                case Bolesni.серозный_плеврит:
                    return Properties.Settings.Default.плеврит;
                case Bolesni.ларингит:
                    return Properties.Settings.Default.ларингит;
                case Bolesni.пневмония:
                    return Properties.Settings.Default.пневмония;
                case Bolesni.тонзилит:
                    return Properties.Settings.Default.тонзиллит;
                case Bolesni.трахеит:
                    return Properties.Settings.Default.трахеит;
                case Bolesni.фолликулярная_ангина:
                    return Properties.Settings.Default.фолликулярная_ангина;

                    defoult:
                    return "Травяной чай";
            }

            return "";
        }

    }

    internal class Bolesni
    {
        private clBaseKnow.Bolesni _name;
        
        private Dictionary<clBaseKnow.SimptomMPS, bool> _simptoms = new Dictionary<clBaseKnow.SimptomMPS, bool>();

        private static Dictionary<clBaseKnow.Bolesni, Dictionary<clBaseKnow.SimptomMPS, bool>> _keyValueArray =
            new Dictionary<clBaseKnow.Bolesni, Dictionary<clBaseKnow.SimptomMPS, bool>>();


        /// <summary>
        /// Внести болезнь и симптомы в картотеку
        /// </summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        public Bolesni(clBaseKnow.Bolesni name, params clBaseKnow.SimptomMPS[] obj)
        {
            _name = name;
            foreach (var simptomMps in obj)
                _simptoms.Add(simptomMps, false);

            _keyValueArray.Add(_name, _simptoms);
        }
        public Bolesni() { }
        /// <summary>
        /// Вернуть список симптомов по названию болезни
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Dictionary<clBaseKnow.SimptomMPS, bool> GetSimptomesByName(clBaseKnow.Bolesni name)
        {
            try
            {
                return _keyValueArray[name];
            }
            catch (KeyNotFoundException e)
            {
                throw new Exception("Болезни " + name + " нет в базе!");
                return null;
            }
        }

        /// <summary>
        /// По имени запросить симптомы и изменить статус активности
        /// </summary>
        /// <param name="name"></param>
        /// <param name="flagActiv"></param>
        /// <returns>Вернет true если все симптомы в true</returns>
        public bool SetActivSimptom(clBaseKnow.Bolesni name, List<bool> flagActiv)
        {
            var state = true;
            var resTmp = _keyValueArray[name];
            var dic = new Dictionary<clBaseKnow.SimptomMPS, bool>();
            var i = 0;
            foreach (KeyValuePair<clBaseKnow.SimptomMPS, bool> keyValuePair in resTmp)
            {
                dic.Add(keyValuePair.Key, flagActiv[i]);
                if (!flagActiv[i])
                    state = false;
                //иначе флаг Активен и поместить в стек
                else StackActivSimptoms(keyValuePair.Key);
                i++;
            }

            _keyValueArray[name] = dic;

            return state;
        }

        private static Stack<clBaseKnow.SimptomMPS> _stackSimptomsActiv = new Stack<clBaseKnow.SimptomMPS>();

        /// <summary>
        /// Положить активный симпт в стек
        /// </summary>
        /// <param name="simptomMps"></param>
        private void StackActivSimptoms(clBaseKnow.SimptomMPS simptomMps)
        {
            if (!_stackSimptomsActiv.Contains(simptomMps))
                _stackSimptomsActiv.Push(simptomMps);
        }

        /// <summary>
        /// Глянуть в стек по симптому, если там такой есть, то вернуть TRUE
        /// </summary>
        /// <param name="simptomMps"></param>
        /// <returns>Вернет Да, если там такой есть</returns>
        public bool isActivateSimptom(clBaseKnow.SimptomMPS simptomMps)
        {
            return _stackSimptomsActiv.Contains(simptomMps);
        }

    }

}
