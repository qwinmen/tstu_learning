using System;
using System.IO;
using System.Windows.Forms;
//ЛПО лаб_2
namespace Trans
{//fParserLexical.cs реализует синтаксический анализ методом рекурсивного спуска
    public partial class fParserLexical : Form
    {
        public fParserLexical()
        {
            InitializeComponent();
            InStrim();
        }
private static int[] arrInt = { 0/*0*/, 2/*1*/, 4/*2*/, 7/*3*/, 9/*4*/, 10/*5*/, 12/*6*/, 13/*7*/,
								14/*8*/, 16/*9*/, 17/*10*/ };
private static string[] arrConst = { "45#2.5"/*0*/, "45#0.68"/*1*/, "45#2.8"/*2*/, "45#Верно"/*3*/ };
private static string[] arrIdent = { "1->1"/*0*/, "1->3"/*1*/, "1->2"/*2*/ };
private static int lenght = arrInt.Length + arrConst.Length + arrIdent.Length;
        private static string[] InStream;
        private static string[] arrStream;
        public void bb()
        {//Проблема переброски кодов лексем из formTable.cs
            InStream = new string[FormTable.words.Length];//Инициализация
            arrStream = new string[FormTable.words.Length];
            char[] razdelenie = { ' ' };
            string mmindex = FormTable.StaticDat.DataBuffer;
            InStream = mmindex.Split(razdelenie);
            int i = 0;            
            foreach (string s in InStream)
            {
                if (s != "")
                {
                    arrStream[i] = s;
                    i++;
                }
            }
            /*В итоге получим масив сзначениями кодов*/
        }
        private ListViewItem newGroup,newGroupB,newGroupTHEN;
        void InStrim()//Точка входа
        {//Граматика == ВыходСПервойЛабы(arrStream)
            bb();
            bool res0 = false, res1 = false, res2 = false, res3 = false;
            if (arrStream[0] == arrInt[0].ToString())//Проверить IF
            {
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                listView_ParserSintax.Items.Add("IF");
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                if (arrStream[1] == arrInt[8].ToString() && arrStream[7] == arrInt[10].ToString())//Проверить ( и )
                {
                    if (arrStream[5] == arrInt[2].ToString())//Проверить <=//ЗНАК
                    {
                        if (Poisk_A() == 1 && Poisk_B() == 1)//1 это Отсутствие знака
                        {//Сразу Res:=(A<=B)
                            //Console.WriteLine("сразу Res0:=(A<=B)");
                            ListViewItem newGroup1 = new ListViewItem("<=");
                            newGroup1.SubItems.Add("Res1");
                            newGroup1.SubItems.Add("Const3");
                            newGroup1.SubItems.Add("Res0");
                            listView_ParserSintax.Items.Add(newGroup1);
                            res0 = true;
                        }
                        else
                        {//Иначе есть операция (+), уточним где:
                            if (Poisk_A() == 110 && Poisk_B()==1)
                            {//Метод A+B до ЗНАКА
                                //Console.WriteLine("RES110:=A+B");
                                ListViewItem newGroup = new ListViewItem("+");
                                newGroup.SubItems.Add("Slag1");
                                newGroup.SubItems.Add("Slag2");
                                newGroup.SubItems.Add("Res0");
                                listView_ParserSintax.Items.Add(newGroup);
                                res0 = true;
                            }
                            if (res0)
                            {//Выполим псевдо сравнение Res0:=(A<=B)
                             //Console.WriteLine("Res1:= (A<=B)");
                                ListViewItem newGroup = new ListViewItem("<=");
                                newGroup.SubItems.Add("Res0");
                                newGroup.SubItems.Add("Const3");
                                newGroup.SubItems.Add("Res1");
                                listView_ParserSintax.Items.Add(newGroup);
                            }
                            /*БЛОК IF(A<=B) ЗАКОНЧИЛ РАБОТУ*/
                        }
                    }
                } int flagProxod = 0;
                int key = 0;
                for (int p = 7; p < 17; p++)
                {key=p;//16
                    if (arrStream[p] == arrInt[3].ToString())//Проверить что есть от ")" до "THEN"
                    {//OR == OR//по типу if
                        if (flagProxod == 0)//Сагрится на OR0
                        {//С помощью flagProxod контролируем OR0,OR1,..
                            bool flag_AND = false; int A = 0, B = 0;
                            for (int i = 8; i < 11; i++)//Проверить знак AND
                            {//8 OR 9-А 10-ЗНАК 11-В
                                if (arrStream[i] == arrInt[4].ToString())
                                {//Найден AND
                                    flag_AND = true;
                                    A = i - 1; B = i + 1;
                                    newGroup = new ListViewItem("AND");
                                }
                            }
                            if (flag_AND)
                            {//Если есть AND то есть и выражения по обе стороны
                                if (Proverka_AandB(A, B) == 2)//Проверим это утверждение
                                {
                                    //Console.WriteLine("Res1:= (A AND B)");
                                    newGroup.SubItems.Add("Res2");
                                    listView_ParserSintax.Items.Add(newGroup);//Група закрылась
                                    res1 = true;
                                }
                            }
                        }
                        if (flagProxod == 1)//Сагрится на OR1
                        {//Теперь надо обработать  ((Z) AND (NOT Y))
                            bool flag_AND = false; int A = 0, B = 0, C = 0;
                            for (int i = p; i < 17; i++)//Проверить знак AND
                            {//8 OR 9-А 10-ЗНАК 11-В
                                if (arrStream[i] == arrInt[4].ToString())//arrInt[4]="AND"
                                {//Найден AND
                                    flag_AND = true;
                                    A = i - 1;//A пишим без !проверки!
                                    newGroupB=new ListViewItem("AND");
                                    if (arrStream[i + 1] != arrConst[2])//if(AND+1!=B)
                                    { B = i + 2; C = i + 1; }
                                    else B = i + 1;//AND+1=B
                                }
                                if (flag_AND)
                                {//Если есть AND то есть и выражения по обе стороны
                                    if (Proverka_AandCB(A, B, C) == 2)//Проверим это утверждение
                                    {//                 13/16/15
                                        //Console.WriteLine("Res2:= (A AND NOT B)");
                                        newGroupB.SubItems.Add("Res3");
                                        listView_ParserSintax.Items.Add(newGroupB);//Група закрылась
                                        res2 = true;
                                    }
                                    else
                                    {
                                        //Console.WriteLine("Res2:= (A AND B)"); //==1
                                        newGroupB.SubItems.Add("Y");
                                        newGroupB.SubItems.Add("Res3");
                                        listView_ParserSintax.Items.Add(newGroupB);//Група закрылась
                                    }
                                } flag_AND = false;//сбросим
                            }
                        }
                        flagProxod += 1;
                    }
                }//end for
                if (res0 && res1 && res2)
                {//Делаем псевдо OR типо (res||res) ||res
                    res3 = true;
                    //Console.WriteLine("(res||res) ||res");
                    ListViewItem newGroup34 = new ListViewItem("OR");
                    newGroup34.SubItems.Add("Res1");
                    newGroup34.SubItems.Add("Res2");
                    newGroup34.SubItems.Add("Res4");
                    listView_ParserSintax.Items.Add(newGroup34);
                    //=========================================//
                    ListViewItem newGroup44 = new ListViewItem("OR");
                    newGroup44.SubItems.Add("Res4");
                    newGroup44.SubItems.Add("Res3");
                    newGroup44.SubItems.Add("Res5");
                    listView_ParserSintax.Items.Add(newGroup44);
                }
                if (arrStream[key + 1] == arrInt[6].ToString() && res3)//16+1=="THEN"
                {
                    //Console.Write("Значение THEN\t");
                    newGroupTHEN=new ListViewItem("THEN");
                    int next = key + 1;//17
                    if (arrStream[next + 1] == arrInt[7].ToString())//18="writeln"
                    {
                        //Console.Write("Operator1 writeln\n");
                        newGroupTHEN.SubItems.Add("writeln");
                        listView_ParserSintax.Items.Add(newGroupTHEN);
                        //Console.Write("Значение writeln\t");
                        if (Operator(next + 1) == "0")
                        {
                            MessageBox.Show("Не найдена константа " + arrConst[3]);
                        }
                        /*Конец программы*/
                    }
                }
            }


        }
        bool PoiskZnaka()
        {//Без уточнения !типа знака!
            bool znak = false;
            FormTable ft = new FormTable();
            for (int i = 2; i < 5; i++)//A-->..<=
            {
                if (arrStream[i] == arrInt[1].ToString())//(..поток..<=
                    znak = true;//Найден + "2"
            }
            return znak;
        }
        private int x = 1, y = 1;
        int Poisk_A()
        {//Ищем выражения до ЗНАКА
            bool Op1 = false, Op2 = false; int flag_A = 0;
            int i;
            for ( i = 2; i < 5; i++)//A-->..<=
            {
                if (arrStream[i] == arrConst[0])
                {
                    Op1 = true; //Найден a
                    if(x==1)
                    {
                        ListViewItem newGroup0 = new ListViewItem("Slag1");
                        newGroup0.SubItems.Add(arrConst[x-1]);
                        listView_ParserSintax.Items.Add(newGroup0);
                        x++;
                    }
                }
                if (arrStream[i] == arrConst[1])
                {
                    Op2 = true; //Найден a
                    if (y == 1)
                    {
                        ListViewItem newGroup0 = new ListViewItem("Slag2");
                        newGroup0.SubItems.Add(arrConst[y]);
                        listView_ParserSintax.Items.Add(newGroup0);
                        y++;
                    }
                }
            } 
            if (Op1 || Op2)
                flag_A = 1;//Одно значение
            if (Op1 && Op2)//Оба в тру
            {//Два значения
                flag_A = 2;
                //То выполнить поиск знака операции между двух значений
                if (PoiskZnaka())
                {//Делаем вывод что флаг_А содержит конечный RES!
                    flag_A = 110;
                }
            }
            return flag_A;
        }
        int Poisk_B()
        {//Ищем выражения после ЗНАКА
            int flag_B = 0;
            if (PoiskZnakaPosle())
            { MessageBox.Show("Есть знак ПОСЛЕ <= "); }
            else
            {//Знака нету
                flag_B = 1;//Одна B
                ListViewItem newGroup3 = new ListViewItem("Const3");
                newGroup3.SubItems.Add(arrConst[2]);
                listView_ParserSintax.Items.Add(newGroup3);
            }
            return flag_B;
        }
        bool PoiskZnakaPosle()
        {//Без уточнения !типа знака!
            bool znak = false;
            FormTable ft = new FormTable();
            for (int i = 5; i < 6; i++)// <=..<--B
            {
                if (arrStream[i] == arrInt[1].ToString())//(..поток..<=
                    znak = true;//Найден + "2"
            }
            return znak;
        }
        int Proverka_AandB(int A, int B)
        {//Проверим A и B
            int flag_AandB = 0;
            if (arrStream[A] == arrIdent[2] && arrStream[B] == arrIdent[0])
            {//А и В наместе
                flag_AandB = 2;//AB
                newGroup.SubItems.Add("Y");
                newGroup.SubItems.Add("X");
            }
            if (arrStream[A] != arrIdent[2]) { MessageBox.Show("Нет А в (AandB)"); }
            if (arrStream[B] != arrIdent[0]) { MessageBox.Show("Нет B в (AandB)"); }

            return flag_AandB;
        }
        int Proverka_AandCB(int A, int B, int C)
        {//Проверим A и CB             //13/16/15
            int flag_A = 0, flag_AandCB = 0, flag_CB = 0;
            if (arrStream[A] == arrIdent[1] && arrStream[B] == arrIdent[2])
            {//А и В наместе
                flag_A = 1;//A
                newGroupB.SubItems.Add("Z");
                if (C != 0)//Тоесть чтото есть
                {
                    flag_CB = 1;//Выполнили псевдо операцию NOT_B
                    newGroupB.SubItems.Add("NOT Y");
                }
                flag_AandCB = flag_A /*AND*/+ flag_CB;
            }
            if (arrStream[A] != arrIdent[1]) MessageBox.Show("Нет А в (AandCB)");
            if (arrStream[B] != arrIdent[2]) MessageBox.Show("Нет B в (AandCB)");

            return flag_AandCB;//2
        }
        string Operator(int Metod)
        {//Поиск "Верно" у writeln
            string op1 = "0";
            for (int i = Metod; i < arrStream.Length; i++)//17..23
            {
                if (arrStream[i] == arrConst[3])//"45#Верно"
                {
                    op1 = arrStream[i];
                }
            }
            if (op1!="0")
            {
                ListViewItem newGroupWriteln = new ListViewItem("writeln");
                newGroupWriteln.SubItems.Add("Верно");
                listView_ParserSintax.Items.Add(newGroupWriteln);   
            }
            
            return op1;
        }

        /*
        private string[] MassivNull;
        int index = 0; int a;
        int index2 = 0;

        string Sum(string A,string B)
        {
            string sum = A + B;
            return sum;
        }

        void AtoB()
        {
            FormTable formTable = new FormTable();
            MassivNull = new string[formTable.words.Length];
            
            int j = 0;
            for (int i = 0; i < formTable.words.Length; )
            {
                if (formTable.words[i] != "(" && formTable.words[i] != ")")
                {//Отсеиваем все скобки
                    if (formTable.words[0] == "if")
                        a = 0;
                    MassivNull[j] = formTable.words[i];
                    j++; i++;
                }
                else i++;
            }
            
        }

        string IF(string s)
        {
            switch (s)
            {
                case "if":
                    {
                        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                        listView_ParserSintax.Items.Add(s);
                        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                        index = listView_ParserSintax.Items.Add("Slag1").Index;
                        listView_ParserSintax.Items[index].SubItems.Add("2.5"); //#2.5
                        index = listView_ParserSintax.Items.Add("Slag2").Index;
                        listView_ParserSintax.Items[index].SubItems.Add("0.68"); //#0.68
                        index = listView_ParserSintax.Items.Add("Const3").Index;
                        listView_ParserSintax.Items[index].SubItems.Add("2.8"); //#2.8
                        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                        ListViewItem newGroup = new ListViewItem("+");
                        newGroup.SubItems.Add("Slag1");
                        newGroup.SubItems.Add("Slag2");
                        newGroup.SubItems.Add("Res1");
                        listView_ParserSintax.Items.Add(newGroup);
                        ListViewItem newGroup1 = new ListViewItem("<=");
                        newGroup1.SubItems.Add("Res1");
                        newGroup1.SubItems.Add("Const3");
                        newGroup1.SubItems.Add("Res0");
                        listView_ParserSintax.Items.Add(newGroup1);
                        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                        break;
                        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                    }
            }
            //if (s == "if")
            string flag = "false";
            return flag;
        }

        private string fl = "0";
        string OR(string s)
        {
            if (fl == "0")
            switch (s)
            {
                case "OR":
                    {
                        fl = "1";
                        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                        ListViewItem lvi = new ListViewItem(new string[] {"AND", "Y", "X", "Res2"});
                        listView_ParserSintax.Items.Add(lvi);
                        lvi = new ListViewItem(new string[] {"AND NOT", "Z", "Y", "Res3"});
                        listView_ParserSintax.Items.Add(lvi);
                        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                        lvi = new ListViewItem(new string[] {"OR", "Res2", "Res3", "Res4"});
                        listView_ParserSintax.Items.Add(lvi);
                        lvi = new ListViewItem(new string[] {"OR", "Res0", "Res4", "THEN"});
                        listView_ParserSintax.Items.Add(lvi);
                        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                        break;
                    }
            }
             
            return fl;
        }

        string THEN(string s)
        {
            switch (s)
            {
                case "THEN\r":
                    {
                        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                        index2 = listView_ParserSintax.Items.Add("THEN").Index;
                        listView_ParserSintax.Items[index2].SubItems.Add("writeln");
                        index2 = listView_ParserSintax.Items.Add("Param").Index;
                        listView_ParserSintax.Items[index2].SubItems.Add("Верно");
                        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                        break;
                    }
            }
            string flag = "false";
            return flag;
        }
        
        void Parser()
        {
            foreach (string s in MassivNull)
            {
                //IF(s);
                if (IF(s) == "false")
                    if (OR(s) == "fl") continue;
                THEN(s);
            }
            /*
            if (a == 0)
            {
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                listView_ParserSintax.Items.Add("if");
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                index = listView_ParserSintax.Items.Add("Slag1").Index;
                listView_ParserSintax.Items[index].SubItems.Add("2.5"); //#2.5
                index = listView_ParserSintax.Items.Add("Slag2").Index;
                listView_ParserSintax.Items[index].SubItems.Add("0.68"); //#0.68
                index = listView_ParserSintax.Items.Add("Const3").Index;
                listView_ParserSintax.Items[index].SubItems.Add("2.8"); //#2.8
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                ListViewItem newGroup = new ListViewItem("+");
                newGroup.SubItems.Add("Slag1");
                newGroup.SubItems.Add("Slag2");
                newGroup.SubItems.Add("Res1");
                listView_ParserSintax.Items.Add(newGroup);
                ListViewItem newGroup1 = new ListViewItem("<=");
                newGroup1.SubItems.Add("Res1");
                newGroup1.SubItems.Add("Const3");
                newGroup1.SubItems.Add("Res0");
                listView_ParserSintax.Items.Add(newGroup1);
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                ListViewItem lvi = new ListViewItem(new string[] { "AND", "Y", "X", "Res2" });
                listView_ParserSintax.Items.Add(lvi);
                lvi = new ListViewItem(new string[] { "AND NOT", "Z", "Y", "Res3" });
                listView_ParserSintax.Items.Add(lvi);
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                lvi = new ListViewItem(new string[] { "OR", "Res2", "Res3", "Res4" });
                listView_ParserSintax.Items.Add(lvi);
                lvi = new ListViewItem(new string[] { "OR", "Res0", "Res4", "THEN" });
                listView_ParserSintax.Items.Add(lvi);
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
                index2 = listView_ParserSintax.Items.Add("THEN").Index;
                listView_ParserSintax.Items[index2].SubItems.Add("writeln");
                index2 = listView_ParserSintax.Items.Add("Param").Index;
                listView_ParserSintax.Items[index2].SubItems.Add("Верно");

                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
            }*/

        //}
    }
}
