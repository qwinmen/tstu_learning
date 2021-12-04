using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace VkusBese
{
    public partial class Form1 : Form
    {
        // Создадим список точек
        private PointPairList _list = new PointPairList();
        /// <summary>
        /// Для точек на экране (отрисовка)
        /// </summary>
        private GraphPane _pane;
        /// <summary>
        /// Итератор массива точек
        /// </summary>
        private int _num = 0;
        /// <summary>
        /// Храним опорные точки с экрана
        /// </summary>
        private List<PointD> _lpointArr = new List<PointD>();
        /// <summary>
        /// Для копипаста экранных опорных точек
        /// </summary>
        private PointD[] _pointArr;
        /// <summary>
        /// Флаг разрешает ставить точки на холсте
        /// </summary>
        private bool _activSetPoint;

        public Form1()
        {
            InitializeComponent();
            
            //_pane = zedGraph.GraphPane;
            

            zedGraph.GraphPane.Title.Text = "";
            zedGraph.GraphPane.YAxis.Title.Text = "Ось Y";
            zedGraph.GraphPane.XAxis.Title.Text = "Ось X";
            
            //если зажат cntrl то на перетаскивание точки
            // Перемещать точки можно будет с помощью средней кнопки мыши...
            zedGraph.EditButtons = MouseButtons.Left;

            // ... и при нажатой клавише Ctrl.
            zedGraph.EditModifierKeys = Keys.Control;

            // Точки можно перемещать, как по горизонтали,...
            zedGraph.IsEnableHEdit = true;

            // ... так и по вертикали.
            zedGraph.IsEnableVEdit = true;

            // Подпишемся на событие, вызываемое после перемещения точки
            zedGraph.PointEditEvent += new ZedGraphControl.PointEditHandler(zedGraph_PointEditEvent);
        }

        /// <summary>
        /// Обработчик события перемещения точки.
        /// При перемещении точки, информация о ней записывается в заголовок окна
        /// </summary>
        /// <param name="sender">Компонент ZedGraph</param>
        /// <param name="pane">Панель с графиком</param>
        /// <param name="curve">Кривая, точку которой переместили</param>
        /// <param name="iPt">Номер точки</param>
        /// <returns>Метод должен возвращать строку</returns>
        private string zedGraph_PointEditEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            //string title = string.Format("Точка: {0}. Новые координаты: ({1}; {2})", iPt, curve[iPt].X, curve[iPt].Y);
            if (curve.Tag != null)
                _lpointArr[(int) curve.Tag] = new PointD(curve[iPt].X, curve[iPt].Y);

            return "";
        }


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
            if (e.Button != MouseButtons.Left)
                return;

            //блочить рисование точки
            if (_activSetPoint)
                return;

            // Сюда будут записаны координаты в системе координат графика
            double x, y;

            // Пересчитываем пиксели в координаты на графике
            // У ZedGraph есть несколько перегруженных методов ReverseTransform.
            zedGraph.GraphPane.ReverseTransform(e.Location, out x, out y);
            

            //Ставим точку где кликнули
            _pane = zedGraph.GraphPane;

            //поставить точку по [x;y]
            SetPointCurve(x, y);

            _lpointArr.Add(new PointD(x, y));

        }

        
        /// <summary>
        /// индекс для ориентира в массиве (смены координаты точки)
        /// </summary>
        private int _index = 0;

        /// <summary>
        /// Нарисовать точку по координате
        /// </summary>
        private void SetPointCurve(double x, double y)
        {
            LineItem curvePount = _pane.AddCurve("", new[] { x }, new[] { y }, Color.Blue, SymbolType.Circle);
            // У кривой линия будет невидимой
            curvePount.Line.IsVisible = false;
            //Тег будет линком для поиска точки, которую надо перезаписать
            curvePount.Tag = _index++;
            // Цвет заполнения круга - колубой
            curvePount.Symbol.Fill.Color = Color.Blue;
            // Тип заполнения - сплошная заливка
            curvePount.Symbol.Fill.Type = FillType.Solid;
            // Размер круга
            curvePount.Symbol.Size = 7;
            //-----------------------------------------//
            zedGraph.Invalidate();
        }

        /// <summary>
        /// Точки сняты, рассчитать формулу
        /// </summary>
        private void btnBuild_Click(object sender, EventArgs e)
        {
            _pointArr = new PointD[_lpointArr.Count];
            _lpointArr.CopyTo(_pointArr);
            _num = _pointArr.Length;
            var res = new PointD[_num];
            _list.Clear();
            
            #region построить график

            for (double t = 0.01; t <= 1; t+=0.01)
            {
                for (int i = 0; i < _num; i++)
                {//для i-точки вычислить C*t*(1-t)*P
                    res[i] = Часть(i, _num-1, t, _pointArr[i]);
                }
                PointD tmp = new PointD();
                foreach (var pointD in res)
                {
                    tmp.X += pointD.X;
                    tmp.Y += pointD.Y;
                }
                // добавим в список точку
                _list.Add(tmp.X, tmp.Y);
            }
            
            #endregion
            DrawGraph();
        }

        
        /// <summary>
        /// для i-точки вычислить C*t*(1-t)*P
        /// </summary>
        private PointD Часть(int i, int m, double t, PointD P)
        {
            double ti = .0, tni = .0;
            if (t == 0.0 && i == 0) ti = 1.0;
            else ti = Math.Pow(t, i);

            if (m == i && t == 1.0) tni = 1.0;
            else tni = Math.Pow((1 - t), (m - i));

            double tmp = Koefficient_C(i, m)*ti*tni;
            return new PointD(tmp*P.X, tmp*P.Y);
        }

        private delegate double _C(int i, int m);
        /// <summary>
        /// Рассчитать коэффициент C для i-точки из m-точек
        /// </summary>
        private double Koefficient_C(int i, int m)
        {
            // C(i)(m)= m!/(i!(m-i)!)
            _C res = (_i, _m) =>
                          {
                              double res_m = 1, res_i = 1, res_im = 1;
                              for (int l = 1; l <= _m; l++)
                                  res_m = l*res_m;
                              for (int l = 1; l <= _i; l++)
                                  res_i = l * res_i;
                              for (int l = 1; l <= (_m-_i); l++)
                                  res_im = l * res_im;
                              return res_m/(res_i*res_im);
                          };

            return res(i, m);
        }

        /// <summary>
        /// Очистить форму и массивы точек
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            _list.Clear();
            _num = 0;
            _pointArr = null;
            _lpointArr.Clear();
            _index = 0;

            _pane.CurveList.Clear();
            zedGraph.Refresh();
        }

        /// <summary>
        /// Нажат контрол, блочим установку точки
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _activSetPoint = e.KeyValue == 17;
        }

        /// <summary>
        /// Снимаем флаг блокировки
        /// </summary>
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            _activSetPoint = false;
            btnBuild_Click(null, null);
        }

        


    }

}
