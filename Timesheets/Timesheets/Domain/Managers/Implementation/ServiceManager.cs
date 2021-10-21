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
    public class ServiceManager: IServiceManager
    {
        private readonly IServiceRepo _serviceRepo;

        public ServiceManager(IServiceRepo serviceRepo)
        {
            _serviceRepo=serviceRepo;
        }

        public async Task<Service> GetService(Guid id)
        {
            return await _serviceRepo.GetItem(id);
        }

        public async Task<IEnumerable<Service>> GetServices()
        {
            return await _serviceRepo.GetItems();
        }

        public async Task<Guid> CreateService(ServiceRequest request)
        {
            request.EnsureNotNull(nameof(request));

            var service = new Service()
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _serviceRepo.Add(service);

            return service.Id;
        }

        public async Task UpdateService(Guid id, ServiceRequest request)
        {
            request.EnsureNotNull(nameof(request));

            var service = new Service()
            {
                Id = id,
                Name = request.Name
            };

            await _serviceRepo.Update(service);
        }

        public async Task DeleteService(Guid id)
        {
            await _serviceRepo.Delete(id);
        }

    }
}