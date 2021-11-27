using System;
using System.Reflection;
using �������������;

namespace ���������������
{
    class clPauell
    {
        /// <summary>
        /// �� ����� ������� �������: select = 'f' or 'r'
        /// </summary>
        public clPauell(char select)
        {
            ��������������.Selector = select;
            Poisk();
        }

        //[0] - ������ ������� �����������:
        private enum AB
        {
            AX1 = 1,
            AX2 = 1,
            BX1 = 10,
            BX2 = 10
        }
        //[1] - ������ ����� ���������� �����������:
        private Point K0 = new Point(2, 2);

        private void Poisk()
        {
            double epsilon = 0.01;
            ��������������.K = K0.ToString();
            //[2] - ������������� �0.� � ����� min ������� ��� F[��.AX1..AB.BX1; �0.x2]
            //�������� ����� K1 [X1min; K0.x2]
            Point K1 = new Point(��������������.��������((double) AB.AX1, (double) AB.BX1, epsilon, K0.Y), K0.Y);
            
            ��������������.K = K1.ToString();
            //[3] - ������������� �1.x1 � ����� min ������� ��� F[�1.x1; ��.AX2..AB.BX2]
            Point K2 = new Point(K1.X, ��������������.��������((double) AB.AX2, (double) AB.BX2, epsilon, K1.X));
            
            //[4] - ���������� ��� hx1=|K2x1-K0x1| � hx2=|K2x2-K0x2|
            double hx1 = Math.Abs(K2.X - K0.X);
            double hx2 = Math.Abs(K2.Y - K0.Y);

            //[stop] - ����� ��� (hx1+hx2)<epsilon
            if(hx1 + hx2 < epsilon)
			{Console.WriteLine("�����");Console.WriteLine("�����");Console.WriteLine("�����");}

            //[5] - ��������� ��������� ����� �3[K2.x1+hx1; K2.x2+hx2]
            Point K3 = new Point(K2.X+hx1, K2.Y+hx2);

            if (Program.F(K3, ��������������.Selector) < Program.F(K2, ��������������.Selector))
            {//[5] - ����� ������//�������� ����� �4 ��� � �3
                //K4[K3.x1+hx1; K3.x2+hx2]
                Point K4 = new Point(K3.X+hx1, K3.Y+hx2);
                //����� �������� K4 � K3
            }
            else
            {//[2] - ������������� �3.� � ����� min ������� ��� F[��.AX1..AB.BX1; �3.x2]
                //�������� ����� K4 [X1min; K3.x2]
                ��������������.K = K3.ToString();
                Point K4 = new Point(��������������.��������((double)AB.AX1, (double)AB.BX1, epsilon, K3.Y), K3.Y);

                //[3] - ������������� �4.x1 � ����� min ������� ��� F[�4.x1; ��.AX2..AB.BX2]
                ��������������.K = K4.ToString();
                Point K5 = new Point(K4.X, ��������������.��������((double)AB.AX2, (double)AB.BX2, epsilon, K4.X));
                
                //[4] - ���������� ��� hx1=|K5x1-K3x1| � hx2=|K5x2-K3x2|
                
                
            }

        }

    }

    /// <summary>
    /// ����� ����� ��� �������� [X;Y]
    /// </summary>
    class Point
    {
        private static int index = 0;
        private double _x, _y;
        /// <summary>
        /// [x.X1; X2.y]
        /// </summary>
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
            index++;
        }
        public double X { get { return _x; } set { _x = value; } }
        public double Y { get { return _y; } set { _y = value; } }

        public override string ToString()
        {
            return index.ToString();
        }

    }


}
