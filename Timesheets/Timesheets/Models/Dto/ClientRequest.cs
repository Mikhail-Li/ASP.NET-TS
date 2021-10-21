using System;

namespace Timesheets.Models.Dto
{
    /// <summary> Информация о клиенте для создания и обновления </summary>
    public class ClientRequest
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
    }
}