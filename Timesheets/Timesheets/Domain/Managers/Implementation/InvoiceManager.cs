using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Infrastructure.Extensions;
using Timesheets.Models.Entities;
using Timesheets.Models.Dto;

using Timesheets.Domain.Aggregates;

namespace Timesheets.Domain.Managers.Implementation
{
    public class InvoiceManager : IInvoiceManager
    {
        private readonly IInvoiceRepo _invoiceRepo;
        private readonly ISheetRepo _sheetRepo;

        public InvoiceManager(IInvoiceRepo invoiceRepo, ISheetRepo sheetRepo)
        {
            _invoiceRepo = invoiceRepo;
            _sheetRepo = sheetRepo;
        }

        /// <summary> Возвращаеь экземпляр счета по Id</summary>
        public async Task<Invoice> GetInvoice(Guid id)
        {
            return await _invoiceRepo.GetItem(id);
        }

        /// <summary> Возвращаеь все счета</summary>
        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            return await _invoiceRepo.GetItems();
        }

        /// <summary> Создает счет</summary>
        public async Task<Guid> CreateInvoice(InvoiceRequest request)
        {
            request.EnsureNotNull(nameof(request));

            var invoice = InvoiceAggregate.Create(request);

            var sheetsToInclude = await _sheetRepo
                .GetItemsForInvoice(request);

            invoice.IncludeSheets(sheetsToInclude);
            
            await _invoiceRepo.Add(invoice);

            return invoice.Id;
        }

        /// <summary> Обновляет счет</summary>
        public async Task UpdateInvoice(Guid invoiceId, InvoiceRequest request)
        {
            request.EnsureNotNull(nameof(request));

            var invoice = InvoiceAggregate.Update(invoiceId, request);

            var sheetsToInclude = await _sheetRepo
                .GetItemsForInvoice(request);

            invoice.IncludeSheets(sheetsToInclude);

            await _invoiceRepo.Update(invoice);
        }

        /// <summary> Удаляет счет </summary>
        public async Task DeleteInvoice(Guid id)
        {
            await _invoiceRepo.Delete(id);
        }
    }
}