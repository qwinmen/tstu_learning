using ZedGraph;

namespace GModel
{
    /// <summary>
    /// - Массивы придется инициализировать перед использованием
    /// - Обьявлять все что тут есть там где хош реализовать
    /// + Более менее с типами не_массивов для единичного хранения
    /// Note: вывод - для одних и техже переменных лучше использовать отдельный класс и наследовать его
    /// </summary>
    internal interface IInterface
    {
        /// <summary>
        /// Для точек на экране (отрисовка)
        /// </summary>
        GraphPane IPane { get; set; }

        /// <summary>
        /// Ссылка на контрол формы
        /// </summary>
        ZedGraphControl IZedGraph { get; set; }

        /// <summary>
        /// Флаг разрешает ставить точки на холсте
        /// </summary>
        bool IActivSetPoint { get; set; }

        /// <summary>
        /// индекс для ориентира в массиве (смены координаты точки)
        /// </summary>
        int IIndex { get; set; }

        /// <summary>
        /// Итератор массива точек
        /// </summary>
        int INum { get; set; }

        /// <summary>
        /// Флаг активности класса
        /// </summary>
        bool IeActive { get; set; }
    }
}
