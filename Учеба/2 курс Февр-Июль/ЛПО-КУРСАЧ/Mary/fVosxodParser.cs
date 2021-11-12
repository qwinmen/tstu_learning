using System;
using System.Windows.Forms;

namespace Mary
{//Метод операторного предшествования
    public partial class fVosxodParser : Form
    {
        public fVosxodParser()
        {
            InitializeComponent();
            CreateTablePriorityVisual();
        }

        /// <summary>
        /// Создать, заполнить колонки у listViewTablVosxod
        /// </summary>
        private void CreateTablePriorityVisual()
        {
                int i = 1;
                listViewTablVosxod.Columns.Add((i-1).ToString(), "", 50);
                foreach (string str in FormTable.ЛексемыБезПовторов)
                {//создать колонки
                    if (str != null & str != "")
                    {
                        listViewTablVosxod.Columns.Add(i.ToString(), str, str.Length + 45, HorizontalAlignment.Center, 0);
                        listViewTablVosxod.Items.Add(str);//строки
                        i++;
                    }
                }
            AddStrListView("+","2","2");//значение-строка-столбец
        }

        /// <summary>
        /// str - значение, znak[0]=строка, znak[1]=столбец
        /// </summary>
        void AddStrListView(string str, params string[] znak)
        {
            if (znak.Length != 0 & znak[0] != null & znak[1] != null
                & Convert.ToInt32(znak[1]) < FormTable.TableCountStr 
                & Convert.ToInt32(znak[0]) < FormTable.TableCountStr)
            for (int i = 0; i < FormTable.TableCountStr; i++)
            {//по строке
                for (int j = 0; j < Convert.ToInt32(znak[1]); j++)//по столбцу
                    listViewTablVosxod.Items[i].SubItems.Add("");

                if (i == Convert.ToInt32(znak[0]))//по строке
                    listViewTablVosxod.Items[i].SubItems.Add(str);
            }
        }

    }

    internal class Priority
    {
        public Priority() { BufferWords(); }
        private string outMessage;
        private string[] arrPriority = {"="/*0*/, "<•"/*1*/, "•>"/*2*/, "<•"/*3*/, "•>"/*4*/, "="/*5*/, "•>"/*6*/,
                                              "<•"/*7*/, "<•"/*8*/, "•>"/*9*/, "<•"/*10*/,"•>"/*11*/,"<•"/*12*/,"•>"/*13*/,
                                              "<•"/*14*/,"•>"/*15*/,"<•"/*16*/,"="/*17*/, "<•"/*18*/,"•>"/*19*/
                                              };
        private string[] arrZapas = { "<•"/*( +*/, "•>"/*+ <=*/};//ДопЗначения при колизии
        
        public static string[] words;//для слов
        string text;//для строки
        void BufferWords()
        {//Вытаскиваем из буфера Текст "как есть" и переводим в массив
            text = FormTable.BuffWords.DataBuffer;
            char[] razdelenie = { ' ', '\n' };
            words = text.Split(razdelenie); //Делим строку на ПОДСТРОКИ
            for (int i = 0; i < words.Length; i++)
            {//Поиск :
                if (words[i] == ":")
                {
                    if (words[i + 1] == ":\r" || words[i + 1] == ":")
                    {//Обьединить
                        words[i] += " :=";
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
        {//p*(a+i-1);
            int flagStop = 0, flagStop1 = 0;
            if (words[3] == null)//если + занулен
            {//<* <==2.8 *>//Слив на запасной массив при колизии
                arrPriority[4] = arrZapas[0];//ставим <*
                for (int e = 0; e < words.Length; e++)
                {
                    if (words[e] != null)//Нулы пропускаем
                        outMessage += " " + words[e] + " ";
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
                    outMessage += " " + words[e] + " ";
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
                                    outMessage += " " + words[e] + " ";
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
        {//begin write() read()
            int flagStop = 0, flagStop1 = 0;
                if (words[14 - 1] == null && words[14] != null && words[14 + 1] == null)
                {//_Write(_//Слив на запасной массив при колизии
                    arrPriority[13] = arrZapas[0];
                    arrPriority[14] = arrZapas[1];
                    arrPriority[13] = null; words[14] = null; arrPriority[14] = null;
                    for (int e = 0; e < words.Length; e++)
                    {
                        if (words[e] != null)//Нулы пропускаем
                            outMessage += " " + words[e] + " ";
                    }
                }else
                    if (words[10 - 1] == null && words[10] != null && words[10 + 1] == null)
                    {//_Read(_//Слив на запасной массив при колизии
                        arrPriority[9] = arrZapas[0];
                        arrPriority[10] = arrZapas[1];
                        arrPriority[9] = null; words[10] = null; arrPriority[10] = null;
                        for (int e = 0; e < words.Length; e++)
                        {
                            if (words[e] != null)//Нулы пропускаем
                                outMessage += " " + words[e] + " "; //to do
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
                                                outMessage += " " + words[e] + " "; //for to do
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
                {//_;=;_//Слив на запасной массив при колизии
                    arrPriority[7] = arrZapas[0];
                    arrPriority[12] = arrZapas[1];
                    arrPriority[7] = null; words[8] = null;
                    words[12] = null; arrPriority[12] = null;
                    for (int e = 0; e < words.Length; e++)
                    {
                        if (words[e] != null)//Нулы пропускаем
                            outMessage += " " + words[e] + " "; //for to do
                    }
                }
        }
        private string inOutTextBox()
        {//Выводим результаты в textBoxOut
            var formMain = new fMain();
            OutRes();
            return formMain.txtBoxFortranOUT.Text = outMessage;
        }
    }
}
