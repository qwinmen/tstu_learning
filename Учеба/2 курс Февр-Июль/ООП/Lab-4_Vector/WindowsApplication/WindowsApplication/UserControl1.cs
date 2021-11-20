using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class UserControl1 : UserControl
    {
        private string Status;
        private string Option;
        private int startX;
        private int startY;

        public UserControl1()
        {
            InitializeComponent();
            myInit();

        }

        private void myInit()
        { 
            Status = "";
            Option = "select";
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void UserControl1_MouseDown(object sender, MouseEventArgs e)
        {

            switch (this.Option)
            {
            case "select":
                this.Status = "drawrect";
                this.startX = e.X;
                this.startY = e.Y;
                break;
            default:        
                break;
            }

        }

        public void DrawString(RichTextBox r)
        {
            System.Drawing.Graphics myGraphics;
            myGraphics = this.CreateGraphics();  //.CreateGraphics();

            TxtBox tBox = new TxtBox();
            tBox.getString(r);
            tBox.drawString(myGraphics);
           
        }

        public void DrawStringTest(RichTextBox r)
        {
            // test
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(r.SelectionColor);
            //System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
            System.Drawing.Graphics myGraphics;
            myGraphics = this.CreateGraphics();  //.CreateGraphics();
            //myGraphics.FillRectangle(myBrush, new Rectangle(startX, startY, e.X - this.startX, e.Y - this.startY));
            //Font drawFont = new Font("Arial", 8);
            Font drawFont = r.SelectionFont;
            //myGraphics.DrawRectangle(myPen, new Rectangle(1, 1, 60, 30));


            //maxHeight
            float maxHeight = 0;
            for (int i = 0; i <= r.TextLength; i++)
            {
                r.Select(i, 1);
                drawFont = r.SelectionFont;
                if (drawFont.Height > maxHeight)
                {
                    maxHeight = drawFont.Height;
                }
            }


            float offsetX=0;
            for (int i = 0; i <= r.TextLength; i++)
            {
                r.Select(i, 1);
                drawFont = r.SelectionFont;
                myBrush = new System.Drawing.SolidBrush(r.SelectionColor);
                //if (r.SelectedText != "")
                //{
                // test MeasureCharacterRanges
                    CharacterRange[] characterRanges = { new CharacterRange(0, 1) };
                    StringFormat stringFormat = new StringFormat();
               
                    stringFormat.SetMeasurableCharacterRanges(characterRanges);
                    Region[] stringRegions = new Region[1];
                    stringRegions = myGraphics.MeasureCharacterRanges(r.SelectedText, drawFont, new Rectangle((int)offsetX, (int)(1 + maxHeight - drawFont.Height), 2000, (int)maxHeight), stringFormat);
                    float wid2=0;
                    if (stringRegions.Length>0 )
                    {
                        if (r.SelectedText == " ")
                        {
                            wid2 = myGraphics.MeasureString(r.SelectedText, drawFont).Width;
                        }
                        else
                        {
                            wid2 = stringRegions[0].GetBounds(myGraphics).Width;
                        }
                    }
                // fine test
                 float dx = 0;
                 //float wid=myGraphics.MeasureString(r.SelectedText, drawFont).Width;
                 //wid = wid * 0.67f;

                 float wid = wid2;

                 myGraphics.DrawString(r.SelectedText, drawFont, myBrush,  (int)offsetX, (int)(1 + maxHeight - drawFont.Height));
                 offsetX = offsetX + wid;//drawFont.Size;
                //}
                myBrush.Dispose();
            }

            myBrush.Dispose();
            myGraphics.Dispose();

        }

        private void UserControl1_MouseUp(object sender, MouseEventArgs e)
        {

            switch (this.Option)
            {
                case "select":

                    //this.Status = "drawrect";
                    //this.startX = e.X;
                    //this.startY = e.Y;
                    if (this.Status == "drawrect")
                    {
                     // test
                     System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                     System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
                     System.Drawing.Graphics myGraphics;
                     myGraphics = this.CreateGraphics();  //.CreateGraphics();
                     //myGraphics.FillRectangle(myBrush, new Rectangle(startX, startY, e.X - this.startX, e.Y - this.startY));
                        Font drawFont = new Font("Arial", 8);
                     myGraphics.DrawRectangle(myPen, new Rectangle(startX, startY, e.X - this.startX, e.Y - this.startY));
                        
                     //myGraphics.DrawString("pippo", drawFont, myBrush, startX+1, startY+1);
                     myGraphics.DrawString("pippo", drawFont, myBrush,  new Rectangle(startX, startY, e.X - this.startX, e.Y - this.startY) );                        
                     myPen.Dispose();
                     myBrush.Dispose();
                     myGraphics.Dispose();
                     this.startX = 0;
                     this.startY = 0;
                     this.Status= "" ;
                    }
                    break;
                default:
                    break;
            }


        }
    }
}
