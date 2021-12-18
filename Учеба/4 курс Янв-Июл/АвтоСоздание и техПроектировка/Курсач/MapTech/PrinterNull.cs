using System;
using System.Reflection;
using System.Windows.Forms;

namespace Expromt
{
    partial class PrinterNull : Form
    {
        public PrinterNull()
        {
            InitializeComponent();
            this.Text = "Подготовка документа к печати";
            
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private int i = 0;
        Timer timer = new Timer();
        Random rnd = new Random();

        private void PrinterNull_Load(object sender, EventArgs e)
        {
            timer.Interval = rnd.Next(100, 200);
            timer.Enabled = true;
            timer.Tick += new EventHandler(Interv);
            timer.Start();
        }

        private int _sum;

        private void Interv(object sender, EventArgs eventArgs)
        {
            circularProgress1.Value = i;
            i++;_sum++;
            if (i > 100) i = 0;
            label1.Text = label1.Text.Substring(label1.Text.Length - 5) == "....."
                               ? label1.Text.Substring(0, label1.Text.Length - 5)
                               : label1.Text;
            label1.Text += ".";
            if(_sum == 100)
            {
                _sum = 0;
                label2.Text = @"System32.printerhost.exe' (Managed): Loaded 'C:\Windows\assembly\GAC_MSIL\Accessibility\2.0.0.0__b03f5f7f11d50a3a\Accessibility.dll', Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
The thread 0x7ac has exited with code 0 (0x0).
The thread 0x6bc has exited with code 0 (0x0).
The program '[10100] Expromt.printerhost.exe: Managed' has exited with code 0 (0x0).";
                label2.Visible = !label2.Visible;
                label3.Visible = !label3.Visible;
                timer.Stop();
            }
        }

        private void PrinterNull_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }

    }
}
