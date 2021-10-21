using System;

namespace Timesheets.Models.Dto
{
    /// <summary> Информация о сотруднике для создания и обновления.</summary>
    public class EmployeeRequest
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public bool IsDeleted { get; set; }
    }
}
