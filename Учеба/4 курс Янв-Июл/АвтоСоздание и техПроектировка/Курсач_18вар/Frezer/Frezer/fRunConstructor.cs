using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Frezer
{
    public partial class fRunConstructor : Form
    {
        public fRunConstructor()
        {
            InitializeComponent();
        }

        private static bool flag = true;

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if(flag)
            {
                flag = !flag;
                return;
            }

            var control = sender as RadioButton;
            if (control == null) return;

            switch (control.Text)
            {
                case "AutoCAD":
                    StartConstructor(control.Text);
                    break;
                case "Compas":
                    StartConstructor(control.Text);
                    break;
                case "ProgeCAD":
                    StartConstructor(control.Text);
                    break;
            }

        }

        /// <summary>
        /// если инф-ии нет, то из оболочки запускается любой конструктор необходимых работ
        /// </summary>
        private void StartConstructor(string name)
        {
            try
            {
                switch (name)
                {
                    case "AutoCAD":
                        System.Diagnostics.Process.Start(@"C:\Program Files\ProgeCAD\progeCAD 2011 Professional RUS\icad.exe");
                        break;
                    case "ProgeCAD":
                        System.Diagnostics.Process.Start(@"C:\Program Files\ProgeCAD\progeCAD 2011 Professional RUS\icad.exe");
                        break;
                    case "Compas":
                        System.Diagnostics.Process.Start(@"D:\+ Downloads\+ Torrents\КОМПАС-3D V15.2.16 x32 Portable (mini)\KOMPAS-3D V15\Bin\KOMPAS.Exe");
                        break;
                    default:
                        break;
                }
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(@"Отсутствует выбранный конструктор.", @"Ошибка при запуске конструктора.", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
