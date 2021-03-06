using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO; 						//streamer io
using System.Runtime.Serialization;     // io
using System.Runtime.Serialization.Formatters.Binary; // io
using System.Drawing.Printing;


namespace WindowsApplication1
{

    public partial class vectShapes :  UserControl
    {
        private string Status;
        public string Option;
        private string redimStatus = "";

        private string msg = "";
        [CategoryAttribute("Debug"), DescriptionAttribute("ShowDebugInfo")]
        public bool ShowDebug { get; set; }


        private int startX;
        private int startY;
        private Shapes s;

        private float _Zoom = 1;
        private bool _A4 = true;

        private int _dx = 0;
        private int _dy = 0;
        private int startDX = 0;
        private int startDY = 0;
        private int truestartX = 0;
        private int truestartY = 0;

        //PEN TOOL START
        private ArrayList VisPenPointList;
        private ArrayList PenPointList;
        private int PenPrecX;
        private int PenPrecY;
        //PEN TOOL END

        private Bitmap offScreenBmp;
        private Bitmap offScreenBackBmp;

        // Grid
        public int _gridSize=0;
        public bool fit2grid=true;

        //Graphic
        private System.Drawing.Drawing2D.CompositingQuality _CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
        private System.Drawing.Text.TextRenderingHint _TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        private System.Drawing.Drawing2D.SmoothingMode _SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        private System.Drawing.Drawing2D.InterpolationMode _InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;

        // Drawing Rect
        private bool MouseSx;
        private int tempX;
        private int tempY;

        // Preview & print
       // private Anteprima AnteprimaFrm;

        // richTextBoxEditForm
       // private richForm2 editorFrm;

        public RichTextBox r;

        public Color CreationPenColor;
        public float CreationPenWidth;
        public Color CreationFillColor;
        public bool CreationFilled;

        //public PropertyGrid propGrid;

        //EVENT
        public event OptionChanged optionChanged ;
        public event ObjectSelected objectSelected;

        //Image1.tif
        Cursor AddPointCur = getCursor("newPoint3.cur", Cursors.Cross);
        Cursor DelPointCur = getCursor("delPoint3.cur", Cursors.Default);
        // Gets he *.cur file in a. 
        public static Cursor getCursor(string a, Cursor defCur)
        {
            try
            {
                return new Cursor(a);
            }
            catch
            {
                return defCur;
            }
        }

        public vectShapes()
        {
            InitializeComponent();
            myInit();

            

            //from Ilango.M 
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true); // added line

        }

        //Graphic
        [CategoryAttribute("Graphics"), DescriptionAttribute("Interp.Mode")]
        public System.Drawing.Drawing2D.InterpolationMode InterpolationMode
        {
            get
            {
                return _InterpolationMode;
            }
            set
            {
                _InterpolationMode = value;
            }
        }


        [CategoryAttribute("Graphics"), DescriptionAttribute("Smooth.Mode")]
        public System.Drawing.Drawing2D.SmoothingMode SmoothingMode
        {
            get
            {
                return _SmoothingMode;
            }
            set
            {
                _SmoothingMode = value;
            }
        }

        [CategoryAttribute("Graphics"), DescriptionAttribute("Txt.Rend.Hint")]
        public System.Drawing.Text.TextRenderingHint TextRenderingHint
        {
            get
            {
                return _TextRenderingHint;
            }
            set
            {
                _TextRenderingHint = value;
            }
        }

        [CategoryAttribute("Graphics"), DescriptionAttribute("Comp.Quality")]
        public System.Drawing.Drawing2D.CompositingQuality CompositingQuality
        {
            get
            {
                return _CompositingQuality;
            }
            set
            {
                _CompositingQuality = value;
            }
        }



        [CategoryAttribute(" "), DescriptionAttribute("Canvas")]
        public string ObjectType
        {
            get
            {
                return "Canvas";
            }
        }
        
        [CategoryAttribute("  "), DescriptionAttribute("Grid Size")]
        public int gridSize
        {
            get
            {
                return _gridSize;
            }
            set
            {
                if (value >= 0)
                {
                    _gridSize = value;
                }
                if (_gridSize > 0)
                {
                    this.dx = _gridSize * (int)(this.dx / _gridSize);
                    this.dy = _gridSize * (int)(this.dy / _gridSize);
                }
                this.redraw(true);
            }
        }

        //??? ? ????????
        [CategoryAttribute("  "), DescriptionAttribute("Canvas Zoom")]
        public float Zoom
        {
            get
            {
                return _Zoom;
            }
            set
            {
                if (value > 0)
                {
                    _Zoom = value;
                    this.redraw(true);
                }
                else
                {
                    _Zoom = 1;
                    this.redraw(true);
                }
            }
        }


        [CategoryAttribute("  "), DescriptionAttribute("Show A4")]
        public bool A4
        {
            get
            {
                return _A4;
            }
            set
            {
                 _A4 = value;
            }
        }

        [CategoryAttribute("  "), DescriptionAttribute("Canvas OriginX")]
        public int dx
        {
            get
            {
                return _dx;
            }
            set
            {
                    _dx = value;
            }
        }

        [CategoryAttribute("  "), DescriptionAttribute("Canvas OriginY")]
        public int dy
        {
            get
            {
                return _dy;
            }
            set
            {
                _dy = value;
            }
        }

/*        
        public void zoomIn()
        {
            this.Zoom = (int)(this.Zoom + 1);
        }
/*
        public void zoomOut()
        {
            if (this.Zoom > 1)
            {
                this.Zoom = (int)(this.Zoom - 1);
            }
        }
*/
        public void mergePolygons()
        {
            s.mergePolygons();
            redraw(true);
        }
        public void delPoints()
        {
            this.s.delPoint();
            redraw(true);
        }
/*
        public void linkNodes()
        {
            this.s.linkNodes();
            redraw(true);
        }

/*        public void delNodes()
        {
            this.s.delNodes();
            redraw(true);
        }
*/

        public void extPoints()
        {
            this.s.extPoints();
            redraw(true);
        }


        public void XMirror()
        {
            this.s.XMirror();
            redraw(true);
        }
        public void YMirror()
        {
            this.s.YMirror();
            redraw(true);
        }
        public void Mirror()
        {
            this.s.Mirror();
            redraw(true);
        }



        private void myInit()
        { 
            //Status = "";
            changeStatus("");
            Option = "select";

            Graphics g = this.CreateGraphics();

            //retrive printer resolution
            PrintDocument pd = new PrintDocument();            
            //MessageBox.Show( pd.PrinterSettings.DefaultPageSettings.PrinterResolution.X.ToString() );
            //MessageBox.Show(pd.PrinterSettings.DefaultPageSettings.PrinterResolution.Y.ToString() );
           // Graphics g_pr = pd.PrinterSettings.CreateMeasurementGraphics();
            SizeF sizef;
            float x_pr, y_pr = 0;

           // sizef = g_pr.MeasureString("YourStringHere", Font);
            //x_pr = sizef.Width;
            //y_pr = sizef.Height;
            //y_pr = Font.Height;

            float x_vi, y_vi = 0;

            sizef = g.MeasureString("YourStringHere", Font);
            x_vi = sizef.Width;
            y_vi = sizef.Height; 




            //s = new Shapes((pd.PrinterSettings.DefaultPageSettings.PrinterResolution.X / g.DpiX), pd.PrinterSettings.DefaultPageSettings.PrinterResolution.Y);
            s = new Shapes(g.DpiX  , g.DpiY * (y_pr / y_vi));

//            undoB = new UndoBuffer(5);
            g.Dispose();

           // editorFrm = new richForm2();
          //  this.r = editorFrm.richTextBox1;

            CreationPenColor=Color.Black;
            CreationPenWidth=1f;
            CreationFillColor=Color.Black;
            CreationFilled=false;

            this.optionChanged += new OptionChanged(FakeOptionChange);
            this.objectSelected += new ObjectSelected(FakeObjectSelected);

            offScreenBackBmp = new Bitmap(this.Width, this.Height);
            offScreenBmp = new Bitmap(this.Width, this.Height);
        }

        private void FakeOptionChange(object sender, OptionEventArgs e)
        { }

        private void FakeObjectSelected(object sender, PropertyEventArgs e)
        { }


        private void changeStatus(string s)
        {
            this.Status = s;            
        }

        private void changeOption(string s)
        {
            this.Option = s;
            // Notify Option change to "listening object" (i.e: toolBbox)
            OptionEventArgs e = new OptionEventArgs(this.Option);
            optionChanged(this, e);// raise event
        }
/*
        public void anteprimaStampa(float zoom)
        {
            InitializePrintPreviewControl(zoom);
        }
/*
        #region Print & Preview

        public void Stampa()
        {
            this.s.deSelect();

            AnteprimaFrm = new Anteprima();
            AnteprimaFrm.PrintPreviewControl1.Name = "PrintPreviewControl1";
            AnteprimaFrm.PrintPreviewControl1.Document = AnteprimaFrm.docToPrint;

            AnteprimaFrm.PrintPreviewControl1.Zoom = 1;

            AnteprimaFrm.PrintPreviewControl1.Document.DocumentName = "Anteprima";

            AnteprimaFrm.PrintPreviewControl1.UseAntiAlias = true;

            AnteprimaFrm.docToPrint.PrintPage +=
                new System.Drawing.Printing.PrintPageEventHandler(
                docToPrint_PrintPage);

            // Per stampare
            AnteprimaFrm.docToPrint.Print();

            AnteprimaFrm.Dispose();

        }

        private void InitializePrintPreviewControl(float zoom   )
        {
            this.s.deSelect();

            AnteprimaFrm = new Anteprima();
            // Construct the PrintPreviewControl.
            //AnteprimaFrm.PrintPreviewControl1 = new PrintPreviewControl();

            // Set location, name, and dock style for PrintPreviewControl1.
            //AnteprimaFrm.PrintPreviewControl1.Location = new Point(88, 80);
            AnteprimaFrm.PrintPreviewControl1.Name = "Preview";
            //AnteprimaFrm.PrintPreviewControl1.Dock = DockStyle.Fill;

            // da testare??
            //AnteprimaFrm.PrintPreviewControl1.BackColor = this.BackColor;
            //AnteprimaFrm.PrintPreviewControl1.BackgroundImage = this.BackgroundImage;


            // Set the Document property to the PrintDocument 
            // for which the PrintPage event has been handled.
            AnteprimaFrm.PrintPreviewControl1.Document = AnteprimaFrm.docToPrint;

            // Set the zoom to 25 percent.
            AnteprimaFrm.PrintPreviewControl1.Zoom = zoom;

            // Set the document name. This will show be displayed when 
            // the document is loading into the control.
            AnteprimaFrm.PrintPreviewControl1.Document.DocumentName = "Preview";

            // Set the UseAntiAlias property to true so fonts are smoothed
            // by the operating system.
            AnteprimaFrm.PrintPreviewControl1.UseAntiAlias = true;

            // Add the control to the form.
            //AnteprimaFrm.Controls.Add(AnteprimaFrm.PrintPreviewControl1);

            // Associate the event-handling method with the
            // document's PrintPage event.
            AnteprimaFrm.docToPrint.PrintPage +=
                new System.Drawing.Printing.PrintPageEventHandler(
                docToPrint_PrintPage);

            // Per stampare
            //AnteprimaFrm.docToPrint.Print();
            AnteprimaFrm.ShowDialog();
        }

        // The PrintPreviewControl will display the document
        // by handling the documents PrintPage event
        private void docToPrint_PrintPage(
            object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            // Insert code to render the page here.
            // This code will be called when the control is drawn.

            // The following code will render a simple
            // message on the document in the control.
            //string text = "In docToPrint_PrintPage method.";
            //System.Drawing.Font printFont =
            //    new Font("Arial", 35, FontStyle.Regular);
            //  e.Graphics.DrawString(text, printFont,
            //      Brushes.Black, 10, 10);



            Graphics g = e.Graphics;




            //Do Double Buffering
            //Bitmap offScreenBmp;
            // Graphics offScreenDC;
            //offScreenBmp = new Bitmap(this.Width, this.Height);
            //
            //offScreenDC = Graphics.FromImage(offScreenBmp);

            //offScreenDC.Clear(this.BackColor);

            //background image
            //if ((this.loadImage) & (this.visibleImage))
            //    offScreenDC.DrawImage(this.loadImg, 0, 0);
            //

            //offScreenDC.SmoothingMode=SmoothingMode.AntiAlias;
            
            // test
            //MessageBox.Show("dipx : " + g.DpiX + " ; dipy : " + g.DpiY);

            //s.Draw(offScreenDC);
            if (this.BackgroundImage != null)
                g.DrawImage(this.BackgroundImage, 0, 0);

            //TEST !!!!!!!!!!!!!!!!!!!!!!!!!!!1
            //this.DrawMesure(g);

            s.Draw(g,0,0,1);
            
            //if (this.MouseSx)
            //{
            //    System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
            //    offScreenDC.DrawRectangle(myPen, new Rectangle(this.startX, this.startY, tmpX - this.startX, tmpY - this.startY));
            //    myPen.Dispose();
            //}

            //g.DrawImageUnscaled(offScreenBmp, 0, 0);

            g.Dispose();
        }


        #endregion
*/


        public bool UndoEnabled()
        {
            return this.s.UndoEnabled();
        }

        public bool RedoEnabled()
        {
            return this.s.RedoEnabled();
        }

        public void Undo()
        {
           // this.s = this.undoB.Undo();
           // this.redraw();
            this.s.Undo();
            this.s.deSelect();
            this.redraw(true);
        }

        public void Redo()
        {
            this.s.Redo();
            this.s.deSelect();
            this.redraw(true);
        }


        #region SELECTED SHAPE COMMANDS

        public void setPenColor(Color c)
        {
            CreationPenColor = c;
            if (s.selEle != null)
            {
                this.s.selEle.penColor = c;
            }            
        }

        public void setFillColor(Color c)
        {
            CreationFillColor = c;
            if (s.selEle != null)
            {
                this.s.selEle.fillColor = c;
            }
        }

        public void setFilled(bool f)
        {
            CreationFilled = f;
            if (s.selEle != null)
            {
                this.s.selEle.filled = f;
            }
        }

        public void setPenWidth(float f)
        {
            CreationPenWidth = f;
            if (s.selEle != null)
            {
                this.s.selEle.penWidth = f;
            }
        }
        
  

        public void groupSelected()
        {            
            this.s.groupSelected();

            // show properties
            PropertyEventArgs e1 = new PropertyEventArgs(this.s.getSelectedArray(), this.s.RedoEnabled(), this.s.UndoEnabled());
            objectSelected(this, e1);// raise event


            redraw(true);
        }


        public void deGroupSelected()
        {
            this.s.deGroupSelected();
            // show properties
            PropertyEventArgs e1 = new PropertyEventArgs(this.s.getSelectedArray(), this.s.RedoEnabled(), this.s.UndoEnabled());
            objectSelected(this, e1);// raise event

            redraw(true);
        }

        

        public void rmSelected()
        {
            
            this.s.rmSelected();
            redraw(true);
        }

        //Test
        public void cpSelected()
        {
            //this.s.CopySelected(30, 20);
            this.s.CopyMultiSelected(25, 15);
            redraw(true);
        }
/*
        public void primoPiano()
        {
            this.s.primoPiano();
            redraw(true);
        }
/*
        public void secondoPiano()
        {
            this.s.secondoPiano();
            redraw(true);
        }
*/
        #endregion

        #region LOAD/SAVE
/*
        public bool Loader()
        {
            try
            {
                Stream StreamRead;
                OpenFileDialog DialogueCharger = new OpenFileDialog();
                DialogueCharger.DefaultExt = "shape";
                DialogueCharger.Title = "Load shape";
                DialogueCharger.Filter = "frame files (*.shape)|*.shape|All files (*.*)|*.*";
                if (DialogueCharger.ShowDialog() == DialogResult.OK)
                {
                    if ((StreamRead = DialogueCharger.OpenFile()) != null)
                    {
                        BinaryFormatter BinaryRead = new BinaryFormatter();
                        this.s = (Shapes) BinaryRead.Deserialize(StreamRead);
                        //g_l = (ExtGrpLst)BinaryRead.Deserialize(StreamRead);
                        StreamRead.Close();

                        this.s.afterLoad();

                        this.redraw(true);
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception:" + e.ToString(), "Load error:");
            }
            return false;
        }
/*
        public bool Saver()
        {
            try
            {
                Stream StreamWrite;
                SaveFileDialog DialogueSauver = new SaveFileDialog();
                DialogueSauver.DefaultExt = "shape";
                DialogueSauver.Title = "Save as shape";
                DialogueSauver.Filter = "shape files (*.shape)|*.shape|All files (*.*)|*.*";
                if (DialogueSauver.ShowDialog() == DialogResult.OK)
                {
                    if ((StreamWrite = DialogueSauver.OpenFile()) != null)
                    {
                        BinaryFormatter BinaryWrite = new BinaryFormatter();
                        BinaryWrite.Serialize(StreamWrite, this.s);
                        StreamWrite.Close();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception:" + e.ToString(), "Save error:");
            }
            return false;
        }
/*
        public bool SaveSelected()
        {
            ArrayList a = this.s.getSelectedList();
            if ((a!=null)&&(a.Count >0 ))
            {
                try
                {
                    Stream StreamWrite;
                    SaveFileDialog DialogueSauver = new SaveFileDialog();
                    DialogueSauver.DefaultExt = "sobj";
                    DialogueSauver.Title = "Save as sobj";
                    DialogueSauver.Filter = "sobj files (*.sobj)|*.sobj|All files (*.*)|*.*";
                    if (DialogueSauver.ShowDialog() == DialogResult.OK)
                    {
                        if ((StreamWrite = DialogueSauver.OpenFile()) != null)
                        {
                            BinaryFormatter BinaryWrite = new BinaryFormatter();
                            BinaryWrite.Serialize(StreamWrite, a);
                            StreamWrite.Close();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception:" + e.ToString(), "Save error:");
                }             
            }
            return false;
        }
*/
/*        public bool LoadObj()
        {
            try
            {
                Stream StreamRead;
                OpenFileDialog DialogueCharger = new OpenFileDialog();
                DialogueCharger.DefaultExt = "sobj";
                DialogueCharger.Title = "Load sobj";
                DialogueCharger.Filter = "frame files (*.sobj)|*.sobj|All files (*.*)|*.*";
                if (DialogueCharger.ShowDialog() == DialogResult.OK)
                {
                    if ((StreamRead = DialogueCharger.OpenFile()) != null)
                    {
                        BinaryFormatter BinaryRead = new BinaryFormatter();
                        ArrayList a = (ArrayList)BinaryRead.Deserialize(StreamRead);
                        //this.s = (ArrayList)BinaryRead.Deserialize(StreamRead);
                        this.s.setList(a);
                        StreamRead.Close();
                        this.s.afterLoad();
                        this.redraw(true);
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception:" + e.ToString(), "Load error:");
            }
            return false;
        }
*/

        #endregion

        #region IMG LOADER
        
        public string imgLoader()
        {
            try
            {
                OpenFileDialog DialogueCharger = new OpenFileDialog();
                DialogueCharger.Title = "Load background image";
                DialogueCharger.Filter = "jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
                //DialogueCharger.DefaultExt = "frame";
                if (DialogueCharger.ShowDialog() == DialogResult.OK)
                {
                    return (DialogueCharger.FileName);
                }
            }
            catch { }
            return null;
        }
        
        #endregion  

   
        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            // from Ilango.M
            //this.redraw(false);
            this.redraw(e.Graphics, false); 
        }

        #region DRAWING



        private void redraw_OLD()
        {
            Graphics g = this.CreateGraphics();
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            //Do Double Buffering
            Graphics offScreenDC;
            //offScreenBmp = new Bitmap(this.Width, this.Height);
            //
            offScreenDC = Graphics.FromImage(offScreenBmp);

            offScreenDC.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            offScreenDC.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            offScreenDC.Clear(this.BackColor);

            if (this.BackgroundImage != null)
                offScreenDC.DrawImage(this.BackgroundImage, 0, 0);

            // Visualizzazione Griglia
            if (this.gridSize > 0)
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.LightGray);
                int nX = this.Width / this.gridSize;
                for (int i = 0; i <= nX; i++)
                {
                    offScreenDC.DrawLine(myPen, i * this.gridSize, 0, i * this.gridSize, this.Height);
                }
                int nY = this.Height / this.gridSize;
                for (int i = 0; i <= nY; i++)
                {
                    offScreenDC.DrawLine(myPen, 0, i * this.gridSize, this.Width, i * this.gridSize);
                }
                myPen.Dispose();
            }

            // Disegna tutti gli oggetti
            s.Draw(offScreenDC,0,0,1);

            //Draw Red creation Rect/Line
            if (this.MouseSx & this.Status=="drawrect")
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red,1.5f);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                myPen.StartCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
                //myPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

                if (this.Option == "LI")
                {
                    offScreenDC.DrawLine(myPen, startX,startY,tempX,tempY);                    
                }
                else
                {                    
                    offScreenDC.DrawRectangle(myPen, new Rectangle(this.startX, this.startY, tempX - this.startX, tempY - this.startY));                    
                }
                myPen.Dispose();
            }


            //Draw selection Rect
            if (this.MouseSx & this.Status=="selrect") 
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Green, 1.5f);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                offScreenDC.DrawRectangle(myPen, new Rectangle(this.startX, this.startY, tempX - this.startX, tempY - this.startY));
                myPen.Dispose();
            }


            g.DrawImageUnscaled(offScreenBmp, 0, 0);

            offScreenDC.Dispose();
            g.Dispose();

        }


        private void GraphicSetUp(Graphics g)
        {
            g.CompositingQuality = this.CompositingQuality;
            g.TextRenderingHint = this.TextRenderingHint;
            g.SmoothingMode = this.SmoothingMode;
            g.InterpolationMode = this.InterpolationMode;
            //g.PageUnit = GraphicsUnit.Millimeter;
        }

        /// <summary>
        /// Testing save to *bmp
        /// </summary>
        public void saveBmp()
        {
            offScreenBackBmp.Save("test.bmp");
        }

        /// <summary>
        /// redraws this.s on this control
        /// All=true : redraw all graphic
        /// All=false : redraw only selected objects
        /// </summary>
        public void redraw( bool All)
        {

            /*
            int startTime = System.DateTime.Now.Second * 10000 + System.DateTime.Now.Millisecond;
            System.Console.WriteLine("startTime:  {0}", startTime.ToString());
            */

            //All=true : redraw all graphic
            //All=false : redraw only selected objects
            //TEST
            if (fit2grid & this.gridSize > 0)
            {
                this.startX = this.gridSize * (int)(startX / this.gridSize);
                this.startY = this.gridSize * (int)(startY / this.gridSize);
            }


            Graphics g = this.CreateGraphics();

            //g.ScaleTransform(Zoom, Zoom);           
            //g.TranslateTransform(this.dx, this.dy);
            this.GraphicSetUp(g);
            //g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            

            if (All)
            {
                // Redraw static objects
                // in the back Layer 
                Graphics backG;
                backG = Graphics.FromImage(offScreenBackBmp);
                this.GraphicSetUp(backG);
                //backG.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                //backG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                backG.Clear(this.BackColor);

                if (this.BackgroundImage != null)
                    backG.DrawImage(this.BackgroundImage, 0, 0);

                // Render the grid
                if (this.gridSize > 0)
                {
                    System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.LightGray);
                    int nX = (int)(this.Width / (this.gridSize * Zoom));
                    for (int i = 0; i <= nX; i++)
                    {
                        backG.DrawLine(myPen, i * this.gridSize * Zoom, 0, i * this.gridSize * Zoom, this.Height);
                    }
                    int nY = (int)(this.Height / (this.gridSize * Zoom));
                    for (int i = 0; i <= nY; i++)
                    {
                        backG.DrawLine(myPen, 0, i * this.gridSize * Zoom, this.Width, i * this.gridSize * Zoom);
                    }
                    myPen.Dispose();
                }

                // Draws unselected objects
                s.DrawUnselected(backG,this.dx,this.dy,this.Zoom);

                backG.Dispose();
            }

            //Do Double Buffering
            Graphics offScreenDC;
            offScreenDC = Graphics.FromImage(offScreenBmp);
            offScreenDC.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            offScreenDC.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            offScreenDC.Clear(this.BackColor);


            // I draw the background image with statics objects
            offScreenDC.DrawImageUnscaled(this.offScreenBackBmp,0,0);

            // Now I draw the dynamic objects on the buffer
            s.DrawSelected(offScreenDC, this.dx, this.dy, this.Zoom);

            //this.DrawMesure(offScreenDC);


            // Now I draw the graphics effects (creation and selection )
            #region Creation/Selection/PenPoimts plus A4 margin
            //Draw Red creation Rect/Line
            if (this.MouseSx & this.Status == "drawrect")
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red, 1.5f);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                myPen.StartCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
                //myPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

                if (this.Option == "LI" || this.Option == "POLY" || this.Option == "GRAPH")
                {
                    offScreenDC.DrawLine(myPen, (startX + this.dx) * this.Zoom, (startY + this.dy) * this.Zoom, (tempX + this.dx) * this.Zoom, (tempY + this.dy) * this.Zoom);
                }
                else
                {
                    offScreenDC.DrawRectangle(myPen, (this.startX + this.dx) * this.Zoom, (this.startY + this.dy) * this.Zoom, (tempX - this.startX) * this.Zoom, (tempY - this.startY) * this.Zoom);
                }
                myPen.Dispose();
            }

            //Draw selection Rect
            if (this.MouseSx & this.Status == "selrect")
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Green, 1.5f);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                offScreenDC.DrawRectangle(myPen, (this.startX + this.dx) * this.Zoom, (this.startY + this.dy) * this.Zoom, (tempX - this.startX) * this.Zoom, (tempY - this.startY) * this.Zoom);
                myPen.Dispose();
            }

            this.drawDebugInfo(offScreenDC);

            //Draw A4 margin
            if (this.A4)
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Blue, 0.5f);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                offScreenDC.DrawRectangle(myPen, (1 + this.dx) * this.Zoom, (1 + this.dy) * this.Zoom, 810 * this.Zoom, 1140 * this.Zoom);
                myPen.Dispose();
            }

            //Draw Pen construction shape
            if (PenPointList != null)
            { 
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red, 1.5f);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                myPen.StartCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;

                // To ARRAY
                PointF[] myArr = new PointF[this.VisPenPointList.Count];
                int i = 0;
                foreach (PointWr p in this.VisPenPointList)
                {
                    myArr[i++] = new PointF((startX + p.X + this.dx) * this.Zoom, (startY + p.Y + this.dy) * this.Zoom);// p.point;
                    
                }

                if (myArr.Length > 1)
                    offScreenDC.DrawCurve(myPen, myArr);
            }

            #endregion

            // I draw the buffer on the graphic of my control
            g.DrawImageUnscaled(offScreenBmp, 0, 0);

            offScreenDC.Dispose();


            g.Dispose();

            /*
            int endTime = System.DateTime.Now.Second * 10000 + System.DateTime.Now.Millisecond;
            System.Console.WriteLine("endTime:  {0}", endTime.ToString());
            */
        }



        private void drawDebugInfo(Graphics g)
        {
            //Draw msg
            if (ShowDebug)
            {
             msg = " Status : " + this.Status;
             msg = msg + " Option : " + this.Option;
             msg = msg + " redimStatus : " + this.redimStatus;
             Font tmpf = new System.Drawing.Font("Arial", 7);
             g.DrawString(msg, tmpf, new SolidBrush(Color.Gray), new PointF((tempX + this.dx) * this.Zoom, (tempY + this.dy) * this.Zoom), StringFormat.GenericDefault);
             tmpf.Dispose();
            }
        }


        public void redraw(Graphics g,bool All)
        {

            if (fit2grid & this.gridSize > 0)
            {
                this.startX = this.gridSize * (int)(startX / this.gridSize);
                this.startY = this.gridSize * (int)(startY / this.gridSize);
            }


            //Graphics g = this.CreateGraphics();

            this.GraphicSetUp(g);

            if (All)
            {
                // Redraw static objects
                // in the back Layer 
                Graphics backG;
                backG = Graphics.FromImage(offScreenBackBmp);
                this.GraphicSetUp(backG);
                //backG.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                //backG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                backG.Clear(this.BackColor);

                if (this.BackgroundImage != null)
                    backG.DrawImage(this.BackgroundImage, 0, 0);

                // Render the grid
                if (this.gridSize > 0)
                {
                    System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.LightGray);
                    int nX = (int)(this.Width / (this.gridSize * Zoom));
                    for (int i = 0; i <= nX; i++)
                    {
                        backG.DrawLine(myPen, i * this.gridSize * Zoom, 0, i * this.gridSize * Zoom, this.Height);
                    }
                    int nY = (int)(this.Height / (this.gridSize * Zoom));
                    for (int i = 0; i <= nY; i++)
                    {
                        backG.DrawLine(myPen, 0, i * this.gridSize * Zoom, this.Width, i * this.gridSize * Zoom);
                    }
                    myPen.Dispose();
                }

                // Draws unselected objects
                s.DrawUnselected(backG, this.dx, this.dy, this.Zoom);

                backG.Dispose();
            }

            //Do Double Buffering
            Graphics offScreenDC;
            offScreenDC = Graphics.FromImage(offScreenBmp);
            offScreenDC.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            offScreenDC.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            offScreenDC.Clear(this.BackColor);


            // I draw the background image with statics objects
            offScreenDC.DrawImageUnscaled(this.offScreenBackBmp, 0, 0);

            // Now I draw the dynamic objects on the buffer
            s.DrawSelected(offScreenDC, this.dx, this.dy, this.Zoom);

            //this.DrawMesure(offScreenDC);

            // Now I draw the graphics effects (creation and selection )
            #region Creation/Selection/PenPoimts plus A4 margin
            //Draw Red creation Rect/Line
            if (this.MouseSx & this.Status == "drawrect")
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red, 1.5f);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                myPen.StartCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
                //myPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

                if (this.Option == "LI" || this.Option == "POLY" || this.Option == "GRAPH")
                {
                    offScreenDC.DrawLine(myPen, (startX + this.dx) * this.Zoom, (startY + this.dy) * this.Zoom, (tempX + this.dx) * this.Zoom, (tempY + this.dy) * this.Zoom);
                }
                else
                {
                    offScreenDC.DrawRectangle(myPen, (this.startX + this.dx) * this.Zoom, (this.startY + this.dy) * this.Zoom, (tempX - this.startX) * this.Zoom, (tempY - this.startY) * this.Zoom);
                }
                myPen.Dispose();
            }

            //Draw selection Rect
            if (this.MouseSx & this.Status == "selrect")
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Green, 1.5f);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                offScreenDC.DrawRectangle(myPen, (this.startX + this.dx) * this.Zoom, (this.startY + this.dy) * this.Zoom, (tempX - this.startX) * this.Zoom, (tempY - this.startY) * this.Zoom);
                myPen.Dispose();
            }

            //Draw msg
            this.drawDebugInfo(offScreenDC);

            //Draw A4 margin
            if (this.A4)
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Blue, 0.5f);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                offScreenDC.DrawRectangle(myPen, (1 + this.dx) * this.Zoom, (1 + this.dy) * this.Zoom, 810 * this.Zoom, 1140 * this.Zoom);
                myPen.Dispose();
            }

            //Draw Pen construction shape
            if (PenPointList != null)
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red, 1.5f);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                myPen.StartCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;

                // To ARRAY
                PointF[] myArr = new PointF[this.VisPenPointList.Count];
                int i = 0;
                foreach (PointWr p in this.VisPenPointList)
                {
                    myArr[i++] = new PointF((startX + p.X + this.dx) * this.Zoom, (startY + p.Y + this.dy) * this.Zoom);// p.point;

                }

                if (myArr.Length > 1)
                    offScreenDC.DrawCurve(myPen, myArr);
            }

            #endregion

            // I draw the buffer on the graphic of my control
            g.DrawImageUnscaled(offScreenBmp, 0, 0);

            offScreenDC.Dispose();

            

            //g.Dispose();

        }

        private void DrawMesure(Graphics g)
        {
            /* TEST*/
            GraphicsUnit u = g.PageUnit;
            g.PageUnit = GraphicsUnit.Millimeter;
            
            // draws in millimeters
            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Black, 0.5f);
             g.DrawLine(myPen, 0, 5, 210, 5);
             for (int i = 0; i < 210;i = i + 10 )
             {
                g.DrawLine(myPen, i, 5, i, 0);   
             }
            g.PageUnit = u;
            
        }

        #endregion

        #region MOUSE EVENT MANAGMENT

        private void UserControl1_MouseDown(object sender, MouseEventArgs e)
        {
            this.startX = (int)((e.X) / Zoom - this.dx);
            this.startY = (int)((e.Y) / Zoom - this.dy);
            //this.startX = (int)( e.X- this.dx  );
            //this.startY = (int)( e.Y - this.dy );

            this.truestartX = (int)e.X;
            this.truestartY = (int)e.Y;

            if (e.Button == MouseButtons.Left)
            {
                #region START LEFT MOUSE BUTTON PRESSED
                this.MouseSx = true; // I start pressing SX
                switch (this.Option)
                {
                    case "select":

                        if (this.redimStatus != "")
                        {
                            // I'm over an object or Object redim handle
                            changeStatus("redim");// I'm starting redim/move action
                        }
                        else
                        {
                            // I'm pressing SX in an empty space, I'm starting a select rect
                            changeStatus("selrect");// I'm starting a select rect
                        }

                        break;
                    case "PEN":
                            PenPointList = new ArrayList();//reset pints buffer
                            VisPenPointList = new ArrayList();//reset pints buffer
                            PenPrecX = this.startX;
                            PenPrecY = this.startY;
                            PenPointList.Add(new PointWr(0, 0));
                            VisPenPointList.Add(new PointWr(0, 0));
                        break;
                    default:
                        /* if Option != "select" then I'm going tocreate an object*/
                        //                    this.MouseSx = true; // I start pressing SX
                        changeStatus("drawrect"); //I 'm startring drawing a new object
                        break;
                }
                #endregion
            }
            else
            {
                #region START RIGHT MOUSE BUTTON PRESSED
                this.startDX = this.dx;
                this.startDY = this.dy;
                this.Cursor = Cursors.Cross;
                #endregion
            }
            
        }

        private void UserControl1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            #region left mouse button pressed
            {
                if (this.MouseSx)
                {    
                    tempX = (int)(e.X / Zoom );
                    tempY = (int)(e.Y / Zoom );
                    if (fit2grid & this.gridSize > 0)
                    {
                        tempX = this.gridSize * (int)((e.X / Zoom ) / this.gridSize);
                        tempY = this.gridSize * (int)((e.Y / Zoom ) / this.gridSize);
                    }
                    tempX = tempX - this.dx;
                    tempY = tempY - this.dy;

                }


                if (this.Status == "redim")
                {
                    int tmpX = (int)(e.X / Zoom - this.dx);
                    int tmpY = (int)(e.Y / Zoom - this.dy);
                    int tmpstartX = startX;
                    int tmpstartY = startY;
                    if (fit2grid & this.gridSize > 0)
                    {
                        tmpX = this.gridSize * (int)((e.X / Zoom - this.dx) / this.gridSize);
                        tmpY = this.gridSize * (int)((e.Y / Zoom - this.dy) / this.gridSize);
                        tmpstartX = this.gridSize * (int)(startX / this.gridSize);
                        tmpstartY = this.gridSize * (int)(startY / this.gridSize);
                        s.Fit2grid(this.gridSize);
                        s.sRec.Fit2grid(this.gridSize);
                    }

                    switch (this.redimStatus)
                    {
                        //Poly's point
                        case "POLY":
                            // Move selected
                            if (s.selEle != null & s.sRec != null)
                            {
                                //s.movePoint(tmpstartX - tempX, tmpstartY - tempY);
                                s.movePoint(tmpstartX - tmpX, tmpstartY - tmpY);
                            }
                            if (fit2grid & this.gridSize > 0)
                            {
                                s.Fit2grid(this.gridSize);
                                s.sRec.Fit2grid(this.gridSize);
                            }
                            break;
                        //Graph's point
                        case "GRAPH":
                            // Move selected
                            if (s.selEle != null & s.sRec != null)
                            {
                                
                                s.movePointG(tmpstartX - tmpX, tmpstartY - tmpY);
                            }
                            if (fit2grid & this.gridSize > 0)
                            {
                                s.Fit2grid(this.gridSize);
                                s.sRec.Fit2grid(this.gridSize);
                            }
                            break;

                        case "C":
                            // Move selected
                            if (s.selEle != null & s.sRec != null)
                            {
                                s.move(tmpstartX - tmpX, tmpstartY - tmpY);

                                s.sRec.move(tmpstartX - tmpX, tmpstartY - tmpY);
                            }
                            break;
                        case "ROT":
                            // rotate selected
                            if (s.selEle != null & s.sRec != null)
                            {
                                s.selEle.Rotate(tmpX, tmpY);
                                s.sRec.Rotate(tmpX, tmpY);
                            }
                            break;
                        case "ZOOM":
                            // rotate selected
                            if (s.selEle != null & s.sRec != null)
                            {
                                if (s.selEle is Group)
                                {
                                    ((Group)s.selEle).setZoom(tmpX, tmpY);
                                    s.sRec.setZoom(((Group)s.selEle).GrpZoomX, ((Group)s.selEle).GrpZoomY);
                                }
                            }
                            break;
                        default:
                            // redim selected
                            if (s.selEle != null & s.sRec != null)
                            {
                                s.selEle.redim(tmpX - tmpstartX, tmpY - tmpstartY, this.redimStatus);
                                s.sRec.redim(tmpX - tmpstartX, tmpY - tmpstartY, this.redimStatus);
                            }
                            break;
                    }

                }

                else
                {
                    if (this.Option == "PEN")
                    {
                        //this.s.addEllipse(tempX,tempY,tempX+1,tempY+1,Color.Blue,Color.Blue,1f,false);
                        VisPenPointList.Add(new PointWr(tempX - this.startX, tempY - this.startY));
                        if (Math.Sqrt(Math.Pow(PenPrecX - tempX, 2) + Math.Pow(PenPrecY - tempY, 2)) > 15)
                        {
                            PenPointList.Add(new PointWr(tempX - this.startX, tempY - this.startY));
                            PenPrecX = this.tempX;
                            PenPrecY = this.tempY;
                        }
                        this.redraw(false);
                    }
                }

                redraw(false);
            }
            #endregion
            else
                if (e.Button == MouseButtons.Right)
                #region right mouse button pressed
                {

                    this.dx = (this.startDX + this.truestartX - e.X );
                    this.dy = (this.startDY + this.truestartY - e.Y );
                    if (fit2grid & this.gridSize > 0)
                    {
                        this.dx = this.gridSize * (int)((this.dx ) / this.gridSize);
                        this.dy = this.gridSize * (int)((this.dy ) / this.gridSize);
                    }
                    this.redraw(true);                    
                }
                #endregion
                else
                #region NO muse button pressed
                {
                    if (this.Option == "select")
                    {
                        if (this.s.sRec != null)
                        {
                            string st = this.s.sRec.isOver((int)(e.X / Zoom) - this.dx, (int)(e.Y / Zoom - this.dy));
                            this.redimStatus = st;

                            switch (st)
                            {
                                case "NEWP":
                                    this.Cursor = Cursors.SizeAll;
                                    this.Cursor =  AddPointCur;
                                    /*To change the cursor
                                    Cursor cc = new Cursor("NewPoint.ico");
                                    this.Cursor = cc;
                                    */
                                    break;
                                case "POLY":
                                    this.Cursor = Cursors.SizeAll;
                                    break;
                                case "GRAPH":
                                    this.Cursor = Cursors.SizeAll;
                                    break;
                                case "ROT":
                                    this.Cursor = Cursors.SizeAll;
                                    break;
                                case "C":
                                    this.Cursor = Cursors.Hand;
                                    break;
                                case "NW":
                                    this.Cursor = Cursors.SizeNWSE;
                                    break;
                                case "N":
                                    this.Cursor = Cursors.SizeNS;
                                    break;
                                case "NE":
                                    this.Cursor = Cursors.SizeNESW;
                                    break;
                                case "E":
                                    this.Cursor = Cursors.SizeWE;
                                    break;
                                case "SE":
                                    this.Cursor = Cursors.SizeNWSE;
                                    break;
                                case "S":
                                    this.Cursor = Cursors.SizeNS;
                                    break;
                                case "SW":
                                    this.Cursor = Cursors.SizeNESW;
                                    break;
                                case "W":
                                    this.Cursor = Cursors.SizeWE;
                                    break;
                                case "ZOOM":
                                    this.Cursor = Cursors.SizeNWSE;
                                    break;
                                default:
                                    this.Cursor = Cursors.Default;
                                    redimStatus = "";
                                    break;
                            }
                        }
                        else 
                        {
                            this.Cursor = Cursors.Default;
                            redimStatus = "";
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        redimStatus = "";
                    }

                #endregion
            }
            //redraw();
        }

        private void UserControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            #region left up
            {
                int tmpX = (int)((e.X) / Zoom - this.dx);
                int tmpY = (int)((e.Y) / Zoom - this.dy);
                if (fit2grid & this.gridSize > 0)
                {
                    tmpX = this.gridSize * (int)((e.X / Zoom - this.dx )/ this.gridSize);
                    tmpY = this.gridSize * (int)((e.Y / Zoom  - this.dy)/ this.gridSize);
                }

                switch (this.Option)
                {
                    #region selectrect
                    case "select":
                        if (this.Status != "redim")
                        {
                            this.s.click((int)((e.X) / Zoom - this.dx), (int)((e.Y) / Zoom - this.dy), this.r);
                        }
                        else
                        { 
                             if (this.s.selEle is PointSet)
                             {//POLY MANAGEMENT START
                                 s.addPoint();
                                 //((PointSet)this.s.selEle).rePos();
                                 if (fit2grid & this.gridSize > 0)
                                 {
                                     this.s.Fit2grid(this.gridSize);
                                     //this.s.sRec = new SelPoly(this.s.selEle);//create handling rect
                                 }
                                 switch (this.redimStatus)
                                 {
                                     case "ROT":
                                         this.s.selEle.CommitRotate(tmpX, tmpY);
                                         //this.s.sRec = new SelPoly(this.s.selEle);//create handling rect                                     
                                         break;
                                     default:
                                         break;
                                 }//POLY MANAGEMENT END
                             }

                             if (this.s.selEle is Graph)
                             {//GRAPH MANAGEMENT START
                                 s.addPoint();
                                 //((PointSet)this.s.selEle).rePos();
                                 if (fit2grid & this.gridSize > 0)
                                 {
                                     this.s.Fit2grid(this.gridSize);
                                     //this.s.sRec = new SelPoly(this.s.selEle);//create handling rect
                                 }
                                 switch (this.redimStatus)
                                 {
                                     case "ROT":
                                         this.s.selEle.CommitRotate(tmpX, tmpY);
                                         //this.s.sRec = new SelPoly(this.s.selEle);//create handling rect                                     
                                         break;
                                     default:
                                         break;
                                 }//GRAPH MANAGEMENT END
                             }

                        }
                        
                        if (this.Status == "selrect")
                        {
                            if ((((e.X) / Zoom - this.dx - this.startX) + ((e.Y) / Zoom - this.dy  - this.startY)) > 12)
                            {
                                // manage multi objeect selection
                                this.s.multiSelect(this.startX, this.startY, (int)((e.X) / Zoom - this.dx), (int)((e.Y) / Zoom - this.dy), this.r);
                            }
                        }

                        changeStatus("");
                        break;
                    #endregion
                    #region Rect
                    case "DR": //DrawRect

                        if (this.Status == "drawrect")
                        {
                            this.s.addRect(startX, startY, tmpX, tmpY, this.CreationPenColor, CreationFillColor, CreationPenWidth, CreationFilled);
                            //this.Option = "select";
                            changeOption("select");
                        }
                        break;
                    #endregion
                    #region LINk TEST
                    case "LINK": //Link//test
                        if (this.Status == "drawrect")
                        {


                            changeOption("select");
                        }
                        break;
                    #endregion
                    #region Arc
                    case "ARC": //Arc
                        if (this.Status == "drawrect")
                        {
                            this.s.addArc(startX, startY, tmpX, tmpY, this.CreationPenColor, CreationFillColor, CreationPenWidth, CreationFilled);
                            changeOption("select");
                        }
                        break;
                    #endregion
                    #region Poly & Pen & Graph
                    case "PEN":
                        //if (this.Status == "drawrect")
                        //{
                            this.s.addPoly(startX, startY, tmpX, tmpY, this.CreationPenColor, CreationFillColor, CreationPenWidth, CreationFilled, PenPointList,true);
                            PenPointList = null;
                            VisPenPointList = null;
                            changeOption("select");
                        //}
                        break;
                    case "POLY": //polygon/pointSet/curvedshape..
                        if (this.Status == "drawrect")
                        {
                            ArrayList aa = new ArrayList();
                            aa.Add(new PointWr(0, 0));
                            //aa.Add(new PointWr(System.Math.Abs(startX - tmpX), System.Math.Abs(startY - tmpY)));
                            aa.Add(new PointWr(  tmpX-startX,   tmpY-startY));
                            this.s.addPoly(startX, startY, tmpX, tmpY, this.CreationPenColor, CreationFillColor, CreationPenWidth, CreationFilled,aa,false);
                            changeOption("select");
                        }
                        break;
                    case "GRAPH":
                        if (this.Status == "drawrect")
                        {
                            ArrayList aa = new ArrayList();
                            aa.Add(new PointWr(0, 0));
                            //aa.Add(new PointWr(System.Math.Abs(startX - tmpX), System.Math.Abs(startY - tmpY)));
                            aa.Add(new PointWr(tmpX - startX, tmpY - startY));
                            this.s.addGraph(startX, startY, tmpX, tmpY, this.CreationPenColor, CreationFillColor, CreationPenWidth, CreationFilled, aa);
                            changeOption("select");
                        }
                        break;
                    #endregion
                    #region RRect
                    case "DRR": //DrawRRect

                        if (this.Status == "drawrect")
                        {

                            this.s.addRRect(startX, startY, tmpX, tmpY, this.CreationPenColor, CreationFillColor, CreationPenWidth, CreationFilled);
                            //this.Option = "select";
                            changeOption("select");
                        }
                        break;
                    #endregion
                    #region Ellipse
                    case "ELL": //DrawEllipse

                        if (this.Status == "drawrect")
                        {

                            this.s.addEllipse(startX, startY, tmpX, tmpY, this.CreationPenColor, CreationFillColor, CreationPenWidth, CreationFilled);
                            //this.Option = "select";
                            changeOption("select");
                        }
                        break;
                    #endregion
                    #region DrawTextBox
                    case "TB": //DrawTextBox
                        if (this.Status == "drawrect")
                        {
                            this.Cursor = Cursors.WaitCursor;
                       //     editorFrm.ShowDialog();
                            this.Cursor = Cursors.Arrow;
                            this.s.addTextBox(startX, startY, tmpX, tmpY, r, this.CreationPenColor, CreationFillColor, CreationPenWidth, CreationFilled);
                            changeOption("select");
                        }
                        break;
                    #endregion
                    #region DrawSimpleTextBox
                    case "STB": //DrawSimpleTextBox
                        if (this.Status == "drawrect")
                        {
                            this.Cursor = Cursors.WaitCursor;
                     //       editorFrm.ShowDialog();
                            this.Cursor = Cursors.Arrow;
                            this.s.addSimpleTextBox(startX, startY, tmpX, tmpY, r, this.CreationPenColor, CreationFillColor, CreationPenWidth, CreationFilled);
                            changeOption("select");
                        }
                        break;
                    #endregion
                    #region ImgBox
                    case "IB": //DrawImgBox

                        if (this.Status == "drawrect")
                        {
                            // load image

                            string f_name = this.imgLoader();
                            this.s.addImgBox(startX, startY, tmpX, tmpY, f_name, this.CreationPenColor, CreationPenWidth);
                            //this.Option = "select";
                            changeOption("select");
                        }
                        break;
                    #endregion
                    #region Line
                    case "LI": //Draw Line

                        if (this.Status == "drawrect")
                        {

                            this.s.addLine(startX, startY, tmpX, tmpY, this.CreationPenColor, CreationPenWidth);
                            //this.Option = "select";
                            changeOption("select");
                        }
                        break;
                    #endregion
                    default:
                        //this.Status = "";
                        changeStatus("");
                        break;
                }


                // store start X,Y,X1,Y1 of selected item
                if (this.s.selEle != null)
                {
                    if (this.s.selEle is PointSet)
                    {//POLY MANAGEMENT START
                        ((PointSet)this.s.selEle).setupSize();
                        this.s.sRec = new SelPoly(this.s.selEle);//create handling rect
                    }

                    if (this.s.selEle is Graph)
                    {//GRAPH MANAGEMENT START
                        
                        ((Graph)this.s.selEle).setupSize();
                        this.s.sRec = new SelGraph(this.s.selEle);//create handling rect
                    }


                    if (this.redimStatus != "")
                    {
                        this.s.endMove();
                    }

                    if (this.s.sRec != null)
                    {
                        this.s.sRec.endMoveRedim();
                    }
                }
                // show properties
                PropertyEventArgs e1 = new PropertyEventArgs(this.s.getSelectedArray(), this.s.RedoEnabled(), this.s.UndoEnabled());
                objectSelected(this, e1);// raise event

                redraw(true); //redraw all=true 

                this.MouseSx = false; // end pressing SX
            }
            #endregion
            else
            #region right up
            {
                // show properties
                PropertyEventArgs e1 = new PropertyEventArgs(this.s.getSelectedArray(), this.s.RedoEnabled(), this.s.UndoEnabled());
                objectSelected(this, e1);// raise event

            }
            #endregion
        }

        private void UserControl1_DoubleClick(object sender, EventArgs e)
        {

            switch (this.Option)
            {
                case "select":
                    //if (this.Status != "redim")
                    //{
                        if (s.selEle != null)
                        {
                            if (s.selEle is BoxTesto || s.selEle is Group)
                            {
                                this.Cursor = Cursors.WaitCursor;
                           //     s.selEle.ShowEditor(this.editorFrm);
                                this.Cursor = Cursors.Arrow;
                            }
                            if (s.selEle is ImgBox )
                            {
                                //string f_name = this.imgLoader();
                                ((ImgBox)s.selEle).Load_IMG();
                            }
                            if (s.selEle is Group)
                            {
                                //string f_name = this.imgLoader();
                                ((Group)s.selEle).Load_IMG();
                            }
                            if (s.selEle is PointColorSet)
                            {
                                if (this.redimStatus == "POLY")
                                {
                                    ((PointColorSet)s.selEle).dbl_Click();
                                }
                                    
                            }
                            
                        }
                        this.changeStatus("");
                    //}
                    break;
                default:
                    break;
            }

        }

        #endregion

        public void addPointSet(ArrayList a)
        {
            ArrayList tmpa = new ArrayList();
            foreach (PointWr p in a)
            {
                PointColor tmpp = new PointColor(p.point);
                tmpp.col = Color.Red;
                tmpa.Add(tmpp);
            }
              
            //this.s.addPoly(0, 0, 0, 0, Color.Black, Color.Black, 1, false, a, true);
            this.s.addColorPoinySet(0, 0, 0, 0, Color.Black, Color.Black, 1, false, tmpa, true);
        }
        public ArrayList getPointSet()
        {
            if (this.s.selEle != null)
                if (this.s.selEle is PointSet)
                    return ((PointSet)this.s.selEle).getRealPosPoints();

            return null;
            
        }


/*
        public void propertyChanged()
        {
            this.s.Propertychanged();
        }
*//*
        public void HelpForm(string s)
        {
            Help h = new Help();
            h.setMsg(s);
            h.ShowDialog();
        }
*/
        private void vectShapes_Resize(object sender, EventArgs e)
        {
            if (this.Width>0 & this.Height>0)
            {
            offScreenBackBmp = new Bitmap(this.Width, this.Height);
            offScreenBmp = new Bitmap(this.Width, this.Height);
            this.redraw(true);
            }
        }

        private void vectShapes_Load(object sender, EventArgs e)
        {

        }

    }
}

