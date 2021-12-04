using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
//17 varik
namespace Сам
{
    class clModel
    {
        public clModel()
        {
            //Note: первая область
            List<double > list = new List<double>();
            list.Add(19.0);//T0 = 20-(-2*-0.5)=19.0
            List<PointD> alfaBeta = new List<PointD>();
            alfaBeta.Add(new PointD(-0.5, -0.5));
            int indx = 0;
            for (double i = -0.5; i < 0; i+=_deltaBet)
            {
                for (double j = -i; j < _L + i; j+=_deltaAlf)
                {
                    alfaBeta.Add(new PointD(i, j));
                    list.Add(list[indx] + (4.0*_Kt)/(_Ct*_p*_D)*(_Tt-list[indx])*_deltaAlf);
                    indx++;
                }
            }

            //Note: вторая область
            List<double> list2 = new List<double>();
            list2.Add(30.0);//Tвх = 20+10+5*sin(10) = 30
            List<PointD> alfaBeta2 = new List<PointD>();
            alfaBeta2.Add(new PointD(0, 0));
            indx = 0;
            for (double i = 0; i < 4.5; i += _deltaBet)
            {
                for (double j = i; j < _L + i; j += _deltaAlf)
                {
                    alfaBeta2.Add(new PointD(i, j));
                    list2.Add(list2[indx] + (4.0 * _Kt) / (_Ct * _p * _D) * (_Tt - list2[indx]) * _deltaAlf);
                    indx++;
                }
            }

            //Note: третья область
            List<double> list3 = new List<double>();
            list3.Add(30.0);//Tвх = 20+10+5*sin(10) = 30
            List<PointD> alfaBeta3 = new List<PointD>();
            alfaBeta3.Add(new PointD(4.5, 4.5));
            indx = 0;
            for (double i = 4.5; i < _tmax/2; i += _deltaBet)
            {
                for (double j = i; j < _tmax - i; j += _deltaAlf)
                {
                    alfaBeta3.Add(new PointD(i, j));
                    list3.Add(list3[indx] + (4.0 * _Kt) / (_Ct * _p * _D) * (_Tt - list3[indx]) * _deltaAlf);
                    indx++;
                }
            }

            List<PointPair4> coord = new List<PointPair4>();
            List<PointPair4> coord1 = new List<PointPair4>();
            List<PointPair4> coord2 = new List<PointPair4>();
            coord = Transform(list, alfaBeta);
            coord1 = Transform(list2, alfaBeta2);
            coord2 = Transform(list3, alfaBeta3);

            _1 = new PointPair4(coord[0]);
            _2 = new PointPair4(coord[1]);
            _3 = new PointPair4(coord[3]);
            _4 = new PointPair4(coord[5]);

            _5 = new PointPair4(coord1[13]);_6 = new PointPair4(coord1[27]);
            _7 = new PointPair4(coord1[41]);_8 = new PointPair4(coord1[55]);
            _9 = new PointPair4(coord1[68]);_10 = new PointPair4(coord1[77]);
            _11 = new PointPair4(coord1[84]);_12 = new PointPair4(coord1[91]);

            _13 = new PointPair4(coord2[1]);
            _14 = new PointPair4(coord2[3]);
            _15 = new PointPair4(coord2[5]);
            _16 = new PointPair4(coord2[7]);
        }

        //Область 1
        internal PointPair4 _1;
        internal PointPair4 _2;
        internal PointPair4 _3;
        internal PointPair4 _4;
        //Область 2
        internal PointPair4 _5;
        internal PointPair4 _6;
        internal PointPair4 _7;
        internal PointPair4 _8;
        //Область 2
        internal PointPair4 _9;
        internal PointPair4 _10;
        internal PointPair4 _11;
        internal PointPair4 _12;
        //Область 3
        internal PointPair4 _13;
        internal PointPair4 _14;
        internal PointPair4 _15;
        internal PointPair4 _16;

        /// <summary>
        /// По икс идет бета, по игрек идет Т, по зет идет альфа
        /// </summary>
        private List<PointPair4> Transform(List<double> T, List<PointD> alfBet)
        {
            List<PointPair4> ext = new List<PointPair4>();

            var index = 0;
            while (index<T.Count)
            {
                //PointPair4 sd = new PointPair4(alfBet[index].X, T[index], alfBet[index].Y, 0);
                ext.Add(new PointPair4(_u*(alfBet[index].Y - alfBet[index].X), T[index],
                                       alfBet[index].Y + alfBet[index].X, 0));
                index++;
            }

            return ext;
        }

        private const double _deltaAlf = 0.3;
        private const double _deltaBet = 0.2;

        private const double _Kt = 6500;
        private const double _Ct = 4190;
        private const double _p = 1000;

        private const double _Tt = 80;
        private const double _L = 1.0;
        private const double _D = 0.05;

        private const double _u = 0.2;
        private const double _tmax = 10.0;

    }
}
