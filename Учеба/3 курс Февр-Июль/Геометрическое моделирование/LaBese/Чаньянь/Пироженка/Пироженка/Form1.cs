using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Пироженка
{
    public partial class Form1 : Form
    {

        // Создадим список точек
        private List<PointD> _list = new List<PointD>();
        /// <summary>
        /// Для точек на экране (отрисовка)
        /// </summary>
        
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

            pictureBox1.Image = (Image)new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            oldImage = new Bitmap(pictureBox1.Image);
            _graf = Graphics.FromImage(pictureBox1.Image);
        }

        private Graphics _graf;

        /// <summary>
        /// Нарисовать точку по координате
        /// </summary>
        private void SetPointCurve(double x, double y)
        {
            _graf.DrawEllipse(new Pen(Color.Blue), new RectangleF((float)x, (float)y, 5f, 5f));
        }

        /// <summary>
        /// Отрисовка графика функции
        /// </summary>
        private void DrawGraph()
        {
            // Создадим кривую с названием "Sinc",// которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            foreach (var xy in _list)
            {
                SetPointCurve(xy.X, xy.Y);
            }

            // Обновляем график
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// индекс для ориентира в массиве (смены координаты точки)
        /// </summary>
        private int _index = 0;

        /// <summary>
        /// Стираем холст
        /// </summary>
        private void UpdateOldImage()
        {
            oldImage.Dispose();
            oldImage = new Bitmap(pictureBox1.Image);
        }

        private Bitmap oldImage;

        /// <summary>
        /// Снять опорную точку
        /// Отобразить точку на холсте
        /// </summary>
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            //блочить рисование точки
            if (_activSetPoint)
                return;

            // Сюда будут записаны координаты в системе координат графика
            var x = e.X;
            var y = e.Y;

            //поставить точку по [x;y]
            SetPointCurve(x, y);

            _lpointArr.Add(new PointD(x, y));

            flag = true;
            _x = e.X;
            _y = e.Y;
            pictureBox1.Invalidate();
        }

        private bool flag = false;
        private int _x = 0, _y = 0;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var br = new SolidBrush(Color.Red);
            if (flag)
                //e.Graphics.FillRectangle(br, new Rectangle(_x,_y, 10,10));
                e.Graphics.FillEllipse(br, new Rectangle(_x, _y, 5, 5));
            else e.Graphics.Clear(Color.WhiteSmoke);
        }

        private void button2_Click(object sender, EventArgs e)
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
                var tmp = new PointD(0.0, 0.0);
                foreach (var pointD in res)
                {
                    tmp.X += pointD.X;
                    tmp.Y += pointD.Y;
                }
                // добавим в список точку
                _list.Add(tmp);
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

        private void button1_Click(object sender, EventArgs e)
        {
            _list.Clear();
            _num = 0;
            _pointArr = null;
            _lpointArr.Clear();
            _index = 0;
            
            UpdateOldImage();

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.Clear(Color.WhiteSmoke);
                flag = false;
                pictureBox1_Paint(sender, new PaintEventArgs(g, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height)));
            }
            pictureBox1.Invalidate();
        }






    }


    /// <summary>
    /// Класс Точки для хранения [X;Y]
    /// </summary>
    class PointD
    {
        private static int index = 0;
        private double _x, _y;
        /// <summary>
        /// [x.X1; X2.y]
        /// </summary>
        public PointD(double x, double y)
        {
            _x = x;
            _y = y;
            //Console.WriteLine("new Point[X1={0:0.####}; X2={1:0.####}]", x, y);
            index++;
        }
        /// <summary>
        /// [Point]
        /// </summary>
        public PointD(Point A)
        {
            _x = A.X;
            _y = A.Y;
            //Console.WriteLine("new Point[X1={0:0.####}; X2={1:0.####}]", x, y);
            index++;
        }

        public double X { get { return _x; } set { _x = value; } }
        public double Y { get { return _y; } set { _y = value; } }

        public override string ToString()
        {
            return index.ToString();
        }

        public static PointD operator +(PointD x1, PointD x2)
        {
            return new PointD(x1.X + x2.X, x1.Y + x2.Y);
        }

        public static PointD operator /(PointD x1, double x2)
        {
            return new PointD(x1.X / x2, x1.Y / x2);
        }

    }


}
