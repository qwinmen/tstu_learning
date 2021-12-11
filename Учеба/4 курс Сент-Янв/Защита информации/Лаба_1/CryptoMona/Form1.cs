using System;
using System.Drawing;
using System.Windows.Forms;
//Реализовать методы шифрования текста:
//-Атбаш
//-Магический квадрат 4Х4
//-Гаммирование модуль N
//-ADFGX
namespace CryptoMona
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            _clAtbash = new clAtbash("");
            
        }
        
        private clAtbash _clAtbash;
        private clMagicQuad _clMagicQuad;
        private clGammaN _clGammaN;
        private clAdfgx _clAdfgx;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //грузим буквы
            lbl_Alfavit.Text = _clAtbash.StrAlf(radioButton_Ru.Checked ? "ru" : "en");
            
            //Числовая последовательность для маг квадрата
            cbox_QuadRen.SelectedIndex = 0;
        }

        /// <summary>
        /// Выбрали алфавит
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_Ru_CheckedChanged(object sender, EventArgs e)
        {
            //обновить буквы
            lbl_Alfavit.Text = _clAtbash.StrAlf(radioButton_Ru.Checked ? "ru" : "en");
        }

        /// <summary>
        /// Вводим тексты и анализируем
        /// </summary>
        private void txtbx_Input_TextChanged(object sender, EventArgs e)
        {
            //передать всё подрят
            _clAtbash.Analiz(((TextBox)sender).Text);
            txtbx_Out.Text = _clAtbash.OutString;
        }

        /// <summary>
        /// Поставить фокус на textBox
        /// </summary>
        private void Form1_Shown(object sender, EventArgs e)
        {
            txtbx_Input.Focus();
        }

        /// <summary>
        /// Активировать метод Магический квадрат
        /// </summary>
        private void sTabItem2_Click(object sender, EventArgs e)
        {
            //передать обьект в класс
            _clMagicQuad = new clMagicQuad(heaparGrid1, cbox_QuadRen.SelectedItem);
            //вывести заполненый обьект
            heaparGrid1 = _clMagicQuad.quadOut;
            //обновить обьект
            heaparGrid1.Invalidate();
        }

        /// <summary>
        /// Выбрана другая числовая последовательность для маг квадрата
        /// </summary>
        private void cbox_QuadRen_SelectedIndexChanged(object sender, EventArgs e)
        {
            sTabItem2_Click(sender, e);
        }

        /// <summary>
        /// Изменения в txtBox_QuadIn
        /// </summary>
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            //установить лимит на количество знаков
            gaugeControl1.CircularScales[0].Pointers[0].Value = txtBox_QuadIn.TextLength;
        }

        /// <summary>
        /// Нажата кнопка ОК для выполнения шифровки
        /// </summary>
        private void txtBox_QuadIn_ButtonCustomClick(object sender, EventArgs e)
        {
            //передать текст в класс для заполнения таблицы
            _clMagicQuad.SetCrypto(txtBox_QuadIn.Text, heaparGrid2);
            //Вывести результат в текстбокс
            txtBox_QuadOut.Text = _clMagicQuad.TextOut;

            //обновить контрол
            heaparGrid2.Invalidate();
        }

        //перетаскмвание панели
        #region Panel Drag Drop

        private Boolean _dragging;
        private Point _startDragPoint;

        /// <summary>
        /// Нажатие
        /// </summary>
        private void pnlDragDrop_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _startDragPoint = e.Location;
        }

        /// <summary>
        /// Перемещение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlDragDrop_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                ((Control)sender).Left = ((Control)sender).Location.X + (e.Location.X - _startDragPoint.X);
                ((Control)sender).Top = ((Control)sender).Location.Y + (e.Location.Y - _startDragPoint.Y);
            }
        }

        /// <summary>
        /// Освобождение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlDragDrop_MouseUp(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                _dragging = false;
                bevel_GMenu.Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Изменился режим работ гаммирования
        /// </summary>
        private void checkBox_GCriptMode_CheckedChanged(object sender, EventArgs e)
        {
            //сменить подсказку
            toolTip_GMode.SetToolTip(this.checkBox_GCriptMode,
                                     checkBox_GCriptMode.Checked ? "Выключить расшифровку?" : "Включить расшифровку?");
        }

        /// <summary>
        /// Снять текст гаммирования
        /// </summary>
        private void txtBox_Gin_TextChanged(object sender, EventArgs e)
        {
            //проверить введен ли ключ,
            //если его нет в поле, то не обрабатывать тексты
            if (txtBox_GKey.Text.Length < 1) return;
            //Выполнить шифровку//Вывести результат
            txtBox_Gout.Text = _clGammaN.CriptoTextIn(txtBox_Gin.Text, txtBox_GKey.Text, checkBox_GCriptMode.Checked);
            
            
        }

        /// <summary>
        /// Ввели\Изменили ключ
        /// </summary>
        private void txtBox_GKey_ButtonCustomClick(object sender, EventArgs e)
        {
            if (txtBox_GKey.Text.Length < 1) return;
            //назначена новая гамма
            //analiz:
            txtBox_Gout.Text = _clGammaN.CriptoTextIn(txtBox_Gin.Text, txtBox_GKey.Text, checkBox_GCriptMode.Checked);
        }

        /// <summary>
        /// Gamma N
        /// </summary>
        private void sTabItem3_Click(object sender, EventArgs e)
        {
            _clGammaN = new clGammaN(int.Parse(reflectionLabel_GN.Tag.ToString()));
        }

        private bool _state = false;
        /// <summary>
        /// tab ADFGX
        /// </summary>
        private void sTabItem4_Click(object sender, EventArgs e)
        {
            //Заполнить алфавит//Сгенерировать рандом
            if (_state) return;

            _state = !_state;
            _clAdfgx = new clAdfgx();
            buttonItem_ARandom_Click(sender, e);
        }

        /// <summary>
        /// Кнопка рандом
        /// </summary>
        private void buttonItem_ARandom_Click(object sender, EventArgs e)
        {
            //Очистить ячейки
            listView_Aalf.Items.Clear();
            //Передать обьект для изменений
            listView_Aalf = _clAdfgx.ListAlf(listView_Aalf);
        }

        /// <summary>
        /// Ввели ключ - кнопка Ок
        /// </summary>
        private void textBoxItem_AKey_ButtonCustomClick(object sender, EventArgs e)
        {
            if (textBox_AtextIn.Text.Length < 3 || (textBoxItem_AKey.Text.Length < 1)) return;
            //передать на обработку в класс
            textBox_Aout.Text = _clAdfgx.Cripton(textBox_AtextIn.Text, textBoxItem_AKey.Text, switchButtonItem_ACripto.Value);
        }

        /// <summary>
        /// Вводим текст для шифрования
        /// </summary>
        private void textBox_AtextIn_TextChanged(object sender, EventArgs e)
        {
            if (textBox_AtextIn.Text.Length < 3 || textBoxItem_AKey.Text.Length < 1) return;
            textBox_Aout.Text = _clAdfgx.Cripton(textBox_AtextIn.Text, textBoxItem_AKey.Text, switchButtonItem_ACripto.Value);
        }





    }
}
