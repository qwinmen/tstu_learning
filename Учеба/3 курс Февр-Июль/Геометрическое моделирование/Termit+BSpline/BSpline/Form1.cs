using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace BSpline
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            zedGraph.EditModifierKeys = Keys.Control;
        }

        /// <summary>
        /// Для точек на экране (отрисовка)
        /// </summary>
        private GraphPane _pane;

        /// <summary>
        /// Храним опорные точки + вектора с экрана.
        /// точка, вектор, точка, вектор
        /// </summary>
        private List<PointD> _lpointArr = new List<PointD>();

        /// <summary>
        /// Создадим список точек
        /// </summary>
        private PointPairList _list = new PointPairList();

        /// <summary>
        /// Флаг разрешает ставить точки на холсте
        /// </summary>
        private bool _activSetPoint;

        /// <summary>
        /// индекс для ориентира в массиве (смены координаты точки)
        /// </summary>
        private int _index = 0;

        /// <summary>
        /// Для копипаста экранных опорных точек
        /// </summary>
        private PointD[] _pointArr;

        /// <summary>
        /// Итератор массива точек
        /// </summary>
        private int _num = 0;




        private void btnClear_Click(object sender, EventArgs e)
        {
            if (_pane == null)
                return;
            _list.Clear();
            _num = 0;
            _pointArr = null;
            _lpointArr.Clear();
            _index = 0;
            //_labelBese = false;

            _pane.CurveList.Clear();
            zedGraph.Refresh();
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            //локальный массив точек
            _pointArr = new PointD[_lpointArr.Count];
            _lpointArr.CopyTo(_pointArr);
            _num = _pointArr.Length;
            //Для отдельных частей формулы исп массив:
            var res = new PointD[_num];
            _list.Clear();

            #region построить график

            bool flagRepitStart = true;
            var tmpRes = new PointD();

            if (switchButton_OnOff.Value)//On
            {//Note: Для партии по 3 точки:
                //Дублировать 1 и n точку 2 раза
                for (int i = 0; i+2 < _lpointArr.Count; i++)
                {//Note: Конец - это не конец, это начало:)
                    var Pi2 = _pointArr[i];
                    var Pi1 = _pointArr[i + 1];
                    var Pi0 = _pointArr[i + 2];
                    
                    for (var t = .01; t <= 1.0; t += .01)
                    {
                        if (t + .01 > 1.0 && i + 2 == _lpointArr.Count - 1)//Конец = 2 точки
                            tmpRes = new PointD(
                                .5*t*t*Pi0.X + (.75 - Math.Pow(t - .5, 2.0))*Pi0.X +
                                .5*Math.Pow(t - 1.0, 2.0)*Pi2.X,
                                .5*t*t*Pi0.Y + (.75 - Math.Pow(t - .5, 2.0))*Pi0.Y +
                                .5*Math.Pow(t - 1.0, 2.0)*Pi2.Y);
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
                    var Pi3 = _pointArr[i];     
                    var Pi2 = _pointArr[i + 1]; 
                    var Pi1 = _pointArr[i + 2]; 
                    var Pi0 = _pointArr[i + 3];
                    if(i==0)
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

                    for (double t = .01, itr = 0.0; t <= 1.0; t += .01, itr+=1.0)
                    {
                        if (t + .01 > 1.0 && i + 3 == _lpointArr.Count - 1)//Конец = 2 точки
                            tmpRes = new PointD(
                                1.0/6.0*t*t*t*Pi0.X +
                                (2.0/3.0 - 0.5*Math.Pow(t - 1.0, 3.0) - Math.Pow(t - 1.0, 2.0))*Pi0.X +
                                (2.0/3.0 + 0.5*t*t*t - t*t)*Pi0.X + 1.0/6.0*Math.Pow(1.0 - t, 3.0)*Pi3.X,
                                1.0/6.0*t*t*t*Pi0.Y +
                                (2.0/3.0 - 0.5*Math.Pow(t - 1.0, 3.0) - Math.Pow(t - 1.0, 2.0))*Pi0.Y +
                                (2.0/3.0 + 0.5*t*t*t - t*t)*Pi0.Y + 1.0/6.0*Math.Pow(1.0 - t, 3.0)*Pi3.Y);
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
            pane.AddCurve("", _list, Color.Blue, SymbolType.None);


            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();
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
        private string zedGraph_PointEditEvent(ZedGraph.ZedGraphControl sender, ZedGraph.GraphPane pane, ZedGraph.CurveItem curve, int iPt)
        {
            //string title = string.Format("Точка: {0}. Новые координаты: ({1}; {2})", iPt, curve[iPt].X, curve[iPt].Y);
            if (curve.Tag != null)// && _bese != null)//_bese.AddPoint((int)curve.Tag, new PointD(curve[iPt].X, curve[iPt].Y));
                _lpointArr[(int)curve.Tag] = new PointD(curve[iPt].X, curve[iPt].Y);
            return "";
        }

        /// <summary>
        /// Снять точку
        /// </summary>
        private void zedGraph_MouseClick(object sender, MouseEventArgs e)
        {
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
        /// Нарисовать точку по координате
        /// </summary>
        private void SetPointCurve(double x, double y)
        {
            LineItem curvePount;

            curvePount = _pane.AddCurve("", new[] { x }, new[] { y }, Color.Blue, SymbolType.Circle);
            curvePount.Symbol.Fill.Color = Color.Blue;

            // У кривой линия будет невидимой
            curvePount.Line.IsVisible = false;

            //Тег будет линком для поиска точки, которую надо перезаписать
            curvePount.Tag = _index++;

            // Тип заполнения - сплошная заливка
            curvePount.Symbol.Fill.Type = FillType.Solid;

            // Размер круга
            curvePount.Symbol.Size = 7;
            //-----------------------------------------//
            zedGraph.Invalidate();
        }


        /// <summary>
        /// Снимаем флаг блокировки
        /// </summary>
        private void zedGraph_KeyUp(object sender, KeyEventArgs e)
        {
            _activSetPoint = false;
            //Ctrl:
            //if (e.KeyValue == 17) btnBuild();
            //Zoom:
            if (e.KeyData == Keys.PageDown)
                zedGraph.ZoomPane(_pane, .7, new PointF(0, 0), false);
            if (e.KeyData == Keys.PageUp)
                zedGraph.ZoomPane(_pane, 3.0, new PointF(0, 0), false);
        }

        /// <summary>
        /// Нажат контрол, блочим установку точки
        /// </summary>
        private void zedGraph_KeyDown(object sender, KeyEventArgs e)
        {
            _activSetPoint = e.KeyValue == 17;
        }
    }
}
