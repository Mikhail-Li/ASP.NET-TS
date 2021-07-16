using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models.Entities;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface IInvoiceManager
    {
        /// <summary> Возвращаеь экземпляр счета по Id</summary>
        Task<Invoice> GetInvoice(Guid id);

        /// <summary> Возвращаеь все счета</summary>
        Task<IEnumerable<Invoice>> GetInvoices();

        /// <summary> Создает счет/summary>
        Task<Guid> CreateInvoice(InvoiceRequest invoiceRequest);

        /// <summary> Обновляет счет/summary>
        Task UpdateInvoice(Guid id, InvoiceRequest invoiceRequest);

        /// <summary> Удаляет счет/summary>
        Task DeleteInvoice(Guid id);
    }
}