using System.Collections.Generic;
using System.Drawing;
using FastColoredTextBoxNS;

namespace Mary
{
    /// <summary>
    /// надо обработать повторяющиеся ID в блоке Var, подкрасить ошибки блока
    /// </summary>
    class clSyntaxErrIDtoVar
    {
        //create my custom style
        readonly EllipseStyle _ellipseStyle = new EllipseStyle();
        
        /// <summary>
        /// В блоке Var выделить все повторяющиеся идентификаторы
        /// </summary>
        internal void fctb_TextChanged(TextChangedEventArgs e, FastColoredTextBox textBoxIn, KeyValuePair<int,int>[] err)
        {
            //clear old styles of chars
            e.ChangedRange.ClearStyle(_ellipseStyle);
            if(err!=null)
            foreach (KeyValuePair<int, int> keyValuePair in err)
            {
                e.ChangedRange.tb.SelectionStart = keyValuePair.Key;//откуда
                e.ChangedRange.tb.SelectionLength = keyValuePair.Value;//и на сколько
                textBoxIn.Selection.SetStyle(_ellipseStyle);
            }
            
        }
    }

    /// <summary>
    /// Этот стиль отрисует рамку-элипсис вокруг косячного обьявления
    /// </summary>
    class EllipseStyle : Style
    {
        /// <summary>
        /// типо конструктор position(x,y) range(width,height)
        /// </summary>
        public override void Draw(Graphics gr, Point position, Range range)
        {
            //get size of rectangle
            Size size = GetSizeOfRange(range);
            //create rectangle
            Rectangle rect = new Rectangle(position, size);

            //inflate it
            rect.Inflate(2, 2);
            //get rounded rectangle
            var path = GetRoundedRectangle(rect, 7);
            //draw rounded rectangle
            gr.DrawPath(Pens.Red, path);
        }
    }
}
