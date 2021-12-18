using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace DataMaster
{
    class clZagotovka:clBolt
    {
        public clZagotovka()
        {
            
        }

        public static void Add(double item)
        {
            _diammetr.Add(item);
            
        }

        public List<double> GetD()
        {
            return _diammetr;
        }

        private static List<double> _diammetr = new List<double>();
    }
}
