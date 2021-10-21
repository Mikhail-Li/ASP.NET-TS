using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models.Entities;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface IEmployeeManager
    {
        /// <summary> Возвращает экземпляр записи работника.</summary>
        Task<Employee> GetEmployee(Guid id);

        /// <summary> Возвращает список записей работников.</summary>
        Task<IEnumerable<Employee>> GetEmployees();

        /// <summary> Добавляет запись работника.</summary>
        Task<Guid> CreateEmployee(EmployeeRequest request);

        /// <summary> Обновляет запись работника.</summary>
        Task UpdateEmployee(Guid id, EmployeeRequest request);

        /// <summary> Удаляет запись работника.</summary>
        Task DeleteEmployee(Guid id);
    }
}
