using System;
using System.Drawing;
using System.Windows.Forms;
//ЛПО лаб_3
namespace Trans
{//Отображение таблицы приоритетов
    public partial class fParserLexical_OperatPredshest : Form
    {//Метод сверток
        public fParserLexical_OperatPredshest()
        {
            InitializeComponent();
            #region
            ListViewItem stroka1 = new ListViewItem("\tif\t");
            stroka1.SubItems.Add(" ");stroka1.SubItems.Add("\t=\t");
            listViewTablPrioritetov.Items.Add(stroka1);

            ListViewItem stroka2 = new ListViewItem("\t(\t");
            stroka2.SubItems.Add(" "); stroka2.SubItems.Add(" "); stroka2.SubItems.Add(" ");
            stroka2.SubItems.Add(" "); stroka2.SubItems.Add(" "); stroka2.SubItems.Add(" ");
            stroka2.SubItems.Add(" "); stroka2.SubItems.Add("\t<•\t");
            listViewTablPrioritetov.Items.Add(stroka2);

            ListViewItem stroka3 = new ListViewItem("\t)\t");
            stroka3.SubItems.Add(" "); stroka3.SubItems.Add(" "); stroka3.SubItems.Add(" ");
            stroka3.SubItems.Add(" "); stroka3.SubItems.Add(" "); stroka3.SubItems.Add(" ");
            stroka3.SubItems.Add("\t<•\t");
            listViewTablPrioritetov.Items.Add(stroka3);

            ListViewItem stroka4 = new ListViewItem("\tid\t");
            stroka4.SubItems.Add(" "); stroka4.SubItems.Add(" "); stroka4.SubItems.Add(" ");
            stroka4.SubItems.Add(" "); stroka4.SubItems.Add(" "); stroka4.SubItems.Add(" ");
            stroka4.SubItems.Add("\t•>\t"); stroka4.SubItems.Add(" ");
            stroka4.SubItems.Add("\t<•\t"); stroka4.SubItems.Add("\t•>\t");
            listViewTablPrioritetov.Items.Add(stroka4);

            ListViewItem stroka5 = new ListViewItem("\t+\t");
            stroka5.SubItems.Add(" "); stroka5.SubItems.Add(" "); stroka5.SubItems.Add(" ");
            stroka5.SubItems.Add(" "); stroka5.SubItems.Add(" "); stroka5.SubItems.Add(" ");
            stroka5.SubItems.Add(" "); stroka5.SubItems.Add("\t•>\t");
            listViewTablPrioritetov.Items.Add(stroka5);

            ListViewItem stroka6 = new ListViewItem("\t<=\t");
            stroka6.SubItems.Add(" "); stroka6.SubItems.Add(" "); stroka6.SubItems.Add(" ");
            stroka6.SubItems.Add(" "); stroka6.SubItems.Add(" "); stroka6.SubItems.Add(" ");
            stroka6.SubItems.Add(" "); stroka6.SubItems.Add("\t•>\t");
            listViewTablPrioritetov.Items.Add(stroka6);

            ListViewItem stroka7 = new ListViewItem("\tor\t");
            stroka7.SubItems.Add(" "); stroka7.SubItems.Add(" "); stroka7.SubItems.Add(" ");
            stroka7.SubItems.Add("\t<•\t");
            listViewTablPrioritetov.Items.Add(stroka7);

            ListViewItem stroka8 = new ListViewItem("\tconst\t");
            stroka8.SubItems.Add(" "); stroka8.SubItems.Add(" "); stroka8.SubItems.Add("\t•>\t");
            stroka8.SubItems.Add(" "); stroka8.SubItems.Add("\t<•\t"); stroka8.SubItems.Add("\t<•\t");
            listViewTablPrioritetov.Items.Add(stroka8);

            ListViewItem stroka9 = new ListViewItem("\tand\t");
            stroka9.SubItems.Add(" "); stroka9.SubItems.Add(" "); stroka9.SubItems.Add(" ");
            stroka9.SubItems.Add("\t•>\t");
            listViewTablPrioritetov.Items.Add(stroka9);

            ListViewItem stroka10 = new ListViewItem("\tthen\t");
            stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" ");
            stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" ");
            stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" ");
            stroka10.SubItems.Add(" "); stroka10.SubItems.Add("\t<•\t");
            listViewTablPrioritetov.Items.Add(stroka10);

            ListViewItem stroka11 = new ListViewItem("\twriteln\t");
            stroka11.SubItems.Add(" "); stroka11.SubItems.Add("\t=\t");
            listViewTablPrioritetov.Items.Add(stroka11);
#endregion
            BufferWords();
        }

        private string outMessage;
        private string[] arrPriority = {"="/*0*/, "<•"/*1*/, "<•"/*2*/, "•>"/*3*/, "<•"/*4*/, "•>"/*5*/, "•>"/*6*/,
                                              "<•"/*7*/, "<•"/*8*/, "<•"/*9*/, "•>"/*10*/,"•>"/*11*/,"<•"/*12*/,"<•"/*13*/,
                                              "•>"/*14*/,"•>"/*15*/,"<•"/*16*/,"="/*17*/, "<•"/*18*/,"•>"/*19*/
                                              };
        public static string[] words;//для слов
        string text;//для строки
        void BufferWords()
        {//Вытаскиваем из буфера Текст "как есть" и переводим в массив
            text = FormTable.BuffWords.DataBuffer;
            char[] razdelenie = { ' ', '\n' };
            words = text.Split(razdelenie); //Делим строку на ПОДСТРОКИ
            for (int i = 0; i < words.Length; i++)
            {//Поиск NOT и Y
                if (words[i]=="NOT")
                {
                    if (words[i + 1] == "Y\r" || words[i + 1] == "Y")
                    {//Обьединить Not и Y в одну ячейку
                        words[i] += " Y";//NOT Y
                        for (int j = i+1; j < words.Length-1; j++)
                        {//Делаем сдвиг в лево оставшейся части
                            words[j] = words[j + 1];
                        }
                        words[words.Length-1] = null;//Последнюю занулим
                    }
                }
            }
        }
        void OutRes()
        {//Или 8 раз или сделать поиск *> наперёд для подстраховки
            int flag = 0;
            for (int i = 0; i < 8; i++)
            {//Вывод построчно
                outMessage += i+"] "; perebor(); outMessage += Environment.NewLine;
                shag(i,flag);//Зануляем в тексте
                flag++;
            }
        }
        void shag(int i,int flag)
        {
            if (i == 0 && flag == 0)
            {//a+b
                words[2] = null; words[3] = null; words[4] = "Res" + flag;
                flag = 1;
            }
            if (i == 1 && flag == 1)
            {//a<=b
                words[4] = null; words[5] = null; words[6] = "Res" + flag;
                flag = 2;
            }
            if (i == 2 && flag == 2)
            {//a and b
                words[9] = null; words[10] = null; words[11] = "Res" + flag;
                flag = 3;
            }
            if (i == 3 && flag == 3)
            {//a and not_b
                words[13] = null; words[14] = null; words[15] = "Res" + flag;
                flag = 4;
            }
            if (i == 4 && flag == 4)
            {//( 'Верно' )
                words[19] = null; words[20] = null; words[21] = "Res" + flag;
                flag = 5;
            }/**************************сворачиваем OR***********************/
            if (i == 5 && flag == 5)
            {//a OR A
                words[1] = null; words[7] = null;//( и )
                words[6] = null; words[8] = null; words[11] = "Res" + flag;
                flag = 6;
            }
            if (i == 6 && flag == 6)
            {//A OR b
                words[11] = null; words[12] = null; words[15] = "Res" + flag;
                flag = 7;
            }
        }
        void perebor()
        {//8 раз
            int flagStop = 0, flagStop1 = 0;
            for (int p = 0; flagStop!=1 ; p++)
            {
                if (arrPriority[p] == "•>")
                {//outMessage += "найден •>";
                    flagStop = 1;
                    for (int k = p; flagStop1 != 1; k--)
                    {
                        if (arrPriority[k] == "<•")
                        {
                            for (int e = 0; e < words.Length; e++)
                            {
                                if (words[e] != null)//Нулы пропускаем
                                    outMessage += " " + words[e] + " "; //if(2.5+0.68
                            }
                            arrPriority[p] = null; arrPriority[k] = null;
                            flagStop1 = 1;
                        }
                    }
                }
            }
            #region
            /*            if (arrPriority[3]=="•>")
            {
                if (arrPriority[2] == "<•")
                {
                    foreach (string w in words)
                    {
                        if (w == "2.5" || w=="+"||w=="0.68")
                            outMessage += "Res0" + Environment.NewLine;
                        else outMessage += w;
                    }
                        
                    //result[0]=
                    //words[2] = null;
                    //words[3] = null;
                    //words[4] = null;
                }
            }
            
            /*
            for (int i = 0; i < 5 ; i++)
            {//Поиск в плюс
                if (arrPriority[i] == "•>")
                {
                    for (int j = i; j > 0; j--)
                    {//Поиск в минус
                        if (arrPriority[j] == "<•")
                        {
                            outMessage = j.ToString()+" "+i.ToString();
                        }
                    }
                }
            }
            */
            #endregion
        }
        public string inOutTextBox()
        {//Выводим результаты в textBoxOut
            FormMain formMain = new FormMain();
            OutRes();
            return formMain.textBoxOut.Text = outMessage;
        }
    }
}
