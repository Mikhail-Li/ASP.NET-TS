using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;
using Timesheets.Infrastructure.Extensions;

namespace Timesheets.Domain.Managers.Implementation
{
    public class ContractManager: IContractManager
    {
        private readonly IContractRepo _contractRepo;

        public ContractManager(IContractRepo contractRepo)
        {
            _contractRepo = contractRepo;
        }

        public async Task<Contract> GetContract(Guid id)
        {
            return await _contractRepo.GetItem(id);
        }

        public async Task<IEnumerable<Contract>> GetContracts()
        {
            return await _contractRepo.GetItems();
        }

        public async Task<Guid> CreateContract(ContractRequest request)
        {
            request.EnsureNotNull(nameof(request));

            var contract = new Contract()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                DateStart = request.DateStart,
                DateEnd = request.DateEnd,
                Description = request.Description,                
                IsDeleted = request.IsDeleted
            };

            await _contractRepo.Add(contract);

            return contract.Id;
        }

        public async Task UpdateContract(Guid id, ContractRequest request)
        {
            request.EnsureNotNull(nameof(request));

            var contract = new Contract()
            {
                Id = id,
                Title = request.Title,
                DateStart = request.DateStart,
                DateEnd = request.DateEnd,
                Description = request.Description,
                IsDeleted = request.IsDeleted
            };

            await _contractRepo.Update(contract);
        }

        public async Task DeleteContract(Guid id)
        {
            await _contractRepo.Delete(id);
        }

        public async Task<bool?> CheckContractIsActive(Guid id)
        {
            return await _contractRepo.CheckContractIsActive(id);
        }
    }
}