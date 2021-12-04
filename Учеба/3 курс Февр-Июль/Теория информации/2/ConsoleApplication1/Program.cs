using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            string str =
                //"1000100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                //"100106110840100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                //"9010211040102110830100000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                //"9010111060105110790100000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                //"90108110830100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                //"80102110110101110780100000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                //"570100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                //"101011101010111010101110101011101010111010101110450100000000000000000000000000000000000000000000000000000000000000";
                //"30102110100101110840100000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                //"601011104010111080101110790100000000000000000000000000000000000000000000000000000000000000000000000000000000";
                //"701041109010211040101110730100000000000000000000000000000000000000000000000000000000000000000000000000000000";                
                //"901016110750100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";                
                "15010111090101110740100000000000000000000000000000000000000000000000000000000000000000000000000000000000000";

            int[] arr = new int[str.Length];
            int razdel2 = 10;
            int lenRazd = razdel2.ToString().Length;
			
			//Динамические массивы для элементов
            List<int> povt = new List<int>();
            List<int> znak = new List<int>();
            List<int> razd = new List<int>();

            Console.WriteLine(str);
            
            bool flag = true;
            //разделитель--знак--повтор
            /*
            while (lastIndxRazd2 != -1 && lastIndxRazd2 != 0)
            {
                if (!flag) razd.Add(razdel2);
                string sub = str.Substring(0, lastIndxRazd2);

                if (!flag) znak.Add(sub[sub.Length-1]);//0 or 1
                
                lastIndxRazd2 = sub.LastIndexOf(razdel2.ToString());//-1 or 0
                //повтор - это число от [lastIndxRazd2 до tmpIndx]
                if(lastIndxRazd2 > 0)
                {
                    if(lastIndxRazd2!=(sub.Length-lenRazd))
                    {
                        string pvtr = sub.Remove(0, lastIndxRazd2 + lenRazd);
                        povt.Add(int.Parse(pvtr.Remove(pvtr.Length - 1)));
                    }
                    else//когда razd2 самый последний в sub, надо изменить lastIndxRazd2
                    {
                        if(!flag)
                        {
                            string pvtr = sub.Remove(0, lastIndxRazd2); //10
                            povt.Add(int.Parse(pvtr.Remove(pvtr.Length - 1))); //1[0]
                            flag = true;
                        }else flag = false;
                    }
                }
                else povt.Add(int.Parse(sub.Remove(sub.Length-1)));
            }
            */

			//int index = str.LastIndexOf(string value) - вернет последний индекс value в строке str
			//или -1 если в строке str нет value
			
            //находим последний разделитель в строке
            int lastIndxRazd2 = str.LastIndexOf(razdel2.ToString());
			
			//анализ с конца в начало строки
            while (lastIndxRazd2 != -1 && lastIndxRazd2 != 0)
            {
                if(lastIndxRazd2 <= -2) break;
                //обрезать строку - откинуть последний разделитель
                string sub = str.Remove(lastIndxRazd2);
                //найти последний разделитель в обрезанной строке
                lastIndxRazd2 = sub.LastIndexOf(razdel2.ToString());                

                //добавим последний разделитель
                razd.Add(razdel2);
                if (lastIndxRazd2==sub.Length-lenRazd && flag)
                {//то lastIndxRazd2 указыкает на повтор+знак
                    if (lastIndxRazd2 == sub.IndexOf(razdel2.ToString()))
                    {
                        string pvtr = sub; //110
                        povt.Add(int.Parse(pvtr.Remove(pvtr.Length - 1))); //11
                        znak.Add(int.Parse(pvtr[pvtr.Length - 1].ToString())); //0 or 1
                        lastIndxRazd2 = lastIndxRazd2 - lenRazd;
                        flag = false;
                    }
                    else
                    {//"80102110 110"
                        string pvtr = sub.Remove(0, lastIndxRazd2); //840
                        
                        string repit = sub.Remove(lastIndxRazd2);//вырезать конец pvtr
                        int dupl = repit.LastIndexOf(razdel2.ToString());//теперь где 10
                        int rez = repit.Length - (dupl + lenRazd);//1 неможет быть!
                        
                        if(pvtr==razdel2.ToString() && rez == 1)
                        {
                            pvtr = sub.Remove(0, (dupl + lenRazd));//110
                            povt.Add(int.Parse(pvtr.Remove(pvtr.Length - 1))); //84
                            znak.Add(int.Parse(pvtr[pvtr.Length - 1].ToString())); //0 or 1
                            lastIndxRazd2 = dupl;//lastIndxRazd2 - lenRazd;
                        }
                        else
                        {
                            povt.Add(int.Parse(pvtr.Remove(pvtr.Length - 1))); //84
                            znak.Add(int.Parse(pvtr[pvtr.Length - 1].ToString())); //0 or 1
                            lastIndxRazd2 = lastIndxRazd2 - lenRazd;
                        }
                        flag = false;
                    }
                }
                else
                {//то lastIndxRazd2 указывает на разделитель
                    if(lastIndxRazd2>0)
                    {
                        string pvtr = sub.Remove(0, lastIndxRazd2 + lenRazd);//840
                        if(pvtr.Length == 1)
                        {
                            int lst = sub.LastIndexOf(razdel2.ToString());
                            pvtr = sub.Remove(0, lst);
                            lastIndxRazd2 = lst - lenRazd;
                        }
                        povt.Add(int.Parse(pvtr.Remove(pvtr.Length - 1)));//84
                        znak.Add(int.Parse(pvtr[pvtr.Length - 1].ToString()));//0 or 1
                    }
                    else
                    {
                        povt.Add(int.Parse(sub.Remove(sub.Length - 1)));//10
                        znak.Add(int.Parse(sub[sub.Length - 1].ToString()));//0 or 1
                    }
                    flag = true;
                }



            }


            int ot = 0;
            foreach (int i in povt)
            {
                Console.Write(razd[ot] +" " +i+" " + znak[ot]+'\n');
                ot++;
            }
            Console.ReadLine();

            //840 61 100
            //90 10 21 10 40 10 21 10 830 10
            //60 10 21 10 50 10 11 10 10  10 21 10 20 10 11 10 800 10

        }



        /// <summary>
        /// Построчное сжатие повторов
        /// </summary>
        private void Sjatie()
        {
            Random rnd = new Random();

            //у строк по х столбцов
            int x = 4, y = 2;
            int[,] array = new int[x,y];
            array[0, 0] = 0;
            array[1, 0] = 0;
            array[2, 0] = 0;
            array[3, 0] = 0;

            array[0, 1] = rnd.Next(0, 2);
            array[1, 1] = rnd.Next(0, 2);
            array[2, 1] = rnd.Next(0, 2);
            array[3, 1] = rnd.Next(0, 2);
            Console.WriteLine("Без сжатия:");
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(array[j, i] + " ");
                }
                Console.WriteLine();
            }


            Console.WriteLine("\nСжатый:");

            int maxXLength = 0; //самая длинная строка
            int povtorVal = 0; //счетчик повторов
            int tmpVal = 0;

            List<string> outarr = new List<string>();

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (j == 0)
                    {
                        tmpVal = array[j, i]; //начало строки берем первый символ
                        Console.Write(maxXLength + ":-> ");
                        povtorVal = 0;
                        povtorVal++;
                        maxXLength = 0;
                    }
                    else //иначе сравним символ с тикущим
                    {
                        if (tmpVal == array[j, i]) //если предыдущий равен текущему
                        {
                            povtorVal++;
                            if (povtorVal == x) //если вся строка из повторного символа
                            {
                                outarr.Add(povtorVal + " " + tmpVal + " _");
                                povtorVal = 0;
                                maxXLength += 2;
                            }
                            else if (j == x - 1 && povtorVal > 0) //не вся строка но конец
                            {
                                outarr.Add(povtorVal + " " + tmpVal + " _");
                                povtorVal = 0;
                                maxXLength += 2;
                            }
                        }
                        else //неравен
                        {
                            if (povtorVal == 0) povtorVal++;
                            outarr.Add(povtorVal + " " + tmpVal + " _");
                            maxXLength += 2;
                            tmpVal = array[j, i];
                            if (j == x - 1)
                            {
                                outarr.Add(1 + " " + tmpVal + " _");
                                maxXLength += 2;
                            }

                            povtorVal = 1;
                        }
                    }

                }

            }

            Console.WriteLine(maxXLength + "=>:");
            foreach (string s in outarr)
            {
                Console.Write(s);
            }

            Console.ReadKey();
        }


    }
}
