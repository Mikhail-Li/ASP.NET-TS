using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Dto
{
    /// <summary> Информация о клиенте для создания и обновления </summary>
    public class ClientRequest
    {
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}