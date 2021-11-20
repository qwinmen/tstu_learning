using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
//ООП Лаб-2 Paint 6 фигур и ластик
namespace Ganza
{
    public partial class FormGanza : Form
    {
        public FormGanza()
        {
            InitializeComponent();

            toolTipForBtn.SetToolTip(btnPen,"Карандаш");
            toolTipForBtn.SetToolTip(btnBrush, "Кисть");
            toolTipForBtn.SetToolTip(btnRectangle, "Прямоугольник");
            toolTipForBtn.SetToolTip(btnLine, "Линия");
            toolTipForBtn.SetToolTip(btnElipsise, "Эллипсис");
            toolTipForBtn.SetToolTip(btnRoundRectangle, "Скругленный прямоугольник");
            toolTipForBtn.SetToolTip(btnPolyGon, "Многоугольник");
            toolTipForBtn.SetToolTip(btnSterka, "Ластик");
            toolTipForBtn.SetToolTip(btnTriangle, "Триугольник");

            _drawableObject = new Karandash();
            StartPosition = FormStartPosition.CenterScreen;

            _bufferedGraphicsContext = BufferedGraphicsManager.Current;
            InitializeGraphics();
        }
        
        private int _key;
        private Color _colorColorSelector = Color.Black;
        private Point _movePoint, _downPoint;//конечные координаты X-Y//начальные координаты Х-Y
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _movePoint = e.Location;
                
                if (_drawableObject is Line)
                {//отрисовка линии
                    Line line = (Line)_drawableObject;
                    line.Begin = _downPoint;
                    line.End = _movePoint;
                    line._Pen = new Pen(_colorColorSelector, trackBarForPenSize.Value);
                }
                else if (_drawableObject is Rect)
                {//отрисовка прямоугольника
                    Rect rect = (Rect)_drawableObject;
                    rect._Pen = new Pen(_colorColorSelector, trackBarForPenSize.Value);
                    rect.State = _state;//true на заливку фигуры
                    int width, height, x, y;
                    //КООРДИНАТНЫЕ ОБЛАСТИ:
                    if (_movePoint.X > _downPoint.X)
                    {
                        width = _movePoint.X - _downPoint.X;
                        x = _downPoint.X;
                    }
                    else
                    {
                        width = _downPoint.X - _movePoint.X;
                        x = _movePoint.X;
                    }
                    if (_movePoint.Y > _downPoint.Y)
                    {
                        height = _movePoint.Y - _downPoint.Y;
                        y = _downPoint.Y;
                    }
                    else
                    {
                        height = _downPoint.Y - _movePoint.Y;
                        y = _movePoint.Y;
                    }
                    //отрисовка
                    rect.Rectangle = new Rectangle(x, y, width, height);
                }
                else if (_drawableObject is Karandash)
                {//отрисовка карандаш\кисть\ластик
                    Karandash karandash = (Karandash)_drawableObject;
                    if (_key != 7) karandash._Pen = new Pen(_colorColorSelector, trackBarForPenSize.Value);
                    else karandash._Pen = new Pen(Color.White, trackBarForPenSize.Value);//ластик
                    karandash.Begin = _downPoint;
                    karandash.End = _movePoint;
                    _drawableObject.Draw(_bmpGraphics);//Запись в буфер перед обновлением холста
                    _downPoint = _movePoint; //начало=конец
                }
                else if (_drawableObject is Elipsise)
                {//отрисовка элипсиса
                    Elipsise elipsise = (Elipsise) _drawableObject;
                    elipsise._Pen = new Pen(_colorColorSelector, trackBarForPenSize.Value);
                    elipsise.State = _state;
                    elipsise.Begin = _movePoint;
                    elipsise.End = _downPoint;
                }
                else if (_drawableObject is RoundRectangle)
                {//отрисовка прямоугольника со скруглеными углами
                    RoundRectangle rect = (RoundRectangle)_drawableObject;
                    rect._Pen = new Pen(_colorColorSelector, trackBarForPenSize.Value);
                    rect.State = _state;
                    int width, height, x, y;
                    //КООРДИНАТНЫЕ ОБЛАСТИ:
                    if (_movePoint.X > _downPoint.X)
                    {
                        width = _movePoint.X - _downPoint.X;
                        x = _downPoint.X;
                    }
                    else
                    {
                        width = _downPoint.X - _movePoint.X;
                        x = _movePoint.X;
                    }
                    if (_movePoint.Y > _downPoint.Y)
                    {
                        height = _movePoint.Y - _downPoint.Y;
                        y = _downPoint.Y;
                    }
                    else
                    {
                        height = _downPoint.Y - _movePoint.Y;
                        y = _movePoint.Y;
                    }
                    //отрисовка
                    rect.Rectangle = new Rectangle(x, y, width, height);
                }
                if (_drawableObject is PolyGon)
                {//Многоугольник
                    PolyGon polyGon = (PolyGon)_drawableObject;
                    polyGon._Pen = new Pen(_colorColorSelector, trackBarForPenSize.Value);
                    polyGon.Begin = _pointMouseUp;
                    /*ПКМ - бросаем начальную точку
                      ЛКМ - конечная точка линии*/
                    polyGon.End = _movePoint;
                }
                if (_drawableObject is Triangle)
                {//Триугольник
                    Triangle triangle = (Triangle)_drawableObject;
                    triangle.Triangles.Clear();
                    GraphicsPath gp = new GraphicsPath();
                    gp.AddPolygon(Vertexes);
                    
                    triangle._Pen = new Pen(_colorColorSelector, trackBarForPenSize.Value);
                    triangle.State = _state;

                    Vertexes[0] = _downPoint;//Запоминаем первую точку
                    Vertexes[1] = e.Location;//Запоминаем вторую вершину
                    Vertexes[2] = GetThirdVertex(_downPoint, e.Location);//Считаем третью вершину

                    triangle.Triangles.Add(gp);
                }
                DrawToBuffer();//На обновление холста
            }//end if(btn.Left)
        }//end void

        DrawMode _drawMode;
        private Point _pointMouseUp;
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _pointMouseUp = e.Location;//для полигона
            switch (_drawMode)
            {//запись изменений в буфер холста
                case DrawMode.Normal:
                    if (_drawableObject != null)
                        _drawableObject.Draw(_bmpGraphics);
                    
                    break;
            }
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {//начальные координаты
            //Включаем режим рисования
            _downPoint = e.Location;
        }
        
        private void colorSelect_ForegroundColorChanged(object sender, EventArgs e)
        {//Верхний цвет выбран
            _colorColorSelector = colorSelect.ForegroundColor;
        }

        private void colorSelect_BackgroundColorChanged(object sender, EventArgs e)
        {//Нижний цвет выбран
            _colorColorSelector = colorSelect.BackgroundColor;
        }

        private void btnPen_Click(object sender, EventArgs e)
        {//Выбран один из элементов рисования
            _key = 0;
            int k = Convert.ToInt32((sender as Button).TabIndex);
            switch (k)
            {
                case 0://btnPen
                    _drawableObject = new Karandash();
                    break;
                case 1://btnBrush
                    _drawableObject = new Karandash();
                    break;
                case 2://btnRectangle
                    _drawableObject = new Rect();
                    break;
                case 3://btnLine
                    _drawableObject = new Line();
                    break;
                case 4://btnElipsise
                    _drawableObject = new Elipsise();
                    break;
                case 5://btnRoundRectangle
                    _drawableObject = new RoundRectangle();
                    break;
                case 6://btnPolyGon
                    _key = 1;
                    _drawableObject = new PolyGon();
                    break;
                case 7://btnSterka
                    _key = 7;
                    _drawableObject = new Karandash();
                    break;
                case 8://btnTriangle
                    _key = 8;
                    _drawableObject = new Triangle();
                    break;
            }
        }
        
        private void pictureBoxHolst_Paint(object sender, PaintEventArgs e)
        {
            DrawToBuffer();
        }

        private BufferedGraphics _bufferedGraphics;
        private Shape _drawableObject;
        Bitmap _bitmap;
        private void DrawToBuffer()
        {
            _bufferedGraphics.Graphics.Clear(Color.White);//фон

            if (_drawableObject != null)
                _drawableObject.Draw(_bufferedGraphics.Graphics);

            _bufferedGraphics.Graphics.DrawImageUnscaled(_bitmap, 0, 0);//_canvasRect.X, _canvasRect.Y, _canvasRect.Width, _canvasRect.Height);
            
            _bufferedGraphics.Render();//Обновление холста
        }

        private Rectangle _canvasRect;//Область для рисования
        private Graphics _gr, _bmpGraphics;
        private readonly BufferedGraphicsContext _bufferedGraphicsContext;
        private void InitializeGraphics()
        {
            _canvasRect = new Rectangle(0, 0, pictureBoxHolst.Width, pictureBoxHolst.Height);//холст размер квадрата
            _gr = pictureBoxHolst.CreateGraphics();
            _bufferedGraphics = _bufferedGraphicsContext.Allocate(_gr, _canvasRect);

            Bitmap prevBmp = null;
            if (_bitmap != null)
                prevBmp = _bitmap;

            _bitmap = new Bitmap(ClientSize.Width+1, ClientSize.Height+1);
            _bmpGraphics = Graphics.FromImage(_bitmap);
            
            if (prevBmp != null)
                _bmpGraphics.DrawImage(prevBmp, 0, 0, prevBmp.Width, prevBmp.Height);
        }

        private void FormGanza_Resize(object sender, EventArgs e)
        {
            pictureBoxHolst.Update();
            InitializeGraphics();
        }


        #region -----Triangle-------Vertex--------- 
        PointF[] Vertexes = new PointF[3];//Координаты вершин треугольника
        private PointF GetThirdVertex(PointF FirstVertex, PointF SecondVertex)
        {
            //Угол наклона прямой, образованной известными вершинами
            double alpha = Math.Atan((FirstVertex.Y - SecondVertex.Y) / (FirstVertex.X - SecondVertex.X));
            /* k13 - коэффициент наклона прямой, проходящей через первую и третью вершину;
             * k23 - коэффициент наклона прямой, проходящей через вторую и третью вершину;*/
            double k13 = 0, k23 = 0;
            float x, y;
            //Вычисление угловых коэффициентов в зависимости от угла наклона первой стороны
            if (FirstVertex.Y > SecondVertex.Y)
            {
                k13 = Math.Tan(alpha - 2 * Math.PI / 3);
                k23 = Math.Tan(alpha - Math.PI / 3);
            }
            else if (FirstVertex.Y <= SecondVertex.Y)
            {
                k13 = Math.Tan(alpha + Math.PI / 3);
                k23 = Math.Tan(alpha + 2 * Math.PI / 3);
            }
            //Координата X третьей вершины
            x = (float)((k13 * FirstVertex.X - k23 * SecondVertex.X + SecondVertex.Y - FirstVertex.Y) / (k13 - k23));
            //Координата Y третьей вершины
            y = (float)(k13 * (x - FirstVertex.X) + FirstVertex.Y);

            return new PointF(x, y);
        }
        #endregion

        private void trackBarForPenSize_MouseUp(object sender, MouseEventArgs e)
        {//Изменение размера кисти выводим на btnSterka
            btnSterka.Text = trackBarForPenSize.Value.ToString();
        }

        private bool _state;
        private void checkBoxForFill_CheckStateChanged(object sender, EventArgs e)
        {//на заливку фигуры
            _state = checkBoxForFill.Checked;
        }

        

        










    
    }
}
