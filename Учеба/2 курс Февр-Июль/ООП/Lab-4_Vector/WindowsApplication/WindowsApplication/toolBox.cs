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
            this.s = inS;
        }
        
        public toolBox()
        {
            InitializeComponent();
        }

        public void setVectShape(vectShapes inS)
        {
            this.s = inS;
            // mi registro all'evento 
            this.s.optionChanged += new OptionChanged(OnOptionChange);
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
            PolyBtn.Checked = false;
            CurveBtn.Checked = false;
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
        }

        private void RedoBtn_Click(object sender, EventArgs e)
        {
            this.s.Redo();
        }

        private void ArcBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            this.s.Option = "ARC";
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

        private void RTFBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            this.s.Option = "TB";
        }

        private void CurveBtn_Click(object sender, EventArgs e)
        {
            deselectAll();
            CurveBtn.Checked = true;
            this.s.Option = "PEN";

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
