using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace WindowsApplication1
{
    [Serializable]
    public class PenWR 
    {
        public PenAlignment alignment { get; set; }
        
        public Color color { get; set; }
        
        public float[] compoundArray{ get; set; }
        public CustomLineCap customEndCap { get; set; }
        public CustomLineCap customStartCap { get; set; }
        public DashCap dashCap { get; set; }
        public float dashOffset { get; set; }
        public float[] dashPattern { get; set; }
        public DashStyle dashStyle { get; set; }
        public LineCap endCap { get; set; }
        public LineJoin lineJoin { get; set; }
        public float miterLimit { get; set; }
        public LineCap startCap { get; set; }
        public float width { get; set; }

        public PenWR(Color c)
        {
            this.color = c;

            Pen p = new Pen(c);

            alignment = p.Alignment;            
            compoundArray = p.CompoundArray;
            //if (p.CustomEndCap!=null)
            // customEndCap = p.CustomEndCap;
            //customStartCap = p.CustomStartCap;
            dashCap = p.DashCap;
            dashOffset = p.DashOffset;
            //dashPattern = p.DashPattern;
            dashStyle = p.DashStyle;
            endCap = p.EndCap;
            lineJoin = p.LineJoin;
            miterLimit = p.MiterLimit;
            startCap = p.StartCap;
            width = p.Width;

        }

        public Pen getPen()
        {
            Pen p = new Pen(this.color);
            
            //set p properties
            p.Alignment = this.alignment;
            //if (this.compoundArray!=null)
            //    p.CompoundArray = this.compoundArray;
            if (this.customEndCap!=null)
                p.CustomEndCap =this.customEndCap;
            if (this.customStartCap != null)
            p.CustomStartCap = this.customStartCap;
            p.DashCap = this.dashCap;
            p.DashOffset = this.dashOffset;
            if (this.dashPattern != null)
                p.DashPattern = this.dashPattern;
            p.DashStyle = this.dashStyle;
            p.EndCap = this.endCap;
            p.LineJoin = this.lineJoin;
            p.MiterLimit = this.miterLimit;
            p.StartCap = this.startCap;
            p.Width = this.width;
           
            return p;
        }


    }

}
