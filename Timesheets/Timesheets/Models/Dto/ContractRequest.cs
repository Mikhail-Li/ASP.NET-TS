using System;

namespace Timesheets.Models.Dto
{
    /// <summary> Информация о контракте для создания и обновления </summary>
    public class ContractRequest
    {
        public string Title { get; set; }
        public Guid ClientId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
