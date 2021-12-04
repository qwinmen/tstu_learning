using System;
using System.Windows.Forms;
using DevComponents.AdvTree;

namespace sZip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private clCompress clCompress;

        /// <summary>
        /// Снять тексты и сжимать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OK_Click(object sender, EventArgs e)
        {
            if (radioButton_Сжать.Checked)
            {
                //Очистить содержимое в таблице AdvTree
                advTree1.ClearAndDisposeAllNodes();
                label2.Text = (textBox_IN.Text.Length * 8) + " bit";
                //передать текст
                clCompress = new clCompress(textBox_IN.Text);
                label1.Text = "Совпадений: " + clCompress.Repit;
                var index = 0;
                foreach (string s in clCompress.Dictonary)
                {
                    Node node = new Node((s == " " ? "㏚" : s));
                    node.Cells.Add(new Cell(index.ToString()));

                    advTree1.Nodes.Add(node);
                    index++;
                }
                textBox_OUT.Text = "";
                index = 0;
                foreach (int cod in clCompress.Cod)
                {
                    textBox_OUT.Text += cod + " ";
                    index++;
                }
                label3.Text = index + " bit";
            }
            else//иначе надо восстановить текст
            {
                advTree1.ClearAndDisposeAllNodes();
                //0 12 33 2 1 9 13
                clDecoder clDecoder = new clDecoder(textBox_IN.Text, sZip.clCompress.StartDicton);
                label2.Text = (textBox_IN.Text.Split(' ').Length - 1) + " bit";
                textBox_OUT.Text = "";
                var index = 0;
                var arr = textBox_IN.Text.Split(' ');
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    int dex = int.Parse(arr[i]);
                    textBox_OUT.Text += clDecoder.Decod[dex] + " ";
                    index += (clDecoder.Decod[dex].Length * 8);
                }

                label3.Text = index + " bit";

                index = 0;
                foreach (string s in clDecoder.Decod)
                {
                    Node node = new Node((s == " " ? "㏚" : s));
                    node.Cells.Add(new Cell(index.ToString()));

                    advTree1.Nodes.Add(node);
                    index++;
                }

            }
        }





    }
}
