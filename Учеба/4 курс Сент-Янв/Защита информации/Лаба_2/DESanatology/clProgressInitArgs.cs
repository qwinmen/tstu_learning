using System;

namespace DESanatology
{
    /// <summary>
    /// События формы - загрузка
    /// </summary>
    public class clProgressInitArgs: EventArgs
    {
        public clProgressInitArgs(int Maximum)
        {
            this.Maximum = Maximum;
        }

        public int Maximum;
    }

    /// <summary>
    /// Счетчик операций
    /// </summary>
    public class ProgressEventArgs : EventArgs
    {
        public ProgressEventArgs(int Increment)
        {
            this.Increment = Increment;
        }

        public int Increment;
    }
}
