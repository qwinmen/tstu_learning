using System.Net;
using System.Text;
using System;
using System.IO;
using System.Windows.Forms;
//http://www.rfc-editor.org/pdfrfc/rfc791.txt.pdf
/*Note: Example Internet Datagram Header
0 					1					2					3
0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
|Version| 	IHL |Type of Service| 			Total Length 		|
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
| Identification 				|Flags| 	Fragment Offset 	|
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
| Time to Live 	| Protocol 		| Header Checksum 				|
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
| 						Source Address 							|
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
| 						Destination Address 					|
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
| 					Options 					| Padding 		|
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+

 */

/*
 * 4 ���� --> ����� ������
 * 4 ���� --> ����� ���������
 * 8 ���  --> ��� �������
 * 16 ��� --> ����� �����
 * 16 ��� --> ������������� ������
 * 3 ���� --> �����
 * 13 ��� --> �������� ���������
 * 8 ���  --> ����� �����
 * 8 ���  --> �������� �������� ������
 * 16 ��� --> ����������� �����
 * 32 ��� --> ip-����� ���������
 * 32 ��� --> ip-����� ����������
 * --> ��������� ������������ (������) 
 
 */
namespace MJsniffer
{
    public class IPHeader
    {
        //Note: IP Header
        private byte      byVersionAndHeaderLength;   //������ ��� ��� ������ � ����� ���������
        private byte      byDifferentiatedServices;    //������ ��� ��� ������������������ ����� (TOS)
        private ushort    usTotalLength;              //����������� ��� ��� ����� ����� ����������� (��������� + ���������)
        private ushort    usIdentification;           //����������� ��� ��� �������������
        private ushort    usFlagsAndOffset;           //������ ��� ��� ������ � ������������ ��������
        private byte      byTTL;                      //������ ��� ��� TTL (Time To Live)
        private byte      byProtocol;                 //������ ����� ��� �������� ���������
        private short     sChecksum;                  //����������� ���, ���������� ����������� ����� ���������
                                                      //(����� ����� ���� ������������� ������� ���, ��� short)
        private uint      uiSourceIPAddress;          //�������� ��� ���� IP-����� ���������
        private uint      uiDestinationIPAddress;     //�������� ��� ���� IP-������ ����������
        //End IP Header
        
        private byte      byHeaderLength;             //����� ���������
        private byte[]    byIPData = new byte[4096];  //������, ����������� ��� �����������


        public IPHeader(byte[] byBuffer, int nReceived)
        {

            try
            {
                //������� MemoryStream �� �������� ����
                MemoryStream memoryStream = new MemoryStream(byBuffer, 0, nReceived);
                //������� BinaryReader �� MemoryStream
                BinaryReader binaryReader = new BinaryReader(memoryStream);

                //������ ������ ����� ��������� IP �������� ������ �
                //����� ���������, ������ ��
                byVersionAndHeaderLength = binaryReader.ReadByte();

                //��������� ������ ����� �������� ������������������ ������
                byDifferentiatedServices = binaryReader.ReadByte();

                //��������� ������ ����� �������� ����� ����� �����������
                usTotalLength = (ushort) IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //��������� ����������� �������� ����� �������������
                usIdentification = (ushort) IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //��������� ����������� ��� �������� ����� � ����������. ��������
                usFlagsAndOffset = (ushort) IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //��������� ������ ����� ����� �������� TTL
                byTTL = binaryReader.ReadByte();

                //��������� ������ ������������ ��������, ����������������� � �����������
                byProtocol = binaryReader.ReadByte();

                //��������� ����������� ��� �������� ����������� ����� ���������
                sChecksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //��������� �������� ��� ���� ����� IP-����� ���������
                uiSourceIPAddress = (uint) (binaryReader.ReadInt32());

                //��������� �������� ��� �������� IP-����� ����������
                uiDestinationIPAddress = (uint) (binaryReader.ReadInt32());

                //Note: ������� ����� ���������:

                byHeaderLength = byVersionAndHeaderLength;
                //��������� ������ ���� ������ � ����� ��������� �������� � ���� ����� ���������
                //�������� ��������� ������� �������� �������������� �������� � ������� ��
                byHeaderLength <<= 4;
                byHeaderLength >>= 4;
                //�������� �� ������, ����� �������� ������ ����� ���������
                byHeaderLength *= 4;

                //����������� ������, ������������ ���������� � ������ ������
                //� ������������ � ���������� �������������� � ����������� IP
                Array.Copy(byBuffer,
                           byHeaderLength, //������ ����������� � ����� ���������
                           byIPData, 0,
                           usTotalLength - byHeaderLength);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MJsniffer", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ����� ������ ���������
        /// </summary>
        public string Version
        {
            get
            {
                //��������� IP ������
                //������ ���� ��������� IP �������� IP ������
                if ((byVersionAndHeaderLength >> 4) == 4)
                    return "IP v4";
                else if ((byVersionAndHeaderLength >> 4) == 6)
                    return "IP v6";
                else
                    return "Unknown";
            }
        }

        /// <summary>
        /// ����� ���������
        /// </summary>
        public string HeaderLength
        {
            get
            {
                return byHeaderLength.ToString();                
            }
        }

        /// <summary>
        /// ����� ���������
        /// </summary>
        public ushort MessageLength
        {
            get
            {
                //MessageLength = (���_�����_�����������) - (�����_���������)
                return (ushort)(usTotalLength - byHeaderLength);
            }
        }

        /// <summary>
        /// ������������ ������
        /// </summary>
        public string DifferentiatedServices
        {
            get
            {
                //���������� ������������������ ������ � ����������������� �������
                return string.Format ("0x{0:x2} ({1})", byDifferentiatedServices, byDifferentiatedServices);
            }
        }

        /// <summary>
        /// �����
        /// </summary>
        public string Flags
        {
            get
            {
                //������ ��� ���� ������ � ������������ �������
                //(������� ���������, �������� �� ������ �������������� ��� ���)
                int nFlags = usFlagsAndOffset >> 13;
                if (nFlags == 2)
                    return "��� ������������";
                else if (nFlags == 1)
                    return "More fragments to come";
                else
                    return nFlags.ToString();
            }
        }

        /// <summary>
        /// ���������� ��������
        /// </summary>
        public string FragmentationOffset
        {
            get
            {
                //��������� ���������� ��� ����� � ���������� ���� �������� ������������ ��������
                int nOffset = usFlagsAndOffset << 3;
                nOffset >>= 3;

                return nOffset.ToString();
            }
        }

        /// <summary>
        /// ����� ��������
        /// </summary>
        public string TTL
        {
            get
            {
                return byTTL.ToString();
            }
        }

        /// <summary>
        /// ��� ���������
        /// </summary>
        public Protocol ProtocolType
        {
            get
            {
                //���� ��������� ������������ ����� �������� � ����� ������ �����������
                if (byProtocol == 6)        //�������� ����� ������������ �������� TCP
                    return Protocol.TCP;
                else if (byProtocol == 17)  //17 UDP
                    return Protocol.UDP;
                else if (byProtocol == 1)  //1 ICMP
                    return Protocol.ICMP;
                else if (byProtocol == 2)  //2 IGMP
                    return Protocol.IGMP;
                else
                    return Protocol.Unknown;
            }
        }

        /// <summary>
        /// ����������� �����
        /// </summary>
        public string Checksum
        {
            get
            {
                //������� ��������� ����� � 16f �������
                return string.Format ("0x{0:x2}", sChecksum);
            }
        }

        /// <summary>
        /// ����� �����������/���������
        /// </summary>
        public IPAddress SourceAddress
        {
            get
            {
                return new IPAddress(uiSourceIPAddress);
            }
        }

        /// <summary>
        /// ����� ���������/����������
        /// </summary>
        public IPAddress DestinationAddress
        {
            get
            {
                return new IPAddress(uiDestinationIPAddress);
            }
        }

        /// <summary>
        /// ����� ����� (���������+���������)
        /// </summary>
        public string TotalLength
        {
            get
            {
                return usTotalLength.ToString();
            }
        }

        /// <summary>
        /// �������������
        /// </summary>
        public string Identification
        {
            get
            {
                return usIdentification.ToString();
            }
        }

        /// <summary>
        /// ������, ����������� ��� �����������
        /// </summary>
        public byte[] Data
        {
            get
            {
                return byIPData;
            }
        }
    }
}
