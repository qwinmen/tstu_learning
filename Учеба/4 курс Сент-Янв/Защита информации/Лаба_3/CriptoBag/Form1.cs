using System;
using System.Drawing;
using System.Windows.Forms;
//Алгоритм шифрования - Задача об укладке рюкзака
//http://algoritm-rukzaka.narod.ru/index/0-2
//Модуль шифрования
namespace CriptoBag
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly clCripto _clCripted = new clCripto();

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(slider_CountKey, slider_CountKey.Value.ToString());
            var key = ""; var m = 0; var n = 0;
            _clCripted.Cripto(slider_CountKey.Value, out key, out m, out n);
            textBoxX_Key.Text = key;
            SetReflectionLabelMNvalue(true, m);
            SetReflectionLabelMNvalue(false, n);
        }

        /// <summary>
        /// Задание длины ключа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slider_CountKey_ValueChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(slider_CountKey, slider_CountKey.Value.ToString());
            //новое значение - новая последовательность
            var key = "";
            var m = 0;
            var n = 0;
            _clCripted.Cripto(slider_CountKey.Value, out key, out m, out n);
            textBoxX_Key.Text = key;
            SetReflectionLabelMNvalue(true, m);
            SetReflectionLabelMNvalue(false, n);

            textBox_InputText_TextChanged(sender, e);
        }

        /// <summary>
        /// Установить значения m, n
        /// mSet=true for m.value
        /// </summary>
        private void SetReflectionLabelMNvalue(bool mSet, int value)
        {
            if(mSet) reflectionLabel_m.Text = "<b><font size=\"+3\"><i>m</i> = <font color=\"#B02B2C\">"+value+"</font></font></b>";
            else reflectionLabel_n.Text = "<b><font size=\"+3\"><i>n</i> = <font color=\"#B02B2C\">"+value+"</font></font></b>";
        }

        /// <summary>
        /// Скопировать в буфер закрытый ключ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX_Key_ButtonCustomClick(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(new DataObject(textBoxX_Key.Text));
        }

        /// <summary>
        /// Вводим тексты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_InputText_TextChanged(object sender, EventArgs e)
        {
            if(textBox_InputText.Text.Length<1)return;

            var result = "";    
            //снять текст и отправить на конвертер
            _clCripted.Cripto(textBox_InputText.Text, out result, slider_CountKey.Value);
            textBox_OutText.Text = result;
        }

        /// <summary>
        /// Немного изменять позицию панели ключа при открытии\закрытии
        /// Красивее
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expandablePanel_Key_ExpandedChanging(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            //-10; 90
            expandablePanel_Key.Location = expandablePanel_Key.Expanded ? new Point(-10, 90) : new Point(1, 90);
        }
    }
}
