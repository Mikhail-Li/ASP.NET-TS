using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models.Entities;

namespace Timesheets.Domain.Aggregates.InvoiceAggregate
{
    public interface IInvoiceAggregateRepo 
    {
        Task<InvoiceAggregate> GetInvoice(Guid id);
        Task<IEnumerable<InvoiceAggregate>> GetInvoices();
        Task AddInvoice(InvoiceAggregate item);
        Task UpdateInvoice(InvoiceAggregate item);
        Task<IEnumerable<SheetAggregate.SheetAggregate>> GetSheets(Guid contractId, DateTime dateStart, DateTime dateEnd);
    }
}