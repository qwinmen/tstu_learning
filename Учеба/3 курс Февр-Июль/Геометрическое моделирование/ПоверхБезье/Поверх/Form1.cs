using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ZedGraph;

namespace Поверх
{
    public partial class Form1 : Form
    {
        private PointPair4 _1 = new PointPair4(1.0, 1.0, 3.0, 1.0);
        private PointPair4 _2 = new PointPair4(2.0, 1.0, 1.0, 1.0);
        private PointPair4 _3 = new PointPair4(3.0, 1.0, 1.0, 1.0);
        private PointPair4 _4 = new PointPair4(4.0, 1.0, 1.0, 1.0);

        private PointPair4 _5 = new PointPair4(1.0, 2.0, 1.0, 1.0);
        private PointPair4 _6 = new PointPair4(2.0, 2.0, 1.0, 1.0);
        private PointPair4 _7 = new PointPair4(3.0, 2.0, 1.0, 1.0);
        private PointPair4 _8 = new PointPair4(4.0, 2.0, 3.0, 1.0);

        private PointPair4 _9 = new PointPair4( 1.0, 3.0, 1.0, 1.0);
        private PointPair4 _10 = new PointPair4(2.0, 3.0, 1.0, 1.0);
        private PointPair4 _11 = new PointPair4(3.0, 3.0, 1.0, 1.0);
        private PointPair4 _12 = new PointPair4(4.0, 3.0, 3.0, 1.0);

        private PointPair4 _13 = new PointPair4(1.0, 4.0, 1.0, 1.0);
        private PointPair4 _14 = new PointPair4(2.0, 4.0, 1.0, 1.0);
        private PointPair4 _15 = new PointPair4(3.0, 4.0, 1.0, 1.0);
        private PointPair4 _16 = new PointPair4(4.0, 4.0, 3.0, 1.0);

        private List<PointPair4> _pList = new List<PointPair4>();

        private PointPair4[] Mb = new PointPair4[4];
        private PointPair4[] MbT = new PointPair4[4];
        
        // Создадим список точек
        private PointPairList _list = new PointPairList();
        /// <summary>
        /// Для точек на экране (отрисовка)
        /// </summary>
        private GraphPane _paneXY, _paneYZ, _paneXZ, _pane;
        /// <summary>
        /// Итератор массива точек
        /// </summary>
        private int _num = 0;
        /// <summary>
        /// Храним опорные точки с экрана
        /// </summary>
        private List<PointD> _lpointArrXY = new List<PointD>();
        private List<PointD> _lpointArrXZ = new List<PointD>(); 
        private List<PointD> _lpointArrYZ = new List<PointD>();
        /// <summary>
        /// Для копипаста экранных опорных точек
        /// </summary>
        private PointD[] _pointArr;
        /// <summary>
        /// Флаг разрешает ставить точки на холсте
        /// </summary>
        private bool _activSetPoint;





        public Form1()
        {
            InitializeComponent();

            Mb[0] = new PointPair4(-1.0, 3.0, -3.0, 1.0);
            Mb[1] = new PointPair4(3.0, -6.0, 3.0, 0.0);
            Mb[2] = new PointPair4(-3.0, 3.0, 0.0, 0.0);
            Mb[3] = new PointPair4(1.0, 0.0, 0.0, 0.0);

            MbT[0] = new PointPair4(-1.0, 3.0, -3.0, 1.0);
            MbT[1] = new PointPair4(3.0, -6.0, 3.0, 0.0);
            MbT[2] = new PointPair4(-3.0, 3.0, 0.0, 0.0);
            MbT[3] = new PointPair4(1.0, 0.0, 0.0, 0.0);


            _paneXY = zedGraphControl_XY.GraphPane;
            _paneYZ = zedGraphControl_YZ.GraphPane;
            _paneXZ = zedGraphControl_XZ.GraphPane;

            zedGraphControl_XY.GraphPane.Title.Text = "";
            zedGraphControl_XY.GraphPane.YAxis.Title.Text = "Ось Y";
            zedGraphControl_XY.GraphPane.XAxis.Title.Text = "Ось X";

            zedGraphControl_XZ.GraphPane.Title.Text = "";
            zedGraphControl_XZ.GraphPane.YAxis.Title.Text = "Ось Z";
            zedGraphControl_XZ.GraphPane.XAxis.Title.Text = "Ось X";

            zedGraphControl_YZ.GraphPane.Title.Text = "";
            zedGraphControl_YZ.GraphPane.YAxis.Title.Text = "Ось Y";
            zedGraphControl_YZ.GraphPane.XAxis.Title.Text = "Ось Z";

            _pList.Add(_1); _pList.Add(_2); _pList.Add(_3); _pList.Add(_4);
            _pList.Add(_5); _pList.Add(_6); _pList.Add(_7); _pList.Add(_8);
            _pList.Add(_9); _pList.Add(_10); _pList.Add(_11); _pList.Add(_12);
            _pList.Add(_13); _pList.Add(_14); _pList.Add(_15); _pList.Add(_16);
            PointPairList two = new PointPairList();
            PointPairList vert = new PointPairList();
            foreach (PointPair4 pointPair4 in _pList)
            {
                _list.Add(pointPair4.X, pointPair4.Y);
                two.Add(pointPair4.Z, pointPair4.Y);
                vert.Add(pointPair4.X, pointPair4.Z);
            }
            DrawGraph(zedGraphControl_XY, _list, 1);
            DrawGraph(zedGraphControl_YZ, two, 2);
            DrawGraph(zedGraphControl_XZ, vert, 3);
        }

        /// <summary>
        /// Отрисовка графика функции
        /// </summary>
        private void DrawGraph(ZedGraphControl zedGraph, PointPairList list, int flag)
        {
            // Получим панель для рисования
            GraphPane pane = zedGraph.GraphPane;

            
            double xmin_limit = -80, xmax_limit = +80;
            double ymin_limit = -80, ymax_limit = +80;

            // !!!
            // Устанавливаем интересующий нас интервал по оси X
            //pane.XAxis.Scale.Min = xmin_limit;
            //pane.XAxis.Scale.Max = xmax_limit;

            // !!!
            // Устанавливаем интересующий нас интервал по оси Y
            //pane.YAxis.Scale.Min = ymin_limit;
            //pane.YAxis.Scale.Max = ymax_limit;
            

            // Включим отображение сетки
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;

            // Создадим кривую с названием "Sinc",// которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            

            if(flag== 1)//xy
            {
                LineItem myCurve = pane.AddCurve("", list, Color.Blue, SymbolType.Circle);
                //Тег будет линком для поиска точки, которую надо перезаписать
                myCurve.Tag = _index++;
                if (state)
                myCurve.Line.Fill = new ZedGraph.Fill(Color.Red, Color.Yellow, Color.Blue, 90.0f);
            }
            if(flag== 2)//yz
            {
                LineItem myCurve = pane.AddCurve("", list, Color.Blue, SymbolType.Plus);
                //Тег будет линком для поиска точки, которую надо перезаписать
                myCurve.Tag = _indexYZ++;
                if (state)
                myCurve.Line.Fill = new ZedGraph.Fill(Color.Red, Color.Yellow, Color.Blue, 90.0f);
            }
            if(flag== 3)//xz
            {
                LineItem myCurve = pane.AddCurve("", list, Color.Blue, SymbolType.Square);
                //Тег будет линком для поиска точки, которую надо перезаписать
                myCurve.Tag = _indexXZ++;
                if(state)
                myCurve.Line.Fill = new ZedGraph.Fill(Color.Red, Color.Yellow, Color.Blue, 90.0f);
            }
            
            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();
        }

        private int _indexYZ = 0, _indexXZ = 0;

        private void zedGraphControl_XY_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            //блочить рисование точки
            if (_activSetPoint)
                return;

            // Сюда будут записаны координаты в системе координат графика
            double x, y;

            // Пересчитываем пиксели в координаты на графике
            // У ZedGraph есть несколько перегруженных методов ReverseTransform.
            zedGraphControl_XY.GraphPane.ReverseTransform(e.Location, out x, out y);


            //Ставим точку где кликнули
            _pane = zedGraphControl_XY.GraphPane;

            //поставить точку по [x;y]
            //SetPointCurve(x, y, zedGraphControl_XY, 1);

            //_lpointArrXY.Add(new PointD(x, y));
        }

        private void zedGraphControl_YZ_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            //блочить рисование точки
            if (_activSetPoint)
                return;

            // Сюда будут записаны координаты в системе координат графика
            double x, y;

            // Пересчитываем пиксели в координаты на графике
            // У ZedGraph есть несколько перегруженных методов ReverseTransform.
            zedGraphControl_YZ.GraphPane.ReverseTransform(e.Location, out x, out y);


            //Ставим точку где кликнули
            _pane = zedGraphControl_YZ.GraphPane;

            //поставить точку по [x;y]
            //SetPointCurve(x, y, zedGraphControl_YZ, 2);

            //_lpointArrYZ.Add(new PointD(x, y));
        }

        private void zedGraphControl_XZ_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            //блочить рисование точки
            if (_activSetPoint)
                return;

            // Сюда будут записаны координаты в системе координат графика
            double x, y;

            // Пересчитываем пиксели в координаты на графике
            // У ZedGraph есть несколько перегруженных методов ReverseTransform.
            zedGraphControl_XZ.GraphPane.ReverseTransform(e.Location, out x, out y);


            //Ставим точку где кликнули
            _pane = zedGraphControl_XZ.GraphPane;

            //поставить точку по [x;y]
            //SetPointCurve(x, y, zedGraphControl_XZ, 3);

            //_lpointArrXZ.Add(new PointD(x, y));
        }

        /// <summary>
        /// индекс для ориентира в массиве (смены координаты точки)
        /// </summary>
        private int _index = 0;

        /// <summary>
        /// Нарисовать точку по координате
        /// </summary>
        private void SetPointCurve(double x, double y, ZedGraphControl zedGraph, int flag)
        {
            _pane = zedGraph.GraphPane;
            
            LineItem curvePount = _pane.AddCurve("", new[] { x }, new[] { y }, Color.Blue, SymbolType.Circle);
            // У кривой линия будет невидимой
            curvePount.Line.IsVisible = false;
            //Тег будет линком для поиска точки, которую надо перезаписать
            if (flag == 1)//xy
                curvePount.Tag = _index++;
            if (flag == 2)//yz
                curvePount.Tag = _indexYZ++;
            if (flag == 3)//xz
                curvePount.Tag = _indexXZ++;

            // Цвет заполнения круга - колубой
            curvePount.Symbol.Fill.Color = Color.Red;
            // Тип заполнения - сплошная заливка
            curvePount.Symbol.Fill.Type = FillType.Solid;
            // Размер круга
            curvePount.Symbol.Size = 7;
            //-----------------------------------------//
            zedGraph.Invalidate();
        }

        /// <summary>
        /// Построить поверхность
        /// </summary>
        private void roundButton1_Click(object sender, System.EventArgs e)
        {
            //Чистим холст
            Clear();
            _list.Clear();
            PointPairList two = new PointPairList(), vert = new PointPairList();

            for (double t = 0.01; t < 1.0; t+=0.04)
            {
                for (double s = 0.01; s < 1.0; s+=0.04)
                {
                    var smb = SMb(new PointPair4(s*s*s, s*s, s, 1.0));
                    var px = Px(smb);
                    var py = Py(smb);
                    var pz = Pz(smb);

                    var pmx = PM(px); var pmy = PM(py); var pmz = PM(pz);

                    var resX = MT(pmx, new PointPair4(t*t*t, t*t, t, 1.0));
                    var resY = MT(pmy, new PointPair4(t*t*t, t*t, t, 1.0));
                    var resZ = MT(pmz, new PointPair4(t*t*t, t*t, t, 1.0));

                    //SetPointCurve(resZ, resY, zedGraphControl_YZ);
                    _list.Add(resX, resY);
                    two.Add(resZ, resY);
                    vert.Add(resX, resZ);
                }

                //Добавить точки разрыва в кривые
                _list.Add(PointPairBase.Missing, PointPairBase.Missing);
                two.Add(PointPairBase.Missing, PointPairBase.Missing);
                vert.Add(PointPairBase.Missing, PointPairBase.Missing);
            }

            DrawGraph(zedGraphControl_XY, _list, 1);
            DrawGraph(zedGraphControl_YZ, two, 2);
            DrawGraph(zedGraphControl_XZ, vert, 3);
        }

        /// <summary>
        /// S[1;4]*Mb[4;4] = SMb[1;4]
        /// </summary>
        private PointPair4 SMb(PointPair4 S)
        {
            //S.x//S.y//S.z//S.t//S[x,y,z,t]

            PointPair4 tmp = new PointPair4(
                (S.X*Mb[0].X + S.Y*Mb[1].X + S.Z*Mb[2].X + S.T*Mb[3].X),
                (S.X*Mb[0].Y + S.Y*Mb[1].Y + S.Z*Mb[2].Y + S.T*Mb[3].Y),
                (S.X*Mb[0].Z + S.Y*Mb[1].Z + S.Z*Mb[2].Z + S.T*Mb[3].Z),
                (S.X*Mb[0].T + S.Y*Mb[1].T + S.Z*Mb[2].T + S.T*Mb[3].T)
                );

            return tmp;
        }

        /// <summary>
        /// Tmp[S*Mb]*P[4;4] = P[1;4]
        /// </summary>
        private PointPair4 Px(PointPair4 SMb)
        {//SMb[x;y;z;t]

            PointPair4 tmp = new PointPair4(
                (SMb.X*_pList[0].X + SMb.Y*_pList[4].X + SMb.Z*_pList[8].X + SMb.T*_pList[12].X),
                (SMb.X*_pList[1].X + SMb.Y*_pList[5].X + SMb.Z*_pList[9].X + SMb.T*_pList[13].X),
                (SMb.X*_pList[2].X + SMb.Y*_pList[6].X + SMb.Z*_pList[10].X + SMb.T*_pList[14].X),
                (SMb.X*_pList[3].X + SMb.Y*_pList[7].X + SMb.Z*_pList[11].X + SMb.T*_pList[15].X)
                );

            return tmp;
        }

        private PointPair4 Py(PointPair4 SMb)
        {
            PointPair4 tmp = new PointPair4(
                (SMb.X * _pList[0].Y + SMb.Y * _pList[4].Y + SMb.Z * _pList[8].Y + SMb.T * _pList[12].Y),
                (SMb.X * _pList[1].Y + SMb.Y * _pList[5].Y + SMb.Z * _pList[9].Y + SMb.T * _pList[13].Y),
                (SMb.X * _pList[2].Y + SMb.Y * _pList[6].Y + SMb.Z * _pList[10].Y + SMb.T * _pList[14].Y),
                (SMb.X * _pList[3].Y + SMb.Y * _pList[7].Y + SMb.Z * _pList[11].Y + SMb.T * _pList[15].Y)
                );

            return tmp;
        }

        private PointPair4 Pz(PointPair4 SMb)
        {
            PointPair4 tmp = new PointPair4(
                (SMb.X * _pList[0].Z + SMb.Y * _pList[4].Z + SMb.Z * _pList[8].Z + SMb.T * _pList[12].Z),
                (SMb.X * _pList[1].Z + SMb.Y * _pList[5].Z + SMb.Z * _pList[9].Z + SMb.T * _pList[13].Z),
                (SMb.X * _pList[2].Z + SMb.Y * _pList[6].Z + SMb.Z * _pList[10].Z + SMb.T * _pList[14].Z),
                (SMb.X * _pList[3].Z + SMb.Y * _pList[7].Z + SMb.Z * _pList[11].Z + SMb.T * _pList[15].Z)
                );

            return tmp;
        }


        /// <summary>
        /// P[1;4]*MbT[4;4] = PM[1;4]
        /// </summary>
        private PointPair4 PM(PointPair4 p)
        {
            PointPair4 tmp = new PointPair4(
                (p.X * MbT[0].X + p.Y * MbT[1].X + p.Z * MbT[2].X + p.T * MbT[3].X),
                (p.X * MbT[0].Y + p.Y * MbT[1].Y + p.Z * MbT[2].Y + p.T * MbT[3].Y),
                (p.X * MbT[0].Z + p.Y * MbT[1].Z + p.Z * MbT[2].Z + p.T * MbT[3].Z),
                (p.X * MbT[0].T + p.Y * MbT[1].T + p.Z * MbT[2].T + p.T * MbT[3].T)
                );

            return tmp;
        }

        /// <summary>
        /// Конечн число
        /// </summary>
        private double MT(PointPair4 Pm, PointPair4 t)
        {
            double tmp = (Pm.X*t.X + Pm.Y*t.Y + Pm.Z*t.Z + Pm.T*t.T);

            return tmp;
        }

        private void Clear()
        {
            _index = 0;
            _indexXZ = 0;
            _indexYZ = 0;

            _lpointArrXY.Clear();
            _lpointArrYZ.Clear();
            _lpointArrXZ.Clear();

            _paneXY.CurveList.Clear();
            _paneYZ.CurveList.Clear();
            _paneXZ.CurveList.Clear();

            zedGraphControl_XY.Refresh();
            zedGraphControl_YZ.Refresh();
            zedGraphControl_XZ.Refresh();
        }

        /// <summary>
        /// Строим скелет
        /// </summary>
        private void roundButton2_Click(object sender, System.EventArgs e)
        {
            Clear();
            _list.Clear();

            PointPairList two = new PointPairList();
            PointPairList vert = new PointPairList();
            foreach (PointD pointD in _lpointArrXY)
            {
                //_list.Add(pointD.X, pointD.Y);
            }
            foreach (PointD pointD in _lpointArrYZ)
            {
                //two.Add(pointD.X, pointD.Y);
            }
            foreach (PointD pointD in _lpointArrXZ)
            {
                //vert.Add(pointD.X, pointD.Y);
            }

            //точки для отрисовки
            foreach (PointPair4 pointPair4 in _pList)
            {
                _list.Add(pointPair4.X, pointPair4.Y);
                SetPointCurve(pointPair4.X, pointPair4.Y, zedGraphControl_XY, 1);
                
                two.Add(pointPair4.Z, pointPair4.Y);
                SetPointCurve(pointPair4.Z, pointPair4.Y, zedGraphControl_YZ, 2);

                vert.Add(pointPair4.X, pointPair4.Z);
                SetPointCurve(pointPair4.X, pointPair4.Z, zedGraphControl_XZ, 3);
            }
            
            
            //DrawGraph(zedGraphControl_XY, _list, 1);
            //DrawGraph(zedGraphControl_YZ, two, 2);
            //DrawGraph(zedGraphControl_XZ, vert, 3);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //если зажат cntrl то на перетаскивание точки
            // Перемещать точки можно будет с помощью средней кнопки мыши...
            zedGraphControl_XY.EditButtons = MouseButtons.Left;
            zedGraphControl_YZ.EditButtons = MouseButtons.Left;
            zedGraphControl_XZ.EditButtons = MouseButtons.Left;

            // ... и при нажатой клавише Ctrl.
            zedGraphControl_XY.EditModifierKeys = Keys.Control;
            zedGraphControl_YZ.EditModifierKeys = Keys.Control;
            zedGraphControl_XZ.EditModifierKeys = Keys.Control;

            // Точки можно перемещать, как по горизонтали,...
            zedGraphControl_XY.IsEnableHEdit = true;
            zedGraphControl_YZ.IsEnableHEdit = true;
            zedGraphControl_XZ.IsEnableHEdit = true;

            // ... так и по вертикали.
            zedGraphControl_XY.IsEnableVEdit = true;
            zedGraphControl_XZ.IsEnableVEdit = true;
            zedGraphControl_YZ.IsEnableVEdit = true;

            // Подпишемся на событие, вызываемое после перемещения точки
            zedGraphControl_XY.PointEditEvent += new ZedGraphControl.PointEditHandler(zedGraphXY_PointEditEvent);
            zedGraphControl_XZ.PointEditEvent += new ZedGraphControl.PointEditHandler(zedGraphXZ_PointEditEvent);
            zedGraphControl_YZ.PointEditEvent += new ZedGraphControl.PointEditHandler(zedGraphYZ_PointEditEvent);

        }

        private string zedGraphYZ_PointEditEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int ipt)
        {
            if (curve.Tag != null && (int)curve.Tag < _pList.Count)
            {
                //_lpointArrYZ[(int)curve.Tag] = new PointD(curve[ipt].X, curve[ipt].Y);
                var tmpOld = _pList[(int)curve.Tag];
                var tmpNew = new PointPair4(tmpOld.X, curve[ipt].Y, curve[ipt].X, tmpOld.T);
                _pList[(int)curve.Tag] = tmpNew;
            }
            

            return "";
        }

        private string zedGraphXZ_PointEditEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int ipt)
        {
            if (curve.Tag != null && (int)curve.Tag < _pList.Count)
            {
                //_lpointArrXZ[(int)curve.Tag] = new PointD(curve[ipt].X, curve[ipt].Y);
                var tmpOld = _pList[(int)curve.Tag];
                var tmpNew = new PointPair4(curve[ipt].X, tmpOld.Y, curve[ipt].Y, tmpOld.T);
                _pList[(int)curve.Tag] = tmpNew;
            }

            return "";
        }

        private string zedGraphXY_PointEditEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int ipt)
        {
            if (curve.Tag != null && (int)curve.Tag < _pList.Count)
            {
                //_lpointArrXY[(int)curve.Tag] = new PointD(curve[ipt].X, curve[ipt].Y);
                var tmpOld = _pList[(int) curve.Tag];
                var tmpNew = new PointPair4(curve[ipt].X, curve[ipt].Y, tmpOld.Z, tmpOld.T);
                _pList[(int) curve.Tag] = tmpNew;
            }
            

            return "";
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            _activSetPoint = false;
            roundButton2_Click(null, null);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _activSetPoint = e.KeyValue == 17;
        }

        private bool state = false;
        /// <summary>
        /// Подключить цвет
        /// </summary>
        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked)
                state = true;
            else state = false;

        }



    }
}
