
namespace DESanatology
{
    /// <summary>
    /// Абстрактный класс дешифровка\шифровка
    /// </summary>
    abstract class clCommonProcess
    {
        public abstract string EncryptionStart(string text, string key, bool IsTextBinary);

        public abstract string DecryptionStart(string text, string key, bool IsTextBinary);
    }
}
