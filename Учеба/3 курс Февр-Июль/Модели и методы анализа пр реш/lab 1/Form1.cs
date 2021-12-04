using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Выпарной
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            SetValueForm();
        }

        private void SetValueForm()
        {
            gс_Концентрат.LinearScales[0].Pointers[0].Value = КонцентратВыход();
            gс_Концентрат.LinearScales[0].Pointers[0].Tooltip =
                gс_Концентрат.LinearScales[0].Pointers[0].Value.ToString();

            gaugeControl1.LinearScales[0].Pointers[0].Value = Mвых();
            gaugeControl1.LinearScales[0].Pointers[0].Tooltip =
                gaugeControl1.LinearScales[0].Pointers[0].Value.ToString();

            gaugeControl1.LinearScales[1].Pointers[0].Value = Mвт();
            gaugeControl1.LinearScales[1].Pointers[0].Tooltip =
                gaugeControl1.LinearScales[1].Pointers[0].Value.ToString();
        }

        private const double Ct = 4187;

        private double КонцентратВыход()
        {
            zedGraph_CinCout.GraphPane.Title.Text = "";
            zedGraph_CinCout.GraphPane.YAxis.Title.Text = "С(вых)";
            zedGraph_CinCout.GraphPane.XAxis.Title.Text = "С(вх)";
            PointPairList _list = new PointPairList();

            double Cout = doubleInput_Cinput.Value*
                   ((doubleInput_minput.Value*(Ct*(doubleInput_Tp.Value - doubleInput_R.Value)))/
                    (doubleInput_Kt.Value*doubleInput_F.Value*(doubleInput_Tп.Value - doubleInput_Tp.Value) +
                     doubleInput_minput.Value*(Ct*(doubleInput_Tp.Value - doubleInput_R.Value))));
            for (double i = doubleInput_C0.Value; i < doubleInput_C1.Value; i+=doubleInput_deltaC.Value)
            {
                double Y = i *
                   ((doubleInput_minput.Value * (Ct * (doubleInput_Tp.Value - doubleInput_R.Value))) /
                    (doubleInput_Kt.Value * doubleInput_F.Value * (doubleInput_Tп.Value - doubleInput_Tp.Value) +
                     doubleInput_minput.Value * (Ct * (doubleInput_Tp.Value - doubleInput_R.Value))));

                _list.Add(i, Y);
            }
            DrawGraph(zedGraph_CinCout, _list);
            return Cout;
        }

        private double Mвых()
        {
            zedGraph_minCout.GraphPane.Title.Text = "";
            zedGraph_minCout.GraphPane.YAxis.Title.Text = "С(вых)";
            zedGraph_minCout.GraphPane.XAxis.Title.Text = "m(вх)";
            PointPairList _list = new PointPairList();

            for (double i = doubleInput_m0.Value; i < doubleInput_m1.Value; i += doubleInput_deltam.Value)
            {
                double Y = doubleInput_Cinput.Value *
                   ((i * (Ct * (doubleInput_Tp.Value - doubleInput_R.Value))) /
                    (doubleInput_Kt.Value * doubleInput_F.Value * (doubleInput_Tп.Value - doubleInput_Tp.Value) +
                     i * (Ct * (doubleInput_Tp.Value - doubleInput_R.Value))));

                _list.Add(i, Y);
            }
            DrawGraph(zedGraph_minCout, _list);

            return (doubleInput_minput.Value*doubleInput_Cinput.Value)/(gс_Концентрат.LinearScales[0].Pointers[0].Value);
        }

        private double Mвт()
        {
            zedGraph_TпCout.GraphPane.Title.Text = "";
            zedGraph_TпCout.GraphPane.YAxis.Title.Text = "С(вых)";
            zedGraph_TпCout.GraphPane.XAxis.Title.Text = "Тп";
            PointPairList _list = new PointPairList();
            
            for (double i = doubleInput_T0.Value; i < doubleInput_T1.Value; i += doubleInput_deltaT.Value)
            {
                double Y = doubleInput_Cinput.Value *
                   ((doubleInput_minput.Value * (Ct * (doubleInput_Tp.Value - doubleInput_R.Value))) /
                    (doubleInput_Kt.Value * doubleInput_F.Value * (i - doubleInput_Tp.Value) +
                     doubleInput_minput.Value * (Ct * (doubleInput_Tp.Value - doubleInput_R.Value))));

                _list.Add(i, Y);
            }
            DrawGraph(zedGraph_TпCout, _list);

            return (doubleInput_minput.Value - gaugeControl1.LinearScales[0].Pointers[0].Value);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            SetValueForm();
        }

        private void expandableSplitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            bevel1.Refresh();
        }

        private void expandableSplitter1_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            bevel1.Refresh();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            bevel1.Refresh();
        }

        /// <summary>
        /// Отрисовка графика функции
        /// </summary>
        private void DrawGraph(ZedGraphControl zedGraph, PointPairList _list)
        {
            // Получим панель для рисования
            GraphPane pane = zedGraph.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            // !!!
            // Устанавливаем интересующий нас интервал по оси X
            pane.XAxis.Scale.MinAuto = true;//pane.XAxis.Scale.Min = xmin_limit;
            pane.XAxis.Scale.MaxAuto = true;//pane.XAxis.Scale.Max = xmax_limit;

            // !!!
            // Устанавливаем интересующий нас интервал по оси Y
            pane.YAxis.Scale.MinAuto = true;//pane.YAxis.Scale.Min = ymin_limit;
            pane.YAxis.Scale.MaxAuto = true;//pane.YAxis.Scale.Max = ymax_limit;


            // Включим отображение сетки
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;

            // Создадим кривую с названием "Sinc",// которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve("", _list, Color.Blue, SymbolType.None);

            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();
        }




    }
}
