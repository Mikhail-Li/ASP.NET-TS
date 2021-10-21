using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models.Entities;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface IServiceManager
    {
        /// <summary> Возвращает экземпляр записи сервиса.</summary>
        Task<Service> GetService(Guid id);

        /// <summary> Возвращает список записей сервисов.</summary>
        Task<IEnumerable<Service>> GetServices();

        /// <summary> Добавляет запись сервиса.</summary>
        Task<Guid> CreateService(ServiceRequest request);

        /// <summary> Обновляет запись сервиса.</summary>
        Task UpdateService(Guid id, ServiceRequest request);

        /// <summary> Удаляет запись сервиса.</summary>
        Task DeleteService(Guid id);
    }
}