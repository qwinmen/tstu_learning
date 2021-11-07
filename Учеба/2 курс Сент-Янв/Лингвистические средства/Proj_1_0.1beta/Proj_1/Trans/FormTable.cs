using System;
using System.IO;
using System.Windows.Forms;

namespace Trans
{
    public partial class FormTable : Form
    {
        public FormTable()
        {
            InitializeComponent();
            Leksema();
        }

        public string mmindex;

        public void Leksema()
        {

            string ass = "kol_1-Лексема";
            string kol2 = "kol_2-Код";
            string ID = "ident ";
            int max = 1;
            for (int increment = 0; increment < max; increment++)
            {//Общий счетчик выражений
                //int index = listViewKod_Table.Items.Add(ass).Index;//int index =increment ;
                //mmindex = increment.ToString();
                Kod(increment);//listViewKod_Table.Items[index].SubItems.Add(increment.ToString());
            }

            /*for (int i = max; i < 13; i++)
            {//Для идентификаторов
                int index1 = listViewKod_Table.Items.Add(ID + max).Index;
                listViewKod_Table.Items[index1].SubItems.Add(i.ToString());
            }*/

        }

        private int dlina;

        
        public void Kod(int index)
        {
            FormMain formMain=new FormMain();
            
            //string file="";
            //string[] argse = Environment.GetCommandLineArgs();
            //foreach (string wq in argse)
            //    file=wq;//Полный путь до .ЕХЕ

            //MessageBox.Show();
            char[] razdelenie = {' ','\n'};
            using (StreamReader reader = new StreamReader(FormMain.StaticData.DataBuffer))
            {
                //Безопасное открытие патока
                string[] Massiv;
                string[] Massiv_Index;
                int i = 0, j = 0;
                int trr = 0;
                while (!reader.EndOfStream)//(reader.Peek() > -1)
                {//0(аааа)-1(бббб)-2(сссс) строки
                    //В потоке возвращает целочисленное значение, 
                    //чтобы определить, произошла ошибка или достигнут конец файла(-1)
                    string s = reader.ReadToEnd();//ПОЛНОСТЬЮ!//ReadLine(); //Чтение ПОСТРОЧНО
                    dlina = s.Length;
                    string[] words = s.Split(razdelenie); //Делим строку на ПОДСТРОКИ

                    int flag = 0, flag_and = 0, flag_or = 0, flag_1 = 0, flag_2 = 0, flag_3 = 0; //Контроль повтора "Y"
                    string X_atribute = "1", Y_atribute = "2", Z_atribute = "3";

                    int ind_CONST = 0; //CONST_0 #2.5
                    int ind_IDENT = 1; //ID X->1
                    
                    Massiv = new string[words.Length];
                    Massiv_Index = new string[words.Length];
                    int E = 0,y=0,qw=0;
                    foreach (string ts in words)
                    {
                        //if (listViewKod_Table.SelectedItems != null)
                        //    Massiv[j] = listViewKod_Table.SelectedItems.ToString();
                        //Massiv[j] = listViewKod_Table.Items.Add(ts).ToString();
                        Massiv[j] = ts;
                        j++;
                        for (int e = 0; e < i; e++)
                            if (ts.CompareTo(Massiv[e]) == 0)
                            {//Если есть результ, то есть совпадение с текущим значением ts!
                                //Console.WriteLine("СОВПАДЕНИЕ С " + ts);
                                Massiv_Index[e] = ts;
                                Massiv[e] = null;//Занулим все совпадения
                            }
                        i++;


                        #region


                        //Вывод результата разбития в ТАБЛИЦУ
                        //int indEex = ts.IndexOf("if");
                        //if (indEex == 0)
                        //    listViewKod_Table.Items.Add("if");
/*
                        int ind_CONST = 0; //CONST_0 #2.5
                        int ind_IDENT = 1; //ID X->1
                        

                        if (ts == "2.5" || ts == "0.68" || ts == "2.8")
                        {
                            //Konstant
                            index = listViewKod_Table.Items.Add("CONST_" + ind_CONST).Index; //_0
                            listViewKod_Table.Items[index].SubItems.Add("#" + ts); //#2.5
                            mmindex += (ind_CONST + "#" + ts + " "); // SSS()+="#"+ts;
                        }
                        else if (ts == "X" || ts == "Y" || ts == "Z")
                        {
                            if (ts == "X")
                            {
                                index = listViewKod_Table.Items.Add("ID_" + ind_IDENT).Index; //_1
                                listViewKod_Table.Items[index].SubItems.Add(ts + "->" + X_atribute); //
                                mmindex += (" " + ind_IDENT + "->" + X_atribute);
                            }
                            if (ts == "Y")
                            {
                                //Без контроля на textBoxOut
                                mmindex += (" " + ind_IDENT + "->" + Y_atribute);
                                if (ts == "Y" && flag == 0)
                                {
                                    //Контроль на listViewKod_Table
                                    index = listViewKod_Table.Items.Add("ID_" + ind_IDENT).Index; //_1
                                    listViewKod_Table.Items[index].SubItems.Add(ts + "->" + Y_atribute); //
                                }
                            }flag = 1; //Контроль повтора "Y"
                            if (ts == "Z")
                            {
                                index = listViewKod_Table.Items.Add("ID_" + ind_IDENT).Index; //_1
                                listViewKod_Table.Items[index].SubItems.Add(ts + "->" + Z_atribute); //
                                mmindex += (" " + ind_IDENT + "->" + Z_atribute);
                            }
                        }
                        else
                        {
                            
                            
                            for (int e = 0; e < i; e++)
                                if (ts.CompareTo(Massiv[e]) == 0)
                                {//Если есть результ, то есть совпадение с текущим значением ts!
                                    //Console.WriteLine("СОВПАДЕНИЕ С " + ts);
                                    Massiv[e] = null;//Занулим все совпадения
                                }
                            i++;

                            foreach (string ss in Massiv)
                            {
                                if (ss != null)
                                {
                                    index = listViewKod_Table.Items.Add("AAAA").Index; //_1
                                    //listViewKod_Table.Items[index].SubItems.Add(index.ToString()); //
                                    //mmindex += (index);
                                }
                            }
                        }

                        

                        
                        //index = listViewKod_Table.Items.Add(ts).Index;//listViewKod_Table.Items.Add(ts);
                        //listViewKod_Table.Items[index].SubItems.Add(index.ToString());








                        mmindex += (" "+index+" ");//00_

*/

                        //index = listViewKod_Table.Items.Add(ts).Index;//listViewKod_Table.Items.Add(ts);
                        //listViewKod_Table.Items[index].SubItems.Add(index.ToString());

                        #endregion
                    }
                    int ks = 0,t=0,u=0,gr=0;
                    foreach (string ss in Massiv)
                    {
                        if (ss != null)
                        {//Шарим в ЗАНУЛЕНОМ МАСИВЕ!
                            //----------------------------------------------------------------//
                            //----------------------------------------------------------------//
                            ks++; 
                            if (ss == "2.5" || ss == "0.68" || ss == "2.8")
                            {//ловим Konstant
                                index = listViewKod_Table.Items.Add("CONST_" + ind_CONST).Index; //_0
                                listViewKod_Table.Items[index].SubItems.Add("#" + ss); //#2.5
                                mmindex += ("  "+ind_CONST + "#" + ss + "  "); // SSS()+="#"+ts;
                                //Massiv_Index[index] = index.ToString();
                              //  Massiv_Index[qw] += index.ToString();
                                qw++;
                                index++;
                                flag++;
                                //ks++; 
                            }
                            else if (ss == "X" || ss == "Y" || ss == "Z" || ss=="Y\r")
                            {//ловим идентификатор
                                if (ss == "X")
                                {
                                    
                                    index = listViewKod_Table.Items.Add("IDENT_" + ind_IDENT).Index; //_1
                                    listViewKod_Table.Items[index].SubItems.Add(ss + "->" + X_atribute); //
                                    mmindex += ("  " + ind_IDENT + "->" + X_atribute+"  ");
                                    flag++;
                                    //Massiv_Index[qw] += index.ToString();
                                    qw++;
                                    //ks++; 
                                    //Massiv_Index[index] = index.ToString();
                                }
                                if (ss == "Y" || ss == "Y\r")
                                {
                                    index = listViewKod_Table.Items.Add("IDENT_" + ind_IDENT).Index; //_1
                                    listViewKod_Table.Items[index].SubItems.Add(ss + "->" + Y_atribute); //
                                    mmindex += ("  " + ind_IDENT + "->" + Y_atribute+"  ");
                                    flag++;
                                    //Massiv_Index[qw] += index.ToString();
                                    //ks++; 
                                    qw++;
                                    //Massiv_Index[index] = index.ToString();
                                }
                                if (ss == "Z")
                                {
                                    index = listViewKod_Table.Items.Add("IDENT_" + ind_IDENT).Index; //_1
                                    listViewKod_Table.Items[index].SubItems.Add(ss + "->" + Z_atribute); //
                                    mmindex += ("  " + ind_IDENT + "->" + Z_atribute+"  ");
                                    flag++;
                                    //Massiv_Index[index] = index.ToString();
                                  //  Massiv_Index[qw] += index.ToString();
                                    qw++;
                                    //ks++; 
                                }
                                index++;
                                //ks++; 
                            }
                            else
                            {
                                listViewKod_Table.Items.Add(ss); //Колонка Лексемы
                                listViewKod_Table.Items[index].SubItems.Add(index.ToString()); //
                                //Massiv_Index[index] += index.ToString();
                                qw++;
                                mmindex += ("  " + index + " ");//mmindex += ("  $"+index+"$ ");
                                index++;

                                //ks++; 
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
                    }

                    /*int u = 1;
                    foreach (string df in words)//if
                    {
                        
                        //for (int e = 0; e < Massiv.Length; e++)
                        {
                            if (df.CompareTo(Massiv[u]) == 0)
                            {//Если есть результ, то есть совпадение с текущим значением ts!
                                //Console.WriteLine("СОВПАДЕНИЕ С " + ts);
                                if (u >= 1)
                                    mmindex += u - 1 + "  ";
                                else
                                    mmindex += u + "  ";
                            }
                            else
                            {
                                foreach (string ru in Massiv)
                                {
                                    if(ru!=null)
                                    if (ru==df)
                                    {
                                        mmindex += "else ";
                                    }
                                }
                            }

                        }
                        //trr++;
                        //else//Совпадений нет
                        //mmindex += df + "  ";

                    }
                    */

                    
                }

            }

        }//END KOD()


        public string SSS()
        {//Перехват значений и отправка FormTable-->FormMain
            FormMain formMain = new FormMain();

            return formMain.textBoxOut.Text = mmindex;
        }


    }//clFormTable()

}//END NAMESPACE()



/*
                             else
                            {//Проч код потока
                                /*if (ts == "AND" || ts=="OR" || ts=="(" || ts==")" || ts=="'")
                                    {
                                        //mmindex += (" " + index + " ");
                                        if(ts == "AND" && flag_and==0)
                                        {
                                            index = listViewKod_Table.Items.Add("AND").Index; //_1
                                            listViewKod_Table.Items[index].SubItems.Add(index.ToString()); //
                                            flag_and = 1;
                                        } 
                                        if (ts == "OR" && flag_or == 0)
                                        {
                                            index = listViewKod_Table.Items.Add("OR").Index; //_1
                                            listViewKod_Table.Items[index].SubItems.Add(index.ToString()); //
                                            flag_or = 1;
                                        }
                                        if (ts == "(" && flag_1 == 0)
                                        {
                                            index = listViewKod_Table.Items.Add("(").Index; //_1
                                            listViewKod_Table.Items[index].SubItems.Add(index.ToString()); //
                                            flag_1 = 1;
                                        }
                                        if (ts == ")" && flag_2 == 0)
                                        {
                                            index = listViewKod_Table.Items.Add(")").Index; //_1
                                            listViewKod_Table.Items[index].SubItems.Add(index.ToString()); //
                                            flag_2 = 1;
                                        }
                                        if (ts == "'" && flag_3 == 0)
                                        {
                                            index = listViewKod_Table.Items.Add(ts).Index; //_1
                                            listViewKod_Table.Items[index].SubItems.Add(index.ToString()); //
                                            flag_3 = 1;
                                        }
                                        flag_and = 1;
                                        flag_or = 1;
                                        flag_1 = 1;
                                        flag_2 = 1;
                                        flag_3 = 1;

                                    }
                                
                                */