
namespace Timesheets.Models.Dto
{
    /// <summary> Информация о токенах и сроке действия.</summary>
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        
        // пока не реализован
        public string RefreshToken { get; set; } 
        
        public long ExpiresIn { get; set; }
    }
}
