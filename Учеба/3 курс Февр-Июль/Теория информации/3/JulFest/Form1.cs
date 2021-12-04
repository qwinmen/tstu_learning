using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using heaparessential.Controls;

namespace JulFest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

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
                pnlDragDrop.Left = pnlDragDrop.Location.X + (e.Location.X - _startDragPoint.X);
                pnlDragDrop.Top = pnlDragDrop.Location.Y + (e.Location.Y - _startDragPoint.Y);
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
                panel1.Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Храним текст для кодирования
        /// </summary>
        private string _txtIn;

        private clCoder _coder;

        /// <summary>
        /// Нажали ОК, снять текст для кодирования
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            //снять текст
            _txtIn = txtInput.Text;
            //подсчитать сколько бит на строку
            label1.Text = (_txtIn.Length * 8) + " bit";
            label1.BackColor = Color.Transparent;

            if (checkBoxInptCod.Checked)
            {//если будем сжимать то:
                //определить частоты встречаемости каждой буквы
                _coder = new clCoder(_txtIn);
                //загрузить результат в таблицу на форме
                LoadЧастотыTab();
                //загрузить результат в таблицу на форме
                LoadСимволЦепьTab();
                //перевести тексты в цепочки
                ConverterStr();
            }
            else
            {//надо используя на входе цепочки через пробел
                //получить на выходе строку
                Decoder(_txtIn);
            }

        }

        /// <summary>
        /// По цепочкам декодировать строку
        /// </summary>
        private void Decoder(string txtIn)
        {
            if (_coder == null)
            {
                label1.BackColor = Color.Red;
                label1.Text = "Not trees!";
                return;
            }

            textBoxX1.Text = "";
            var arr = txtIn.Split(' ');
            int index = 0;
            string strOut = "";

            for (int i = 0; i < arr.Length; i++)
            {
                var tmp = arr[i];
                index += tmp.Length;
                if (tmp == "") continue;
                foreach (KeyValuePair<Tree, string> keyValuePair in _coder.СимволЦепь)
                {
                    if (tmp == keyValuePair.Value)
                    {
                        strOut += keyValuePair.Key.Str;
                        break;
                    }
                }
            }
            label1.Text = index + " bit";
            textBoxX1.Text = strOut;
            label2.Text = (strOut.Length * 8) + " bit";
        }

        /// <summary>
        /// Заполнить текстбокс переводом
        /// </summary>
        private void ConverterStr()
        {
            textBoxX1.Text = "";

            string strIn = txtInput.Text;
            var strOut = "";
            var index = 0;
            for (int i = 0; i < strIn.Length; i++)
            {
                var tmp = strIn[i].ToString();
                foreach (KeyValuePair<Tree, string> keyValuePair in _coder.СимволЦепь)
                {
                    if (keyValuePair.Key.Str == tmp)
                    {
                        index += keyValuePair.Value.Length;
                        strOut += keyValuePair.Value + " ";
                        break;
                    }
                }
            }
            textBoxX1.Text = strOut;
            label2.Text = index + " bit";
        }

        /// <summary>
        /// Заполнить таблицу частот символов в сообщении
        /// </summary>
        private void LoadЧастотыTab()
        {
            //Очистить содержимое в таблице AdvTree
            advTree1.ClearAndDisposeAllNodes();

            foreach (KeyValuePair<string, int> keyValuePair in _coder.Частоты)
            {
                Node node = new Node((keyValuePair.Key == " " ? "㏚" : keyValuePair.Key));
                node.Cells.Add(new Cell(keyValuePair.Value.ToString()));

                advTree1.Nodes.Add(node);
            }
        }

        /// <summary>
        /// Заполнить таблицу символ=цепочка
        /// </summary>
        private void LoadСимволЦепьTab()
        {
            //Очистить содержимое в таблице AdvTree
            advTree2.ClearAndDisposeAllNodes();

            foreach (KeyValuePair<Tree, string> keyValuePair in _coder.СимволЦепь)
            {
                var tmp = keyValuePair.Key;
                Node node = new Node((keyValuePair.Key.Str == " " ? "㏚" : keyValuePair.Key.Str));
                node.Cells.Add(new Cell(keyValuePair.Value));

                advTree2.Nodes.Add(node);
            }
        }








        
    }
}
