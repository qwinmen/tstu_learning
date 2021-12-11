using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using heaparessential.Controls;

namespace Expromt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            BevelColor = Color.Red;
            ArrBevelComponents = new List<Bevel>();
            //Width = 40;//Height = 40;
        }

        /// <summary>
        /// Путь до плана цеха
        /// </summary>
        private Image image;
        /// <summary>
        /// Храним выбранный в тулбаре компонент
        /// </summary>
        private ButtonItem _tmpPushBtnComponent;
        /// <summary>
        /// Храним расположеные на поле обьекты
        /// </summary>
        private List<Bevel> ArrBevelComponents { get; set; }
        /// <summary>
        /// Массив координат клеток в строке
        /// </summary>
        public List<Point> ArrCoordStr { get; set; }
        /// <summary>
        /// Массив координат клеток в столбце
        /// </summary>
        public List<Point> ArrCoordStl { get; set; }
        /// <summary>
        /// Размер ячейки сетки
        /// </summary>
        private const int iter = 25;
        /// <summary>
        /// Цвет рисования сетки
        /// </summary>
        private Pen pen1;

        //цвет обрамления
        [Category("Style"), Description("Bevel color")]
        [DefaultValue(typeof(Color), "ButtonHighlight")]
        public Color BevelColor { get; set; }

        /// <summary>
        /// событие onPaint которое вызывается при необходимости прорисовки
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            pen1 = new Pen(BevelColor, 1);

            //в зависимости от формы обрамления выводим рисунок
            for (var a = 0; a < panel1.Width; a+=iter )
            {
                e.Graphics.DrawLine(pen1, new Point(a, 0), new Point(a, Height - 1));//VerticalLine:
                e.Graphics.DrawLine(pen1, new Point(0, a), new Point(Width - 1, a));//HorizontalLine:
            }

            ArrCoordStr = new List<Point>();
            var sCount = 0;//сколько ячеек в строке
            for (int i = 0; i < panel1.Width; i += iter, sCount++)//для строк
            {//0..Width
                ArrCoordStr.Add(new Point(i, i+iter));
            }

            ArrCoordStl = new List<Point>();
            var lCount = 0;//сколько ячеек в стoлбе
            for (int i = 0; i < panel1.Height; i += iter, lCount++)//для стoлбца
            {
                ArrCoordStl.Add(new Point(i, i + iter));
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            OnPaint(e);
        }

        /// <summary>
        /// Установить значек на поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Click(object sender, EventArgs e)
        {
            if (_tmpPushBtnComponent == null || !_tmpPushBtnComponent.Checked 
                || ((MouseEventArgs)e).Button == MouseButtons.Right)
                return;
            
            var d = (MouseEventArgs)e;
            //если выделен компонент в тулбаре
            var panel = new Bevel();
            panel.Location = LocationForNewComponent(d.Location);//new Point(d.X,d.Y);
            panel.Size = new Size(iter + iter, iter + iter);
            panel.BackgroundImage = _tmpPushBtnComponent.Image;
            panel.BackgroundImageLayout = ImageLayout.Zoom;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Style = heaparessential.Controls.BevelStyle.Raised;
            toolTip1.SetToolTip(panel, _tmpPushBtnComponent.Tooltip);

            if (ArrBevelComponents.Count==0 || РазрешитьУстановкуНаПоле(panel.Location))
            {
                panel1.Controls.Add(panel);
                //добавить в колекцию
                ArrBevelComponents.Add(panel);
            }

            //panel1.Invalidate();
            
        }

        /// <summary>
        /// Проверить, можт реактор ставим\зацепаем на еще один реактор
        /// </summary>
        /// <returns></returns>
        private bool РазрешитьУстановкуНаПоле(Point locClick)
        {
            if (ArrBevelComponents.Count == 0) return true;//типо первый компонент

            foreach (Bevel tmp in ArrBevelComponents)
            {//два теста
                if (locClick.X + iter == tmp.Location.X)
                {//клик слево от обьекта
                    if (locClick.Y == tmp.Location.Y || locClick.Y - iter == tmp.Location.Y || locClick.Y + iter == tmp.Location.Y)
                        return false;//то запрет установки
                }
                else if (locClick.Y + iter == tmp.Location.Y)
                {//клик сверху обьекта
                    if (locClick.X == tmp.Location.X || locClick.X - iter == tmp.Location.X || locClick.X + iter == tmp.Location.X)
                        return false;//то запрет установки
                }
            }
            //иначе разрешаю туда ставить
            return true;
        }

        /// <summary>
        /// Рассчитать локацию установки компонента в угол ближней сетки
        /// </summary>
        /// <param name="click">Точка щелчка</param>
        /// <returns></returns>
        private Point LocationForNewComponent(Point click)
        {
            var coord = new Point(-5,-5);
            //куда ближе по строке
            var rightPosition = 0;//ближнее справо граница от щелчка
            var leftPosition = 0;//ближнее слево грань от щелчка
            foreach (Point point in ArrCoordStr.Where(point => point.X > click.X))
            {
                rightPosition = point.X;
                foreach (Point pointw in ArrCoordStl.Where(pointw => pointw.X > click.Y))
                {
                    leftPosition = pointw.X;
                    break;
                }
                break;
            }
            //куда ближе по столбцу
            rightPosition = rightPosition - iter;
            leftPosition = leftPosition - iter;

            coord.X = rightPosition;
            coord.Y = leftPosition;

            return coord;
        }

        /// <summary>
        /// Был выделен компонент для установки на поле
        /// Завязываем все компоненты на это событие!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ReactorA_CheckedChanged(object sender, EventArgs e)
        {
            var btnComponent = (ButtonItem) sender;
            
            if(_tmpPushBtnComponent != null && btnComponent!= _tmpPushBtnComponent)
                _tmpPushBtnComponent.Checked = false;//отжать предыдущий выбор

            _tmpPushBtnComponent = btnComponent;//запоминаем нажатое

        }

        /// <summary>
        /// Контекстное меню Очистить поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void лапшаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //чистим массив расположеных компонентов
            ArrBevelComponents.Clear();
            //Чистим поверхность панели от расположеных там компонент
            panel1.Controls.Clear();
            panel1.Invalidate();
            //Делаем перерисовку сетки
            //PaintEventArgs args = new PaintEventArgs(panel1.CreateGraphics(), new Rectangle(panel1.Location, panel1.Size));
            //OnPaint(args);
        }

        /// <summary>
        /// Подгрузить на фон панели план помещения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void открытьКартуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы изображений|*.png;";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                image = Image.FromFile(openFileDialog.FileName);
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show("Ошибка при чтении изображения: "+ex);
                return;
            }
            panel1.BackgroundImage = image;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        

        


    }
}
