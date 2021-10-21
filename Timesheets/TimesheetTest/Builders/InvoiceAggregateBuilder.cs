using System;
using Timesheets.Domain.Aggregates;
using Timesheets.Models.Dto;

namespace TimesheetTest.Builders
{
    public class InvoiceAggregateBuilder
    {
        public Guid InvoiceContractId = Guid.NewGuid();
        public DateTime InvoiceDateStart = DateTime.MinValue;
        public DateTime InvoiceDateEnd = DateTime.Now;

        public InvoiceAggregate CreateRandomInvoice()
        {
            var invoiceRequest = new InvoiceRequest
            {
                ContractId = InvoiceContractId,
                DateStart = InvoiceDateStart,
                DateEnd = InvoiceDateEnd
            };

            var result = InvoiceAggregate.Create(invoiceRequest);

            return result;
        }

        public InvoiceRequest CreateRandomInvoiceRequest()
        {
            var result = new InvoiceRequest
            {
                ContractId = Guid.NewGuid(),
                DateStart = DateTime.MinValue.AddDays(1),
                DateEnd = DateTime.Now.AddSeconds(60)
            };

            return result;
        }

        public InvoiceAggregate UpdateInvoiceAggregate(Guid invoiceId, InvoiceRequest request)
        {
            var result = InvoiceAggregate.Update(invoiceId, request);

            return result;
        }
    }
}

