using System.IO;
using System.Net;

//http://book.itep.ru/4/44/igmp_449.htm
/*
 * 4 бит  --> версия
 * 4 бит  --> тип
 * 16 бит --> не используется
 * 16 бит --> контрольная сумма
 * 32 бит --> групповой адрес класса D (нуль при запросе)
 */
namespace MJSniff
{
    class IGMPHeader
    {
        private byte byVersionAndType;      //Восемь бит для версии и типа
        private ushort usZeroTotal;         //Шестнадцать бит не используется
        private short sChecksum;               //Шестнадцать бит контрольной суммы
        private uint uiSourceIPAddress;     //Тридцать два бита IP-адрес класса Д

        private byte[] byIGMPData = new byte[4096];     //Данные, переносимые в пакете
        private byte byType;                    //4 bit

        /// <summary>
        /// Разбор пакета
        /// </summary>
        public IGMPHeader(byte [] byBuffer, int nReceived)
        {
            MemoryStream memoryStream = new MemoryStream(byBuffer, 0, nReceived);
            BinaryReader binaryReader = new BinaryReader(memoryStream);

            //Первые восемь битов содержат версию и
            //тип заголовка, читаем их
            byVersionAndType = binaryReader.ReadByte();

            byType = byVersionAndType;
            byType <<= 4;
            byType >>= 4;
            byType *= 4;
            //16 bit не используется
            usZeroTotal = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            //Следующие шестнадцать бит содержат контрольную сумму
            sChecksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            //Следующие тридцать два бита имеют IP-адрес группы
            uiSourceIPAddress = (uint)(binaryReader.ReadInt32());

        }

        /// <summary>
        /// Oпределяет используемую версию протокола
        /// </summary>
        public string Version
        {
            get
            {
                //Посчитать версию//Четыре бита
                return "v" + (byVersionAndType >> 4);
            }
        }

        /// <summary>
        /// Тип:
        /// тип=1 говорит о том, что это запрос, отправленный мультикастинг-маршрутизатором;
        /// тип=2 указывает, что этот отклик послан ЭВМ.
        /// </summary>
        public string Type
        {
            get
            {
                return byType.ToString();
            }
        }

        /// <summary>
        /// Не используется
        /// </summary>
        public string ZeroSpase
        {
            get { return usZeroTotal.ToString(); }
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
        /// Груповой адрес
        /// </summary>
        public IPAddress SourceAddress
        {
            get
            {
                return new IPAddress(uiSourceIPAddress);
            }
        }

        /// <summary>
        /// Сообщение
        /// </summary>
        public byte[] Data
        {
            get
            {
                return byIGMPData;
            }
        }



    }
}
