using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Бархан
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


        public struct switchButton_OnOff
        {
            public static bool Value = false;
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
            var tmpRes = new PointD(0, 0);

            if (switchButton_OnOff.Value)//On
            {//Note: Для партии по 3 точки:
                //Дублировать 1 и n точку 2 раза
                for (int i = 0; i + 2 < _lpointArr.Count; i++)
                {//Note: Конец - это не конец, это начало:)
                    var Pi2 = _pointArr[i];
                    var Pi1 = _pointArr[i + 1];
                    var Pi0 = _pointArr[i + 2];

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
                        _list.Add(new PointD(tmpRes.X, tmpRes.Y));
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
                    if (i == 0)
                    {//Псевдо равные ячейки для начала массива
                        //Pi2 = _pointArr[i];
                        //Pi1 = _pointArr[i + 1];
                        //Pi0 = _pointArr[i + 2];
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
                        _list.Add(new PointD(tmpRes.X, tmpRes.Y));
                    }
                }
            }

            #endregion

            DrawGraph();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            switchButton_OnOff.Value = radioButton1.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            switchButton_OnOff.Value = radioButton1.Checked;
        }

        /// <summary>
        /// Отрисовка графика функции
        /// </summary>
        private void DrawGraph()
        {
            
            foreach (var xy in _list)
            {
                SetPointCurve(xy.X, xy.Y);
            }

            // Обновляем график
            pictureBox1.Invalidate();
        }

        private Graphics _graf;

        /// <summary>
        /// Снять точку
        /// </summary>
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
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

        /// <summary>
        /// Нарисовать точку по координате
        /// </summary>
        private void SetPointCurve(double x, double y)
        {
            _graf.DrawEllipse(new Pen(Color.Blue), new RectangleF((float)x, (float)y, 5f, 5f));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var br = new SolidBrush(Color.Red);
            if (flag)
                //e.Graphics.FillRectangle(br, new Rectangle(_x,_y, 10,10));
                e.Graphics.FillEllipse(br, new Rectangle(_x, _y, 5, 5));
            else e.Graphics.Clear(Color.WhiteSmoke);
        }




    }
}
