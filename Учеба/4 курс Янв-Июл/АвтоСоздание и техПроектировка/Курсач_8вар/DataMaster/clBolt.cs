using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace DataMaster
{
    class clBolt
    {
        
        public clBolt()
        {
        }

        public List<double> GetD()
        {
            return _diammetr;
        }

        private static List<double> _diammetr = new List<double>();

        /// <summary>
        /// Загрузить картинки из папки dir
        /// </summary>
        /// <param name="listViewEx1"></param>
        /// <param name="imageList1"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public ListViewEx GetListViewEx(ListViewEx listViewEx1, ImageList imageList1, string dir)
        {
            listViewEx1.BeginUpdate();
            listViewEx1.Items.Clear();
            var files = Directory.GetFiles(dir);
            foreach (var file in files)
            {
                var str = (file.Replace(dir + "\\", "")).Replace(".png", "").Replace(".jpg", "");
                listViewEx1.Items.Add(str, 0);
                try
                {
                    if (dir == "Болванка")
                        clZagotovka.Add(double.Parse(str.Replace("D", "")));
                    else _diammetr.Add(double.Parse(str.Replace("m", "")));
                }
                catch (Exception)
                {
                    if (dir == "Болванка")
                        clZagotovka.Add(10);
                    else _diammetr.Add(10);
                }
                
                Bitmap res = new Bitmap(file);
                imageList1.Images.Add(res);
            }
            listViewEx1.LargeImageList = imageList1;
            for (int i = 0; i < listViewEx1.Items.Count; i++)
            {
                listViewEx1.Items[i].ImageIndex = i;
            }
            listViewEx1.EndUpdate();

            return listViewEx1;
        }

        

    }
}
