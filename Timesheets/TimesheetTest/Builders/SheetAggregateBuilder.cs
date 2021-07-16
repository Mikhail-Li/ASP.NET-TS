using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Domain.Aggregates.SheetAggregate;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace TimesheetTest.Builders 
{ 
    public class SheetAggregateBuilder
    {
        public int Amount = 7;
        public Guid SheetContractId = Guid.Parse("42e7a301-e8ea-4139-93dd-a0c0d6ea3a42");
        public Guid SheetEmployeeId = Guid.NewGuid();
        public Guid SheetServiceId = Guid.NewGuid();

        /// <summary>
        /// Создает экземпляр SheetAggregate в целях тестирования
        /// </summary>
        public SheetAggregate CreateRandomSheet()
        {
            var sheetRequest = new SheetRequest()
            {
                Amount = Amount,
                ServiceId = SheetServiceId,
                ContractId = SheetContractId,
                EmployeeId = SheetEmployeeId,
                Date = DateTime.Now
            };

            var result = SheetAggregate.CreateSheet(sheetRequest);

            return result;
        }

        /// <summary>
        /// Создает экземпляра SheetRequest в целях тестирования
        /// </summary>
        public SheetRequest CreateRandomSheetRequest()
        {
            var result = new SheetRequest()
            {
                Amount = 5,
                Date = DateTime.UtcNow,
                ContractId = Guid.NewGuid(),
                EmployeeId = Guid.NewGuid(),
                ServiceId = Guid.NewGuid()
            };
            
            return result;
        }

        /// <summary>
        /// Обновляет экземпляр SheetAggregate 
        /// </summary>
        public SheetAggregate UpdateSheetAggregate(SheetRequest request, SheetAggregate sheet)
        {
            var result = SheetAggregate.UpdateSheet(sheet.Id, request, sheet);

            return result;
        }

        /// <summary>
        /// Создает и возвращает коллекцию IEnumerable<Sheet>
        /// </summary>
        public IEnumerable<Sheet> GetSheetsForInvoice()
        {
            var sheetBuilder = new SheetAggregateBuilder();
            var sheet1 = sheetBuilder.CreateRandomSheet();
            var sheet2 = sheetBuilder.CreateRandomSheet();
            var sheet3 = sheetBuilder.CreateRandomSheet();

           return new Sheet[] { sheet1, sheet2, sheet3};
        }
    }
}