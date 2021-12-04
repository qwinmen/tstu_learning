using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.DotNetBar;
//Чем дальше в лес, тем толще партизаны.
//http://habrahabr.ru/post/141827/
namespace RLEpic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bevel1.BevelLineStep = sliderItem_ШагСетки.Value;
            bevel1.LastikColor = Color.Yellow;
            bevel1.BevelShadowColor = Color.Black;

            _schema1 = true;
            _schema2 = false;
            _razdelitel1 = ' ';
            _razdelitel2 = ' ';

            progressBarX1.Value = 0;
        }

        private clFile _file = new clFile();
        private clCoder _coder = new clCoder();
        private clDecoder _deCoder = new clDecoder();

        private void sliderItem_ШагСетки_ValueChanged(object sender, EventArgs e)
        {
            //перетащили слайдер изменил сетку
            bevel1.BevelLineStep = sliderItem_ШагСетки.Value;
            sliderItem_ШагСетки.Text = "Шаг " + sliderItem_ШагСетки.Value;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //перерисовать холст
            bevel1.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //сохранить содержимое полотна в файл
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TXT files|*.txt";

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var filename = saveFileDialog.FileName;

            //сохранить в файл
            int outX, outY;
            _file.SaveProject(filename, bevel1.SaveArrayToFile(out outX, out outY), _xResol, _yResol, outX, outY);
            
        }

        /// <summary>
        /// Загрузить неЗакодированный файл
        /// </summary>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            //загрузить тхт файл
            var openFileDialog = new OpenFileDialog {Filter = "TXT files|*.txt"};

            if(openFileDialog.ShowDialog() != DialogResult.OK) return;
            
            int xLen, yLen;
            bevel1.LoadFromFile(_file.LoadProject(out xLen, out yLen, openFileDialog.FileName, true), xLen, yLen);
            bevel1.Refresh();
        }

        private void btnLastic_Click(object sender, EventArgs e)
        {
            bevel1.Rejim = true;
        }

        private void btnKarandash_Click(object sender, EventArgs e)
        {
            bevel1.Rejim = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            progressBarX1.Value = 0;
            toolTip1.SetToolTip(progressBarX1, "Сжато " + 0 + "/" + 100);

            bevel1.ClearHolst();
        }




        private void bevel1_MouseDownEvent(object sender, MouseEventArgs e){}

        private void bevel1_MouseMoveEvent(object sender, MouseEventArgs e){}

        private void bevel1_MouseUpEvent(object sender, MouseEventArgs e){}

        private void bevel1_CliclEvent(object sender, EventArgs e){}

        private int _xResol = 100;
        private int _yResol = 100;

        private void textBoxItem1_TextChanged(object sender, EventArgs e)
        {
            var rxNums = new Regex(@"^\d+$"); // любые цифры
            _yResol = rxNums.IsMatch(textBoxItem1.Text) ? int.Parse(textBoxItem1.Text) : 100;
        }

        private void textBoxItem2_TextChanged(object sender, EventArgs e)
        {
            var rxNums = new Regex(@"^\d+$"); // любые цифры
            _xResol = rxNums.IsMatch(textBoxItem2.Text) ? int.Parse(textBoxItem2.Text) : 100;
        }

        /// <summary>
        /// Сгенерировать произвольный рисунок
        /// </summary>
        private void btnRandomImg_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            int xlen = _yResol;
            int ylen = _xResol;
            int[,] arr = new int[xlen, ylen];

            for (int i = 0; i < xlen; i++)
            {
                for (int j = 0; j < ylen; j++)
                {
                    arr[i, j] = rnd.Next(0, 2);
                }
            }
            bevel1.LoadFromFile(arr, xlen, ylen);
            bevel1.Refresh();
        }

        private char _razdelitel1, _razdelitel2;

        /// <summary>
        /// Первый разделитель
        /// </summary>
        private void textBoxItem_Разд1_TextChanged(object sender, EventArgs e)
        {//нельзя пустой или ластик или карандаш
            if (textBoxItem_Разд1.Text != "" && textBoxItem_Разд1.Text != bevel1.BSterka.ToString() &&
                textBoxItem_Разд1.Text != bevel1.BKarandash.ToString())
                _razdelitel1 = textBoxItem_Разд1.Text.ToCharArray()[0];
        }

        /// <summary>
        /// Второй разделитель
        /// </summary>
        private void textBoxItem_Разд2_TextChanged(object sender, EventArgs e)
        {//нельзя пустой или ластик или карандаш
            if (textBoxItem_Разд2.Text != "" && textBoxItem_Разд2.Text != bevel1.BSterka.ToString() &&
                textBoxItem_Разд2.Text != bevel1.BKarandash.ToString())
                _razdelitel2 = textBoxItem_Разд2.Text.ToCharArray()[0];
        }

        private bool _schema1, _schema2;
        /// <summary>
        /// Схема 1
        /// </summary>
        private void checkBoxItem1_Click(object sender, EventArgs e)
        {
            _schema1 = checkBoxItem1.Checked;
            _schema2 = checkBoxItem2.Checked;
        }
        /// <summary>
        /// Схема 2
        /// </summary>
        private void checkBoxItem2_Click(object sender, EventArgs e)
        {
            _schema2 = checkBoxItem2.Checked;
            _schema1 = checkBoxItem1.Checked;
        }

        /// <summary>
        /// Приступить к сжатию содержимого холста
        /// </summary>
        private void buttonItemSjatie_Click(object sender, EventArgs e)
        {
            if(_schema1)
            {
                //взять содержимое холста размером _Resol
                int outX, outY;
                //сжать по схеме1 с разделителями
                int[,] arr = _coder.Compress(bevel1.SaveArrayToFile(out outX, out outY), outX, outY, _razdelitel1, _razdelitel2);

                double сжатArr = _coder.Koeff;
                progressBarX1.Value = (int)сжатArr;
                toolTip1.SetToolTip(progressBarX1, "Сжато " + сжатArr + "/" + (100 - сжатArr));
                //сохранить в файл
                //Вывести сжатое на холст
                bevel1.LoadFromFile(arr, _coder.XY.X, _coder.XY.Y);
                bevel1.Refresh();
            }
            if(_schema2)
            {
                //взять содержимое холста размером _Resol
                int outX, outY;
                //сжать по схеме2
                int[,] arr = _coder.Compress(bevel1.SaveArrayToFile(out outX, out outY), _xResol, _yResol);

                //сохранить в файл
                //Вывести сжатое на холст
            }

        }

        /// <summary>
        /// Сохранить сжатое в файл
        /// </summary>
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            //сохранить содержимое полотна в файл
            var saveFileDialog = new SaveFileDialog {Filter = "TXT files|*.txt"};

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var filename = saveFileDialog.FileName;

            //сохранить в файл
            int outX, outY;

            _file.SaveProjectCoder(filename, bevel1.SaveArrayToFile(out outX, out outY), _xResol, _yResol, outX, outY, _razdelitel2);
        }

        /// <summary>
        /// Загрузить сжатый файл
        /// </summary>
        private void buttonItem_LoadSjatoe_Click(object sender, EventArgs e)
        {
            //загрузить тхт файл
            var openFileDialog = new OpenFileDialog { Filter = "TXT files|*.txt" };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            //загру3ить сжатый файл и вывести на холст
            int xLen, yLen;
            bevel1.LoadFromFile(
                _file.LoadProjectCoder(out xLen, out yLen, openFileDialog.FileName, false, _razdelitel1, _razdelitel2),
                xLen, yLen);
            bevel1.Refresh();
        }

        /// <summary>
        /// Восстаносить из сжатого состояния
        /// </summary>
        private void buttonItemDekompress_Click(object sender, EventArgs e)
        {
            //взять массив из clFile\LoadProjCoder() !!без паразитных окончаний!!
            //передать в clDecoder и в нем восстановить все сжатые послед-сти

            //загру3ить файл и вывести на холст
            int xLen, yLen;
            bevel1.LoadFromFile(_deCoder.DeCodArr(out xLen, out yLen, _file.CoderArr, _file.XY, _file.ShemaRazbora), xLen, yLen);
            bevel1.Refresh();
        }

        



    }
}
