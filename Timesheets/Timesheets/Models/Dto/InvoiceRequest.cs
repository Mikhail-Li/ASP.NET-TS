using System;

namespace Timesheets.Models.Dto
{
    /// <summary> Информация для формирования или изменения счета.</summary>
    public class InvoiceRequest
    {
        public Guid ContractId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
