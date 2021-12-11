
namespace DESanatology
{
    /// <summary>
    /// Реализация алгоритма DES
    /// </summary>
    class clCryptographer
    {
        clCommonProcess cProcess = null;

        public clCryptographer(Form1.ProgressEventHandler IncrementProgress, Form1.ProgressInitHandler InitProgress)
        {
            cProcess = new clProcessDES(IncrementProgress, InitProgress);
        }

        public string EncryptionStart(string text, string key, bool IsBinary)
        {
            return cProcess.EncryptionStart(text, key, IsBinary);
        }

        public string DecryptionStart(string text, string key, bool IsBinary)
        {
            return cProcess.DecryptionStart(text, key, IsBinary);
        }

    }
}
