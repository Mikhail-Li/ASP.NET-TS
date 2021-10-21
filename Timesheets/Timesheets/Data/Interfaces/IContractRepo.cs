using System;
using System.Threading.Tasks;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Interfaces
{
    public interface IContractRepo: IRepoBase<Contract>
    {
        /// <summary> Проверяет контракт на актуальность.</summary>
        Task<bool?> CheckContractIsActive(Guid id);
    }
}