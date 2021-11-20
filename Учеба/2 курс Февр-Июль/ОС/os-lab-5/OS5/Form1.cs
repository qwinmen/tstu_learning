using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace OS5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (!buttonsPanel1.Opened) checkBox1.Visible = checkBox2.Visible = checkBox3.Visible = false;
        }

        
        private void buttonsPanel1_Clicked(object value, heaparessential.Common.ButtonClickedEventArgs args)
        {er = args;}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            State = checkBox1.Checked;
            textBox1.Text = "";
            TickTok.Ticker.Clear();
        }

        internal static bool State{get; set; }
        public static List<string> console = new List<string>(50);

        private heaparessential.Common.ButtonClickedEventArgs er;
        private void buttonsPanel1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (er.Index == 0)
            {
                /*Когда выполнение потока временно заблокировано, он он вызывает метод Wait()
                 * В итоге поток переходит в сост ожидания, а блокировка с ресурса снимается
                 * что даст возможность использовать ресурс в другом потоке                 */
                TickTok.Ticker.Clear(); 

                TickTok tt = new TickTok();
                //создать два патока с вызывом общего ресурса
                MyThread mt1 = new MyThread("Tick", tt);
                MyThread mt2 = new MyThread("Tock", tt);

                mt1.Thrd.Join();
                mt2.Thrd.Join();

                for (int i = 0; i < TickTok.Ticker.Count; i++)
                {
                    if (TickTok.Ticker[i] == "ТИК") textBox1.Text += "тиик";
                    else textBox1.Text += "тааак";
                    textBox1.Text += Environment.NewLine;
                }
            }
            if (er.Index == 1)
            {
                /*Mutex представляет собой взаимно исключающий синхронизирующий обьект, т.е 
                 он может быть получен потоком только по очереди                 */
                console.Clear(); 
                //сконструировать два потока
                IncThread mt1=new IncThread("Инкриментирующий поток", 5);
                Thread.Sleep(1);//разрешить начать инкрим поток

                DecThread mt2=new DecThread("Декрементирующий поток", 5);
                mt1.Thrd.Join();
                mt2.Thrd.Join();

                for (int i = 0; i < console.Count; i++)
                {
                    textBox1.Text += console[i];
                    textBox1.Text += Environment.NewLine;
                }
            }
            if (er.Index == 2)
            {
                MyThreadEvent.text.Clear();
                ManualResetEvent evtObj=new ManualResetEvent(false);
                MyThreadEvent mt1=new MyThreadEvent("Событийный поток 1", evtObj);
                textBox1.Text += "Основной поток ожидает события" + Environment.NewLine;
                for (int i = 0; i < MyThreadEvent.text.Count; i++)
                {
                    textBox1.Text += MyThreadEvent.text[i];
                    textBox1.Text += Environment.NewLine;
                }
                //ожидать уведомления о событии
                if(!checkBox3.Checked) evtObj.WaitOne();
                textBox1.Text += "Основной поток получил уведомление о событии от первого потока" + Environment.NewLine;
                //Установить событийный обьект в исходное состояние
                evtObj.Reset();

                mt1=new MyThreadEvent("Событийный поток 2", evtObj);
                //Ожидать уведомления о событии
                if (!checkBox3.Checked) evtObj.WaitOne();
                for (int i = 0; i < MyThreadEvent.text.Count; i++)
                {
                    textBox1.Text += MyThreadEvent.text[i];
                    textBox1.Text += Environment.NewLine;
                }
                textBox1.Text += "Основной поток получил уведомление о событии от второго потока" + Environment.NewLine;
            }

            MessageBox.Show("Готово");

        }

        private void textBox1_SizeChanged(object sender, EventArgs e)
        {
            if (buttonsPanel1.Opened) checkBox1.Visible = checkBox2.Visible = checkBox3.Visible = true;
            else checkBox1.Visible = checkBox2.Visible = checkBox3.Visible = false;
        }

    }
}
