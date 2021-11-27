using System;
using System.IO;
//Доступ к медиа файлам
namespace Vika
{
    class clDictonary
    {
        public clDictonary()
        {}
        
        
        #region interface
        
        /// <summary>
        /// Указать имя файла, вернуть полный путь до файла.
        /// Вернуть picBox_Img.Image = Image.FromFile(dict.Image(_index));
        /// </summary>
        public string Image(string pictureName)
        {
            DirectoryInfo di = new DirectoryInfo("res\\pictures\\");//res\pictures\
            FileInfo[] info = di.GetFiles("*.gif", SearchOption.TopDirectoryOnly);
            string img = "";
            foreach (FileInfo fileInfo in info)
            {

                string fileName = fileInfo.FullName;            //filename.txt
                
                string name = fileInfo.Name.Replace(".gif", "");//filename

                if (name.Equals(pictureName, StringComparison.CurrentCultureIgnoreCase))
                {
                    img = (@"res\pictures\") + name + ".gif";
                    break;
                }
            }

            return img.Length == 0 ? null : img;
        }

        #endregion

       
    }
}
