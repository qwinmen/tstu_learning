using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Trans
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {//Событие по Выходу
            Close();//FormMain.ActiveForm.Close();
        }
        private StreamReader reader;//паток
        private OpenFileDialog openFileDialog;
        
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        public static class StaticData
        {
            //Буфер данных
            public static String DataBuffer = String.Empty;
        }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {//Открытие файла входа
            textBoxIn.ReadOnly = true;
            textBoxIn.Visible = false;
            listViewHashTable.Visible = false;
            openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files|*.txt";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

            TextLoad();//Грузим тексты с файла внешнего
            toolStripStatusLabel.Visible = true;
            toolStripStatusLPath.Text = openFileDialog.SafeFileName;
            toolStripStatusLPath.Visible = true;
            
            panel_Fon.Invalidate();
        }
        void TextLoad()
        {//Вывод текста с открытого файла в textBox.In
            StaticData.DataBuffer = Path.GetFullPath(openFileDialog.FileName);
            reader = new StreamReader(openFileDialog.OpenFile());
            try
            {
                textBoxIn.Visible = true;
                textBoxIn.Text = reader.ReadToEnd();
                viewToolStripMenuItem.Enabled = true;
                /*----------------------------------*/
                textBoxIn.ReadOnly = true;
                listViewHashTable.Visible = false;
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show("Ошибка при чтении файла");
                return;
            }
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {//View/Table/
            TextLoad();
            
            FormTable formTable = new FormTable();//создаем форму
            textBoxOut.Visible = true;
            parserToolStripMenuItem.Visible = true;
            textBoxOut.Text = formTable.SSS();
            
            if (formTable.ShowDialog() != DialogResult.OK)//если нажата кн отмена то делаем ретурн
                return;
        }
        private void сверхуВНизToolStripMenuItem_Click(object sender, EventArgs e)
        {//View/Parser/Нисходящий
            TextLoad();
            
            fParserLexical fParserLexical = new fParserLexical();//создаем форму
            if (fParserLexical.ShowDialog() != DialogResult.OK)//если нажата кн отмена то делаем ретурн
                return;
        }
        private void снизуВВерхToolStripMenuItem_Click(object sender, EventArgs e)
        {//View/Parser/Cвертки
            TextLoad();
            
            fParserLexical_OperatPredshest fPLexOperPred=new fParserLexical_OperatPredshest();
            fPLexOperPred.Show();//Показать таблицу приоритетов
            textBoxOut.Text = fPLexOperPred.inOutTextBox();//Вывод в текстовую панель Out
        }
        private void восходящийToolStripMenuItem_Click(object sender, EventArgs e)
        {//View/Parser/Восходящий
            TextLoad();
            
            fVosxodParser fvosxod = new fVosxodParser();
            fvosxod.Show();//Показать таблицу приоритетов
            textBoxOut.Text = fvosxod.inOutTextBox();//Вывод в текстовую панель Out
        }
        public static bool _globalSbros;
        private void hashToolStripMenuItem_Click(object sender, EventArgs e)
        {//Hash/
            textBoxIn.ReadOnly = false;
            textBoxIn.Visible = true;
            textBoxIn.Clear();
            #region Делается сброс всей статики сдесь и в классе хеш
            HashClass hashClass = new HashClass();
            _globalSbros = true;
            hashClass.GlobalSbros(_globalSbros);
            key = 0; index = 0; ent = 0;flag = false; tactic=false;
            #endregion
            listViewHashTable.Visible = true;
            listViewHashTable.Items.Clear();
            _list.Clear();list.Clear();
        }
        static List<string > _list = new List<string>();
        static List<ListViewItem.ListViewSubItem> list=new List<ListViewItem.ListViewSubItem>();
        public static int key, index,ent;
        public static bool flag, tactic, host;
        private static int ghost;
        private void textBoxIn_KeyDown(object sender, KeyEventArgs e)
        {//жмем Enter
            _globalSbros = false;
            if (e.KeyCode == Keys.Enter && listViewHashTable.Visible)
            {//Агримся на нажатие Enter с условием активности ХешТабл окна
                HashClass hashClass = new HashClass();
                //-----------------ввод----------------------------//
                String[] text = textBoxIn.Text.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                //string text = textBoxIn.Text;
                int tact = 0;


                if (Bastion(text) || flag)
                {
                    tactic = true;
                    MessageBox.Show("Этo повтор");
                    hashClass.BufferWords(text); //hashClass.TxtFromTextBoxIn(text);//
                    _list.Add(hashClass.Num().ToString());
                    ghost = hashClass.Num();//пишем номер повтора
                    ListViewItem stroka1 = new ListViewItem(hashClass.Num().ToString());
                    list.Add(stroka1.SubItems.Add("(" + hashClass.Id() + ")"));
                    list.Add(stroka1.SubItems.Add("(" + hashClass.Type() + ")"));
                     var moe="*";
                    list.Add(stroka1.SubItems.Add("(" + moe + ")"));
                    list.Add(stroka1.SubItems.Add("(" + hashClass.Kollizi().ToString() + ")"));
                    listViewHashTable.Items.Add(stroka1);
                    tact++;
                    
                }
                else
                {
                    //HashClass.Chost = false;
                    tactic = false;
                    hashClass.BufferWords(text); //hashClass.TxtFromTextBoxIn(text);//
                    //-----------------вывод---------------------------//
                    _list.Add(hashClass.Num().ToString());
                    ListViewItem stroka1 = new ListViewItem(hashClass.Num().ToString());
                    list.Add(stroka1.SubItems.Add(hashClass.Id()));
                    list.Add(stroka1.SubItems.Add(hashClass.Type()));
                    list.Add(stroka1.SubItems.Add(hashClass.Hasher().ToString()));
                    list.Add(stroka1.SubItems.Add(hashClass.Kollizi().ToString()));
                    listViewHashTable.Items.Add(stroka1);
                    
                    if (flag)
                    {
                        listViewHashTable.Items.Clear();
                        int ee = 0;
                        for (int i = 0; i < _list.Count; i++)
                        {
                            ListViewItem stroka2 = new ListViewItem(_list[i]); //0-1-2
                            stroka2.SubItems.Add(list[ee]); //0-4-8
                            ee++;
                            stroka2.SubItems.Add(list[ee]); //1-5-9
                            ee++;
                            stroka2.SubItems.Add(list[ee]); //2-6-10
                            ee++;
                            
                            if (i == ent && ent != -42)// - tact - 1 && tactic) //i==1 - 1строка
                            {//перезаписать строку-1
                                stroka2.SubItems.Add(index.ToString()); //3-7-11
                                list[ee].Text = index.ToString();
                                ee++;
                                //MessageBox.Show("i=ent");
                            }
                            else
                            {//перезаписать в нули
                                stroka2.SubItems.Add(list[ee]); //3-7-11
                                ee++;
                                //MessageBox.Show("else");
                            }
                            listViewHashTable.Items.Add(stroka2);
                        }
                    }
                    //MessageBox.Show(hashClass.Hash(text).ToString());
                    
                }
                flag = false;
            }

        }
        private bool Bastion(string[] _words)
        {//Защита от повторного ввода
            bool key = false;
            string dd = _words[_words.Length-1];
            for (int i = 0; i<_words.Length-1;i++ )
            {
                if (_words[i] == dd)
                {
                    key = true;
                }
            }
            return key;//true на совпадение
        }


        #region
        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                bHelp.Visible = false;
            else
                bHelp.Visible = true;
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            FHelp fHelp=new FHelp();
            if (fHelp.ShowDialog() != DialogResult.OK)//если нажата кн отмена то делаем ретурн
                return;
        }
        #endregion

        

        

        

        
    }
}
