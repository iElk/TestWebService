using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWebService.Model;
using TestWebService.Tools;
using TestWebService.Data;
using Moq;
using System.Web.Services.Protocols;

namespace TestWebService.Test
{
    /// <summary>
    /// Тесты веб сервиса
    /// </summary>
    [TestClass]
    public class WebService
    {

        #region User

        [TestMethod]
        public void TestGetUsersJson()
        {
            var service = new TestWebService();

            var res = service.GetUsersJson();

            Assert.IsInstanceOfType(res, typeof(string));
        }

        [TestMethod]
        public void TestGetUserJson()
        {
            var service = new TestWebService();

            var res = service.GetUserByIdJson(2);

            Assert.IsInstanceOfType(res, typeof(string));
        }

        [TestMethod]
        public void TestGetUsersXml()
        {
            var service = new TestWebService();

            var res = service.GetUsersXml();

            Assert.IsInstanceOfType(res, typeof(User[]));
        }

        [TestMethod]
        public void TestGetUserXml()
        {
            var service = new TestWebService();

            var res = service.GetUserByIdXml(2);

            Assert.IsInstanceOfType(res, typeof(User));
        }

        #endregion

        #region Album

        [TestMethod]
        public void TestGetAlbumsJson()
        {
            var service = new TestWebService();

            var res = service.GetAlbumsJson();

            Assert.IsInstanceOfType(res, typeof(string));
        }

        [TestMethod]
        public void TestGetAlbumsXml()
        {
            var service = new TestWebService();

            var res = service.GetAlbumsXml();

            Assert.IsInstanceOfType(res, typeof(Album[]));
        }

        [TestMethod]
        public void TestGetAlbumJson()
        {
            var service = new TestWebService();

            var res = service.GetAlbumByIdJson(5);

            Assert.IsInstanceOfType(res, typeof(string));
        }

        [TestMethod]
        public void TestGetAlbumXml()
        {
            var service = new TestWebService();

            var res = service.GetAlbumByIdXml(5);

            Assert.IsInstanceOfType(res, typeof(Album));
        }

        [TestMethod]
        public void TestGetAlbumUserJson()
        {
            var service = new TestWebService();

            var res = service.GetAlbumsByUserIdJson(5);

            Assert.IsInstanceOfType(res, typeof(string));
        }

        [TestMethod]
        public void TestGetAlbumUserXml()
        {
            var service = new TestWebService();

            var res = service.GetAlbumsByUserIdXml(5);

            Assert.IsInstanceOfType(res, typeof(Album[]));
        }

        #endregion

        #region Exception

        [TestMethod]
        [ExpectedException(typeof(SoapException))]
        public void TestRepoException()
        {
            var repo = new Mock<IRepository>();
            repo.Setup(r => r.GetUsers()).Throws(new Exception("Error"));

            var service = new TestWebService(repo.Object, new CryptographerMP5());

            var res = service.GetUsersXml();
        }

        [TestMethod]
        [ExpectedException(typeof(SoapException))]
        public void TestCryptoException()
        {
            var repo = new Mock<IRepository>();
            repo.Setup(r => r.GetUsers()).Returns(new User[] { new User() { id = 1, name = "test" } });

            var crypto = new Mock<ICryptographer>();
            crypto.Setup(c => c.Encrypt(It.IsAny<string>())).Throws(new Exception("Error"));

            var service = new TestWebService(repo.Object, crypto.Object);

            var res = service.GetUsersXml();
        }

        #endregion
    }
}
