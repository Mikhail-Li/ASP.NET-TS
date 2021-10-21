using System;

namespace Timesheets.Models.Dto
{
    /// <summary> Информация о табеле для создания и обновления.</summary>
    public class SheetRequest
    {
        public DateTime Date { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ContractId { get; set; }
        public Guid ServiceId { get; set; }
        public int Amount { get; set; }
    }
}