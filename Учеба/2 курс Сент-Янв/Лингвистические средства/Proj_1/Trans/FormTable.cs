using System;
using System.IO;
using System.Windows.Forms;
//ЛПО лаб_1
namespace Trans
{//FormTable.cs реализует лексический анализ
    public partial class FormTable : Form
    {
        public FormTable()
        {
            InitializeComponent();
            Leksema();
        }

        private string mmindex;

        private void Leksema()
        {
            int max = 1;
            for (int increment = 0; increment < max; increment++)
            {//Общий счетчик выражений
                Kod(increment);//listViewKod_Table.Items[index].SubItems.Add(increment.ToString());
            }

        }
               
        public static string[] words;
        public void Kod(int index)
        {
            char[] razdelenie = {' ','\n'};
            using (StreamReader reader = new StreamReader(FormMain.StaticData.DataBuffer))
            {
                //Безопасное открытие патока
                string[] Massiv;
                string[] Massiv_Index;
                int i = 0, j = 0;
                while (!reader.EndOfStream)//(reader.Peek() > -1)
                {
                    //В потоке возвращает целочисленное значение, 
                    //чтобы определить, произошла ошибка или достигнут конец файла(-1)
                    string s = reader.ReadToEnd();//ПОЛНОСТЬЮ!//ReadLine(); //Чтение ПОСТРОЧНО
BuffWords.DataBuffer = s;//Пихаем в буфер для ЛАБ_3
                    words = s.Split(razdelenie); //Делим строку на ПОДСТРОКИ
                    //***********ЯВНОЕ ОБЬЯВЛЕНИЕ********************
                    string X_atribute = "1", Y_atribute = "2", Z_atribute = "3";
                    int ind_CONST = 45; //CONST_0 #2.5
                    int ind_IDENT = 1; //ID X->1
                    //***********************************************
                    Massiv = new string[words.Length];
                    Massiv_Index = new string[words.Length];
                    
                    foreach (string ts in words)
                    {
                        Massiv[j] = ts;
                        j++;
                        for (int e = 0; e < i; e++)
                            if (ts.CompareTo(Massiv[e]) == 0)
                            {//Если есть результ, то есть совпадение с текущим значением ts!
                                Massiv_Index[e] = ts;
                                Massiv[e] = null;//Занулим все совпадения
                            }
                        i++;
                    }
                    int ks = 0;
                    foreach (string ss in Massiv)
                    {
                        if (ss != null)
                        {//Шарим в ЗАНУЛЕНОМ МАСИВЕ!
                            //----------------------------------------------------------------//
                            //----------------------------------------------------------------//
                            ks++; 
                            if (ss == "2.5" || ss == "0.68" || ss == "2.8" || ss=="Верно")
                            {//ловим Konstant
                                index = listViewKod_Table.Items.Add("CONST_" + ind_CONST).Index; //_0
                                listViewKod_Table.Items[index].SubItems.Add("#" + ss); //#2.5
                                mmindex += ("  "+ind_CONST + "#" + ss + "  "); // SSS()+="#"+ts;
                                index++;
                            }
                            else if (ss == "X" || ss == "Y" || ss == "Z" || ss=="Y\r")
                            {//ловим идентификатор
                                if (ss == "X")
                                {
                                    index = listViewKod_Table.Items.Add("IDENT_" + ind_IDENT).Index; //_1
                                    listViewKod_Table.Items[index].SubItems.Add(ss + "->" + X_atribute); //
                                    mmindex += ("  " + ind_IDENT + "->" + X_atribute+"  ");
                                }
                                if (ss == "Y" || ss == "Y\r")
                                {
                                    index = listViewKod_Table.Items.Add("IDENT_" + ind_IDENT).Index; //_1
                                    listViewKod_Table.Items[index].SubItems.Add(ss + "->" + Y_atribute); //
                                    mmindex += ("  " + ind_IDENT + "->" + Y_atribute+"  ");
                                }
                                if (ss == "Z")
                                {
                                    index = listViewKod_Table.Items.Add("IDENT_" + ind_IDENT).Index; //_1
                                    listViewKod_Table.Items[index].SubItems.Add(ss + "->" + Z_atribute); //
                                    mmindex += ("  " + ind_IDENT + "->" + Z_atribute+"  ");
                                }
                                index++;
                            }
                            else
                            {
                                listViewKod_Table.Items.Add(ss); //Колонка Лексемы
                                listViewKod_Table.Items[index].SubItems.Add(index.ToString()); //
                                mmindex += ("  " + index + " ");//mmindex += ("  $" + index + "$ ");
                                index++;
                            }
                            
                            //----------------------------------------------------------------//
                            //----------------------------------------------------------------//
                        }
                        else//Иначе надо null заменить значением
                        {
                            string vvv = Massiv_Index[ks];//"(" || "Y\r"
                            int x = 0;
                            
                            foreach (string vv in Massiv)
                            {
                                if(vv == vvv)//Найден символ
                                {
                                    if (vv == "Y" || vv == "Y\r")
                                        mmindex += ("  " + ind_IDENT + "->" + Y_atribute + "  ");
                                    else
                                    {
                                        //Какой x_индекс у vvv в Massiv
                                        int dex = 0;
                                        //Сколько null от начала до vvv
                                        for (int k = 0; k < x; k++)
                                        {
                                            if (Massiv[k] == null) //[1]=null
                                                dex++; //+1
                                        }
                                        //Вычтем подсчитаное количество нулов (x-dex)
                                        mmindex += " " + (x - dex) + " ";
                                    }
                                }
                                x++;
                            }
                            ks++;//Поднятие индекса
                        }
                    }//End Foreach
                }//End While
            }//END Using

        }//END KOD()

        
        public string SSS()
        {//Перехват значений и отправка FormTable-->FormMain
            FormMain formMain = new FormMain();
            StaticDat.DataBuffer = mmindex;
            return formMain.textBoxOut.Text = mmindex;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        public static class StaticDat
        {//ПЕРЕДАЧА КОДОВ ЛЕКСЕМ ТЕКСТА В PARSER.cs
            //Буфер данных
            public static String DataBuffer = String.Empty;
        }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        public static class BuffWords
        {//ПЕРЕДАЧА ТЕКСТА В fParserLexical_OperatPredshest.cs
            //Буфер данных
            public static String DataBuffer = String.Empty;
        }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
    }//clFormTable()

}//END NAMESPACE()