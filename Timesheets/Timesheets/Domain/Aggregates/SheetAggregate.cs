using System;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace Timesheets.Domain.Aggregates
{
    public class SheetAggregate : Sheet
    {
        private SheetAggregate() { }

        /// <summary> Создает табель </summary>
        public static SheetAggregate CreateSheet(SheetRequest request)
        {
            return new SheetAggregate()
            {
                Id = Guid.NewGuid(),
                Amount = request.Amount,
                ContractId = request.ContractId,
                Date = request.Date,
                EmployeeId = request.EmployeeId,
                ServiceId = request.ServiceId
            };
        }

        /// <summary> Обновляет табель</summary>
        public static SheetAggregate UpdateSheet(Guid sheetId, SheetRequest request, Sheet sheet)
        {
            return new SheetAggregate()
            {
                Id = sheetId,
                Amount = request.Amount,
                ContractId = request.ContractId,
                Date = request.Date,
                EmployeeId = request.EmployeeId,
                ServiceId = request.ServiceId,
                InvoiceId = sheet.InvoiceId,
                IsApproved = sheet.IsApproved,
                ApprovedDate = sheet.ApprovedDate
            };
        }
    }
}
