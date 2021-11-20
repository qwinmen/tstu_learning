using System;
using SHDocVw;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        public void setMsg(string s)
        {
            this.msgLbl.Text = s;
        }


        /// <SUMMARY>
        /// Creates a COM object given it's ProgID.
        /// </SUMMARY>
        /// <PARAM name="sProgID">The ProgID to create</PARAM>
        /// <RETURNS>The newly created object, or null on failure.</RETURNS>
        public  object COMCreateObject(string sProgID)
        {
            // We get the type using just the ProgID
            Type oType = Type.GetTypeFromProgID(sProgID);
            if (oType != null)
            {
                return Activator.CreateInstance(oType);
            }

            return null;
        }

        /// <summary>
        /// Opens a new Internet Explorer window and navigates it to the URL.
        /// This code is for demonstration purposes only.
        /// From http://www.novicksoftware.com/TipsAndTricks/tip-csharp-open-ie-browser.htm
        /// </summary>
        /// <param name="sURL">URL to navigate to.</param>
        /// <returns>true all the time.</returns>        
        public  bool IEOpenOnURL(string sURL)
        {
        
            InternetExplorer oIE = (InternetExplorer)COMCreateObject
                                                              ("InternetExplorer.Application");
            if (oIE != null)
            {
                object oEmpty = String.Empty;
                object oURL = sURL;
                oIE.Visible = true;
                oIE.Navigate2(ref oURL, ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
            }
            return true;
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IEOpenOnURL(linkLabel1.Text);
        }

        private void axWebBrowser1_Enter(object sender, EventArgs e)
        {

        }
    }
}