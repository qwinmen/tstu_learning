using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lekari
{
    class clBaseKnow
    {
        /// <summary>
        /// Симптомы мочеполовой системы
        /// </summary>
        public enum SimptomMPS : int
        {//---------------1=MPS--------------------------
            Артериальное_давление_умеренно_повышено = 1,
            Бледность_кожных_покровов = 2,
            Боли_внизу_живота = 3,
            Головная_боль = 4,
            Задержка_стула_и_газов = 5,
            Зуд_наружных_половых_органов = 6,
            Интенсивные_боли_в_верхней_части_живота = 7,
            Интенсивные_боли_в_пояснице = 8,
            Лихорадка = 9,
            Мышечные_и_суставные_боли = 10,
            Нарушение_общего_самочувствия = 11,
            Обильный_пот = 12,
            Обильные_слизисто_гнойные_бели = 13,
            Одутловатость_лица = 14,
            Озноб = 15,
            Отдышка = 16,
            Отсутствие_аппетита = 17,
            Растройства_мочеиспускания = 18,
            Рвота = 19,
            Сурдцебиение = 20,
            Температура = 21,
            Тошнота = 22,
            Уменьшается_мочеотделение = 23,
            Ухудшение_аппетита = 24,
            Учащенное_иногда_болезненное_мочеиспускание = 25,
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
            экзема = 43,
            эндометрит = 23,
            цистит = 28,
            кольпит = 30,
            мочекаменная_болезнь = 86,
            гломерулонефрит = 87,
            пиелонефрит = 182,
            //----------2=-----------------------
            
        }

        

    }

    internal class Bolesni
    {
        private clBaseKnow.Bolesni _name;
        //private List<clBaseKnow.SimptomMPS> _simptoms = new List<clBaseKnow.SimptomMPS>();
        private Dictionary<clBaseKnow.SimptomMPS, bool > _simptoms = new Dictionary<clBaseKnow.SimptomMPS, bool>();

        private static Dictionary<clBaseKnow.Bolesni, Dictionary<clBaseKnow.SimptomMPS, bool>> _keyValueArray =
            new Dictionary<clBaseKnow.Bolesni, Dictionary<clBaseKnow.SimptomMPS, bool>>();
        

        /// <summary>
        /// Внести болезнь и симптомы в картотеку
        /// </summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        public Bolesni(clBaseKnow.Bolesni name, params clBaseKnow.SimptomMPS []obj)
        {
            _name = name;
            foreach (var simptomMps in obj)
                _simptoms.Add(simptomMps, false);

            _keyValueArray.Add(_name, _simptoms);
        }

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
                throw new Exception("Болезни "+name+" нет в базе!");
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
