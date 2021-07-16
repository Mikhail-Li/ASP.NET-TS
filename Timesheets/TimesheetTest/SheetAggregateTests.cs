using System;
using Xunit;
using FluentAssertions;
using TimesheetTest.Builders;

namespace TimesheetTest
{
    public class SheetAggregateTests
    {
        [Fact]
        public void SheetAggregate_CreateRandomSheetFromSheetRequest()
        {
            var sheetBuilder = new SheetAggregateBuilder();
            var sheet = sheetBuilder.CreateRandomSheet();

            sheet.Amount.Should().Be(sheetBuilder.Amount);
            sheet.ContractId.Should().Be(sheetBuilder.SheetContractId);
            sheet.EmployeeId.Should().Be(sheetBuilder.SheetEmployeeId);
            sheet.ServiceId.Should().Be(sheetBuilder.SheetServiceId);
            sheet.Date.Should().BeExactly(TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds()));
        }

        [Fact]
        public void SheetAggregate_UpdateSheetFromIdAndSheetRequest()
        {
            var sheetBuilder = new SheetAggregateBuilder();
            
            var sheet = sheetBuilder.CreateRandomSheet();
            var newSheetRequest = sheetBuilder.CreateRandomSheetRequest();

            var updatedSheet = sheetBuilder.UpdateSheetAggregate(newSheetRequest, sheet);

            updatedSheet.Id.Should().Be(sheet.Id);
            updatedSheet.Amount.Should().Be(newSheetRequest.Amount);
            updatedSheet.ContractId.Should().Be(newSheetRequest.ContractId);
            updatedSheet.EmployeeId.Should().Be(newSheetRequest.EmployeeId);
            updatedSheet.ServiceId.Should().Be(newSheetRequest.ServiceId);
            updatedSheet.Date.Should().Be(newSheetRequest.Date);
            updatedSheet.InvoiceId.Should().Be(sheet.InvoiceId);
            updatedSheet.IsApproved.Should().Be(sheet.IsApproved);
            updatedSheet.ApprovedDate.Should().Be(sheet.ApprovedDate);
        }
    }
}
