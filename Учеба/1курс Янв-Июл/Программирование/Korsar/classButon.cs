using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Korsar
{
    class classButon
    {
        void Peredvigaet(int key)
        {
            if (key == 1)
            {
                Random r = new Random();
                bUbegaet.Left = r.Next(0, ClientSize.Width - bUbegaet.Width);
                bUbegaet.Top = r.Next(0, ClientSize.Height - bUbegaet.Height);
                if (bUbegaet.Capture)
                {
                    MessageBox.Show("Мяу!");
                    bUbegaet.Visible = false;
                    bAktivator.Visible = true;
                }

            }
        }

    }
}
