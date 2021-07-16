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
    public class EmployeesController : TimesheetBaseController
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        /// <summary> Возвращает запись работника по Id </summary>
        /// <returns>OK</returns>
        /// <response code="200">Запрос выполнен.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        [Authorize(Roles = "user, admin, manager")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var result = await _employeeManager.GetEmployee(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary> Возвращает записи всех работников в БД </summary>
        /// <returns>OK</returns>
        /// <response code="200">Запрос выполнен.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        [Authorize(Roles = "user, admin, manager")]
        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var result = await _employeeManager.GetEmployees();
            return Ok(result);
        }

        /// <summary> Добавляет запись сотрудника и возвращает сгенерированный Id работника </summary>
        /// <returns>OK</returns>
        /// <response code="200">Запись сотрудника создана.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера</response>
        [Authorize(Roles = "admin, manager")]
        [HttpPost("employee")]
        public async Task<IActionResult> Create([FromBody] EmployeeRequest request)
        {
            var id = await _employeeManager.CreateEmployee(request);

            return Ok(id);
        }

        /// <summary> Обновляет запись работника </summary>
        /// <response code="200">Запись сотрудника обновлена.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера</response>
        [Authorize(Roles = "admin, manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EmployeeRequest request)
        {
            await _employeeManager.UpdateEmployee(id, request);

            return Ok();
        }

        /// <summary> Удаляет запись работника по Id </summary>
        /// <response code="200">Запись сотрудника удалена.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера</response>
        [Authorize(Roles = "admin, manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _employeeManager.DeleteEmployee(id);

            return Ok();
        }
    }

}