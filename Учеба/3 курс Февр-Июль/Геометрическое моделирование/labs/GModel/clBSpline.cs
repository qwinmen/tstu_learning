using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace GModel
{
    class clBSpline : IInterface
    {
        /// <summary>
        /// Флаг активности класса
        /// </summary>
        internal bool eActive { get; set; }

        /// <summary>
        /// Чтоб сто раз не выводить название кривой
        /// </summary>
        private bool _labelBSpline;

        /// <summary>
        /// Храним опорные точки + вектора с экрана.
        /// точка, вектор, точка, вектор
        /// </summary>
        private List<PointD> _lpointArr = new List<PointD>();

        /// <summary>
        /// Для копипаста экранных опорных точек
        /// </summary>
        private PointD[] _pointArr;

        /// <summary>
        /// Создадим список точек
        /// </summary>
        private PointPairList _list = new PointPairList();

        /// <summary>
        /// Флаг переключателя режимов 3\4
        /// </summary>
        internal bool _switchFlag { get; set; }

        public clBSpline(ZedGraphControl getGrControl)
        {
            IZedGraph = getGrControl;
            
            eActive = true;

            btnClear();
            //++++++++++++++++++++++++++++++++++++++++++++++++
            //если зажат cntrl то на перетаскивание точки
            // Перемещать точки можно будет с помощью средней кнопки мыши...
            IZedGraph.EditButtons = MouseButtons.Left;

            // ... и при нажатой клавише Ctrl.
            IZedGraph.EditModifierKeys = Keys.Control;

            // Точки можно перемещать, как по горизонтали,...
            IZedGraph.IsEnableHEdit = true;

            // ... так и по вертикали.
            IZedGraph.IsEnableVEdit = true;

            // Подпишемся на событие, вызываемое после перемещения точки
            IZedGraph.PointEditEvent += new ZedGraphControl.PointEditHandler(zedGraph_PointEditEvent);
            IZedGraph.KeyUp += new System.Windows.Forms.KeyEventHandler(zedGraph_KeyUp);
            IZedGraph.KeyDown += new System.Windows.Forms.KeyEventHandler(zedGraph_KeyDown);
            //++++++++++++++++++++++++++++++++++++++++++++++++

            IZedGraph.GraphPane.Title.Text = "";
            IZedGraph.GraphPane.YAxis.Title.Text = "Ось Y";
            IZedGraph.GraphPane.XAxis.Title.Text = "Ось X";

            // Включим отображение сетки
            IZedGraph.GraphPane.XAxis.MajorGrid.IsVisible = true;
            IZedGraph.GraphPane.YAxis.MajorGrid.IsVisible = true;

            GraphPane pane = IZedGraph.GraphPane;

            // Установим масштаб по умолчанию для оси X
            pane.XAxis.Scale.Min = -80;
            pane.XAxis.Scale.Max = 80;

            // Установим масштаб по умолчанию для оси Y
            pane.YAxis.Scale.Min = -80;
            pane.YAxis.Scale.Max = 80;

            // Обновим данные об осях
            IZedGraph.AxisChange();
            // Обновляем график
            IZedGraph.Invalidate();

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
            if (curve.Tag != null)
                _lpointArr[(int)curve.Tag] = new PointD(curve[iPt].X, curve[iPt].Y);
            return "";
        }

        /// <summary>
        /// Очистить форму и массивы точек
        /// </summary>
        internal void btnClear()
        {
            if (IPane == null)
                return;

            _list.Clear();
            INum = 0;
            _pointArr = null;
            _lpointArr.Clear();
            IIndex = 0;
            _labelBSpline = false;

            IPane.CurveList.Clear();
            IZedGraph.Refresh();
        }

        /// <summary>
        /// Снять опорную точку
        /// Отобразить точку на холсте
        /// </summary>
        internal void zedGraph_MouseClick(object sender, MouseEventArgs e)
        {
            //блочить рисование точки
            if (IActivSetPoint)
                return;

            // Сюда будут записаны координаты в системе координат графика
            double x, y;

            // Пересчитываем пиксели в координаты на графике
            IZedGraph.GraphPane.ReverseTransform(e.Location, out x, out y);

            //Ставим точку где кликнули
            IPane = IZedGraph.GraphPane;

            //поставить точку по [x;y]
            SetPointCurve(x, y);

            _lpointArr.Add(new PointD(x, y));
        }

        /// <summary>
        /// Нажат контрол, блочим установку точки
        /// </summary>
        private void zedGraph_KeyDown(object sender, KeyEventArgs e)
        {
           IActivSetPoint = e.KeyValue == 17;
        }

        /// <summary>
        /// Снимаем флаг блокировки
        /// </summary>
        private void zedGraph_KeyUp(object sender, KeyEventArgs e)
        {
            IActivSetPoint = false;
            //Ctrl:
            if (e.KeyValue == 17) btnBuild();
            //Zoom:
            if (e.KeyData == Keys.PageDown)
                IZedGraph.ZoomPane(IPane, .7, new PointF(0, 0), false);
            if (e.KeyData == Keys.PageUp)
                IZedGraph.ZoomPane(IPane, 3.0, new PointF(0, 0), false);
        }

        /// <summary>
        /// Нарисовать точку по координате
        /// </summary>
        private void SetPointCurve(double x, double y)
        {
            LineItem curvePount = IPane.AddCurve("", new[] { x }, new[] { y }, Color.Blue, SymbolType.Circle);
            curvePount.Symbol.Fill.Color = Color.Blue;
            
            // У кривой линия будет невидимой
            curvePount.Line.IsVisible = false;

            //Тег будет линком для поиска точки, которую надо перезаписать
            curvePount.Tag = IIndex++;

            // Тип заполнения - сплошная заливка
            curvePount.Symbol.Fill.Type = FillType.Solid;

            // Размер круга
            curvePount.Symbol.Size = 7;
            //-----------------------------------------//
            IZedGraph.Invalidate();
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
            //проверить количество точек >= 3
            if (_lpointArr.Count < 3) return;

            _pointArr = new PointD[_lpointArr.Count];
            _lpointArr.CopyTo(_pointArr);
            INum = _pointArr.Length;
            _list.Clear();

            #region построить график

            bool flagRepitStart = true;
            var tmpRes = new PointD();

            if (_switchFlag)//On
            {//Note: Для партии по 3 точки:
                //Дублировать 1 и n точку 2 раза
                for (int i = 0; i + 2 < _lpointArr.Count; i++)
                {//Note: Конец - это не конец, это начало:)
                    PointD Pi2 = _pointArr[i];
                    PointD Pi1 = _pointArr[i + 1];
                    PointD Pi0 = _pointArr[i + 2];

                    for (var t = .01; t <= 1.0; t += .01)
                    {
                        if (t + .01 > 1.0 && i + 2 == _lpointArr.Count - 1)//Конец = 2 точки
                            tmpRes = new PointD(
                                .5 * t * t * Pi0.X + (.75 - Math.Pow(t - .5, 2.0)) * Pi0.X +
                                .5 * Math.Pow(t - 1.0, 2.0) * Pi2.X,
                                .5 * t * t * Pi0.Y + (.75 - Math.Pow(t - .5, 2.0)) * Pi0.Y +
                                .5 * Math.Pow(t - 1.0, 2.0) * Pi2.Y);
                        else
                            tmpRes = flagRepitStart
                                         ? new PointD(//Начало = 2 точки
                                               .5 * t * t * Pi0.X + (.75 - Math.Pow(t - .5, 2.0)) * Pi2.X +
                                               .5 * Math.Pow(t - 1.0, 2.0) * Pi2.X,
                                               .5 * t * t * Pi0.Y + (.75 - Math.Pow(t - .5, 2.0)) * Pi2.Y +
                                               .5 * Math.Pow(t - 1.0, 2.0) * Pi2.Y)
                                         : new PointD(//Серединка = 3 точки
                                               .5 * t * t * Pi0.X + (.75 - Math.Pow(t - .5, 2.0)) * Pi1.X +
                                               .5 * Math.Pow(t - 1.0, 2.0) * Pi2.X,
                                               .5 * t * t * Pi0.Y + (.75 - Math.Pow(t - .5, 2.0)) * Pi1.Y +
                                               .5 * Math.Pow(t - 1.0, 2.0) * Pi2.Y);
                        flagRepitStart = false;
                        // добавим в список точку P(t)
                        _list.Add(tmpRes.X, tmpRes.Y);
                    }
                }
            }
            else//Off
            {//Note: Для партии по 4 точки
                //Дублировать 1 и n точку 3 раза

                for (int i = 0; i + 3 < _lpointArr.Count; i++)
                {//Note: Конец - это не конец, это начало:)
                    PointD Pi3 = _pointArr[i];
                    PointD Pi2 = _pointArr[i + 1];
                    PointD Pi1 = _pointArr[i + 2];
                    PointD Pi0 = _pointArr[i + 3];
                    if (i == 0)
                    {//Псевдо равные ячейки для начала массива
                        Pi2 = _pointArr[i];
                        Pi1 = _pointArr[i + 1];
                        Pi0 = _pointArr[i + 2];
                    }
                    if (i + 3 == _lpointArr.Count - 1 && !flagRepitStart)
                    {//Псевдо равные ячейки для конца массива
                        //Pi3 = _pointArr[i + 0];
                        //Pi2 = _pointArr[i + 1];
                        //Pi1 = _pointArr[i + 2];
                        //Pi0 = _pointArr[i + 2];
                    }

                    for (double t = .01, itr = 0.0; t <= 1.0; t += .01, itr += 1.0)
                    {
                        if (t + .01 > 1.0 && i + 3 == _lpointArr.Count - 1)//Конец = 2 точки
                            tmpRes = new PointD(
                                1.0 / 6.0 * t * t * t * Pi0.X +
                                (2.0 / 3.0 - 0.5 * Math.Pow(t - 1.0, 3.0) - Math.Pow(t - 1.0, 2.0)) * Pi0.X +
                                (2.0 / 3.0 + 0.5 * t * t * t - t * t) * Pi0.X + 1.0 / 6.0 * Math.Pow(1.0 - t, 3.0) * Pi3.X,
                                1.0 / 6.0 * t * t * t * Pi0.Y +
                                (2.0 / 3.0 - 0.5 * Math.Pow(t - 1.0, 3.0) - Math.Pow(t - 1.0, 2.0)) * Pi0.Y +
                                (2.0 / 3.0 + 0.5 * t * t * t - t * t) * Pi0.Y + 1.0 / 6.0 * Math.Pow(1.0 - t, 3.0) * Pi3.Y);
                        else
                            tmpRes = flagRepitStart
                                         ? new PointD(
                                               1.0 / 6.0 * t * t * t * Pi0.X +
                                               (2.0 / 3.0 - 0.5 * Math.Pow(t - 1.0, 3.0) - Math.Pow(t - 1.0, 2.0)) * Pi3.X +
                                               (2.0 / 3.0 + 0.5 * t * t * t - t * t) * Pi3.X + 1.0 / 6.0 * Math.Pow(1.0 - t, 3.0) * Pi3.X,
                                               1.0 / 6.0 * t * t * t * Pi0.Y +
                                               (2.0 / 3.0 - 0.5 * Math.Pow(t - 1.0, 3.0) - Math.Pow(t - 1.0, 2.0)) * Pi3.Y +
                                               (2.0 / 3.0 + 0.5 * t * t * t - t * t) * Pi3.Y + 1.0 / 6.0 * Math.Pow(1.0 - t, 3.0) * Pi3.Y)
                                         : new PointD(
                                               1.0 / 6.0 * t * t * t * Pi0.X +
                                               (2.0 / 3.0 - 0.5 * Math.Pow(t - 1.0, 3.0) - Math.Pow(t - 1.0, 2.0)) * Pi1.X +
                                               (2.0 / 3.0 + 0.5 * t * t * t - t * t) * Pi2.X + 1.0 / 6.0 * Math.Pow(1.0 - t, 3.0) * Pi3.X,
                                               1.0 / 6.0 * t * t * t * Pi0.Y +
                                               (2.0 / 3.0 - 0.5 * Math.Pow(t - 1.0, 3.0) - Math.Pow(t - 1.0, 2.0)) * Pi1.Y +
                                               (2.0 / 3.0 + 0.5 * t * t * t - t * t) * Pi2.Y + 1.0 / 6.0 * Math.Pow(1.0 - t, 3.0) * Pi3.Y);



                        flagRepitStart = false;
                        // добавим в список точку P(t)
                        _list.Add(tmpRes.X, tmpRes.Y);
                    }
                }
            }
                  

            #endregion
            DrawGraph();
        }

        /// <summary>
        /// Отрисовка графика функции
        /// </summary>
        private void DrawGraph()
        {
            // Получим панель для рисования
            GraphPane pane = IZedGraph.GraphPane;

            double xmin_limit = -80, xmax_limit = +80;
            double ymin_limit = -80, ymax_limit = +80;
            
            pane.XAxis.Scale.Min = xmin_limit;
            pane.XAxis.Scale.Max = xmax_limit;
            
            pane.YAxis.Scale.Min = ymin_limit;
            pane.YAxis.Scale.Max = ymax_limit;


            // Включим отображение сетки
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;

            pane.AddCurve(!_labelBSpline ? "BSpline" : "", _list, Color.Blue, SymbolType.None);
            _labelBSpline = true;

            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            IZedGraph.AxisChange();

            // Обновляем график
            IZedGraph.Invalidate();
        }




        public GraphPane IPane { get; set; }

        public ZedGraphControl IZedGraph { get; set; }

        public bool IActivSetPoint { get; set; }

        public int IIndex { get; set; }

        public int INum { get; set; }

        public bool IeActive { get; set; }
    }


}
