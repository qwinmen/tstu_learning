using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace ZTermit
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



        /// <summary>
        /// Очистить холст
        /// </summary>
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

        /// <summary>
        /// Построить
        /// </summary>
        private void btnBuild_Click(object sender, EventArgs e)
        {
            //проверить, все ли точки имеют вектор//если нет, нестроить
            if(_lpointArr.Count%2!=0) return;

            _pointArr = new PointD[_lpointArr.Count];
            _lpointArr.CopyTo(_pointArr);
            _num = _pointArr.Length;
            var res = new PointD[_num];
            _list.Clear();

            #region построить график
            var tmpArrP = new PointD[4];
            //Note: количество отрезков = _lpointArr.Count/4
            for (int o = 2, iter = 0; o < _lpointArr.Count; o+=2, iter+=2)
            {//построить отрезок точка-вектор и точка-вектор:
                tmpArrP[0] = new PointD(_pointArr[iter].X, _pointArr[iter].Y);          //P1:0//2//4//..
                tmpArrP[1] = new PointD(_pointArr[iter + 1].X, _pointArr[iter + 1].Y);  //R1:1//3//5//..
                tmpArrP[2] = new PointD(_pointArr[iter + 2].X, _pointArr[iter + 2].Y);  //P4:2//4//6//..
                tmpArrP[3] = new PointD(_pointArr[iter + 3].X, _pointArr[iter + 3].Y);  //R4:3//5//6//..
                for (double t = 0.01; t <= 1; t += 0.01)
                {
                    for (int i = 0; i < 4; i++)
                    {//для i-точки вычислить
                        //vector() OR point()
                        if(i%2==0) res[i] = Точка(i, t, tmpArrP[i]);
                        else
                        {//Note: vector = R[n] - P[n-1]
                            var vector = new PointD(tmpArrP[i].X - tmpArrP[i - 1].X,
                                                  tmpArrP[i].Y - tmpArrP[i - 1].Y);
                            res[i] = Вектор(i, t, vector);
                        }
                    }
                    var tmp = new PointD();
                    foreach (var pointD in res)
                    {
                        tmp.X += pointD.X;
                        tmp.Y += pointD.Y;
                    }
                    // добавим в список точку P(t)
                    _list.Add(tmp.X, tmp.Y);
                }
            }
            

            #endregion

            DrawGraph();
        }

        /// <summary>
        /// Вычислить P*(t)
        /// </summary>
        private PointD Точка(int i, double t, PointD point)
        {
            if (i == 0)//p1:
                return new PointD(point.X*(2.0*t*t*t - 3.0*t*t + 1.0), point.Y*(2.0*t*t*t - 3.0*t*t + 1.0));
            //p4:
            return new PointD(point.X*(-2.0*t*t*t + 3.0*t*t), point.Y*(-2.0*t*t*t + 3.0*t*t));
        }

        /// <summary>
        /// Вычислить R*(t)
        /// </summary>
        private PointD Вектор(int i, double t, PointD point)
        {
            if (i == 1)//r1
                return new PointD(point.X * (t * t * t - 2.0 * t * t + t), point.Y * (t * t * t - 2.0 * t * t + t));
            //r4
            return new PointD(point.X * (t * t * t - (t * t)), point.Y * (t * t * t - (t * t)));
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
            SetPointCurve(x, y, Symbol());

            _lpointArr.Add(new PointD(x, y));
        }

        /// <summary>
       /// Определить, ставить круг или стрелку вектора
        /// </summary>
        private SymbolType Symbol()
        {
            //взять текущий индекс\размер масива
            //проверить чет-нечет
            if (_lpointArr.Count % 2 == 0)
                return SymbolType.Circle;
            //vector:
            return SymbolType.Diamond;
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
       /// Нарисовать точку по координате
       /// </summary>
       private void SetPointCurve(double x, double y, SymbolType symbolType)
       {
           LineItem curvePount;
           
           if(symbolType == SymbolType.Circle)
           {
               curvePount = _pane.AddCurve("", new[] { x }, new[] { y }, Color.Blue, symbolType);
               curvePount.Symbol.Fill.Color = Color.Blue;
           }else
           {
               curvePount = _pane.AddCurve("", new[] { x }, new[] { y }, Color.Red, symbolType);
               curvePount.Symbol.Fill.Color = Color.Red;
           }

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

        
    }
}
