using System;
using System.Collections.Generic;

namespace Timesheets.Models.Entities
{
    /// <summary> Информация о владельце контракта.</summary>
    public class Client
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        
        public string Title { get; set; }
        public bool IsDeleted { get; set; }

        public User User { get; set; }
        
        public ICollection<Contract> Contracts { get; set; }
    }
}