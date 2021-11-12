using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FDelit
{
    public partial class Form1 : Form
    {
        private readonly List<string> _reservedWords = new List<string>();

        public Form1()
        {
            InitializeComponent();
            _reservedWords.Add("begin");
            _reservedWords.Add("end");



            //richTextBox1.Text = "в лесу родилась елочка";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
/*
            //Построй соотношение слов с цветом, которым хочешь их выделить. Выделять будем все слова независимо от регистра
            KeyValuePair<Regex, Color>[] PAIRS = new KeyValuePair<Regex, Color>[]
            {
                new KeyValuePair<Regex, Color>(new Regex("For|Next|If|Then", RegexOptions.IgnoreCase), Color.Red),
                new KeyValuePair<Regex, Color>(new Regex("My|Life|Tree|Count", RegexOptions.IgnoreCase), Color.Green),
                new KeyValuePair<Regex, Color>(new Regex("Привет|Как|Дела", RegexOptions.IgnoreCase), Color.Blue)
                
            };
            //При вводе в richtextbox проверь каждый из наборов на совпадение
            foreach (var element in PAIRS)
                ColourText(richTextBox1, element.Key, element.Value);
*/
        }
        int ind = 0;
        private void ColourText(RichTextBox rtb, Regex regEx, Color col)
        {
            int del = rtb.Text.Length;
            foreach (Match match in regEx.Matches(rtb.Text))
            {
                if (match.Index - 1 > 0)
                ind = match.Index - 1;

                if (rtb.Text[ind] == ' ')
                {
                    rtb.Select(match.Index, match.Length);
                    rtb.SelectionColor = col;
                    rtb.DeselectAll();
                    
                }

            }
            rtb.SelectionStart = del;//rtb.TextLength;
            rtb.SelectionColor = Color.Black;
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ' ') return;
            var searchWord = "";
            var startIndex = 0;
            for (var i = richTextBox1.SelectionStart - 1; i >= 0; i--)
            {
                var ch = richTextBox1.Text[i];
                if (ch == ' ' || ch == Convert.ToChar("\n") || ch == Convert.ToChar("\r")) break;
                searchWord = ch + searchWord;
                startIndex = i;
            }
            if (_reservedWords.IndexOf(searchWord) == -1) return;
            richTextBox1.SelectionStart = startIndex;
            richTextBox1.SelectionLength = searchWord.Length;
            richTextBox1.SelectionColor = Color.Blue;
            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Bold);
            richTextBox1.SelectionStart += richTextBox1.SelectionLength;
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            

        }
    }
}
