using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Термит
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = (Image)new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            oldImage = new Bitmap(pictureBox1.Image);
            _graf = Graphics.FromImage(pictureBox1.Image);

        }

        

        /// <summary>
        /// Храним опорные точки + вектора с экрана.
        /// точка, вектор, точка, вектор
        /// </summary>
        private List<PointD> _lpointArr = new List<PointD>();

        /// <summary>
        /// Создадим список точек
        /// </summary>
        private List<PointD> _list = new List<PointD>();

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


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
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


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var br = new SolidBrush(Color.Red);
            if (flag)
                //e.Graphics.FillRectangle(br, new Rectangle(_x,_y, 10,10));
                e.Graphics.FillEllipse(br, new Rectangle(_x, _y, 5, 5));
            else e.Graphics.Clear(Color.WhiteSmoke);
        }

        private void button2_Click(object sender, System.EventArgs e)
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

        private bool flag = false;
        private int _x = 0, _y = 0;
        private Bitmap oldImage;

        /// <summary>
        /// Стираем холст
        /// </summary>
        private void UpdateOldImage()
        {
            oldImage.Dispose();
            oldImage = new Bitmap(pictureBox1.Image);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //проверить, все ли точки имеют вектор//если нет, нестроить
            if (_lpointArr.Count % 2 != 0) return;

            _pointArr = new PointD[_lpointArr.Count];
            _lpointArr.CopyTo(_pointArr);
            _num = _pointArr.Length;
            var res = new PointD[_num];
            _list.Clear();

            #region построить график
            var tmpArrP = new PointD[4];
            //Note: количество отрезков = _lpointArr.Count/4
            for (int o = 2, iter = 0; o < _lpointArr.Count; o += 2, iter += 2)
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
                        if (i % 2 == 0) res[i] = Точка(i, t, tmpArrP[i]);
                        else
                        {//Note: vector = R[n] - P[n-1]
                            var vector = new PointD(tmpArrP[i].X - tmpArrP[i - 1].X,
                                                  tmpArrP[i].Y - tmpArrP[i - 1].Y);
                            res[i] = Вектор(i, t, vector);
                        }
                    }
                    var tmp = new PointD(0.0, 0.0);
                    foreach (var pointD in res)
                    {
                        if(pointD==null) continue;
                        
                        tmp.X += pointD.X;
                        tmp.Y += pointD.Y;
                    }
                    // добавим в список точку P(t)
                    _list.Add(tmp);
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
                return new PointD(point.X * (2.0 * t * t * t - 3.0 * t * t + 1.0), point.Y * (2.0 * t * t * t - 3.0 * t * t + 1.0));
            //p4:
            return new PointD(point.X * (-2.0 * t * t * t + 3.0 * t * t), point.Y * (-2.0 * t * t * t + 3.0 * t * t));
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







        
    }
}
