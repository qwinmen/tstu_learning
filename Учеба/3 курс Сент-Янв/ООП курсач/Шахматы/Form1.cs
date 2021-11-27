using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using heaparessential.Controls;
using Шахматы.Properties;

/*
 FMain
 *menuStrip1
    *Panel1                    *tableLayoutPanel2
    **tableLayoutPanel1        **lbl_n
    ***Bevel_n
    ****btn_n
 *tableLayoutPanel3 
 **lbl_n 
 
 */

namespace Шахматы
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            
            NauStateKey();
            //начальное положение квадрата
            _bevelStateIndex = "44";
            //Подгрузим статистику из файла
            _saveToFile.Load();
            _formMenu.Statistic(_saveToFile.Schetchik);
        }

        /// <summary>
        /// Дефолтовые значения с XML
        /// </summary>
        private void NauStateKey()
        {
            _keysB.Clear(); _keysW.Clear();
            #region key deffolt load from file xml
            for (int i = 0; i <= 3; i++)
                _keysB.Add(_кнопкиУправления.ReadParam("black", i).Key, _кнопкиУправления.ReadParam("black", i).Value);

            for (int i = 0; i <= 3; i++)
                _keysW.Add(_кнопкиУправления.ReadParam("white", i).Key, _кнопкиУправления.ReadParam("white", i).Value);

            #endregion
        }

        private SortedList<string, string > _keysB = new SortedList<string, string>();
        private SortedList<string, string> _keysW = new SortedList<string, string>();

        /// <summary>
        /// Коллекция обьектов Bevel
        /// </summary>
        private List<Bevel> _bevels = new List<Bevel>();
        /// <summary>
        /// Коллекция обьектов Button
        /// </summary>
        private List<ButtonBase> _buttons = new List<ButtonBase>();

        private clNewGame newGame = new clNewGame();
        private clWorkFile _saveToFile = new clWorkFile();
        private clStack _stackXodov = new clStack();
        private clCopyAsValue _copyValueObj = new clCopyAsValue();
        private fTransformPawnToN _fTransformPawn = new fTransformPawnToN();


        private void fMain_Load(object sender, EventArgs e)
        {
            _saveToFile.Schetchik += 1;
            newGame = new clNewGame();
            _bevels.Clear();
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                    if ((tableLayoutPanel1.GetControlFromPosition(i, j) as Bevel) != null)
                        _bevels.Add((tableLayoutPanel1.GetControlFromPosition(i, j) as Bevel));
            _buttons.Clear();
            foreach (Bevel bevel in _bevels.Where(bevel => (bevel.GetChildAtPoint(new Point(0, 0)) as ButtonBase) != null))
            {
                _buttons.Add(bevel.GetChildAtPoint(new Point(0, 0)) as ButtonBase);
                _copyValueObj.AddList(bevel.GetChildAtPoint(new Point(0, 0)) as ButtonBase);
            }
        }

/*КТО ИДЕТ за_клинским ПЕРВЫМ?*/
        private clXod xod = new clXod(true);
        /// <summary>
        /// Варианты действий обьекта
        /// </summary>
        private void xod_Click(object sender, EventArgs e)
        {
            #region Button_Click
            //убедимся что нажали кнопку
            if ((sender as ButtonBase) != null)
            {
                var btnFigure = (sender as ButtonBase);//текущая фигура
                //ЩА ХОДЯТ ЧЕРНЫЕ:
                if (xod.BlackGo && btnFigure.Tag.ToString().Contains("ЧЕР"))
                {//нажали не туже самую кнопку повторно
                    if (xod.XodStartFigureTag != btnFigure.Tag.ToString())
                    {
                        /*Методы отвечающие за начало хода фигурой*/
                        /*Нажал кнопу, снял подсветку, подсветил ходы*/
                        //MessageBox.Show("Начало хода ЭТОЙ кнопкой ИЛИ буду бить ЭТУ кнопу");

                        _btnBase = btnFigure;
                        noCheked();
                        podsvetXoda(btnFigure.Tag.ToString(), btnFigure.Name);

                        /*Методы отвечающие за возможность битья
                         * если текущая кнопка под ударом предыдущей
                         */

                        xod.XodStart = true;
                        xod.XodStartFigureTag = btnFigure.Tag.ToString();
                    }
                }
                else if (xod.BlackGo && btnFigure.Tag.ToString().Contains("БЕЛ"))
                {
                    if (string.IsNullOrEmpty(xod.XodStartFigureTag))
                    {
                        showBall(xod.BlackGo ? "errBlackGo" : "errWhiteGo");
                        return;
                    }
                    //заряжаю тег кнопки "ЧЕР_СЛОН_A2", получаю индекс [6,0] в массиве
                    Point indexStart = newGame.PoiskVMassive(btnFigure.Tag.ToString()); //[6,0]
                    string bvl = indexStart.X + "" + indexStart.Y;
                    string result = newGame.VariantXoda(xod.XodStartFigureTag, bvl, true);
                    //Могу ее(бел) выбить?
                    switch (result)
                    {
                        case "help": showBall(xod.ConteinsFigure(xod.XodStartFigureTag));
                            break;
                        case "Путь перекрыт": showBall("errNe");
                            break;
                        case "err": showBall(xod.BlackGo ? "errBlackGo" : "errWhiteGo");
                            break;
                        case "OK":// MessageBox.Show("БИТЬ МОЖНО");
                            deliteFigure(btnFigure, xod.XodStartFigureTag);
                            xod.BlackGo = !xod.BlackGo;
                            xod.XodStart = false;
                            xod.XodStartFigureTag = "";
                            //_stackXodov.Add(newGame.FigureObjArrState(), xod.BlackGo);
                            _stackXodov.AddString(newGame.FigureObjArrState(), xod.BlackGo);
                            return;
                    }
                    
                }
                

                //ЩА ХОДЯТ БЕЛЫЕ:
                if (!xod.BlackGo && btnFigure.Tag.ToString().Contains("БЕЛ"))
                {//нажали не туже самую кнопку повторно
                    if (xod.XodStartFigureTag != btnFigure.Tag.ToString())
                    {
                        /*Методы отвечающие за начало хода фигурой*/
                        /*Нажал кнопу, снял подсветку, подсветил ходы*/
                        //MessageBox.Show("Начало хода ЭТОЙ кнопкой ИЛИ буду бить ЭТУ кнопу");

                        _btnBase = btnFigure;
                        noCheked();
                        podsvetXoda(btnFigure.Tag.ToString(), btnFigure.Name);

                        /*Методы отвечающие за возможность битья
                         * если текущая кнопка под ударом предыдущей
                         */

                        xod.XodStart = true;
                        xod.XodStartFigureTag = btnFigure.Tag.ToString();
                    }
                }
                else if (!xod.BlackGo && btnFigure.Tag.ToString().Contains("ЧЕР"))
                {
                    if (string.IsNullOrEmpty(xod.XodStartFigureTag))
                    {
                        showBall(xod.BlackGo ? "errBlackGo" : "errWhiteGo");
                        return;
                    }
                    //заряжаю тег кнопки "ЧЕР_СЛОН_A2", получаю индекс [6,0] в массиве
                    Point indexStart = newGame.PoiskVMassive(btnFigure.Tag.ToString()); //[6,0]
                    string bvl = indexStart.X + "" + indexStart.Y;
                    string result = newGame.VariantXoda(xod.XodStartFigureTag, bvl, true);
                    //Могу ее(чер) выбить?
                    switch (result)
                    {
                        case "help": showBall(xod.ConteinsFigure(xod.XodStartFigureTag));
                            break;
                        case "Путь перекрыт": showBall("errNe");
                            break;
                        case "err": showBall(xod.BlackGo ? "errBlackGo" : "errWhiteGo");
                            break;
                        case "OK"://   MessageBox.Show("БИТЬ МОЖНО");
                            deliteFigure(btnFigure, xod.XodStartFigureTag);
                            ProverkaNaShax(xod.XodStartFigureTag);
                            xod.BlackGo = !xod.BlackGo;
                            xod.XodStart = false;
                            xod.XodStartFigureTag = "";
                            //_stackXodov.Add(newGame.FigureObjArrState(), xod.BlackGo);
                            _stackXodov.AddString(newGame.FigureObjArrState(), xod.BlackGo);
                            return;
                    }
                }


            }
            #endregion
            /***************************************************************************/
            #region Bevel
            if ((sender as Bevel) != null)
            {
                //Если начала хода небыло
                if(xod.XodStart)
                {
                    /*Методы отвечающие за переход кнопки В панель
                     * на форме
                     * в массиве
                     */
                    var bvl = (sender as Bevel);

                    //если кнопке xod.XodStartFigureTag разрешен переход на панель bvl.Tag:
                    //если на панели есть фигура, то бить ИЛИ (это своя, туда нельзя)
                    string result = newGame.VariantXoda(xod.XodStartFigureTag, bvl.Tag.ToString(), false);
                    switch (result)
                    {
                        case "help": showBall(xod.ConteinsFigure(xod.XodStartFigureTag));
                            break;
                        case "Путь перекрыт": showBall("errNe");
                            break;
                        default:
                            {
                                perexod(bvl);
                                ProverkaNaShax(xod.XodStartFigureTag);
                                xod.BlackGo = !xod.BlackGo;
                                //_stackXodov.Add(newGame.FigureObjArrState(), xod.BlackGo);
                                _stackXodov.AddString(newGame.FigureObjArrState(), xod.BlackGo);
                            }break;
                    }
                    xod.XodEnd = true;
                }
            }
            #endregion
            //Ход совершен полностью
            xod.ResetXodState();
        }

        /// <summary>
        /// Показать варианты хода для фигуры btnFigureTag
        /// </summary>
        private void podsvetXoda(string btnFigureTag, string name)
        {
            if(_formMenu.PodsvetOn)
            switch (name)
            {
                #region case "btnBP_a2": GoPawn(btnFigureTag); break;
                    //если тег кнопки изменен (ПЕШКА _ КОНЬ) то это КОНЬ
                case "btnBP_a2": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag));
                        break;
                case "btnBP_b2": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag));
                        break;
                case "btnBP_c2": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag));
                        break;
                case "btnBP_d2": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag));
                        break;
                case "btnBP_e2": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag));
                        break;
                case "btnBP_f2": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag));
                        break;
                case "btnBP_g2": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag));
                        break;
                case "btnBP_h2": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag));
                        break;
                #endregion

                #region case "btnWP_a7": GoPawn(btnFigureTag); break;
                case "btnWP_a7": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag)); 
                        break;
                case "btnWP_b7": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag)); 
                        break;
                case "btnWP_c7": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag)); 
                        break;
                case "btnWP_d7": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag)); 
                        break;
                case "btnWP_e7": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag)); 
                        break;
                case "btnWP_f7": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag)); 
                        break;
                case "btnWP_g7": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag)); 
                        break;
                case "btnWP_h7": if (btnFigureTag.Contains("ПЕШКА")) GoPawn(btnFigureTag);
                                    else podsvetXoda(btnFigureTag, TagName(btnFigureTag)); 
                        break;
                    #endregion

                #region case "btnBL_a1": GoLaden(btnFigureTag); break;
                case "btnBL_a1":
                    GoLaden(btnFigureTag); break;
                case "btnBL_h1":
                    GoLaden(btnFigureTag); break;
               #endregion

                #region case "btnWL_a8": GoLaden(btnFigureTag); break;
                case "btnWL_a8":
                    GoLaden(btnFigureTag); break;
                case "btnWL_h8":
                    GoLaden(btnFigureTag); break;
               #endregion

                #region case "btnBK_b1": GoKoni(btnFigureTag); break;
                case "btnBK_b1": GoKoni(btnFigureTag); break;
                case "btnBK_g1": GoKoni(btnFigureTag); break;
                #endregion

                #region case "btnWK_b8": GoKoni(btnFigureTag); break;
                case "btnWK_b8": GoKoni(btnFigureTag); break;
                case "btnWK_g8": GoKoni(btnFigureTag); break;
                #endregion

                #region case "btnBS_c1": GoSlon(btnFigureTag); break;
                case "btnBS_c1": GoSlon(btnFigureTag); break;
                case "btnBS_f1": GoSlon(btnFigureTag); break;
                #endregion

                #region case "btnWS_c8": GoSlon(btnFigureTag); break;
                case "btnWS_c8": GoSlon(btnFigureTag); break;
                case "btnWS_f8": GoSlon(btnFigureTag); break;
                #endregion

                case "btnBW_d1": GoKarol(btnFigureTag); break;

                case "btnWW_d8": GoKarol(btnFigureTag); break;

                case "btnBF_e1": GoFerz(btnFigureTag); break;

                case "btnWF_e8": GoFerz(btnFigureTag); break;

                case "err": throw new Exception("Ошибка TagName() в преобразовании фигуры");
            }
        }

        /// <summary>
        /// выдать направление на swith выше.
        /// на вход "ЧЕР_btnIKoni_1" на выход "btnBK_b1"
        /// </summary>
        private string TagName(string name)
        {
            string[] tmp = name.Split('_');
            if(name.Contains("ЧЕР"))
            {
                switch (tmp[1])
                {
                    case "btnILaden": return "btnBL_a1";
                    case "btnIKoni": return "btnBK_b1";
                    case "btnISlon": return "btnBS_c1";
                    case "btnIFerz": return "btnBF_e1";
                }
            }
            else
            {
                switch (tmp[1])
                {
                    case "btnILaden": return "btnWL_a8";
                    case "btnIKoni": return "btnWK_b8";
                    case "btnISlon": return "btnWS_c8";
                    case "btnIFerz": return "btnWF_e8";
                }
            }
            return "err";
        }

        /// <summary>
        /// Для ферзя подсветка хода
        /// </summary>
        private void GoFerz(string btnFigureTag)
        {
            /*
             *Ферзь - это направления:
             *а) Слон
             *б) Ладья
             *используем
             */
            GoLaden(btnFigureTag);
            GoSlon(btnFigureTag);
        }

        /// <summary>
        /// Для короля подсветка хода
        /// </summary>
        private void GoKarol(string btnFigureTag)
        {
            /*варианты обхода:
             *3-3-1-1
             *2-2-2-2
             *верх-низ-лево-право
             */
            //чем ходим
            bool goBlack = btnFigureTag.Contains("ЧЕР");
            bool goWhite = btnFigureTag.Contains("БЕЛ");
            //заряжаю тег кнопки "ЧЕР_КАРОЛЬ_A2", получаю индекс [6,0] в массиве
            Point indexStart = newGame.PoiskVMassive(btnFigureTag);//[6,0]
            const int up = 0, down = 7, left = 0, right = 7;
            string indexL = "", indexR = "", indexC = "";

            #region Верхнее направление
            //поднялись по строке
            int goUp = indexStart.X - 1;
            //по столбцам
            int goLeft = indexStart.Y - 1;
            int goCentr = indexStart.Y;
            int goRight = indexStart.Y + 1;

            if (goLeft >= left) indexL = goUp + "" + goLeft;
            if (goRight <= right) indexR = goUp + "" + goRight;
            if (goCentr >= up) indexC = goUp + "" + goCentr;

            //убедится что не нарушены границы доски
            if (goUp >= up && (indexL != "" || indexR != ""))
            {
                string figNameL = newGame.ShowFigName(indexL);
                string figNameC = newGame.ShowFigName(indexC);
                string figNameR = newGame.ShowFigName(indexR);
                //разрешено вверх и (вправо или влево)
                foreach (var bevel in _bevels)
                {
                    //"40" = "40"
                    if (bevel.Tag.ToString() == indexL)//|| bevel.Tag.ToString() == indexR)
                    {
                        if (goBlack && (figNameL == "null" || figNameL.Contains("БЕЛ")))
                            bevel.BackColor = Color.Green;
                        if (goWhite && (figNameL == "null" || figNameL.Contains("ЧЕР")))
                            bevel.BackColor = Color.Green;
                    }
                    if (bevel.Tag.ToString() == indexC)
                    {
                        if (goBlack && (figNameC == "null" || figNameC.Contains("БЕЛ")))
                            bevel.BackColor = Color.Green;
                        if (goWhite && (figNameC == "null" || figNameC.Contains("ЧЕР")))
                            bevel.BackColor = Color.Green;
                    }
                    if (bevel.Tag.ToString() == indexR)
                    {
                        if (goBlack && (figNameR == "null" || figNameR.Contains("БЕЛ")))
                            bevel.BackColor = Color.Green;
                        if (goWhite && (figNameR == "null" || figNameR.Contains("ЧЕР")))
                            bevel.BackColor = Color.Green;
                    }

                }
            }
            indexL = indexR = "";
            #endregion
            
            #region Левое направление
            goLeft = indexStart.Y - 1;
            if(goLeft>=left)
            {
                indexL = indexStart.X + "" + goLeft;
                string figNameL = newGame.ShowFigName(indexL);
                foreach(Bevel bvl in _bevels)
                    if (bvl.Tag.ToString() == indexL)//|| bevel.Tag.ToString() == indexR)
                    {
                        if (goBlack && (figNameL == "null" || figNameL.Contains("БЕЛ")))
                            bvl.BackColor = Color.Green;
                        if (goWhite && (figNameL == "null" || figNameL.Contains("ЧЕР")))
                            bvl.BackColor = Color.Green;
                    }
            }
            #endregion

            #region Правое направление
            goRight = indexStart.Y + 1;
            if (goRight <= right)
            {
                indexR = indexStart.X + "" + goRight;
                string figNameR = newGame.ShowFigName(indexR);
                foreach (Bevel bvl in _bevels)
                    if (bvl.Tag.ToString() == indexR)
                    {
                        if (goBlack && (figNameR == "null" || figNameR.Contains("БЕЛ")))
                            bvl.BackColor = Color.Green;
                        if (goWhite && (figNameR == "null" || figNameR.Contains("ЧЕР")))
                            bvl.BackColor = Color.Green;
                    }
            }
            #endregion

            #region Нижнее направление
            //опустились по строке
            goUp = indexStart.X + 1;
            //по столбцам
            goLeft = indexStart.Y - 1;
            goCentr = indexStart.Y;
            goRight = indexStart.Y + 1;

            if (goLeft >= left) indexL = goUp + "" + goLeft;
            if (goRight <= right) indexR = goUp + "" + goRight;
            if (goCentr <= down) indexC = goUp + "" + goCentr;

            //убедится что не нарушены границы доски
            if (goUp <= down && (indexL != "" || indexR != ""))
            {//goUp типо goDown ну лень
                string figNameL = newGame.ShowFigName(indexL);
                string figNameC = newGame.ShowFigName(indexC);
                string figNameR = newGame.ShowFigName(indexR);
                //разрешено вверх и (вправо или влево)
                foreach (var bevel in _bevels)
                {
                    //"40" = "40"
                    if (bevel.Tag.ToString() == indexL)//|| bevel.Tag.ToString() == indexR)
                    {
                        if (goBlack && (figNameL == "null" || figNameL.Contains("БЕЛ")))
                            bevel.BackColor = Color.Green;
                        if (goWhite && (figNameL == "null" || figNameL.Contains("ЧЕР")))
                            bevel.BackColor = Color.Green;
                    }
                    if (bevel.Tag.ToString() == indexC)
                    {
                        if (goBlack && (figNameC == "null" || figNameC.Contains("БЕЛ")))
                            bevel.BackColor = Color.Green;
                        if (goWhite && (figNameC == "null" || figNameC.Contains("ЧЕР")))
                            bevel.BackColor = Color.Green;
                    }
                    if (bevel.Tag.ToString() == indexR)
                    {
                        if (goBlack && (figNameR == "null" || figNameR.Contains("БЕЛ")))
                            bevel.BackColor = Color.Green;
                        if (goWhite && (figNameR == "null" || figNameR.Contains("ЧЕР")))
                            bevel.BackColor = Color.Green;
                    }

                }
            }
            
            #endregion

        }

        /// <summary>
        /// Для слона подсветка хода
        /// </summary>
        private void GoSlon(string btnFigureTag)
        {
            //чем ходим
            bool goBlack = btnFigureTag.Contains("ЧЕР");
            bool goWhite = btnFigureTag.Contains("БЕЛ");
            //заряжаю тег кнопки "ЧЕР_СЛОН_A2", получаю индекс [6,0] в массиве
            Point indexStart = newGame.PoiskVMassive(btnFigureTag); //[6,0]
            const int up = 0, down = 7, left = 0, right = 7;
            /*направления хода: границы//верх=0//низ=7//лево=0//право=7
             *
             * в процессе хода незаходить за обьект
             */
            string indexL = "", indexR = "";

            #region Верхнее направление
            bool rstop = false, lstop = false;
            //глянем в право
            int goRight = indexStart.Y + 1;
            //глянем в лево
            int goLeft = indexStart.Y - 1;
            //поднятся на верх
            int goUp = indexStart.X - 1;
            //проверить на выход за грань
            while (goUp >= up)
            {
                //мы ненарушили и поднялись

                //проверить на выход за грань
                if (goLeft >= left)
                {
                    //мы ненарушили и перешли в лево, координаты:
                    indexL = goUp + "" + goLeft;
                    //глянем наличие обьекта по этим координатам в массиве:
                    string figNameL = newGame.ShowFigName(indexL);
                    foreach (var bevel in _bevels)
                    {
                        if (!lstop && bevel.Tag.ToString() == indexL)
                        {
                            if (goBlack && figNameL.Contains("ЧЕР"))
                                lstop = true;
                            if (goWhite && figNameL.Contains("БЕЛ"))
                                lstop = true;
                            if (goBlack && figNameL.Contains("БЕЛ"))
                            { bevel.BackColor = Color.Green; lstop = true; }
                            if (goWhite && figNameL.Contains("ЧЕР"))
                            { bevel.BackColor = Color.Green; lstop = true; }

                            if (goBlack && (figNameL == "null" || figNameL.Contains("БЕЛ")))
                                bevel.BackColor = Color.Green;
                            if (goWhite && (figNameL == "null" || figNameL.Contains("ЧЕР")))
                                bevel.BackColor = Color.Green;
                        }
                    }
                    goLeft--;
                }

                //проверить на выход за грань
                if (goRight <= right)
                {
                    //мы ненарушили и перешли в право, координаты:
                    indexR = goUp + "" + goRight;
                    //глянем наличие обьекта по этим координатам в массиве:
                    string figNameR = newGame.ShowFigName(indexR);
                    foreach (var bevel in _bevels)
                    {
                        if (!rstop && bevel.Tag.ToString() == indexR)
                        {
                            if (goBlack && figNameR.Contains("ЧЕР"))
                                rstop = true;
                            if (goWhite && figNameR.Contains("БЕЛ"))
                                rstop = true;
                            if (goBlack && figNameR.Contains("БЕЛ"))
                            { bevel.BackColor = Color.Green; rstop = true; }
                            if (goWhite && figNameR.Contains("ЧЕР"))
                            { bevel.BackColor = Color.Green; rstop = true; }

                            if (goBlack && (figNameR == "null" || figNameR.Contains("БЕЛ")))
                                bevel.BackColor = Color.Green;
                            if (goWhite && (figNameR == "null" || figNameR.Contains("ЧЕР")))
                                bevel.BackColor = Color.Green;
                        }
                    }
                    goRight++;
                }
                goUp--;
            }
            indexL = indexR = "";
            #endregion

            #region Нижнее направление
            rstop = lstop = false;
            //глянем в право
            goRight = indexStart.Y + 1;
            //глянем в лево
            goLeft = indexStart.Y - 1;
            //опустится в низ
            goUp = indexStart.X + 1;
            //проверить на выход за грань
            while (goUp <= down)
            {//goUp насамом деле goDown, лень...
                //мы ненарушили и опустились

                //проверить на выход за грань
                if (goLeft >= left)
                {
                    //мы ненарушили и перешли в лево, координаты:
                    indexL = goUp + "" + goLeft;
                    //глянем наличие обьекта по этим координатам в массиве:
                    string figNameL = newGame.ShowFigName(indexL);
                    foreach (var bevel in _bevels)
                    {
                        if (!lstop && bevel.Tag.ToString() == indexL)
                        {
                            if (goBlack && figNameL.Contains("ЧЕР"))
                                lstop = true;
                            if (goWhite && figNameL.Contains("БЕЛ"))
                                lstop = true;
                            if (goBlack && figNameL.Contains("БЕЛ"))
                            { bevel.BackColor = Color.Green; lstop = true; }
                            if (goWhite && figNameL.Contains("ЧЕР"))
                            { bevel.BackColor = Color.Green; lstop = true; }

                            if (goBlack && (figNameL == "null" || figNameL.Contains("БЕЛ")))
                                bevel.BackColor = Color.Green;
                            if (goWhite && (figNameL == "null" || figNameL.Contains("ЧЕР")))
                                bevel.BackColor = Color.Green;
                        }
                    }
                    goLeft--;
                }

                //проверить на выход за грань
                if (goRight <= right)
                {
                    //мы ненарушили и перешли в право, координаты:
                    indexR = goUp + "" + goRight;
                    //глянем наличие обьекта по этим координатам в массиве:
                    string figNameR = newGame.ShowFigName(indexR);
                    foreach (var bevel in _bevels)
                    {
                        if (!rstop && bevel.Tag.ToString() == indexR)
                        {
                            if (goBlack && figNameR.Contains("ЧЕР"))
                                rstop = true;
                            if (goWhite && figNameR.Contains("БЕЛ"))
                                rstop = true;
                            if (goBlack && figNameR.Contains("БЕЛ"))
                            { bevel.BackColor = Color.Green; rstop = true; }
                            if (goWhite && figNameR.Contains("ЧЕР"))
                            { bevel.BackColor = Color.Green; rstop = true; }

                            if (goBlack && (figNameR == "null" || figNameR.Contains("БЕЛ")))
                                bevel.BackColor = Color.Green;
                            if (goWhite && (figNameR == "null" || figNameR.Contains("ЧЕР")))
                                bevel.BackColor = Color.Green;
                        }
                    }
                    goRight++;
                }
                goUp++;
            }
            indexL = indexR = "";
            #endregion

        }

        /// <summary>
        /// Для коня подсветка хода
        /// </summary>
        private void GoKoni(string btnFigureTag)
        {
            //чем ходим
            bool goBlack = btnFigureTag.Contains("ЧЕР");
            bool goWhite = btnFigureTag.Contains("БЕЛ");
            //заряжаю тег кнопки "ЧЕР_КОНЬ_A2", получаю индекс [6,0] в массиве
            Point indexStart = newGame.PoiskVMassive(btnFigureTag);//[6,0]
            const int up = 0, down = 7, left = 0, right = 7;
            /*направления хода: границы//верх=0//низ=7//лево=0//право=7
             *
             * в процессе хода незаходить за обьект
             */
            string indexL="", indexR="";

            #region Верхнее направление
            //по строке
            int goUp = indexStart.X - 2;//6-2
            //по столбцам
            int goLeft = indexStart.Y - 1;
            int goRight = indexStart.Y + 1;

            if(goLeft>=left) indexL = goUp + "" + goLeft;
            if(goRight<=right) indexR = goUp + "" + goRight;

            //убедится что не нарушены границы доски
            if (goUp >= up && (indexL != "" || indexR != ""))
            {
                string figNameL = newGame.ShowFigName(indexL);
                string figNameR = newGame.ShowFigName(indexR);
                //разрешено вверх и (вправо или влево)
                foreach (var bevel in _bevels)
                {
                    //"40" = "40"
                    if (bevel.Tag.ToString() == indexL)//|| bevel.Tag.ToString() == indexR)
                    {
                        if (goBlack && (figNameL == "null" || figNameL.Contains("БЕЛ")))
                            bevel.BackColor = Color.Green;
                        if (goWhite && (figNameL == "null" || figNameL.Contains("ЧЕР")))
                            bevel.BackColor = Color.Green;
                    }
                    if (bevel.Tag.ToString() == indexR)
                    {
                        if (goBlack && (figNameR == "null" || figNameR.Contains("БЕЛ")))
                            bevel.BackColor = Color.Green;
                        if (goWhite && (figNameR == "null" || figNameR.Contains("ЧЕР")))
                            bevel.BackColor = Color.Green;
                    }

                }
            }
            indexL = indexR = "";
            #endregion

            #region Нижнее направление
            //по строке
            goUp = indexStart.X + 2;//6+2
            //по столбцам
            goLeft = indexStart.Y - 1;
            goRight = indexStart.Y + 1;

            if (goLeft >= left) indexL = goUp + "" + goLeft;
            if (goRight <= right) indexR = goUp + "" + goRight;

            //убедится что не нарушены границы доски
            if (goUp <= down && (indexL != "" || indexR != ""))
            {
                string figNameL = newGame.ShowFigName(indexL);
                string figNameR = newGame.ShowFigName(indexR);
                //разрешено вниз и (вправо или влево)
                foreach (var bevel in _bevels)
                {
                    //"40" = "40"
                    if (bevel.Tag.ToString() == indexL)
                    {
                        if (goBlack && (figNameL == "null" || figNameL.Contains("БЕЛ")))
                            bevel.BackColor = Color.Green;
                        if (goWhite && (figNameL == "null" || figNameL.Contains("ЧЕР")))
                            bevel.BackColor = Color.Green;
                    }
                    if (bevel.Tag.ToString() == indexR)
                    {
                        if (goBlack && (figNameR == "null" || figNameR.Contains("БЕЛ")))
                            bevel.BackColor = Color.Green;
                        if (goWhite && (figNameR == "null" || figNameR.Contains("ЧЕР")))
                            bevel.BackColor = Color.Green;
                    }
                }
            }
            indexL = indexR = "";
            #endregion

            #region Влево направление
            //по строке вверх и вниз
            goUp = indexStart.X + 1;//до 7
			int goDown = indexStart.X - 1;//до 0
            //по столбцам в лево
            goLeft = indexStart.Y - 2;//до 0
			
			if(goUp<=down) indexL = goUp+""+goLeft;
			if(goDown>=up) indexR = goDown+""+goLeft;

            //убедится что не нарушены границы доски
            if (goLeft>=left && (indexL != "" || indexR != ""))
            {
                string figNameL = newGame.ShowFigName(indexL);
                string figNameR = newGame.ShowFigName(indexR);
                //разрешено вдево и (выше или ниже)
                foreach (var bevel in _bevels)
                {
                    //"40" = "40"
                    if (bevel.Tag.ToString() == indexL)//верх
                    {
                        if (goBlack && (figNameL == "null" || figNameL.Contains("БЕЛ")))
                            bevel.BackColor = Color.Green;
                        if (goWhite && (figNameL == "null" || figNameL.Contains("ЧЕР")))
                            bevel.BackColor = Color.Green;
                    }
                    if (bevel.Tag.ToString() == indexR)//низ
                    {
                        if (goBlack && (figNameR == "null" || figNameR.Contains("БЕЛ")))
                            bevel.BackColor = Color.Green;
                        if (goWhite && (figNameR == "null" || figNameR.Contains("ЧЕР")))
                            bevel.BackColor = Color.Green;
                    }
                }
            }
            indexL = indexR = "";
            #endregion

            #region Вправо направление
            //по строке вверх и вниз
            goUp = indexStart.X + 1;//до 7
			goDown = indexStart.X - 1;//до 0
            //по столбцам в право
            goRight = indexStart.Y + 2;//до 7
			
			if(goUp<=down) indexL = goUp+""+goRight;
			if(goDown>=up) indexR = goDown+""+goRight;

            //убедится что не нарушены границы доски
            if (goRight<=right && (indexL != "" || indexR != ""))
            {
                string figNameL = newGame.ShowFigName(indexL);
                string figNameR = newGame.ShowFigName(indexR);
                //разрешено вдево и (выше или ниже)
                foreach (var bevel in _bevels)
                {
                    //"40" = "40"
                    if (bevel.Tag.ToString() == indexL)//|| bevel.Tag.ToString() == indexR)
                    {
                        if (goBlack && (figNameL == "null" || figNameL.Contains("БЕЛ")))
                            bevel.BackColor = Color.Green;
                        if (goWhite && (figNameL == "null" || figNameL.Contains("ЧЕР")))
                            bevel.BackColor = Color.Green;
                    }
                    if (bevel.Tag.ToString() == indexR)
                    {
                        if (goBlack && (figNameR == "null" || figNameR.Contains("БЕЛ")))
                            bevel.BackColor = Color.Green;
                        if (goWhite && (figNameR == "null" || figNameR.Contains("ЧЕР")))
                            bevel.BackColor = Color.Green;
                    }
                }
            }
            indexL = indexR = "";
            #endregion

        }

        /// <summary>
        /// Для ладьи подсветка хода
        /// </summary>
        private void GoLaden(string btnFigureTag)
        {
            bool goBlack = btnFigureTag.Contains("ЧЕР");
            //заряжаю тег кнопки "ЧЕР_ЛАДЬЯ_A2", получаю индекс [6,0] в массиве
            Point indexStart = newGame.PoiskVMassive(btnFigureTag);//[6,0]
            //индекс [6,0] в строку "60", строку ищем в Bevel.Tag
            //string nn = (indexStart.X) + "" + (indexStart.Y);//6+""+0
            const int up = 0, down = 7, left = 0, right = 7;
            /*направления хода: границы//верх=0//низ=7//лево=0//право=7
             * в верх: от [6-1, 2] до [верх, 2]
             * в низ : от [6+1, 2] до [низ, 2]
             * в лево: от [6, 2-1] до [6, лево]
             *в право: от [6, 2+1] до [6, право]
             *
             * в процессе хода незаходить за обьект
             */
            List<string > toUp = new List<string>();

            #region Верхнее направление
            for (int i = (indexStart.X - 1); i >= up; i--)
            {//6..5..4..0
                string tmp = (i) + "" + indexStart.Y;
                string figName = newGame.ShowFigName(tmp);
                
                //если ячейка пуста, то подсветим:
                if (figName == "null") toUp.Add(tmp);

                if (goBlack && figName != "null")
                {
                 //если в ячейке обьект И я пошел ЧЕРными И обьект_БЕЛ, то подсветим
                    if (figName.Contains("БЕЛ")) {toUp.Add(tmp); break;}
                 //если в ячейке обьект И я пошел ЧЕРными И обьект_ЧЕР, то несветим
                    if (figName.Contains("ЧЕР")) break;
                }

                if (!goBlack && figName != "null")
                {
                 //если в ячейке обьект И я пошел БЕЛыми И обьект_ЧЕР, то подсветим
                    if (figName.Contains("ЧЕР")) { toUp.Add(tmp); break; }
                 //если в ячейке обьект И я пошел БЕЛыми И обьект_БЕЛ, то несветим
                    if (figName.Contains("БЕЛ")) break;
                }
            }

            foreach (var bevel in _bevels)
                foreach (string s in toUp)
                    if (bevel.Tag.ToString() == s)
                        bevel.BackColor = Color.Green;
            toUp.Clear();
            #endregion

            #region Нижнее направление
            for (int i = (indexStart.X + 1); i <= down; i++)
            {//6..5..4..0
                string tmp = (i) + "" + indexStart.Y;
                string figName = newGame.ShowFigName(tmp);

                //если ячейка пуста, то подсветим:
                if (figName == "null") toUp.Add(tmp);

                if (goBlack && figName != "null")
                {
                    //если в ячейке обьект И я пошел ЧЕРными И обьект_БЕЛ, то подсветим
                    if (figName.Contains("БЕЛ")) { toUp.Add(tmp); break; }
                    //если в ячейке обьект И я пошел ЧЕРными И обьект_ЧЕР, то несветим
                    if (figName.Contains("ЧЕР")) break;
                }

                if (!goBlack && figName != "null")
                {
                    //если в ячейке обьект И я пошел БЕЛыми И обьект_ЧЕР, то подсветим
                    if (figName.Contains("ЧЕР")) { toUp.Add(tmp); break; }
                    //если в ячейке обьект И я пошел БЕЛыми И обьект_БЕЛ, то несветим
                    if (figName.Contains("БЕЛ")) break;
                }
            }

            foreach (var bevel in _bevels)
                foreach (string s in toUp)
                    if (bevel.Tag.ToString() == s)
                        bevel.BackColor = Color.Green;
            toUp.Clear();
            #endregion			

            #region Левое направление
            for (int i = (indexStart.Y - 1); i >= left; i--)
            {//6..5..4..0
                string tmp = indexStart.X + "" + (i);
                string figName = newGame.ShowFigName(tmp);

                //если ячейка пуста, то подсветим:
                if (figName == "null") toUp.Add(tmp);

                if (goBlack && figName != "null")
                {
                    //если в ячейке обьект И я пошел ЧЕРными И обьект_БЕЛ, то подсветим
                    if (figName.Contains("БЕЛ")) { toUp.Add(tmp); break; }
                    //если в ячейке обьект И я пошел ЧЕРными И обьект_ЧЕР, то несветим
                    if (figName.Contains("ЧЕР")) break;
                }

                if (!goBlack && figName != "null")
                {
                    //если в ячейке обьект И я пошел БЕЛыми И обьект_ЧЕР, то подсветим
                    if (figName.Contains("ЧЕР")) { toUp.Add(tmp); break; }
                    //если в ячейке обьект И я пошел БЕЛыми И обьект_БЕЛ, то несветим
                    if (figName.Contains("БЕЛ")) break;
                }
            }

            foreach (var bevel in _bevels)
                foreach (string s in toUp)
                    if (bevel.Tag.ToString() == s)
                        bevel.BackColor = Color.Green;
            toUp.Clear();
            #endregion			

            #region Правое направление
            for (int i = (indexStart.Y + 1); i <= right; i++)
            {//6..5..4..0
                string tmp = indexStart.X + "" + (i);
                string figName = newGame.ShowFigName(tmp);

                //если ячейка пуста, то подсветим:
                if (figName == "null") toUp.Add(tmp);

                if (goBlack && figName != "null")
                {
                    //если в ячейке обьект И я пошел ЧЕРными И обьект_БЕЛ, то подсветим
                    if (figName.Contains("БЕЛ")) { toUp.Add(tmp); break; }
                    //если в ячейке обьект И я пошел ЧЕРными И обьект_ЧЕР, то несветим
                    if (figName.Contains("ЧЕР")) break;
                }

                if (!goBlack && figName != "null")
                {
                    //если в ячейке обьект И я пошел БЕЛыми И обьект_ЧЕР, то подсветим
                    if (figName.Contains("ЧЕР")) { toUp.Add(tmp); break; }
                    //если в ячейке обьект И я пошел БЕЛыми И обьект_БЕЛ, то несветим
                    if (figName.Contains("БЕЛ")) break;
                }
            }

            foreach (var bevel in _bevels)
                foreach (string s in toUp)
                    if (bevel.Tag.ToString() == s)
                        bevel.BackColor = Color.Green;
            toUp.Clear();
            #endregion		
            
        }

       
        /// <summary>
        /// Для пешек подсветка хода
        /// </summary>
        private void GoPawn(string btnFigureTag)
        {
            bool goBlack = btnFigureTag.Contains("ЧЕР");
            //заряжаю тег кнопки "ЧЕР_ПЕШКА_A2", получаю индекс [6,0] в массиве
            Point indexStart = newGame.PoiskVMassive(btnFigureTag);//[6,0]
            if (indexStart.X < 0 || indexStart.Y < 0)
                throw new Exception("Error");

            const int up = 0, down = 7, left = 0, right = 7;
            string index = "", figName = "";
            //Черные?
            if (goBlack)
            {
                if((indexStart.X - 1)>=up)
                {
                    figName = newGame.ShowFigName(indexStart.X - 1 + "" + indexStart.Y);
                    index = indexStart.X - 1 + "" + indexStart.Y;
                    /*Цикл выполнит 1 ход (true && false)в верх 
                     * И два хода при условии (true && true)*/
                    int extWhile = 0;
                    do
                    {
                        //есть кто на позиции [X-1;Y]?
                        if (figName == "null")
                        {//нет\\светим\\проверим следующ панель
                            foreach (Bevel bevel in _bevels)
                                if (bevel.Tag.ToString() == index)
                                { bevel.BackColor = Color.Green; break; }
                        } if (figName != "null") break;
                        //сменим позицию и индекс:
/*ПОВЕСИТЬ ПРЕВРАЩЕНИЕ В ДРУГУЮ ФИГУРУ*/if ((indexStart.X - 2) < up) break;
                        figName = newGame.ShowFigName(indexStart.X - 2 + "" + indexStart.Y);
                        index = indexStart.X - 2 + "" + indexStart.Y;
                        extWhile++;
                    } while (extWhile != 2 && !newGame.OneGoFigure(indexStart));//Два хода разрешены?
                }
                
                //верх лево
                index = (indexStart.X - 1) + "" + (indexStart.Y - 1);
                if ((indexStart.X - 1)>=up && (indexStart.Y - 1)>=left)
                {
                    figName = newGame.ShowFigName(index);
                    if (figName != null && figName.Contains("БЕЛ"))
                    {
                        foreach (Bevel bevel in _bevels)
                            if (bevel.Tag.ToString() == index)
                            { bevel.BackColor = Color.Green; break; }
                    }
                }
                //верх право
                index = (indexStart.X - 1) + "" + (indexStart.Y + 1);
                if ((indexStart.X - 1) >= up && (indexStart.Y + 1)<=right)
                {
                    figName = newGame.ShowFigName(index);
                    if (figName != null && figName.Contains("БЕЛ"))
                    {
                        foreach (Bevel bevel in _bevels)
                            if (bevel.Tag.ToString() == index)
                            { bevel.BackColor = Color.Green; break; }
                    } return;
                }
            }
            else//белые
            {
                if ((indexStart.X + 1)<=down)
                {
                    figName = newGame.ShowFigName(indexStart.X + 1 + "" + indexStart.Y);
                    index = indexStart.X + 1 + "" + indexStart.Y;
                    /*Цикл выполнит 1 ход (true && false)в низ 
                     * И два хода при условии (true && true)*/
                    int extWhile = 0;
                    do
                    {
                        //есть кто на позиции [X+1;Y]?
                        if (figName == "null")
                        {//нет\\светим\\проверим следующ панель
                            foreach (Bevel bevel in _bevels)
                                if (bevel.Tag.ToString() == index)
                                { bevel.BackColor = Color.Green; break; }
                        } if (figName != "null") break;
                        //сменим позицию и индекс:
/*ПОВЕСИТЬ ПРЕВРАЩЕНИЕ В ДРУГУЮ ФИГУРУ*/if ((indexStart.X + 2)>down) break;
                        figName = newGame.ShowFigName(indexStart.X + 2 + "" + indexStart.Y);
                        index = indexStart.X + 2 + "" + indexStart.Y;
                        extWhile++;
                    } while (extWhile != 2 && !newGame.OneGoFigure(indexStart));//Два хода разрешены?
                }
                
                //низ лево
                index = (indexStart.X + 1) + "" + (indexStart.Y - 1);
                if((indexStart.X + 1)<=down && (indexStart.Y - 1)>=left)
                {
                    figName = newGame.ShowFigName(index);
                    if (figName != null && figName.Contains("ЧЕР"))
                    {
                        foreach (Bevel bevel in _bevels)
                            if (bevel.Tag.ToString() == index)
                            {bevel.BackColor = Color.Green;break;}
                    }
                }

                //низ право
                index = (indexStart.X + 1) + "" + (indexStart.Y + 1);
                if ((indexStart.X + 1)<=down && (indexStart.Y + 1)<=right)
                {
                    figName = newGame.ShowFigName(index);
                    if (figName != null && figName.Contains("ЧЕР"))
                    {
                        foreach (Bevel bevel in _bevels)
                            if (bevel.Tag.ToString() == index)
                            {bevel.BackColor = Color.Green;break;}
                    }return;
                }
            }

            
        }

        /// <summary>
        /// Нажатие на КНОПКУ-фигуру
        /// </summary>
        private void tbn_Click(object sender, EventArgs e) { xod_Click(sender, e); }

        private static ButtonBase _btnBase;
        /// <summary>
        /// Куда собираемся перейти
        /// </summary>
        private void bevel_Click(object sender, EventArgs e) { xod_Click(sender, e); }

        /// <summary>
        /// Смена текущего положения ФОРМА и МАССИВ
        /// </summary>
        private void perexod(Bevel bvl)
        {
//изменить _btnBase.Tag и Image на выбранную фигуру
            //на форме:
            if(newGame.ShowFigName(bvl.Tag.ToString())=="null")
            {
              ChangeFigurePawnToN(bvl);
                bvl.Controls.Add(_btnBase);
            }
            //в массиве:
            //ЧЕР_ПЕШКА_A2/в/40
            newGame.PerestanovkaVMassive(_btnBase.Tag.ToString(), bvl.Tag.ToString());

            noCheked();
        }

        /// <summary>
        /// Сменить пешку на выбранную - она выжила и дошла до другого края
        /// </summary>
        private void ChangeFigurePawnToN(Bevel bvl)
        {
            var objFigure = _btnBase.Tag.ToString();//"ЧЕР_ПЕШКА_A2"
            string black = objFigure.Contains("ЧЕР") ? "ЧЕР_" : "БЕЛ_";

            Point indexPanel = newGame.coordinate(bvl.Tag.ToString());
            //Это пешка? и панель [0, 0..7] || [7, 0..7])
            if (objFigure.Contains("ПЕШКА") && (indexPanel.X == 0 || indexPanel.X == 7))
            {//MessageBox.Show("Наш клиент");
                //выбираем фигуру:
                _fTransformPawn.ShowDialog();
                //найти кнопку и сменить тег с пешки на выбр фигуру:
                foreach (var @base in _buttons)
                {
                    if (_btnBase.Name == @base.Name)
                    {
                        //проверить уникальность этой фигуры
                        do
                        {//уже есть такой//переназначить Тег
                            _fTransformPawn.UpIncrement();
                            @base.Tag = black + _fTransformPawn.SelectedFigure;//"ЧЕР_КОНЬ_1";
                        } while (Search());
                        break;
                    }
                }
                _btnBase.Tag = black + _fTransformPawn.SelectedFigure;//"ЧЕР_КОНЬ_1";
                _btnBase.Image = ChangeImageBtn(_btnBase.Tag.ToString());
                newGame.TransformPawn(objFigure, _btnBase.Tag.ToString(), indexPanel);
            }
        }

        /// <summary>
        /// Вернет TRUE если такая фигура уже есть
        /// </summary>
        private bool Search()
        {
            string[] Massiv = new string[_buttons.Count];
            int i = 0, j = 0;
            foreach (var ts in _buttons)
            {
                Massiv[j] = ts.Tag.ToString();
                j++;
                for (int e = 0; e < i; e++)
                    if (ts.Tag.ToString().CompareTo(Massiv[e]) == 0)
                    {//Если есть результ, то есть совпадение с текущим значением ts!
                        return true;
                    }
                i++;
            }
            return false;
        }

        /// <summary>
        /// Сменит у кнопки рисунок пешки на другой выбранный
        /// </summary>
        private Image ChangeImageBtn(string name)
        {
//проверить какой пакет установлен на фигурки в меню!
            string[] tmp = name.Split('_');
            if(tmp[0].Contains("ЧЕР"))
            {
                switch (tmp[1])
                {
                    case "btnILaden": return _formMenu.SearchAndTransform("чер_ладья_nn", _StateSelectImgPak);//return Resources.черный_ладья;
                    case "btnIKoni": return _formMenu.SearchAndTransform("чер_конь_nn", _StateSelectImgPak);//return Resources.черный_конь;
                    case "btnISlon": return _formMenu.SearchAndTransform("чер_слон_nn", _StateSelectImgPak);//return Resources.черный_слон;
                    case "btnIFerz": return _formMenu.SearchAndTransform("чер_ферзь_nn", _StateSelectImgPak);//return Resources.черный_ферзь;
                }
            }
            else
            {
                switch (tmp[1])
                {
                    case "btnILaden": return _formMenu.SearchAndTransform("бел_ладья_nn", _StateSelectImgPak);//return Resources.белый_ладья;
                    case "btnIKoni": return _formMenu.SearchAndTransform("бел_конь_nn", _StateSelectImgPak);//return Resources.белый_конь;
                    case "btnISlon": return _formMenu.SearchAndTransform("бел_слон_nn", _StateSelectImgPak);//return Resources.белый_слон;
                    case "btnIFerz": return _formMenu.SearchAndTransform("бел_ферзь_nn", _StateSelectImgPak);//return Resources.белый_ферзь;
                }
            }

            return null;
        }

        //private List<ButtonBase> reBtn = new List<ButtonBase>();
        /// <summary>
        /// Удалить фигуру на форме
        /// </summary>
        private void deliteFigure(ButtonBase когоСнять, string когоПоставить)
        {
            //заряжаю тег кнопки "ЧЕР_СЛОН_A2", получаю индекс [6,0] в массиве
            Point indexStart = newGame.PoiskVMassive(когоСнять.Tag.ToString()); //[6,0]
            //удалить и в массиве
            newGame.DeliteFigure(когоСнять.Tag.ToString(), когоПоставить);
            //удалить на форме (сделать неактивным-невидимым)
            когоСнять.Visible = false;
            когоСнять.Enabled = false;
            //reBtn.Add(когоСнять);
            //ФОРМА: поставить новую фигуру на место-панель битой
            foreach (Bevel bevel in _bevels.Where(bevel => bevel.Tag.ToString() == (indexStart.X + "" + indexStart.Y)))
            {
                foreach (ButtonBase @base in _buttons.Where(@base => @base.Tag.ToString() == когоПоставить))
                {
                    ChangeFigurePawnToN(bevel);
                    bevel.Controls.Add(@base);
                    break;
                }
                break;
            }
            noCheked();

            if(когоСнять.Tag.ToString().Contains("КАРОЛЬ"))
            {
                if (когоСнять.Tag.ToString().Contains("БЕЛ"))
                    _saveToFile.BlackWin += 1;
                MessageBox.Show("КОНЕЦ ИГРЫ");
                //Вызвать статистику
                настройкиToolStripMenuItem_Click(null, null);
            }
        }

        
        
        /// <summary>
        /// Восстановить поле после подсветки хода
        /// </summary>
        private void noCheked()
        {
            foreach (var bevel in _bevels.Where(bevel => bevel != null))
            {
                bevel.BackColor = Color.Transparent;
            }
        }

        /// <summary>
        /// Начать игру заново.
        /// начало игры на чистом поле, сброс предыдущей игры;
        /// </summary>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //сбросить поле с фигурами
            newGame = new clNewGame();
            _saveToFile.Schetchik += 1;

            //сбросить очередность первого хода
            if (_formMenu.IsEvent()) xod.BlackGo = _formMenu.OneGo;
            xod = new clXod(_formMenu.OneGo);
            //сбросить кнопки на форме
            ResetForm();
        }

        /// <summary>
        /// Сбросить все кнопки на исходные места
        /// </summary>
        private void ResetForm()
        {
            this.bevel_A1.Controls.Add(this.btnBL_a1); this.bevel_B2.Controls.Add(this.btnBP_b2);
            this.bevel_C1.Controls.Add(this.btnBS_c1); this.bevel_D2.Controls.Add(this.btnBP_d2);
            this.bevel_E1.Controls.Add(this.btnBF_e1); this.bevel_G1.Controls.Add(this.btnBK_g1);
            this.bevel_H2.Controls.Add(this.btnBP_h2); this.bevel_F2.Controls.Add(this.btnBP_f2);
            this.bevel_G2.Controls.Add(this.btnBP_g2); this.bevel_E2.Controls.Add(this.btnBP_e2);
            this.bevel_C2.Controls.Add(this.btnBP_c2); this.bevel_A2.Controls.Add(this.btnBP_a2);
            this.bevel_B1.Controls.Add(this.btnBK_b1); this.bevel_D1.Controls.Add(this.btnBW_d1);
            this.bevel_F1.Controls.Add(this.btnBS_f1); this.bevel_H1.Controls.Add(this.btnBL_h1);
            this.bevel_A7.Controls.Add(this.btnWP_a7); this.bevel_B7.Controls.Add(this.btnWP_b7);
            this.bevel_C7.Controls.Add(this.btnWP_c7); this.bevel_D7.Controls.Add(this.btnWP_d7);
            this.bevel_F7.Controls.Add(this.btnWP_f7); this.bevel_E7.Controls.Add(this.btnWP_e7);
            this.bevel_H7.Controls.Add(this.btnWP_h7); this.bevel_G7.Controls.Add(this.btnWP_g7);
            this.bevel_H8.Controls.Add(this.btnWL_h8); this.bevel_G8.Controls.Add(this.btnWK_g8);
            this.bevel_F8.Controls.Add(this.btnWS_f8); this.bevel_E8.Controls.Add(this.btnWF_e8);
            this.bevel_D8.Controls.Add(this.btnWW_d8); this.bevel_C8.Controls.Add(this.btnWS_c8);
            this.bevel_A8.Controls.Add(this.btnWL_a8); this.bevel_B8.Controls.Add(this.btnWK_b8);

            foreach (var button in _buttons)
            {
                foreach (var btnDeff in _copyValueObj.ObjValue)
                {
                    if (button.Name == btnDeff.Key && button.Tag.ToString() != btnDeff.Value && btnDeff.Value != null)
                    {
                        button.Tag = btnDeff.Value;
                        button.Image = button.Tag.ToString().Contains("ЧЕР")
                                               ? Resources.черный_пешка : Resources.белый_пешка;
                    }
                }
                button.Enabled = true;
                button.Visible = true;
            }
        }

        /// <summary>
        /// Выход из программы
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) { this.Close(); }

        /// <summary>
        /// сохранение текущей игры в любой момент в файл;
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //сохранить содержимое массива в файл
            //сохранить Кто_ходил_последним
            var saveFileDialog = new SaveFileDialog {Filter = "Текстовые файлы|*.txt|Все файлы|*.*"};
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            var saveData = new List<string>();
            saveData.AddRange(newGame.CopyFiguresDataToList());
            var streamWriter = new StreamWriter(saveFileDialog.FileName);

            streamWriter.WriteLine(xod.BlackGo);

            foreach (string s in saveData)
                streamWriter.WriteLine(s);

            streamWriter.Close();
        }

        /// <summary>
        /// восстановление состояния игры из файла;
        /// </summary>
        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            OpenFileDialog openFileDialog = new OpenFileDialog {Filter = "Текстовые файлы|*.txt|Все файлы|*.*"};
            if(openFileDialog.ShowDialog()!=DialogResult.OK)
                return;

            List<string > loadData = new List<string>();
            StreamReader streamReader = new StreamReader(openFileDialog.FileName);
            //переписать чей Первый_Ход после загрузки
            xod.BlackGo = streamReader.ReadLine().Contains("False")?false:true;

            while (true)
            {
                string str = streamReader.ReadLine();
                if(str==null)break;
                loadData.Add(str);
            }
            streamReader.Close();

            //загрузить из файла массив и поместить его в игру.
            if (loadData.Count > 3) newGame.PastDataListToFiguresArr(loadData);
            else
            {
                MessageBox.Show("Файл повреджен, либо не содержит загрузочных данных.", "Ошибка", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            //расставить фигуры-кнопки на доске ориентируясь только на
            //содержимое загруженого массива
            //на форме:
            RasstanovkaKnopok();
        }

        /// <summary>
        /// Показать подсказку
        /// </summary>
        private void showBall(string typeFigure)
        {
            if(_formMenu.IsShowHelp())
            {
                Balloon b = new Balloon
                {
                    Style = eBallonStyle.Alert,
                    CaptionText = "Недопустимый ход"
                };
                b.MouseHover += new EventHandler(ballon_MouseHover);
                b.MouseLeave += new EventHandler(ballon_MouseLeave);

                switch (typeFigure)
                {//вызвать как ходит фигура
                    case "ПЕШКА":
                        {
                            b.CaptionImage = Resources.pawn128;
                            b.Text = Resources.fMain_showBall_Пешка;
                        } break;
                    case "ЛАДЬЯ":
                        {
                            b.CaptionImage = Resources.rook26;
                            b.Text = Resources.fMain_showBall_Ладья;
                        } break;
                    case "КОНЬ":
                        {
                            b.CaptionImage = Resources.knight48;
                            b.Text = Resources.fMain_showBall_Конь;
                        } break;
                    case "СЛОН":
                        {
                            b.CaptionImage = Resources.bishop48;
                            b.Text = Resources.fMain_showBall_Слон;
                        } break;
                    case "КАРОЛЬ":
                        {
                            b.CaptionImage = Resources.king26;
                            b.Text = Resources.fMain_showBall_Кароль;
                        } break;
                    case "ФЕРЗЬ":
                        {
                            b.CaptionImage = Resources.queen48;
                            b.Text = Resources.fMain_showBall_Ферзь;
                        } break;
                    //вызвать предупреждение
                    case "errBlackGo":
                        {
                            b.CaptionImage = Resources.alert;
                            b.Text = Resources.fMain_showBall_BlackGo;
                        } break;
                    case "errWhiteGo":
                        {
                            b.CaptionImage = Resources.alert;
                            b.Text = Resources.fMain_showBall_WhiteGo;
                        } break;
                    case "errSHAX":
                        {
                            b.CaptionImage = Resources.alert;
                            b.Text = Resources.fMain_showBall_SHAX;
                        } break;
                    case "errNe":
                        {
                            b.CaptionImage = Resources.alert;
                            b.Text = Resources.fMain_showBall_Ne;
                        } break;
                    default: return;
                }

                b.AlertAnimation = eAlertAnimation.TopToBottom;
                b.AutoResize();
                if(_flagCliseBall)
                {
                    b.AutoClose = true;
                    b.AutoCloseTimeOut = 3;
                }
                b.Owner = this;
                b.Show(menuStrip1, false);
            }
            
        }

        private int _StateSelectImgPak = 0;
        private fMenu _formMenu = new fMenu();
        /// <summary>
        /// Открыть окно с настройками
        /// </summary>
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //статистика обновить
            _formMenu.Statistic(_saveToFile.Schetchik);
            //количество выйгрышей обновить
            _formMenu.UpdateLiveChart(_saveToFile.BlackWin);

            _formMenu.ShowDialog();

            //Если текущий неравен предыдущему, то стиль меняем
            if (_formMenu.StateSelectImgPak != _StateSelectImgPak)
                ChangeFiguresStylePak();

            if (_formMenu.BoardImage != null && _formMenu.BoardImage != tableLayoutPanel1.BackgroundImage)
                tableLayoutPanel1.BackgroundImage = _formMenu.BoardImage;

            //очередность хода:
            if(_formMenu.IsEvent()) xod.BlackGo = _formMenu.OneGo;

            if(_formMenu.IsNewKeys)
            {
                _кнопкиУправления.WriteParam(_formMenu._arr);
                _formMenu.IsNewKeys = false;
                NauStateKey();
            }
        }

        /// <summary>
        /// Изменить Image у всех кнопок
        /// </summary>
        private void ChangeFiguresStylePak()
        {
            //перепишем текущий стиль для будущего сравнения
            _StateSelectImgPak = _formMenu.StateSelectImgPak;

            foreach (var button in _buttons)
                button.Image = _formMenu.SearchAndTransform(button.Tag.ToString(), _StateSelectImgPak);
            
        }

        /// <summary>
        /// Чем рулить. Либо дифолтом - с файла, либо назнач в настройках
        /// </summary>
        KeyControlsDeff _кнопкиУправления = new KeyControlsDeff();

        private Bevel _bvlObj;
        /// <summary>
        /// Из чего нажато - отсеиваем кнопы управления(заданы\умолч.) и меняем bevel.border
        /// </summary>
        private void fMain_KeyUp(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;

            switch (key)
            {
                case Keys.Enter://генерим мыху xod_Click(object sender, EventArgs e)
                    //sender as button || bevel//e as Point[x,y]
                    if(_bvlObj!=null) xod_Click(UseEnter(), null);
                    break;
            }
            //Ориентируемся по кодам клавиш
            foreach (KeyValuePair<string, string > s in _keysB)
            {
                if (e.KeyValue.ToString() == s.Value)
                {
                    //Реакция панели на нажатие совпавшей клавиши:
                    ChangeBevelBorder(s);
                    return;
                }
                
            }

            foreach (KeyValuePair<string,string > s in _keysW)
            {
                if (e.KeyValue.ToString() == s.Value)
                {
                    //Реакция панели на нажатие совпавшей клавиши:
                    ChangeBevelBorder(s);
                    return;
                }
            }
            
        }

        /// <summary>
        /// Вернуть object либо Bevel либо ButtonBase 
        /// </summary>
        private object UseEnter()
        {
            //Если на панели есть обьект то вернуть обьект
            string objBtn = newGame.ShowFigName(_bvlObj.Tag.ToString());
            if (objBtn == "null") return _bvlObj;//Иначе вернуть панель
            return _buttons.FirstOrDefault(@base => @base.Tag.ToString() == objBtn);
        }

        private bool _chColor;
        private string _bevelStateIndex;
        /// <summary>
        /// Изменить Визуально активную панель взависимости от нажатой клавы
        /// </summary>
        private void ChangeBevelBorder(KeyValuePair<string,string > keyObject)
        {
            //keyObject даст пару имя.значение - тоесть куда идти и нажата кнопка
            //Сбросить предыдущий стиль панели
            foreach (var bevel in _bevels.Where(bevel => bevel.Tag.ToString() == _bevelStateIndex))
            {
                bevel.BackColor = _chColor ? Color.Green : Color.Transparent;
                break;
            }

            _chColor = false;
            if (_кнопкиУправления.Go(keyObject.Key, _bevelStateIndex) == null) { _bvlObj = null; return; }
            
            _bevelStateIndex = _кнопкиУправления.Go(keyObject.Key, _bevelStateIndex);

            //найти нужную панель и сменить оформление
            //ориентир поиска парам Name из XML файла (up\down\left\right)
            //за счет этого меняем на 1 индекс движения 
            //44-->up-->34
            //44-->down-->54
            foreach (var bevel in _bevels.Where(bevel => bevel.Tag.ToString() == _bevelStateIndex))
            {
                if (bevel.BackColor == Color.Green) _chColor=true;
                bevel.BackColor = Color.Cornsilk;
                _bvlObj = bevel;
                bevel.Focus();
                return;
            }
            _bvlObj = null;
        }

        /// <summary>
        /// Перед закрытием окна делаем сохранение в файл
        /// </summary>
        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //сохранить счетчик в файл
            _saveToFile.Save();
        }

        /// <summary>
        /// Проверить возможность ШАХа фигурой
        /// </summary>
        private void ProverkaNaShax(string btnTagFigure)
        {
            //берем фигуру после действия ход\битьё
            //берем "ЧЕР" или "БЕЛ"
            
            if(_formMenu.ShaxOn)
            {
                if(btnTagFigure.Contains("ЧЕР"))
                {//проверить Угроза Белому королю
                    //берем положение короля БЕЛ в массиве
                    Point indexKing = newGame.PoiskVMassive("БЕЛ_КАРОЛЬ_D8");
                    //могу ли фигурой дойти до панели с королем?
                    switch (newGame.VariantXoda(btnTagFigure, (indexKing.X + "" + indexKing.Y), false))
                    {
                        case "OK": showBall("errSHAX"); break;
                        case "Error": newGameToolStripMenuItem_Click(null, null); break;
                    }
                }
                else
                {//проверить Угроза Черному королю
                    //берем положение короля ЧЕР в массиве
                    Point indexKing = newGame.PoiskVMassive("ЧЕР_КАРОЛЬ_D1");
                    //могу ли фигурой дойти до панели с королем?
                    switch (newGame.VariantXoda(btnTagFigure, (indexKing.X + "" + indexKing.Y), false))
                    {
                        case "OK": showBall("errSHAX"); break;
                        case "Error": newGameToolStripMenuItem_Click(null, null); break;
                    }
                }
            }
        }

        private bool _flagCliseBall = true;
        /// <summary>
        /// Курсор над обьектом Подсказка
        /// </summary>
        private void ballon_MouseHover(object sender, EventArgs e)
        {
            var obj = (sender as Balloon);
            if (obj != null)
            {
                obj.AutoCloseTimeOut += 5;
            }
        }
        /// <summary>
        /// Курсор покинул обьект Подсказка
        /// </summary>
        private void ballon_MouseLeave(object sender, EventArgs e)
        {
            var obj = (sender as Balloon);
            if (obj != null)
            {
                obj.AutoClose = true;
                obj.AutoCloseTimeOut = 1;
                _flagCliseBall = true;
            }
        }

        /// <summary>
        /// Установить кнопки на форме так как они есть в массиве
        /// </summary>
        private void RasstanovkaKnopok()
        {
            foreach (var button in _buttons)
            {
                button.Visible = false;
                button.Enabled = false;
            }

            //проход по панелям
            foreach (var bevel in _bevels)
            {
                string objFigure = newGame.ShowFigName(bevel.Tag.ToString());
                //если в массиве по адресу Тег_панели есть обьект
                //то на панель ставим кнопку с Тегом_имени_обьекта
                //иначе пусто
                if(objFigure!="null")
                    foreach (var button in _buttons.Where(button => button.Tag.ToString() == objFigure))
                    {
                        button.Enabled = true;
                        button.Visible = true;
                        bevel.Controls.Add(button);
                    }
            }

            ChangeFigurePawnToN();
        }

        /// <summary>
        /// Сменить тег кнопки на измененый
        /// </summary>
        private void ChangeFigurePawnToN()
        {
            foreach (var bevel in _bevels)
            {
                string objFigure = newGame.ShowFigName(bevel.Tag.ToString());
                string[] tmp = objFigure.Split('_');
                //если в массиве по адресу Тег_панели есть обьект
                //то на панель ставим кнопку с Тегом_имени_обьекта
                //иначе пусто
                if (objFigure != "null")
                    foreach (var button in _buttons)
                    {
                        if (!button.Enabled && button.Tag.ToString().Contains("ПЕШКА") && tmp != null)
                            switch (tmp[1])
                            {
                                case "btnILaden":
                                    button.Enabled = true;
                                    button.Visible = true;
                                    button.Tag = objFigure;
                                    button.Image = ChangeImageBtn(objFigure);
                                    bevel.Controls.Add(button);
                                    tmp = null;
                                    break;
                                case "btnIKoni":
                                    button.Enabled = true;
                                    button.Visible = true;
                                    button.Tag = objFigure;
                                    button.Image = ChangeImageBtn(objFigure);
                                    bevel.Controls.Add(button);
                                    tmp = null;
                                    break;
                                case "btnISlon":
                                    button.Enabled = true;
                                    button.Visible = true;
                                    button.Tag = objFigure;
                                    button.Image = ChangeImageBtn(objFigure);
                                    bevel.Controls.Add(button);
                                    tmp = null;
                                    break;
                                case "btnIFerz":
                                    button.Enabled = true;
                                    button.Visible = true;
                                    button.Tag = objFigure;
                                    button.Image = ChangeImageBtn(objFigure);
                                    bevel.Controls.Add(button);
                                    tmp = null;
                                    break;
                            }

                    }
            }


            //если обьект есть в массиве, а нет кнопки с таким тегом)
            
            //выбрать неактивную кнопку с тегом ПЕШКА
            //преобразовать ее явно в "ibtn"
            
        }

        /// <summary>
        /// (-1) - текущее_состояние.
        /// (-2) - влево на 1 от текущего
        /// </summary>
        private int _stackIndexer, _i = 1;

        private bool _lastflag=true;
        /// <summary>
        /// Сделать Откат назад/вперед
        /// </summary>
        private void Otkat_Click(object sender, EventArgs e)
        {
            if (_i <= 0) _i = 1;
            
            if (((ToolStripMenuItem)sender).Name == goBack.Name && _stackXodov.GetStringListObject(_stackXodov.CountIndex-1) != null)
            {
                if(_i==1 && _lastflag)
                {
                    _i = _stackXodov.CountIndex - 2;
                    _stackIndexer = _i;
                    _lastflag = false;
                }
                //при откате назат на 1 берем -1_последний элемент стека //и переписываем его в конец стека.
                _stackXodov.AddString(_stackXodov.GetStringListObject(_i), _stackXodov.GetBoolObject(_i));//_stackXodov.Add(_stackXodov.GetIndexObject(_stackIndexer), _stackXodov.GetBoolObject(_stackIndexer));
                //Загружаем игру с конца стека
                NState();
                _i--;
                return;
            }
            //else if (_stackXodov.GetStringListObject(2) != null) _stackIndexer++;

            if ((sender as ToolStripMenuItem).Name == goForward.Name && _stackXodov.GetStringListObject(_stackXodov.CountIndex - 1) != null)
            {
                if (!_lastflag)
                {
                    _i += 2;
                    _lastflag = true;
                }else if(_stackIndexer+1 > _i) _i++;
                //при откате назат на 1 берем -1_последний элемент стека //и переписываем его в конец стека.
                _stackXodov.AddString(_stackXodov.GetStringListObject(_i), _stackXodov.GetBoolObject(_i));//_stackXodov.Add(_stackXodov.GetIndexObject(_stackIndexer), _stackXodov.GetBoolObject(_stackIndexer));
                //Загружаем игру с конца стека
                NState();
            }

        }

        /// <summary>
        /// Восстановить игру из отката
        /// </summary>
        private void NState()
        {
            //загрузить из файла массив и поместить его в игру.
            if (_stackXodov.GetLastListObject() != null)
            {
                //переписать чей Первый_Ход после загрузки
                xod.BlackGo = _stackXodov.GetLastBoolObject();
                //newGame.PastDataListToFiguresArr(_stackXodov.GetLastObject());
                newGame.PastDataListToFiguresArr(_stackXodov.GetLastListObject());
                //расставить фигуры-кнопки на доске ориентируясь только на
                //содержимое загруженого массива
                //на форме:
                RasstanovkaKnopok();
            }
        }


    }
}
