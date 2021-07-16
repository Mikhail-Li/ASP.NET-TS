using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Dto
{
    /// <summary> Информация о сотруднике для создания и обновления </summary>
    public class EmployeeRequest
    {
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
