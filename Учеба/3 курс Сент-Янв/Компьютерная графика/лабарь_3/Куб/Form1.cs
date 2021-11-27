using System;
using System.Drawing;
using System.Windows.Forms;

namespace Куб
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private clKub _kub;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Отрисовать единичный куб
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            if (pictureBox1.Width!=0)
            {
                pictureBox1.Image = (Image)new Bitmap(pictureBox1.Width, pictureBox1.Height);
                graphics = Graphics.FromImage(pictureBox1.Image);
                _kub = new clKub(graphics, pictureBox1.Height / 2);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        /// <summary>
        /// Установленый масштаб
        /// </summary>
        private void hScrollBar_Mashtab_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = hScrollBar_Mashtab.Value.ToString();
            Point[] tmpArr = _kub.Mashtab(hScrollBar_Mashtab.Value);

            //стереть предыдущее
            graphics.Clear(Color.White);
            //нарисовать новое
            graphics.DrawPolygon(new Pen(Color.Red), tmpArr);
            //обновить поверхность
            pictureBox1.Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                //изменить курсор
                this.pictureBox1.Cursor = Cursors.Cross;
                //снять координаты клика для переноса в эту точку
                //_cursorPoint = pictureBox1_MouseClick(object sender, MouseEventArgs e)
            }
            else this.pictureBox1.Cursor = Cursors.Default;

        }

        private Point _cursorPoint = new Point(0, 0);
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked)
            {
                //то снять координату клика
                _cursorPoint = e.Location;

                //выполнить перенос
                Point[] tmpArr = _kub.Perenos(_cursorPoint);
                //стереть предыдущее
                graphics.Clear(Color.White);
                //нарисовать новое
                graphics.DrawPolygon(new Pen(Color.Black), tmpArr);
                //обновить поверхность
                pictureBox1.Refresh();
            }
        }

        private float pointXF = 0;
        private float pointYF = 0;
        private float pointZF = 0;
        /// <summary>
        /// поворот по Х
        /// </summary>
        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = hScrollBar1.Value.ToString();
            pointXF += 0.1f;
            //выполнить поворот по Х
            Point[] tmpArr = _kub.PovorotX(new PointF(pointXF, pointXF));
            //Point[] tmpArr = _kub.PovorotX(new PointF(0.1f, 0.1f));//(hScrollBar1.Value, hScrollBar1.Value));
            //стереть предыдущее
            graphics.Clear(Color.White);
            //нарисовать новое
            graphics.DrawPolygon(new Pen(Color.Black), tmpArr);
            //обновить поверхность
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Поворот по Y
        /// </summary>
        private void hScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            label5.Text = hScrollBar2.Value.ToString();
            //выполнить поворот по Y
            pointYF += 0.1f;
            //выполнить поворот по Х
            Point[] tmpArr = _kub.PovorotY(new PointF(pointYF, pointYF));
            //Point[] tmpArr = _kub.PovorotY(new Point(hScrollBar2.Value, hScrollBar2.Value));
            //стереть предыдущее
            graphics.Clear(Color.White);
            //нарисовать новое
            graphics.DrawPolygon(new Pen(Color.Black), tmpArr);
            //обновить поверхность
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Поворот по Z
        /// </summary>
        private void hScrollBar3_ValueChanged(object sender, EventArgs e)
        {
            label7.Text = hScrollBar3.Value.ToString();
            //выполнить поворот по Z
            pointZF += 0.1f;
            //выполнить поворот по Х
            Point[] tmpArr = _kub.PovorotZ(new PointF(pointZF, pointZF));
            //Point[] tmpArr = _kub.PovorotZ(new Point(hScrollBar3.Value, hScrollBar3.Value));
            //стереть предыдущее
            graphics.Clear(Color.White);
            //нарисовать новое
            graphics.DrawPolygon(new Pen(Color.Black), tmpArr);
            //обновить поверхность
            pictureBox1.Refresh();
        }

        private fSxod fSxodDialog = new fSxod();
        /// <summary>
        /// открыть настройку точек схода окно
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            fSxodDialog.ShowDialog();
            //опросить свойства схода точек и передать на Куб
            PointF[] tmpArr = _kub.Proekc(fSxodDialog.SxodX, fSxodDialog.SxodY, fSxodDialog.SxodZ);
            //стереть предыдущее
            graphics.Clear(Color.White);
            //нарисовать новое
            graphics.DrawPolygon(new Pen(Color.Black), tmpArr);
            //обновить поверхность
            pictureBox1.Refresh();
        }

        private fProecion fProecDialog = new fProecion();
        /// <summary>
        /// Открыть настройку вида проекций
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            fProecDialog.ShowDialog();

            PointF[] tmpArr = _kub.Otobrajenie(fProecDialog.Kabinet, fProecDialog.Voennik);
            //стереть предыдущее
            graphics.Clear(Color.White);
            //нарисовать новое
            graphics.DrawPolygon(new Pen(Color.Black), tmpArr);
            //обновить поверхность
            pictureBox1.Refresh();

        }




    }
}
