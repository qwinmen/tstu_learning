using DevComponents.DotNetBar;

namespace Шахматы
{
    /// <summary>
    /// Пешка превращается в другую ранговую фигуру
    /// </summary>
    public partial class fTransformPawnToN
    {
        public fTransformPawnToN()
        {
            InitializeComponent();
            Increment = 0; Increment++;
            OpisanieTXT("btnILaden");
        }
        /// <summary>
        /// Общая форма "btnInn_n"
        /// </summary>
        private int Increment;

        /// <summary>
        /// Принудительно повысить инкремент новой фигуры
        /// </summary>
        internal void UpIncrement()
        {
            Increment++;
            SelectedFigure = _figName + "_" + Increment;
        }

        private void OpisanieTXT(string figType)
        {
            switch (figType)
            {
                case "btnILaden":
                    opisaniePlus.Text = "ход на дальняк";
                    opisanieMinus.Text = "ход только по прямой";
                    break;
                case "btnIKoni":
                    opisaniePlus.Text = "взятие радиальных барьеров";
                    opisanieMinus.Text = "важна позиция";
                    break;
                case "btnISlon":
                    opisaniePlus.Text = "ход на дальняк";
                    opisanieMinus.Text = "ход только по диагонали\n\rход по клеткам цвета фигуры";
                    break;
                case "btnIFerz":
                    opisaniePlus.Text = "безбашенная фигура";
                    opisanieMinus.Text = "нет";
                    break;
            }
        }
        /// <summary>
        /// Ознакомление с ттх фигуры
        /// </summary>
        private void btnILaden_Click(object sender, System.EventArgs e)
        {
            opisanieMinus.Text = " \n\r ";

            var figure = sender as ButtonItem;
            if(figure!=null)
                OpisanieTXT(figure.Name);
        }
        /// <summary>
        /// Подтверждение выбранной фигуры
        /// </summary>
        private void btnIFerz_DoubleClick(object sender, System.EventArgs e)
        {
            var figure = sender as ButtonItem;
            if (figure != null)
            {
                SelectedFigure = figure.Name+"_"+Increment;
                _figName = figure.Name;
                this.Close();
            }
        }

        private string _figName;

        /// <summary>
        /// Выбранная фигура
        /// </summary>
        public string SelectedFigure { get; private set; }
        
    }
}
