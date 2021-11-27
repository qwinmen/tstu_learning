
namespace Шахматы
{
    class clXod
    {
        /// <summary>
        /// Отметка о выборе фигуры для хода
        /// </summary>
        public bool XodStart { get; set; }
        /// <summary>
        /// Отметка о завершении хода
        /// </summary>
        public bool XodEnd { get; set; }
        /// <summary>
        /// Тег фигуры, которой совершено начало хода
        /// </summary>
        public string XodStartFigureTag { get; set; }

        /// <summary>
        /// Очередность ходов
        /// </summary>
        public bool BlackGo { get; set; }
        /// <summary>
        /// Первыми ходят ЧЕРНЫЕ?
        /// </summary>
        public clXod(bool goBlack)
        {//true первый ход - черных\\иначе - белых
            BlackGo = goBlack;
        }

        /// <summary>
        /// Сбросить ход.
        /// </summary>
        public void ResetXodState()
        {
            if(XodStart && XodEnd)
            {
                XodStart = false;
                XodEnd = false;
                XodStartFigureTag = "";
            }
        }

        /// <summary>
        /// Выдернуть часть названия фигуры
        /// </summary>
        public string ConteinsFigure(string xodStartFigureTag)
        {
            //определить - чё за кнопка?//тип фигуры
            if (xodStartFigureTag.Contains("ПЕШКА")) return "ПЕШКА";
            if (xodStartFigureTag.Contains("ЛАДЬЯ")) return "ЛАДЬЯ";
            if (xodStartFigureTag.Contains("КОНЬ")) return "КОНЬ";
            if (xodStartFigureTag.Contains("СЛОН")) return "СЛОН";
            if (xodStartFigureTag.Contains("КАРОЛЬ")) return "КАРОЛЬ";
            if (xodStartFigureTag.Contains("ФЕРЗЬ")) return "ФЕРЗЬ";

            return "null";
        }
    }
}
