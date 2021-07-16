using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Aggregates.SheetAggregate
{
    public interface ISheetAggregateRepo
    {
        Task<SheetAggregate> GetSheet(Guid id);
        Task<IEnumerable<SheetAggregate>> GetSheets();
        Task<Guid> AddSheet(SheetAggregate item);
        Task UpdateSheet(SheetAggregate item);
    }
}
