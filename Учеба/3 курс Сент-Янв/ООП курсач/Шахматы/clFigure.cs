
namespace Шахматы
{
    class clFigure
    {
        private readonly string _nameFigure;

        /// <summary>
        /// Имя обьекта
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Поле для пешки - первый ход разрешено на две клетки.
        /// False - доступно два хода
        /// </summary>
        public bool OneGo { get; set; }
        /// <summary>
        /// Когда пешка превращается в фигуру высокого ранга
        /// </summary>
        public string TransformFigurePawn { get; set; }

        /// <summary>
        /// создать персональную фигуру
        /// </summary>
        public clFigure(string name)
        {
            _nameFigure = name;
            Name = _nameFigure;

            //если обьект - пешка, то понадобится поле ПЕРВЫЙ_ХОД
            if(name.Contains("ПЕШКА")) Pawn();

        }

        /// <summary>
        /// Первый ход на 1//2 клетки
        /// </summary>
        private void Pawn()
        {//ход разрешен
            OneGo = false;
        }

/*
 Кнопку на форме с записью положения в массиве связываем 
 * при помощи поля Tag кнопки.
 * У каждой панели поле Tag даёт адрес в массиве\на форме
 * типо .Tag=40 означает ячейку в массиве[4,0]
 */
        
        
    }
}
