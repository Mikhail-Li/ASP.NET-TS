using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ServicesController : TimesheetBaseController
    {
        private readonly IServiceManager _serviceManager;

        public ServicesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary> Возвращает запись сервиса по Id.</summary>
        /// <returns>OK</returns>
        /// <response code="200">Запрос выполнен.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        [Authorize(Roles = "user, admin, manager")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService ([FromRoute] Guid id)
        {
            var result = await _serviceManager.GetService(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary> Возвращает записи всех сервисов в БД.</summary>
        /// <returns>OK</returns>
        /// <response code="200">Запрос выполнен.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        [Authorize(Roles = "user, admin, manager")]
        [HttpGet("services")]
        public async Task<IActionResult> GetServices()
        {
            var result = await _serviceManager.GetServices();
            return Ok(result);
        }

        /// <summary> Добавляет запись сервиса и возвращает сгенерированный Id сервиса.</summary>
        /// <returns>OK</returns>
        /// <response code="200">Запись сервиса создана.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера.</response>
        [Authorize(Roles = "admin, manager")]
        [HttpPost("service")]
        public async Task<IActionResult> Create([FromBody] ServiceRequest request)
        {
            var id = await _serviceManager.CreateService(request);

            return Ok(id);
        }

        /// <summary> Обновляет запись сервиса.</summary>
        /// <response code="200">Запись сервиса обновлена.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера.</response>
        [Authorize(Roles = "admin, manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ServiceRequest request)
        {
            await _serviceManager.UpdateService(id, request);

            return Ok();
        }

        /// <summary> Удаляет запись сервиса по Id.</summary>
        /// <response code="200">Запись сервиса удалена.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера.</response>
        [Authorize(Roles = "admin, manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _serviceManager.DeleteService(id);

            return Ok();
        }
    }

}