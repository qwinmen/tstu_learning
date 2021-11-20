using System;
using System.Drawing;
using System.Windows.Forms;
using ClassLibrary1;
using btnClass;
//ООП Лаб-1 Реализация собственного контрола
namespace Viktory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         
         
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                Bevel bevel = new Bevel();
                bevel.Left = 0 + i;
                bevel.Top = 50 + i;
                bevel.Height = 50 + i*2;
                bevel.Width = 50 + i*2;
                if (i%2 == 0)
                    bevel.Style = BevelStyle.Lowered;
                else
                    bevel.Style = BevelStyle.Raised;
                for (BevelShape j = BevelShape.Box; j <= BevelShape.HorizontalLine; j++)
                {
                    if (i == 0)
                    {
                        bevel.Shape = BevelShape.Box;
                    }
                   // else if (i == 1) bevel.Shape = BevelShape.Frame;
                 //   else bevel.Shape = j - i;
                    bevel.BevelShadowColor = Color.Red;
                    bevel.BevelColor = Color.Blue;

                    Controls.Add(bevel);
                }
                bevel.MouseDown += control_MouseDown;
                bevel.MouseMove += control_MouseMove;
                bevel.MouseUp += control_MouseUp;

                btnClass.BtnCtrl btn=new BtnCtrl();
                btn.Left = 2;
                btn.Top = 2;
                btn.Width = bevel.Width-4;
                btn.Text = "Катировки";
                btn.RunningSpeed = 50;
                btn.Start();
                bevel.Controls.Add(btn);
            }

        }
         
        private Boolean dragging;
        private Point startDragPoint;

        private void control_MouseDown(object sender,MouseEventArgs e)
        {
            dragging = true;
            startDragPoint = e.Location;
        }

        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                ((Control) sender).Left = ((Control) sender).Location.X + (e.Location.X - startDragPoint.X);
                ((Control)sender).Top = ((Control)sender).Location.Y + (e.Location.Y - startDragPoint.Y);
            }
        }

        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                dragging = false;
                Invalidate();
            }
        }

         
         
    }
}
