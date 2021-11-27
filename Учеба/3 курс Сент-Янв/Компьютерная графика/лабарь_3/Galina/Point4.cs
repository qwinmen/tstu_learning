using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Galina
{
    /// <summary>
    /// X-Y-Z-vector
    /// </summary>
    class Point4
    {
        private int _ax, _ay, _az, _av;
        private int _aXy, _axY, _aXz, _azY;

        public Point4(int ax, int ay, int az, int av)
        {
            _ax = ax;
            X = _ax;
            _ay = ay;
            Y = _ay;
            _az = az;
            Z = _az;
            _av = av;
            V = _av;
        }

        public Point4(Point A, Point Z, int av)
        {
            _aXy = A.X;
            X = _aXy;

            _axY = A.Y;
            Y = _axY;

            _aXz = Z.X;
            _azY = Z.Y;
            Zxy = new Point(_aXz, _azY);

            _av = av;
            V = _av;
        }

        internal int X { get; set; }
        internal int Y { get; set; }
        internal int Z { get; set; }
        internal int V { get; set; }
        internal Point Zxy { get; set; }



    }
}
