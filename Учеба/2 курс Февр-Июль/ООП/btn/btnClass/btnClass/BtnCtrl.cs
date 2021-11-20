using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace btnClass
{
    public partial class BtnCtrl : Label
    {
        private int _runningSpeed;

        private Timer _myTmr;

        private SolidBrush b;

        private float curX, fStep, fTxtWidth, fH, w;

        private Rectangle invRect = new Rectangle();

        private bool bDrawing;
        public BtnCtrl()
        {
            //InitializeComponent();
            curX = 0.0F;
            fStep = 1F;
            fTxtWidth = 0.0F;
            fH = 0.0F;
            w = 0.0F;
            _runningSpeed = 20;
            _myTmr = new Timer();
            _myTmr.Interval = _runningSpeed;
            _myTmr.Tick += new EventHandler(_myTmr_Tick);
        }

        

        public int RunningSpeed
        {
            get { return _runningSpeed; }
            set
            {
                _runningSpeed = value;
                if (_myTmr.Enabled)
                {
                    this.Stop();
                    this.Start();
                }
            }
        }

        public void Start()
        {
            if (Text.Length > 0)
            {
                _myTmr.Interval = _runningSpeed;

                Graphics myG = Graphics.FromHwndInternal(this.Handle);
                fTxtWidth = myG.MeasureString(Text, this.Font).Width;
                myG.Dispose();
                myG = null;
                System.GC.Collect();

                b = new SolidBrush(this.ForeColor);

                invRect.Height = this.Height;
                fH = (float)invRect.Height;
                w = (float)this.Width;
                curX = 0.0F;
                invRect.Y = 0;
                bDrawing = false;

                this.Invalidate();

                _myTmr.Start();
            }
        }

        public void Stop()
        {
            _myTmr.Stop();
            b.Dispose();
            b = null;
            System.GC.Collect();
        }

        void _myTmr_Tick(object sender, EventArgs e)
        {
            if (!bDrawing)
            {
                bDrawing = true;
                curX += fStep;
                if (curX >= w)
                {
                    curX = -fTxtWidth;
                }
                if (curX < 0)
                {
                    invRect.X = 0;
                    invRect.Width = (int)(curX + fTxtWidth) + 2;
                }
                else
                {
                    invRect.X = (int)(curX - fStep);
                    invRect.Width = (int)(fTxtWidth + fStep);
                }
                bDrawing = false;
                this.Invalidate(invRect, false);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            invRect.Height = this.Height;
            fH = (float)invRect.Height;
            w = (float)this.Width;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!_myTmr.Enabled)
            {
                base.OnPaint(e);
            }
            else
            {
                bDrawing = true;
                e.Graphics.DrawString(Text, this.Font, b, curX, 0.0F);
                bDrawing = false;
            }
        }

    }
}
