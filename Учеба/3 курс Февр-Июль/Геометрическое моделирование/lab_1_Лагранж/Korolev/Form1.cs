using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Korolev
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

        private Graphics _graf;

        /// <summary>
        /// Нарисовать точку по координате
        /// </summary>
        private void SetPointCurve(int x, int y)
        {
            _graf.DrawEllipse(new Pen(Color.Blue), new Rectangle(x, y, 5, 5));
        }

        /// <summary>
        /// Точки сняты, рассчитать формулу
        /// </summary>
        private void btnBuild_Click(object sender, EventArgs e)
        {
            _pointArr = new Point[_lpointArr.Count];
            _lpointArr.CopyTo(_pointArr);
            _num = _pointArr.Length;

            #region построить график

            int n = _num - 1;//n скобок на 1 дробьЧислитель
            double[] res = new double[_num];
            // Интервал, где есть данные
            double xmin = _pointArr[0].X;//-100;
            double xmax = _pointArr[n].X;//100;

            var text = "";
            foreach (Point pointD in _pointArr)
            {
                text += "[" + pointD.X + "; " + pointD.Y + "] ";
            }
            MessageBox.Show(text);

            // Заполняем список точек
            //_list.Add(xmin, _pointArr[0].Y);
            for (double x = xmin; x <= xmax; x += 0.01)
            {
                //_num //Количество дробей == количеству точек
                for (int i = 0; i < _num; i++)
                {
                    //за один такт вычислить 1 дробь
                    //1)составить скобки в дроби
                    double resLocDrob = СобратьЧислитель(n, x, i) / СобратьЗнаменатель(n, x, i);
                    //Итог в i-дроби есть число:
                    res[i] = _pointArr[i].Y * resLocDrob;
                }

                double tmp = 0.0;
                foreach (double re in res)
                {//просуммировать итог(результат n-дробей)
                    tmp += re;
                }
                //SetPointCurve(x,tmp);
                // добавим в список точку
                _list.Add(new Point((int)x, (int)tmp));
            }

            DrawGraph();
            #endregion

        }

        /// <summary>
        /// Собрать числитель дроби
        /// </summary>
        /// <param name="n">Количество скобок</param>
        /// <param name="x">Точка для которой ищем У</param>
        /// <param name="i">Номер дроби для генератора</param>
        private double СобратьЧислитель(int n, double x, int i)
        {
            double temp = 0.0;
            //Общий вид: (x-generator)*(x-generator)
            for (int j = 0; j < n; j++)
            {
                //собрать скобку
                if (temp == 0.0)
                    temp = (x - generator(i, j));
                else temp = temp * (x - generator(i, j));
            }

            return temp;
        }

        /// <summary>
        /// Собрать знаменатель дроби
        /// </summary>
        /// <param name="n">Количество скобок</param>
        /// <param name="x">Точка для которой ищем У</param>
        /// <param name="i">Номер дроби для генератора</param>
        private double СобратьЗнаменатель(int n, double x, int i)
        {
            double temp = 0.0;
            //Общий вид: (xi-generator)*(xi-generator)
            for (int j = 0; j < n; j++)
            {
                //собрать скобку
                if (temp == 0.0)
                    temp = (_pointArr[i].X - generator(i, j));
                else temp = temp * (_pointArr[i].X - generator(i, j));
            }

            return temp;
        }

        private int _gindex;

        /// <summary>
        /// Определить какой Х использовать
        /// </summary>
        /// <param name="i">Порядковый номер дроби</param>
        /// <param name="j">Текущая скобка номер</param>
        /// <returns></returns>
        private double generator(int i, int j)
        {
            if (j == 0)
                _gindex = i + 1;
            else _gindex++;

            if (_gindex >= _pointArr.Length)
                _gindex = 0;

            return _pointArr[_gindex].X;
        }


        /// <summary>
        /// Очистить форму и массивы точек
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            _gindex = 0;
            _list.Clear();
            _num = 0;
            _pointArr = null;
            _lpointArr.Clear();
            lblCoordinates.Text = "--X--;--Y--";

            UpdateOldImage();
            
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.Clear(Color.WhiteSmoke);
                flag = false;
                pictureBox1_Paint(sender, new PaintEventArgs(g, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height)));
            }
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Стираем холст
        /// </summary>
        private void UpdateOldImage()
        {
            oldImage.Dispose();
            oldImage = new Bitmap(pictureBox1.Image);
        }

        private Bitmap oldImage;

        // Создадим список точек
        private List<Point> _list = new List<Point>();

        /// <summary>
        /// Для копипаста экранных опорных точек
        /// </summary>
        private Point[] _pointArr;
        /// <summary>
        /// Храним опорные точки с экрана
        /// </summary>
        private List<Point> _lpointArr = new List<Point>();
        /// <summary>
        /// Итератор массива точек
        /// </summary>
        private int _num = 0;

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
        /// Снять опорную точку
        /// Отобразить точку на холсте
        /// </summary>
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            // Сюда будут записаны координаты в системе координат графика
            var x = e.X;
            var y = e.Y;

            // Выводим результат
            lblCoordinates.Text = string.Format("X: {0:#.###}; Y: {1:#.###}", x, y);

            //поставить точку по [x;y]
            SetPointCurve(x, y);

            _lpointArr.Add(new Point(x, y));

            flag = true;
            _x = e.X;
            _y = e.Y;
            pictureBox1.Invalidate();
        }

        private bool flag = false;
        private int _x=0, _y=0;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var br = new SolidBrush(Color.Red);
            if(flag)
            //e.Graphics.FillRectangle(br, new Rectangle(_x,_y, 10,10));
                e.Graphics.FillEllipse(br, new Rectangle(_x, _y, 5, 5));
            else e.Graphics.Clear(Color.WhiteSmoke);
        }



    }
}
