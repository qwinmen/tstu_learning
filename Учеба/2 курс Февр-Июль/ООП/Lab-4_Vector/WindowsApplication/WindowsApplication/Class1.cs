using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{

    /// <summary>
    /// Rappresenta una stringa Rtf, con relativo font e colore.
    /// </summary>
    [Serializable]
    public class TxtElem
    {
        public string T;
        public Font F;
        //public SolidBrush B;
        public Color B;
        
        public TxtElem(string t,Font f, Color b)
        {
            T = t;
            F = f;
            B = b;
        }
    }

    /// <summary>
    /// Rappresenta una riga Rtf. Collection di TxtElem 
    /// </summary>
    [Serializable]
    public class TxtLine
    {
        public ArrayList Charlist;
        public StringAlignment Allign;
        public float maxHeight;

        public TxtLine()
        {
            Charlist = new ArrayList();
        }


        TxtLine(StringAlignment a)
        {
            Charlist = new ArrayList();
            Allign = a;
        }

        public void addChar(string s,Font f , Color b)
        {
            TxtElem e = new TxtElem(s,f,b);
            this.Charlist.Add(e);
        }

        public void Clear()
        {
            this.Charlist.Clear();
        }

        public void setLine(RichTextBox r)
        {
            foreach (TxtElem e in this.Charlist)
            {
                if (e.T != "\n")// il caso "\n" lo gestisco fuori ciclo
                {
                    r.SelectionFont = e.F;
                    r.SelectionColor = e.B;
                    r.SelectedText = e.T;
                }

            }
            //r.SelectedText = "\n"; // gestisco riga vuota

        
        }
    }

    /// <summary>
    /// Rappresenta testo Rtf. Collection di TxtLine 
    /// </summary>
    [Serializable]
    public class TxtBox
    {
        public ArrayList Linelist;

        //[NonSerialized()]private RichTextBox tmpR;

        public TxtBox()
        {
            Linelist = new ArrayList();
            
        }

        private void addLine(TxtLine l)
        {            
            this.Linelist.Add(l);
        }

        public void Clear()
        {
            this.Linelist.Clear();
        }

        /// <summary>
        /// Disegna Una singola riga (chiamata da drawString)
        /// </summary> 
        public void drawLine(System.Drawing.Graphics g, TxtLine l, float startX, float startY,int x1,int y1)
        {

            System.Drawing.SolidBrush myBrush = null;
            Font drawFont=null;
            float offsetX = startX;
            foreach( TxtElem e in l.Charlist)
            {
                if (e.T == "\n") 
                    break;
                
                drawFont = e.F;
                myBrush = new SolidBrush(e.B);
                
                CharacterRange[] characterRanges = { new CharacterRange(0, e.T.Length) };
                //CharacterRange[] characterRanges = { new CharacterRange(0, 1) };
                
                StringFormat stringFormat = new StringFormat();

                stringFormat.SetMeasurableCharacterRanges(characterRanges);
                Region[] stringRegions = new Region[1];
                stringRegions = g.MeasureCharacterRanges(e.T, drawFont, new Rectangle((int)startX, (int)startY, 2000, 2000), stringFormat);
                float wid2 = 0;
                float hei2 = 0;
                if (stringRegions.Length > 0)
                {
                    if (e.T == " ")
                    {
                        wid2 = g.MeasureString(e.T, drawFont).Width;
                        hei2 = g.MeasureString(e.T, drawFont).Height;                        
                    }
                    else
                    {
                        int conta_spazi_inizio = e.T.Length -  e.T.TrimStart(" ".ToCharArray()).Length;
                        int conta_spazi_fine = e.T.Length - e.T.TrimEnd(" ".ToCharArray()).Length;
                        float wid_space = 0;
                        wid_space = g.MeasureString(" ", drawFont).Width * (conta_spazi_inizio + conta_spazi_fine);

                        wid2 = stringRegions[0].GetBounds(g).Width + wid_space;
                        hei2 = stringRegions[0].GetBounds(g).Height;
                    }
                }

                float wid = wid2;
                string tmpStr = e.T;
                if ((x1 - offsetX > 0) & (y1 - (startY + l.maxHeight - hei2) > 0))
                {
                    g.DrawString(tmpStr, drawFont, myBrush, new RectangleF(offsetX, (startY + l.maxHeight - hei2), x1 - offsetX, y1 - (startY + l.maxHeight - hei2)));
                }

                offsetX = offsetX + wid;//drawFont.Size;
                

            }

        }

        /// <summary>
        /// Disegna il textbox su un System.Drawing.Graphics passato in input
        /// </summary>        
        public void drawString(System.Drawing.Graphics g,int x , int y,int x1, int y1)
        {
            float dy = y;
            foreach (TxtLine l in this.Linelist)
            {
                this.drawLine(g, l, x, dy, x1, y1);
                dy = dy + l.maxHeight;
            }
        }

        /// <summary>
        /// Imposta un RichTextBox passato in input
        /// </summary>
        public void setString(RichTextBox r)
        {
            int i = 0;
            r.Text = "";
            foreach (TxtLine l in this.Linelist)
            {
                l.setLine(r);
                r.SelectedText = "\n"; // vado a capo dopo avere stampato riga
                i++;
            }
            
        }

        public void getStringOLD(RichTextBox r)
        {
            //int nLine = 0;
            int i=0;
            while (i  < r.TextLength )
            {
                TxtLine l = new TxtLine();
                //maxHeight
                float maxHeight = 0;

                while (r.SelectedText != "\n" && i  < r.TextLength )
                {
                    r.Select(i, 1);
                    Font drawFont = r.SelectionFont;               
                    if (drawFont.Height > maxHeight)
                    {
                        maxHeight = drawFont.Height;
                    }
                    l.addChar(r.SelectedText,r.SelectionFont,r.SelectionColor);
                    i++;
                }
                l.maxHeight = maxHeight;
                if (r.SelectedText == "\n")
                {
                    r.Select(i, 1);
                    //i++;
                }
                this.addLine(l);
            }
        }


        private int getLenColorFormat(RichTextBox r, int start)
        {
            int i = start;
            int n = 0;
            while (i < r.TextLength)
            {

            }
            return n;
        }

        /// <summary>
        /// Carica i dati da un RichTextBox passato in input 
        /// (SPLITTA IN BASE AI CAMBIAMENTI DI COLORE E/O FONT)
        /// Se si usa sempre stesso font, allora gestisce automaticamente il testo verticale.
        /// </summary>
        public void getString(RichTextBox r)
        {
            //int nLine = 0;
            int i = 0;
            float lastHeight = 0;
            
            foreach (string tmpStr in r.Lines)
            {
                TxtLine l = new TxtLine();
                //maxHeight
                float maxHeight = 0;

                bool primo = true;
                Color precCol = Color.White;
                Font precFont = null;
                int k=i;
                foreach (char tmpChar in tmpStr)
                {

                    r.Select(i, 1);
                    i++;

                    if (primo)
                    {
                        primo = false;
                        precCol = r.SelectionColor;
                        precFont = r.SelectionFont;
                        k = i;
                    }

                    Font drawFont = r.SelectionFont;
                    if (drawFont.Height > maxHeight)
                    {
                        maxHeight = drawFont.Height;
                    }
                    lastHeight = drawFont.Height;

                    if (precCol.Name != r.SelectionColor.Name || ! precFont.Equals(r.SelectionFont) )
                    {
                        precCol = r.SelectionColor;
                        precFont = r.SelectionFont;

                        // è cambiato qlcosa.. 
                        r.Select(k - 1, i - (k - 1) - 1);
                        l.addChar(r.SelectedText, r.SelectionFont, r.SelectionColor);
                        k = i;
                    }
                    //l.addChar(r.SelectedText, r.SelectionFont, r.SelectionColor);
                }
                r.Select(k-1, i - (k-1));
                l.addChar(r.SelectedText, r.SelectionFont, r.SelectionColor);

                i++;// a capo
                if (maxHeight == 0)
                {
                    l.maxHeight = lastHeight;
                }
                else
                {
                    l.maxHeight = maxHeight;
                }

                this.addLine(l);

            }

        }

    
    


        /// <summary>
        /// Carica i dati da un RichTextBox passato in input (SPLITTA CARATTERE PER CARATTERE)
        /// </summary>
        public void getStringBUONO(RichTextBox r)
        {
            //int nLine = 0;
            int i = 0;
            float lastHeight = 0;
            
            while (i < r.TextLength)
            {
                TxtLine l = new TxtLine();
                //maxHeight
                float maxHeight = 0;

                while ( i < r.TextLength)
                {

                    r.Select(i, 1);
                    i++;

                    if (r.SelectedText == "\n")
                    {
                        //devo gestire riga vuota
                        //maxHeight=lastHeight;
                        break; 
                    }

                    Font drawFont = r.SelectionFont;
                    if (drawFont.Height > maxHeight)
                    {
                        maxHeight = drawFont.Height;
                    }
                    lastHeight = drawFont.Height;
                    l.addChar(r.SelectedText, r.SelectionFont, r.SelectionColor);
                    
                }

                if (maxHeight == 0)
                {
                    l.maxHeight = lastHeight;
                }
                else
                {
                    l.maxHeight = maxHeight;
                }

                this.addLine(l);
            }
        }

    
    }



}
