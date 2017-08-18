using TestWebService.Helpers;
using TestWebService.Model;
using System.Web.Script.Serialization;
using System;

namespace TestWebService.Data
{
    /// <summary>
    /// Репозиторий
    /// </summary>
    internal class RepositoryLoginet : IRepository
    {
        public User[] GetUsers()
        {
            return new JavaScriptSerializer().Deserialize<User[]>(ResponseApiHelper.GetResponseJson("http://jsonplaceholder.typicode.com/users"));
        }

        public User GetUserById(int id)
        {
            return new JavaScriptSerializer().Deserialize<User>(ResponseApiHelper.GetResponseJson("http://jsonplaceholder.typicode.com/users/" + id));
        }

        public Album[] GetAlbums()
        {
            return new JavaScriptSerializer().Deserialize<Album[]>(ResponseApiHelper.GetResponseJson("http://jsonplaceholder.typicode.com/albums"));
        }

        public Album GetAlbumById(int id)
        {
            return new JavaScriptSerializer().Deserialize<Album>(ResponseApiHelper.GetResponseJson("http://jsonplaceholder.typicode.com/albums/" + id));
        }

        public Album[] GetAlbumsByUserId(int userId)
        {
            return new JavaScriptSerializer().Deserialize<Album[]>(ResponseApiHelper.GetResponseJson("http://jsonplaceholder.typicode.com/albums?userId=" + userId));
        }
    }
}