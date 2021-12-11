using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace Razbor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            zedGraphControl1.GraphPane.Title.Text = "";
            zedGraph.GraphPane.Title.Text = "";
            zedGraph.GraphPane.YAxis.Title.Text = "С3 вых, моль/м³";
            zedGraph.GraphPane.XAxis.Title.Text = "Длина трубы, м";
            var listTi = new List<double>();

            //Статика//Найти мин длину трубы при 4% С3//Ответ Lmin=2.8m при 286°C и С3=4%
            Random rnd = new Random();
            listTi.Add(560);
            for (double i = 260, k=0; i <= 300; i+=5, k++)
            {
                var Ti = this.C1(i);
                listTi.Add(Ti);
                //при разнице температур в 1000К делаем выход
                if (Math.Abs(Ti-listTi[listTi.Count-2]) > 1000)
                    break;
                //Для минимальной длины при температуре
                clDixotomia = new Дихотомия(Lmin);
                
                for (int j = 0; j < 5; j++)
                    gaugeControl1.LinearScales[j].Pointers[0].Value = clDixotomia.HiComerce[j];
                
                DrawGraph(_list, Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)), i + "°C");//i + "°C");
                
                //DrawGraph(clDixotomia._list, Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)), "°C");//i + "°C");
                textBox1.Text += clDixotomia.ResultLen;
                
            }
            //Динамика//ГСЧ лаб6 + лаб4 Характеристик
            //получаем 200 чисел
            //cтроим С1(tao) по кнопке Динамика
            //передаем на метод характеристик
            //_model = new clModel(massivГСЧ, 2.8);
        }

        private double[] _arr_200 { get; set; }
        private clГСЧ _гсч = new clГСЧ();
        private clModel _model;

        // Создадим список точек
        private PointPairList _list = new PointPairList();

        private Дихотомия clDixotomia;
        //private Console clConsole = new Console();

        GraphPane pane;
        /// <summary>
        /// Отрисовка графика функции
        /// </summary>
        private void DrawGraph(PointPairList list, Color color, string func, params bool[] parm)
        {
            zedGraph = parm.Length!=0?zedGraphControl1:zedGraph;
            // Получим панель для рисования
            pane = zedGraph.GraphPane;
            pane.LineType = LineType.Normal;
            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            //pane.CurveList.Clear();

            double xmin_limit = 0, xmax_limit = +100;
            double ymin_limit = 0, ymax_limit = +5;

            // !!!
            // Устанавливаем интересующий нас интервал по оси X
            pane.XAxis.Scale.Min = xmin_limit;
            pane.XAxis.Scale.Max = xmax_limit;

            // !!!
            // Устанавливаем интересующий нас интервал по оси Y
            pane.YAxis.Scale.Min = ymin_limit;
            pane.YAxis.Scale.Max = ymax_limit;
            pane.YAxis.Scale.MaxAuto = true;
            pane.YAxis.Scale.MinAuto = true;
            pane.XAxis.Scale.MaxAuto = true;
            pane.XAxis.Scale.MinAuto = true;

            // Включим отображение сетки
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;

            // Создадим кривую с названием "Sinc",// которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve(func, list, color, SymbolType.None);

            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();
            _list = new PointPairList();

        }

        /// <summary>
        /// Нарисовать точку по координате
        /// </summary>
        private void SetPointCurve(double x, double y, params bool [] flag)
        {
            zedGraph = flag.Length != 0 ? zedGraphControl1 : zedGraph;
            GraphPane pane = zedGraph.GraphPane;
            LineItem curvePount = pane.AddCurve("", new[] { x }, new[] { y }, flag.Length == 0 ? Color.Blue : Color.Red, SymbolType.Circle);
            curvePount.Symbol.Fill.Color = Color.Blue;

            // У кривой линия будет невидимой
            curvePount.Line.IsVisible = false;

            // Тип заполнения - сплошная заливка
            curvePount.Symbol.Fill.Type = FillType.Solid;

            // Размер круга
            curvePount.Symbol.Size = 4;
            //-----------------------------------------//
            zedGraph.Invalidate();
        }

        public const double _A1 = 8000;
        public const double _A2 = 4000;
        public const double _A3 = 300000;

        public const double _E1 = 72600;//Дж\моль
        public const double _E2 = 77000;//Дж\моль
        public const double _E3 = 87000;//Дж\моль

        public const double _R = 8.31;

        public const double _C1_нафВх = 1.09;//моль\м3
        public const double _C2_О2вв = 8.75;//моль\м3
        public const double _C3_вых = 6.62;//моль\м3

        public const double _dL = 0.1;//метр
        public const double _U = 0.1;//м\с
        public const double _Ct = 1100;//Дж\кг*град
        public const double _p = 1.4;//кг\м3
        public const double _Kt = 500;//Вт\м2*град
        public const double _D = 0.025;//метр

        public const double _deltaTao = 0.1;//секунд

        #region Расчер k

        /// <summary>
        /// k1=A1exp(-E1/RTt)
        /// </summary>
        /// <returns></returns>
        public double K1(double Tt)
        {
            //+градус в кельвин
            return _A1 * Math.Exp(-_E1 / (_R * (Tt + 273.15)));
        }

        /// <summary>
        /// k2=A2exp(-E2/RTt)
        /// </summary>
        /// <returns></returns>
        public double K2(double Tt)
        {
            return _A2 * Math.Exp(-_E2 / (_R * (Tt + 273.15)));
        }

        /// <summary>
        /// k3=A3exp(-E3/RTt)
        /// </summary>
        /// <returns></returns>
        public double K3(double Tt)
        {
            return _A3 * Math.Exp(-_E3 / (_R * (Tt + 273.15)));
        }

        #endregion

        #region Расчет Сi и Ti
        
        private double C1(double temper)
        {
            var flag = !false;
            var listC1 = new PointPairList();
            var listC2 = new PointPairList();

            var lenArr = 7000;
            var C1i = new double[lenArr];
            C1i[0] = _C1_нафВх;
            var C2i = new double[lenArr];
            C2i[0] = _C2_О2вв;
            var C3i = new double[lenArr];
            C3i[0] = 0.0;//_C3_вых;
            var Ti = new double[lenArr];
            Ti[0] = 650.0;//Кельвин//Tвх
            var _dL = 0.001;
            var limitC3 = ((4.0 * _p) / (100.0 * 0.148));// 4%==>0.37моль\м3
            var j = 0.0;//для шага по трубе [0..max]
            //var temper = 260;//Цельси
            var длинаТрубы = 110.0;//m

            for (int i = 1; j < длинаТрубы; i++)
            {
                var k1 = K1(Ti[i - 1] - 273.15);//в цельси т.к. метод преобразует
                var k2 = K2(Ti[i - 1] - 273.15);
                var k3 = K3(Ti[i - 1] - 273.15);

                var Tt = temper + 273.15;//в кельвин
                var rp1 = k1 * C1i[i-1]*C2i[i-1];//_C1_нафВх * _C2_О2вв;
                var rp2 = k2 * C1i[i-1]*C2i[i-1]*C3i[i-1];//_C1_нафВх * _C2_О2вв * _C3_вых;
                var rp3 = k3 * C1i[i - 1] * C2i[i - 1];//_C1_нафВх * _C2_О2вв;

                var Qp1 = 1.47 * Math.Pow(10, 7);
                var Qp2 = 1.4 * Math.Pow(10, 8);
                var Qp3 = 19.6 * Math.Pow(10, 6);

                Ti[i] = Ti[i-1]+((rp1*Qp1)/(_Ct*_p) - ((4*_Kt)/(_Ct*_p*_D))*(Ti[i-1]-Tt) + (rp2*Qp2)/(_Ct*_p) + (rp3*Qp3)/(_Ct*_p))/_U*_dL;

                C1i[i] = C1i[i - 1] + (-2.0 * k1 * C1i[i - 1] * C2i[i - 1] - k2 * C1i[i - 1] * C2i[i - 1]) / _U * _dL;
                C2i[i] = C2i[i - 1] +
                         (-9.0*k1*C1i[i - 1]*C2i[i - 1] - 12.0*k2*C1i[i - 1]*C2i[i - 1] - 9.0*k3*C3i[i - 1]*C2i[i - 1])/
                         _U * _dL;
                C3i[i] = C3i[i - 1] + (-k3 * C3i[i - 1] * C2i[i - 1] + 2.0 * k1 * C1i[i - 1] * C2i[i - 1]) / _U * _dL;
                var res = C3i[i];

                j += _dL;//шаг по трубе

                _list.Add(j, res);//вывод на график

                //Если достигнут порог вещества на выходе
                if (res >= limitC3 && flag)//моль\м3 >= моль\м3
                {
                    SetPointCurve(j, res);//вывод контрольной точки на график
            //        flag = false;
                    textBox1.Text +=
                        String.Format("=>{0:#0.##}m при {1:#0.###}моль/м³=4% и {2:#0.###}°C на Ti={3:#0.###}K", j, res, temper, Ti[i]) +
                        Environment.NewLine;
                    Lmin = j;
                    //exit
                    return Ti[i];
                }
                listC1.Add(j, C1i[i]);
                listC2.Add(j, C2i[i]);
            }
            
           
            
            return Ti[Ti.Length-1];
        }
        /// <summary>
        /// Храним найденый минимум в статике
        /// </summary>
        internal double Lmin { get; set; }

        
        #endregion

        //событие Построить график динамики
        private void StartDinamiks(object sender, EventArgs e)
        {
            //очистить график
            pane.CurveList.Clear();

            zedGraph.GraphPane.YAxis.Title.Text = "С1 [200], моль/м³";
            zedGraph.GraphPane.XAxis.Title.Text = "tao, с";
            // Обновляем график
            zedGraph.Invalidate();

            var massivГСЧ = _гсч.ГСЧрезульт;
            _arr_200 = massivГСЧ;

            C1_200();

        }

        /// <summary>
        /// График С1(tao)
        /// </summary>
        private void C1_200()
        {
            var list1 = new PointPairList();
            foreach (PointD pointD in _гсч.NaGrafik)
            {
                if(pointD==null)continue;
                list1.Add(pointD.X, pointD.Y);
                SetPointCurve(pointD.X, pointD.Y);
            }
            DrawGraph(list1, Color.Red, "C1(tao)");
            
        }

        /// <summary>
        /// Нарисовать график зависимости C1(L)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_C1L(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.YAxis.Title.Text = "С3, моль/м³";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "tao, c";
            // Обновляем график
            zedGraphControl1.Invalidate();
            
            C1_L();
        }

        

        private void C1_L()
        {

            double tauSrednee = Lmin / _U;    //среднее время пребывания, c
            var i = 0;
            var k = 0.0;
            var asdd = new double[_arr_200.Length];
            foreach (double d in _arr_200)
            {
                if(k>tauSrednee)
                    asdd[i] = d;
                i+=1;
                k += 0.01;
            }
            _model = new clModel(asdd, Lmin);

            var list2 = new PointPairList();
            foreach (PointD pointD in _model.NaGrafik2)
            {
                if (pointD != null)
                {
                    list2.Add(pointD.X, pointD.Y);
                    SetPointCurve(pointD.X, pointD.Y, true);
                }
            }
            DrawGraph(list2, Color.DimGray, "C3(tao)", new bool[] { true });
            
        }

    }
}
