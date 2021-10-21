using System;
using Xunit;
using FluentAssertions;
using TimesheetTest.Builders;

namespace TimesheetTest
{
    public class InvoiceAggregateTests
    {
        [Fact]
        public void InvoiceAggregate_CreateRandomInvoiceFromInvoiceRequest()
        {
            var invoiceBuilder = new InvoiceAggregateBuilder();
            var invoice = invoiceBuilder.CreateRandomInvoice();

            invoice.ContractId.Should().Be(invoiceBuilder.InvoiceContractId);
            invoice.DateStart.Should().Be(invoiceBuilder.InvoiceDateStart);
            invoice.DateEnd.Should().BeExactly(TimeSpan.FromSeconds(DateTimeOffset.Now.ToUnixTimeSeconds()));
        }

        [Fact]
        public void InvoiceAggregate_UpdateInvoiceFromIdAndinvoiceRequest()
        {
            var invoiceBuilder = new InvoiceAggregateBuilder();

            var invoice = invoiceBuilder.CreateRandomInvoice();
            var newInvoiceRequest = invoiceBuilder.CreateRandomInvoiceRequest();

            var updatedInvoice = invoiceBuilder.UpdateInvoiceAggregate(invoice.Id, newInvoiceRequest);

            updatedInvoice.Id.Should().Be(invoice.Id);
            updatedInvoice.ContractId.Should().Be(newInvoiceRequest.ContractId);
            updatedInvoice.DateStart.Should().Be(newInvoiceRequest.DateStart);
            updatedInvoice.DateEnd.Should().Be(newInvoiceRequest.DateEnd);
        }

        [Fact]
        public void InvoiceAggregate_IncludeSheetsInInvoice_CalculateSumInInvoice()
        {
            var invoiceBuilder = new InvoiceAggregateBuilder();
            var invoice = invoiceBuilder.CreateRandomInvoice();
            var sheetBuilder = new SheetAggregateBuilder();
            var sheets = sheetBuilder.GetSheetsForInvoice();

            invoice.IncludeSheets(sheets);

            var sheetEnumerator = sheets.GetEnumerator();

            int i = 0;

            while (sheetEnumerator.MoveNext())
            {
                invoice.Sheets[i].Should().Be(sheetEnumerator.Current);
                i++;
            }
        }
    }
}
