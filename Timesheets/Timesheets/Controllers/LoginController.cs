using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : TimesheetBaseController
    {
        private readonly IUserManager _userManager;
        private readonly ILoginManager _loginManager;

        public LoginController(ILoginManager loginManager, IUserManager userManager)
        {
            _loginManager = loginManager;
            _userManager = userManager;
        }

        /// <summary> Аутентификация пользователя. Возвращает Access Token.</summary>
        /// <returns>OK</returns>
        /// <response code="200">Аутентификация выполнена.</response>
        /// <response code="401">Ошибка аутентификации.</response>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.GetUserByLoginAndPasswordHash(request);

            if (user == null)
            {
                return Unauthorized();
            }

            var loginResponse = await _loginManager.Authenticate(user);

            return Ok(loginResponse);
        }
    }
}
