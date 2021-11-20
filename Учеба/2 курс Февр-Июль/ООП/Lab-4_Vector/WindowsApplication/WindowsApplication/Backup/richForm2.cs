using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class richForm2 : Form
    {
        //private RichTextBox OuterRichText;

        public bool confermato;

        public richForm2()
        {
            InitializeComponent();
        }

        public richForm2(string rtfIn)
        {
            InitializeComponent();
            this.richTextBox1.Rtf = rtfIn;
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }

        public string getRtf()
        {
            return this.richTextBox1.Rtf;
        }

        public void setRtf(string rtfIn)
        {
            this.richTextBox1.Rtf = rtfIn;
        }



        private void richForm2_Load(object sender, EventArgs e)
        {
            //this.DimensioneCbo.


                FontFamily[] ff = FontFamily.Families;
                // Loop and create a sample of each font.
                for (int x = 0; x < ff.Length; x++)
                {

                    System.Drawing.Font font = null;

                    // Create the font - based on the styles available.
                    if (ff[x].IsStyleAvailable(FontStyle.Regular))
                        font = new System.Drawing.Font(
                            ff[x].Name,
                            this.DimensioneCbo.Font.Size
                            );
                    else if (ff[x].IsStyleAvailable(FontStyle.Bold))
                        font = new System.Drawing.Font(
                            ff[x].Name,
                            this.DimensioneCbo.Font.Size,
                            FontStyle.Bold
                            );
                    else if (ff[x].IsStyleAvailable(FontStyle.Italic))
                        font = new System.Drawing.Font(
                            ff[x].Name,
                            this.DimensioneCbo.Font.Size,
                            FontStyle.Italic
                            );
                    else if (ff[x].IsStyleAvailable(FontStyle.Strikeout))
                        font = new System.Drawing.Font(
                            ff[x].Name,
                            this.DimensioneCbo.Font.Size,
                            FontStyle.Strikeout
                            );
                    else if (ff[x].IsStyleAvailable(FontStyle.Underline))
                        font = new System.Drawing.Font(
                            ff[x].Name,
                            this.DimensioneCbo.Font.Size,
                            FontStyle.Underline
                            );

                    // Should we add the item?
                    if (font != null)
                        this.DimensioneCbo.Items.Add(font.FontFamily.Name);

                } // End for all the fonts.
                this.DimensioneCbo.SelectedIndex = 0;

        }


        public String SelectedFontFamily
        {

            get
            {

                // Sanity check the combobox before attempting to use it.
                if (DimensioneCbo == null)
                    return null;

                // Get the index of the currently selected item.
                int index = DimensioneCbo.SelectedIndex;

                // Sanity check the index before attempting to use it.
                if (index == -1)
                    return null;

                // Return the corresponding font family.
                return ((String)DimensioneCbo.SelectedItem);

            } // End get

            set
            {

                // Sanity check the combobox before attempting to use it.
                if (DimensioneCbo == null)
                    return;

                int index = -1;

                // Should we look for a matching item?
                if (value != null)
                    index = DimensioneCbo.FindString(value, -1);

                // Select the item.
                DimensioneCbo.SelectedIndex = index;

            } // End set

        } // End SelectedFontFamily


        public int SelectedSize
        {

            get
            {
                if (SizeCbo.Text == "")
                    return 8;
                // Return the corresponding font family.
                return (System.Convert.ToInt16(SizeCbo.Text));

            } // End get
            set
            {
                // Sanity check the combobox before attempting to use it.
                if (SizeCbo == null)
                    return;

                SizeCbo.Text = value.ToString();

            } // End set

        } // End SelectedFontFamily


        private void DimensioneCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this,"You selected: " + this.SelectedFontFamily);
            this.setFont();             
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionColor.Name != "0")
                this.ColorBtn.BackColor = richTextBox1.SelectionColor;
            if (this.richTextBox1.SelectionFont != null)
            {
             this.SelectedFontFamily = this.richTextBox1.SelectionFont.FontFamily.Name;
             this.SelectedSize = (int)this.richTextBox1.SelectionFont.Size;
             if (this.richTextBox1.SelectionFont.Bold)
             {
                GrassettoBtn.Checked = true;
             }
             else
             {
                GrassettoBtn.Checked = false;
             }
             if (this.richTextBox1.SelectionFont.Italic)
             {
                CorsivoBtn.Checked = true;
             }
             else
             {
                CorsivoBtn.Checked = false;
             }
             if (this.richTextBox1.SelectionFont.Underline)
             {
                SottolineatoBtn.Checked = true;
             }
             else
             {
                SottolineatoBtn.Checked = false;
             }
            }

            
            Ce.Checked = (this.richTextBox1.SelectionAlignment == HorizontalAlignment.Center);
            Sx.Checked = (this.richTextBox1.SelectionAlignment == HorizontalAlignment.Left);
            Dx.Checked = (this.richTextBox1.SelectionAlignment == HorizontalAlignment.Right);

/*            if (this.richTextBox1.SelectionAlignment == HorizontalAlignment.Center)
            {
                Sx.Checked = false;
                Dx.Checked = false;
                Ce.Checked = true;
            }
            if (this.richTextBox1.SelectionAlignment == HorizontalAlignment.)
            {
                Sx.Checked = false;
                Dx.Checked = false;
                Ce.Checked = true;
            }
            if (this.richTextBox1.SelectionAlignment == HorizontalAlignment.Center)
            {
                Sx.Checked = false;
                Dx.Checked = false;
                Ce.Checked = true;
            }*/

        }

        private void GrassettoBtn_Click(object sender, EventArgs e)
        {
            this.setFont();     
        }


        private void setFont()
        {
           
            FontStyle fs = 0; ;
            if (GrassettoBtn.Checked)
                fs = fs | FontStyle.Bold;
            if (CorsivoBtn.Checked)
                fs = fs | FontStyle.Italic;
            if (SottolineatoBtn.Checked)
                fs = fs | FontStyle.Underline;
            //FontStyle fs = FontStyle.Bold | FontStyle.Underline | FontStyle.Italic;
            try
            {
                Font f = new Font(this.SelectedFontFamily, this.SelectedSize, fs);
                this.richTextBox1.SelectionFont = f;
                this.richTextBox1.SelectionColor = ColorBtn.BackColor;
            }
            catch
            { }

            this.richTextBox1.Focus();

        }

        private void SottolineatoBtn_Click(object sender, EventArgs e)
        {
            this.setFont(); 
        }

        private void CorsivoBtn_Click(object sender, EventArgs e)
        {
            this.setFont(); 
        }

        private void SizeCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setFont(); 
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SizeCbo_TextUpdate(object sender, EventArgs e)
        {
            this.setFont();
        }

        private void SizeCbo_Leave(object sender, EventArgs e)
        {
            this.setFont();
        }

        private void ColorBtn_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = ColorBtn.BackColor;
            colorDialog1.ShowDialog(this);
            ColorBtn.BackColor = colorDialog1.Color;

            this.setFont();

        }

        private void Sx_Click(object sender, EventArgs e)
        {
            Sx.Checked = true;
            Dx.Checked = false;
            Ce.Checked = false;

            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            this.richTextBox1.Focus();

        }

        private void Sx_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void Ce_Click(object sender, EventArgs e)
        {
            Sx.Checked = false;
            Dx.Checked = false;
            Ce.Checked = true;
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            this.richTextBox1.Focus();

        }

        private void Dx_Click(object sender, EventArgs e)
        {
            Sx.Checked = false;
            Dx.Checked = true;
            Ce.Checked = false;
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            this.richTextBox1.Focus();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.confermato = true;
            this.Visible = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.confermato = false;
            this.Visible = false;

        }



    }
}