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
    public class ContractController : TimesheetBaseController
    {
        private readonly IContractManager _contractManager;

        public ContractController(IContractManager contractManager)
        {
            _contractManager = contractManager;
        }

        /// <summary> Возвращает запись конт контракта по Id </summary>
        /// <returns>OK</returns>
        /// <response code="200">Запрос выполнен.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        [Authorize(Roles = "user, admin, manager")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContract([FromRoute] Guid id)
        {
            var result = await _contractManager.GetContract(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary> Возвращает записи всех контрактов в БД </summary>
        /// <returns>OK</returns>
        /// <response code="200">Запрос выполнен.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        [Authorize(Roles = "user, admin, manager")]
        [HttpGet("contracts")]
        public async Task<IActionResult> GetContracts()
        {
            var result = await _contractManager.GetContracts();
            return Ok(result);
        }

        /// <summary> Добавляет запись контракта и возвращает сгенерированный Id контракта </summary>
        /// <returns>OK</returns>
        /// <response code="200">Запись контракта создана.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера</response>
        [Authorize(Roles = "admin, manager")]
        [HttpPost("contract")]
        public async Task<IActionResult> Create([FromBody] ContractRequest request)
        {
            var id = await _contractManager.CreateContract(request);

            return Ok(id);
        }

        /// <summary> Обновляет запись контракта. </summary>
        /// <response code="200">Запись контракта обновлена.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера</response>
        [Authorize(Roles = "admin, manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ContractRequest request)
        {
            await _contractManager.UpdateContract(id, request);

            return Ok();
        }

        /// <summary> Удаляет запись контракта по Id </summary>
        /// <response code="200">Запись контракта удалена.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера</response>
        [Authorize(Roles = "admin, manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _contractManager.DeleteContract(id);

            return Ok();
        }
    }

}
