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
        private ushort usSourcePort;              //Шестнадцать битов для номера порта источника
        private ushort usDestinationPort;         //Шестнадцать бит для номера порта назначения
        private uint uiSequenceNumber = 555;          //Тридцать два бита для порядкового номера (номер очереди)
        private uint uiAcknowledgementNumber = 555;   //Тридцать два бита для номера подтверждения
        private ushort usDataOffsetAndFlags = 555;      //Шестнадцать бит для флагов и данных смещения
        private ushort usWindow = 555;                  //Шестнадцать битов для размера окна
        private short sChecksum = 555;                 //Шестнадцать битов для контрольной суммы
                                                    //(может быть отрицательной short)
        private ushort usUrgentPointer;           //Шестнадцать бит для указателя срочности
        //End TCP header

        private byte   byHeaderLength;            //Длина заголовка
        private ushort usMessageLength;           //Длина данных
        private byte[] byTCPData = new byte[4096];//Данные, переносимые в пакете TCP
       
        public TCPHeader(byte [] byBuffer, int nReceived)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream(byBuffer, 0, nReceived);
                BinaryReader binaryReader = new BinaryReader(memoryStream);

                //Первые шестнадцать битов содержит порт источника
                usSourcePort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16 ());

                //Следующие шестнадцать содержать порт назначения
                usDestinationPort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16 ());

                //Следующие тридцать два имеют порядковый номер
                uiSequenceNumber = (uint)IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());

                //Следующие тридцать два имеют номер подтверждения
                uiAcknowledgementNumber = (uint)IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());

                //Следующие шестнадцать бит содержат флаги и данные смещения
                usDataOffsetAndFlags = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Следующие шестнадцать содержать размер окна
                usWindow = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //В ближайшие шестнадцать нас есть контрольная сумма
                sChecksum = (short)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Следующие шестнадцать содержать указатель срочности
                usUrgentPointer = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Данные смещения указывают, где начинаются данные, поэтому его использ. при вычисл. длины заголовка
                byHeaderLength = (byte)(usDataOffsetAndFlags >> 12);
                byHeaderLength *= 4;

                //Длина сообщения = Общая длина пакета TCP - размер заголовка
                usMessageLength = (ushort)(nReceived - byHeaderLength);

                //Скопир данные TCP в буфер данных
                Array.Copy(byBuffer, byHeaderLength, byTCPData, 0, nReceived - byHeaderLength);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MJsniff TCP" + (nReceived), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Порт отправителя
        /// </summary>
        public string SourcePort
        {
            get
            {
                return usSourcePort.ToString();
            }
        }

        /// <summary>
        /// Порт получателя
        /// </summary>
        public string DestinationPort
        {
            get
            {
                return usDestinationPort.ToString ();
            }
        }

        /// <summary>
        /// Номер очереди
        /// </summary>
        public string SequenceNumber
        {
            get
            {
                return uiSequenceNumber.ToString();
            }
        }

        /// <summary>
        /// Номер подтверждения
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
        /// Длина заголовка
        /// </summary>
        public string HeaderLength
        {
            get
            {
                return byHeaderLength.ToString();
            }
        }

        /// <summary>
        /// Размер окна
        /// </summary>
        public string WindowSize
        {
            get
            {
                return usWindow.ToString();
            }
        }

        /// <summary>
        /// Указатель срочности
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
        /// Флаги
        /// </summary>
        public string Flags
        {
            get
            {
                //последние шесть бит данных смещения и флаги содержат управляющие биты

                //Сначала мы извлечём флаги
                int nFlags = usDataOffsetAndFlags & 0x3F;
 
                string strFlags = string.Format ("0x{0:x2} (", nFlags);

                //Теперь мы начнём смотреть, установлены ли отдельные биты или нет
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
        /// Контрольная сумма
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
        /// Сообщение
        /// </summary>
        public byte[] Data
        {
            get
            {
                return byTCPData;
            }
        }

        /// <summary>
        /// Длина сообщения
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