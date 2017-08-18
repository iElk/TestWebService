using TestWebService.Model;

namespace TestWebService.Data
{
    /// <summary>
    /// Интерфейс репозитория
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Получить массив всех пользователей
        /// </summary>
        /// <returns>Массив пользователей</returns>
        User[] GetUsers();

        /// <summary>
        /// Получить пользователя
        /// </summary>
        /// <param name="id">ИД пользователя</param>
        /// <returns>Пользователь</returns>
        User GetUserById(int id);

        /// <summary>
        /// Получить массив всех альбомов
        /// </summary>
        /// <returns>Массив альбомов</returns>
        Album[] GetAlbums();

        /// <summary>
        /// Получить альбом
        /// </summary>
        /// <param name="id">ИД альбома</param>
        /// <returns>Альбом</returns>
        Album GetAlbumById(int id);

        /// <summary>
        /// Получить массив альбомов пользователя
        /// </summary>
        /// <param name="userId">ИД пользователя</param>
        /// <returns>Массив альбомов</returns>
        Album[] GetAlbumsByUserId(int userId);
    }
}