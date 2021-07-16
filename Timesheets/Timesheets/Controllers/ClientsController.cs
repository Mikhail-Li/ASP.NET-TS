using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : TimesheetBaseController
    {
        private readonly IClientManager _clientManager;

        public ClientsController (IClientManager clientManager)
        {
            _clientManager = clientManager;
        }

        /// <summary> Возвращает запись клиента по Id </summary>
        /// <returns>OK</returns>
        /// <response code="200">Запрос выполнен.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        [Authorize(Roles = "user, admin, manager")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient([FromRoute] Guid id)
        {
            var result = await _clientManager.GetClient(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary> Возвращает записи всех клиентов в БД </summary>
        /// <returns>OK</returns>
        /// <response code="200">Запрос выполнен.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        [Authorize(Roles = "user, admin, manager")]
        [HttpGet("clients")]
        public async Task<IActionResult> GetClients()
        {
            var result = await _clientManager.GetClients();
            return Ok(result);
        }

        /// <summary> Добавляет запись клиента и возвращает сгенерированный Id клиента </summary>
        /// <returns>OK</returns>
        /// <response code="200">Запись клиента создана.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера</response>
        [Authorize(Roles = "admin, manager")]
        [HttpPost("client")]
        public async Task<IActionResult> Create([FromBody] ClientRequest request)
        {
            var id = await _clientManager.CreateClient(request);

            return Ok(id);
        }

        /// <summary> Обновляет запись клиента. </summary>
        /// <response code="200">Запись клиента обновлена.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера</response>
        [Authorize(Roles = "admin, manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ClientRequest request)
        {
            await _clientManager.UpdateClient(id, request);

            return Ok();
        }

        /// <summary> Удаляет запись клиента по Id </summary>
        /// <response code="200">Запись клиента удалена.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера</response>
        [Authorize(Roles = "admin, manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _clientManager.DeleteClient(id);

            return Ok();
        }
    }

}