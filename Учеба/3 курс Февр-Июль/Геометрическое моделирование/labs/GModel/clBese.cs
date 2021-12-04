using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace GModel
{
    class clBese
    {
        /// <summary>
        /// Ссылка на контрол формы
        /// </summary>
        private ZedGraphControl _zedGraph;
        /// <summary>
        /// Флаг активности класса
        /// </summary>
        internal bool lActive { get; set; }

        public clBese(ZedGraphControl getGrControl)
        {
            _zedGraph = getGrControl;

            lActive = true;

            btnClear();
            //++++++++++++++++++++++++++++++++++++++++++++++++
            //если зажат cntrl то на перетаскивание точки
            // Перемещать точки можно будет с помощью средней кнопки мыши...
            _zedGraph.EditButtons = MouseButtons.Left;

            // ... и при нажатой клавише Ctrl.
            _zedGraph.EditModifierKeys = Keys.Control;

            // Точки можно перемещать, как по горизонтали,...
            _zedGraph.IsEnableHEdit = true;

            // ... так и по вертикали.
            _zedGraph.IsEnableVEdit = true;

            // Подпишемся на событие, вызываемое после перемещения точки
            _zedGraph.PointEditEvent += new ZedGraphControl.PointEditHandler(zedGraph_PointEditEvent);
            _zedGraph.KeyUp += new System.Windows.Forms.KeyEventHandler(zedGraph_KeyUp);
            _zedGraph.KeyDown += new System.Windows.Forms.KeyEventHandler(zedGraph_KeyDown);
            //++++++++++++++++++++++++++++++++++++++++++++++++
            
            _zedGraph.GraphPane.Title.Text = "";
            _zedGraph.GraphPane.YAxis.Title.Text = "Ось Y";
            _zedGraph.GraphPane.XAxis.Title.Text = "Ось X";

            // Включим отображение сетки
            _zedGraph.GraphPane.XAxis.MajorGrid.IsVisible = true;
            _zedGraph.GraphPane.YAxis.MajorGrid.IsVisible = true;

            GraphPane pane = _zedGraph.GraphPane;

            // Установим масштаб по умолчанию для оси X
            pane.XAxis.Scale.Min = -80;
            pane.XAxis.Scale.Max = 80;

            // Установим масштаб по умолчанию для оси Y
            pane.YAxis.Scale.Min = -80;
            pane.YAxis.Scale.Max = 80;

            // Обновим данные об осях
            _zedGraph.AxisChange();
            // Обновляем график
            _zedGraph.Invalidate();

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
            if (curve.Tag != null)// && _bese != null)//_bese.AddPoint((int)curve.Tag, new PointD(curve[iPt].X, curve[iPt].Y));
                _lpointArr[(int)curve.Tag] = new PointD(curve[iPt].X, curve[iPt].Y);
            return "";
        }

        /// <summary>
        /// Для точек на экране (отрисовка)
        /// </summary>
        private GraphPane _pane;

        /// <summary>
        /// Храним опорные точки с экрана
        /// </summary>
        private List<PointD> _lpointArr = new List<PointD>();

        // Создадим список точек
        private PointPairList _list = new PointPairList();

        /// <summary>
        /// Для копипаста экранных опорных точек
        /// </summary>
        private PointD[] _pointArr;

        /// <summary>
        /// Итератор массива точек
        /// </summary>
        private int _num = 0;

        /// <summary>
        /// индекс для ориентира в массиве (смены координаты точки)
        /// </summary>
        private int _index = 0;

        /// <summary>
        /// Флаг разрешает ставить точки на холсте
        /// </summary>
        private bool _activSetPoint;

        /// <summary>
        /// Чтоб сто раз не выводить название кривой
        /// </summary>
        private bool _labelBese;

        /// <summary>
        /// Снять опорную точку
        /// Отобразить точку на холсте
        /// </summary>
        internal void zedGraph_MouseClick(object sender, MouseEventArgs e)
        {
            //блочить рисование точки
            if (_activSetPoint)
                return;

            // Сюда будут записаны координаты в системе координат графика
            double x, y;

            // Пересчитываем пиксели в координаты на графике
            // У ZedGraph есть несколько перегруженных методов ReverseTransform.
            _zedGraph.GraphPane.ReverseTransform(e.Location, out x, out y);

            //Ставим точку где кликнули
            _pane = _zedGraph.GraphPane;

            //поставить точку по [x;y]
            SetPointCurve(x, y);

            _lpointArr.Add(new PointD(x, y));
        }

        /// <summary>
        /// Нажат контрол, блочим установку точки
        /// </summary>
        private void zedGraph_KeyDown(object sender, KeyEventArgs e)
        {
            _activSetPoint = e.KeyValue == 17;
        }

        /// <summary>
        /// Снимаем флаг блокировки
        /// </summary>
        private void zedGraph_KeyUp(object sender, KeyEventArgs e)
        {
            _activSetPoint = false;
            //Ctrl:
            if(e.KeyValue == 17) btnBuild();
            //Zoom:
            if (e.KeyData == Keys.PageDown)
                _zedGraph.ZoomPane(_pane, .7, new PointF(0, 0), false);
            if (e.KeyData == Keys.PageUp)
                _zedGraph.ZoomPane(_pane, 3.0, new PointF(0, 0), false);
        }

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
            _zedGraph.Invalidate();
        }

        /// <summary>
        /// Передать список точек
        /// </summary>
        internal List<PointD> GetPointList()
        {
            return _lpointArr;
        }

        /// <summary>
        /// Заполнить точками таблицу на вкладке VIEW
        /// </summary>
        internal void SetValueListView(ListView listViewPoints)
        {
            int i = 0;
            //вывести список точек
            foreach (PointD pointD in GetPointList())
            {
                var newGroup = new ListViewGroup("Точка " + i);
                listViewPoints.Groups.Add(newGroup);

                var newItem = new ListViewItem("[" + pointD.X + "; " + pointD.Y + "]", newGroup);
                listViewPoints.Items.Add(newItem);
                i++;
            }
        }

        /// <summary>
        /// Точки сняты, рассчитать формулу
        /// </summary>
        internal void btnBuild()
        {
            _pointArr = new PointD[_lpointArr.Count];
            _lpointArr.CopyTo(_pointArr);
            _num = _pointArr.Length;
            var res = new PointD[_num];
            _list.Clear();

            #region построить график

            for (double t = 0.01; t <= 1; t += 0.01)
            {
                for (int i = 0; i < _num; i++)
                {//для i-точки вычислить C*t*(1-t)*P
                    res[i] = Часть(i, _num - 1, t, _pointArr[i]);
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

            double tmp = Koefficient_C(i, m) * ti * tni;
            return new PointD(tmp * P.X, tmp * P.Y);
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
                    res_m = l * res_m;
                for (int l = 1; l <= _i; l++)
                    res_i = l * res_i;
                for (int l = 1; l <= (_m - _i); l++)
                    res_im = l * res_im;
                return res_m / (res_i * res_im);
            };

            return res(i, m);
        }

        /// <summary>
        /// Отрисовка графика функции
        /// </summary>
        private void DrawGraph()
        {
            // Получим панель для рисования
            GraphPane pane = _zedGraph.GraphPane;

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
            pane.AddCurve(!_labelBese ? "Bese" : "", _list, Color.Blue, SymbolType.None);
            _labelBese = true;

            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            _zedGraph.AxisChange();

            // Обновляем график
            _zedGraph.Invalidate();
        }

        /// <summary>
        /// Очистить форму и массивы точек
        /// </summary>
        internal void btnClear()
        {
            if (_pane == null)
                return;

            _list.Clear();
            _num = 0;
            _pointArr = null;
            _lpointArr.Clear();
            _index = 0;
            _labelBese = false;

            _pane.CurveList.Clear();
            _zedGraph.Refresh();
        }


    }

}
