using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Timesheets.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class InvoicesController : TimesheetBaseController
    {
        private readonly IInvoiceManager _invoiceManager;

        public InvoicesController(IInvoiceManager invoiceManager)
        {
            _invoiceManager = invoiceManager;
        }

        /// <summary> Возвращает клиентский счет по id.</summary>
        /// <returns>OK</returns>
        /// <response code="200">Запрос выполнен.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        [Authorize(Roles = "user, admin, client")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoice([FromRoute] Guid id)
        {
            var result = await _invoiceManager.GetInvoice(id);
            
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary> Возвращает список всех счетов.</summary>
        /// <returns>OK</returns>
        /// <response code="200">Запрос выполнен.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        [Authorize(Roles = "user, admin, manager")]
        [HttpGet("invoices")]
        public async Task<IActionResult> GetInvoices()
        {
            var result = await _invoiceManager.GetInvoices();
            return Ok(result);
        }


        /// <summary> Создает клиентский счет.</summary>
        /// <returns>OK</returns>
        /// <response code="200">Счет успешно сформирован.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера.</response>
        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] InvoiceRequest invoiceRequest)
        {
            var id = await _invoiceManager.CreateInvoice(invoiceRequest);
            return Ok(id);
        }

        /// <summary> Обновляет клиентский счет.</summary>
        /// <returns>OK</returns>
        /// <response code="200">Счет обновлен.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера.</response>
        [Authorize(Roles = "user, admin, manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] InvoiceRequest invoiceRequest)
        {
            await _invoiceManager.UpdateInvoice(id, invoiceRequest);

            return Ok();
        }

        /// <summary> Удаляет клиентский счет по Id.</summary>
        /// <response code="200">Счет удалён.</response>
        /// <response code="400">Ошибка в запросе.</response>
        /// <response code="401">Отсутствует авторизация.</response>
        /// <response code="403">Недостаточно прав для выполнения операции.</response>
        /// <response code="500">Внутренняя ошибка Сервера.</response>
        [Authorize(Roles = "admin, manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _invoiceManager.DeleteInvoice(id);

            return Ok();
        }
    }
}
