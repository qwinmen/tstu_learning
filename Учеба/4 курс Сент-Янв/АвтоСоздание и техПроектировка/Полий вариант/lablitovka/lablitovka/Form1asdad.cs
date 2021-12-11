using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lablitovka
{
    public partial class Form1 : Form
    {
        const int Diameter = 10;

        int x = 20;
        int y = 20;
        int dx = 1;
        int dy = 1;

        private readonly Timer _timer;
        private BufferedGraphics _bufGraphics;
        public Form1()
        {
            InitializeComponent();
            _timer = new Timer();
            _timer.Tick += timer_Tick;
            _timer.Interval = 1;

            InitializeGraphics();
        }

        private void InitializeGraphics()
        {
            BufferedGraphicsContext context = new BufferedGraphicsContext();
            _bufGraphics = context.Allocate(CreateGraphics(), ClientRectangle);
            context.MaximumBuffer = ClientRectangle.Size;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
             //x, y - текущая позиция шарика
// r - радиус шарика
// w,h - ширина и высота формы соответственно
// dx, dy - вектор движения шарика (изначально ставим, например, dx = 5; dy = 5)
// В таймере код примерно такой был:
 
//  Код:
            x += dx;
            y += dy;

            if (x <= 0 || x + Diameter >= 450) // шарик стукнулся о вертикальную границу
            {
                dx = -dx;
            }
            if (y <= 0 || y + Diameter >= 450) // шарик стукнулся о горизонтальную границу
            {
                dy = -dy;
            }
            //Рисуем в буфере, чтобы не мигало изображение
            _bufGraphics.Graphics.Clear(BackColor);
            _bufGraphics.Graphics.DrawEllipse(new Pen(Color.Silver, 5), x, y, Diameter, Diameter);
            _bufGraphics.Render(); //выводим то, что отрисовано в буфере

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _timer.Enabled = !_timer.Enabled;
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            bool timerState = _timer.Enabled;
            _timer.Stop();

            InitializeGraphics();

            _timer.Enabled = timerState;

            ResetPosition();
        }

        private void ResetPosition()
        {
            if (x + Diameter >= 450)
            {
                x = 450 - Diameter;
            }

            if (y + Diameter >= 450)
            {
                y = 450 - Diameter;
            }
        }
    }
}
