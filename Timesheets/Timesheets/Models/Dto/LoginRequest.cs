
namespace Timesheets.Models.Dto
{
    /// <summary> Информация для процесса аутентификации пользователя </summary>
    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
