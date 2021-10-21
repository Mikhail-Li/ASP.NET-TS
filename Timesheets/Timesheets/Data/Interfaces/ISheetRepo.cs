using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Interfaces
{
    public interface ISheetRepo: IRepoBase<Sheet>
    {
        /// <summary> Возвращает перечень табелей за период для формирования счета.</summary>
        Task<IEnumerable<Sheet>> GetItemsForInvoice(InvoiceRequest request);
    }
}