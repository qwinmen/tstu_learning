using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace PointLine
{
    class clArrayList : IEnumerator, IEnumerable
    {
        private List<PointF> _arrayPoint;
        private List<Color> _arrayColor;

        /// <summary>
        /// Подобие Dictionary но с индексатором[int]
        /// </summary>
        public clArrayList()
        {
            _arrayPoint = new List<PointF>();
            _arrayColor = new List<Color>();
        }

        public PointF this[int index]
        {
            get { return _arrayPoint[index]; }
            set { _arrayPoint[index] = value; }
        }

        public Color this[double index]
        {
            get { return _arrayColor[(int)index]; }
            set { _arrayColor[(int)index] = value; }
        }

        public void Add(PointF point, Color color)
        {
            _arrayPoint.Add(point);
            _arrayColor.Add(color);
        }

        public void Clear()
        {
            _arrayPoint.Clear();
            _arrayColor.Clear();
        }

        public int Count()
        {
            return _arrayPoint.Count;
        }

        private int _idx = -1;
        public bool MoveNext()
        {
            if (_idx == Count() - 1)
            {
                Reset();
                return false;
            }
            _idx++;
            return true;
        }

        public void Reset()
        {
            _idx = -1;
        }

        public object Current
        {
            get {return _arrayPoint[_idx];}
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
        
        

    }
}
