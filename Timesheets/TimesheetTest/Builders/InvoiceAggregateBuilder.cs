using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Domain.Aggregates.InvoiceAggregate;
using Timesheets.Models.Dto;

namespace TimesheetTest.Builders
{
    public class InvoiceAggregateBuilder
    {
        public Guid InvoiceContractId = Guid.NewGuid();
        public DateTime InvoiceDateStart = DateTime.MinValue;
        public DateTime InvvoiceDateEnd = DateTime.Now;

        public InvoiceAggregate CreateRandomInvoice()
        {
            var invoiceRequest = new InvoiceRequest
            {
                ContractId = InvoiceContractId,
                DateStart = InvoiceDateStart,
                DateEnd = InvvoiceDateEnd
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

