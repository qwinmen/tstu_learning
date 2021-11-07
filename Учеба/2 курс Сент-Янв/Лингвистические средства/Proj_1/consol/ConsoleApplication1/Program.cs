using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        private static string[] array = {
                                            "if", "(", "2", "+", "3", "<=", "4", ")",
                                            "OR", "Y_AND_X", "OR", "Z_AND NOT_Y",
                                        };

        public struct info
        {
            public char[] id;//80
            public char[] type;//20
            public int chain; //цепочка
            public int number; //номер
            public int error; //повтор
        } ;
        public struct work 
        { 
            public int kod; 
            public double zarabotok; 
            public string name;
            public string surname;
        }
        public static int vol = 10;
        static int[] _Num = new int[vol];

        static void Main()
        {
            #region

            /*   sort(0, array.Length - 1);//От 0..2
            foreach (string s in array)
                Console.Write(s+" ");
            Console.WriteLine();
            sort2(0, array2.Length - 1);//От 0..2
            foreach (string s in array2)
                Console.Write(s + " ");
            Console.WriteLine("___________________________");
            InStrim();
            Console.WriteLine("___________________________");
            Galim();
            LL();
//#################################################################################################            
            ToSteek(10, 20);//10+20//Пихаем в метод числа\переменые с числом, он их через стек сложит
          */

            #endregion

            /*
            string text = "int a";
            HashTab t;
            t.PoradkovNomer = 0;
            char razdelitel = ' ';
            string[] words = text.Split(razdelitel);
            int key = 0;
            for(int i=0;i<words.Length;i++)
            {
                if(i==0)
                {
                    t.TypeId = words[i];
                    Console.WriteLine(t.TypeId);
                }else if(i==1)
                {
                    t.Id = words[i];
                    Console.WriteLine(t.Id);
                    key = 1;
                }
                if (key > 0)
                {
                    t.PoradkovNomer += key-1;
                    Console.WriteLine(t.PoradkovNomer);
                }
            }
            
            string[] a = {"vasa pupkin"};
            string b = a[0];
            char[] razdelenie = { ' ' };
            string[] words = b.Split(razdelenie); //Делим строку на ПОДСТРОКИ
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }*/

            for (int i = 0; i < _Num.Length; i++)
            {
                if (i==_Num.Length-1)
                {
                    Console.WriteLine("help");
                    int[] _Num2=new int[20];
                    _Num.CopyTo(_Num2,0);
                    foreach (int i1 in _Num2)
                    {
                        Console.WriteLine(i1);
                    }
                }
                _Num[i] = Console.Read();
            }
            
            /*
            work[] w = new work[10];
            Random r = new Random();
            for (int i = 0; i < w.Length; i++)
            {
                w[i].kod = i;
                w[i].zarabotok = r.Next(200000, 300000)/10.0;
                Console.Write((i + 1) + " - name: ");
                w[i].name = Console.ReadLine();
                Console.Write((i + 1) + " - surname: ");
                w[i].surname = Console.ReadLine();
            }
            Console.WriteLine("Result:");
            for (int i = 0; i < w.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + w[i].name 
                    + " " + w[i].surname + " zarplata - " + w[i].zarabotok);
            }
            Console.Read();

            */


        }

        static int hash(char[] str)
        {//На вход слово
            int h = 0;
            for (int j = 0; j < str.Length; j++)
                h = h + str[j];//ascii cod 'd'=100
            return h%6;
        }
        static int hashStr(string[] str)
        {//На вход слово
            int h = 0;
                for (int j = 0; j < str.Length; j++)
                {
                    h += str[j].Length;
                    //h = h + str[j]; //ascii cod 'd'=100
                }
            
            return h % 6;
        }

        public struct HashTab
        {
            public int PoradkovNomer;
            public string Id;
            public string TypeId;
            public int HashMetoda;
            public int ChKolisii;
        }



















        static void ToSteek(int const1,int const2)
        {
            string operac = "+";
            Stack st=new Stack();
            st.Push(const1);//10
            st.Push(const2);//20
            for (; st.Count>0 ;)
            {
                var w =st.Pop().ToString();
                var v = st.Pop().ToString();
                Console.WriteLine(ConvertAndSum(w, v, operac));
            }
        }
        static int ConvertAndSum(string a,string b,string operac)
        {// +// -// *//
            int res=0;
            if(operac=="+")
            {res = Convert.ToInt32(a) + Convert.ToInt32(b);}
            if (operac == "-")
            { res = Convert.ToInt32(a) - Convert.ToInt32(b); }
            if (operac == "*")
            { res = Convert.ToInt32(a) * Convert.ToInt32(b); }

            return res;
        }
//#################################################################################################
        private static int[] arrayT = { 8,20, 22,14,24, 21 };//read( A,24 )
        static void LL()
        {
            foreach (int token in arrayT)
            {
                Read(token);
            }
        }

        static bool Read(int token)
        {
            bool found=false;
            if (token == 8) // {Read}
            {//{перейти к следующей лексеме}
                token=arrayT[1];
                if (token == 20) // {(}
                {//{перейти к следующей лексеме}
                    token = arrayT[2];
                    if (IDLIST(2)) // закончилась успешно
                    {
                        if (token == 21) // {)} 
                        {
                            found=true;
                            //{перейти к следующей лексеме}
                        }
                    }
                }
                if (found)
                {Console.WriteLine("Всё");} //{успешное завершение}
                else
                {Console.WriteLine("Eror");} //{неудачное завершение}

            }
            return found;
        }

        static bool IDLIST(int key)
        {
            bool found=false;
            int token = arrayT[key];
            if (token == 22) // {id} then
            {
                found=true;
                //{перейти к следующей лексеме}
                token = arrayT[key + 1];
                while (token == 14 && (found = true))
                { //{,}
                //{перейти к следующей лексеме}
                    token = arrayT[key + 2];//14->24->..
                    if (token == 24) //{id} then
                    { Console.WriteLine("24"); found = true; } //{перейти к следующей лексеме}
                    else
                        found=false;
                }  //while
            } //if 22

            if (found = true) // then
            {} //{успешное завершение}
            else
            {} //{неудачное завершение}

            return found;
        }

//#################################################################################################
private static int[] arrInt = { 0/*0*/, 2/*1*/, 4/*2*/, 7/*3*/, 9/*4*/, 10/*5*/, 12/*6*/, 13/*7*/, 14/*8*/, 16/*9*/, 17/*10*/ };
private static string[] arrConst = { "45#2.5"/*0*/, "45#0.68"/*1*/, "45#2.8"/*2*/, "45#Верно"/*3*/ };
private static string[] arrIdent = { "1->1"/*0*/, "1->3"/*1*/, "1->2"/*2*/ };
private static int lenght = arrInt.Length + arrConst.Length + arrIdent.Length;

private static string[] arrStream = {/*Полный паток выводится в Out на Form1*/
                                      "0"/*0*/,  "14"/*1*/,     "45#2.5"/*2*/,  "2"/*3*/,     "45#0.68"/*4*/,
                                      "4"/*5*/,  "45#2.8"/*6*/, "17"/*7*/,      "7"/*8*/,     "1->2"/*9*/,
                                      "9"/*10*/, "1->1"/*11*/,  "7"/*12*/,      "1->3"/*13*/, "9"/*14*/,
                                     "10"/*15*/, "1->2"/*16*/,  "12"/*17*/,     "13"/*18*/,   "14"/*19*/,
                                     "16"/*20*/, "45#Верно"/*21*/, "16"/*22*/,  "17"/*23*/
                                    };
        
        static void InStrim()//Точка входа
        {//Граматика == ВыходСПервойЛабы(arrStream)
            bool res0 = false, res1 = false, res2 = false, res3=false;
            if(arrStream[0] == arrInt[0].ToString())//Проверить IF
            {
                if (arrStream[1] == arrInt[8].ToString() && arrStream[7] == arrInt[10].ToString())//Проверить ( и )
                {
                    if (arrStream[5] == arrInt[2].ToString())//Проверить <=//ЗНАК
                    {
                        if (Poisk_A() == 1 && Poisk_B() == 1)//1 это Отсутствие знака
                        {//Сразу Res:=(A<=B)
                            Console.WriteLine("сразу Res0:=(A<=B)");
                            res0 = true;
                        }
                        else
                        {//Иначе есть операция (+), уточним где:
                            if(Poisk_A()==110)
                            {//Метод A+B до ЗНАКА
                                Console.WriteLine("RES110:=A+B");
                            }
                            //Выполим псевдо сравнение Res0:=(A<=B)
                            Console.WriteLine("Res0:= (A<=B)");
                            res0 = true;
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
                                }
                            }
                            if (flag_AND)
                            {//Если есть AND то есть и выражения по обе стороны
                                if (Proverka_AandB(A, B) == 2)//Проверим это утверждение
                                {
                                    Console.WriteLine("Res1:= (A AND B)");
                                    res1 = true;
                                }
                            }
                        }
                        if (flagProxod==1)//Сагрится на OR1
                        {//Теперь надо обработать  ((Z) AND (NOT Y))
                            bool flag_AND = false; int A = 0, B = 0, C=0;
                            for (int i = p; i < 17; i++)//Проверить знак AND
                            {//8 OR 9-А 10-ЗНАК 11-В
                                if (arrStream[i] == arrInt[4].ToString())//arrInt[4]="AND"
                                {//Найден AND
                                    flag_AND = true;
                                    A = i - 1;//A пишим без !проверки!
                                    if (arrStream[i + 1] != arrConst[2])//if(AND+1!=B)
                                    { B = i + 2; C = i + 1; }
                                    else B = i + 1;//AND+1=B
                                }
                                if (flag_AND)
                                {//Если есть AND то есть и выражения по обе стороны
                                    if (Proverka_AandCB(A, B, C) == 2)//Проверим это утверждение
                                    {//                 13/16/15
                                        Console.WriteLine("Res2:= (A AND NOT B)");
                                        res2 = true;
                                    }
                                    else Console.WriteLine("Res2:= (A AND B)");//==1
                                }flag_AND = false;//сбросим
                            }
                        }
                        flagProxod += 1;
                    }
                }//end for
                if (res0 && res1 && res2)
                {//Делаем псевдо OR типо (res||res) ||res
                    res3 = true;
                    Console.WriteLine("(res||res) ||res");
                }
                if(arrStream[key+1]==arrInt[6].ToString() && res3)//16+1=="THEN"
                {Console.Write("Значение THEN\t");
                    int next = key + 1;//17
                    if (arrStream[next+1]==arrInt[7].ToString())//18="writeln"
                    {
                        Console.Write("Operator1 writeln\n");
                        Console.Write("Значение writeln\t");
                        if(Operator(next+1)!="0")
                        { Console.Write("Operator1 'Верно'\n"); }
                         /*Конец программы*/
                    }
                }
            }
        }
        static bool PoiskZnaka()
        {//Без уточнения !типа знака!
            bool znak = false;
            for (int i = 2; i < 5; i++)//A-->..<=
            {
                if (arrStream[i] == arrInt[1].ToString())//(..поток..<=
                    znak = true;//Найден + "2"
                
            }
            return znak;
        }

        static int Poisk_A()
        {//Ищем выражения до ЗНАКА
            bool Op1 = false, Op2 = false; int flag_A = 0;
            for (int i = 2; i < 5; i++)//A-->..<=
            {
                if (arrStream[i] == arrConst[0])
                    Op1 = true;//Найден a
                if(arrStream[i] == arrConst[1])
                    Op2 = true;//Найден a
            }
            if (Op1 || Op2)
                flag_A = 1;//Одно значение
            if (Op1 && Op2)//Оба в тру
            {//Два значения
                flag_A = 2;
                //То выполнить поиск знака операции между двух значений
                if(PoiskZnaka())
                {//Делаем вывод что флаг_А содержит конечный RES!
                    flag_A = 110;
                }
            }
            return flag_A;
        }

        static int Poisk_B()
        {//Ищем выражения после ЗНАКА
            int flag_B = 0;
            if(PoiskZnakaPosle())
            {Console.WriteLine("Есть знак ПОСЛЕ <= ");}
            else
            {//Знака нету
                flag_B = 1;//Одна B
            }
            return flag_B;
        }
        static bool PoiskZnakaPosle()
        {//Без уточнения !типа знака!
            bool znak = false;
            for (int i = 5; i < 6; i++)// <=..<--B
            {
                if (arrStream[i] == arrInt[1].ToString())//(..поток..<=
                    znak = true;//Найден + "2"

            }
            return znak;
        }

        static int Proverka_AandB(int A,int B)
        {//Проверим A и B
            int flag_AandB = 0;
            if(arrStream[A]==arrIdent[2] && arrStream[B]==arrIdent[0])
            {//А и В наместе
                flag_AandB = 2;//AB
            }
            if (arrStream[A] != arrIdent[2]){Console.WriteLine("Нет А в (AandB)");}
            if (arrStream[B] != arrIdent[0]){Console.WriteLine("Нет B в (AandB)");}

            return flag_AandB;
        }

        static int Proverka_AandCB(int A, int B, int C)
        {//Проверим A и CB             //13/16/15
            int flag_A = 0,flag_AandCB=0, flag_CB=0;
            if (arrStream[A] == arrIdent[1] && arrStream[B] == arrIdent[2])
            {//А и В наместе
                flag_A = 1;//A
                if(C!=0)//Тоесть чтото есть
                {
                    flag_CB = 1;//Выполнили псевдо операцию NOT_B
                }
                flag_AandCB = flag_A /*AND*/+ flag_CB;
            }
            if (arrStream[A] != arrIdent[1])Console.WriteLine("Нет А в (AandCB)"); 
            if (arrStream[B] != arrIdent[2])Console.WriteLine("Нет B в (AandCB)"); 

            return flag_AandCB;//2
        }

        static string Operator(int Metod)
        {
            string op1 = "0";
            for (int i = Metod; i < arrStream.Length; i++)//17..23
            {
                if (arrStream[i] == arrConst[3])//"45#Верно"
                {
                    op1 = arrStream[i];
                }
            }
            return op1;
        }

        static void Galim()
        {
            int i = 0, k = 0, z = 0, j = 0, h = 0, m = 0;
            Console.Write("+---------------------------------------+ \n");
            Console.Write("¦Операция  ¦  Оп1   ¦   Оп2  ¦ Результат¦ \n");
            Console.Write("+----------+--------+--------+----------¦ \n");
            if(arrInt[0] == 0)//Проверить IF
            for (i = 0; i < lenght; i++)
            {
                if (arrInt[6]==12)//есть THEN
                {
                    if(arrInt[0]==0)
                    {//IF
                        if(arrInt[8]==14)//Скобка открыта
                        {
                            if(arrInt[10]==17)//Cкобка закрыта
                            {//Вид if()
                                //Блок подготовки наличия slag1 slag2 const2
                                if(arrInt[2]==4)//Знак <= наместе
                                {
                                    if(arrConst[0]=="#2.5" && arrConst[2]=="#2.8")//A<=B проверили что есть А и В
                                    {
                                        if(arrConst[0]=="#2.5" && arrInt[1]==2)//A&&+
                                        {
                                            Console.Write("¦+         ¦  #2.5    ¦  #2.8    ¦ res1       ¦\n");
                                        }//Далее надо вывести res2:=(A<=B)
                                    }
                                }else Console.WriteLine("Отсутствует <=");

                            }else Console.WriteLine("Отсутствует )");
                        }else Console.WriteLine("Отсутствует (");
                    }else Console.WriteLine("Отсутствует IF");
                }
                else
                {
                    Console.WriteLine("Отсутствует THEN");
                }
            }
        }

//#################################################################################################
        static void sort(int l, int r)
        {
            int i = l; int j = r;
            
            string x = array[(l + r) / 2];
            do
            {
                //while (array[i] != x) i++;
                //while (array[j] != x) j--;
                if (i <= j)
                {
                    string y = array[i];
                    array[i] = array[j];
                    array[j] = y;
                    i++;
                    j--;
                }
            } while (i < j);
            
            if (l < j)
                sort(l, j);
            if (l < r)
                sort(i, r);

        }
        private static string[] array2 = { "THEN", "writeln", "(", " ' Верно ' ", ")" };
        static void sort2(int l, int r)
        {
            int i = l; int j = r;

            string x = array2[(l + r) / 2];
            do
            {
                

                //while (array2[i] != x) i++;
                //while (array2[j] == x) j--;
                if (i <= j)
                {
                    string y = array2[i];
                    array2[i] = array2[j];
                    array2[j] = y;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (l < j)
                sort2(l, j);
            if (l < r)
                sort2(i, r);

        }

    }
}