using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace TestFile
{
    public partial class UCOptimizm : UserControl
    {
        public UCOptimizm()
        {
            InitializeComponent();

            // Опознано
            microChartItem1.PieChartStyle.SliceColors[0] = Color.LawnGreen;
            microChartItem1.PieChartStyle.SliceColors[1] = Color.Red;
            microChartItem1.PieChartStyle.SliceColors[2] = Color.Black;
            microChartItem1.PieChartStyle.SliceOutlineColor = Color.Gray;
            // Set custom tool-tips
            microChartItem1.DataPointTooltips = new List<string>(new string[] { "Полимер: {0}%", "Песок: {0}%", "Краситель: {0}%" });
        }

        private void UCOptimizm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void UpdateLiveChart(PointPairBase point)
        {
            microChartItem1.DataPoints = new List<double>(){point.X, point.Y, 100-(point.X+point.Y)};
        }

        /// <summary>
        /// Числа для графики распознания символов
        /// </summary>
        internal PointPairBase PieGraffik { get; private set; }

        /// <summary>
        /// Свх, %
        /// </summary>
        public double SetC_in { get { return numericUpDown_Свх.Value; } set { numericUpDown_Свх.Value = value; } }
        /// <summary>
        /// mвх, кг/ч
        /// </summary>
        public double SetM_in
        {
            get { return doubleInput_mвх.Value; }
            set { doubleInput_mвх.Value = value; }
        }
        /// <summary>
        /// t(пласт),*C
        /// </summary>
        public double SetTпла_in
        {
            get { return doubleInput_t0.Value; }
            set { doubleInput_t0.Value = value; }
        }
        /// <summary>
        /// t(песок), *С
        /// </summary>
        public double SetTпck_in
        {
            get { return doubleInput_Тпесок.Value; }
            set { doubleInput_Тпесок.Value = value; }
        }

        private const double _S = 0.75;
        private const double _sigma = 0.12;
        private const double _Cвх = 21.4;
        private const double _Cвых = 9.7;
        private const double _mвх = 7.5;
        private const double _mвт = 8.2;
        private const double _Tp = 95.7;
        private const double _P0 = 7900.0;
        private const double _P1 = 7600.0;

        private const double _dCвх = 2.0;
        private const double _dmвх = 3.8;
        private const double _dTп = 17.0;

        /// <summary>
        /// (M) Найти Массу раствора в апорате
        /// Начальное условие
        /// </summary>
        private double M_1_56(double i)
        {
            return _S * ((_P1 - _P0) + ((_mвх - _mвт) / _sigma) * ((_mвх - _mвт) / _sigma + i)) / i;
        }

        /// <summary>
        /// (mвых) Масса на выходе
        /// </summary>
        private double mвых(double i)
        {
            return (_sigma * Math.Sqrt(_P0 + M_1_56(i) / _S - _P1));
        }
        #region ВХОДНЫЕ ПАРАМЕТРЫ

        private void numericUpDown_Свх_ValueChanged(object sender, EventArgs e)
        {
            Init();
        }

        private void doubleInput_mвх_ValueChanged(object sender, EventArgs e)
        {
            Init();
        }

        private void doubleInput_t0_ValueChanged(object sender, EventArgs e)
        {
            Init();
        }

        private void doubleInput_Тпесок_ValueChanged(object sender, EventArgs e)
        {
            Init();
        }


        #endregion

        private void Init()
        {
            //mвх_t()//Tп_t()
            //Cоотношение С1\С2\С3
            var Ckras = doubleInput_mвх.Value / 100.0;
            linkLabel_С2Песок.Text = string.Format("С2 песок, {0:.#}%", 100 - numericUpDown_Свх.Value - (Ckras));
            linkLabel_С3Краситель.Text = string.Format("С3 краситель, {0:.#}%", Ckras);
            //Температура зоны А
            var Ta = (doubleInput_t0.Value + doubleInput_Тпесок.Value) / 1.3 + Cвх_t()[(int)doubleInput_t0.Value].Y;
            linkLabel_ТемперЗона_А.Text = string.Format("Температура зоны А, {0:.#}*С", Ta);
            //Tемпература зоны Б
            var Tb = (Tп_t()[(int)doubleInput_t0.Value].Y) + Ta / 1.3;
            linkLabel_ТемперЗона_Б.Text = string.Format("Температура зоны Б, {0:.#}*С", Tb);
            //Время зоны А
            var taoA = ((Cвх_t()[(int)doubleInput_mвх.Value].Y + numericUpDown_Свх.Value) / 100);
            linkLabel_ТаоА.Text = string.Format("Время смешения А, {0:0.#}ч", taoA);
            //Время зоны Б
            var taoB = Cвх_t()[(int)doubleInput_mвх.Value].Y / 60;
            linkLabel_ТаоБ.Text = string.Format("Время смешения Б, {0:0.#}ч", taoB);
            //Затраченое время
            var tao = taoA + taoB;
            linkLabel_РезультВремя.Text = string.Format("Затраченое время, {0:0.#}ч = {1:0.#}мин", tao, (tao * 3600) / 60);
            //m(вых)
            linkLabel7.Text = string.Format("m(вых), {0:#.#}кг/ч", doubleInput_mвх.Value - mвых(100));
            //обновить графику распознания
            var x = numericUpDown_Свх.Value;//полимер
            var y = 100 - numericUpDown_Свх.Value - (Ckras);//песок
            var symb = new PointPairBase(x, y);
            PieGraffik = symb;
            UpdateLiveChart(PieGraffik);
        }

        

        /// <summary>
        /// dM(t)/dt =0
        /// </summary>
        private PointPairList dM_1_55()
        {
            PointPairList Cвых = new PointPairList();
            for (double i = 0; i < 500; i += 0.1)
            {
                Cвых.Add(i, (_mвх * _Cвх - mвых(i) * _Cвых) / M_1_56(i) + _Tp);
            }

            //Cвых(t)
            return Cвых;
        }

        /// <summary>
        /// Cвх(t)
        /// </summary>
        private PointPairList Cвх_t()
        {
            PointPairList Cвхt = new PointPairList();
            for (double i = 0; i < 1500; i += 1.1)
            {
                Cвхt.Add(i, (_dmвх + mвых(i) + _Cвых) / M_1_56(i) + _dTп);
            }

            return Cвхt;
        }

        /// <summary>
        /// mвх(t)
        /// </summary>
        private PointPairList mвх_t()
        {
            PointPairList mвхt = new PointPairList();
            for (double i = 0; i < 500; i += 0.1)
            {
                mвхt.Add(i, mвых(i) + _mвт + (_dTп + _dCвх));
            }

            return mвхt;
        }

        private PointPairList Tп_t()
        {
            PointPairList Tпt = new PointPairList();
            for (double i = 0; i < 500; i += 0.1)
            {
                Tпt.Add(i, _dTп / (_dmвх * _dCвх - mвых(i) * _Cвых) + M_1_56(i) + _Tp);
            }

            return Tпt;
        }


        #region Рунге-Куты
        static double q(double x, double y)
        {//y'=x+sin(y/п)
            return x + Math.Sin(y / Math.PI);//x + cos(y / sqrt(10));
        }
        static void Reshenie()
        {
            double x, y = 5.3, h = 0.01, a = 1.7, b = 2.7, k1, k2, k3, k4;
            x = a;
            Console.Write("{0}\t{1}\n", x, y);
            for (int i = 1; i < (b - a) / h; i++)
            {
                k1 = h * q(x, y);
                k2 = h * q(x + h / 2, y + k1 / 2);
                k3 = h * q(x + h / 2, y + k2 / 2);
                k4 = h * q(x + h, y + k3);
                x = x + h;
                y = y + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                Console.Write("{0:#.##}\t{1:#.##}\n", x, y);
            }
        }
        #endregion 


    }
}
