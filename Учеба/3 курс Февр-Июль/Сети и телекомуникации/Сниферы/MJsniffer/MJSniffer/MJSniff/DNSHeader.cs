using System.Net;
using System.Text;
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
//http://www.rfc-editor.org/pdfrfc/rfc1034.txt.pdf
namespace MJsniffer
{
    public class DNSHeader
    {
        //NOTE: DNS header
        private ushort usIdentification;        //����������� ��� ��� �������������
        private ushort usFlags;                 //����������� ��� ��� DNS ������
        private ushort usTotalQuestions;        //����������� �����, ����������� ���������� ������� � ������ ��������
        private ushort usTotalAnswerRRs;        //����������� �����, ����������� ���������� ������� � ����� ������ ������� ������
                                                //
        private ushort usTotalAuthorityRRs;     //����������� �����, ����������� ���������� �������
                                                //� ������ ������� ������
        private ushort usTotalAdditionalRRs;    //����������� �����, ����������� ���������� ������� 
                                                //�������������� �������� � ������ �������
        //End DNS header fields

        public DNSHeader(byte []byBuffer, int nReceived)
        {
            MemoryStream memoryStream = new MemoryStream(byBuffer, 0, nReceived);
            BinaryReader binaryReader = new BinaryReader(memoryStream);

            //������ ����������� ��� ��� �������������
            usIdentification = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //��������� ����������� ��������� �����
            usFlags = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //��������� ��� ������ �������� � ������ ��������
            usTotalQuestions = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //��������� ����� ���������� ������� � ������ �������
            usTotalAnswerRRs = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //��������� ����� ���������� ������� � ������ ����������
            usTotalAuthorityRRs = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //����� ���������� ������� � �������������� ������ ������ �������
            usTotalAdditionalRRs = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
        }

        /// <summary>
        /// �������������
        /// </summary>
        public string Identification
        {
            get
            {
                return string.Format("0x{0:x2}", usIdentification);
            }
        }

        /// <summary>
        /// �����
        /// </summary>
        public string Flags
        {
            get
            {
                return string.Format("0x{0:x2}", usFlags);
            }
        }

        /// <summary>
        /// ���������� ��������
        /// </summary>
        public string TotalQuestions
        {
            get
            {
                return usTotalQuestions.ToString();
            }
        }

        /// <summary>
        /// ���������� �������
        /// </summary>
        public string TotalAnswerRRs
        {
            get
            {
                return usTotalAnswerRRs.ToString();
            }
        }

        /// <summary>
        /// ����� Authority
        /// </summary>
        public string TotalAuthorityRRs
        {
            get
            {
                return usTotalAuthorityRRs.ToString();
            }
        }

        /// <summary>
        /// ����� �������������
        /// </summary>
        public string TotalAdditionalRRs
        {
            get
            {
                return usTotalAdditionalRRs.ToString();
            }
        }
	}
}
