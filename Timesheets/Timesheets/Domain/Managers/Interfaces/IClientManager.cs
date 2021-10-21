using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models.Entities;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface IClientManager
    {
        /// <summary> Возвращает экземпляр записи клиента.</summary>
        Task<Client> GetClient(Guid id);

        /// <summary> Возвращает список записей клиентов.</summary>
        Task<IEnumerable<Client>> GetClients();

        /// <summary> Добавляет запись клиента.</summary>
        Task<Guid> CreateClient(ClientRequest request);

        /// <summary> Обновляет запись клиента.</summary>
        Task UpdateClient(Guid id, ClientRequest request);

        /// <summary> Удаляет запись клиента.</summary>
        Task DeleteClient(Guid id);
    }
}