using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;



namespace GraficDisplay
{
    using GraphLib;

    public partial class MainForm : Form
    {
        #region INITIALIZATION

        #region VARIABLES
        private bool sin = false; // для чекбокса
        private bool cos = false;
        private bool tg = false;
        private bool ctg = false;

        int CirclePart = 0;     // какой сектор круга будет окрашен

        // цвета графиков
        Color[] grColors = { Color.FromArgb(0,0,255), 
                             Color.FromArgb(255,0,0),
                             Color.FromArgb(255,255,0), 
                             Color.FromArgb(0,255,0) };
        double[,] arCoef = new double[4, 3];//коэфициенты для функций, параметры
        #endregion VARIABLES

        public MainForm()
        {
            InitializeComponent();
            display.Smoothing = System.Drawing.Drawing2D.SmoothingMode.None;
            CalcDataGraphs();
            display.Refresh();
            RefreshButtonsColor();
            for (int i = 0; i < 4; i++)
            {
                arCoef[i, 0] = 1;   // 1 коэфициент
                arCoef[i, 1] = 0;   // 3 коэфициент
                arCoef[i, 2] = 1;   // 2 коэфициент
            }
            

        }

        #endregion INITIALIZATION

        #region GRAPH CALCULATIONS

        protected void CalcSin(DataSource src, // источник куда записываются точки
            int idx,    // для масштаба
            double k1,  // коэфициент 1
            double k2,  // коэфициент 3
            double k3)  // коэфициент 2
        {
            for (int i = 0; i < src.Length; i++)
            {

                src.Samples[i].x = i;
                src.Samples[i].y = (float)(((float)k1*Math.Sin(k3*(idx-1) * i * (3.14 / src.Length)/* для перевода в радианы*/)) + k2);
                // k1*sin(k3*x)+k2
            }
        }

        protected void CalcCos(DataSource src, int idx, double k1, double k2, double k3)
        {
            for (int i = 0; i < src.Length; i++)
            {
                src.Samples[i].x = i;
                src.Samples[i].y = (float)(((float)k1 * Math.Cos(k3 * (idx - 1) * i * 3.14 / src.Length)) + k2);
            }
        }

        protected void CalcTg(DataSource src, int idx, double k1, double k2, double k3)
        {
            for (int i = 0; i < src.Length; i++)
            {
                src.Samples[i].x = i;
                src.Samples[i].y = (float)(((float)k1 * Math.Tan(k3 * (idx - 1) * i * 3.14 / src.Length)) + k2);
            }
        }

        protected void CalcCtg(DataSource src, int idx, double k1, double k2, double k3)
        {
            for (int i = 0; i < src.Length; i++)
            {
                src.Samples[i].x = i;
                src.Samples[i].y = (float)(((float)-Math.Tan(k3 * (idx - 1) * i * 3.14 / src.Length)) * k1 + k2);
            }
        }

        protected void DrawGraph(int index, string name, Color CGraphColor)
        {

            display.DataSources[index].Name = name;
            display.DataSources[index].OnRenderXAxisLabel += RenderXLabel;
            display.DataSources[index].Length = 3600;
            display.PanelLayout = PlotterGraphPaneEx.LayoutMode.NORMAL;
            display.DataSources[index].SetDisplayRangeY(-4, 4);
            display.DataSources[index].SetGridDistanceY(1);
            display.DataSources[index].GraphColor = CGraphColor;
            display.DataSources[index].OnRenderYAxisLabel += RenderYLabel;
            //display.DataSources[index].AutoScaleX = true;
        }

        #endregion GRAPH CALCULATIONS

        #region EXTRA FUNCTIONS

        private void RefreshButtonsColor()
        {
            this.button1.BackColor = grColors[0];
            this.button2.BackColor = grColors[1];
            this.button3.BackColor = grColors[2];
            this.button4.BackColor = grColors[3];
        }

        private void ApplyColorSchema()
        {
            display.BackgroundColorTop = Color.YellowGreen;
            display.BackgroundColorBot = Color.Green;
            display.SolidGridColor = Color.LightGray;
            display.DashedGridColor = Color.LightGray;
        }

        private void RefreshGraph()
        {
            display.Refresh();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            display.Dispose();
            base.OnClosing(e);
        }

        #endregion EXTRA FUNCTIONS

        #region MAIN PART

        protected void CalcDataGraphs( )
        {

            this.SuspendLayout();
           
            display.DataSources.Clear();
            display.SetDisplayRangeX(0, 1200);


            try
            {
                #region RENDER GRAPHS
                if (sin)
                {
                    display.DataSources.Add(new DataSource());
                    DrawGraph(display.DataSources.Count-1, "Sin", grColors[0]);
                    CalcSin(display.DataSources[display.DataSources.Count - 1], 10, arCoef[0, 0], arCoef[0, 1], arCoef[0, 2]);
                }
                if (cos)
                {
                    display.DataSources.Add(new DataSource());
                    DrawGraph(display.DataSources.Count - 1, "Cos", grColors[1]);
                    CalcCos(display.DataSources[display.DataSources.Count - 1], 10, arCoef[1, 0], arCoef[1, 1], arCoef[1, 2]);
                }
                if (tg)
                {
                    display.DataSources.Add(new DataSource());
                    DrawGraph(display.DataSources.Count - 1, "Tg", grColors[2]);
                    CalcTg(display.DataSources[display.DataSources.Count - 1], 10, arCoef[2, 0], arCoef[2, 1], arCoef[2, 2]);
                }
                if (ctg)
                {
                    display.DataSources.Add(new DataSource());
                    DrawGraph(display.DataSources.Count - 1, "Ctg", grColors[3]);
                    CalcCtg(display.DataSources[display.DataSources.Count - 1], 10, arCoef[3, 0], arCoef[3, 1], arCoef[3, 2]);
                }
                #endregion render graphs
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ApplyColorSchema();
            this.ResumeLayout();
            display.Refresh();
        }

        #endregion MAIN PART

        // прорисовуются оси, т.е П, П/2, 3П/2
        #region RENDER LABELS

        private String RenderXLabel(DataSource s, int idx)
        {
            int n = (int)(s.Samples[idx].x/200);
            string label = string.Empty;
            if(n == 0)
            {
                label = "0";
            }
            else if (n % 2 == 0)
            {
                if (n != 2)
                {
                    label = n / 2 + "P";
                }
                else
                {
                    label = "P";
                }
            }
            else
            {
                if (n != 1)
                {
                    label = n + "P/2"; ;
                }
                else
                {
                    label = "P/2";
                }
                
            }
            return label;
        }

        private String RenderYLabel(DataSource s, float  value)
        {             
            return String.Format("{0:0.0}", value);
        }

        #endregion RENDER LABELS

        #region CHECKBOXES

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sin = !sin;
            this.groupBoxExpSin.Visible = sin;
            CalcDataGraphs();
        }

        private void checkBoxCos_CheckedChanged(object sender, EventArgs e)
        {
            cos = !cos;
            this.groupBoxExpCos.Visible = cos;
            CalcDataGraphs();
        }

        private void checkBoxTan_CheckedChanged(object sender, EventArgs e)
        {
            tg = !tg;
            this.groupBoxExpTg.Visible = tg;
            CalcDataGraphs();
        }

        private void checkBoxCTan_CheckedChanged(object sender, EventArgs e)
        {
            ctg = !ctg;
            this.groupBoxExpCtg.Visible = ctg;
            CalcDataGraphs();
        }

        #endregion CHECKBOXES
        // кнопки изменения цветов графика
        #region CHANGE COLORS
        // вызывает окошечко выбора цвета
        private Color ChooseColor()
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowHelp = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
                return MyDialog.Color;
            return Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grColors[0] = this.ChooseColor();
            this.CalcDataGraphs();
            this.RefreshButtonsColor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grColors[1] = this.ChooseColor();
            this.CalcDataGraphs();
            this.RefreshButtonsColor();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            grColors[2] = this.ChooseColor();
            this.CalcDataGraphs();
            this.RefreshButtonsColor();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            grColors[3] = this.ChooseColor();
            this.CalcDataGraphs();
            this.RefreshButtonsColor();
        }

        #endregion Change colors

        #region COMBOBOXES

        private void comboSinK1_SelectedIndexChanged(object sender, EventArgs e)
        {
            arCoef[0, 0] = double.Parse(comboSinK1.Items[comboSinK1.SelectedIndex].ToString());
            CalcDataGraphs();
        }

        private void comboSinK2_SelectedIndexChanged(object sender, EventArgs e)
        {
            arCoef[0, 1] = double.Parse(comboSinK2.Items[comboSinK2.SelectedIndex].ToString());
            CalcDataGraphs();
        }

        private void comboCosK1_SelectedIndexChanged(object sender, EventArgs e)
        {

            arCoef[1, 0] = double.Parse(comboCosK1.Items[comboCosK1.SelectedIndex].ToString());
            CalcDataGraphs();
        }

        private void comboCosK2_SelectedIndexChanged(object sender, EventArgs e)
        {
            arCoef[1, 1] = double.Parse(comboCosK2.Items[comboCosK2.SelectedIndex].ToString());
            CalcDataGraphs();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            arCoef[2, 0] = double.Parse(comboTgK1.Items[comboTgK1.SelectedIndex].ToString());
            CalcDataGraphs();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            arCoef[2, 1] = double.Parse(comboTgK2.Items[comboTgK2.SelectedIndex].ToString());
            CalcDataGraphs();
        }

        private void comboCtgK1_SelectedIndexChanged(object sender, EventArgs e)
        {
            arCoef[3, 0] = double.Parse(comboCtgK1.Items[comboCtgK1.SelectedIndex].ToString());
            CalcDataGraphs();
        }

        private void comboCtgK2_SelectedIndexChanged(object sender, EventArgs e)
        {
            arCoef[3, 1] = double.Parse(comboCtgK2.Items[comboCtgK2.SelectedIndex].ToString());
            CalcDataGraphs();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            arCoef[0, 2] = double.Parse(this.comboBox1.Items[comboBox1.SelectedIndex].ToString());
            CalcDataGraphs();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            arCoef[0, 2] = double.Parse(this.comboBox2.Items[comboBox2.SelectedIndex].ToString());
            CalcDataGraphs();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            arCoef[0, 2] = double.Parse(this.comboBox3.Items[comboBox3.SelectedIndex].ToString());
            CalcDataGraphs();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            arCoef[0, 2] = double.Parse(this.comboBox4.Items[comboBox4.SelectedIndex].ToString());
            CalcDataGraphs();
        }

        #endregion COMBOBOXES

        #region MENU BUTTONS

        private void очиститьПолеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.checkBoxSin.Checked = false;
            this.checkBoxCos.Checked = false;
            this.checkBoxTan.Checked = false;
            this.checkBoxCTan.Checked = false;
            CalcDataGraphs();
        }
        
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion MENU BUTTONS

        // единичные окружности тригон. функций
        #region CIRCLES BLOCK
        
        private void DrawTrigCircle(PictureBox pb, Graphics g,string z1,string z2, string z3, string z4, int fillSector)
        {
            int w = pb.Width;
            int h = pb.Height;
            int rx = (w - 40) / 2;
            int ry = (h - 40) / 2;
            // заливаем сектор
            if (fillSector != 0)
            {
                g.FillPie(Brushes.Red, 20, 20, w - 40, h - 40, 180 + fillSector * 90, 90);
            }

            using (Pen p = new Pen(Color.Black))
            {
                g.DrawEllipse(p, 20, 20, w - 40, h - 40);
                g.DrawLine(p, 20 + (w - 40) / 2, 10, 20 + (w - 40) / 2, 30 + (h - 40));
                g.DrawLine(p, 10, 20 + (h - 40) / 2, 30 + (w - 40), 20 + (h - 40) / 2);

            }
            Font f = new Font("Arial", 14);

            // выводим знаки четвертей
            g.DrawString(z1, f, Brushes.Blue, 11 + (w - 40) / 2 - rx / 2, 9 + (h - 40) / 2 - rx / 2);
            g.DrawString(z2, f, Brushes.Blue, 11 + (w - 40) / 2 + rx / 2, 9 + (h - 40) / 2 - rx / 2);
            g.DrawString(z3, f, Brushes.Blue, 11 + (w - 40) / 2 + rx / 2, 9 + (h - 40) / 2 + rx / 2);
            g.DrawString(z4, f, Brushes.Blue, 11 + (w - 40) / 2 - rx / 2, 9 + (h - 40) / 2 + rx / 2);
            // выводим номера четвертей
            g.DrawString("II", f, Brushes.Red, 5, ry / 2);
            g.DrawString("I", f, Brushes.Red, w - 20, ry / 2);
            g.DrawString("IV", f, Brushes.Red, w - 20, h - ry / 2 - 5);
            g.DrawString("III", f, Brushes.Red, 5, h - ry / 2 - 5);
            Invalidate();

        }

        private void ImageCircleSin_Paint(object sender, PaintEventArgs e)
        {
            this.DrawTrigCircle(this.ImageCircleSin, e.Graphics, "+", "+", "-", "-", CirclePart);
        }

        private void ImageCircleCos_Paint(object sender, PaintEventArgs e)
        {
            this.DrawTrigCircle(this.ImageCircleCos, e.Graphics, "+", "-", "-", "+", CirclePart);
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            this.DrawTrigCircle(this.pictureBox3, e.Graphics, "+", "-", "+", "-", CirclePart);
        }

        private void pictureBox4_Paint(object sender, PaintEventArgs e)
        {
            this.DrawTrigCircle(this.pictureBox4, e.Graphics, "-", "+", "-", "+", CirclePart);
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            this.tableLayoutPanel3.Visible = !this.tableLayoutPanel3.Visible;
            //this.GroupBoxSettings.Enabled = !this.GroupBoxSettings.Enabled;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            GroupBoxSettings.Visible = !GroupBoxSettings.Visible;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int angle = int.Parse(this.EditAngle.Text);
                if (angle < -360 || angle > 360) throw new Exception();
                if (angle > 0 && angle <= 90) CirclePart = 1;
                if (angle > 90 && angle <= 180) CirclePart = 4;
                if(angle > 180 && angle <= 270) CirclePart = 3;
                if(angle > 270 && angle <= 360) CirclePart = 2;

                if (angle <= 0 && angle >-90) CirclePart = 2;
                if (angle <= -90 && angle > -180) CirclePart = 3;
                if (angle <= -180 && angle > -270) CirclePart = 4;
                if (angle <= -270 && angle > -360) CirclePart = 1;

                ImageCircleSin.Invalidate();
                ImageCircleCos.Invalidate();
                pictureBox3.Invalidate();
                pictureBox4.Invalidate();

            }
            catch
            {
                MessageBox.Show("Возможны значения от 0 до 360");
            }
        }

        #endregion CIRCLES BLOCK


    }
}