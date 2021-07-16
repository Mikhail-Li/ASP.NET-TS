using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models.Entities;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface ISheetManager
    {
        /// <summary> Возвращает экземпляр записи табеля </summary
        Task<Sheet> GetSheet(Guid id);

        /// <summary> Возвращает список записей табелей </summary>
        Task<IEnumerable<Sheet>> GetSheets();

        /// <summary> Добавляет запись табеля </summary>
        Task<Guid> CreateSheet(SheetRequest request);

        /// <summary> Обновляет запись табеля </summary>
        Task UpdateSheet(Guid id, SheetRequest request);

        /// <summary> Удаляет запись табеля </summary>
        Task DeleteSheet(Guid id);

        /// <summary> Подтверждает запись табеля </summary>
        Task ApproveSheet(Guid id);

        /// <summary> снимает подтверждение записи табеля </summary>
        Task UnApproveSheet(Guid id);

        /// <summary> Изменяет работника в записи табеля </summary>
        Task ChangeEmployee(Guid sheetId, Guid newEmployeeId);
    }
}