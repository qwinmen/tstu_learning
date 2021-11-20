using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace WindowsApplication1
{

    /// <summary>
    /// 
    /// Handle object for redim/move/rotate shapes
    /// </summary>
    public class Handle : Ele
    {
        public string op;
        public Handle(int x, int y, int x1, int y1, string o)
        {
            this.X = x;
            this.X1 = x1;
            this.Y = y;
            this.Y1 = y1;
            op = o;
        }

        public Handle(Rectangle r, string o)
        {
            this.X = r.Left;
            this.X1 = r.Left + r.Width;
            this.Y = r.Top;
            this.Y1 = r.Top + r.Height;
            op = o;
        }

        public string isOver(int x, int y)
        {
            Rectangle r;
            r = new Rectangle(this.X, this.Y, this.X1 - this.X, this.Y1 - this.Y);
            if (r.Contains(x, y))
                return this.op;
            else
                return "";
        }

        public override void Draw(Graphics g, int dx, int dy, float zoom)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            myBrush.Color = this.Trasparency(Color.Black, 90);

            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Blue, 1.5f);

            // Create a path and add the object.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddRectangle(new RectangleF((this.X + dx) * zoom, (this.Y + dy) * zoom, (this.X1 - this.X) * zoom, (this.Y1 - this.Y) * zoom));
            //Matrix translateMatrix = new Matrix();
            //translateMatrix.RotateAt(this.Rotation, new PointF((this.X + dx + (int)(this.X1 - this.X) / 2) * zoom, (this.Y + dy + (int)(this.Y1 - this.Y) / 2) * zoom));
            //myPath.Transform(translateMatrix);

            // Draw the transformed ellipse to the screen.
            if (this.filled)
            {
                g.FillPath(myBrush, myPath);
                if (this.showBorder)
                    g.DrawPath(myPen, myPath);
            }
            else
                g.DrawPath(myPen, myPath);

            myPath.Dispose();
            myPen.Dispose();
            myBrush.Dispose();
        }


    }


    /// <summary>
    /// 
    /// Abstract Handle collection for redim/move/rotate shapes
    /// </summary>
    [Serializable]
    public abstract class AbstractSel : Ele
    {
        protected ArrayList handles;

        public AbstractSel(Ele el)
        {
            this.X = el.getX();
            this.Y = el.getY();
            this.X1 = el.getX1(); ;
            this.Y1 = el.getY1();
            this.Selected = false;
            this.rot = el.canRotate();// RotAllowed;
            this._rotation = el.getRotation();
            handles = new ArrayList();
            this.endMoveRedim();
        }

        public override void endMoveRedim()
        {
            base.endMoveRedim();
            foreach (Handle h in handles)
            {
                h.endMoveRedim();
            }
        }

        public override void move(int x, int y)
        {
            base.move(x, y);
            //
            foreach (Handle h in handles)
            {
                h.move(x, y);
            }
        }

        public void showHandles(bool i)
        {
            this.IamGroup = i;
        }

        /// <summary>
        /// Su quale maniglia cade il punto x,y? 
        /// </summary>
        public string isOver(int x, int y)
        {
            string ret;
            foreach (Handle h in handles)
            {
                ret = h.isOver(x, y);
                if (ret != "")
                    return ret;
            }

            if (this.contains(x, y))
                return "C";

            return "NO";

        }

        public override void Select()
        {
            this.undoEle = this.Copy();
        }

        public override void Draw(Graphics g, int dx, int dy, float zoom)
        {

            foreach (Handle h in handles)
            {
                h.Draw(g, dx, dy, zoom);
            }
        }


    }


    /// <summary>
    /// Handle tool for redim/move/rotate shapes
    /// </summary>
    [Serializable]
    public class SelRectTest : AbstractSel
    {

        public SelRectTest(Ele el)
            : base(el)
        {
            setup();
        }

        public override void redim(int x, int y, string redimSt)
        {
            base.redim(x, y, redimSt);

        }


        /// <summary>
        ///set ups handles
        /// </summary>
        public void setup()
        {
            Rectangle r;

            if (!this.AmIaGroup())
            {
                //NW
                r = new Rectangle(this.X - 2, this.Y - 2, 5, 5);
                this.handles.Add(new Handle(r, "NW"));
                //SE
                r.X = this.X1 - 2;
                r.Y = this.Y1 - 2;
                this.handles.Add(new Handle(r, "SE"));
                if (!sonoUnaLinea)
                {
                    //N
                    r.X = this.X - 2 + (this.X1 - this.X) / 2;
                    r.Y = this.Y - 2;
                    this.handles.Add(new Handle(r, "N"));
                    if (rot)
                    {
                        //ROT
                        float midX, midY = 0;
                        midX = (this.X1 - this.X) / 2;
                        midY = (this.Y1 - this.Y) / 2;
                        PointF Hp = new PointF(0, -25);
                        PointF RotHP = this.rotatePoint(Hp, this._rotation);
                        midX += RotHP.X;
                        midY += RotHP.Y;

                        r.X = this.X + (int)midX - 2;
                        r.Y = this.Y + (int)midY - 2;
                        this.handles.Add(new Handle(r, "ROT"));
                    }
                    //NE
                    r.X = this.X1 - 2;
                    r.Y = this.Y - 2;
                    this.handles.Add(new Handle(r, "NE"));
                    //E
                    r.X = this.X1 - 2;
                    r.Y = this.Y - 2 + (this.Y1 - this.Y) / 2;
                    this.handles.Add(new Handle(r, "E"));
                    //S
                    r.X = this.X - 2 + (this.X1 - this.X) / 2;
                    r.Y = this.Y1 - 2;
                    this.handles.Add(new Handle(r, "S"));
                    //SW
                    r.X = this.X - 2;
                    r.Y = this.Y1 - 2;
                    this.handles.Add(new Handle(r, "SW"));
                    //W
                    r.X = this.X - 2;
                    r.Y = this.Y - 2 + (this.Y1 - this.Y) / 2;
                    this.handles.Add(new Handle(r, "W"));
                }
            }

        }

    }


}
