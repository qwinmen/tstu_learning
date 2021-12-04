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
 * 4 бита --> номер версии
 * 4 бита --> длина заголовка
 * 8 бит  --> тип сервиса
 * 16 бит --> общая длина
 * 16 бит --> идентификатор пакета
 * 3 бита --> флаги
 * 13 бит --> смещение фрагмента
 * 8 бит  --> время жизни
 * 8 бит  --> протокол верхнего уровня
 * 16 бит --> контрольная сумма
 * 32 бит --> ip-адрес источника
 * 32 бит --> ip-адрес назначения
 * --> параметры выравнивания (резерв) 
 
 */
namespace MJsniffer
{
    public class IPHeader
    {
        //Note: IP Header
        private byte      byVersionAndHeaderLength;   //Восемь бит для версии и длины заголовка
        private byte      byDifferentiatedServices;    //Восемь бит для дифференцированных услуг (TOS)
        private ushort    usTotalLength;              //Шестнадцать бит для общей длины дейтаграммы (заголовок + сообщения)
        private ushort    usIdentification;           //Шестнадцать бит для идентификации
        private ushort    usFlagsAndOffset;           //Восемь бит для флагов и фрагментации смещения
        private byte      byTTL;                      //Восемь бит для TTL (Time To Live)
        private byte      byProtocol;                 //Восемь битов для базового протокола
        private short     sChecksum;                  //Шестнадцать бит, содержащие контрольную сумму заголовка
                                                      //(сумма может быть отрицательной принято так, как short)
        private uint      uiSourceIPAddress;          //Тридцать два бита IP-адрес источника
        private uint      uiDestinationIPAddress;     //Тридцать два бита IP-адреса назначения
        //End IP Header
        
        private byte      byHeaderLength;             //Длина заголовка
        private byte[]    byIPData = new byte[4096];  //Данные, переносимые как дейтаграммы


        public IPHeader(byte[] byBuffer, int nReceived)
        {

            try
            {
                //Создать MemoryStream из принятых байт
                MemoryStream memoryStream = new MemoryStream(byBuffer, 0, nReceived);
                //Создать BinaryReader из MemoryStream
                BinaryReader binaryReader = new BinaryReader(memoryStream);

                //Первые восемь битов заголовка IP содержат версию и
                //длину заголовка, читаем их
                byVersionAndHeaderLength = binaryReader.ReadByte();

                //Следующие восемь битов содержат дифференцированные услуги
                byDifferentiatedServices = binaryReader.ReadByte();

                //Следующие восемь битов приводим общую длину дейтаграммы
                usTotalLength = (ushort) IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Следующие шестнадцать содержат байты идентификации
                usIdentification = (ushort) IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Следующие шестнадцать бит содержат флаги и фрагментац. смещение
                usFlagsAndOffset = (ushort) IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Следующие восемь битов имеют значение TTL
                byTTL = binaryReader.ReadByte();

                //Следующие восемь представляет протокол, инкапсулированный в дейтаграмму
                byProtocol = binaryReader.ReadByte();

                //Следующие шестнадцать бит содержат контрольную сумму заголовка
                sChecksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Следующие тридцать два бита имеют IP-адрес источника
                uiSourceIPAddress = (uint) (binaryReader.ReadInt32());

                //Следующие тридцать два содержат IP-адрес назначения
                uiDestinationIPAddress = (uint) (binaryReader.ReadInt32());

                //Note: Подсчет длины заголовка:

                byHeaderLength = byVersionAndHeaderLength;
                //Последние четыре бита версии и длина заголовка содержит в поле длина заголовка
                //проводим несколько простых двоичных арифметических операций в извлечь их
                byHeaderLength <<= 4;
                byHeaderLength >>= 4;
                //Умножьте на четыре, чтобы получить точную длину заголовка
                byHeaderLength *= 4;

                //Копирование данных, передаваемых датаграмой в другой массив
                //в соответствии с протоколом осуществляется в дейтаграммы IP
                Array.Copy(byBuffer,
                           byHeaderLength, //начать копирование с конца заголовка
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
        /// Номер версии протокола
        /// </summary>
        public string Version
        {
            get
            {
                //Посчитать IP версию
                //Четыре бита заголовка IP содержит IP версию
                if ((byVersionAndHeaderLength >> 4) == 4)
                    return "IP v4";
                else if ((byVersionAndHeaderLength >> 4) == 6)
                    return "IP v6";
                else
                    return "Unknown";
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
        /// Длина сообщения
        /// </summary>
        public ushort MessageLength
        {
            get
            {
                //MessageLength = (общ_длина_дейтаграммы) - (длина_заголовка)
                return (ushort)(usTotalLength - byHeaderLength);
            }
        }

        /// <summary>
        /// Дифференциал сервис
        /// </summary>
        public string DifferentiatedServices
        {
            get
            {
                //Возвращает дифференцированные услуги в шестнадцатеричном формате
                return string.Format ("0x{0:x2} ({1})", byDifferentiatedServices, byDifferentiatedServices);
            }
        }

        /// <summary>
        /// Флаги
        /// </summary>
        public string Flags
        {
            get
            {
                //Первые три бита флагов и фрагментации области
                //(которые указывают, является ли данные фрагментирован или нет)
                int nFlags = usFlagsAndOffset >> 13;
                if (nFlags == 2)
                    return "Без фрагментации";
                else if (nFlags == 1)
                    return "More fragments to come";
                else
                    return nFlags.ToString();
            }
        }

        /// <summary>
        /// Фрагментац смещение
        /// </summary>
        public string FragmentationOffset
        {
            get
            {
                //Последние тринадцать бит флаги и фрагментац поля содержат фрагментации смещения
                int nOffset = usFlagsAndOffset << 3;
                nOffset >>= 3;

                return nOffset.ToString();
            }
        }

        /// <summary>
        /// Время задержки
        /// </summary>
        public string TTL
        {
            get
            {
                return byTTL.ToString();
            }
        }

        /// <summary>
        /// Тип протокола
        /// </summary>
        public Protocol ProtocolType
        {
            get
            {
                //Поле протокола представляет собой протокол в части данных дейтаграммы
                if (byProtocol == 6)        //Значение шесть представляет протокол TCP
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
        /// Контрольная сумма
        /// </summary>
        public string Checksum
        {
            get
            {
                //Вернуть контрольн сумму в 16f формате
                return string.Format ("0x{0:x2}", sChecksum);
            }
        }

        /// <summary>
        /// Адрес отправителя/источника
        /// </summary>
        public IPAddress SourceAddress
        {
            get
            {
                return new IPAddress(uiSourceIPAddress);
            }
        }

        /// <summary>
        /// Адрес приемника/получателя
        /// </summary>
        public IPAddress DestinationAddress
        {
            get
            {
                return new IPAddress(uiDestinationIPAddress);
            }
        }

        /// <summary>
        /// Общая длина (заголовок+сообщение)
        /// </summary>
        public string TotalLength
        {
            get
            {
                return usTotalLength.ToString();
            }
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public string Identification
        {
            get
            {
                return usIdentification.ToString();
            }
        }

        /// <summary>
        /// Данные, переносимые как дейтаграммы
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
