﻿
namespace Timesheets.Models.Dto
{
    /// <summary> Информация о пользователе для создания и обновления.</summary>
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
