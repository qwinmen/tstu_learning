using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FoxPro.Properties;
using ZedGraph;

namespace FoxPro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        #region Panel Drag Drop

        private Boolean _dragging;
        private Point _startDragPoint;

        /// <summary>
        /// Нажатие
        /// </summary>
        private void pnlDragDrop_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _startDragPoint = e.Location;
        }

        /// <summary>
        /// Перемещение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlDragDrop_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                ((Control)sender).Left = ((Control)sender).Location.X + (e.Location.X - _startDragPoint.X);
                ((Control)sender).Top = ((Control)sender).Location.Y + (e.Location.Y - _startDragPoint.Y);
            }
        }

        /// <summary>
        /// Освобождение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlDragDrop_MouseUp(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                _dragging = false;
                panel1.Invalidate();
            }
        }

        #endregion

        clAlfavit _alfavit = new clAlfavit("ru");

        private void Form1_Load(object sender, EventArgs e)
        {
            //стартуем с русского
            label3.Text = Resources.StrPowerAlf + _alfavit.N().ToString();
            //грузим буквы
            txtBx_Alfavit.Text = _alfavit.StrAlf();
            txtBx_Alfavit.Enabled = false;
        }

        /// <summary>
        /// Установить N на табло
        /// </summary>
        private void SetLng(string lng)
        {
            _alfavit = new clAlfavit(lng.ToLower());

            switch (lng.ToLower())
            {
                case "ru":
                    //стартуем с русского
                    label3.Text = Resources.StrPowerAlf + _alfavit.N().ToString();
                    //грузим буквы
                    txtBx_Alfavit.Text = _alfavit.StrAlf();
                    txtBx_Alfavit.Enabled = false;
                    break;
                case "en":
                    label3.Text = Resources.StrPowerAlf + _alfavit.N().ToString();
                    //грузим буквы
                    txtBx_Alfavit.Text = _alfavit.StrAlf();
                    txtBx_Alfavit.Enabled = false;
                    break;
                case "ex":
                    label3.Text = Resources.StrPowerAlf + _alfavit.N().ToString();
                    //грузим буквы
                    txtBx_Alfavit.Text = _alfavit.StrAlf();
                    txtBx_Alfavit.Enabled = true;
                    break;
            }

        }

        /// <summary>
        /// Выбрано направление языка
        /// </summary>
        private void radialMenu1_ItemClick(object sender, EventArgs e)
        {
            if (sender == null) return;

            if (((RadioButton)sender).Text.Equals("Ru"))
                SetLng(((RadioButton)sender).Text);
            if (((RadioButton)sender).Text.Equals("En"))
                SetLng(((RadioButton)sender).Text);
            if (((RadioButton)sender).Text.Equals("Ex"))
                SetLng(((RadioButton)sender).Text);

            var controls = new TextBox() { Text = txtBx_Input.Text };
            txtBx_Input_TextChanged(controls, null);
        }

        /// <summary>
        /// Вводим тексты и анализируем
        /// </summary>
        private void txtBx_Input_TextChanged(object sender, EventArgs e)
        {
            //передать всё подрят
            _alfavit.Analiz(((TextBox)sender).Text);
            //обновить графику распознания
            UpdateLiveChart(_alfavit.PieGraffik);
            //Обновить панель информер
            label2.Text = Resources.StrV + (_alfavit.InfoVMsg).ToString().Replace(',', '.') + "BIT";
            label1.Text = Resources.StrWeight+(_alfavit.InfoiMsg).ToString().Replace(',', '.') + "BIT";
        }

        private void UpdateLiveChart(PointD point)
        {
            microChartItem1.Value = (int) point.X > 0 ? (int) point.X : 0;
            toolTip1.SetToolTip(microChartItem1,
                String.Format("Опознано: {1}%, Неопознано: {0}%", (Math.Round((point.X), 2)), (Math.Round((point.Y), 2))));
        }
       
        /// <summary>
        /// Вводим свой алфавит
        /// </summary>
        private void txtBx_Alfavit_TextChanged(object sender, EventArgs e)
        {
            //снять строку "все подряд"
            _alfavit.Razbor(((TextBox)sender).Text);
            //запрос мощьности
            label3.Text = Resources.StrPowerAlf + _alfavit.N().ToString();
        }


    }
}
