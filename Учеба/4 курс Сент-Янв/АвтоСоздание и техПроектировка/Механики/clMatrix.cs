using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;
// для работы с библиотекой FreeGLUT 
using Tao.FreeGlut;
// для работы с элементом управления SimpleOpenGLControl 
using Tao.Platform.Windows;

namespace Механики
{
    internal class clMatrix
    {

        public struct Matrix4fT
        {
            public struct s
            {
                //column major
                private float M00;
                private float XX;
                private float SX;

                //XAxis.X and Scale X

                private float M10;
                private float XY;

                //XAxis.Y

                private float M20;
                private float XZ; //XAxis.Z

                private float M30;
                private float XW; //XAxis.W

                private float M01;
                private float YX; //YAxis.X

                private float M11;
                private float YY;
                private float SY; //YAxis.Y and Scale Y

                private float M21;
                private float YZ; //YAxis.Z

                private float M31;
                private float YW; //YAxis.W

                private float M02;
                private float ZX; //ZAxis.X

                private float M12;
                private float ZY; //ZAxis.Y

                private float M22;
                private float ZZ;
                private float SZ; //ZAxis.Z and Scale Z

                private float M32;
                private float ZW; //ZAxis.W

                private float M03;
                private float TX; //Trans.X

                //Trans.Y

                private float M23;
                private float TZ; //Trans.Z

                private float M33;
                private float TW;
                private float SW; //Trans.W and Scale W
            } ;
            /// <summary>
            /// [16]
            /// </summary>
            public float[] M;
        }

    }
}
