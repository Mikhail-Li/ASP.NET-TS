using System.Threading.Tasks;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Interfaces
{
    public interface IUserRepo: IRepoBase<User>
    {
        /// <summary> Возвращает запись пользователя.</summary>
        Task<User> GetByLoginAndPasswordHash(string login, byte[] passwordHash);
    }
}