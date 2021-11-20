using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{

    public partial class toolBox : UserControl
    {

        public toolBox(vectShapes inS)
        {
            InitializeComponent();
            myInit();
            this.s = inS;
        }
        
        public toolBox()
        {
            InitializeComponent();
            myInit();
        }

        private void myInit()
        { 
        
        }

        public void setVectShape(vectShapes inS)
        {
            this.s = inS;
            // mi registro all'evento 
            this.s.optionChanged += new OptionChanged(OnOptionChange);
            this.s.objectSelected += new ObjectSelected(OnObjectSelected);

        }

        private void OnObjectSelected(object sender, PropertyEventArgs e)
        {
            //this.propertyGrid1.SelectedObject = e.ele;
            if (e.ele.Length == 0)
                this.propertyGrid1.SelectedObject = sender;
            else
                this.propertyGrid1.SelectedObjects = e.ele;

            this.RedoBtn.Enabled = e.Redoable;
            this.UndoBtn.Enabled = e.Undoable;

            // managmet of 2Front,2back,Delete and Copy buttons
            if (e.ele.Length > 0 )
            {
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
                toolStripButton4.Enabled = true;
                toolStripSplitButton1.Enabled = true;
            }
            else
            {
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false;
                toolStripButton3.Enabled = false;
                toolStripButton4.Enabled = false;
                toolStripSplitButton1.Enabled = false;
            }
            if (e.ele.Length > 1 )
                GroupBtn.Enabled=true;
            else
                GroupBtn.Enabled = false;
        }

        private void OnOptionChange(object sender, OptionEventArgs e)
        { 
            if (e.option=="select")
            {
                deselectAll();
                SelectBtn.Checked = true;
            }
        }

        private void deselectAll()
        {
            SelectBtn.Checked = false;
            RectBtn.Checked = false;
            RRectBtn.Checked = false;
            CirciBtn.Checked = false;
            LineBtn.Checked = false;
            ImageBtn.Checked = false;
            ArcBtn.Checked = false;
            PolyBtn.Checked = false;
            CurveBtn.Checked = false;
            GraphBtn.Checked = false;

            textMnu.BackColor = RRectBtn.BackColor;
            RTFBtn.Checked = false;
            SimpleTextBtn.Checked = false;
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            SelectBtn.Checked = true;
            this.s.Option = "select";
        }

        private void RectBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            RectBtn.Checked = true;
            this.s.Option = "DR";
        }

        private void LineBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            LineBtn.Checked = true;
            this.s.Option = "LI";
        }

        private void CirciBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            CirciBtn.Checked = true;
            this.s.Option = "ELL";
        }

        private void RRectBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            RRectBtn.Checked = true;
            this.s.Option = "DRR";
        }


        private void ImageBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            ImageBtn.Checked = true;
            this.s.Option = "IB";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (s.Saver()) { }
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            if (s.Loader()) { }
        }

        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            this.s.anteprimaStampa(1f);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.s.gridSize = 0;
            //this.s.redraw(true);         
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.s.gridSize = System.Convert.ToInt16(toolStripMenuItem3.Text);
            //this.s.redraw(true);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.s.gridSize = System.Convert.ToInt16(toolStripMenuItem4.Text);
            //this.s.redraw(true);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.s.gridSize = System.Convert.ToInt16(toolStripMenuItem5.Text);
            //this.s.redraw(true);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.s.gridSize = System.Convert.ToInt16(toolStripMenuItem6.Text);
            //this.s.redraw(true);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.s.gridSize = System.Convert.ToInt16(toolStripMenuItem7.Text);
            //this.s.redraw(true);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            this.s.gridSize = System.Convert.ToInt16(toolStripMenuItem8.Text);
            //this.s.redraw(true);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            this.s.gridSize = System.Convert.ToInt16(toolStripMenuItem9.Text);
            //this.s.redraw(true);
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (toolStripTextBox1.Text != "")
            {
                foreach (char c in toolStripTextBox1.Text)
                {
                    if (!Char.IsNumber(c))
                        return;
                }
                this.s.gridSize = System.Convert.ToInt16(toolStripTextBox1.Text);
                this.s.Refresh();
            }

        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            this.s.Stampa();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            this.s.rmSelected();
        }

        private void frontBtn_Click(object sender, EventArgs e)
        {
            this.s.primoPiano();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.s.secondoPiano();
        }

        private void PenColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = PenColor.BackColor;
            colorDialog1.ShowDialog(this);
            PenColor.BackColor = colorDialog1.Color;

            // add code
            this.s.setPenColor(PenColor.BackColor);
            
            this.s.Refresh();

        }

        private void FillColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = FillColor.BackColor;
            colorDialog1.ShowDialog(this);
            FillColor.BackColor = colorDialog1.Color;

            // add code
            this.s.setFillColor(FillColor.BackColor);


            this.s.Refresh();

        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.s.setPenWidth((float)System.Convert.ToDouble(toolStripMenuItem10.Text));
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            this.s.setPenWidth((float)System.Convert.ToDouble(toolStripMenuItem11.Text));
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            this.s.setPenWidth((float)System.Convert.ToDouble(toolStripMenuItem12.Text));
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            this.s.setPenWidth((float)System.Convert.ToDouble(toolStripMenuItem13.Text));
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            this.s.setPenWidth((float)System.Convert.ToDouble(toolStripMenuItem14.Text));
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            this.s.setPenWidth((float)System.Convert.ToDouble(toolStripMenuItem15.Text));
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            this.s.setPenWidth((float)System.Convert.ToDouble(toolStripMenuItem16.Text));
        }


        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            this.s.setFilled(toolStripMenuItem17.Checked);
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox2.Text != "")
            {
                foreach (char c in toolStripTextBox2.Text)
                {
                    if (!Char.IsNumber(c))
                        return;
                }
                this.s.setPenWidth((float)System.Convert.ToDouble(toolStripTextBox2.Text));
                this.s.Refresh();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.s.primoPiano();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.s.secondoPiano();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.s.rmSelected();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            this.s.propertyChanged();
            this.s.Refresh();   
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            if (s.Loader()) { }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (s.Saver()) { }
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            this.s.anteprimaStampa(1f);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.s.Stampa();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.s.cpSelected();
        }

        private void UndoBtn_Click(object sender, EventArgs e)
        {
            this.s.Undo();
            this.RedoBtn.Enabled = this.s.RedoEnabled();
            this.UndoBtn.Enabled = this.s.UndoEnabled();
        }

        private void RedoBtn_Click(object sender, EventArgs e)
        {
            this.s.Redo();
            this.RedoBtn.Enabled = this.s.RedoEnabled();
            this.UndoBtn.Enabled = this.s.UndoEnabled();

        }

        private void ArcBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            ArcBtn.Checked = true;
            this.s.Option = "ARC";

        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void iNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.s.zoomIn();

        }

        private void oUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.s.zoomOut();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.s.HelpForm("");
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            this.s.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem21.Text, provider);
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            this.s.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem22.Text, provider);

        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            this.s.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem23.Text, provider);

        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            this.s.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem24.Text, provider);

        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            this.s.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem25.Text, provider);

        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            this.s.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem26.Text, provider);

        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            this.s.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem27.Text, provider);

        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            this.s.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem28.Text, provider);

        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            this.s.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem29.Text, provider);

        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            this.s.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem30.Text, provider);

        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            this.s.HelpForm("You can also set zoom property clicking the canvas and changing the property grid (Zoom).");
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            if (s.LoadObj()) { }
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            if (s.SaveSelected()) { }
        }

        private void objToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.groupSelected();
            //this.s.Refresh();

        }

        private void deGroupBtn_Click(object sender, EventArgs e)
        {
            s.deGroupSelected();
            //this.s.Refresh();

        }

        private void toolStripDropDownButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void PolyBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            PolyBtn.Checked = true;
            this.s.Option = "POLY";
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            this.s.mergePolygons();
        }

        private void delPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.s.delPoints();
        }

        private void extPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.s.extPoints();
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.s.XMirror();
        }

        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.s.YMirror();
        }

        private void xYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.s.Mirror();
        }

        private void SimpleTextBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            textMnu.BackColor = Color.LightBlue;
            this.s.Option = "STB";
        }

        private void RTFBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            textMnu.BackColor = Color.LightBlue;
            this.s.Option = "TB";
        }

        private void CurveBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            CurveBtn.Checked = true;
            this.s.Option = "PEN";

        }

        private void GraphBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            GraphBtn.Checked = true;
            this.s.Option = "GRAPH";

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }

        private void addArcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.s.linkNodes();
        }

        private void delNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.s.delNodes();
        }

    }
}
