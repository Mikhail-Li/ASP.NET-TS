using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models.Entities;
using Timesheets.Models.Dto;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Infrastructure.Extensions;

namespace Timesheets.Domain.Managers.Implementation
{
    public class ClientManager : IClientManager
    {
        private readonly IClientRepo _clientRepo;

        public ClientManager(IClientRepo clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public async Task<Client> GetClient(Guid id)
        {
            return await _clientRepo.GetItem(id);
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _clientRepo.GetItems();
        }

        public async Task<Guid> CreateClient(ClientRequest request)
        {
            request.EnsureNotNull(nameof(request));

            var client = new Client()
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                IsDeleted = request.IsDeleted
            };

            await _clientRepo.Add(client);

            return client.Id;
        }

        public async Task UpdateClient(Guid id, ClientRequest request)
        {
            request.EnsureNotNull(nameof(request));

            var client = new Client()
            {
                Id = id,
                UserId = request.UserId,
                IsDeleted = request.IsDeleted
            };

            await _clientRepo.Update(client);
        }

        public async Task DeleteClient(Guid id)
        {
            await _clientRepo.Delete(id);
        }

    }
}
