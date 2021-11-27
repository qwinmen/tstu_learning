using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Куб
{
    /// <summary>
    /// Единичный куб
    /// </summary>
    class clKub
    {
        Pen _pen = new Pen(Color.Black);
        
        public clKub(Graphics graphics)
        {
            InitArrayPoint();
            Draw(graphics);
        }

        public clKub(Graphics graphics, int centr)
        {
            _НачалоКоординат = new Size(centr, centr);
            InitArrayPoint();
            Draw(graphics);
            _tempArray = arrPoint;
        }

        /// <summary>
        /// Единичный куб
        /// </summary>
        private void InitArrayPoint()
        {
            arrPoint[0] = new Point(10, 10);
            arrPoint[1] = new Point(20, 10);

            arrPoint[2] = new Point(20, 20);
            arrPoint[3] = new Point(10, 20);

            arrPoint[4] = new Point(10, 10);

            arrPoint[5] = new Point(20, 0);
            arrPoint[6] = new Point(30, 0);

            arrPoint[7] = new Point(30, 10);
            arrPoint[8] = new Point(20, 10);

            arrPoint[9] = new Point(20, 0);
            arrPoint[10] = new Point(30, 0);

            arrPoint[11] = new Point(20, 10);
            arrPoint[12] = new Point(10, 20);

            arrPoint[13] = new Point(20, 20);
            arrPoint[14] = new Point(30, 10);

        }

        Point[] arrPoint = new Point[15];
        private Size _НачалоКоординат = new Size(100, 100);

        Point[] _tempArray = new Point[15];

        /// <summary>
        /// Нарисовать и центровать
        /// </summary>
        private void Draw(Graphics graphics)
        {
            //переносим обьект в центр
            for (int i = 0; i < arrPoint.Length; i++)
            {
                arrPoint[i] = arrPoint[i] + _НачалоКоординат;
            }

            graphics.DrawPolygon(_pen, arrPoint);
        }

        public Point[] Mashtab(int коэфф)
        {
            /*
             S(xyz1) = 
                     x_0_0_0
                     0_y_0_0
                     0_0_z_0
                     0_0_0_1
             * [S]4 столбца == 4 строкам [P]
             * 
             * P(xyz1) = 
                      x
                      y
                      z
                      1
             * S[4*4] * P[1*4]
             */
            //Взять arrPoint[] и все значения перегнатьчерез матрицу
            //на выходе получить матрицу arrPoint[] и отобразить её
            int[] S = new int[]
                          {
                              коэфф, 0, 0, 0,
                              0, коэфф, 0, 0,
                              0, 0, коэфф, 0,
                              0, 0, 0,     1
                          };
            Point[] tmpArr = new Point[arrPoint.Length];
            int i = 0;
            foreach (Point point in arrPoint)
            {
                //point.X*(коэфф, 0, 0, 0) => X
                //point.Y*(0, коэфф, 0, 0) => Y
                //point.Z*(0, 0, коэфф, 0) => Z
                //point.A*(0, 0, 0,     1) => A
                tmpArr[i] = new Point((point.X - _НачалоКоординат.Height)*коэфф,
                                      (point.Y - _НачалоКоординат.Width)*коэфф);
                
                i++;
            }
            //_tempArray = tmpArr;
            return Centrovka(tmpArr);
        }

        /// <summary>
        /// Выполнить перенос в точку
        /// </summary>
        public Point[] Perenos(Point tochka)
        {
            Point[] tmpArr = new Point[arrPoint.Length];
            int i = 0;
            foreach (Point point in _tempArray)
            {
                tmpArr[i] = new Point((point.X + tochka.X) - _НачалоКоординат.Height-10,
                                      (point.Y + tochka.Y) - _НачалоКоординат.Width-10);

                i++;
            }
            //_tempArray = tmpArr;

            return tmpArr;
            /*//Как должно но не работает
            Point[] tmp = new Point[15];
            int i = 0;
            foreach (Point point in _tempArray)
            {
                int[] tmper = A_mul_B('p', new int[] {point.X, point.Y, 0, 0}, tochka);
                 tmp[i] = new Point(tmper[0], tmper[1]);
                i++;
            }
            return tmp;
           */
        }

        /// <summary>
        /// Выполнить поворот относительно х
        /// </summary>
        public Point[] PovorotX(PointF tochka)//(Point tochka)
        {
            Point[] tmp = new Point[15];
            int i = 0;
            foreach (Point point in _tempArray)
            {
                int[] tmper = A_mul_B('x', new int[] {point.X, point.Y, 0, 0}, tochka);
                 tmp[i] = new Point(tmper[0], tmper[1]);
                i++;
            }
            return tmp;
        }

        /// <summary>
        /// Выполнить поворот относительно Y
        /// </summary>
        public Point[] PovorotY(PointF tochka)
        {
            Point[] tmp = new Point[15];
            int i = 0;
            foreach (Point point in _tempArray)
            {
                int[] tmper = A_mul_B('y', new int[] { point.X, point.Y, 0, 0 }, tochka);
                tmp[i] = new Point(tmper[0], tmper[1]);
                i++;
            }
            return tmp;
        }

        /// <summary>
        /// Выполнить поворот относительно Z
        /// </summary>
        public Point[] PovorotZ(PointF tochka)
        {
            Point[] tmp = new Point[15];
            int i = 0;
            foreach (Point point in _tempArray)
            {
                int[] tmper = A_mul_B('z', new int[] { point.X, point.Y, 0, 0 }, tochka);
                tmp[i] = new Point(tmper[0], tmper[1]);
                i++;
            }
            return tmp;
        }

        /// <summary>
        /// Выполнить перенос на центр холста
        /// </summary>
        private Point[] Centrovka(Point[] arr)
        {
            //переносим обьект в центр
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] + _НачалоКоординат;
            }
            _tempArray = arr;
            return arr;
        }

        /// <summary>
        /// Выполнить перенос в угол холста
        /// </summary>
        private Point[] Ziro(Point[] arr)
        {
            //переносим обьект в центр
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] - _НачалоКоординат;
            }
            return arr;
        }

        /// <summary>
        /// Перемножить два массива
        /// X = A[0]
        /// Y = A[1]
        /// Z = A[2]
        /// A = A[3]
        /// </summary>
        internal int[] A_mul_B(char flagOper, int[] A, PointF koeff)//(char flagOper, int[] A, Point koeff)
        {
            switch (flagOper)
            {
                case 'm':
                    {
                        int[] S = new int[]
                          {
                              (int)koeff.X, 0, 0, 0,
                              0, (int)koeff.X, 0, 0,
                              0, 0, (int)koeff.X, 0,
                              0, 0, 0,     1
                          };
                        return new int[]
                                   {
                                       (int)(koeff.X*A[0] + 0*A[1] + 0*A[2] + 0*A[3]),//X
                                       (int)(0*A[0] + koeff.X*A[1] + 0*A[2] + 0*A[3]),//Y
                                       (int)(0*A[0] + 0*A[1] + koeff.X*A[2] + 0*A[3]),//Z
                                       (0*A[0] + 0*A[1] + 0*A[2] + 1*A[3])//A
                                   };
                    }
                    break;
                case 'p':
                    {
                        int[] S = new int[]
                          {
                              1, 0, 0, 0,
                              0, 1, 0, 0,
                              0, 0, 1, 0,
                              (int)koeff.X, (int)koeff.Y, 0, 1
                          };
                        return new int[]
                                   {
                                       (1*A[0] + 0*A[1] + 0*A[2] + 0*A[3]),//X
                                       (0*A[0] + 1*A[1] + 0*A[2] + 0*A[3]),//Y
                                       (0*A[0] + 0*A[1] + 1*A[2] + 0*A[3]),//Z
                                       (int)(koeff.X*A[0] + koeff.Y*A[1] + 0*A[2] + 1*A[3])//A
                                   };
                    }
                    break;
                case 'x':
                    {
                        int[] S = new int[]
                          {
                              1, 0, 0, 0,
                              0, (int)Math.Cos(koeff.X), (int)Math.Sin(koeff.X), 0,
                              0, -(int)Math.Sin(koeff.X), (int)Math.Cos(koeff.X), 0,
                              0, 0, 0, 1
                          };
                        return new int[]
                                   {
                                       (1*A[0] + 0*A[1] + 0*A[2] + 0*A[3]),//X
                                       (int)(0*A[0] + Math.Cos(koeff.X)*A[1] + Math.Sin(koeff.X)*A[2] + 0*A[3]),//Y
                                       (int)(0*A[0] - Math.Sin(koeff.X)*A[1] + Math.Cos(koeff.X)*A[2] + 0*A[3]),//Z
                                       (0*A[0] + 0*A[1] + 0*A[2] + 1*A[3])//A
                                   };
                    }
                    break;
                case 'y':
                    {
                        int[] S = new int[]
                          {
                              (int)Math.Cos(koeff.X), 0, -(int)Math.Sin(koeff.X), 0,
                              0, 1, 0, 0,
                              (int)Math.Sin(koeff.X), 0, (int)Math.Cos(koeff.X), 0,
                              0, 0, 0, 1
                          };
                        return new int[]
                                   {
                                       (int)(Math.Cos(koeff.X)*A[0] + 0*A[1] - Math.Sin(koeff.X)*A[2] + 0*A[3]),//X
                                       (0*A[0] + 1*A[1] + 0*A[2] + 0*A[3]),//Y
                                       (int)(Math.Sin(koeff.X)*A[0] + 0*A[1] + Math.Cos(koeff.X)*A[2] + 0*A[3]),//Z
                                       (0*A[0] + 0*A[1] + 0*A[2] + 1*A[3])//A
                                   };
                    }
                    break;
                case 'z':
                    {
                        int[] S = new int[]
                          {
                              (int)Math.Cos(koeff.X), (int)Math.Sin(koeff.X), 0, 0,
                              -(int)Math.Sin(koeff.X), (int)Math.Cos(koeff.X), 0, 0,
                              0, 0, 1, 0,
                              0, 0, 0, 1
                          };
                        return new int[]
                                   {
                                       (int)(Math.Cos(koeff.X)*A[0] + Math.Sin(koeff.X)*A[1] + 0*A[2] + 0*A[3]),//X
                                       (int)(-Math.Sin(koeff.X)*A[0] + Math.Cos(koeff.X)*A[1] + 0*A[2] + 0*A[3]),//Y
                                       (0*A[0] + 0*A[1] + 1*A[2] + 0*A[3]),//Z
                                       (0*A[0] + 0*A[1] + 0*A[2] + 1*A[3])//A
                                   };
                    }
                    break;
            }
            return null;
        }

        /// <summary>
        /// Расстояние от проекцПлоскости до смотрящего
        /// </summary>
        private const float _d = 600;

        /// <summary>
        /// Проекция для точек схода
        /// </summary>
        internal PointF[] Proekc(bool x, bool y, bool z)
        {
            /*
         Одна точка схода по Z
         * x' = x/(1+z/d)
         * y' = y/(1+z/d)
         Две точки схода по Z и Y
         * x' = x/(1+z/d + y/d)
         * y' = y/(1+z/d + y/d)
         Три точки схода по Z_Y_X
         * x' = x/(1+z/d + y/d + x/d)
         * y' = y/(1+z/d + y/d + x/d)
         */
            PointF[] tmp = new PointF[15];
            int i = 0;

            if(x&&y&&z)//x-y-z
                foreach (Point point in _tempArray)
                {
                    tmp[i] = new PointF(point.X / (1.0f + 0 / _d + point.X / _d + point.Y / _d),
                                       point.Y / (1.0f + 0 / _d + point.X / _d + point.Y / _d));
                    //double ttt = point.X / (1.0 + 0.0 / _d + point.X / _d + point.Y / _d);
                    //double ddd = point.Y/ (1.0 + 0/_d + point.X/_d + point.Y/_d);
                    i++;
                }
            else if (!x&&y&&z)//y-z
            {
                i = 0;
                foreach (Point point in _tempArray)
                {
                    tmp[i] = new PointF(point.X / (1 + 0 / _d + point.Y / _d),
                                       point.Y / (1 + 0 / _d + point.Y / _d));
                    i++;
                }
            }
            else if (!x && !y && z)//z
            {
                i = 0;
                foreach (Point point in _tempArray)
                {
                    tmp[i] = new PointF(point.X / (1 + 0 / _d),
                                       point.Y / (1 + 0 / _d));
                    i++;
                }
            }

            if (x && y && !z)//x-y
            {
                i = 0;
                foreach (Point point in _tempArray)
                {
                    tmp[i] = new PointF(point.X / (1 + point.X / _d + point.Y / _d),
                                       point.Y / (1 + point.X / _d + point.Y / _d));
                    i++;
                }
            }
            else if (x && !y && !z)//x
            {
                i = 0;
                foreach (Point point in _tempArray)
                {
                    tmp[i] = new PointF(point.X / (1 + point.X / _d),
                                       point.Y / (1 + point.X / _d));
                    i++;
                }
            }

            if (x && !y && z)//x-z
            {
                i = 0;
                foreach (Point point in _tempArray)
                {
                    tmp[i] = new PointF(point.X / (1 + point.X / _d + 0 / _d),
                                       point.Y / (1 + point.X / _d + 0 / _d));
                    i++;
                }
            }

            if (!x && y && !z)//y
            {
                i = 0;
                foreach (Point point in _tempArray)
                {
                    tmp[i] = new PointF(point.X / (1 + point.Y / _d),
                                       point.Y / (1 + point.Y / _d));
                    i++;
                }
            }



            return tmp;
        }

        internal PointF[] Otobrajenie(bool kabinet, bool voennik)
        {
            /*
         x' = x + z * (L * Math.Cos(alpha))
         y' = y + z * (L * Math.Sin(alpha))
         * Военник=L=1
         * Кабинет=L=0.5
         * alpha=30_OR_45
         */
            PointF[] arrTmp = new PointF[15];
            int i = 0;
            float Cos = (float)Math.Cos(45);
            float Sin = (float)Math.Sin(45);
            float Z = 2.5f;

            if (kabinet)
            {
                foreach (Point point in _tempArray)
                {
                    arrTmp[i] = new PointF(point.X + Z * (0.5f * Cos), point.Y + Z * (0.5f * Sin));
                    i++;
                }
            }
            else if (voennik)
            {
                foreach (Point point in _tempArray)
                {
                    arrTmp[i] = new PointF(point.X + Z * (1.0f * Cos), point.Y + Z * (1.0f * Sin));
                    i++;
                }
            }
            return arrTmp;
        }




    }

    

}
