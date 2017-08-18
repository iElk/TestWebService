using System.Net;
using System.IO;
using System.Text;

namespace TestWebService.Helpers
{
    /// <summary>
    /// Хелпер для работы с ответом от Api
    /// </summary>
    public class ResponseApiHelper
    {
        /// <summary>
        /// Получить ответа в формате Json по ссылке Api
        /// </summary>
        /// <param name="urlApi">ссылка Api</param>
        /// <returns>строка ответа в формате Json</returns>
        public static string GetResponseJson(string urlApi)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(urlApi);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            string response = "";

            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                response = stream.ReadToEnd();
            }

            return response;
        }
    }
}