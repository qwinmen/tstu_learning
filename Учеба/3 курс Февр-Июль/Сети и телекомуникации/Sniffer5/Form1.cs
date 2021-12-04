using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;

/*http://www.rfc-editor.org/search/standards.php
//-->faerwall == off!
//tcp\ip == internet(brouzer)
//udp == VM_VirtBox_Kali
//ICMP == VM_VirtBox_Kali_PING
 */
namespace Sniffer5
{
        public enum Protocol
        {
            ICMP = 1,
            IGMP = 2,
            TCP = 6,
            UDP = 17,
            Unknown = -1
        } ;

        public partial class Form1 : Form
        {

            private Socket mainSocket;                          //Сокет на прием
            private byte[] byteData = new byte[4096];
            private bool bContinueCapturing = false;            //прием пакет вкл
            /// <summary>
            /// Доступ к контролу из патока
            /// </summary>
            private delegate void AddIPLabel(LabelItem labelItem);

            public Form1()
            {
                InitializeComponent();
            }

            /// <summary>
            /// Вкл\Откл прием пакетов
            /// </summary>
            private void switchBtn_OnSniff_ValueChanged(object sender, EventArgs e)
            {
                if (labelItem_IP.Text == "")
                {
                    MessageBox.Show("Не определен адрес получающей стороны.", "Sn5",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //if (!switchBtn_OnSniff.Value) return;
                try
                {
                    if (!bContinueCapturing)
                    {
                        bContinueCapturing = true;
                        //создаем сам сокет:
                        mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
                        
                        var strIp = labelItem_IP.Text.Remove(0,4);
                        //Связывание локального адреса и сокета
                        mainSocket.Bind(new IPEndPoint(IPAddress.Parse(strIp), 0));
                        
                        //Уст опции сокета
                        mainSocket.SetSocketOption(SocketOptionLevel.IP,            //Нужны только IP пакеты
                                                   SocketOptionName.HeaderIncluded, //Включать заголовки
                                                   true);

                        //Note: IOControl для работы в windows 8||Для Vista строки коментируем
                        mainSocket.IOControl(IOControlCode.ReceiveAll, new byte[] { 1, 0, 0, 0 }, new byte[4]);
                        //Note: Запустить прослушку канала в асинхронном режиме
                        mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
                    }
                    else
                    {
                        bContinueCapturing = false;
                        //Остановки прослушивания, закрытие сокета
                        mainSocket.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sn5", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            /// <summary>
            /// Асинхронная прослушка канала
            /// </summary>
            private void OnReceive(IAsyncResult ar)
            {
                try
                {
                    int nReceived = mainSocket.EndReceive(ar);
                    
                    //Note: Разобрать полученные данные
                    ParseData(byteData, nReceived);

                    if (bContinueCapturing)
                    {
                        byteData = new byte[4096];

                        //Рекурсивный вызов для следующей партий данных
                        mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
                    }
                }
                catch (ObjectDisposedException){}
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sn5", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private int _tagIndexer = 0;

            /// <summary>
            /// Разбор по протоколам, вывод информации
            /// Note: Мультипоток!
            /// </summary>
            private void ParseData(byte[] byteData, int nReceived)
            {
                //Note: Получить заголовок датаграмы, инкапсулированной в пакет IP
                IPHeader ipHeader = new IPHeader(byteData, nReceived);
                _IPHeadList.Add(_tagIndexer, ipHeader);

                AddIPLabel addIpLabel = new AddIPLabel(OnAddLabelItem);
                LabelItem _tmpLabelIP = new LabelItem()
                                            {
                                               BorderType = eBorderType.DoubleLine,
                                               Text = ipHeader.SourceAddress + "⇒" + ipHeader.DestinationAddress,
                                               Tag = _tagIndexer
                                           };
                switch (ipHeader.ProtocolType)
                {
                    case Protocol.ICMP: _tmpLabelIP.BackColor = Color.CadetBlue; _tmpLabelIP.Tooltip = "ICMP"; break;
                    case Protocol.IGMP: _tmpLabelIP.BackColor = Color.Violet; _tmpLabelIP.Tooltip = "IGMP"; break;
                    case Protocol.TCP: _tmpLabelIP.BackColor = Color.LightGreen; _tmpLabelIP.Tooltip = "TCP"; break;
                    case Protocol.UDP: _tmpLabelIP.BackColor = Color.OrangeRed; _tmpLabelIP.Tooltip = "UDP"; break;
                    case Protocol.Unknown: _tmpLabelIP.BackColor = Color.Gray; _tmpLabelIP.Tooltip = "Unknown"; break;
                }
                _tmpLabelIP.Click += new EventHandler(LabelClic);
                _tagIndexer++;

                //Note: Добавление элемента через поток:
                itemPanel_IpConteiner.Invoke(addIpLabel , new object[]{_tmpLabelIP});
            }

            /// <summary>
            /// Клик по label - выдать информацию об элементе
            /// </summary>
            private void LabelClic(object sender, EventArgs e)
            {
                advTree_IP.Nodes.Clear();
                textBox_Protocols.Text = "";
                
                IPHeader ipHeader = _IPHeadList[(int) ((LabelItem) sender).Tag];
                //Подробности IP
                advTree_IP.Nodes.Add(MakeIP(ipHeader));
                
                //Подробности Protocol
                switch (ipHeader.ProtocolType)
                {
                    case Protocol.TCP:

                        TCPHeader tcpHeader = new TCPHeader(ipHeader.Data,              //IPHeader.Data stores the data being 
                            //carried by the IP datagram
                                                            ipHeader.MessageLength);//Length of the data field                    

                        MakeTCP(tcpHeader);

                        //If the port is equal to 53 then the underlying protocol is DNS
                        //Note: DNS can use either TCP or UDP thats why the check is done twice
                        if (tcpHeader.DestinationPort == "53" || tcpHeader.SourcePort == "53")
                        {
                            MakeDNS(tcpHeader.Data, (int)tcpHeader.MessageLength);
                        }

                        break;

                    case Protocol.UDP:

                        UDPHeader udpHeader = new UDPHeader(ipHeader.Data,              //IPHeader.Data stores the data being 
                            //carried by the IP datagram
                                                           (int)ipHeader.MessageLength);//Length of the data field                    
                        MakeUDP(udpHeader);
                        //If the port is equal to 53 then the underlying protocol is DNS
                        //Note: DNS можно использовать как TCP или UDP Именно поэтому проверка выполняется в два раза
                        if (udpHeader.DestinationPort == "53" || udpHeader.SourcePort == "53")
                        {
                            MakeDNS(udpHeader.Data,
                                // Длина UDP заголовка всегда восемь байт, поэтому вычитаем из общего числа
                                //чтобы найти длину данных
                                                               Convert.ToInt32(udpHeader.Length) - 8);
                        }

                        break;

                    case Protocol.ICMP:

                        ICMPHeader icmpHeader = new ICMPHeader(ipHeader.Data, ipHeader.MessageLength);
                        MakeICMP(icmpHeader);
                        
                        break;
                    case Protocol.IGMP:
                        IGMPHeader igmpHeader = new IGMPHeader(ipHeader.Data, ipHeader.MessageLength);
                        MakeIGMP(igmpHeader);
                        
                        break;
                    case Protocol.Unknown:
                        break;
                }
                
            }

            private void MakeUDP(UDPHeader udpHeader)
            {
                textBox_Protocols.AppendText("UDP");
                textBox_Protocols.AppendText("\r\nSource Port: " + udpHeader.SourcePort);
                textBox_Protocols.AppendText("\r\nDestination Port: " + udpHeader.DestinationPort);
                textBox_Protocols.AppendText("\r\nLength: " + udpHeader.Length);
                textBox_Protocols.AppendText("\r\nChecksum: " + udpHeader.Checksum);
                
            }

            /// <summary>
            /// Возвращает информацию содержащуюся в сообщении
            /// </summary>
            private void MakeICMP(ICMPHeader icmpHeader)
            {
                textBox_Protocols.AppendText("ICMP");
                textBox_Protocols.AppendText("\r\nType: " + icmpHeader.Type);
                textBox_Protocols.AppendText("\r\nCode: " + icmpHeader.Code);
                textBox_Protocols.AppendText("\r\nChecksum: " + icmpHeader.Checksum);
                textBox_Protocols.AppendText("\r\nID процесса : " + icmpHeader.OriginTimestamp);
                textBox_Protocols.AppendText("\r\n#: " + icmpHeader.RecvTimestamp);
                textBox_Protocols.AppendText("\r\nData: " + icmpHeader.TrnsTimestamp);
                
            }

            /// <summary>
            /// Возвращает информацию igmp пакета
            /// </summary>
            private void MakeIGMP(IGMPHeader igmpHeader)
            {
                textBox_Protocols.AppendText("IGMP");
                textBox_Protocols.AppendText("\r\nVersion: " + igmpHeader.Version);
                textBox_Protocols.AppendText("\r\nType: " + igmpHeader.Type);
                textBox_Protocols.AppendText("\r\nZero: " + igmpHeader.ZeroSpase);
                textBox_Protocols.AppendText("\r\nChecksum: " + igmpHeader.Checksum);
                textBox_Protocols.AppendText("\r\nIP class-D : " + igmpHeader.SourceAddress);
            }

            private void MakeDNS(byte[] byteData, int nLength)
            {
                DNSHeader dnsHeader = new DNSHeader(byteData, nLength);

                textBox_Protocols.AppendText("DNS");
                textBox_Protocols.AppendText("\r\nIdentification: " + dnsHeader.Identification);
                textBox_Protocols.AppendText("\r\nFlags: " + dnsHeader.Flags);
                textBox_Protocols.AppendText("\r\nQuestions: " + dnsHeader.TotalQuestions);
                textBox_Protocols.AppendText("\r\nAnswer RRs: " + dnsHeader.TotalAnswerRRs);
                textBox_Protocols.AppendText("\r\nAuthority RRs: " + dnsHeader.TotalAuthorityRRs);
                textBox_Protocols.AppendText("\r\nAdditional RRs: " + dnsHeader.TotalAdditionalRRs);
            }

            private Dictionary<int, IPHeader> _IPHeadList = new Dictionary<int, IPHeader>();

            /// <summary>
            /// Добавить LabelItem в контейнер
            /// </summary>
            private void OnAddLabelItem(LabelItem labelItem)
            {
                itemContainer_SniffIP.SubItems.AddRange(new BaseItem[]{labelItem});
                itemPanel_IpConteiner.Refresh();
                //itemContainer_SniffIP.Refresh();
            }

            /// <summary>
            /// Подгрузить информацию по IP
            /// </summary>
            private Node MakeIP(IPHeader ipHeader)
            {
                Node node = new Node(ipHeader.Version);
                node.Cells.Add(new Cell(ipHeader.HeaderLength));
                node.Cells.Add(new Cell(ipHeader.DifferentiatedServices));
                node.Cells.Add(new Cell(ipHeader.TotalLength));
                node.Cells.Add(new Cell(ipHeader.Identification));
                node.Cells.Add(new Cell(ipHeader.Flags));
                node.Cells.Add(new Cell(ipHeader.FragmentationOffset));
                node.Cells.Add(new Cell(ipHeader.TTL));
                switch (ipHeader.ProtocolType)
                {
                    case Protocol.TCP:
                        node.Cells.Add(new Cell(("TCP")));
                        break;
                    case Protocol.UDP:
                        node.Cells.Add(new Cell(("UDP")));
                        break;
                    case Protocol.ICMP:
                        node.Cells.Add(new Cell(("ICMP")));
                        break;
                    case Protocol.IGMP:
                        node.Cells.Add(new Cell(("IGMP")));
                        break;
                    case Protocol.Unknown:
                        node.Cells.Add(new Cell(("Unknown")));
                        break;
                }
                node.Cells.Add(new Cell(ipHeader.Checksum));
                node.Cells.Add(new Cell(ipHeader.SourceAddress.ToString()));
                node.Cells.Add(new Cell(ipHeader.DestinationAddress.ToString()));

                return node;
            }

            private void MakeTCP(TCPHeader tcpHeader)
            {

                textBox_Protocols.AppendText("TCP");

                textBox_Protocols.AppendText("\r\nSource Port: " + tcpHeader.SourcePort);
                textBox_Protocols.AppendText("\r\nDestination Port: " + tcpHeader.DestinationPort);
                textBox_Protocols.AppendText("\r\nSequence Number: " + tcpHeader.SequenceNumber);

                if (tcpHeader.AcknowledgementNumber != "")
                    textBox_Protocols.AppendText("\r\nAcknowledgement Number: " + tcpHeader.AcknowledgementNumber);

                textBox_Protocols.AppendText("\r\nHeader Length: " + tcpHeader.HeaderLength);
                textBox_Protocols.AppendText("\r\nFlags: " + tcpHeader.Flags);
                textBox_Protocols.AppendText("\r\nWindow Size: " + tcpHeader.WindowSize);
                textBox_Protocols.AppendText("\r\nChecksum: " + tcpHeader.Checksum);

                if (tcpHeader.UrgentPointer != "")
                    textBox_Protocols.AppendText("\r\nUrgent Pointer: " + tcpHeader.UrgentPointer);
                
            }

            private Regex _rxNums = new Regex(@"^\d+\."); // любые цифры или точка

            /// <summary>
            /// Установить IP адрес ПК
            /// </summary>
            private void Form1_Load(object sender, EventArgs e)
            {
                IPHostEntry HosyEntry = Dns.GetHostEntry((Dns.GetHostName()));
                foreach (IPAddress ip in HosyEntry.AddressList)
                {
                    if (_rxNums.IsMatch(ip.ToString()))
                        labelItem_IP.Text = "IP: " + ip;
                }
            }

            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (bContinueCapturing)
                {
                    mainSocket.Close();
                }
            }





        }



}
