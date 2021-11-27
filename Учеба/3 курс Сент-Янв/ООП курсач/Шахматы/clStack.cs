using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Шахматы
{
    /// <summary>
    /// Обеспечить механизм создания\заполнения\перемещения\удаления 
    /// контейнера для среза "массив фигур"
    /// </summary>
    class clStack
    {
        /// <summary>
        /// Снимок обьекта "массив"
        /// </summary>
        private List<List<clFigure>> _stackArr;
        /// <summary>
        /// Хей ход был когда делался снимок в стек
        /// </summary>
        private List<bool> _state;

        internal int IndexPos { get; set; }

        private string[,] _list;
        /// <summary>
        /// Какой индекс у последнего элемента
        /// </summary>
        internal int CountIndex { get; private set; }
        
        /// <summary>
        /// Обьект типа clFigure[,]
        /// </summary>
        public clStack()
        {
            _stackArr = new List<List<clFigure>>(20);
            _state = new List<bool>(20);
            _list = new string[21,64];
            CountIndex = 0;
        }

        internal List<clFigure> this[int index]
        {
            get { return GetIndexObject(index); }
            set { _stackArr[index] = value; }
        }

        /// <summary>
        /// Добавить обьект в конец списка
        /// </summary>
        internal void Add(List<clFigure> objFigure, bool xod)
        {
            if (_stackArr.Count < 20)
            {
                _stackArr.Add(objFigure);
                _state.Add(xod);
                CountIndex++;
            }
            else
            {
                CountIndex = 0;
                DeliteOne();
                Add(objFigure, xod);//_stackArr.Add(keyValuePair);
            }
        }

        /// <summary>
        /// Обрезать массив
        /// </summary>
        private void DeliteOne()
        {
            //вырезать с 10 по 20 элементы и поместить их с 0 по 10
            var tmpList = _stackArr.GetRange(10, 10);//10-10
            _stackArr.Clear();
            _stackArr = tmpList;

            //вырезать с 10 по 20 элементы и поместить их с 0 по 10
            var tmp = _state.GetRange(10, 10);//10-10
            _state.Clear();
            _state = tmp;
        }


        private int _i = 0;
        /// <summary>
        /// Добавить List_clFigure_ в конец списка
        /// </summary>
        internal void AddString(IEnumerable<clFigure> objFigure, bool xod)
        {
            int j = 0;
            if(_i < 21)
            {
                _state.Add(xod);
                foreach (clFigure figure in objFigure)
                {
                    if (figure == null) _list[_i, j] = "null";
                    else _list[_i, j] = figure.Name + " " + figure.OneGo;
                    j++;
                }
                _i++; CountIndex++;
            }
            else
            {
                _i = 10;
                CountIndex = 0;
                DeliteOneString();
                AddString(objFigure, xod);//_stackArr.Add(keyValuePair);
            }
        }

        /// <summary>
        /// Добавить List_string_ в конец списка
        /// </summary>
        internal void AddString(IEnumerable<string> objFigure, bool xod)
        {
            if(objFigure==null) return;

            int j = 0;
            if (_i < 21)
            {
                _state.Add(xod);
                foreach (string figure in objFigure)
                {
                    if (figure == "null") _list[_i, j] = "null";
                    else _list[_i, j] = figure;
                    j++;
                }
                _i++; CountIndex++;
            }
            else
            {
                _i = 10;
                CountIndex = 0;
                DeliteOneString();
                AddString(objFigure, xod);//_stackArr.Add(keyValuePair);
            }
        }
       
        /// <summary>
        /// Элементы с 10 по 20 врезать на место 0..10
        /// Остальное с 11 по 20 занулить
        /// </summary>
        private void DeliteOneString()
        {
            int s = 10, l = 0;
            while (l < 11)
            {
                for (int t = 0; t < 64; t++)
                {//[0..10, 0..64] = [10..20, 0..64]
                    _list[l, t] = _list[s, t];
                }
                l++; s++;
            }
            for (int j = 10; j < 21; j++)
            {
                for (int i = 0; i < 64; i++)
                {//[10..20, 0..64] = null
                    _list[j, i] = null;
                }
            }
            
            
        }

        /// <summary>
        /// Добавить обьект в N позицию списка
        /// </summary>
        internal void AddToN(List<clFigure> keyValuePair, int index)
        {
            this[index] = keyValuePair;
        }

        /// <summary>
        /// Получить начальный элемент списка
        /// </summary>
        internal List<clFigure> GetFirstObject()
        {
            return _stackArr.FirstOrDefault();
        }

        /// <summary>
        /// Получить последний элемент списка
        /// </summary>
        internal List<clFigure> GetLastObject()
        {
            return _stackArr.LastOrDefault();
        }

        /// <summary>
        /// Получить последний элемент-состояние-хода списка
        /// </summary>
        internal bool GetLastBoolObject()
        {
            return _state.LastOrDefault();
        }

        /// <summary>
        /// Получить указанный элемент списка
        /// </summary>
        internal List<clFigure> GetIndexObject(int index)
        {
            return _stackArr.ElementAtOrDefault(index);
        }

        /// <summary>
        /// Получить указанный элемент-состояние-хода списка
        /// </summary>
        internal bool GetBoolObject(int index)
        {
            return _state.ElementAtOrDefault(index);
        }

        /// <summary>
        /// Получить обьект по индексу
        /// </summary>
        internal IEnumerable<string> GetStringListObject(int index)
        {
            if (index < 0) return null;
            
            List<string> tmp = new List<string>();
            for (int i = 0; i < 64; i++)
            {
                tmp.Add(_list[index, i]);
            }
            if (tmp.TakeWhile(s => s == null).Any())
            {
                return null;
            }
            return tmp;
        }

        /// <summary>
        /// Получить последний элемент списка
        /// </summary>
        internal IEnumerable<string> GetLastListObject()
        {
            var tmp = new List<string>();
            for (int i = 0; i < 64; i++)
            {
                tmp.Add(_list[this.CountIndex-1, i]);
            }
            return tmp;
        }

        

    }
}
