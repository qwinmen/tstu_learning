using System;
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
        
        //public string winPath;
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        public static class StaticData
        {
            //Буфер данных
            public static String DataBuffer = String.Empty;
        }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {//Открытие файла входа
            openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files|*.txt";
                
                

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

               StaticData.DataBuffer = Path.GetFullPath(openFileDialog.FileName);
                //StaticData.DataBuffer = winPath;
            reader = new StreamReader(openFileDialog.OpenFile());

            
            
             //winPath = Path.GetFullPath(openFileDialog.FileName););
            
            try
            {
                
                textBoxIn.Visible = true;
                textBoxIn.Text = reader.ReadToEnd();
                
                viewToolStripMenuItem.Enabled=true;

                /*
                using (StreamReader re2 = new StreamReader("intro.txt"))
                {
                    while (re2.Peek() > -1)
                    {
                        char razdelenie = ' ';
                        string s = re2.ReadLine();//Чтение ПОСТРОЧНО
                        string[] words = s.Split(razdelenie);//Делим строку на ПОДСТРОКИ
                        foreach (string ts in words)
                        {
                            if (ts == "if")
                                textBoxOut.Text += " 1 ";
                            if (ts == "(")
                                textBoxOut.Text += " 2 ";
                        }
                    }
                }*/

            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show("Ошибка при чтении файла");
                return;
            }
            toolStripStatusLabel.Visible = true;
            toolStripStatusLPath.Text = openFileDialog.SafeFileName;
            toolStripStatusLPath.Visible = true;
            
            panel_Fon.Invalidate();
        }


        

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {//View/Table/
            FormTable formTable = new FormTable();//создаем форму
            textBoxOut.Visible = true;
            //textBoxOut.Text = "rtrttr";
            
            
            //FormTable formTable = new FormTable();
            //formTable.Show();
            textBoxOut.Text = formTable.SSS();

            
            if (formTable.ShowDialog() != DialogResult.OK)//если нажата кн отмена то делаем ретурн
                return;





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
