using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
//http://www.rfc-editor.org/pdfrfc/rfc792.txt.pdf
//http://book.itep.ru/4/44/icmp_444.htm
/*
 Заголовок ICMP-сообщения начинается с трех стандартных полей фиксированный длины:
 * тип сообщения, 
 * код сообщения и 
 * контрольная сумма.
 * Значение поля типа определяет формат остальной части сообщения и его назначение.
 */
namespace MJSniff
{
    class ICMPHeader
    {
        //NOTE: ICMP header
        private ushort usType;            //тип пакета 8 бит
        private ushort usCode;       //код пакета (15 значений) 8 бит
        private short sChecksum;                //контрольная сумма 16 bit
        private ushort usOrigTimestamp;                //дополнительные поля
        private ushort usRecvTimestamp;                //уточнающие тип
        private ushort usTrnsTimestamp;                //icmp пакета
        //(checksum can be negative so taken as short)
        
        private byte[] byICMPData = new byte[4096];  //Данные, переносимые в пакете

        /// <summary>
        /// Разбор пакета
        /// </summary>
        public ICMPHeader(byte [] byBuffer, int nReceived)
        {
            MemoryStream memoryStream = new MemoryStream(byBuffer, 0, nReceived);
            BinaryReader binaryReader = new BinaryReader(memoryStream);

            //8 бит на тип пакета
            usType = binaryReader.ReadByte();
            //8 бит на код
            usCode = binaryReader.ReadByte();
            //Следующие шестнадцать бит содержат контрольную сумму
            sChecksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //Note: если Cod = 8||0 && Type = 0 то это Формат эхо-запроса и отклика ICMP
            switch (this.Code)
            {
                case "0":
                case "8":
                    switch (this.Type)
                    {
                        case "0":
                            //идентификатор 16 bit
                            usOrigTimestamp = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                            //номер по порядку 16 bit
                            usRecvTimestamp = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                            //Следующие тридцать два бита имеют данные
                            usTrnsTimestamp = (ushort)(binaryReader.ReadInt32());
                            break;
                    }
                    break;
            }
            


            //Копирование данных, передаваемых по ICMP пакета в буфере данных
            Array.Copy(byBuffer,
                       8,               //заголовок из 8 байт, поэтому мы начать копирование после него
                       byICMPData,
                       0,
                       nReceived - 8);

        }

        /// <summary>
        /// Тип
        /// </summary>
        public string Type
        {
            get
            {
                return usType.ToString();
            }
        }

        /// <summary>
        /// Kod
        /// </summary>
        public string Code
        {
            get
            {
                return usCode.ToString();
            }
        }

        /// <summary>
        /// Временая отметка
        /// </summary>
        public string OriginTimestamp
        {
            get
            {
                return usOrigTimestamp.ToString ();
            }
        }

        /// <summary>
        /// Отметка
        /// </summary>
        public string RecvTimestamp
        {
            get
            {
                return usRecvTimestamp.ToString();
            }
        }

        /// <summary>
        /// Отметка
        /// </summary>
        public string TrnsTimestamp
        {
            get
            {
                return usTrnsTimestamp.ToString();
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
                return byICMPData;
            }
        }


    }
}
