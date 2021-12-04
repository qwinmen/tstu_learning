using System;
using System.Runtime.InteropServices;
using System.Text;

//Описание WSASocket:
//https://msdn.microsoft.com/en-us/library/ms742212%28VS.85%29.aspx
//Номера протоколов:
//http://en.wikipedia.org/wiki/List_of_IP_protocol_numbers
namespace Sniffer5
{

    class clSniff
    {


        [DllImport("Kernel32.dll", EntryPoint = "RtlZeroMemory", SetLastError = false)]
        public static extern void ZeroMemory(IntPtr dest, IntPtr size);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern int gethostname(StringBuilder name, int length);


        /// <summary>
        /// Функция WSASocket создает сокет, связанный с конкретным поставщиком транспортных услуг.
        /// </summary>
        /// <param name="af">Семейство адресов спецификации</param>
        /// <param name="socket_type">Тип создаваемого сокета</param>
        /// <param name="protocol">Протокол, который будет использоваться</param>
        /// <param name="lpProtocolInfo">Указатель на WSAPROTOCOL_INFO структуру</param>
        /// <param name="group">0</param>
        /// <param name="dwFlags">Набор флагов используется для задания дополнительных атрибутов сокета.</param>
        /// <returns>Возвращает дескриптор, ссылающийся на новый сокет. В противном случае, возвращается значение INVALID_SOCKET,
        /// а специфический код ошибки может быть получен путем вызова WSAGetLastError.</returns>
        [DllImport("ws2_32.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr WSASocket(ADDRESS_FAMILIES af, SOCKET_TYPE socket_type, PROTOCOL protocol,
                                              IntPtr lpProtocolInfo, Int32 group, OPTION_FLAGS_PER_SOCKET dwFlags);

        /// <summary>
        /// Спецификация семейства адресов
        /// </summary>
        public enum ADDRESS_FAMILIES : short
        {
            /// <summary>
            /// Семейство адресов не определен.
            /// </summary>
            AF_UNSPEC = 0,
            /// <summary>
            /// Local to host (pipes, portals) [value = 1].
            /// </summary>
            AF_UNIX = 1,
            /// <summary>
            /// Internetwork: UDP, TCP, etc Интернет-протокол версии 4 (IPv4)
            /// </summary>
            AF_INET = 2,
            /// <summary>
            /// Arpanet imp addresses [value = 3].
            /// </summary>
            AF_IMPLINK = 3,
            /// <summary>
            /// Pup protocols: e.g. BSP [value = 4].
            /// </summary>
            AF_PUP = 4,
            /// <summary>
            /// Mit CHAOS protocols [value = 5].
            /// </summary>
            AF_CHAOS = 5,
            /// <summary>
            /// XEROX NS protocols [value = 6].
            /// Семейство адресов IPX / SPX. 
            /// Это семейство адресов поддерживается только если установлен протокол совместимый транспортный протокол NWLink IPX / SPX NetBIOS.
            ///Это семейство адресов не поддерживается на Windows Vista и более поздних версий.
            /// </summary>
            AF_NS = 6,
            /// <summary>
            /// IPX protocols: IPX, SPX, etc [value = 6].
            /// </summary>
            AF_IPX = 6,
            /// <summary>
            /// ISO protocols [value = 7].
            /// </summary>
            AF_ISO = 7,
            /// <summary>
            /// OSI is ISO [value = 7].
            /// </summary>
            AF_OSI = 7,
            /// <summary>
            /// european computer manufacturers [value = 8].
            /// </summary>
            AF_ECMA = 8,
            /// <summary>
            /// datakit protocols [value = 9].
            /// </summary>
            AF_DATAKIT = 9,
            /// <summary>
            /// CCITT protocols, X.25 etc [value = 10].
            /// </summary>
            AF_CCITT = 10,
            /// <summary>
            /// IBM SNA [value = 11].
            /// </summary>
            AF_SNA = 11,
            /// <summary>
            /// DECnet [value = 12].
            /// </summary>
            AF_DECnet = 12,
            /// <summary>
            /// Direct data link interface [value = 13].
            /// </summary>
            AF_DLI = 13,
            /// <summary>
            /// LAT [value = 14].
            /// </summary>
            AF_LAT = 14,
            /// <summary>
            /// NSC Hyperchannel [value = 15].
            /// </summary>
            AF_HYLINK = 15,
            /// <summary>
            /// AppleTalk [value = 16].
            /// Это семейство адресов не поддерживается на Windows Vista и более поздних версий.
            /// </summary>
            AF_APPLETALK = 16,
            /// <summary>
            /// NetBios-style addresses [value = 17].
            /// Поставщик Windows Sockets для NetBIOS поддерживается на 32-разрядных версиях Windows. 
            /// Этот провайдер по умолчанию устанавливается на 32-битных версиях Windows.
            /// </summary>
            AF_NETBIOS = 17,
            /// <summary>
            /// VoiceView [value = 18].
            /// </summary>
            AF_VOICEVIEW = 18,
            /// <summary>
            /// Protocols from Firefox [value = 19].
            /// </summary>
            AF_FIREFOX = 19,
            /// <summary>
            /// Somebody is using this! [value = 20].
            /// </summary>
            AF_UNKNOWN1 = 20,
            /// <summary>
            /// Banyan [value = 21].
            /// </summary>
            AF_BAN = 21,
            /// <summary>
            /// Native ATM Services [value = 22].
            /// </summary>
            AF_ATM = 22,
            /// <summary>
            /// Интернет-протокол версии 6 (IPv6)
            /// </summary>
            AF_INET6 = 23,
            /// <summary>
            /// Microsoft Wolfpack [value = 24].
            /// </summary>
            AF_CLUSTER = 24,
            /// <summary>
            /// IEEE 1284.4 WG AF [value = 25].
            /// </summary>
            AF_12844 = 25,
            /// <summary>
            /// IrDA [value = 26].
            /// Ассоциация инфракрасной передачи данных (IrDA)
            /// Это семейство адресов поддерживается только если компьютер имеет инфракрасный порт и установлен драйвер.
            /// </summary>
            AF_IRDA = 26,
            /// <summary>
            /// Network Designers OSI &amp; gateway enabled protocols [value = 28].
            /// </summary>
            AF_NETDES = 28,
            /// <summary>
            /// [value = 29].
            /// </summary>
            AF_TCNPROCESS = 29,
            /// <summary>
            /// [value = 30].
            /// </summary>
            AF_TCNMESSAGE = 30,
            /// <summary>
            /// [value = 31].
            /// </summary>
            AF_ICLFXBM = 31,
            /// <summary>
            /// Семейство адресов Bluetooth.
            /// </summary>
            AF_BTH = 32
        }

        /// <summary>
        /// Спецификация типа для нового сокета.
        /// </summary>
        public enum SOCKET_TYPE : short
        {
            /// <summary>
            /// Тип сокета, что обеспечивает последовательную, надежную, двусторонний, байт соединение на основе
            /// потоков с механизмом передачи данных OOB.
            ///  Этот тип сокета использует протокол управления передачей (TCP) для семейства адресов Интернет (AF_INET или AF_INET6).
            /// </summary>
            SOCK_STREAM = 1,

            /// <summary>
            /// Тип сокета, который поддерживает датаграммы, которые не имеют соединения,
            /// ненадежные буферы фиксированной (обычно небольшой) максимальной длины. 
            /// Этот тип сокета использует протокол User Datagram Protocol (UDP) для семейства адресов в Интернет (AF_INET или AF_INET6).
            /// </summary>
            SOCK_DGRAM = 2,

            /// <summary>
            /// Тип сокета, который обеспечивает новый сокет, который позволяет приложению манипулировать заголовком протокола верхнего уровня. 
            /// Для управления IPv4 заголовок, IP_HDRINCL опции сокета должены быть установлены на сокете. 
            /// Чтобы управлять заголовок IPv6, IPV6_HDRINCL опции сокета должены быть установлены на сокете.
            /// </summary>
            SOCK_RAW = 3,

            /// <summary>
            /// Тип сокета, что обеспечивает надежное сообщение дейтаграмму. Примером такого типа является Pragmatic General Multicast (PGM) 
            /// реализация протокола многоадресной в Windows, часто упоминается как надежного многоадресного программирования .
            /// </summary>
            SOCK_RDM = 4,

            /// <summary>
            /// Обеспечивает псевдо-поток пакетов, основываясь на дейтаграмм.
            /// </summary>
            SOCK_SEQPACKET = 5
        }

        /// <summary>
        /// Протокол, который будет использоваться.
        /// </summary>
        public enum PROTOCOL : short
        {//dummy for IP  
            IPPROTO_IP = 0,
            //control message protocol  
            IPPROTO_ICMP = 1,
            //internet group management protocol  
            IPPROTO_IGMP = 2,
            //gateway^2 (deprecated)  
            IPPROTO_GGP = 3,
            //tcp  
            IPPROTO_TCP = 6,
            //pup  
            IPPROTO_PUP = 12,
            //user datagram protocol  
            IPPROTO_UDP = 17,
            //xns idp  
            IPPROTO_IDP = 22,
            //IPv6  
            IPPROTO_IPV6 = 41,
            //UNOFFICIAL net disk proto  
            IPPROTO_ND = 77,

            IPPROTO_ICLFXBM = 78,
            //raw IP packet  
            IPPROTO_RAW = 255,

            IPPROTO_MAX = 256
        }

        /// <summary>
        /// Набор флагов используется для задания дополнительных атрибутов сокета.
        /// </summary>
        public enum OPTION_FLAGS_PER_SOCKET : short
        {
            // turn on debugging info recording  
            SO_DEBUG = 0x0001,
            // socket has had listen()  
            SO_ACCEPTCONN = 0x0002,
            // allow local address reuse  
            SO_REUSEADDR = 0x0004,
            // keep connections alive  
            SO_KEEPALIVE = 0x0008,
            // just use interface addresses  
            SO_DONTROUTE = 0x0010,
            // permit sending of broadcast msgs  
            SO_BROADCAST = 0x0020,
            // bypass hardware when possible  
            SO_USELOOPBACK = 0x0040,
            // linger on close if data present  
            SO_LINGER = 0x0080,
            // leave received OOB data in line  
            SO_OOBINLINE = 0x0100,
            SO_DONTLINGER = (int)(~SO_LINGER),
            // disallow local address reuse
            SO_EXCLUSIVEADDRUSE = ((int)(~SO_REUSEADDR)),

            ///*
            // * Additional options.
            // */
            // send buffer size  
            SO_SNDBUF = 0x1001,
            // receive buffer size  
            SO_RCVBUF = 0x1002,
            // send low-water mark  
            SO_SNDLOWAT = 0x1003,
            // receive low-water mark  
            SO_RCVLOWAT = 0x1004,
            // send timeout  
            SO_SNDTIMEO = 0x1005,
            // receive timeout  
            SO_RCVTIMEO = 0x1006,
            // get error status and clear  
            SO_ERROR = 0x1007,
            // get socket type  
            SO_TYPE = 0x1008,

            ///*
            // * WinSock 2 extension -- new options
            // */
            // ID of a socket group  
            SO_GROUP_ID = 0x2001,
            // the relative priority within a group
            SO_GROUP_PRIORITY = 0x2002,
            // maximum message size  
            SO_MAX_MSG_SIZE = 0x2003,
            // WSAPROTOCOL_INFOA structure  
            SO_PROTOCOL_INFOA = 0x2004,
            // WSAPROTOCOL_INFOW structure  
            SO_PROTOCOL_INFOW = 0x2005,
            // configuration info for service provider  
            PVD_CONFIG = 0x3001,
            // enable true conditional accept: connection is not ack-ed to the other side until conditional function returns CF_ACCEPT  
            SO_CONDITIONAL_ACCEPT = 0x3002
        }


    }

}
