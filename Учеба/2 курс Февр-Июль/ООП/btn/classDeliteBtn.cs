using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*����-1 �� ���
�������: �������� ���� �����, ������� ����������� �� ������ ��������
�������� ���� ��� �������� � ���� �����. ������� ������ ������ ������
� ������� �� ����� �� ��� ����������, ��� ��� ������������� �������-������������*/
namespace NewProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
    public sealed class RainbowButton : Button // ����������� �� ������ ������
    {
        private Random rand;
        public byte r, g, b, a;
        public int numberOfClicks;
        public RainbowButton() // ����������� ������
        {
            rand = new Random(); // �������������� ������������
            //this.ForeColor = Color.FromArgb(rand.Next(int.MaxValue)); // ������ ��������� ���� ������
            ChangeTextColor();
            r = this.ForeColor.R;
            g = this.ForeColor.G;
            b = this.ForeColor.B;
            a = this.ForeColor.A;
            this.numberOfClicks=0;
        }

        public void ChangeTextColor()
        {
            this.ForeColor = Color.FromArgb(rand.Next(int.MaxValue)); // ������ ��������� ���� ������
        }

        protected override void OnMouseClick(MouseEventArgs e) // �������������� ���������� �������� ������
        // ������ ����� ���������� ��� ����� �� ������
        {
            //this.ForeColor = Color.FromArgb(rand.Next(int.MaxValue)); // ����� ������ ���� ������
            ChangeTextColor();
            base.OnMouseClick(e); // �������� ���������� �������� ������, ��� �� ������ �� "����������"
            this.numberOfClicks++;
            r = this.ForeColor.R;
            g = this.ForeColor.G;
            b = this.ForeColor.B;
            a = this.ForeColor.A;
            string text = String.Format("ARGB ��������: Alpha: {0}, " +
                "red: {1}, green: {2}, blue: {3}", new object[] { a, r, g, b });
            MessageBox.Show("�������� " + this.numberOfClicks + " ���; "+ text, "Info");
        }
    }
}

