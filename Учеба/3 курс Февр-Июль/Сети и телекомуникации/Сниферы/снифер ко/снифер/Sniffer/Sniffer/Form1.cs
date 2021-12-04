using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Sniffer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Socket socket; //собственно это и есть наше прослушивающее устройство
        private byte[] buffer; //а сюда мы будем записывать полученные пакеты
        
        //Создаем и инициализируем низкоуровневый сокет
        private void Form1_Load(object sender, EventArgs e)
        {
            //IP-адреса этой машины (нужен реальный локальный адрес)
            IPHostEntry ipHostEntry = Dns.GetHostByName(Dns.GetHostName());
            IPAddress ip = ipHostEntry.AddressList[0];

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            //socket.Bind(new IPEndPoint(IPAddress.Parse("192.168.0.11"), 0));
            socket.Bind(new IPEndPoint(ip, 0));
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

            byte[] byInc = new byte[] { 1, 0, 0, 0 };
            byte[] byOut = new byte[4];
            buffer = new byte[4096];
            socket.IOControl(IOControlCode.ReceiveAll, byInc, byOut);

            //Начинаем прослушивание
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, OnReceive, null);
        }

        //Пришел пакет
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                int nReceived = socket.EndReceive(ar);
                Print(buffer, nReceived);
                buffer = new byte[4096];
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None,
                    OnReceive, null);
            }
            catch { }
        }


        //Счетчики для статистики
        int packetsTCP = 0, packetsUDP = 0, packetsICMP = 0, packetsIGMP = 0, allPackets = 0;
        long dataTCP = 0, dataUDP = 0, dataICMP = 0, dataIGMP = 0, allData;
        private void Print(byte[] buf, int len)
        {
            //Парсим пакет
            IPHeader ipHeader = new IPHeader(buf, len);
            //Пишем в лог информацию о пакете
            string info =
                string.Format("{0}\tFrom: {1} To: {2}  Length: {3}\n",
                ipHeader.ProtocolType.ToString(),
                ipHeader.SourceAddress,
                ipHeader.DestinationAddress,
                ipHeader.TotalLength);
            richTextBox1.BeginInvoke(new Action(() => richTextBox1.AppendText(info)));
            //Считаем статистику
            allPackets++;
            allData += ipHeader.TotalLength;
            switch (ipHeader.ProtocolType)
            {
                case Protocol.TCP:
                    {
                        packetsTCP++;
                        dataTCP += ipHeader.TotalLength;
                        break;
                    }
                case Protocol.UDP:
                    {
                        packetsUDP++;
                        dataUDP += ipHeader.TotalLength;
                        break;
                    }
                case Protocol.ICMP:
                    {
                        packetsICMP++;
                        dataICMP += ipHeader.TotalLength;
                        break;
                    }
                case Protocol.IGMP:
                    {
                        packetsIGMP++;
                        dataIGMP += ipHeader.TotalLength;
                        break;
                    }
            }
            //Выводим статистику
            string stat = string.Format(
                "TCP: \nпакетов - {0}, ({1}%) \nданных - {2:0.00} Кб ({3}%)\n" +
                "UDP: \nпакетов - {4}, ({5}%) \nданных - {6:0.00} Кб ({7}%)\n" +
                "ICMP: \nпакетов - {8}, ({9}%) \nданных - {10:0.00} Кб ({11}%)\n" +
                "IGMP: \nпакетов - {12}, ({13}%) \nданных - {14:0.00} Кб ({15}%)\n" + 
                "\nВсего: \nпакетов - {16} \nданных - {17:0.00} Кб",
                packetsTCP, (int)100 * packetsTCP / allPackets, (double)dataTCP / (8 * 1024), (int)100 * dataTCP / allData,
                packetsUDP, (int)100 * packetsUDP / allPackets, (double)dataUDP / (8 * 1024), (int)100 * dataUDP / allData,
                packetsICMP, (int)100 * packetsICMP / allPackets, (double)dataICMP / (8 * 1024), (int)100 * dataICMP / allData,
                packetsIGMP, (int)100 * packetsIGMP / allPackets, (double)dataIGMP / (8 * 1024), (int)100 * dataIGMP / allData,
                allPackets, (double)allData / (8 * 1024));
            lblStat.BeginInvoke(new Action(() => lblStat.Text = stat));
        }
    }
}
