using System;
using System.Collections.Generic;

namespace Timesheets.Models.Entities
{
    /// <summary> Информация о работнике.</summary>
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        
        public string Name { get; set; }
        
        public string Post { get; set; }
        public bool IsDeleted { get; set; }

        public User User { get; set; }

        public ICollection<Sheet> Sheets { get; set; }
    }
}