using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    static public class PointExt
    {
       static public Point minus(this Point left, Point right)
        {
            return new Point(left.X - right.X, left.Y - right.Y);
        }

       static public Point plus(this Point left, Point right)
        {
            return new Point(left.X + right.X, left.Y + right.Y);
        }

       static public Point mult(this Point left, float right)
       {
           return new Point((int)((float)left.X * right),(int)( (float)left.Y * right));
       }

       static public Point rot_to_left(this Point orgn)
        {
            return new Point(orgn.Y, -orgn.X);
        }

       static public Point reverse(this Point orgn)
        {
            return new Point(-orgn.X, -orgn.Y);
        }

       static public Point bymax_norm(this Point orgn)
        {

            if ((int)Math.Abs(orgn.X) > (int)Math.Abs(orgn.Y))
            {
                return new Point(orgn.X / (int)Math.Abs(orgn.X), 0);
            }
            return orgn.Y==0?new Point(0,0):new Point(0, (orgn.Y / (int)Math.Abs(orgn.Y)));
        }

       static public Point bymin_norm(this Point orgn)
        {
            if ((int)Math.Abs(orgn.X) < (int)Math.Abs(orgn.Y))
            {
                if (orgn.X == 0) return new Point(0, 0);
                return new Point(orgn.X / (int)Math.Abs(orgn.X), 0);
            }

            if (orgn.Y == 0) return new Point(0, 0);
            return new Point(0, (orgn.Y / (int)Math.Abs(orgn.Y)));
        }

        
    }
}
