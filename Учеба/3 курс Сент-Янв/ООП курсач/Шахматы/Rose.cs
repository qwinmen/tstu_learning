using System;
using System.Xml;

namespace Шахматы
{
    class Rose
    {
        
        /// <summary>
        /// Храним полученные keysControl из xml
        /// </summary>
            public Rose(string name, int index, string value)
            {
                this.Name = name;
                this.Index = index;
                this.Value = value;
            }

            public string Name { get; set; }
            public int Index { get; set; }
            public string Value { get; set; }

            public void LoadFromFile(XmlTextReader xmlIn)
            {
                try
                {
                    Name = xmlIn.GetAttribute("Name");
                    Index = Convert.ToInt32(xmlIn.GetAttribute("Index"));
                    Value = xmlIn.GetAttribute("Value");
                }
                catch { throw new ArgumentException("Ошибка сохранения атрибутов при чтении xml"); }
            }

            public void SaveToFile(XmlTextWriter xmlOut, string startAtrib)
            {
                try
                {
                    xmlOut.WriteStartElement(startAtrib);
                    xmlOut.WriteAttributeString("Name", Name);
                    xmlOut.WriteAttributeString("Index", Index.ToString());
                    xmlOut.WriteAttributeString("Value", Value.ToString());
                    xmlOut.WriteEndElement();
                }
                catch (Exception)
                {
                    throw new Exception("Запись в файл прервана");
                }
                
            }
        
    }
}
