using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models.Entities;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface IUserManager
    {
        /// <summary> Возвращает экземпляр записи пользователя по Имени и паролю</summary>
        Task<User> GetUserByLoginAndPasswordHash(LoginRequest request);

        /// <summary> Возвращает список записей пользователей </summary>
        Task<IEnumerable<User>> GetUsers();

        /// <summary> Добавляет запись пользователя </summary>
        Task<Guid> CreateUser(CreateUserRequest request);

        /// <summary> Обновляет запись пользователя </summary>
        Task UpdateUser(Guid id, CreateUserRequest request);

        /// <summary> Удаляет запись пользователя </summary>
        Task DeleteUser(Guid id);
    }
}