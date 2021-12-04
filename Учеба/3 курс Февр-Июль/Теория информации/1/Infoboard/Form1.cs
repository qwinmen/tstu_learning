using System;
using System.Collections.Generic;
using System.Drawing;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Instrumentation;
using ZedGraph;

namespace Infoboard
{
    public partial class Form1 : Office2007Form
    {
        public Form1()
        {
            InitializeComponent();
            //UpdateLiveChart(new PointD(-1,-1));
            // Опознано
            microChartItem1.PieChartStyle.SliceColors[0] = Color.LawnGreen;
            microChartItem1.PieChartStyle.SliceColors[1] = Color.Red;
            microChartItem1.PieChartStyle.SliceOutlineColor = Color.Gray;
            // Set custom tool-tips
            microChartItem1.DataPointTooltips = new List<string>(new string[] { "Опознано: {0}%", "Неопознано: {0}%" });
        }

        private void UpdateLiveChart(PointD point)
        {
            microChartItem1.DataPoints = GetRandomDataPoints(point);
        }

        private List<double> GetRandomDataPoints(PointD pointD)
        {
            List<double> points = new List<double>();
            
            if(pointD.X > 0)
                points.Add(Math.Round((pointD.Y), 2)); points.Add(Math.Round((pointD.X), 2));

            return points;
        }

        clAlfavit _alfavit = new clAlfavit("ru");

        private void Form1_Load(object sender, EventArgs e)
        {
            //стартуем с русского
            GaugeItem gaugeN = gaugeControl1.GaugeItems[5];
            ((NumericIndicator) gaugeN).Text = _alfavit.N().ToString();
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
            GaugeItem gaugeN = gaugeControl1.GaugeItems[5];

            switch (lng.ToLower())
            {
                case "ru":
                    //стартуем с русского
                    ((NumericIndicator)gaugeN).Text = _alfavit.N().ToString();
                    //грузим буквы
                    txtBx_Alfavit.Text = _alfavit.StrAlf();
                    txtBx_Alfavit.Enabled = false;
                    break;
                case "en":
                    ((NumericIndicator)gaugeN).Text = _alfavit.N().ToString();
                    //грузим буквы
                    txtBx_Alfavit.Text = _alfavit.StrAlf();
                    txtBx_Alfavit.Enabled = false;
                    break;
                case "blend":
                    ((NumericIndicator)gaugeN).Text = _alfavit.N().ToString();
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

            if (((BaseItem)sender).Text.Equals("Ru"))
                SetLng(((BaseItem)sender).Text);
            if (((BaseItem)sender).Text.Equals("En"))
                SetLng(((BaseItem)sender).Text);
            if (((BaseItem)sender).Text.Equals("Blend"))
                SetLng(((BaseItem)sender).Text);

            var controls = new TextBoxX(){Text = txtBx_Input.Text};
            txtBx_Input_TextChanged(controls, null);
        }

        /// <summary>
        /// Вводим тексты и анализируем
        /// </summary>
        private void txtBx_Input_TextChanged(object sender, EventArgs e)
        {
            //передать всё подрят
            _alfavit.Analiz(((TextBoxX)sender).Text);
            //обновить графику распознания
            UpdateLiveChart(_alfavit.PieGraffik);
            //Обновить панель информер
            GaugeItem gaugeV = gaugeControl1.GaugeItems[3];
            ((NumericIndicator) gaugeV).Text = (_alfavit.InfoVMsg).ToString().Replace(',', '.')+"BIT";
            gaugeV = gaugeControl1.GaugeItems[1];
            ((NumericIndicator)gaugeV).Text = (_alfavit.InfoiMsg).ToString().Replace(',', '.') + "BIT";


        }

        /// <summary>
        /// Вводим свой алфавит
        /// </summary>
        private void txtBx_Alfavit_TextChanged(object sender, EventArgs e)
        {
            //снять строку "все подряд"
            _alfavit.Razbor(((TextBoxX)sender).Text);
            //запрос мощьности
            GaugeItem gaugeN = gaugeControl1.GaugeItems[5];
            ((NumericIndicator)gaugeN).Text = _alfavit.N().ToString();
        }



    }
}
