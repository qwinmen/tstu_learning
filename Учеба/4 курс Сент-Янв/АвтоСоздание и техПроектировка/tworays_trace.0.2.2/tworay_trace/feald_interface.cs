using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public enum mode { none, chip, line };

    public partial class feald_interface : UserControl
    {
        workbench workspace;
       public mode current_mode;

        Point begin;

        public feald_interface()
        {
            DoubleBuffered = true;
            current_mode = mode.none;
            begin.X= -1;
            workspace = new workbench(150, 150);
           // workspace.add_chip(new Point(2, 2), new Point(25, 20));
            //workspace.add_line(new Point(25, 16), new Point(40, 30));

            //workspace.add_line(new Point(25, 18), new Point(40, 50));

           // workspace.trace();
            InitializeComponent();
        }

        public mode mode { set { current_mode = value; begin.X = -1; } }

        public void clean()
        {
            workspace.clean();
            Invalidate();
        }

        public void set_intersapace(int space)
        {
            workspace.inter_space = space;
        }

        public void trace()
        {
            workspace.trace();
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SizeF step = new SizeF((float)this.Width / workspace.width,(float) this.Height / workspace.height);

            Color cell= Color.Red;

            for (int x = 0; x < workspace.width; ++x)
            {
                for (int y = 0; y < workspace.height; ++y)
                {
                   cell = workspace.get(x, y) == 0 ? Color.DarkGreen : cell;
                   cell = workspace.get(x, y) == -1 ? Color.Black : cell;
                   cell = workspace.get(x, y) == -2 ? Color.DarkGray : cell;
                   cell = workspace.get(x, y) > 1 ? Color.Gray : cell;
                   g.FillRectangle(new SolidBrush(cell), x * step.Width, y * step.Height, step.Width, step.Height);
                }
            }

            foreach (List<Point> way in workspace.ways)
            {
                if (way.Count > 1)
                {
                    List<PointF> t = new List<PointF>();
                    foreach (Point p in way)
                    {
                        t.Add(new PointF(p.X * step.Width + step.Width / 2, p.Y * step.Height + step.Height / 2));
                    }
                    g.DrawLines(new Pen(Color.Gold, 2), t.ToArray());
                }
            }

            int count=1;
            foreach (line l in workspace.lines)
            {
                cell = Color.DarkGreen;

                g.FillRectangle(new SolidBrush(cell), l.begin.X * step.Width, l.begin.Y * step.Height, step.Width, step.Height);
                g.FillRectangle(new SolidBrush(cell), l.end.X * step.Width, l.end.Y * step.Height, step.Width, step.Height);
  
                g.DrawString(Convert.ToString(count), this.Font, new SolidBrush(Color.DarkRed), l.begin.X*step.Width,l.begin.Y*step.Height);
               
                g.DrawString(Convert.ToString(count), this.Font, new SolidBrush(Color.DarkRed), l.end.X*step.Width,l.end.Y*step.Height);


                ++count;
            }

            count = 1;

            foreach (Point p in workspace.chips)
            {
                g.DrawString(Convert.ToString(count), this.Font, new SolidBrush(Color.DarkRed), p.X * step.Width, p.Y * step.Height);
                ++count;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Invalidate();
        }

        private void feald_interface_MouseDown(object sender, MouseEventArgs e)
        {
            SizeF step = new SizeF((float)this.Width / workspace.width, (float)this.Height / workspace.height);

            if (current_mode != mode.none)
            {
                if (begin.X == -1)
                {
                    begin = new Point((int)(e.Location.X / step.Width), (int)(e.Location.Y / step.Height));
                }
                else
                {
                    Point end = new Point((int)(e.Location.X / step.Width), (int)(e.Location.Y / step.Height));
                    if (current_mode == mode.chip) workspace.add_chip(begin, end);
                    if (current_mode == mode.line) workspace.add_line(begin, end);
                    begin.X = -1;
                    Invalidate();
                }
            }
            
        }


    }
}
