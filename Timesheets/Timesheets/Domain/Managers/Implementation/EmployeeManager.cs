using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models.Entities;
using Timesheets.Models.Dto;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Infrastructure.Extensions;

namespace Timesheets.Domain.Managers.Implementation
{
    public class EmployeeManager: IEmployeeManager
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeManager(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<Employee> GetEmployee(Guid id)
        {
            return await _employeeRepo.GetItem(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepo.GetItems();
        }

        public async Task<Guid> CreateEmployee(EmployeeRequest request)
        {
            request.EnsureNotNull(nameof(request));

            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Name = request.Name,
                Post =request.Post,
                IsDeleted = request.IsDeleted
            };

            await _employeeRepo.Add(employee);

            return employee.Id;
        }

        public async Task UpdateEmployee(Guid id, EmployeeRequest request)
        {
            request.EnsureNotNull(nameof(request));

            var employee = new Employee()
            {
                Id = id,
                UserId = request.UserId,
                Name = request.Name,
                Post =request.Post,
                IsDeleted = request.IsDeleted
            };

            await _employeeRepo.Update(employee);
        }

        public async Task DeleteEmployee(Guid id)
        {
            await _employeeRepo.Delete(id);
        }

    }
}

