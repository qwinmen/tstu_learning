using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ConsMemTest
{
    public partial class MForm : Form
    {
        public MForm()
        {
            InitializeComponent();
            
            Thread thread = new Thread(new ThreadStart(ShowMemory));
            timerUpdateForm.Start();
            timerUpdateForm.Tick += new EventHandler(timerUpdateForm_Tick);
            thread.Start();
            //ShowMemory();
            
        }

        public void ShowMemory()
        {
            
            
            UInt32 storePages = 0;
            UInt32 ramPages = 0;
            UInt32 pageSize = 0;
            //int res = clMemTest.GetSystemMemoryDivision(ref storePages, ref ramPages, ref pageSize);

            // Call the native GlobalMemoryStatus method
            // with the defined structure.
            clMemTest.MEMORYSTATUS memStatus = new clMemTest.MEMORYSTATUS();
            clMemTest.GlobalMemoryStatus(ref memStatus);

            // Use a StringBuilder for the message box string.
            StringBuilder MemoryInfo = new StringBuilder();
            MemoryInfo.Append("Размер структуры: " + memStatus.dwLength.ToString() + "\n");
            MemoryInfo.Append("Процент использования памяти: " + memStatus.dwMemoryLoad.ToString() + "\n");
            MemoryInfo.Append("Физическая память, Byte: " + memStatus.dwTotalPhys.ToString() + "\n");
            MemoryInfo.Append("Свободно физической памяти, Byte: " + memStatus.dwAvailPhys.ToString() + "\n");
            MemoryInfo.Append("Размер файла подкачки, Byte: " + memStatus.dwTotalPageFile.ToString() + "\n");
            MemoryInfo.Append("Свободных байт в файле подкачки: " + memStatus.dwAvailPageFile.ToString() + "\n");
            MemoryInfo.Append("Виртуальная память, используемая процессом: " + memStatus.dwTotalVirtual.ToString() +
                              "\n");
            MemoryInfo.Append("Свободная виртуальная память: " + memStatus.dwAvailVirtual.ToString() + "\n");

            // Show the available memory.
            //Console.WriteLine(MemoryInfo.ToString() + "___");
            

            label1.Text = "Занято: " + memStatus.dwMemoryLoad + "%";
            verticalProgressBar1.Value = (int) memStatus.dwMemoryLoad;
            label2.Text = "Свободно: " + (100 - memStatus.dwMemoryLoad)+ "%";
            progressBar1.Value = 100 - (int) memStatus.dwMemoryLoad;

            
            label3.Text = "Занято: " + (memStatus.dwTotalPhys - memStatus.dwAvailPhys);
            verticalProgressBar2.Value = 10;//(int)(memStatus.dwTotalPhys - memStatus.dwAvailPhys);
            label4.Text = "Свободно: " + (memStatus.dwAvailPhys / 100);
            verticalProgressBar3.Value = 10;//(int)memStatus.dwAvailPhys;

        }


        //для вывода текста метод
        void Label1T(string str)
        {
            label1.Text = str;
        }
        void ProgrBar1(int str)
        {
            progressBar1.Value = str;
        }

        private delegate void PrintInTxt(string str);//делегат
        private delegate void PrintIntTxt(int str);

        private PrintInTxt PrintDelegateFunc;//переменая делегата
        private PrintIntTxt PrINTDeleg;
        private void timerUpdateForm_Tick(object sender, EventArgs e)
        {
            PrintDelegateFunc = new PrintInTxt(Label1T);//инициалим переменую делегата
            PrINTDeleg = new PrintIntTxt(ProgrBar1);//инициалим переменую делегата
            
            for (int i = 0; i < 10; i++)
            {
                label1.Invoke(PrintDelegateFunc, new object[] { DateTime.Now.Millisecond.ToString() });
                
                progressBar1.Invoke(PrINTDeleg, new object[] { (DateTime.Now.Millisecond/100)%10 });
            }
        }

        
        

    }


    public class VerticalProgressBar : ProgressBar
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x04;
                return cp;
            }
        }
    }

    
}
