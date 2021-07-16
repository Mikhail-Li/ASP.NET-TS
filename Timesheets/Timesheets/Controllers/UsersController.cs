using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    /// <summary> Создание, изменение, удаление и просмотр пользователей доступно с ролью "admin"</summary>
    [Authorize(Roles = "admin, manager")]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : TimesheetBaseController
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary> Возвращает список всех пользователей из БД</summary>
        /// <returns>OK</returns>
        /// <response code="200">Запрос выполнен успешно</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера</response>
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userManager.GetUsers();
            return Ok(result);
        }

        /// <summary> Добавляет запись нового пользователя и возвращает сгенерированный Id нового пользователя </summary>
        /// <returns>OK</returns>
        /// <response code="200">Запись нового пользователя добавлена</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера</response>
        [HttpPost("user")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var id = await _userManager.CreateUser(request);
            return Ok(id);
        }

        /// <summary> Обновляет запись пользователя </summary>
        /// <returns>OK</returns>
        /// <response code="200">Запись пользователя обновлена</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CreateUserRequest request)
        {
            await _userManager.UpdateUser(id, request);

            return Ok();
        }

        /// <summary> Удаляет запись пользователя по Id </summary>
        /// <response code="200">Запись пользователя удалена</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _userManager.DeleteUser(id);

            return Ok();
        }
    }
}