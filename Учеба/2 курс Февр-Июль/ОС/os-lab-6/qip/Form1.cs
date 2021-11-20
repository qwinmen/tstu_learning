using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace qip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (_enterConnInf.ShowDialog() != DialogResult.OK && _enterConnInf.StrMailBox != "Введите имя нового ящика")
            {
                toolStripStatusLabel2.Text = _s + _enterConnInf.StrMailBox;
                _preMailBox = _enterConnInf.StrMailBox;
                PrintDelegateFunc = new PrintInFCTB(PrintFunc);

                tt=new Thread(new ParameterizedThreadStart(Serv))
                       {
                           IsBackground = true,
                           Priority = ThreadPriority.Lowest
                       };
                tt.Start(true);
                
                this.Show();
                fctb.Invoke(PrintDelegateFunc, new object[] { dsdsd });

            }else toolStripStatusLabel2.Text = _s + "ПУСТО";
            

            style = new GifImageStyle(fctb);
            style.ImagesByText.Add(@":bb", Properties.Resources.bye);
            style.ImagesByText.Add(@":D", Properties.Resources.lol);
            style.ImagesByText.Add(@"8)", Properties.Resources.rolleyes);
            style.ImagesByText.Add(@":@", Properties.Resources.unsure);
            style.ImagesByText.Add(@":)", Properties.Resources.smile_16x16);
            style.ImagesByText.Add(@":(", Properties.Resources.sad_16x16);
            style.ImagesByText.Add(@"``", Properties.Resources.greenMsg);
            style.ImagesByText.Add(@"~~", Properties.Resources.redMsg);
            style.ImagesByText.Add(@"^^", Properties.Resources.cli_qutim_ico_0);
            
            style.StartAnimation();

            fctb.OnTextChanged();
        }

        private string dsdsd = "^^" + "OnLine", _preMailBox = "";
        private delegate void PrintInFCTB(string str);
        private PrintInFCTB PrintDelegateFunc;

        private void PrintFunc(string str)
        {
            fctb.AppendText(str);
        }

        private Thread tt;
        private const string _s = "Созданный ящик: ";
        private readonly ConnectInfo _enterConnInf = new ConnectInfo();
        private readonly ClientToServer _clientToServB = new ClientToServer();
        
        /// <summary>
        /// Сервер_А
        /// </summary>
        private void Serv(object state)
        {
            string mailName = null;
            EventWaitHandle hEvent = null;
            IntPtr hMailslot = IntPtr.Zero;
            BinaryReader br = null;
            int[] mailInfo = new int[4];
            
            hMailslot = clAPI.CreateMailslot(
                            @"\\.\mailslot\" + (mailName = _enterConnInf.StrMailBox),
                            0, -1, IntPtr.Zero
                            );

            if (hMailslot == clAPI.INVALID_HANDLE_VALUE)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            hEvent = new EventWaitHandle(
                            false,
                            EventResetMode.ManualReset,
                            @"Global\Mailslot_" + mailName
                            );
            
            br = new BinaryReader(//вместо ReadFile
                        new FileStream(hMailslot, FileAccess.ReadWrite),Encoding.Default);
            
            while ((bool)state)
            {
                hEvent.WaitOne();
                
                do
                {
                    if (!clAPI.GetMailslotInfo(
                            hMailslot, out mailInfo[0], out mailInfo[1],
                            out mailInfo[2], out mailInfo[3])
                        )
                    {
                        MessageBox.Show("WARNING!!! GetMailslotInfo error: "+Marshal.GetLastWin32Error());
                        Debugger.Break();
                        break;
                    }

                    // No messages
                    if (mailInfo[1] == -1)
                        break;

/*Ник контакта*/    fctb.Invoke(PrintDelegateFunc, new object[] { (Environment.NewLine +"``"+_clientToServB.StrClientToServB + Environment.NewLine) });
                    //dsdsd+="Message:"+Environment.NewLine;
                    fctb.Invoke(PrintDelegateFunc, new object[] { (Encoding.Default.GetString(br.ReadBytes(mailInfo[1]))) });
                    //dsdsd+=(Encoding.Default.GetString(br.ReadBytes(mailInfo[1])));
                } while (mailInfo[2] != 0);

                hEvent.Reset();
     //           Console.WriteLine("Continue? Y/N");
  //              if (Console.ReadLine().Equals("N", StringComparison.InvariantCultureIgnoreCase))
  //                  break;
   //             Console.Clear();
   //             Console.WriteLine("mail: " + mailName);
                //break;
                
            }

            br.Close();
            hEvent.Close();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            if (_enterConnInf.ShowDialog() != DialogResult.OK && _enterConnInf.StrMailBox != "Введите имя нового ящика" && _enterConnInf.StrMailBox != _preMailBox)
            {
                toolStripStatusLabel2.Text = _s + _enterConnInf.StrMailBox;
                PrintDelegateFunc = new PrintInFCTB(PrintFunc);

                tt = new Thread(new ParameterizedThreadStart(Serv))
                         {
                             IsBackground = true,
                             Priority = ThreadPriority.Lowest
                         };
                tt.Start(true);

                this.Show();
                //fctb.Invoke(PrintDelegateFunc, new object[] { dsdsd });

            }else toolStripStatusLabel2.Text = _s + _preMailBox;
        }

        #region fctb_TxtChanged
        GifImageStyle style;
        static string RegexSpecSymbolsPattern = @"[\^\$\[\]\(\)\.\\\*\+\|\?\{\}]";

        private void fctb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (style == null) return;
            e.ChangedRange.ClearStyle(StyleIndex.All);
            foreach (var key in style.ImagesByText.Keys)
            {
                string pattern = Regex.Replace(key, RegexSpecSymbolsPattern, "\\$0");
                e.ChangedRange.SetStyle(style, pattern);
            }
            
            txtBoxClient.Focus();
        }
        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            string Id = "~~" + _enterConnInf.StrMailBox + Environment.NewLine;
            string messaga = txtBoxClient.Text;
            StrMessage = messaga;
            Client(true);
            txtBoxClient.Text = "";
            fctb.Text += Environment.NewLine+Id+messaga;
            
            //scroll to end
            fctb.Select();

            SendKeys.SendWait("^{END}");
            txtBoxClient.Focus();
        }

        private void checkBoxEnterLock_CheckedChanged(object sender, EventArgs e)
        {
            txtBoxClient.Focus();
        }

        private void txtBoxClient_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && checkBoxEnterLock.Checked)
            {
                txtBoxClient.Text = txtBoxClient.Text.TrimEnd('\r', '\n');
                txtBoxClient.Select(0, 0);
                btnSend_Click(sender, e);
            }
        }

        private bool _state;
        private void btnClientConnect_Click(object sender, EventArgs e)
        {//нужно подключение к серверу_Б как клиента
            //снять имя сервера_Б со свойства _clientToServB.StrClientToServB
            if (_clientToServB.ShowDialog() != DialogResult.OK && _clientToServB.StrClientToServB != "Имя сервера_Б" && _clientToServB.StrClientToServB!=null)
            {
                Client(_state);//MessageBox.Show(_clientToServB.StrClientToServB);

            }
            txtBoxClient.Focus();
        }
       
        private void Client(object state)
        {
            string mailName = null;
            EventWaitHandle hEvent = null;
            IntPtr hMailslot = IntPtr.Zero;
            int temp = 0;

            //Console.WriteLine("Enter mail:");

            hMailslot = clClientAPI.CreateFile(
                            @"\\.\mailslot\" + (mailName = _clientToServB.StrClientToServB),
                            0x40000000U /* GENERIC_WRITE */,
                            0x1U /* FILE_SHARE_READ */,
                            IntPtr.Zero,
                            0x3U /* OPEN_EXISTING */,
                            0x80U /* FILE_ATTRIBUTE_NORMAL */,
                            IntPtr.Zero
                            );

            if (hMailslot == clAPI.INVALID_HANDLE_VALUE)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            hEvent = EventWaitHandle.OpenExisting(@"Global\Mailslot_" + mailName);

            while ((bool)state)
            {
                byte[] msg = null;

                //Console.WriteLine("Write a message:");
                //с textBoxClient.Text надо считать message
                msg = Encoding.Default.GetBytes(StrMessage ?? "");

                if (!clClientAPI.WriteFile(hMailslot, msg, msg.Length, out temp, IntPtr.Zero))
                    MessageBox.Show("WARNING!!! WriteFile error: "+Marshal.GetLastWin32Error());
                else
                    hEvent.Set();

                //Console.WriteLine("Continue? Y/N");

//                if (Console.ReadLine().Equals("N", StringComparison.InvariantCultureIgnoreCase))
                    break;
            }

            clAPI.CloseHandle(hMailslot);
            hEvent.Close();
        }

        /// <summary>
        /// Тут храним тексты с textBoxClient.Text
        /// </summary>
        private string StrMessage { get; set; }

      
        

    }
}
