using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface IContractManager
    {
        /// <summary> Возвращает экземпляр записи контракта</summary>
        Task<Contract> GetContract(Guid id);

        /// <summary> Возвращает список записей контрактов </summary>
        Task<IEnumerable<Contract>> GetContracts();

        /// <summary> Добавляет запись контракта </summary>
        Task<Guid> CreateContract(ContractRequest request);

        /// <summary> Обновляет запись контракта </summary>
        Task UpdateContract(Guid id, ContractRequest request);

        /// <summary> Удаляет запись контракта </summary>
        Task DeleteContract(Guid id);

        /// <summary> Проверяет контракт на актуальность</summary>
        Task<bool?> CheckContractIsActive(Guid id);
    }
}