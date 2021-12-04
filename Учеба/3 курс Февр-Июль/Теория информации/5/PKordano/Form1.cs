using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PKordano
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int _k;

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            textBox_Решето.Text = "";
            _nline = 0;
            if(textBox_InputTXT.Text.Length<1)return;

            var k = 1;
            //определить количество клеток у стороны
            while (4*(k*k) < textBox_InputTXT.Text.Length)
                k++;

            _k = k;
            label1.Text = @"                                                     Асимптотическая сложность: " +
                          Math.Pow(4, Math.Pow(k, 2));
            
            toolStripStatusLabel1.Text = @"Длина текста " + textBox_InputTXT.Text.Length +
                                         string.Format(". Стороны решётки {0} на {0}", (k + k));
            
            //строим квадрат со стороной k, вписываем в него числа [1..k*k]
            var quad = new int[k, k];
            var tmp = 1;
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    quad[i, j] = tmp;
                    tmp++;
                }
            }
            //вывод на форму
            AddArray(quad, k);

            //поворачиваем квадрат по часовой стрелке
            var q2 = RotateQuad(quad, k);
            //вывод на форму
            AddArray(q2, k);

            //поворачиваем квадрат по часовой стрелке
            var q3 = RotateQuad(q2, k);

            //поворачиваем квадрат по часовой стрелке
            var q4 = RotateQuad(q3, k);
            //вывод на форму
            AddArray(q4, k);
            //вывод на форму
            AddArray(q3, k);
            
            _1 = quad;
            _2 = q2;
            _3 = q3;
            _4 = q4;

            //разбить входную строку на подстроки длиной k
            var strArr = SplitInputText(textBox_InputTXT.Text, k);
            //вписать строки в позиции _arrRnd[]
            if (_arrRnd!=null)
            {
                Cripto(_arrRnd, strArr);
                TextOut();
            }

        }

        /// <summary>
        /// Вывод шифра на форму
        /// </summary>
        private void TextOut()
        {
            textBox_OutText.Text = @"";

            for (int d = 0; d < _k; d++)
            {
                for (int i = 0; i < _k; i++)
                    if (_1[d, i] > _k) textBox_OutText.Text += (char)_1[d, i] + @"▐";
                    else textBox_OutText.Text += _1[d, i] + @"▐";
                for (int i = 0; i < _k; i++)
                    if (_2[d, i] > _k) textBox_OutText.Text += (char)_2[d, i] + @"▐";
                    else textBox_OutText.Text += _2[d, i] + @"▐";
                textBox_OutText.Text += Environment.NewLine;
            }

            for (int d = 0; d < _k; d++)
            {
                for (int i = 0; i < _k; i++)
                    if (_4[d, i] > _k) textBox_OutText.Text += (char)_4[d, i] + @"▐";
                    else textBox_OutText.Text += _4[d, i] + @"▐";
                for (int i = 0; i < _k; i++)
                    if (_3[d, i] > _k) textBox_OutText.Text += (char)_3[d, i] + @"▐";
                    else textBox_OutText.Text += _3[d, i] + @"▐";
                textBox_OutText.Text += Environment.NewLine;
            }

        }

        private int[,] _1;
        private int[,] _2;
        private int[,] _3;
        private int[,] _4;

        /// <summary>
        /// Накладываем код на строку
        /// </summary>
        private void Cripto(int[] arrCod, string[,] strArr)
        {
            
            //первое наложение (без поворота)
            for (int i = 0; i < arrCod.Length; i++)
            {
                //область изменения
                int pos = arrCod[i];
                //вписать на место порядковой i-цифры букву из strArr[]
                var str = strArr[0, i];
                if (!string.IsNullOrEmpty(str))
                    Rest(pos, str, i + 1);
            }

            //4->1//1->2//2->3//3->4
            for (int i = 0; i < arrCod.Length; i++)
            {
                //область изменения
                int pos = arrCod[i];
                switch (pos)
                {
                    case 4: pos = pos == 4 ? 1 : pos; break;
                    case 1: pos = pos == 1 ? 2 : pos; break;
                    case 2: pos = pos == 2 ? 3 : pos; break;
                    case 3: pos = pos == 3 ? 4 : pos; break;
                }
                //вписать на место порядковой i-цифры букву из strArr[]
                var str = strArr[1, i];
                if (!string.IsNullOrEmpty(str))
                    Rest(pos, str, i + 1);
            }

            //4->2//1->3//2->4//3->1
            for (int i = 0; i < arrCod.Length; i++)
            {
                //область изменения
                int pos = arrCod[i];
                switch (pos)
                {
                    case 4: pos = pos == 4 ? 2 : pos; break;
                    case 1: pos = pos == 1 ? 3 : pos; break;
                    case 2: pos = pos == 2 ? 4 : pos; break;
                    case 3: pos = pos == 3 ? 1 : pos; break;
                }
                //вписать на место порядковой i-цифры букву из strArr[]
                var str = strArr[2, i];
                if (!string.IsNullOrEmpty(str))
                    Rest(pos, str, i + 1);
            }

            //4->2//1->3//2->4//3->1
            for (int i = 0; i < arrCod.Length; i++)
            {
                //область изменения
                int pos = arrCod[i];
                switch (pos)
                {
                    case 4: pos = pos == 4 ? 3 : pos; break;
                    case 1: pos = pos == 1 ? 4 : pos; break;
                    case 2: pos = pos == 2 ? 1 : pos; break;
                    case 3: pos = pos == 3 ? 2 : pos; break;
                }
                //вписать на место порядковой i-цифры букву из strArr[]
                var str = strArr[3, i];
                if (!string.IsNullOrEmpty(str))
                    Rest(pos, str, i + 1);
            }


        }

        /// <summary>
        /// стремный код
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="str"></param>
        /// <param name="index"></param>
        private void Rest(int pos, string str, int index)
        {
            if (pos == 1)
            {
                for (int i = 0; i < _k; i++)
                {
                    for (int j = 0; j < _k; j++)
                    {
                        if(_1[i, j] == index)
                            _1[i, j] = Convert.ToChar(str);
                    }
                }
            }
            if (pos == 2)
            {
                for (int i = 0; i < _k; i++)
                {
                    for (int j = 0; j < _k; j++)
                    {
                        if(_2[i, j] == index)
                            _2[i, j] = Convert.ToChar(str);
                    }
                }
            }
            if (pos == 3)
            {
                for (int i = 0; i < _k; i++)
                {
                    for (int j = 0; j < _k; j++)
                    {
                        if(_3[i, j] == index)
                            _3[i, j] = Convert.ToChar(str);
                    }
                }
            }
            if (pos == 4)
            {
                for (int i = 0; i < _k; i++)
                {
                    for (int j = 0; j < _k; j++)
                    {
                        if (_4[i, j] == index)
                            _4[i, j] = Convert.ToChar(str);
                    }
                }
            }
        }

        /// <summary>
        /// Разбить строку на части длиной k*k
        /// </summary>
        /// <param name="str"></param>
        /// <param name="k"></param>
        private string[,] SplitInputText(string str, int k)
        {
            //if(_arrRnd==null) return;

            var chrArr = new string[k+k,k*k];
            var indx = 0;
            int ii, jj;

            for (int i = 0; ; i++)
            {
                for (int j = 0; j < k*k; j++)
                {
                    if (indx < str.Length) chrArr[i, j] = str[indx].ToString();
                    else
                    {
                        ii = i;
                        jj = j;
                        if(jj!=0)
                            for (int ie = jj; ie < k * k; ie++)
                            {
                                chrArr[ii, ie] = "•";
                            }
                        return chrArr;
                    }
                    indx++;
                }
            }

        }

        private int _nline;
        /// <summary>
        /// Вывод на форму
        /// </summary>
        private void AddArray(int[,] arr, int k)
        {
            foreach (int i in arr)
            {
                if (_nline > 1)
                {
                    textBox_Решето.Text += Environment.NewLine;
                    _nline = 0;
                }
                textBox_Решето.Text += i + @"▐";
            }
            _nline++;
        }

        /// <summary>
        /// Поворот входного массива по часовой стрелке
        /// </summary>
        /// <returns></returns>
        private int[,] RotateQuad(int [,] arr, int k)
        {
            var extArr = new int[k,k];
            //столбец переписать в строку
            for (int i = 0; i < k; i++)
            {//столбец
                for (int j = 0, r = k-1; j < k; j++, r--)
                {//строки
                    extArr[i, r] = arr[j, i];
                }
            }

            return extArr;
        }

        Random _rnd = new Random();
        private bool flagRnd = false;
        private int[] _arrRnd;

        /// <summary>
        /// Разбросать в четыре области решетки цифры от 1 до k*k
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Rnd_Click(object sender, EventArgs e)
        {
            flagRnd = !flagRnd;
            toolStripStatusLabel2.Text = " Код ≈";

            _arrRnd = new int[_k*_k];
            for (int i = 0; i < _k*_k; i++)
            {
                _arrRnd[i] = _rnd.Next(1, 5);
                toolStripStatusLabel2.Text += " " + _arrRnd[i];
            }
            //_arrRnd[0] = 2;
            //_arrRnd[1] = 3;
            //_arrRnd[2] = 1;
            //_arrRnd[3] = 3;
            //_arrRnd[4] = 2;
            //_arrRnd[5] = 4;
            //_arrRnd[6] = 2;
            //_arrRnd[7] = 2;
            //_arrRnd[8] = 4;
            if (_k * _k > 50)
            {
                MessageBox.Show(toolStripStatusLabel2.Text);
                toolStripStatusLabel2.Text = "≈≈";
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(!flagRnd) return;

            toolStripStatusLabel2.Text = " Код ≈";

            _arrRnd = new int[_k * _k];
            for (int i = 0; i < _k * _k; i++)
            {
                _arrRnd[i] = _rnd.Next(1, 5);
                toolStripStatusLabel2.Text += " " + _arrRnd[i];
            }
            if (_k * _k > 50)
            {
                MessageBox.Show(toolStripStatusLabel2.Text);
                toolStripStatusLabel2.Text = "≈≈";
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            flagRnd = false;
            
        }



    }
}
