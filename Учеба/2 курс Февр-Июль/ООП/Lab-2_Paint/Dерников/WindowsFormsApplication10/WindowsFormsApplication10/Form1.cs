using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            //PictureBox p = Owner.Controls["panel1"].Controls["pictureBox1"] as PictureBox;
            openFileDialog1.InitialDirectory = saveFileDialog1.InitialDirectory =
                Directory.GetCurrentDirectory();
            form2.numericUpDown1.Value = panel1.ClientSize.Width;
            form2.numericUpDown2.Value = panel1.ClientSize.Height;
            /****************ЭТО*ПЛОХАЯ*ШТУКА**********************/
            //AddOwnedForm(form2);
            //form2.button1_Click(this, null);
            buttonk();
            oldImage = new Bitmap(pictureBox1.Image);
            /******************************************************/
            pen.StartCap = pen.EndCap = LineCap.Round;
            pen.Alignment = PenAlignment.Inset;
            font = Font.Clone() as Font;
        }

        private void buttonk()
        {
            int w = (int)form2.numericUpDown1.Value,
                h = (int)form2.numericUpDown2.Value;
            Image im = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(im);
            g.Clear(Color.White);
            g.Dispose();
            PictureBox p = Controls["panel1"].Controls["pictureBox1"] as PictureBox;
            if (p.Image != null)
                p.Image.Dispose();
            p.Image = im;
        }

        private void buttonk(Point xy)
        {
            Image im = new Bitmap(xy.X, xy.Y);
            Graphics g = Graphics.FromImage(im);
            g.Clear(Color.White);
            g.Dispose();
            PictureBox p = Controls["panel1"].Controls["pictureBox1"] as PictureBox;


            if (p.Image != null)
                p.Image.Dispose();
            p.Image = im;

        }

        private Pen pen = new Pen(Color.Black);
        private Point startPt;
        private int num;
        private Point movePt;
        private Point nullPt = new Point(int.MaxValue, 0);
        private SolidBrush brush = new SolidBrush(Color.White);
        private int figureMode;
        private bool equalSize;

        private Bitmap oldImage;
        private Font font;
        private Form2 form2 = new Form2();

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2.ActiveControl = form2.numericUpDown1;
            if (form2.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.FileName = "";
                Text = "Новый рисунок";
                UpdateOldImage();
                buttonk(form2.NumerXY);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = openFileDialog1.FileName;
                try
                {
                    Image im = new Bitmap(s);
                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();
                    pictureBox1.Image = im;
                }
                catch
                {
                    MessageBox.Show("File " + s + " has a wrong  format.", "Error");
                    return;
                }
                Text = "Редактор картинки - " + s;
                saveFileDialog1.FileName = Path.ChangeExtension(s, "png");
                openFileDialog1.FileName = "";
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s0 = saveFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = saveFileDialog1.FileName;
                if (s.ToUpper() == s0.ToUpper())
                {
                    s0 = Path.GetDirectoryName(s0) + "\\($$##$$).png";
                    pictureBox1.Image.Save(s0);
                    pictureBox1.Image.Dispose();
                    File.Delete(s);
                    File.Move(s0, s);
                    pictureBox1.Image = new Bitmap(s);
                }
                else
                    pictureBox1.Image.Save(s);
                Text = "Редактор картинки - " + s;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Простенький графический редактор.  Автор: Черников Дмитрий БВТ-21. ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            num = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            num = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            num = 2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            num = 3;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = string.Format("X,Y: {0},{1}", e.X, e.Y);
            if (startPt == nullPt)
                return;
            if (e.Button == MouseButtons.Left)
            {
                switch (num)
                {
                    case 0:
                        Graphics g = Graphics.FromImage(pictureBox1.Image);
                        
                        g.DrawLine(pen, startPt, e.Location);
                        g.Dispose();
                        startPt = e.Location;
                        pictureBox1.Invalidate();
                        break;
                    case 1:
                    case 2:
                        ReversibleDraw();
                        movePt = e.Location;
                        equalSize = Control.ModifierKeys == Keys.Control;
                        ReversibleDraw();
                        break;
                }
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            movePt = startPt = e.Location;
            UpdateOldImage();
            if (Control.ModifierKeys == Keys.Alt)
            {
                Color c = (pictureBox1.Image as Bitmap).GetPixel(e.X, e.Y);
                if (e.Button == MouseButtons.Left)
                    label2.BackColor = c;
                else
                    label4.BackColor = c;
            }
            else
                if (num == 3)
                {
                    Graphics g = Graphics.FromImage(pictureBox1.Image);
                    using (SolidBrush b = new SolidBrush(pen.Color))
                        g.DrawString(textBox1.Text, font, b, e.Location);
                    g.Dispose();
                    pictureBox1.Invalidate();
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateOldImage();
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                g.Clear(brush.Color);
            pictureBox1.Invalidate();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            colorDialog1.Color = lb.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                lb.BackColor = colorDialog1.Color;
        }
        private void label2_BackColorChanged(object sender, EventArgs e)
        {
            pen.Color = label2.BackColor;
            label5.Invalidate();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = (int)numericUpDown1.Value;
            label5.Invalidate();
        }
        private void ReversibleDraw()
        {
            Point p1 = pictureBox1.PointToScreen(startPt),
                p2 = pictureBox1.PointToScreen(movePt);
            if (num == 1)
                ControlPaint.DrawReversibleLine(p1, p2, Color.Black);
            else
                ControlPaint.DrawReversibleFrame(PtToRect(p1, p2), Color.Black,
                    (FrameStyle)((figureMode + 1) % 2));
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startPt == nullPt)
                return;
            if (num >= 1)
            {
                ReversibleDraw();

                Graphics g = Graphics.FromImage(pictureBox1.Image);
                
                switch (num)
                {
                    case 1:
                        g.DrawLine(pen, startPt, movePt);
                        break;
                    case 2:
                        DrawFigure(PtToRect(startPt, movePt), g);
                        break;
                }
                g.Dispose();
                pictureBox1.Invalidate();
            }
        }
        private void label4_BackColorChanged(object sender, EventArgs e)
        {
            brush.Color = label4.BackColor;
            label5.Invalidate();
        }
        private void DrawFigure(Rectangle r, Graphics g)
        {
            switch (figureMode)
            {
                case 0:

                    g.FillRectangle(brush, r);
                    g.DrawRectangle(pen, r);
                    break;
                case 1:

                    g.FillEllipse(brush, r);
                    g.DrawEllipse(pen, r);
                    break;
            }
        }
        private Rectangle PtToRect(Point p1, Point p2)
        {
            if (equalSize)
            {
                int dx = p2.X - p1.X, dy = p2.Y - p1.Y;
                if (Math.Abs(dx) > Math.Abs(dy))
                    p2.X = p1.X + Math.Sign(dx) * Math.Abs(dy);
                else
                    p2.Y = p1.Y + Math.Sign(dy) * Math.Abs(dx);
            }
            int x = Math.Min(p1.X, p2.X),
                y = Math.Min(p1.Y, p2.Y),
                w = Math.Abs(p2.X - p1.X),
                h = Math.Abs(p2.Y - p1.Y);
            return new Rectangle(x, y, w, h);
        }
        private void label5_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = label5.ClientRectangle;
            r.Width--; r.Height--;
            DrawFigure(r, g);
        }
        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            if (num == 2)
            {
                figureMode = (figureMode + 1) % 2;
                label5.Invalidate();
            }
        }

        private void UpdateOldImage()
        {
            oldImage.Dispose();
            
            oldImage = new Bitmap(pictureBox1.Image);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = new Bitmap(oldImage);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (num == 3)
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font f = font;
                textBox1.Font = font = fontDialog1.Font;
                f.Dispose();
            }
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
        
        }
        
    }
}
