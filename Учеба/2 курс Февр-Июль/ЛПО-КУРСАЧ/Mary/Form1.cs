using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Mary
{
    public partial class fMain : Form
    {
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        internal static class StaticData
        {//Буфер данных
            public static String DataBuffer = String.Empty;
        }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

        public fMain(){InitializeComponent();}

        /// <summary>
                /// Событие по Выходу
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e){ Close(); }

        private OpenFileDialog _openFileDialog;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {//Открытие файла входа
            textBoxIN.ReadOnly = true;
            textBoxIN.Visible = false;
            _openFileDialog = new OpenFileDialog {Filter = "Text files|*.txt"};

            if (_openFileDialog.ShowDialog() != DialogResult.OK) return;

            if(FormTable.TableCountStr!=0)//сначало Таблица, потом Парсер!!!
                parserToolStripMenuItem.Visible = false;//т.к. инфа берется с Таблиц лексем

            TextLoad();//Грузим тексты с файла внешнего
            toolStripStatusLabel.Visible = toolStripStatusLPath.Visible = true;
            toolStripStatusLPath.Text = _openFileDialog.SafeFileName;
        }

        private StreamReader _reader;//паток
        /// <summary>
        /// Коннектимся к файлу
        /// </summary>
        private void TextLoad()
        {//Вывод текста с открытого файла в textBox.In
            StaticData.DataBuffer = Path.GetFullPath(_openFileDialog.FileName);
            _reader = new StreamReader(_openFileDialog.OpenFile());
            try
            {
                textBoxIN.Visible = true;
                textBoxIN.Text = _reader.ReadToEnd();
                viewToolStripMenuItem.Enabled = tableToolStripMenuItem.Enabled = textBoxIN.ReadOnly = true;
                /*----------------------------------*/
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show("Ошибка при чтении файла " + ex);
                return;
            }
        }

        /// <summary>
        /// Когда грузимся с файла, поток открыт постоянно за счет TextLoad(); ниже в коде события
        /// </summary>
        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {//View/Table/
            TextLoad();

            FormTable formTable = new FormTable();//создаем форму
            textBoxOUT.Visible = parserToolStripMenuItem.Visible = true;
            textBoxOUT.Text = formTable.SSS();
            
            txtBoxFortranOUT.Text = formTable.SFP();

            IndikatorProgram.Visible = IndikatorVar.Visible = IndikatorBegin.Visible = IndikatorEnd.Visible = true;
            IndikLabel();

            if (formTable.ShowDialog() != DialogResult.OK)//если нажата кн отмена то делаем ретурн
            {
                if (FormTable.ErrRepitId != null && FormTable.ErrRepitId.Length != 0)
                    _errIDtoVar.fctb_TextChanged(_ergv, textBoxIN, FormTable.ErrRepitId);
                return;
            }
        }

        private void восходящийToolStripMenuItem_Click(object sender, EventArgs e)
        {//View/Parser/Восходящий
            fVosxodParser fvosxod = new fVosxodParser();
            fvosxod.Show();//Показать таблицу приоритетов
        }

        #region Размер Формы, Вызов Помощи
        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                bHelp.Visible = false;
            else
                bHelp.Visible = true;
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            FHelp fHelp = new FHelp();
            if (fHelp.ShowDialog() != DialogResult.OK)//если нажата кн отмена то делаем ретурн
                return;
        }
        #endregion

        private readonly Style _styleGreen = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        private readonly Style _styleBlue = new TextStyle(Brushes.Blue, null, FontStyle.Italic);
        
        private int _curPos = 0;//храним позицию курсора
        private readonly clSyntaxErrIDtoVar _errIDtoVar = new clSyntaxErrIDtoVar();

        /// <summary>
        /// когда FormTable закроется, необходимо передать в clSyntaxErrIDtoVar errIDtoVar состояние "е"
        /// </summary>
        private TextChangedEventArgs _ergv;

        private void textBoxIN_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearFoldingMarkers();
            //маркеры на сворачивание блоков begin..end
            e.ChangedRange.SetFoldingMarkers(@"begin\b", @"end\b");


            KeyValuePair<Regex, Style>[] pairs = new []
            {
                new KeyValuePair<Regex, Style>(new Regex("(\r\nfor |for\r\n| for )| to | if | do ", RegexOptions.IgnoreCase), _styleGreen),
                new KeyValuePair<Regex, Style>(new Regex("program |(var |\r\nvar )|( begin |\r\nbegin |begin\r\n |\tbegin |\r\nbegin\r\n)|(end |\nend |end.)", RegexOptions.IgnoreCase), _styleBlue)
            };
            _curPos = e.ChangedRange.tb.SelectionStart;

            foreach (KeyValuePair<Regex, Style> keyValuePair in pairs)
            {
                e.ChangedRange.ClearStyle(keyValuePair.Value);
                e.ChangedRange.SetStyle(keyValuePair.Value, keyValuePair.Key);
            }

            _ergv = e;
            if (FormTable.ErrRepitId != null && FormTable.ErrRepitId.Length != 0)
                _errIDtoVar.fctb_TextChanged(e, textBoxIN, FormTable.ErrRepitId);

            e.ChangedRange.tb.SelectionStart = _curPos;
            
            TxtBoxInText = textBoxIN.Text;
        }
        

        /// <summary>
        /// храним текст из панели txtBoxIN
        /// </summary>
        internal static string TxtBoxInText { get; private set; }

        /// <summary>
        /// это жать когда на textBoxIn чето было стерто или добавленно,
        /// тк //View/Table/ работает непосредственно с потоком открытого файла!!
        /// </summary>
        private void hashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTable formTable = new FormTable();//создаем форму
            textBoxOUT.Visible = parserToolStripMenuItem.Visible = true;
            textBoxOUT.Text = formTable.SSS();

            txtBoxFortranOUT.Text = formTable.SFP();
            IndikLabel();
            if (formTable.ShowDialog() != DialogResult.OK)//если нажата кн отмена то делаем ретурн
            {
                if (FormTable.ErrRepitId != null && FormTable.ErrRepitId.Length != 0)
                    _errIDtoVar.fctb_TextChanged(_ergv, textBoxIN, FormTable.ErrRepitId);
                return;
            }
            
        }

        /// <summary>
        /// Установит связь с БазойДанных для внесения\удаления допЗнаков препинания на обработку
        /// </summary>
        private void Пунктуация_Click(object sender, EventArgs e)
        {//окно с пунктуацией - связь с базой данных
            fPunct dialog = new fPunct();
            if(dialog.ShowDialog()!=DialogResult.OK) return;
        }

        /// <summary>
        /// Эта кнопа даёт зелёный\красный свет на редактирование\нет текстовогоПоляIn
        /// </summary>
        private void roundButton1_Click(object sender, EventArgs e)
        {
            if (textBoxIN.ReadOnly)
            {
                textBoxIN.ReadOnly = false;
                hashToolStripMenuItem.Enabled = true;
                roundButton1.BackColor = roundButton1.HoverColor = Color.LightGreen;
            }
            else
            {
                textBoxIN.ReadOnly = true;
                hashToolStripMenuItem.Enabled = false;
                roundButton1.BackColor = roundButton1.HoverColor = Color.Red;
            }
            textBoxIN.Focus();
        }

        /// <summary>
        /// Подсветка наличия\отсутствия каркаса программы
        /// </summary>
        private void IndikLabel()
        {
            foreach (KeyValuePair<bool, int> keyValuePair in FormTable.Indikation)
            {
                if (keyValuePair.Value == 0 && keyValuePair.Key) IndikatorProgram.BackColor = Color.Green;
                else if (keyValuePair.Value == 0 && !keyValuePair.Key) IndikatorProgram.BackColor = Color.Red;
                if (keyValuePair.Value == 1 && keyValuePair.Key) IndikatorVar.BackColor = Color.Green;
                else if (keyValuePair.Value == 1 && !keyValuePair.Key) IndikatorVar.BackColor = Color.Red;
                if (keyValuePair.Value == 2 && keyValuePair.Key) IndikatorBegin.BackColor = Color.Green;
                else if (keyValuePair.Value == 2 && !keyValuePair.Key) IndikatorBegin.BackColor = Color.Red;
                if (keyValuePair.Value == 3 && keyValuePair.Key) IndikatorEnd.BackColor = Color.Green;
                else if (keyValuePair.Value == 3 && !keyValuePair.Key) IndikatorEnd.BackColor = Color.Red;
            }
            if (FormTable.ZnakProgramToVar.Length != 0)
            foreach (KeyValuePair<int, int> keyValuePair in FormTable.ZnakProgramToVar)
            {
                if (keyValuePair.Key == 0 && keyValuePair.Value == 1)
                {//FormTable--SearchProgramToVar(idIndex[1], index, out pv);
                    IndikatorProgram.BorderSides = ToolStripStatusLabelBorderSides.Right;
                    IndikatorVar.BorderSides = ToolStripStatusLabelBorderSides.Left;
                }
                if (keyValuePair.Key == 1 && keyValuePair.Value == 2)
                {//FormTable--SearchVarToBegin(idIndex[2], index, out pv);
                    IndikatorVar.BorderSides = ToolStripStatusLabelBorderSides.Right;
                    IndikatorBegin.BorderSides = ToolStripStatusLabelBorderSides.Left;
                }
                if (keyValuePair.Key == 2 && keyValuePair.Value == 3)
                {
                    IndikatorBegin.BorderSides = ToolStripStatusLabelBorderSides.Right;
                    IndikatorEnd.BorderSides = ToolStripStatusLabelBorderSides.Left;
                }
            }
        }


    }
}
