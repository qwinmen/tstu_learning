using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moon
{//LPO lab-4 hash
    class Program
    {//Console build
        private static String[] text;
        static void Main(string[] args)
        {
            textBoxIn_KeyDown();
        }
        public static bool _globalSbros;
        
        static List<string> _list = new List<string>();
        static List<string > list = new List<string>();
        public static int key, index, ent;
        public static bool flag, tactic, host;
        private static int ghost;
        private static void textBoxIn_KeyDown()
        {//жмем Enter
            _globalSbros = false;
            
                HashClass hashClass = new HashClass();
                //-----------------ввод----------------------------//
                text = new string[2];
                text[0] = Console.ReadLine();
                //String[] text = Console.ReadLine.Text.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                //string text = textBoxIn.Text;
                int tact = 0;


                if (Bastion(text) || flag)
                {
                    tactic = true;
                    Console.WriteLine("Этo повтор");//MessageBox.Show("Этo повтор");
                    hashClass.BufferWords(text); //hashClass.TxtFromTextBoxIn(text);//
                    _list.Add(hashClass.Num().ToString());
                    ghost = hashClass.Num();//пишем номер повтора
                    Console.Write(hashClass.Num().ToString()+"  ");//ListViewItem stroka1 = new ListViewItem(hashClass.Num().ToString());
                    
                    list.Add(hashClass.Id()); //list.Add(stroka1.SubItems.Add("(" + hashClass.Id() + ")"));
                    Console.Write("(" + hashClass.Id() + ")" + "  ");
                    
                    list.Add(hashClass.Type());
                    Console.Write("(" + hashClass.Type() + ")" + "  ");

                    var moe = "*";
                    list.Add(moe);
                    Console.Write("(" + moe + ")" + "  ");

                    list.Add(hashClass.Kollizi().ToString());
                    Console.Write("(" + hashClass.Kollizi().ToString() + ")" + "  ");
                    tact++;

                }
                else
                {
                    //HashClass.Chost = false;
                    tactic = false;
                    hashClass.BufferWords(text); //hashClass.TxtFromTextBoxIn(text);//
                    //-----------------вывод---------------------------//
                    _list.Add(hashClass.Num().ToString());
                    Console.Write(hashClass.Num().ToString() + "  ");//ListViewItem stroka1 = new ListViewItem();
                    list.Add(hashClass.Id());
                    Console.Write(hashClass.Id() + "  ");

                    list.Add(hashClass.Type());
                    Console.Write(hashClass.Type() + "  ");

                    list.Add(hashClass.Hasher().ToString());
                    Console.Write(hashClass.Hasher().ToString() + "  ");

                    list.Add(hashClass.Kollizi().ToString());
                    Console.Write(hashClass.Kollizi().ToString() + "  ");
                    

                    if (flag)
                    {
                        Console.Clear();//listViewHashTable.Items.Clear();
                        int ee = 0;
                        for (int i = 0; i < _list.Count; i++)
                        {
                            //ListViewItem stroka2 = new ListViewItem(_list[i]); //0-1-2
                            Console.Write(_list[i] + "  ");
                            Console.Write(list[ee] + "  ");//stroka2.SubItems.Add(list[ee]); //0-4-8
                            ee++;
                            Console.Write(list[ee] + "  ");//stroka2.SubItems.Add(list[ee]); //1-5-9
                            ee++;
                            Console.Write(list[ee] + "  ");//stroka2.SubItems.Add(list[ee]); //2-6-10
                            ee++;

                            if (i == ent && ent != -42)// - tact - 1 && tactic) //i==1 - 1строка
                            {//перезаписать строку-1
                                Console.Write(index.ToString() + "  ");//stroka2.SubItems.Add(index.ToString()); //3-7-11
                                list[ee] = index.ToString();
                                ee++;
                                //MessageBox.Show("i=ent");
                            }
                            else
                            {//перезаписать в нули
                                Console.Write(list[ee] + "  ");//stroka2.SubItems.Add(list[ee]); //3-7-11
                                ee++;
                                //MessageBox.Show("else");
                            }
                            //listViewHashTable.Items.Add(stroka2);
                        }
                    }
                    //MessageBox.Show(hashClass.Hash(text).ToString());

                }
                flag = false;
            

        }
        private static bool Bastion(string[] _words)
        {//Защита от повторного ввода
            bool key = false;
            string dd = _words[_words.Length - 1];
            for (int i = 0; i < _words.Length - 1; i++)
            {
                if (_words[i] == dd)
                {
                    key = true;
                }
            }
            return key;//true на совпадение
        }

    }
}
