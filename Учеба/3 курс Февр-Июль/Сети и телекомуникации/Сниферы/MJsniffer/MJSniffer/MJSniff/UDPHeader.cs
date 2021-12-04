using System.Net;
using System.Text;
using System;
using System.IO;
using System.Windows.Forms;
//http://www.rfc-editor.org/pdfrfc/rfc768.txt.pdf
namespace MJsniffer
{
    public class UDPHeader
    {
        //NOTE: UDP header
        private ushort usSourcePort;            //����� ����� ����������� 16 bit
        private ushort usDestinationPort;       //����� ����� ���������� 16 bit
        private ushort usLength;                //����� ����������
        private short sChecksum;                //����������� ����� 16 bit
                                                //(checksum can be negative so taken as short)
        //End UDP header

        private byte[] byUDPData = new byte[4096];  //������, ����������� � ������ UDP

        public UDPHeader(byte [] byBuffer, int nReceived)
        {
            MemoryStream memoryStream = new MemoryStream(byBuffer, 0, nReceived);
            BinaryReader binaryReader = new BinaryReader(memoryStream);

            //������ ����������� ����� �������� ���� ���������
            usSourcePort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //��������� ����������� ��� �������� ���� ����������
            usDestinationPort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //��������� ����������� ��� �������� ����� ������ UDP
            usLength = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //��������� ����������� ��� �������� ����������� �����
            sChecksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //����������� ������, ������������ �� UDP ������ � ������ ������
            Array.Copy(byBuffer,
                       8,               //UDP ��������� �� 8 ����, ������� �� ������ ����������� ����� ����
                       byUDPData, 
                       0, 
                       nReceived - 8);
        }

        /// <summary>
        /// ����� ����� ����������� 
        /// </summary>
        public string SourcePort
        {
            get
            {
                return usSourcePort.ToString();
            }
        }

        /// <summary>
        /// ����� ����� ����������
        /// </summary>
        public string DestinationPort
        {
            get
            {
                return usDestinationPort.ToString();
            }
        }

        /// <summary>
        /// ����� ����������
        /// </summary>
        public string Length
        {
            get
            {
                return usLength.ToString ();
            }
        }

        /// <summary>
        /// ����������� �����
        /// </summary>
        public string Checksum
        {
            get
            {
                //Return the checksum in hexadecimal format
                return string.Format("0x{0:x2}", sChecksum);
            }
        }

        /// <summary>
        /// ���������
        /// </summary>
        public byte[] Data
        {
            get
            {
                return byUDPData;
            }
        }
    }
}