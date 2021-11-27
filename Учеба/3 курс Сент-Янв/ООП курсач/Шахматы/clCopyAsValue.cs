using System.Collections.Generic;
using System.Windows.Forms;

namespace Шахматы
{
    /// <summary>
    /// При обычном копировании обьектов типо "кнопка--лист--лист" мы работаем с сылками на корень.
    /// Нам же нужно работать с независимыми значениями обьекта в его первом виде записи в лист.
    /// </summary>
    class clCopyAsValue
    {
        public readonly List<KeyValuePair<string, string>> ObjValue;

        public clCopyAsValue()
        {
            ObjValue = new List<KeyValuePair<string, string>>();
        }

        /// <summary>
        /// Добавить в лист обьект по значению
        /// </summary>
        internal void AddList(ButtonBase objLink)
        {
            if (objLink == null) return;

            ObjValue.Add(new KeyValuePair<string, string>(objLink.Name, objLink.Tag.ToString()));
        
        }

    }
}
