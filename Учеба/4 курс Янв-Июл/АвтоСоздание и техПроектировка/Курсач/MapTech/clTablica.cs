using System.Collections.Generic;
using System.Linq;
using unvell.ReoGrid;

namespace MapTech
{
    class clTablica
    {
        //А-Номер цеха, участка, рабочего места, где выполняется операция, номер операции, код и наименование операции, обозначение документов
        //Б-Код, наименование оборудования и информация по трудозатратам
        //В-Номер цеха, участка, рабочего места, где выполняется операция, номер операции, код и наименование операции
        //О-Содержание операции (перехода)
        //Т-Информация о применяемой при выполнении операции технологической оснастке

        public clTablica()
        {
            
        }
        /// <summary>
        /// 3начения для Таблица Операций
        /// Код операции по Технологическому Классификатору
        /// </summary>
        public enum OperationEnum
        {
            Зарузка = 3422,
            Транспортировка = 8428,
            Дробление = 6909,
            Контроль = 9253,
            Сушка = 6839,
            Гранулирование = 4463,
            Подогрев = 1155,
            Смешивание = 5313
        }

        /// <summary>
        /// 3начения для пункта О
        /// Пояснение операции (перехода)
        /// </summary>
        public Dictionary<OperationEnum, string> OpisanieOperationEnum = new Dictionary<OperationEnum, string>()
                                                                             {
                                                                                 {OperationEnum.Зарузка, "Выполнить загрузку сырья на транспортную линию с целью дальнейшей обработки;"},
                                                                                 {OperationEnum.Транспортировка, "Выполнить транспортировку сырья на ленточном конвеере до следующего шага обработки;"},
                                                                                 {OperationEnum.Дробление, "Произвести измельчение сырья, поступившего на вход аппарата. Размеры частичек сырья на выходе 3мм. (±0.2мм);"},
                                                                                 {OperationEnum.Контроль, "Проверить поступающий поток сырья на предмет инородных частиц металла;"}, 
                                                                                 {OperationEnum.Сушка, "Произвести сушку песка для последующего этапа производства;"},
                                                                                 {OperationEnum.Гранулирование, "Выполнить операцию получения конечного сырья - гранул, с целью их вторичной переработки;"}, 
                                                                                 {OperationEnum.Подогрев, "Разогреть сырье до вязкого состояния. Температурный режим 180°С (±1°С);"},
                                                                                 {OperationEnum.Смешивание, "Перемешать отходы пластиков, используя свойства вязкости расплавленных полимеров;"}, 
                                                                             };

        private int _indexStroka = 3;
        /// <summary>
        /// Вставка новой строки
        /// </summary>
        /// <param name="содержимоеЯчеек">АБВ/0123/.../</param>
        internal void ДобавитьНовуюСтроку(List<string> содержимоеЯчеек, ReoGridControl reoGridControl_МаршрутнаяКарта)
        {
            if (содержимоеЯчеек.Count == 0) return;

            var sheet = reoGridControl_МаршрутнаяКарта.CurrentWorksheet;
            var posStr = 1;
            var arrABCDHead = Enumerable.Range(0, 26).Select((x, i) => (char)('A' + i)).ToArray();

            foreach (var str in содержимоеЯчеек)
            {
                if (posStr >= arrABCDHead.Length) posStr = 1;
                var cellXY = arrABCDHead[posStr - 1].ToString() + _indexStroka;//[A]+1/[B]+1
                //колонка под буквы А-Б-Т-О-...\\Выравниваем по центру ячейки
                if (posStr == 1)
                {
                    sheet.Cells[cellXY].Style.HAlign = ReoGridHorAlign.Center;
                    sheet[cellXY] = str=="" ? str : str + _indexStroka;

                    posStr++; continue;
                }
                //объединение ячеек и добавление текста в полученную ячейку
                if (содержимоеЯчеек[0].IndexOfAny("ОТ".ToCharArray()) != -1)
                    sheet.MergeRange(arrABCDHead[1].ToString() + _indexStroka + ":M" + _indexStroka);
                sheet[cellXY] = str;
                posStr++;
            }

            _indexStroka++;
        }


        internal void СоздатьШапкуКарты(ReoGridControl reoGridControl_МаршрутнаяКарта)
        {
            //А-Номер цеха, участка, рабочего места, где выполняется операция, номер операции, код и наименование операции, обозначение документов
            //Б-Код, наименование оборудования и информация по трудозатратам
            //В-Номер цеха, участка, рабочего места, где выполняется операция, номер операции, код и наименование операции
            //О-Содержание операции (перехода)
            //Т-Информация о применяемой при выполнении операции технологической оснастке
            var sheet = reoGridControl_МаршрутнаяКарта.CurrentWorksheet;
            sheet.SetColumnsWidth(1, 15, 50);
            {
                sheet["A1"] = "А"; sheet.Cells["A1"].Style.HAlign = ReoGridHorAlign.Center;
                sheet["B1"] = "Цех";
                sheet["C1"] = "Уч";
                sheet["D1"] = "РМ";
                sheet["E1"] = "Опер";
                sheet["F1"] = "Код, наименование операции"; sheet.SetColumnsWidth(5, 2, 200);
                sheet["G1"] = "Обозначение документа"; 
            }
            {
                sheet["A2"] = "Б"; sheet.Cells["A2"].Style.HAlign = ReoGridHorAlign.Center;
                sheet["B2"] = "Код, наименование оборудования"; sheet.SetColumnsWidth(1, 1, 210);
                sheet["C2"] = "СМ";
                sheet["D2"] = "Проф";//http://professions.org.ru/?page=14
                sheet["E2"] = "Р";
                sheet["F2"] = "УТ";
                sheet["G2"] = "КР";
                sheet["H2"] = "КОИД";
                sheet["I2"] = "ЕН";
                sheet["J2"] = "ОП";
                sheet["K2"] = "Кшт";
                sheet["L2"] = "Тпз";
                sheet["M2"] = "Тшт";
            }

        }

        public struct A
        {
            public string _цех;
            public string _учстк;
            public string _рабмсто;
            public string _опер;
            public string _кодИмяОпрц;
            public string _обзДокум;
            public A(string цех, string учстк, string рабмсто, string опер, string кодИмяОпрц, string обзДокум, ReoGridControl reoGridControl_МКарта)
            {
                _цех = цех;
                _учстк = учстк;
                _рабмсто = рабмсто;
                _опер = опер;
                _обзДокум = обзДокум;
                _кодИмяОпрц = кодИмяОпрц;
                _list = new List<string> {"А", _цех, _учстк, _рабмсто, _опер, _кодИмяОпрц, _обзДокум};
                _reoGridControl_МаршрутнаяКарта = reoGridControl_МКарта;
            }

            public ReoGridControl _reoGridControl_МаршрутнаяКарта;
            public List<string> _list;
        }

        public struct Б
        {
            public string _кдНаимОбруд;
            public string _СтпнМехнзци;
            public string _КодПрофессии;
            public string _разрдРабт;
            public string _кдУслвТруда;
            public string _колРабочих;
            public string _колДетлВТаре;
            public string _едНормир;
            public string _обемТранспПартии;
            public string _кэфШтучВремен;
            public string _времПодгНаОпрацю;
            public string _времШтучНаОпрацю;

            public Б(string кдНаимОбруд, string СтпнМехнзци, string КодПрофессии, string разрдРабт, string кдУслвТруда, string колРабочих,
                string колДетлВТаре, string едНормир, string обемТранспПартии, string кэфШтучВремен, string времПодгНаОпрацю,
                string времШтучНаОпрацю, ReoGridControl reoGridControl_МКарта)
            {
                _кдНаимОбруд = кдНаимОбруд;
                _СтпнМехнзци = СтпнМехнзци;
                _КодПрофессии = КодПрофессии;
                _разрдРабт = разрдРабт;
                _кдУслвТруда = кдУслвТруда;
                _колРабочих = колРабочих;
                _колДетлВТаре = колДетлВТаре;
                _едНормир = едНормир;
                _обемТранспПартии = обемТранспПартии;
                _кэфШтучВремен = кэфШтучВремен;
                _времПодгНаОпрацю = времПодгНаОпрацю;
                _времШтучНаОпрацю = времШтучНаОпрацю;

                _list = new List<string> {"Б",   кдНаимОбруд,   СтпнМехнзци,   КодПрофессии,   разрдРабт,   кдУслвТруда,   колРабочих,
                                    колДетлВТаре,   едНормир,   обемТранспПартии,   кэфШтучВремен,   времПодгНаОпрацю,времШтучНаОпрацю};
                _reoGridControl_МаршрутнаяКарта = reoGridControl_МКарта;
            }

            public ReoGridControl _reoGridControl_МаршрутнаяКарта;
            public List<string> _list;
        }

        public struct О
        {
            public string _СодержаниеОперацииПерехода;
            public О(string СодержаниеОперацииПерехода, ReoGridControl reoGridControl_МКарта)
            {
                _СодержаниеОперацииПерехода = СодержаниеОперацииПерехода;

                _list = new List<string> {"О", _СодержаниеОперацииПерехода};
                _reoGridControl_МаршрутнаяКарта = reoGridControl_МКарта;
            }

            public ReoGridControl _reoGridControl_МаршрутнаяКарта;
            public List<string> _list;
        }

        public struct Т
        {
            public string _ТехнологичОснасткаОборудование;
            public Т(string ТехнологичОснасткаОборудование, ReoGridControl reoGridControl_МКарта)
            {
                _ТехнологичОснасткаОборудование = ТехнологичОснасткаОборудование;

                _list = new List<string> { "Т", _ТехнологичОснасткаОборудование };
                _reoGridControl_МаршрутнаяКарта = reoGridControl_МКарта;
            }

            public ReoGridControl _reoGridControl_МаршрутнаяКарта;
            public List<string> _list;
        }

        /// <summary>
        /// Вставить строку по шаблону -А
        /// </summary>
        /// <param name="structA"></param>
        internal void АtrokaSet(A structA)
        {
            ДобавитьНовуюСтроку(structA._list, structA._reoGridControl_МаршрутнаяКарта);
        }

        /// <summary>
        /// Вставить строку по шаблону -Б
        /// </summary>
        /// <param name="structБ"></param>
        internal void БstrokaSet(Б structБ)
        {
            ДобавитьНовуюСтроку(structБ._list, structБ._reoGridControl_МаршрутнаяКарта);
        }

        /// <summary>
        /// Вставить строку по шаблону -О
        /// </summary>
        /// <param name="structО"></param>
        internal void ОstrokaSet(О structО)
        {
            ДобавитьНовуюСтроку(structО._list, structО._reoGridControl_МаршрутнаяКарта);
        }

        /// <summary>
        /// Вставить строку по шаблону -Т
        /// </summary>
        /// <param name="structТ"></param>
        internal void ТstrokaSet(Т structТ)
        {
            ДобавитьНовуюСтроку(structТ._list, structТ._reoGridControl_МаршрутнаяКарта);
        }

        /// <summary>
        /// Вставить пустую строку
        /// </summary>
        /// <param name="reoGridControl_МаршрутнаяКарта"></param>
        internal void ПустаяСтрока(ReoGridControl reoGridControl_МаршрутнаяКарта)
        {
            ДобавитьНовуюСтроку(new List<string>(){""}, reoGridControl_МаршрутнаяКарта);
        }



    }
}
