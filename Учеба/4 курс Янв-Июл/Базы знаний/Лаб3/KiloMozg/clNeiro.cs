using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DevComponents.AdvTree;
using FastColoredTextBoxNS;
using ZedGraph;
using Line = FastColoredTextBoxNS.Line;

//Вариант D7
namespace KiloMozg
{
    class clNeiro
    {
        private const double _c = .1;//[0.1..10]
        private const double _ε = .001;
        private const double _λ = 1.0;
        private const double _x0 = 1;
        private readonly double[] _x1 = new double[] { 0, 0, 0, 0, 1, 1, 1, 1 };
        private readonly double[] _x2 = new double[] { 0, 0, 1, 1, 0, 0, 1, 1 };
        private readonly double[] _x3 = new double[] { 0, 1, 0, 1, 0, 1, 0, 1 };
        private readonly double[] _d = new double[] { 0, 1, 0, 1, 1, 0, 1, 0 };
        private readonly Random _rnd = new Random();
        private double _E = 0.0;
        public StringBuilder _отчетНаФорму = new StringBuilder();
        public double[] _wForm = new double[16];
        public int _SelectIndexInTable;
        private Thread _thread;

        /// <summary>
        /// Примеры x, d вписать в таблицу
        /// </summary>
        /// <returns>Вернет массив строк - таблицу</returns>
        public Node[] LoadTable()
        {
            var node = new Node[_d.Length];//сколько строк в таблице?
            var tmpNode = new Node(_x0.ToString());
            for (int i = 0, endStr = 0; i < _d.Length; endStr++)
            {
                switch (endStr)
                {//заполнить i-строку
                    case 0: tmpNode.Cells.Add(new Cell(_x1[i].ToString())); break;
                    case 1: tmpNode.Cells.Add(new Cell(_x2[i].ToString())); break;
                    case 2: tmpNode.Cells.Add(new Cell(_x3[i].ToString())); break;
                    case 3: tmpNode.Cells.Add(new Cell(_d[i].ToString())); break;
                    case 4:
                        node[i] = tmpNode;
                        tmpNode = new Node(_x0.ToString());
                        i++;
                        endStr = -1;
                        break;
                }

            }

            return node;
        }
        
        public clNeiro(){}

        public void CloseThread()
        {
            _thread.Join();
        }


        public clNeiro(AdvTree advTree)
        {
            Log = advTree;
            //Запуск отдельного фонового потока для расчетов//Независим от текущего примера
            _thread = new Thread(new ThreadStart(ShowMemory)) { IsBackground = true };
            _thread.Start();
        }

        private AdvTree Log;
        public PointPairList _list = new PointPairList();

        delegate void WriteToLogDelegate(int message);
        private void WriteToLog(int message)
        {
            if (Log.InvokeRequired)
            {
                var writeToLog = new WriteToLogDelegate(WriteToLog);
                Log.Invoke(writeToLog, message);
            }
            else
            {
                Log.SelectedIndex = message;
            }
        }

        delegate void WriteToZedGraphDelegate(PointPair pair);
        private void WriteToZedGraph(PointPair pair)
        {
            _list.Add(pair);
        }
        
        public int threadd;
        private int _eIndex;
        
        public void ShowMemory()
        {
            var индексОбучения = 0;//[0..7]
            //Сгенерировать рандомные веса
            var w = new double[16];
            for (int i = 0; i < w.Length; i++)
            {
                w[i] = _rnd.NextDouble();
                if (i == 8) _отчетНаФорму.AppendFormat("\r\n");
                _отчетНаФорму.AppendFormat("w{0}{1}={2:0.00}; ", (i == 0 || i == 13 || i == 14 || i == 15) ? '²' : '¹', i, w[i]);
            }
            _отчетНаФорму.AppendFormat("\r\n");

        nextStep:
            threadd++;
            if (threadd > 20999) throw new Exception("Зациклился!");

            WriteToLog(индексОбучения);
            //Рассчитать h для первого слоя
            var h1_1 = h(1, new double[] { w[1], w[4], w[7], w[10] }, _x0, _x1[индексОбучения], _x2[индексОбучения], _x3[индексОбучения]);
            var h1_2 = h(1, new double[] { w[2], w[5], w[8], w[11] }, _x0, _x1[индексОбучения], _x2[индексОбучения], _x3[индексОбучения]);
            var h1_3 = h(1, new double[] { w[3], w[6], w[9], w[12] }, _x0, _x1[индексОбучения], _x2[индексОбучения], _x3[индексОбучения]);
            _отчетНаФорму.AppendFormat("h¹1={0:0.00}; h¹2={1:0.00}; h¹3={2:0.00}; \r\n", h1_1, h1_2, h1_3);
            //Рассчитать F(h) для первого слоя
            var Fh1_1 = Fh(h1_1);
            var Fh1_2 = Fh(h1_2);
            var Fh1_3 = Fh(h1_3);
            _отчетНаФорму.AppendFormat("F(h¹1)={0:0.00}; F(h¹2)={1:0.00}; F(h¹3)={2:0.00}; \r\n", Fh1_1, Fh1_2, Fh1_3);
            //Рассчитать h для второго слоя
            var h2_1 = h(2, new double[] {w[0], w[13], w[14], w[15]}, _x0, Fh1_1, Fh1_2, Fh1_3);
            _отчетНаФорму.AppendFormat("h²1={0:0.00}; \r\n", h2_1);
            //Рассчитать F(h) для второго слоя
            var Fh2_1 = Fh(h2_1);
            _отчетНаФорму.AppendFormat("F(h²1)={0:0.00}; \r\n", Fh2_1);
            //Рассчитать ошибку уровня
            var ep1 = ep(Fh2_1, _d[индексОбучения]);
            _отчетНаФорму.AppendFormat("ep{0}={1:0.0000}; \r\n", индексОбучения, ep1);
            
            if(ep1 <= _ε)
            {
                _E += ep1;
                _eIndex++;
                WriteToZedGraph(new PointPair(_eIndex, _E));
                if (_E > _ε + 0.011)
                {
                    _отчетНаФорму.AppendFormat("-------------------END-----------------\r\n");
                    //Закончить обучение
                    return;
                }
                //то задача решена, переходим на новый уровень
                индексОбучения += индексОбучения+1 < _d.Length ? 1 : -7;
                goto nextStep;
            }
            //иначе рассчитать ошибку для второго слоя
            var δ2_1 = δ(2, _d[индексОбучения], Fh2_1, h2_1);
            _отчетНаФорму.AppendFormat("δ²1={0:0.00}; \r\n", δ2_1);
            //рассчитать ошибку для первого слоя
            var прицеп = Прицеп(new double[] {w[0], w[13], w[14], w[15]}, δ2_1);
            var δ1_1 = δ(1, _d[индексОбучения], Fh2_1, h1_1, прицеп);
            var δ1_2 = δ(1, _d[индексОбучения], Fh2_1, h1_2, прицеп);
            var δ1_3 = δ(1, _d[индексОбучения], Fh2_1, h1_3, прицеп);
            _отчетНаФорму.AppendFormat("δ¹1={0:0.00}; δ¹2={1:0.00}; δ¹3={2:0.00}; \r\n", δ1_1, δ1_2, δ1_3);
            //пересчитаем весы
            var Δw = new double[w.Length];
            for (int i = 0; i < Δw.Length; i++)
            {//просчитываем все дельта от 0 до 15
                if (i == 0 || i == 13 || i == 14 || i == 15)
                    Δw[i] = this.Δw(2, δ2_1, -1, i == 0 ? _x0 : i == 13 ? Fh1_1 : i == 14 ? Fh1_2 : i == 15 ? Fh1_3 : -1);
                else
                    Δw[i] = this.Δw(1, i == 1 || i == 4 || i == 7 || i == 10 ? δ1_1 : i == 2 || i == 5 || i == 8 || i == 11 ? δ1_2 : i == 3 || i == 6 || i == 9 || i == 12 ? δ1_3 : -1, i == 1 || i == 2 || i == 3 ? _x0 : i == 4 || i == 5 || i == 6 ? _x1[индексОбучения] : i == 7 || i == 8 || i == 9 ? _x2[индексОбучения] : i == 10 || i == 11 || i == 12 ? _x3[индексОбучения] : -1);
            }
            {//вывести дельта в отчет
                var i = 0;
                foreach (var dbl in Δw)
                    _отчетНаФорму.AppendFormat("Δw{0}{1}={2}; \r\n", (i == 0 || i == 13 || i == 14 || i == 15) ? '²' : '¹', i++, dbl);
            }
            //пересчитать весы
            for (int i = 0; i < w.Length; i++)
            {
                w[i] -= Δw[i];
                if (i == 8) _отчетНаФорму.AppendFormat("\r\n");
                _отчетНаФорму.AppendFormat("w{0}{1}={2:0.00}; ", (i == 0 || i == 13 || i == 14 || i == 15) ? '²' : '¹', i, w[i]);
                _wForm[i] = w[i];//для вывода на форму
            }
            _отчетНаФорму.AppendFormat("\r\n");
            goto nextStep;
            
        }

        /// <summary>
        /// Пробный пуск системы
        /// </summary>
        public void Tester(double _x1, double _x2, double _x3, int индексОбучения)
        {
            _отчетНаФорму.AppendFormat("-------------------TEST_d{0}={1}----------------\r\n", индексОбучения, _d[индексОбучения]);
            var w = _wForm;
            for (int i = 0; i < w.Length; i++)
            {
                if (i == 8) _отчетНаФорму.AppendFormat("\r\n");
                _отчетНаФорму.AppendFormat("w{0}{1}={2:0.00}; ", (i == 0 || i == 13 || i == 14 || i == 15) ? '²' : '¹', i, w[i]);
            }
            _отчетНаФорму.AppendFormat("\r\n");
            
            //Рассчитать h для первого слоя
            var h1_1 = h(1, new double[] { w[1], w[4], w[7], w[10] }, _x0, _x1, _x2, _x3);
            var h1_2 = h(1, new double[] { w[2], w[5], w[8], w[11] }, _x0, _x1, _x2, _x3);
            var h1_3 = h(1, new double[] { w[3], w[6], w[9], w[12] }, _x0, _x1, _x2, _x3);
            _отчетНаФорму.AppendFormat("h¹1={0:0.00}; h¹2={1:0.00}; h¹3={2:0.00}; \r\n", h1_1, h1_2, h1_3);
            //Рассчитать F(h) для первого слоя
            var Fh1_1 = Fh(h1_1);
            var Fh1_2 = Fh(h1_2);
            var Fh1_3 = Fh(h1_3);
            _отчетНаФорму.AppendFormat("F(h¹1)={0:0.00}; F(h¹2)={1:0.00}; F(h¹3)={2:0.00}; \r\n", Fh1_1, Fh1_2, Fh1_3);
            //Рассчитать h для второго слоя
            var h2_1 = h(2, new double[] { w[0], w[13], w[14], w[15] }, _x0, Fh1_1, Fh1_2, Fh1_3);
            _отчетНаФорму.AppendFormat("h²1={0:0.00}; \r\n", h2_1);
            //Рассчитать F(h) для второго слоя
            var Fh2_1 = Fh(h2_1);
            _отчетНаФорму.AppendFormat("F(h²1)={0:0.00}; \r\n", Fh2_1);
            //Рассчитать ошибку уровня
            var ep1 = ep(Fh2_1, _d[индексОбучения]);
            _отчетНаФорму.AppendFormat("ep{0}={1:0.0000}; \r\n", индексОбучения, ep1);
            _отчетНаФорму.AppendFormat("-------------------END----------------------\r\n");
        }

        /// <summary>
        /// Вычислить h
        /// </summary>
        /// <param name="номерСлоя">1\2 слой</param>
        /// <param name="w">значение весов</param>
        /// <param name="вход">x0..3 или F(h)</param>
        /// <returns>Вернет просчитаное число</returns>
        private double h(int номерСлоя, double[] w, params double[] вход)
        {
            switch (номерСлоя)
            {
                case 1:
                    return вход[0]*w[0] + вход[1]*w[1] + вход[2]*w[2] + вход[3]*w[3];
                case 2:
                    return вход[0]*w[0] + вход[1]*w[1] + вход[2]*w[2] + вход[3]*w[3];
            }

            return -1;
        }

        private double Fh(double h)
        {
            return 1.0 / (1.0 + Math.Exp(-_λ * h));
        }

        private double ep(double Fh, double d)
        {
            return Math.Pow(Fh - d, 2);
        }

        private double δ(int номерСлоя, double d, double Fh, double h, params double[] прицеп)
        {
            switch (номерСлоя)
            {
                case 1:
                    return (1.0*_λ*Math.Exp(-_λ*h))/(Math.Pow(1.0 + Math.Exp(-_λ*h), 2))*прицеп[0];
                case 2:
                    return -2.0*(d - Fh)*(1.0*_λ*Math.Exp(-_λ*h))/(Math.Pow(1.0 + Math.Exp(-_λ*h), 2));
            }
            return -1;
        }

        private double Прицеп(double[] w, double δ)
        {
            return δ*w[0] + δ*w[1] + δ*w[2] + δ*w[3];
        }

        private double Δw(int номерСлоя, double δ, double x, params double[] Fh)
        {
            switch (номерСлоя)
            {
                case 1:
                    return _c * δ * x;
                case 2:
                    return _c * δ * Fh[0];
            }
            return -1;
        }

    }


    /// <summary>
    /// Класс для работы с очень большими текстами//Оптимизатор
    /// </summary>
    public class StringTextSource : TextSource, IDisposable
    {
        List<int> sourceStringLinePositions = new List<int>();
        string sourceString;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public StringTextSource(FastColoredTextBox tb)
            : base(tb)
        {
            timer.Interval = 10000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            try
            {
                UnloadUnusedLines();
            }
            finally
            {
                timer.Enabled = true;
            }
        }

        private void UnloadUnusedLines()
        {
            const int margin = 2000;
            var iStartVisibleLine = CurrentTB.VisibleRange.Start.iLine;
            var iFinishVisibleLine = CurrentTB.VisibleRange.End.iLine;

            int count = 0;
            for (int i = 0; i < Count; i++)
                if (base.lines[i] != null && !base.lines[i].IsChanged && Math.Abs(i - iFinishVisibleLine) > margin)
                {
                    base.lines[i] = null;
                    count++;
                }
            
        }
        
        public void OpenString(string sourceString)
        {
            Clear();

            this.sourceString = sourceString;

            //parse lines
            int index = -1;
            do
            {
                sourceStringLinePositions.Add(index + 1);
                base.lines.Add(null);
                index = sourceString.IndexOf('\n', index + 1);
            } while (index >= 0);

            OnLineInserted(0, Count);

            //load first lines for calc width of the text
            var linesCount = Math.Min(lines.Count, CurrentTB.Height / CurrentTB.CharHeight);
            for (int i = 0; i < linesCount; i++)
                LoadLineFromSourceString(i);
        }

        public override void ClearIsChanged()
        {
            foreach (var line in lines)
                if (line != null)
                    line.IsChanged = false;
        }

        public override Line this[int i]
        {
            get
            {
                if (base.lines[i] != null)
                    return lines[i];
                else
                    LoadLineFromSourceString(i);

                return lines[i];
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private void LoadLineFromSourceString(int i)
        {
            var line = CreateLine();

            string s;
            if (i == Count - 1)
                s = sourceString.Substring(sourceStringLinePositions[i]);
            else
                s = sourceString.Substring(sourceStringLinePositions[i], sourceStringLinePositions[i + 1] - sourceStringLinePositions[i] - 1);

            foreach (var c in s)
                line.Add(new FastColoredTextBoxNS.Char(c));

            base.lines[i] = line;
        }

        public override void InsertLine(int index, Line line)
        {
            throw new NotImplementedException();
        }

        public override void RemoveLine(int index, int count)
        {
            if (count == 0) return;
            throw new NotImplementedException();
        }

        public override int GetLineLength(int i)
        {
            if (base.lines[i] == null)
                return 0;
            else
                return base.lines[i].Count;
        }

        public override bool LineHasFoldingStartMarker(int iLine)
        {
            if (lines[iLine] == null)
                return false;
            else
                return !string.IsNullOrEmpty(lines[iLine].FoldingStartMarker);
        }

        public override bool LineHasFoldingEndMarker(int iLine)
        {
            if (lines[iLine] == null)
                return false;
            else
                return !string.IsNullOrEmpty(lines[iLine].FoldingEndMarker);
        }

        public override void Dispose()
        {
            timer.Dispose();
        }

        internal void UnloadLine(int iLine)
        {
            if (lines[iLine] != null && !lines[iLine].IsChanged)
                lines[iLine] = null;
        }
    }

}
