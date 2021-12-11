using System;
using System.Drawing;
using System.Windows.Forms;
using AdvButton;
//Алгоритм дешифрования - Задача об укладке рюкзака
//http://algoritm-rukzaka.narod.ru/index/0-5
//Модуль дешифрования
namespace DeCriptoBag
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private clDeCropto _clDecript = new clDeCropto();

        /// <summary>
        /// При изменениях высоты формы перемещать кнопки управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            expandablePanel_Key.Expanded = false;
            expandablePanel_M.Expanded = false;
            expandablePanel_N.Expanded = false;

            roundButton_ClosedKey.Top = this.ClientSize.Height / 3 / 2 - roundButton_ClosedKey.Height/2;
            roundButton_n.Top = this.ClientSize.Height / 2 - roundButton_n.Height/2;
            roundButton_m.Top = roundButton_n.Top + (roundButton_n.Top - roundButton_ClosedKey.Top);
        }

        /// <summary>
        /// Установть индикатор на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roundButton_ClosedKey_Click(object sender, EventArgs e)
        {
            switch (((RoundButton) sender).Tag.ToString())
            {
                case "1":
                    stepIndicator1.CurrentStep = 1;
                    expandablePanel_Key.Location = new Point(roundButton_ClosedKey.Location.X + 24, roundButton_ClosedKey.Location.Y);
                    expandablePanel_N.Expanded = false;
                    expandablePanel_M.Expanded = false;
                    expandablePanel_Key.BringToFront();
                    expandablePanel_Key.Expanded = true;
                    break;
                case "2":
                    stepIndicator1.CurrentStep = 2;
                    expandablePanel_M.Location = new Point(roundButton_n.Location.X + 24, roundButton_n.Location.Y);
                    expandablePanel_Key.Expanded = false;
                    expandablePanel_N.Expanded = false;
                    expandablePanel_M.BringToFront();
                    expandablePanel_M.Expanded = true;
                    break;
                case "3":
                    stepIndicator1.CurrentStep = 3;
                    expandablePanel_N.Location = new Point(roundButton_m.Location.X + 24, roundButton_m.Location.Y);
                    expandablePanel_M.Expanded = false;
                    expandablePanel_Key.Expanded = false;
                    expandablePanel_N.BringToFront();
                    expandablePanel_N.Expanded = true;
                    break;
            }
        }

        /// <summary>
        /// Сворачиваем панель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expandablePanel_M_ExpandedChanging(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            
            if (expandablePanel_M.Expanded)
            {
                expandablePanel_M.SendToBack();
                expandablePanel_M.Location = new Point(roundButton_n.Location.X, roundButton_n.Location.Y);
            }
            
            if (expandablePanel_N.Expanded)
            {
                expandablePanel_N.SendToBack();
                expandablePanel_N.Location = new Point(roundButton_n.Location.X, roundButton_m.Location.Y);
            }
            
            if (expandablePanel_Key.Expanded)
            {
                expandablePanel_Key.SendToBack(); 
                expandablePanel_Key.Location = new Point(roundButton_n.Location.X, roundButton_ClosedKey.Location.Y);
            }
            
        }

        /// <summary>
        /// Ввод ключа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_KeyInput_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Ввод числа M
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_MInput_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Ввод взаимно простого N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_NInput_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Клик по полю ввода текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextInput_Click(object sender, EventArgs e)
        {
            expandablePanel_M_ExpandedChanging(sender, null);
        }

        /// <summary>
        /// Ввели текст для декодирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextInput_TextChanged(object sender, EventArgs e)
        {
            var n = -1; var m = -1;
            if (int.TryParse(textBox_NInput.Text, out n) && int.TryParse(textBox_MInput.Text, out m))
                textBoxX_OutText.Text = _clDecript.Decript(n, m, textBox_TextInput.Text, textBox_KeyInput.Text);
        }



    }
}
