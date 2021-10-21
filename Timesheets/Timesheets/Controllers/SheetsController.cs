using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Timesheets.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SheetsController: TimesheetBaseController
    {
        private readonly ISheetManager _sheetManager;
        private readonly IContractManager _contractManager;
        private readonly IEmployeeManager _employeeManager;
        
        public SheetsController(ISheetManager sheetManager, IContractManager contractManager, IEmployeeManager employeeManager)
        {
            _sheetManager = sheetManager;
            _contractManager = contractManager;
            _employeeManager = employeeManager;
        }

        /// <summary> Возвращает экземпляр счета по Id.</summary>
        /// <returns>OK</returns>
        /// <response code="200">Запрос выполнен успешно.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="404">Запись табеля не найдена.</response>
        [Authorize(Roles = "user, admin, manager")]
        [HttpGet("{sheetId}")]
        public async Task<IActionResult> GetSheet([FromRoute] Guid sheetId)
        {
            var result = await _sheetManager.GetSheet(sheetId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        ///<summary> Возвращает список всех табелей из БД.</summary>
        /// <returns>OK</returns>
        /// <response code="200">Запрос выполнен успешно.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        [Authorize(Roles = "user, admin, manager")]
        [HttpGet("sheets")]
        public async Task<IActionResult> GetSheets()
        {
            var result = await _sheetManager.GetSheets();
            return Ok(result);
        }

        /// <summary> Добавляет запись табеля и возвращает сгенерированный Id нового табеля.</summary>
        /// <returns>OK</returns>
        /// <response code="200">Табель успешно создан.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера.</response>
        [Authorize(Roles = "user, admin, manager")]
        [HttpPost("sheet")]
        public async Task<IActionResult> Create([FromBody] SheetRequest request)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(request.ContractId);

            if (isAllowedToCreate !=null && !(bool)isAllowedToCreate)
            {
                return BadRequest($"Contract {request.ContractId} is not active or not found.");
            }
            
            var id = await _sheetManager.CreateSheet(request);
            return Ok(id);
        }

        /// <summary> Обновляет данные записи табеля.</summary>
        /// <returns>OK</returns>
        /// <response code="200">Табель успешно обновлен.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера.</response>
        [Authorize(Roles = "admin, manager")]
        [HttpPut("update/{sheetId}")]
        public async Task<IActionResult> Update([FromRoute] Guid sheetId, [FromBody] SheetRequest request)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(request.ContractId);

            if (isAllowedToCreate !=null && !(bool)isAllowedToCreate)
            {
                return BadRequest($"Contract {request.ContractId} is not active or not found.");
            }

            await _sheetManager.UpdateSheet(sheetId, request);

            return Ok();
        }

        /// <summary> Удаляет запись табеля по Id.</summary> //UnApproveSheet
        /// <returns>OK</returns>
        /// <response code="200">Запись табеля удалена.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера.</response>
        [Authorize(Roles = "admin, manager")]
        [HttpDelete("{sheetId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid sheetId)
        {
            await _sheetManager.DeleteSheet(sheetId);

            return Ok();
        }
    }
}