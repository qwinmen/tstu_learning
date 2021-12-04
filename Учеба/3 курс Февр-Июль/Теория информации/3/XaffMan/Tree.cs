namespace XaffMan
{
    /// <summary>
    /// Класс для создания ячейки-листа в дереве
    /// </summary>
    class Tree
    {
        private string _str;
        private int _val;
        private bool _flag;
        private string _napravlenie;
        private static int _len;

        public Tree(string str, int val, bool flag, string napravlenie)
        {
            _str = str;
            _val = val;
            _flag = flag;
            _napravlenie = napravlenie;
        }

        public Tree(Tree min)
        {
            _str = min._str;
            _val = min._val;
            _flag = min._flag;
            _napravlenie = min._napravlenie;
        }

        /// <summary>
        /// Найти два мин числа в массиве arr[]
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="min1"></param>
        /// <param name="min2"></param>
        public Tree(Tree[] arr, out Tree min1, out Tree min2)
        {
            Tree ext1 = null;
            Tree ext2 = null;

            for (int i = 0; i < arr.Length; i++)
            {
                var tmp = arr[i];
                for (int j = i; j < arr.Length; j++)
                {
                        if (tmp._val <= arr[j]._val)
                        {
                            if (ext1 == null)
                                ext1 = tmp;
                            if (tmp._val < ext1._val)
                                ext1 = tmp;
                        }
                }
            }
            min1 = ext1;
            for (int i = 0; i < arr.Length; i++)
            {
                var tmp = arr[i];
                if(tmp==ext1)continue;
                for (int j = i; j < arr.Length; j++)
                {
                    if (tmp._val <= arr[j]._val)
                    {
                        if (ext2 == null)
                            ext2 = tmp;
                        if(tmp._val < ext2._val && tmp != min1)
                            ext2 = tmp;
                    }
                }
            }
            min2 = ext2;
        }

        /// <summary>
        /// Сложение двух минимальных даст один лист
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Tree operator +(Tree a, Tree b)
        {//1-11//0-11
            //если есть еще элементы кроме a+b то направление 1-11
            //если a+b одни и всё, то направление 0-11 и это корень
            return new Tree(a._str+b._str, a._val+b._val, false, "");
        }

        /// <summary>
        /// Сделать поиск подстроки A в строке this
        /// </summary>
        /// <param name="a">Подстрока А</param>
        /// <returns>Вернет true, если в строке есть подстрока А</returns>
        public bool Comparer(Tree a)
        {
            if (this._str.Contains(a._str)) return true;
            return false;
        }

        /// <summary>
        /// Когда astr длиннее текущей
        /// </summary>
        /// <param name="astr">Строка</param>
        /// <returns></returns>
        public bool Compare(Tree astr)
        {
            if (astr._str.Contains(this._str)) return true;
            return false;
        }

        /// <summary>
        /// Сделать полное сравнение элемента А с текущим
        /// </summary>
        /// <param name="a">Элемент А</param>
        /// <returns>Вернет true, если оба элемента одинаковы</returns>
        public bool Equals(Tree a)
        {
            if (this._str == a._str && this._val == a._val) return true;
            return false;
        }

        public bool Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        public string Napravlenie
        {
            get { return _napravlenie; }
            set { _napravlenie = value; }
        }

        public string Str
        {
            get { return _str; }
            set { _str = value; }
        }

        public static int Length
        {
            get { return _len; }
            set { _len = value; }
        }

    }

}
