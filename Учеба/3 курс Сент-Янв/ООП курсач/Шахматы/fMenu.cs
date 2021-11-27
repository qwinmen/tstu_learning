using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Шахматы.Properties;

namespace Шахматы
{
    public partial class fMenu
    {
        public fMenu()
        {
            InitializeComponent();
            OneGo = radioBtn_GoBlack.Checked ? true : false;
            _help = true;

            PodsvetOn = radioButton1.Checked ? true : false;
            ShaxOn = rBtn_OnShax.Checked ? true : false;

            fAbout();
            BoardImage = null;

            reflectionImage5.BackgroundImage = Properties.Resources.fig_deff_mini;
            reflectionImage5.SizeMode = PictureBoxSizeMode.CenterImage;
            lblInfoStyle.Text = Resources.fMenu_SelectedTypeFigures_Click_QwinCor_Style_Pak;
            StateSelectImgPak = 0;
        }

        void fAbout(){textBox1.Select(0, 0);}

        /// <summary>
        /// Кто первый пойдет в игре
        /// </summary>
        public bool OneGo { get; private set; }

        /// <summary>
        /// Ключи на запись:
        /// </summary>
        private bool _keyUpB, _keyDownB, _keyLeftB, _keyRightB,
                     _keyUpW, _keyDownW, _keyLeftW, _keyRightW;
        /// <summary>
        /// public string[] _black = new string[3], _white = new string[3];
        /// </summary>
        public string[,] _arr = new string[2,4];

        /// <summary>
        /// Нажат один из четырех лейблов Черные назначить кнопку
        /// </summary>
        private void blackKeyChenged_Click(object sender, EventArgs e)
        {
            var lblObj = (sender as LabelX);
            //нажали - хочим сменить
            //изменить центральную рактинку типо ЗАПИСЬ
            lblStartWritingKeyBlack.BackgroundImage = global::Шахматы.Properties.Resources.achievement10_rollover;
            //установить флаг на разрешение отлова нажатой клавиши:
            
            if (lblObj != null)
                switch (lblObj.Name)
                {
                    case "lblBlackUp":
                        {
                            _keyUpB = true;
                        }
                        
                        break;
                    case "lblBlackDown":
                        {
                            _keyDownB = true;//_keyDownB = true;
                        }
                        
                        break;
                    case "lblBlackLeft": _keyLeftB = true;
                        break;
                    case "lblBlackRight": _keyRightB = true;
                        break;
                }
        }

        /// <summary>
        /// Нажат один из четырех лейблов Белые назначить кнопку
        /// </summary>
        private void whiteKeyChenged_Click(object sender, EventArgs e)
        {
            lblStartWritingKeyWhite.BackgroundImage = global::Шахматы.Properties.Resources.achievement10_rollover;
            var lblObj = (sender as LabelX);
            //нажали - хочим сменить
            //установить флаг на разрешение отлова нажатой клавиши:

            if (lblObj != null)
                switch (lblObj.Name)
                {
                    case "lblWhiteUp":
                        {
                            _keyUpW = true;
                        }

                        break;
                    case "lblWhiteDown":
                        {
                            _keyDownW = true;//_keyDownB = true;
                        }

                        break;
                    case "lblWhiteLeft": _keyLeftW = true;
                        break;
                    case "lblWhiteRight": _keyRightW = true;
                        break;
                }
        }

        /// <summary>
        /// Само назначение клавиш, покачто их надо кудато запоминать
        /// </summary>
        private void fMenu_KeyUp(object sender, KeyEventArgs e)
        {
            var key = e.KeyValue;
            var tip = e.KeyCode;
            tabControlPanel3.Focus();
            if(_keyUpB)
            {
                lblStartWritingKeyBlack.BackgroundImage = global::Шахматы.Properties.Resources.achievement10;
                toolTipForKeys.SetToolTip(this.lblBlackUp, tip.ToString());
                _keyUpB = !_keyUpB;
                _arr[0, 0] = key.ToString();
                return;
            }
            if (_keyDownB)
            {
                lblStartWritingKeyBlack.BackgroundImage = global::Шахматы.Properties.Resources.achievement10;
                toolTipForKeys.SetToolTip(this.lblBlackDown, tip.ToString());
                _keyDownB = !_keyDownB;
                _arr[0, 1] = key.ToString();
                return;
            }
            if (_keyLeftB)
            {
                lblStartWritingKeyBlack.BackgroundImage = global::Шахматы.Properties.Resources.achievement10;
                toolTipForKeys.SetToolTip(this.lblBlackLeft, tip.ToString());
                _keyLeftB = !_keyLeftB;
                _arr[0, 2] = key.ToString();
                return;
            }
            if (_keyRightB)
            {
                lblStartWritingKeyBlack.BackgroundImage = global::Шахматы.Properties.Resources.achievement10;
                toolTipForKeys.SetToolTip(this.lblBlackRight, tip.ToString());
                _keyRightB = !_keyRightB;
                _arr[0, 3] = key.ToString();
                return;
            }

            #region white if
            if (_keyUpW)
            {
                lblStartWritingKeyWhite.BackgroundImage = global::Шахматы.Properties.Resources.achievement10;
                toolTipForKeys.SetToolTip(this.lblWhiteUp, tip.ToString());
                _keyUpW = !_keyUpW;
                _arr[1, 0] = key.ToString();
                return;
            }
            if (_keyDownW)
            {
                lblStartWritingKeyWhite.BackgroundImage = global::Шахматы.Properties.Resources.achievement10;
                toolTipForKeys.SetToolTip(this.lblWhiteDown, tip.ToString());
                _keyDownW = !_keyDownW;
                _arr[1, 1] = key.ToString();
                return;
            }
            if (_keyLeftW)
            {
                lblStartWritingKeyWhite.BackgroundImage = global::Шахматы.Properties.Resources.achievement10;
                toolTipForKeys.SetToolTip(this.lblWhiteLeft, tip.ToString());
                _keyLeftW = !_keyLeftW;
                _arr[1, 2] = key.ToString();
                return;
            }
            if (_keyRightW)
            {
                lblStartWritingKeyWhite.BackgroundImage = global::Шахматы.Properties.Resources.achievement10;
                toolTipForKeys.SetToolTip(this.lblWhiteRight, tip.ToString());
                _keyRightW = !_keyRightW;
                _arr[1, 3] = key.ToString();
                return;
            }
            #endregion
        
        }

        /// <summary>
        /// Вернет true при назначении новых кнопок
        /// </summary>
        public bool IsNewKeys { get; set; }
        /// <summary>
        /// Если сменилось изображение, то было переназначение кнопок управления
        /// </summary>
        private void lblStartWritingKeyBlack_BackgroundImageChanged(object sender, EventArgs e)
        {
            IsNewKeys = true;
        }

        /// <summary>
        /// Изменен порядок ходов Ч\Б
        /// </summary>
        private void radioBtn_GoBlack_CheckedChanged(object sender, EventArgs e)
        {
            OneGo = radioBtn_GoBlack.Checked;
            _state = true;
        }

        private bool _state;
        /// <summary>
        /// True если изменилось значение выбора очередности хода
        /// </summary>
        public bool IsEvent() {return _state;}

        private bool _help;
        /// <summary>
        /// True Включено отображение подсказок
        /// </summary>
        public bool IsShowHelp() {return _help;}

        private void rBtn_OnHelp_CheckedChanged(object sender, EventArgs e)
        {
            _help = rBtn_OnHelp.Checked;
        }

        /// <summary>
        /// Обновить данные на форме статистики
        /// </summary>
        internal void Statistic(int count)
        {
            lbl_vsegoIgr.Text = count.ToString();
        }

        /// <summary>
        /// Обновить состояние графиков статистики Ч\Б
        /// </summary>
        internal void UpdateLiveChart(int countBlackWin)
        {
            microChart1.DataPoints = new List<double>(new double[] { 1, 32, 30, 20, 55, 66 });
            microChart2.DataPoints = new List<double>(new double[] { 99, 68, 70, 80, 45, 34 });

            int count = 0;//колич игр
            if (!string.IsNullOrEmpty(lbl_vsegoIgr.Text))
                count = Convert.ToInt32(lbl_vsegoIgr.Text);
            //колич побед Черных
            try
            {
                int winB = (countBlackWin * 100) / count;
                int winW = ((count - countBlackWin) * 100) / count;
                microChart1.DataPoints.Add(winB);
                microChart2.DataPoints.Add(winW);
            }
            catch (DivideByZeroException)
            {
                int winB = (countBlackWin * 100) / 1;
                int winW = ((count - countBlackWin) * 100) / 1;
                microChart1.DataPoints.Add(winB);
                microChart2.DataPoints.Add(winW);
            }
            
            microChart1.InvalidateChart(true);
            microChart2.InvalidateChart(true);
        }

        /// <summary>
        /// True включает подсветку хода
        /// </summary>
        public bool PodsvetOn { get; private set; }
        
        /// <summary>
        /// Подсвечивать ходы?
        /// </summary>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PodsvetOn = radioButton2.Checked;
            PodsvetOn = radioButton1.Checked;
        }

        /// <summary>
        /// True если включено отслеживание ШАХа
        /// </summary>
        public bool ShaxOn {get; private set; }
        
        /// <summary>
        /// Отслеживать угрозу королю в виде ШАХа?
        /// </summary>
        private void rBtn_OnShax_CheckedChanged(object sender, EventArgs e)
        {
            ShaxOn = rBtn_OffShax.Checked;
            ShaxOn = rBtn_OnShax.Checked;
        }

        private clImagePakFigures _imgNumTypePak = new clImagePakFigures(0);
        /// <summary>
        /// Клик по набору фигурок, смена изображение в reflectionImage5
        /// Выставляем набор фигурок.
        /// </summary>
        private void SelectedTypeFigures_Click(object sender, EventArgs e)
        {
            var btnItm = sender as ButtonItem;
            
            if(btnItm!=null)
                switch (btnItm.Tag.ToString())
                {
                    case "0"://fig_deff.png
                        _imgNumTypePak = new clImagePakFigures(0);
                        FigImgPak = new Dictionary<string, Image>(_imgNumTypePak.ImgPak);

                        reflectionImage5.BackgroundImage = Properties.Resources.fig_deff_mini;
                        lblInfoStyle.Text = Resources.fMenu_SelectedTypeFigures_Click_QwinCor_Style_Pak;
                        StateSelectImgPak = 0;
                        break;
                    case "1"://fig1.png
                        _imgNumTypePak = new clImagePakFigures(1);
                        FigImgPak = new Dictionary<string, Image>(_imgNumTypePak.ImgPak);

                        reflectionImage5.BackgroundImage = Properties.Resources.fig1;
                        lblInfoStyle.Text = Resources.fMenu_SelectedTypeFigures_Click_Korolev_Style_Pak;
                        StateSelectImgPak = 2;
                        break;
                    case "2"://fig_mini.png
                        _imgNumTypePak = new clImagePakFigures(2);
                        FigImgPak = new Dictionary<string, Image>(_imgNumTypePak.ImgPak);

                        reflectionImage5.BackgroundImage = Properties.Resources.fig_mini;
                        lblInfoStyle.Text = Resources.fMenu_SelectedTypeFigures_Click_Korolev_Style_Pak;
                        StateSelectImgPak = 1;
                        break;
                }
            else
            {
                var tmp = sender.ToString();
                _imgNumTypePak = new clImagePakFigures(0);
                FigImgPak = new Dictionary<string, Image>(_imgNumTypePak.ImgPak);
                StateSelectImgPak = 0;
            }
        }

        /// <summary>
        /// тег бел_пешка_а7 переделать в бел_пешка+индекс
        /// найти и вернуть
        /// </summary>
        internal Image SearchAndTransform(string btnTeg, int index)
        {
            if(FigImgPak == null)
                SelectedTypeFigures_Click("--", null);

            string tmp;
            if(index > 0) tmp = (btnTeg.Remove(btnTeg.LastIndexOf('_'))) + index;
            else tmp = (btnTeg.Remove(btnTeg.LastIndexOf('_')));

            if (!FigImgPak.ContainsKey(tmp.ToLower()))
            {
                string[] arr = btnTeg.Split('_');
                tmp = arr[0] + '_' + _imgNumTypePak.TransformToAssociativFig(arr[1]) + index;
            }
            
            return (from image in FigImgPak where image.Key == tmp.ToLower() select image.Value).FirstOrDefault();
        }

        

        /// <summary>
        /// Передать пакет фигурок
        /// </summary>
        private Dictionary<string, Image> FigImgPak { get; set; }

        /// <summary>
        /// Один из набора radionButton в положении true
        /// Выставляем доску
        /// </summary>
        private void rbSelectedBoadrType_Click(object sender, EventArgs e)
        {
            var checkRbtn = (sender as RadioButton);

            if(checkRbtn!=null)
                switch (checkRbtn.Tag.ToString())
                {
                    case "0": BoardImage = Properties.Resources.board_deff;
                        break;
                    case "1": BoardImage = Properties.Resources.board;
                        break;
                    case "2": BoardImage = Properties.Resources.board1;
                        break;
                    case "3": BoardImage = Properties.Resources.board2;
                        break;
                }
            else
            {
                var checkImage = (sender as ReflectionImage);
                if (checkImage != null)
                    switch (checkImage.Tag.ToString())
                    {
                        case "0": BoardImage = Properties.Resources.board_deff;
                            rb_BoardStyleDeff.Checked = true;
                            break;
                        case "1": BoardImage = Properties.Resources.board;
                            rb_BoardStyle_0.Checked = true;
                            break;
                        case "2": BoardImage = Properties.Resources.board1;
                            rb_BoardStyle_1.Checked = true;
                            break;
                        case "3": BoardImage = Properties.Resources.board2;
                            rb_BoardStyle_2.Checked = true;
                            break;
                    }
            }
        }


        /// <summary>
        /// Передаем выставленное изображение доски
        /// </summary>
        internal Image BoardImage { get; private set; }

        /// <summary>
        /// Дабы не напрягать проц, делаем флаг на запрос "нужна смена пакета"
        /// </summary>
        internal int StateSelectImgPak { get; private set; }

    }

}
