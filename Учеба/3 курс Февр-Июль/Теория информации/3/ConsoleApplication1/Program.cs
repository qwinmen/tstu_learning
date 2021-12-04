using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//построить дерево
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<char, int>() {{'a', 1}, {'e', 1}, {'v', 2}, {'k', 3}, {'o', 1}, {'p', 2}};
            Tree[,] trees = new Tree[7, 7];
            int[] ver = {1, 1, 2, 3, 1, 2};
            char[] chr = {'a', 'e', 'v', 'k', 'o', 'p'};
            Random rnd = new Random();

            trees[0, 0] = new Tree("a", 1, false, "");//new Tree("a", 6, false, "");//new Tree("м", 1, false, ""); //
            trees[0, 1] = new Tree("e", 1, false, "");//new Tree("e", 2, false, "");//new Tree("а", 10, false, "");//
            trees[0, 2] = new Tree("v", 1, false, "");//new Tree("v", 3, false, "");//new Tree("к", 3, false, ""); //
            trees[0, 3] = new Tree("k", 1, false, "");//new Tree("k", 3, false, "");//new Tree("1", 4, false, ""); //
            trees[0, 4] = new Tree("o", 1, false, "");//new Tree("o", 2, false, "");//new Tree("!", 4, false, ""); //
            trees[0, 5] = new Tree("p", 1, false, "");//new Tree("p", 3, false, "");//new Tree("л", 4, false, ""); //
            trees[0, 6] = new Tree("r", 1, false, "");
            Tree.Length = 7;//количество записей trees[,] в строке
            //-----------------------------------------------------------------
            var len = Tree.Length;
            for (int k = 0; k < len - 1; k++)
            {
                var arr = new Tree[len - k];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = trees[k, i];
                }
                Tree tmin1, tmin2;
                new Tree(arr, out tmin1, out tmin2);
                var sum = tmin1 + tmin2;
                trees[k+1, 0] = new Tree(sum);
                var index = 0;
                for (int i = 1; i < len - (k + 1); )
                {
                    if (trees[k, index] != tmin1 && trees[k, index] != tmin2)
                    {
                        trees[k + 1, i] = new Tree(trees[k, index]);
                        i++;
                    }
                    index++;
                }
            }
            //-----------------------------------------------------------------
            var list = new List<KeyValuePair<Tree, string>>();
            for (int i = 0; i < Tree.Length; i++)
            {
                var keyPair = Parser(trees);
                list.Add(keyPair);
            }



            int min1;
            int min2;
            //сложить два мин числа
            SearchMin(ver, out min1, out min2);

        }

        private static KeyValuePair<Tree, string> Parser(Tree[,] trees)
        {
            var str = "";var s = "0";
            var tmp = trees[Tree.Length - 1, 0];
            var indx = Tree.Length - 2;
            var flag = false;
            
            for (int i = 0; i < Tree.Length; )
            {
                if (trees[indx, i]==null)
                {
                    tmp.Flag = true;
                    UpPars(trees, out tmp, out indx, indx+1, tmp);
                    flag = true;
                    i = 0;
                    if (str.Length == 1) str = "0";
                    else str = str.Remove(str.Length - _ival);
                }

                if (trees[indx, i].Equals(tmp))
                {
                    //опускаемся на уровень ниже 
                    //когда элементы не изменяются
                    tmp = trees[indx, i];
                    indx--;
                    if (indx < 0)
                    {
                        if (!tmp.Flag)
                        {
                            tmp.Flag = true;
                            tmp.Napravlenie = str;
                            //достигли дна, возвращаем элемент tmp
                            //и комбинацию переходов 010101)
                            return new KeyValuePair<Tree, string>(tmp, str);
                        }//иначе надо подниматься
                        UpPars(trees, out tmp, out indx, indx, tmp);
                        flag = true;
                    }
                    i = 0;
                }
                else
                {
                    if (tmp.Comparer(trees[indx, i]) && trees[indx, i].Flag)
                        s = "1";
                    
                    if (tmp.Comparer(trees[indx, i]) && !trees[indx, i].Flag)//опускаемся на уровень ниже
                    {
                        tmp = trees[indx, i];
                        if (flag)
                        {
                            str = str.Remove(str.Length - _ival) + s;
                        }
                        else str += s;
                        s = "0";
                        flag = false;
                        indx--;
                        if (indx < 0)
                        {
                            //достигли дна, возвращаем элемент
                            if (!tmp.Flag)
                            {
                                tmp.Flag = true;
                                return new KeyValuePair<Tree, string>(tmp, str);
                            }
                            //иначе надо подниматься
                            UpPars(trees, out tmp, out indx, indx, tmp);
                        }
                        i = 0;
                    }else i++;
                    
                }

                if (i == Tree.Length)
                {
                    tmp.Flag = true;
                    //иначе надо подниматься
                    UpPars(trees, out tmp, out indx, indx + 1, tmp);
                    i = 0;
                    flag = true;
                }
            }

            return new KeyValuePair<Tree, string>();
        }

        private static int _ival = 0;

        /// <summary>
        /// Найти развилку
        /// </summary>
        /// <param name="trees"></param>
        /// <param name="tmp"></param>
        /// <param name="indx"></param>
        private static void UpPars(Tree[,] trees, out Tree tmp, out int indx, int indxIn, Tree tmpIn)
        {
            _ival = 0;
            if(indxIn < 0) indxIn = 0;
            for (int i = 0; i < Tree.Length; i++)
            {
                if (trees[indxIn, i] == null)
                {
                    indxIn++;
                    i = -1;
                }

                if(trees[indxIn, i].Equals(tmpIn))
                {
                    trees[indxIn, i].Flag = true;
                    tmpIn = trees[indxIn, i];
                    indxIn++;
                    i = -1;
                }
                else
                {
                    if(tmpIn.Compare(trees[indxIn, i]))
                    {
                        tmpIn = trees[indxIn, i];
                        _ival++;
                        if (!tmpIn.Flag)
                        {
                            //tmpIn.Flag = true;
                            break;
                        }
                        indxIn++;
                        i = -1;
                    }

                }
            }

            tmp = tmpIn;
            indx = indxIn-1;
        }

        /// <summary>
        /// Найти в массиве два мин числа
        /// </summary>
        static void SearchMin(int[] arr, out int min1, out int min2)
        {
            Array.Sort(arr);
            min1 = arr[0];
            min2 = arr[1];
        }

        private void Derevo(Tree[,] trees)
        {
            //-----------------------------------------------------------------
            Tree[] arr = new Tree[6];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = trees[0, i];
            }
            Tree tmin1 = null;
            Tree tmin2 = null;
            var tmp = new Tree(arr, out tmin1, out tmin2);
            Tree sum = tmin1 + tmin2;
            trees[1, 0] = new Tree(sum);
            int index = 0;
            for (int i = 1; i < 6 - 1; )
            {
                if (trees[0, index] != tmin1 && trees[0, index] != tmin2)
                {
                    trees[1, i] = new Tree(trees[0, index]);
                    i++;
                }
                index++;
            }
            //-----------------------------------------------------------------
            arr = new Tree[6 - 1];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = trees[1, i];
            }
            tmin1 = null;
            tmin2 = null;
            tmp = new Tree(arr, out tmin1, out tmin2);
            sum = tmin1 + tmin2;
            trees[2, 0] = new Tree(sum);
            index = 0;
            for (int i = 1; i < 6 - 2; )
            {
                if (trees[1, index] != tmin1 && trees[1, index] != tmin2)
                {
                    trees[2, i] = new Tree(trees[1, index]);
                    i++;
                }
                index++;
            }
            //-----------------------------------------------------------------
            arr = new Tree[6 - 2];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = trees[2, i];
            }
            tmin1 = null;
            tmin2 = null;
            tmp = new Tree(arr, out tmin1, out tmin2);
            sum = tmin1 + tmin2;
            trees[3, 0] = new Tree(sum);
            index = 0;
            for (int i = 1; i < 6 - 3; )
            {
                if (trees[2, index] != tmin1 && trees[2, index] != tmin2)
                {
                    trees[3, i] = new Tree(trees[2, index]);
                    i++;
                }
                index++;
            }
            //-----------------------------------------------------------------
            arr = new Tree[6 - 3];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = trees[3, i];
            }
            tmin1 = null;
            tmin2 = null;
            tmp = new Tree(arr, out tmin1, out tmin2);
            sum = tmin1 + tmin2;
            trees[4, 0] = new Tree(sum);
            index = 0;
            for (int i = 1; i < 6 - 4; )
            {
                if (trees[3, index] != tmin1 && trees[3, index] != tmin2)
                {
                    trees[4, i] = new Tree(trees[3, index]);
                    i++;
                }
                index++;
            }
            //-----------------------------------------------------------------
            arr = new Tree[6 - 4];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = trees[4, i];
            }
            tmin1 = null;
            tmin2 = null;
            tmp = new Tree(arr, out tmin1, out tmin2);
            sum = tmin1 + tmin2;
            trees[5, 0] = new Tree(sum);
            index = 0;
            for (int i = 1; i < 6 - 5; )
            {
                if (trees[4, index] != tmin1 && trees[4, index] != tmin2)
                {
                    trees[5, i] = new Tree(trees[4, index]);
                    i++;
                }
                index++;
            }
        }


    }
}
