using System;
using System.Collections.Generic;
using System.Linq;
using Timesheets.Domain.ValueObjects;
using Timesheets.Models.Entities;
using Timesheets.Infrastructure.Constants;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Aggregates
{
    public class InvoiceAggregate : Invoice
    {
        private InvoiceAggregate() { }

        /// <summary> Создает счет</summary>
        public static InvoiceAggregate Create(InvoiceRequest request)
        {
            return new InvoiceAggregate()
            {
                Id = Guid.NewGuid(),
                ContractId = request.ContractId,
                DateEnd = request.DateEnd,
                DateStart = request.DateStart
            };
        }

        /// <summary> Обновляет счет</summary>
        public static InvoiceAggregate Update(Guid invoiceId, InvoiceRequest request)
        {
            return new InvoiceAggregate()
            {
                Id = invoiceId,
                ContractId = request.ContractId,
                DateEnd = request.DateEnd,
                DateStart = request.DateStart
            };
        }

        /// <summary> Добавляет табели и сумму к счету</summary>
        public void IncludeSheets(IEnumerable<Sheet> sheets)
        {
            Sheets.AddRange(sheets);
            CalculateSum();
        }

        /// <summary> Вычисляет сумму счета</summary>
        private void CalculateSum()
        {
            var amount = Sheets.Sum(x => x.Amount * TariffRate.tariffHourlyRate);
            Sum = Money.FromDecimal(amount);
        }
    }   
}
