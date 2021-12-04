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
        private ushort usSourcePort;            //номер порта отправителя 16 bit
        private ushort usDestinationPort;       //номер порта получателя 16 bit
        private ushort usLength;                //длина датаграммы
        private short sChecksum;                //контрольная сумма 16 bit
                                                //(checksum can be negative so taken as short)
        //End UDP header

        private byte[] byUDPData = new byte[4096];  //Данные, переносимые в пакете UDP

        public UDPHeader(byte [] byBuffer, int nReceived)
        {
            MemoryStream memoryStream = new MemoryStream(byBuffer, 0, nReceived);
            BinaryReader binaryReader = new BinaryReader(memoryStream);

            //Первые шестнадцать битов содержит порт источника
            usSourcePort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //Следующие шестнадцать бит содержат порт назначения
            usDestinationPort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //Следующие шестнадцать бит содержат длину пакета UDP
            usLength = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //Следующие шестнадцать бит содержат контрольную сумму
            sChecksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //Копирование данных, передаваемых по UDP пакета в буфере данных
            Array.Copy(byBuffer,
                       8,               //UDP заголовок из 8 байт, поэтому мы начать копирование после него
                       byUDPData, 
                       0, 
                       nReceived - 8);
        }

        /// <summary>
        /// номер порта отправителя 
        /// </summary>
        public string SourcePort
        {
            get
            {
                return usSourcePort.ToString();
            }
        }

        /// <summary>
        /// номер порта получателя
        /// </summary>
        public string DestinationPort
        {
            get
            {
                return usDestinationPort.ToString();
            }
        }

        /// <summary>
        /// Длина датаграммы
        /// </summary>
        public string Length
        {
            get
            {
                return usLength.ToString ();
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
                return byUDPData;
            }
        }
    }
}