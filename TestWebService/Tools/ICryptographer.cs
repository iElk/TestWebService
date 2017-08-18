namespace TestWebService.Tools
{
    /// <summary>
    /// Интерфейс шифровальщика
    /// </summary>
    public interface ICryptographer
    {
        /// <summary>
        /// Шифрование
        /// </summary>
        /// <param name="str">строка, которую надо зашифровать</param>
        /// <returns>Строка в зашифрованном виде</returns>
        string Encrypt(string str);
    }
}