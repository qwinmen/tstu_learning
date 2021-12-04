using System.Net;
using System.Text;
using System;
using System.IO;
using System.Windows.Forms;
//http://www.rfc-editor.org/pdfrfc/rfc793.txt.pdf
namespace MJsniffer
{
    public class TCPHeader
    {
        //NOTE: TCP header
        private ushort usSourcePort;              //����������� ����� ��� ������ ����� ���������
        private ushort usDestinationPort;         //����������� ��� ��� ������ ����� ����������
        private uint uiSequenceNumber = 555;          //�������� ��� ���� ��� ����������� ������ (����� �������)
        private uint uiAcknowledgementNumber = 555;   //�������� ��� ���� ��� ������ �������������
        private ushort usDataOffsetAndFlags = 555;      //����������� ��� ��� ������ � ������ ��������
        private ushort usWindow = 555;                  //����������� ����� ��� ������� ����
        private short sChecksum = 555;                 //����������� ����� ��� ����������� �����
                                                    //(����� ���� ������������� short)
        private ushort usUrgentPointer;           //����������� ��� ��� ��������� ���������
        //End TCP header

        private byte   byHeaderLength;            //����� ���������
        private ushort usMessageLength;           //����� ������
        private byte[] byTCPData = new byte[4096];//������, ����������� � ������ TCP
       
        public TCPHeader(byte [] byBuffer, int nReceived)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream(byBuffer, 0, nReceived);
                BinaryReader binaryReader = new BinaryReader(memoryStream);

                //������ ����������� ����� �������� ���� ���������
                usSourcePort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16 ());

                //��������� ����������� ��������� ���� ����������
                usDestinationPort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16 ());

                //��������� �������� ��� ����� ���������� �����
                uiSequenceNumber = (uint)IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());

                //��������� �������� ��� ����� ����� �������������
                uiAcknowledgementNumber = (uint)IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());

                //��������� ����������� ��� �������� ����� � ������ ��������
                usDataOffsetAndFlags = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //��������� ����������� ��������� ������ ����
                usWindow = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //� ��������� ����������� ��� ���� ����������� �����
                sChecksum = (short)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //��������� ����������� ��������� ��������� ���������
                usUrgentPointer = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //������ �������� ���������, ��� ���������� ������, ������� ��� �������. ��� ������. ����� ���������
                byHeaderLength = (byte)(usDataOffsetAndFlags >> 12);
                byHeaderLength *= 4;

                //����� ��������� = ����� ����� ������ TCP - ������ ���������
                usMessageLength = (ushort)(nReceived - byHeaderLength);

                //������ ������ TCP � ����� ������
                Array.Copy(byBuffer, byHeaderLength, byTCPData, 0, nReceived - byHeaderLength);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MJsniff TCP" + (nReceived), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ���� �����������
        /// </summary>
        public string SourcePort
        {
            get
            {
                return usSourcePort.ToString();
            }
        }

        /// <summary>
        /// ���� ����������
        /// </summary>
        public string DestinationPort
        {
            get
            {
                return usDestinationPort.ToString ();
            }
        }

        /// <summary>
        /// ����� �������
        /// </summary>
        public string SequenceNumber
        {
            get
            {
                return uiSequenceNumber.ToString();
            }
        }

        /// <summary>
        /// ����� �������������
        /// </summary>
        public string AcknowledgementNumber
        {
            get
            {
                //If the ACK flag is set then only we have a valid value in
                //the acknowlegement field, so check for it beore returning 
                //anything
                if ((usDataOffsetAndFlags & 0x10) != 0)
                    return uiAcknowledgementNumber.ToString();
                else
                    return "";
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
        /// ������ ����
        /// </summary>
        public string WindowSize
        {
            get
            {
                return usWindow.ToString();
            }
        }

        /// <summary>
        /// ��������� ���������
        /// </summary>
        public string UrgentPointer
        {
            get
            {
                //If the URG flag is set then only we have a valid value in
                //the urgent pointer field, so check for it beore returning 
                //anything
                if ((usDataOffsetAndFlags & 0x20) != 0)
                    return usUrgentPointer.ToString();
                else
                    return "";
            }
        }

        /// <summary>
        /// �����
        /// </summary>
        public string Flags
        {
            get
            {
                //��������� ����� ��� ������ �������� � ����� �������� ����������� ����

                //������� �� �������� �����
                int nFlags = usDataOffsetAndFlags & 0x3F;
 
                string strFlags = string.Format ("0x{0:x2} (", nFlags);

                //������ �� ����� ��������, ����������� �� ��������� ���� ��� ���
                if ((nFlags & 0x01) != 0)
                    strFlags += "FIN, ";
                if ((nFlags & 0x02) != 0)
                    strFlags += "SYN, ";
                if ((nFlags & 0x04) != 0)
                    strFlags += "RST, ";
                if ((nFlags & 0x08) != 0)
                    strFlags += "PSH, ";
                if ((nFlags & 0x10) != 0)
                    strFlags += "ACK, ";
                if ((nFlags & 0x20) != 0)
                    strFlags += "URG";
                strFlags += ")";

                if (strFlags.Contains("()"))
                    strFlags = strFlags.Remove(strFlags.Length - 3);
                else if (strFlags.Contains(", )"))
                    strFlags = strFlags.Remove(strFlags.Length - 3, 2);

                return strFlags;
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
                return byTCPData;
            }
        }

        /// <summary>
        /// ����� ���������
        /// </summary>
        public ushort MessageLength
        {
            get
            {
                return usMessageLength;
            }
        }
    }
}