using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using MJSniff;

/*http://www.rfc-editor.org/search/standards.php
//-->faerwall == off!
//tcp\ip == internet(brouzer)
//udp == VM_VirtBox_Kali
//ICMP == VM_VirtBox_Kali_PING
 */
namespace MJsniffer
{
    public enum Protocol
    {
        ICMP = 1,
        IGMP = 2,
        TCP = 6,
        UDP = 17,
        Unknown = -1
    };

    public partial class MJsnifferForm : Form
    {
        private Socket mainSocket;                          //The socket which captures all incoming packets
        private byte[] byteData = new byte[4096];
        private bool bContinueCapturing = false;            //A flag to check if packets are to be captured or not

        private delegate void AddTreeNode(TreeNode node);

        public MJsnifferForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbInterfaces.Text == "")
            {
                MessageBox.Show("Select an Interface to capture the packets.", "MJsniffer", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (!bContinueCapturing)        
                {
                    //Start capturing the packets...

                    btnStart.Text = "&Stop";

                    bContinueCapturing = true;

                    //создаем сам сокет:
                    mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
                    
                    //Связывание локального адреса и сокета
                    mainSocket.Bind(new IPEndPoint(IPAddress.Parse(cmbInterfaces.Text), 0));

                    //Set the socket  options
                    mainSocket.SetSocketOption(SocketOptionLevel.IP,            //Applies only to IP packets
                                               SocketOptionName.HeaderIncluded, //Set the include the header
                                               true);                           //option to true

                    byte[] byTrue = new byte[4] {1, 0, 0, 0};
                    byte[] byOut = new byte[4]{1, 0, 0, 0}; //Capture outgoing packets

                    
                    //Socket.IOControl is analogous to the WSAIoctl method of Winsock 2
                    //mainSocket.IOControl(IOControlCode.ReceiveAll,              //Equivalent to SIO_RCVALL constant
                                                                                //of Winsock 2
                      //                   byTrue,                                    
                        //                 byOut);

                    

                    //Start receiving the packets asynchronously
                    mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                       new AsyncCallback(OnReceive), null);
                }
                else
                {
                    btnStart.Text = "&Start";
                    bContinueCapturing = false;
                    //To stop capturing the packets close the socket
                    mainSocket.Close ();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MJsniffer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                int nReceived = mainSocket.EndReceive(ar);

                //Analyze the bytes received...                
                ParseData (byteData, nReceived);

                if (bContinueCapturing)     
                {
                    byteData = new byte[4096];
                    
                    //Another call to BeginReceive so that we continue to receive the incoming
                    //packets
                    mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                        new AsyncCallback(OnReceive), null);
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MJsniffer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void ParseData(byte[] byteData, int nReceived)
        {
            TreeNode rootNode = new TreeNode();

            //Since all protocol packets are encapsulated in the IP datagram
            //so we start by parsing the IP header and see what protocol data
            //is being carried by it
            IPHeader ipHeader = new IPHeader(byteData, nReceived);

            TreeNode ipNode = MakeIPTreeNode(ipHeader);
            rootNode.Nodes.Add(ipNode);

            
            //Now according to the protocol being carried by the IP datagram we parse 
            //the data field of the datagram
            switch (ipHeader.ProtocolType)
            {
                case Protocol.TCP:

                    TCPHeader tcpHeader = new TCPHeader(ipHeader.Data,              //IPHeader.Data stores the data being 
                                                                                    //carried by the IP datagram
                                                        ipHeader.MessageLength);//Length of the data field                    

                    TreeNode tcpNode = MakeTCPTreeNode(tcpHeader);

                    rootNode.Nodes.Add(tcpNode);

                    //If the port is equal to 53 then the underlying protocol is DNS
                    //Note: DNS can use either TCP or UDP thats why the check is done twice
                    if (tcpHeader.DestinationPort == "53" || tcpHeader.SourcePort == "53")
                    {
                        TreeNode dnsNode = MakeDNSTreeNode(tcpHeader.Data, (int)tcpHeader.MessageLength);
                        rootNode.Nodes.Add(dnsNode);
                    }
                    
                    break;

                case Protocol.UDP:

                    UDPHeader udpHeader = new UDPHeader(ipHeader.Data,              //IPHeader.Data stores the data being 
                                                                                    //carried by the IP datagram
                                                       (int)ipHeader.MessageLength);//Length of the data field                    

                    TreeNode udpNode = MakeUDPTreeNode(udpHeader);

                    rootNode.Nodes.Add(udpNode);

                    //If the port is equal to 53 then the underlying protocol is DNS
                    //Note: DNS can use either TCP or UDP thats why the check is done twice
                    if (udpHeader.DestinationPort == "53" || udpHeader.SourcePort == "53")
                    {

                        TreeNode dnsNode = MakeDNSTreeNode(udpHeader.Data,
                                                           //Length of UDP header is always eight bytes so we subtract that out of the total 
                                                           //length to find the length of the data
                                                           Convert.ToInt32(udpHeader.Length) - 8);  
                        rootNode.Nodes.Add(dnsNode);
                    }

                    break;

                case Protocol.ICMP:

                    ICMPHeader icmpHeader = new ICMPHeader(ipHeader.Data, ipHeader.MessageLength);
                    TreeNode icmpNode = MakeICMPTreeNode(icmpHeader);
                    rootNode.Nodes.Add(icmpNode);

                    //MessageBox.Show("ICMP");
                    break;
                case Protocol.IGMP:
                    IGMPHeader igmpHeader = new IGMPHeader(ipHeader.Data, ipHeader.MessageLength);
                    TreeNode igmpNode = MakeIGMPTreeNode(igmpHeader);
                    rootNode.Nodes.Add(igmpNode);
                    break;
                case Protocol.Unknown:
                    break;
            }

            AddTreeNode addTreeNode = new AddTreeNode(OnAddTreeNode);

            rootNode.Text = ipHeader.SourceAddress.ToString() + "-" +
                ipHeader.DestinationAddress.ToString();

            //Thread safe adding of the nodes
            treeView.Invoke(addTreeNode, new object[] {rootNode});
        }

        //Helper function which returns the information contained in the IP header as a
        //tree node
        private TreeNode MakeIPTreeNode(IPHeader ipHeader)
        {
            TreeNode ipNode = new TreeNode();

            ipNode.Text = "IP";            
            ipNode.Nodes.Add ("Ver: " + ipHeader.Version);
            ipNode.Nodes.Add ("Header Length: " + ipHeader.HeaderLength);
            ipNode.Nodes.Add ("Differntiated Services: " + ipHeader.DifferentiatedServices);
            ipNode.Nodes.Add("Total Length: " + ipHeader.TotalLength);
            ipNode.Nodes.Add("Identification: " + ipHeader.Identification);
            ipNode.Nodes.Add("Flags: " + ipHeader.Flags);
            ipNode.Nodes.Add("Fragmentation Offset: " + ipHeader.FragmentationOffset);
            ipNode.Nodes.Add("Time to live: " + ipHeader.TTL);
            switch (ipHeader.ProtocolType)
            {
                case Protocol.TCP:
                    ipNode.Nodes.Add ("Protocol: " + "TCP");
                    break;
                case Protocol.UDP:
                    ipNode.Nodes.Add ("Protocol: " + "UDP");
                    break;
                case Protocol.ICMP:
                    ipNode.Nodes.Add("Protocol: " + "ICMP");
                    break;
                case Protocol.IGMP:
                    ipNode.Nodes.Add("Protocol: " + "IGMP");
                    break;
                case Protocol.Unknown:
                    ipNode.Nodes.Add ("Protocol: " + "Unknown");
                    break;
            }
            ipNode.Nodes.Add("Checksum: " + ipHeader.Checksum);
            ipNode.Nodes.Add("Source: " + ipHeader.SourceAddress.ToString());
            ipNode.Nodes.Add("Destination: " + ipHeader.DestinationAddress.ToString());

            return ipNode;
        }
        
        //Helper function which returns the information contained in the TCP header as a
        //tree node
        private TreeNode MakeTCPTreeNode(TCPHeader tcpHeader)
        {
            TreeNode tcpNode = new TreeNode();

            tcpNode.Text = "TCP";

            tcpNode.Nodes.Add("Source Port: " + tcpHeader.SourcePort);
            tcpNode.Nodes.Add("Destination Port: " + tcpHeader.DestinationPort);
            tcpNode.Nodes.Add("Sequence Number: " + tcpHeader.SequenceNumber);

            if (tcpHeader.AcknowledgementNumber != "")
                tcpNode.Nodes.Add("Acknowledgement Number: " + tcpHeader.AcknowledgementNumber);

            tcpNode.Nodes.Add("Header Length: " + tcpHeader.HeaderLength);
            tcpNode.Nodes.Add("Flags: " + tcpHeader.Flags);
            tcpNode.Nodes.Add("Window Size: " + tcpHeader.WindowSize);
            tcpNode.Nodes.Add("Checksum: " + tcpHeader.Checksum);

            if (tcpHeader.UrgentPointer != "")
                tcpNode.Nodes.Add("Urgent Pointer: " + tcpHeader.UrgentPointer);

            return tcpNode;
        }

        //Helper function which returns the information contained in the UDP header as a
        //tree node
        private TreeNode MakeUDPTreeNode(UDPHeader udpHeader)
        {           
            TreeNode udpNode = new TreeNode();

            udpNode.Text = "UDP";
            udpNode.Nodes.Add("Source Port: " + udpHeader.SourcePort);
            udpNode.Nodes.Add("Destination Port: " + udpHeader.DestinationPort);
            udpNode.Nodes.Add("Length: " + udpHeader.Length);
            udpNode.Nodes.Add("Checksum: " + udpHeader.Checksum);
            
            return udpNode;
        }

        /// <summary>
        /// Возвращает информацию содержащуюся в сообщении
        /// </summary>
        private TreeNode MakeICMPTreeNode(ICMPHeader icmpHeader)
        {
            TreeNode icmpNode = new TreeNode();

            icmpNode.Text = "ICMP";
            icmpNode.Nodes.Add("Type: " + icmpHeader.Type);
            icmpNode.Nodes.Add("Code: " + icmpHeader.Code);
            icmpNode.Nodes.Add("Checksum: " + icmpHeader.Checksum);
            icmpNode.Nodes.Add("ID процесса : " + icmpHeader.OriginTimestamp);
            icmpNode.Nodes.Add("#: " + icmpHeader.RecvTimestamp);
            icmpNode.Nodes.Add("Data: " + icmpHeader.TrnsTimestamp);

            return icmpNode;
        }

        /// <summary>
        /// Возвращает информацию igmp пакета
        /// </summary>
        private TreeNode MakeIGMPTreeNode(IGMPHeader igmpHeader)
        {
            TreeNode igmpNode = new TreeNode();

            igmpNode.Text = "IGMP";
            igmpNode.Nodes.Add("Version: " + igmpHeader.Version);
            igmpNode.Nodes.Add("Type: " + igmpHeader.Type);
            igmpNode.Nodes.Add("Zero: " + igmpHeader.ZeroSpase);
            igmpNode.Nodes.Add("Checksum: " + igmpHeader.Checksum);
            igmpNode.Nodes.Add("IP class-D : " + igmpHeader.SourceAddress);

            return igmpNode;
        }

        //Helper function which returns the information contained in the DNS header as a
        //tree node
        private TreeNode MakeDNSTreeNode(byte[] byteData, int nLength)
        {
            DNSHeader dnsHeader = new DNSHeader(byteData, nLength);

            TreeNode dnsNode = new TreeNode();

            dnsNode.Text = "DNS";
            dnsNode.Nodes.Add("Identification: " + dnsHeader.Identification);
            dnsNode.Nodes.Add("Flags: " + dnsHeader.Flags);
            dnsNode.Nodes.Add("Questions: " + dnsHeader.TotalQuestions);
            dnsNode.Nodes.Add("Answer RRs: " + dnsHeader.TotalAnswerRRs);
            dnsNode.Nodes.Add("Authority RRs: " + dnsHeader.TotalAuthorityRRs);
            dnsNode.Nodes.Add("Additional RRs: " + dnsHeader.TotalAdditionalRRs);

            return dnsNode;
        }

        private void OnAddTreeNode(TreeNode node)
        {
            treeView.Nodes.Add(node);
        }

        private void SnifferForm_Load(object sender, EventArgs e)
        {
            string strIP = null;

            IPHostEntry HosyEntry = Dns.GetHostEntry((Dns.GetHostName()));
            if (HosyEntry.AddressList.Length > 0)
            {
                foreach (IPAddress ip in HosyEntry.AddressList)
                {
                    strIP = ip.ToString();
                    cmbInterfaces.Items.Add(strIP);
                }
            }
            //cmbInterfaces.Items.Add("10.11.12.13");//213.87.143.180//10.162.174.199
        }

        private void SnifferForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bContinueCapturing)
            {
                mainSocket.Close();
            }
        }
    }
}