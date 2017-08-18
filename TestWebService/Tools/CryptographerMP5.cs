using System.Security.Cryptography;
using System.Text;

namespace TestWebService.Tools
{
    /// <summary>
    /// Шифрование методом MP5
    /// </summary>
    public class CryptographerMP5 : ICryptographer
    {
        public string Encrypt(string str)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(str);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
    }
}