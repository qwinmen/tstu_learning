using System;
using System.Windows.Forms;
//Lab_3_LPO
namespace Trans
{
    public partial class fVosxodParser : Form
    {
        public fVosxodParser()
        {
            InitializeComponent();
            #region
            ListViewItem stroka1 = new ListViewItem("\tif\t");
            stroka1.SubItems.Add(" "); stroka1.SubItems.Add("\t=\t");
            listViewTablVosxod.Items.Add(stroka1);

            ListViewItem stroka2 = new ListViewItem("\t(\t");
            stroka2.SubItems.Add(" "); stroka2.SubItems.Add(" "); stroka2.SubItems.Add("\t=\t");
            stroka2.SubItems.Add(" "); stroka2.SubItems.Add("\t<•\t"); stroka2.SubItems.Add("\t<•\t");
            stroka2.SubItems.Add(" "); stroka2.SubItems.Add("\t<•\t");
            listViewTablVosxod.Items.Add(stroka2);

            ListViewItem stroka3 = new ListViewItem("\t)\t");
            stroka3.SubItems.Add(" "); stroka3.SubItems.Add(" "); stroka3.SubItems.Add(" ");
            stroka3.SubItems.Add(" "); stroka3.SubItems.Add(" "); stroka3.SubItems.Add(" ");
            stroka3.SubItems.Add("\t<•\t"); stroka3.SubItems.Add(" "); stroka3.SubItems.Add(" ");
            stroka3.SubItems.Add("\t=\t"); listViewTablVosxod.Items.Add(stroka3);

            ListViewItem stroka4 = new ListViewItem("\tid\t");
            stroka4.SubItems.Add(" "); stroka4.SubItems.Add(" "); stroka4.SubItems.Add(" ");
            stroka4.SubItems.Add(" "); stroka4.SubItems.Add(" "); stroka4.SubItems.Add(" ");
            stroka4.SubItems.Add("\t•>\t"); stroka4.SubItems.Add(" ");
            stroka4.SubItems.Add("\t•>\t"); stroka4.SubItems.Add("\t•>\t");
            listViewTablVosxod.Items.Add(stroka4);

            ListViewItem stroka5 = new ListViewItem("\t+\t");
            stroka5.SubItems.Add(" "); stroka5.SubItems.Add(" "); stroka5.SubItems.Add(" ");
            stroka5.SubItems.Add(" "); stroka5.SubItems.Add(" "); stroka5.SubItems.Add("\t•>\t");
            stroka5.SubItems.Add(" "); stroka5.SubItems.Add("\t<•\t");
            listViewTablVosxod.Items.Add(stroka5);

            ListViewItem stroka6 = new ListViewItem("\t<=\t");
            stroka6.SubItems.Add(" "); stroka6.SubItems.Add(" "); stroka6.SubItems.Add(" ");
            stroka6.SubItems.Add(" "); stroka6.SubItems.Add(" "); stroka6.SubItems.Add(" ");
            stroka6.SubItems.Add(" "); stroka6.SubItems.Add("\t=\t");
            listViewTablVosxod.Items.Add(stroka6);

            ListViewItem stroka7 = new ListViewItem("\tor\t");
            stroka7.SubItems.Add(" "); stroka7.SubItems.Add(" "); stroka7.SubItems.Add(" ");
            stroka7.SubItems.Add("\t<•\t"); stroka7.SubItems.Add(" "); stroka7.SubItems.Add(" ");
            stroka7.SubItems.Add("="); stroka7.SubItems.Add(" "); stroka7.SubItems.Add("\t<•\t");
            stroka7.SubItems.Add("\t•>\t"); listViewTablVosxod.Items.Add(stroka7);

            ListViewItem stroka8 = new ListViewItem("\tconst\t");
            stroka8.SubItems.Add(" "); stroka8.SubItems.Add(" "); stroka8.SubItems.Add("\t•>\t");
            stroka8.SubItems.Add(" "); stroka8.SubItems.Add("\t•>\t"); stroka8.SubItems.Add("\t•>\t");
            listViewTablVosxod.Items.Add(stroka8);

            ListViewItem stroka9 = new ListViewItem("\tand\t");
            stroka9.SubItems.Add(" "); stroka9.SubItems.Add(" "); stroka9.SubItems.Add(" ");
            stroka9.SubItems.Add("\t<•\t"); stroka9.SubItems.Add(" "); stroka9.SubItems.Add(" ");
            stroka9.SubItems.Add("\t•>\t"); stroka9.SubItems.Add(" "); stroka9.SubItems.Add(" ");
            stroka9.SubItems.Add("\t•>\t"); listViewTablVosxod.Items.Add(stroka9);

            ListViewItem stroka10 = new ListViewItem("\tthen\t");
            stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" ");
            stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" ");
            stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" ");
            stroka10.SubItems.Add(" "); stroka10.SubItems.Add("\t<•\t");
            listViewTablVosxod.Items.Add(stroka10);

            ListViewItem stroka11 = new ListViewItem("\twriteln\t");
            stroka11.SubItems.Add(" "); stroka11.SubItems.Add("\t=\t");
            listViewTablVosxod.Items.Add(stroka11);
            #endregion
            BufferWords();
        }
        private string outMessage;
        private string[] arrPriority = {"="/*0*/, "<•"/*1*/, "•>"/*2*/, "<•"/*3*/, "•>"/*4*/, "="/*5*/, "•>"/*6*/,
                                              "<•"/*7*/, "<•"/*8*/, "•>"/*9*/, "<•"/*10*/,"•>"/*11*/,"<•"/*12*/,"•>"/*13*/,
                                              "<•"/*14*/,"•>"/*15*/,"<•"/*16*/,"="/*17*/, "<•"/*18*/,"•>"/*19*/
                                              };
        private string[] arrZapas = { "<•"/*( +*/, "•>"/*+ <=*/};//ДопЗначения при колизии
        /*if"="("<•"2.5"•>"+"<•"0.68"•>"<="="2.8"•>")
          "<•"or"<•"id"•>"and"<•"id"•>"or"<•"id"•>"and"<•"id
          "•>"then"<•"writeln"="("<•"const"•>")*/
        public static string[] words;//для слов
        string text;//для строки
        void BufferWords()
        {//Вытаскиваем из буфера Текст "как есть" и переводим в массив
            text = FormTable.BuffWords.DataBuffer;
            char[] razdelenie = { ' ', '\n' };
            words = text.Split(razdelenie); //Делим строку на ПОДСТРОКИ
            for (int i = 0; i < words.Length; i++)
            {//Поиск NOT и Y
                if (words[i] == "NOT")
                {
                    if (words[i + 1] == "Y\r" || words[i + 1] == "Y")
                    {//Обьединить Not и Y в одну ячейку
                        words[i] += " Y";//NOT Y
                        for (int j = i + 1; j < words.Length - 1; j++)
                        {//Делаем сдвиг в лево оставшейся части
                            words[j] = words[j + 1];
                        }
                        words[words.Length - 1] = null;//Последнюю занулим
                    }
                }
                if (words[i] == "'")//i=[19]
                {
                    if (words[i + 1] == "Верно" && words[i + 2] == "'")
                    {//Обьединить ' и Верно в одну ячейку
                        words[i] += "Верно'";//'Верно'
                        for (int j = i + 1; j < words.Length - 1; j++)
                        {//Делаем сдвиг в лево оставшейся части
                            words[j] = words[j + 1];
                        }
                        words[i + 1] = words[i + 2];//[)]
                        for (int j = i + 2; j < words.Length; j++)
                        {
                            words[j] = null;//Последнюю занулим
                        }
                    }
                }
            }
        }
        void OutRes()
        {//Или 8 раз или сделать поиск *> наперёд для подстраховки
            
            for (int i = 0; i < 5; i++)
            {//Вывод построчно
                outMessage += i + "] "; perebor(); outMessage += Environment.NewLine;
            }
            for (int i = 5; i < 12; i++)
            {//Вывод построчно
                outMessage += i + "] "; pereborTwo(); outMessage += Environment.NewLine;
            }
            for (int i = 12; i < 13; i++)
            {//Вывод построчно
                outMessage += i + "] "; PereborFree(); outMessage += Environment.NewLine;
            }
            
        }
        void perebor()
        {//if(a+b<=c)
            int flagStop = 0, flagStop1 = 0;
            if (words[3] == null)//если + занулен
            {//<* <==2.8 *>//Слив на запасной массив при колизии
                arrPriority[4] = arrZapas[0];//ставим <*
                for (int e = 0; e < words.Length; e++)
                {
                    if (words[e] != null)//Нулы пропускаем
                        outMessage += " " + words[e] + " "; //if(2.5+0.68
                }
                arrPriority[4] = null; words[5] = null;
                arrPriority[5] = null; words[6] = null; arrPriority[6] = null;
            }
            else if (words[3 - 1] == null && words[3] != null && words[3 + 1] == null)
            {//_+_//Слив на запасной массив при колизии
                arrPriority[1] = arrZapas[0];
                arrPriority[2] = arrZapas[1];
                for (int e = 0; e < words.Length; e++)
                {
                    if (words[e] != null)//Нулы пропускаем
                    outMessage += " " + words[e] + " "; //if(2.5+0.68
                }
                arrPriority[1] = null; words[3] = null; arrPriority[2] = null;
            }else 
            for (int p = 0; flagStop != 1; p++)
            {
                if (arrPriority[p] == "•>")
                {//outMessage += "найден •>";
                    flagStop = 1;
                    for (int k = p; flagStop1 != 1; k--)
                    {
                        if (arrPriority[k] == "<•" || arrPriority[k] == "=")
                        {
                            for (int e = 0; e < words.Length; e++)
                            {
                                if (words[e] != null)//Нулы пропускаем
                                    outMessage += " " + words[e] + " "; //if(2.5+0.68
                            }
                            //arrPriority[p] = null; arrPriority[k] = null;
                            arrPriority[k] = null; words[p] = null; arrPriority[p] = null;
                            
                            flagStop1 = 1;
                        }
                    }
                }
            }
        }
        void pereborTwo()
        {//or a and b or a and b then writeln()
            int flagStop = 0, flagStop1 = 0;
                if (words[14 - 1] == null && words[14] != null && words[14 + 1] == null)
                {//_and2_//Слив на запасной массив при колизии
                    arrPriority[13] = arrZapas[0];
                    arrPriority[14] = arrZapas[1];
                    arrPriority[13] = null; words[14] = null; arrPriority[14] = null;
                    for (int e = 0; e < words.Length; e++)
                    {
                        if (words[e] != null)//Нулы пропускаем
                            outMessage += " " + words[e] + " "; //if(2.5+0.68
                    }
                }else
                    if (words[10 - 1] == null && words[10] != null && words[10 + 1] == null)
                    {//_and1_//Слив на запасной массив при колизии
                        arrPriority[9] = arrZapas[0];
                        arrPriority[10] = arrZapas[1];
                        arrPriority[9] = null; words[10] = null; arrPriority[10] = null;
                        for (int e = 0; e < words.Length; e++)
                        {
                            if (words[e] != null)//Нулы пропускаем
                                outMessage += " " + words[e] + " "; //if(2.5+0.68
                        }
                    }else
                        for (int p = 0; flagStop != 1; p++)
                        {//5]
                            if (arrPriority[p] == "•>")
                            {//outMessage += "найден •>";
                                flagStop = 1;
                                for (int k = p; flagStop1 != 1; k--)
                                {
                                    if (arrPriority[k] == "<•" || arrPriority[k] == "=")
                                    {
                                        arrPriority[k] = null; words[p] = null; arrPriority[p] = null;
                                        for (int e = 0; e < words.Length; e++)
                                        {
                                            if (words[e] != null)//Нулы пропускаем
                                                outMessage += " " + words[e] + " "; //if(2.5+0.68
                                        }
                                        //arrPriority[p] = null; arrPriority[k] = null;
                                        flagStop1 = 1;
                                    }
                                }
                            }
                        }
        }
        void PereborFree()
        {
            if (words[10] == null && words[12] != null && words[11] == null && words[8] != null)
                {//_OR=OR_//Слив на запасной массив при колизии
                    arrPriority[7] = arrZapas[0];
                    arrPriority[12] = arrZapas[1];
                    arrPriority[7] = null; words[8] = null;
                    words[12] = null; arrPriority[12] = null;
                    for (int e = 0; e < words.Length; e++)
                    {
                        if (words[e] != null)//Нулы пропускаем
                            outMessage += " " + words[e] + " "; //if(2.5+0.68
                    }
                }
        }
        public string inOutTextBox()
        {//Выводим результаты в textBoxOut
            FormMain formMain = new FormMain();
            OutRes();
            return formMain.textBoxOut.Text = outMessage;
        }
    }//end Class
}
