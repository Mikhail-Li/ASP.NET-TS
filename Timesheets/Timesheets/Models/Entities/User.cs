using System;
using System.Collections.Generic;

namespace Timesheets.Models.Entities
{
    /// <summary> Информация о пользователе системы.</summary>
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; }

        public ICollection<Employee> Employee { get; set; }

        public ICollection<Client> Client { get; set; }
    }
}