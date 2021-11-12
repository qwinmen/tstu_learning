using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Mary
{//FormTable.cs реализует лексический анализ
    public partial class FormTable : Form
    {
        public FormTable()
        {
            InitializeComponent();
            Leksema();
        }

        private string _mmindex;

        /// <summary>
        /// Анализ в один проход
        /// </summary>
        private void Leksema()
        {
            for (int increment = 0; increment < 1; increment++)//Общий счетчик выражений
                Kod(increment);
        }

        private static string[] _words;
        public void Kod(int index)
        {
            char[] razdelenie = { ' ', '\n', '\r', '\t' };

            using (new StreamReader(fMain.StaticData.DataBuffer))
            {//Безопасное открытие патока
                int i = 0, j = 0;

                string s = fMain.TxtBoxInText;

                _words = Filter(s).Split(razdelenie);//убираем пробелы\табы\&etc

 /*---parser----*/        ParsFortran(_words);

                string[] Massiv = new string[_words.Length], Massiv_Index = new string[_words.Length];

                foreach (string ts in _words)
                {//нулим все повторения
                    Massiv[j] = ts;
                    j++;
                    for (int e = 0; e < i; e++)
                        if (ts.CompareTo(Massiv[e]) == 0)
                        {//Если есть результ, то есть совпадение с текущим значением ts!
                            Massiv_Index[e] = ts;
                            Massiv[e] = null; //Занулим все совпадения
                        }
                    i++;
                }
                ЛексемыБезПовторов = Massiv;
                int ks = 0;
                foreach (string ss in Massiv)
                {
                    if (ss != null) //пишeм в Таблицу и в txtOUT
                    {//Шарим в ЗАНУЛЕНОМ МАСИВЕ!
                        //----------------------------------------------------------------//
                        //----------------------------------------------------------------//
                        ks++;
                        IdConstVisual(ss, index);
                        index++;
                        //----------------------------------------------------------------//
                        //----------------------------------------------------------------//
                    }
                    else //Иначе надо null заменить значением
                    {//ss = null, пишем только в txtOUT
                        string vvv = Massiv_Index[ks]; //";" || "Y\r"
                        int x = 0;

                        foreach (string vv in Massiv)
                        {
                            if (vv == vvv && vv != "") //vv != "" для отсева пустышек
                            {//Найден символ [2];<<=;[61]
                                IdConstVisual(vv, index, 1, x, Massiv);
                            }
                            x++; //контроль индекса у vv
                        }
                        ks++; //Поднятие индекса
                    }
                } //End Foreach
            }//END Using
        }//END KOD()

        #region Filter знаки препинания
        private delegate string StrMod(string s);
        /// <summary>
        /// На вход строка с файла\\ на выход строка с отделёными зн. препинания
        /// </summary>
        private string Filter(string strIn)
        {
            StrMod aa = res =>
            {
                string temp = "";//для новой строки из старой
                int index = 0;//для посмотреть символ за ':'
                bool flag = false;//если true то 1 проход foreach надо пропустить
                foreach (char ch in res)
                {
                    if (fPunct.PunctArr!=null)
                    {//если в базе данных есть записи то:
                        if (!flag && index < res.Length)//чтоб не вылезти за [границы]
                            temp += Compare(ch, res, ref index, ref flag);
                        else flag = false;//сбросим flag после ':='
                    }
                    else
                    #region если база неподключена, то используем умолчания:
                    {
                        if (!flag && index < res.Length)//чтоб не вылезти за [границы]
                            switch (ch)
                            {//текущая пунктуация//
                                case '(': temp += " ( ";
                                    break;
                                case ')': temp += " ) ";
                                    break;
                                case '*': temp += " * ";
                                    break;
                                case '+': temp += " + ";
                                    break;
                                case ',': temp += " , ";
                                    break;
                                case '-': temp += " - ";
                                    break;
                                case '.': temp += " . ";
                                    break;
                                case ':':
                                    if (res[index + 1] == '=')//смотрим следущий за ':' символ
                                    {//если за ':' идет '='
                                        temp += " := ";
                                        flag = true;//т.е. надо 1 проход foreach пропустить, т.к. там '='
                                    }
                                    else temp += " : ";//если за ':' идет лаб:уда
                                    break;
                                case ';': temp += " ; ";
                                    break;
                                case '=': temp += " = ";
                                    break;
                                default: temp += ch;
                                    break;
                            }
                        else flag = false;//сбросим flag после ':='

                    }
                    #endregion

                    index++;//храним текущую позицию ch в res
                }
                return temp;
            };
            StrMod strOp = aa;
            return strOp(strIn);
        }

        /// <summary>
        /// Используем знаки с базы данных fPunct.PunctArr вместо явной ветки с пунктуацией
        /// </summary>
        private string Compare(char ch, string res, ref int index, ref bool flag)
        {
            string temp = "";
            foreach (string s in fPunct.PunctArr)//заглушка для break
            {
                if (frch(ch))
                {
                    if (ch == ':')
                    {//если это двоеточие, то
                        if (res[index + 1] == '=')//смотрим следущий за ':' символ
                        {//если за ':' идет '='
                            temp += " := ";//значит это сцепка ":="
                            flag = true; //т.е. надо 1 проход foreach пропустить, т.к. там '='(void Filter)
                        }
                        else temp += " " + ch + " ";//иначе это просто одиночное двоеточие
                        break;
                    }
                    temp += " " + ch + " ";//если это другие знаки разделители, которые есть в базе:
                    break;
                }
                temp += ch;//иначе тут только лексемы без разделителей:
                break;
            }
            return temp;
        }

        /// <summary>
        /// если ch есть в БазеДанных, то вернет true
        /// </summary>
        private bool frch(char ch)
        {
            return fPunct.PunctArr.Any(s1 => s1 == ch.ToString());
        }

        #endregion

        #region IdConstVisual визуально ID->1, Const#1 и т.п.
        /// <summary>
        /// Выводим в FormTable и txtOUT визуально ID->1, Const#1 и т.п.
        /// </summary>
        private void IdConstVisual(string ss, int index, params object[] flag)
        {//если flag[]=true, то изменить только _mmindex
            //*****ЯВНОЕ*ОБЬЯВЛЕНИЕ*ЧТО*СЧИТАТЬ*ID*CONST*****
            const string K16_atribute = "1",
                         i_atribute = "2",
                         n_atribute = "3",
                         integer_atribute = "4",
                         p_atribute = "5",
                         a_atribute = "6",
                         real_atribute = "7";
            const int ind_CONST = 45; //CONST_0 #2.5
            const int ind_IDENT = 1; //ID X->1
            //***********************************************
            switch (ss)
            {
                case "1"://ловим Konstant
                    if (flag.Length == 0)//flag=false
                    {
                        index = listViewKod_Table.Items.Add("CONST_" + ind_CONST).Index; //_0
                        listViewKod_Table.Items[index].SubItems.Add("#" + ss); //#1
                    }
                    _mmindex += ("  " + ind_CONST + "#" + ss + "  "); // SSS()+="#"+ts;
                    break;
                case "K16"://ловим идентификатор
                    if (flag.Length == 0)//flag=false
                    {
                        index = listViewKod_Table.Items.Add("IDENT_" + ind_IDENT).Index; //_1
                        listViewKod_Table.Items[index].SubItems.Add(ss + "->" + K16_atribute); //
                    }
                    _mmindex += ("  " + ind_IDENT + "->" + K16_atribute + "  ");
                    break;
                case "i":
                    if (flag.Length == 0)//flag=false
                    {
                        index = listViewKod_Table.Items.Add("IDENT_" + ind_IDENT).Index; //_1
                        listViewKod_Table.Items[index].SubItems.Add(ss + "->" + i_atribute); //
                    }
                    _mmindex += ("  " + ind_IDENT + "->" + i_atribute + "  ");
                    break;
                case "n":
                    if (flag.Length == 0)//flag=false
                    {
                        index = listViewKod_Table.Items.Add("IDENT_" + ind_IDENT).Index; //_1
                        listViewKod_Table.Items[index].SubItems.Add(ss + "->" + n_atribute); //
                    }
                    _mmindex += ("  " + ind_IDENT + "->" + n_atribute + "  ");
                    break;
                case "integer":
                    if (flag.Length == 0)//flag=false
                    {
                        index = listViewKod_Table.Items.Add("IDENT_" + ind_IDENT).Index; //_1
                        listViewKod_Table.Items[index].SubItems.Add(ss + "->" + integer_atribute); //
                    }
                    _mmindex += ("  " + ind_IDENT + "->" + integer_atribute + "  ");
                    break;
                case "p":
                    if (flag.Length == 0)//flag=false
                    {
                        index = listViewKod_Table.Items.Add("IDENT_" + ind_IDENT).Index; //_1
                        listViewKod_Table.Items[index].SubItems.Add(ss + "->" + p_atribute); //
                    }
                    _mmindex += ("  " + ind_IDENT + "->" + p_atribute + "  ");
                    break;
                case "a":
                    if (flag.Length == 0)//flag=false
                    {
                        index = listViewKod_Table.Items.Add("IDENT_" + ind_IDENT).Index; //_1
                        listViewKod_Table.Items[index].SubItems.Add(ss + "->" + a_atribute); //
                    }
                    _mmindex += ("  " + ind_IDENT + "->" + a_atribute + "  ");
                    break;
                case "real":
                    if (flag.Length == 0)//flag=false
                    {
                        index = listViewKod_Table.Items.Add("IDENT_" + ind_IDENT).Index; //_1
                        listViewKod_Table.Items[index].SubItems.Add(ss + "->" + real_atribute); //
                    }
                    _mmindex += ("  " + ind_IDENT + "->" + real_atribute + "  ");
                    break;
                default://лексемы-знаки и т.п.:
                    if (ss != "")
                    {
                        if (flag.Length == 0) //массив flag пуст
                        {
                            listViewKod_Table.Items.Add(ss); //Колонка Лексемы
                            listViewKod_Table.Items[listViewKod_Table.Items.Count - 1].SubItems.Add(index.ToString());//Колонка Код
                            _mmindex += ("  $" + index + "$ "); //_mmindex += ("  " + index + " ");//
                        }
                        else
                        {//Какой x_индекс у vvv в Massiv
                            int dex = 0;
                            //Сколько null от начала до vvv
                            for (int k = 0; k < (int) flag[1]; k++) //flag[1]=x
                            {
                                if (((string[]) flag[2])[k] == null) //Massiv[k]==null
                                    dex++; //+1
                            }
                            //Вычтем подсчитаное количество нулов (x-dex)
                            _mmindex += " " + ((int) flag[1] - dex) + " ";
                        }
                    }
                    break;
            }//end Switch
        }
        #endregion

        /// <summary>
        /// Перехват значений и отправка с FormTable-->fMain
        /// </summary>
        internal string SSS()
        {
            fMain formMain = new fMain();
            StaticDat.DataBuffer = _mmindex;
            TableCountStr = listViewKod_Table.Items.Count;//сколько строк столько и лексем
            return formMain.textBoxOUT.Text = _mmindex;
        }

        private string _rtf = "";
        internal void ParsFortran(string[] index)
        {
            string[] fortranArr = {"Program", "Read", "=", "Write", "end", "stop", ",", "do", "continue"};
            int i = 0, iBgn = 0;//s[i]//[iBgn]="begin"
            
            int[] idIndex = new int[4];//для индексов каркаса
            Indikation = new[]
                             {
                                 new KeyValuePair<bool, int>(ПроверкаКаркасаПрограммы("Program", index, out idIndex[0]), 0),
                                 new KeyValuePair<bool, int>(ПроверкаКаркасаПрограммы("Var", index, out idIndex[1]), 1),
                                 new KeyValuePair<bool, int>(ПроверкаКаркасаПрограммы("Begin", index, out idIndex[2]), 2),
                                 new KeyValuePair<bool, int>(ПроверкаКаркасаПрограммы("End", index, out idIndex[3]), 3)
                             };
            ZnakProgramToVar = new KeyValuePair<int, int>[Indikation.Length];//4
            if (Indikation[1].Key)//есть Var
            {//от Program до Var
                int pv;//idIndex[1]=Var
                SearchProgramToVar(idIndex[1], index, out pv);//поиск ;
                if (pv == 01) ZnakProgramToVar[0] = new KeyValuePair<int, int>(0, 1);
            }if(Indikation[2].Key)//есть Begin
            {//от Var до Begin
                int pv;
                if (idIndex[1] != index.Length) SearchVarToBegin(idIndex[2], index, out pv, idIndex[1]);//idIndex[2]=Begin
                else SearchVarToBegin(idIndex[2], index, out pv);//иначе нету Var и поиск от начала до Begin
                if (pv == 12) ZnakProgramToVar[1] = new KeyValuePair<int, int>(1, 2);
            }if(Indikation[2].Key)//есть Begin
            {//от Begin до End ИЛИ от Begin до конца
                int pv;
                if (idIndex[3] != index.Length) SearchBeginToEnd(idIndex[2], index, out pv, idIndex[3]);//idIndex[3]=end
                else SearchBeginToEnd(idIndex[2], index, out pv);//иначе нету у нас end, ищем до конца
                if (pv == 23) ZnakProgramToVar[2] = new KeyValuePair<int, int>(2, 3);
            }

            foreach (string s in index)
            {

                if (";" == s)_rtf += Environment.NewLine;
                if (AravnoB("var",s)) _rtf += ОписаниеПеременных(i, ref index, out iBgn);

                foreach (string s1 in fortranArr)
                {
                    if (AravnoB("for", s) & AravnoB("do", s1))//for i:=1 to n do <ТелоЦикла>;
                    {
                        _rtf += s1 + " " + i + " ";//do_metka_
                        if (index[i + 2] == ":=")
                        {//i_=_1_
                            _rtf += index[i + 1] + " = " + index[i + 3] + " ";
                            index[i + 2] = index[i + 3] = "";//:= 1

                            if (AravnoB(index[i + 4],"to"))//if (index[i + 4] == "to")
                            {
                                _rtf += ", " + index[i + 5] + " ";//,_n_
                                index[i + 5] = "";//n

                                _rtf += ТелоЦикла(i + 7, ref index);
                            }
                        }
                        _rtf += Environment.NewLine + i + " continue";//_metka_continue
                    }
                    else if (!AravnoB("do", s))
                    {
                        if (/*iBgn != 0 &&*/ s == ":=" && s1 == "=")//begin||;...:=...;
                        {
                            _rtf += ОператорПрисваивания(i, iBgn, index);
                        }
                        

                        if (AravnoB(s1, s))
                        {
                            bool flag = false;
                            for (int j = i; j < iBgn; j++)
                            {//var[i]...begin[iBgn]
                                if (s == ",")
                                {
                                    _rtf += "";//спрятать запятые в блоке обьявления переменых
                                    flag = true;//без затирания в основном массиве index
                                }
                            }

                            if (AravnoB("end", s))
                                _rtf += Environment.NewLine + s;
                            else if (AravnoB("write", s1) | AravnoB("read", s1))
                            {//ищем от write до ")"
                                if (FindAtoB(i + 1, ")", ref index) == "<Ошибка>")
                                    _rtf += s1 + "(*,* " + FindAtoB(i + 1, ")", ref index);
                                else
                                {
                                    _rtf += s1 + "(*,*) " + FindAtoB(i + 1, ")", ref index);
                                    if (!SearchSkbToTzpt(i, index, ")")) ZnakProgramToVar[2] = new KeyValuePair<int, int>(2, 3);//MessageBox.Show("Нету ;");//искать от ) знак ';'
                                }//MessageBox.Show(FindAtoB(i, ".", ref index));
                            }
                            else if (!flag)
                                if (AravnoB("Program", s)) _rtf += s + " " + FindAtoB(i, ";", ref index) + " ";//if (s == "K16") rtf += s + " ";
                                //rtf += s1 + " ";
                        }
                    }//end ElseIf

                }//end foreach (string s1 in fortranArr)
                i++;
            }//end foreach (string s in index)
            
        }

        /// <summary>
        /// поиск от iА до "B" в массиве index
        /// </summary>
        private string FindAtoB(int iA, string b, ref string[] index)
        {//a="Program", b=";", regExp="<ID>"
            int iB = 0,ut=0; string str = "";
            for (int i = iA; i < index.Length; i++)//кто первый - того и тапки:
            {//нашли ; стоп. Ненашли ; - нашли Var стоп
                if (index[i] == ";" && b != ";") ut--;//ищем b до ; Если его нет, то понижаем индекс
                if (index[i] == b || AravnoB("var", index[i]))
                {
                    ut++;//ищем b до ; Если он есть, то повышаем индекс
                    break;
                }
                    iB++;
            }
            if (iB == 0) MessageBox.Show("Знака " + b + " ненайдено!","*Косяк в тексте");
            if (ut <= 0) MessageBox.Show("Знака " + b + " ненайдено!", "**Косяк в тексте");
            for (int i = iA + 1; i < (iB+iA); i++)//[iA]=Program
            {//от [iA]..[iB] чето найти
                if (index[i] != "") str += index[i];
            }
            if (str == "" || ut <=0) str = "<Ошибка>";
            return str;//K16
        }

        /// <summary>
        /// Блок от Var до Begin
        /// </summary>
        private string ОписаниеПеременных(int iVar, ref string[] index, out int iBgn)
        {//после var[5]
            string stroka = "", strForRepitId = "";
            int iBegin = 0, iTemp = iVar;
            //от var до первого begin раздел описания переменных
            iBegin = index.TakeWhile(s => !AravnoB("begin", s)).Count();
            iBgn = iBegin;
            for (int i = iVar; i < iBegin; i++)
            {
                if (index[i] == ";")
                {
                    stroka += Environment.NewLine;
                    for (int j = iTemp; j < i; j++)
                    {
                        if (index[j] == ":")
                        {
                            //переставить местами А[iTemp..j]:B[j..i];
                            for (int k = j + 1; k < i; k++)//+1 = непишем :
                            {//<тип>
                                if (index[k] != "") stroka += index[k] + " ";
                            }
                            for (int l = iTemp + 1; l < j; l++)//+1 = непишем var||;
                            {//<ID,>
                                //MessageBox.Show("iTemp="+iTemp+" j="+j+" i="+i);
                                stroka += index[l] + " ";
                                //если возникло совпадение id=id, то надо подсветить:
                                //с индекса на длинну ID
                                if (index[l] != "" & index[l] != ",")//если там чето есть кроме зпт
                                    strForRepitId += index[l] + ":" + l + "$" + index[l].Length + "%";// "id:index$length%"
                            }
                        }
                        
                    }
                    iTemp = i;
                }
            }

            Dictionary<int, int> dictionary = IndexLengthRepitId(strForRepitId);//MessageBox.Show(strForRepitId,"Надо подсветить:");
            if (dictionary.Count != 0)
            {
                ErrRepitId = new KeyValuePair<int, int>[dictionary.Count/*скоко ошибок*/];
                int indexator = 0;
                foreach (KeyValuePair<int, int> keyValuePair in dictionary)
                {
                    if (indexator < ErrRepitId.Length)
                    {
                        //Это история о том, сколько знаков от начала программы до [keyValuePair.Key]
                        string ads = "";
                        for (int i = 0; i < keyValuePair.Key; i++)
                        {
                            if (index[i] == "") ads += " ";
                            else ads += index[i];
                        }//Конец истории, знаки запакованны в строку.Length
                        ErrRepitId[indexator] = new KeyValuePair<int, int>(ads.Length + 2, keyValuePair.Value);
                    }
                    indexator++;
                }
            }else ErrRepitId = new[] {new KeyValuePair<int, int>(0, 0)};
            
            return stroka;
        }
        
        /// <summary>
        /// p:=p*(a+i-1);
        /// </summary>
        private string ТелоЦикла(int i, ref string[] index)
        {
            string telo = "";
            for (int j = i; j < index.Length; j++)
            {
                if (index[j]==";")
                {
                    for (int k = i; k < j; k++)
                    {
                        if (index[k] == ":=")
                        {
                            index[k] = "";
                            telo += "=";
                        }
                        else
                        {
                            telo += index[k];
                        }
                        
                    }
                    break;
                }
            }
            return telo;
        }

        /// <summary>
        /// Ищет выражения от begin или ; ДО ; или end
        /// ПРИМЕР: begin a:=b; || Read(); a:=b end || Write(); a:=b;
        /// </summary>
        private string ОператорПрисваивания(int i, int iBegin, string[] index)
        {//любое присваивание в begin...end
            //знаем := //Находим ; или begin//Находим ; или (end-не реализовано!)
            string str = ""; int temp = iBegin, endTemp = -1;
            for (int j = iBegin; j < i; j++)//от begin до :=
                if (index[j] == ";") temp = j;//ищем ;
            //если не нашли, то в temp пишем iBegin

            for (int j = i; j < index.Length; j++)//от := до ;||end
            if(index[j]==";" | "end".Equals(index[j],StringComparison.OrdinalIgnoreCase))
            { endTemp = j; break; }

            if (temp != -1 && endTemp != -1)//т.е. знак ; найден
            {
                for (int j = temp + 1; j < endTemp; j++)//begin a:=b; || ; a:=b;
                {
                    if (index[j] == ":=") str += "=";
                    else if (index[j] != "") str += index[j];
                }
            }else if(temp == -1)MessageBox.Show("Нет begin ИЛИ ; до знака :=");
             else if (endTemp == -1) MessageBox.Show("Нет ; ИЛИ end после знака :=");

            return str;
        }

        #region Проверим наличие Program-;-Var-;-Begin-;-End
        /// <summary>
        /// Каркас проверки Program..;Var..;Begin..end
        /// </summary>
        private bool ПроверкаКаркасаПрограммы(string s, IEnumerable<string> index, out int idIndex)
        {// s[i] in index
            bool flag = false;
            int sIndex = 0;
            foreach (string s1 in index)
            {
                if (AravnoB(s1, s))
                {
                    flag = true;
                    break;
                }
                sIndex++;
            }
            idIndex = sIndex;//if (flag) MessageBox.Show("Нет " + s + " "+sIndex,"Косяк каркаса");
            return flag;
        }

        /// <summary>
        /// От Program до Var долж быть только один ";" проверим
        /// </summary>
        private void SearchProgramToVar(int iVar, string[] res, out int pv)
        {// res[index]="var"
            int count = 0, iTo = 0, uInd=0;
            for (int i = 0; i < iVar; i++)
            {
                if (res[i] == ";")
                {
                    uInd = i;
                    count++;
                }
                
            } if (count != 1 && Indikation[0].Key) pv = 01;//MessageBox.Show("Нет ; между Program и Var", "Косяк пунктуации");
            else pv = -1;
            
            for (int i = iVar-1; i > uInd; i--)//реверс
            {//от Var до ; если она есть
                if (res[i] != "" && res[i] != ";") iTo++;//=0 то Ок, иначе Косяк
            } if (iTo != 0) pv = 01;//MessageBox.Show(iTo.ToString());
        }

        /// <summary>
        /// От Var до Begin сколько ':' столько ';'
        /// Если нет Var, то от Begin до 0-начала программы
        /// </summary>
        private void SearchVarToBegin(int iBegin, string[] res, out int pv, params int[] iVar)
        {//idIndex[2], index, out pv
            int iV = 0;//если iVar пуст(те нету ID), то ';' на один больше чем ':'
            List<int> ttIndex=new List<int>();//лист тк непойми сколько этих ':'
            List<int> zptIndex = new List<int>();//лист тк непойми сколько этих ';'
            if (iVar.Length != 0) iV = iVar[0];//MessageBox.Show(iV.ToString());
            for (int i = iBegin; i > iV; i--)//реверс от begin до var
            {
                if (res[i] == ":") ttIndex.Add(i);
                if(res[i]==";")zptIndex.Add(i);
            } if (ttIndex.Count > zptIndex.Count && iV!=0) pv = 12;//MessageBox.Show("Нехватает ;", "Var  Begin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (ttIndex.Count < zptIndex.Count && iV!=0) pv = 12;//MessageBox.Show("Нехватает :", "Var  Begin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else pv = 00;

            if (ttIndex.Count == zptIndex.Count && ttIndex.Count != 0 && zptIndex.Count != 0)
                for (int q = 0; q < ttIndex.Count; q++)
                {//от ':' до ';' ровно один ID-типа, если это не так - то ошибка
                    int countId = 0;
                    for (int i = ttIndex[q] + 1; i < zptIndex[q]; i++)
                        if (res[i] != "") countId++;
                    if (countId != 1) pv = 12;//MessageBox.Show("Между : и ; перебор/нехватка ID-типов", "Var  Begin", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            pv = pv != 12 ? 00 : 12;//при косяке = 12
        }

        /// <summary>
        /// От Begin до End
        /// Если нет End, то от Begin до конца
        /// </summary>
        private void SearchBeginToEnd(int iBegin, string[] res, out int pv, params int[] iEnd)
        {
            int iE = res.Length;//самый конец
            if (iEnd.Length != 0) iE = iEnd[0];//MessageBox.Show(iE.ToString());
            for (int i = iBegin; i < iE; i++)
            {//от Begin до End|res.Length
                //надо обработать а=и выражения //и фот ту ду
            }

            pv = 00;
        }

        /// <summary>
        /// Write\Read При поиске от ) до ; недолжно быть ID иначе косяк ИЛИ кроме ID=End
        /// </summary>
        private bool SearchSkbToTzpt(int i, string[] index, string str)
        {//index[i]='Id' надо найти ')', и потом ';'
            bool state = false;
            int iSkb = 0;//индекс )
            for (int j = i; j < index.Length; j++)
                if (AravnoB(index[j],str))
                {
                    iSkb = j;
                    break;
                }
            int iId = 0;
            for (int j = iSkb+1; j < index.Length; j++)//от ) до первой ; ИЛИ до конца
            {
                if (index[j] == ";")
                {
                    state = true;
                    break;
                }
                if (index[j] != "" && !AravnoB(index[j],"end")) iId++;//т.е. есть между ) ; какието знаки
            }
            if (iId != 0 && state) state=false;//MessageBox.Show("Между ) и ; есть лишние ID");
            else if (iId == 1 && !state) state=true;//MessageBox.Show("Между ) и Концом есть ID=end");
            else if(iId==0 && state) state = true;

            return state;//false при 'ненайден знак'
        }

        #endregion

        /// <summary>
        /// if(a==b)return true. Без учета регистра!
        /// </summary>
        private bool AravnoB(string a, string b){return a.Equals(b, StringComparison.InvariantCultureIgnoreCase);}
        
        /// <summary>
        /// На вход все подряд ID, на выходе те ID, которые нужно подкрасить красным
        /// index[l] + ":" + l + "$" + index[l].Length + "%";
        /// </summary>
        private Dictionary<int,int> IndexLengthRepitId(string strFull)
        {
            string str = ""; Dictionary<int,int> keyValue=new Dictionary<int, int>();
            string[] arr = strFull.Split('%'), massiv = new string[arr.Length];
            int i = 0, j = 0;
            foreach (string ts in arr)
            {
                if(ts!="")
                {
                    massiv[j] = ts;
                    j++;
                    
                    string tmp = ts.Substring(0, ts.IndexOf(':'));//id без хвоста
                    for (int e = 0; e < i; e++)
                        if (massiv[e] != null && AravnoB(tmp, massiv[e].Substring(0, massiv[e].IndexOf(':'))) )
                        {//Если есть результ, то есть совпадение с текущим значением ts!
                            string key = ts.Substring(ts.IndexOf(':') + 1, ts.IndexOf('$') - ts.IndexOf(':') - 1 );
                            string value = ts.Substring(ts.IndexOf('$') + 1);
                            keyValue.Add(Convert.ToInt32(key), Convert.ToInt32(value));
                            str += ts+"%";//необязательно
                            massiv[e] = null;//Занулим все совпадения
                        }
                    i++;
                }
                
            }//MessageBox.Show(str, "Это:надо$подсветить%");

            return keyValue;//это надо выделить
        }

        /// <summary>
        /// вывод в текстовую область Фортран
        /// </summary>
        internal string SFP()
        {
            fMain formMain = new fMain();
            return formMain.txtBoxFortranOUT.Text = _rtf.ToUpper();//fortranArr[i].ToUpper();
        }

        /// <summary>
        /// храним количество строк в таблице
        /// </summary>
        internal static int TableCountStr { get; private set; }
        
        /// <summary>
        /// храним лексемы из входного файла
        /// </summary>
        internal static string[] ЛексемыБезПовторов { get; private set; }

        /// <summary>
        /// ошибочный Id. Key=от, Value=id.Length выделить
        /// </summary>
        internal static KeyValuePair<int,int>[] ErrRepitId { get; private set; }

        /// <summary>
        /// Неполадки в каркасе bool=Red\Green int=0_program..3_End
        /// </summary>
        internal static KeyValuePair<bool, int>[] Indikation { get; private set; }

        /// <summary>
        /// 0_1 отобразить косяк отсутствия ;
        /// </summary>
        internal static KeyValuePair<int, int>[] ZnakProgramToVar { get; private set; }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        internal static class StaticDat
        {//ПЕРЕДАЧА КОДОВ ЛЕКСЕМ ТЕКСТА В PARSER.cs
            //Буфер данных
            internal static String DataBuffer = String.Empty;
        }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        internal static class BuffWords
        {//ПЕРЕДАЧА ТЕКСТА В fParserLexical_OperatPredshest.cs
            //Буфер данных
            internal static String DataBuffer = String.Empty;
        }

        private void FormTable_Load(object sender, EventArgs e)
        {
            try
            {
                columnHeader1.Width = columnHeader2.Width = 115;
                ClientSize = new System.Drawing.Size(columnHeader1.Width + 140, _mmindex.Length + 200);
            }
            catch (NullReferenceException)
            {
                columnHeader1.Width = columnHeader2.Width = 115;
            }
        }
        
    }
}
