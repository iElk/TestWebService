using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Script.Serialization;
using TestWebService.Model;
using TestWebService.Data;
using TestWebService.Tools;
using System;
using System.Web.Services.Protocols;

namespace TestWebService
{
    /// <summary>
    /// Веб сервис
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/TestWebService/TestWebService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TestWebService : System.Web.Services.WebService
    {
        private IRepository _repo;
        private ICryptographer _crypto;

        public TestWebService()
        {
            _repo = new RepositoryLoginet();

            // В задании не указано как будет использоваться поле email на клиенте, поэтому просто шифруем в MP5 без возможности дешифровки
            _crypto = new CryptographerMP5();
        }

        public TestWebService(IRepository repo, ICryptographer crypto)
        {
            _repo = repo;
            _crypto = crypto;
        }

        /// <summary>
        /// Шифрование поля email объекта User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private User EncryptEmail(User user)
        {
            user.email = _crypto.Encrypt(user.email);
            return user;
        }

        /// <summary>
        /// Шифрование поля email массива объектов User
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        private User[] EncryptEmail(User[] users)
        {
            foreach(var user in users)
            {
                EncryptEmail(user);
            }

            return users;
        }

        /// <summary>
        /// Выкидываем наружу ошибку, которая будет обрабатываться на стороне клиента
        /// </summary>
        /// <param name="ex">Ошибка</param>
        private void ThrowSoapException(Exception ex)
        {
            throw new SoapException(ex.Message, SoapException.ServerFaultCode);
        }


        #region Xml

        [WebMethod]
        public User[] GetUsersXml()
        {
            try
            {
                var users = _repo.GetUsers();
                return EncryptEmail(users);
            }
            catch(Exception ex)
            {
                ThrowSoapException(ex);
            }

            return null;
        }

        [WebMethod]
        public User GetUserByIdXml(int id)
        {
            try
            {
                var user = _repo.GetUserById(id);
                return EncryptEmail(user);
            }
            catch (Exception ex)
            {
                ThrowSoapException(ex);
            }
            return null;
        }

        [WebMethod]
        public Album[] GetAlbumsXml()
        {
            try
            {
                return _repo.GetAlbums();
            }
            catch (Exception ex)
            {
                ThrowSoapException(ex);
            }
            return null;
        }

        [WebMethod]
        public Album GetAlbumByIdXml(int id)
        {
            try
            {
                return _repo.GetAlbumById(id);
            }
            catch (Exception ex)
            {
                ThrowSoapException(ex);
            }
            return null;
        }

        [WebMethod]
        public Album[] GetAlbumsByUserIdXml(int userId)
        {
            try
            {
                return _repo.GetAlbumsByUserId(userId);
            }
            catch (Exception ex)
            {
                ThrowSoapException(ex);
            }
            return null;
        }

        #endregion

        #region JSON

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetUsersJson()
        {
            try
            {
                return new JavaScriptSerializer().Serialize(_repo.GetUsers());
            }
            catch (Exception ex)
            {
                ThrowSoapException(ex);
            }
            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetUserByIdJson(int id)
        {
            try
            {
                return new JavaScriptSerializer().Serialize(_repo.GetUserById(id));
            }
            catch (Exception ex)
            {
                ThrowSoapException(ex);
            }
            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetAlbumsJson()
        {
            try
            {
                return new JavaScriptSerializer().Serialize(_repo.GetAlbums());
            }
            catch (Exception ex)
            {
                ThrowSoapException(ex);
            }
            return null;

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetAlbumByIdJson(int id)
        {
            try
            {
                return new JavaScriptSerializer().Serialize(_repo.GetAlbumById(id));
            }
            catch (Exception ex)
            {
                ThrowSoapException(ex);
            }
            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetAlbumsByUserIdJson(int userId)
        {
            try
            {
                return new JavaScriptSerializer().Serialize(_repo.GetAlbumsByUserId(userId));
            }
            catch (Exception ex)
            {
                ThrowSoapException(ex);
            }
            return null;
        }

        #endregion
    }
}
