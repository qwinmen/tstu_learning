using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapTech
{
    /// <summary>
    /// Типо подсоединяемся к базе и запрашиваем от туда нормативные документы
    /// </summary>
    public partial class fОхранаТруда : Form
    {
        public fОхранаТруда()
        {
            InitializeComponent();
            _chekedDoc = new List<string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length < 3) return;
            AddToList(textBox1.Text);
        }

        void AddToList(string str)
        {
            checkedListBox1.Items.Add(str);
        }

        internal List<string> _chekedDoc;

        private void fОхранаТруда_FormClosed(object sender, FormClosedEventArgs e)
        {
            _chekedDoc.Clear();

            var chekd = checkedListBox1.CheckedItems;
            foreach (var VARIABLE in chekd)
                _chekedDoc.Add(VARIABLE+"; ");
        }

    }
}
