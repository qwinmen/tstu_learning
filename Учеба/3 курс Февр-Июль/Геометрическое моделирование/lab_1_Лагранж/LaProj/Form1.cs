using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

//http://matica.org.ua/spravochnik-a-a-gusak-v-m-gusak/31-1-interpolyatsionniy-mnogochlen-lagranzha
//http://jenyay.net/ZedGraph/Simple
/*
 Кликаем и получаем набор точек
 * Высчитываем формулу из точек
 * Строим ZedGraph_график по формуле 
 */
namespace LaProj
{
    public partial class Form1 : Form
    {
        
        /// <summary>
        /// Для копипаста экранных опорных точек
        /// </summary>
        private PointD[] _pointArr;
        /// <summary>
        /// Храним опорные точки с экрана
        /// </summary>
        private List<PointD> _lpointArr = new List<PointD>();
        /// <summary>
        /// Итератор массива точек
        /// </summary>
        private int _num = 0;
        /// <summary>
        /// Для точек на экране (отрисовка)
        /// </summary>
        private GraphPane _pane;

        public Form1()
        {
            InitializeComponent();
            zedGraph.GraphPane.Title.Text = "";
            zedGraph.GraphPane.YAxis.Title.Text = "Ось Y";
            zedGraph.GraphPane.XAxis.Title.Text = "Ось X";
            
        }

        // Создадим список точек
        private PointPairList _list = new PointPairList();

        /// <summary>
        /// Отрисовка графика функции
        /// </summary>
        private void DrawGraph()
        {
            // Получим панель для рисования
            GraphPane pane = zedGraph.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            //pane.CurveList.Clear();

            double xmin_limit = -80, xmax_limit = +80;
            double ymin_limit = -80, ymax_limit = +80;

            // !!!
            // Устанавливаем интересующий нас интервал по оси X
            pane.XAxis.Scale.Min = xmin_limit;
            pane.XAxis.Scale.Max = xmax_limit;

            // !!!
            // Устанавливаем интересующий нас интервал по оси Y
            pane.YAxis.Scale.Min = ymin_limit;
            pane.YAxis.Scale.Max = ymax_limit;
            
            
            // Включим отображение сетки
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;

            // Создадим кривую с названием "Sinc",// которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve("Sinc", _list, Color.Blue, SymbolType.None);

            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();
        }

        /// <summary>
        /// Снять опорную точку
        /// Отобразить точку на холсте
        /// </summary>
        private void zedGraph_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
                return;
            // Сюда будут записаны координаты в системе координат графика
            double x, y;

            // Пересчитываем пиксели в координаты на графике
            // У ZedGraph есть несколько перегруженных методов ReverseTransform.
            zedGraph.GraphPane.ReverseTransform(e.Location, out x, out y);

            // Выводим результат
            lblCoordinates.Text = string.Format("X: {0:#.###}; Y: {1:#.###}", x, y);

            //Ставим точку где кликнули
            _pane = zedGraph.GraphPane;
            
            //поставить точку по [x;y]
            SetPointCurve(x,y);

            _lpointArr.Add(new PointD(x, y));
            
        }

        /// <summary>
        /// Нарисовать точку по координате
        /// </summary>
        private void SetPointCurve(double x, double y)
        {
            LineItem curvePount = _pane.AddCurve("", new[] { x }, new[] { y }, Color.Blue, SymbolType.Circle);
            
            // У кривой линия будет невидимой
            curvePount.Line.IsVisible = false;

            // Цвет заполнения круга - колубой
            curvePount.Symbol.Fill.Color = Color.Blue;

            // Тип заполнения - сплошная заливка
            curvePount.Symbol.Fill.Type = FillType.Solid;

            // Размер круга
            curvePount.Symbol.Size = 7;

            //zedGraph.AxisChange();
        }

        /// <summary>
        /// Точки сняты, рассчитать формулу
        /// </summary>
        private void btnBuild_Click(object sender, EventArgs e)
        {
            _pointArr = new PointD[_lpointArr.Count];
            _lpointArr.CopyTo(_pointArr);
            _num = _pointArr.Length;

            #region построить график

            int n = _num - 1;//n скобок на 1 дробьЧислитель
            double[] res = new double[_num];
            // Интервал, где есть данные
            double xmin = _pointArr[0].X;//-100;
            double xmax = _pointArr[n].X;//100;

            var text = "";
            foreach (PointD pointD in _pointArr)
            {
                text += "[" + pointD.X + "; " + pointD.Y + "] ";
            }
            MessageBox.Show(text);
            
            // Заполняем список точек
            //_list.Add(xmin, _pointArr[0].Y);
            for (double x = xmin; x <= xmax; x +=0.01)
            {
                //_num //Количество дробей == количеству точек
                for (int i = 0; i < _num; i++)
                {
                    //за один такт вычислить 1 дробь
                    //1)составить скобки в дроби
                    double resLocDrob = СобратьЧислитель(n, x, i)/СобратьЗнаменатель(n, x, i);
                    //Итог в i-дроби есть число:
                    res[i] = _pointArr[i].Y * resLocDrob;
                }

                double tmp = 0.0;
                foreach (double re in res)
                {//просуммировать итог(результат n-дробей)
                    tmp += re;
                }
                //SetPointCurve(x,tmp);
                // добавим в список точку
                _list.Add(x, tmp);
            }
            
            DrawGraph();
            #endregion
            
        }

        /// <summary>
        /// Собрать числитель дроби
        /// </summary>
        /// <param name="n">Количество скобок</param>
        /// <param name="x">Точка для которой ищем У</param>
        /// <param name="i">Номер дроби для генератора</param>
        private double СобратьЧислитель(int n, double x, int i)
        {
            double temp = 0.0;
            //Общий вид: (x-generator)*(x-generator)
            for (int j = 0; j < n; j++)
            {
                //собрать скобку
                if (temp == 0.0)
                    temp = (x - generator(i, j));
                else temp = temp * (x - generator(i, j));
            }

            return temp;
        }

        /// <summary>
        /// Собрать знаменатель дроби
        /// </summary>
        /// <param name="n">Количество скобок</param>
        /// <param name="x">Точка для которой ищем У</param>
        /// <param name="i">Номер дроби для генератора</param>
        private double СобратьЗнаменатель(int n, double x, int i)
        {
            double temp = 0.0;
            //Общий вид: (xi-generator)*(xi-generator)
            for (int j = 0; j < n; j++)
            {
                //собрать скобку
                if (temp == 0.0)
                    temp = (_pointArr[i].X - generator(i, j));
                else temp = temp * (_pointArr[i].X - generator(i, j));
            }

            return temp;
        }

        private int _gindex;

        /// <summary>
        /// Определить какой Х использовать
        /// </summary>
        /// <param name="i">Порядковый номер дроби</param>
        /// <param name="j">Текущая скобка номер</param>
        /// <returns></returns>
        private double generator(int i, int j)
        {
            if (j == 0)
                _gindex = i + 1;
            else _gindex++;

            if (_gindex >= _pointArr.Length)
                _gindex = 0;

            return _pointArr[_gindex].X;
        }

        /// <summary>
        /// Очистить форму и массивы точек
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            _gindex = 0;
            _list.Clear();
            _num = 0;
            _pointArr = null;
            _lpointArr.Clear();
            lblCoordinates.Text = "--X--;--Y--";

            _pane.CurveList.Clear();
            zedGraph.Refresh();
        }

    }
}
