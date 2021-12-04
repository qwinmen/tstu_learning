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
        private ushort usIdentification;        //Шестнадцать бит для идентификации
        private ushort usFlags;                 //Шестнадцать бит для DNS флагов
        private ushort usTotalQuestions;        //Шестнадцать битов, указывающих количество записей в списке вопросов
        private ushort usTotalAnswerRRs;        //Шестнадцать битов, указывающих количество записей в ответ записи ресурса списке
                                                //
        private ushort usTotalAuthorityRRs;     //Шестнадцать битов, указывающих количество записей
                                                //в записи ресурса списке
        private ushort usTotalAdditionalRRs;    //Шестнадцать битов, указывающих количество записей 
                                                //дополнительных ресурсов в списке записей
        //End DNS header fields

        public DNSHeader(byte []byBuffer, int nReceived)
        {
            MemoryStream memoryStream = new MemoryStream(byBuffer, 0, nReceived);
            BinaryReader binaryReader = new BinaryReader(memoryStream);

            //Первые шестнадцать бит для идентификации
            usIdentification = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //Следующие шестнадцать содержать флаги
            usFlags = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //Прочитать все номера вопросов в списке вопросов
            usTotalQuestions = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //Прочитать общее количество ответов в списке ответов
            usTotalAnswerRRs = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //Прочитать общее количество записей в списке полномочий
            usTotalAuthorityRRs = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            //Общее количество записей в дополнительный ресурс списка записей
            usTotalAdditionalRRs = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public string Identification
        {
            get
            {
                return string.Format("0x{0:x2}", usIdentification);
            }
        }

        /// <summary>
        /// Флаги
        /// </summary>
        public string Flags
        {
            get
            {
                return string.Format("0x{0:x2}", usFlags);
            }
        }

        /// <summary>
        /// Количество запросов
        /// </summary>
        public string TotalQuestions
        {
            get
            {
                return usTotalQuestions.ToString();
            }
        }

        /// <summary>
        /// Количество ответов
        /// </summary>
        public string TotalAnswerRRs
        {
            get
            {
                return usTotalAnswerRRs.ToString();
            }
        }

        /// <summary>
        /// Всего Authority
        /// </summary>
        public string TotalAuthorityRRs
        {
            get
            {
                return usTotalAuthorityRRs.ToString();
            }
        }

        /// <summary>
        /// Всего дополнительно
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
