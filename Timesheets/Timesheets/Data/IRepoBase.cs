using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timesheets.Data
{
    public interface IRepoBase<T>
    {
        /// <summary>Возвращает экземпляр записи <T></summary>
        Task<T> GetItem(Guid id);

        /// <summary> Возвращает список записей <T> </summary>
        Task<IEnumerable<T>> GetItems();

        /// <summary> Добавляет запись <T> </summary>
        Task Add(T item);

        /// <summary> Обновляет запись <T> </summary>
        Task Update(T item);

        /// <summary> Удаляет запись <T> </summary>
        Task Delete(Guid id);
    }
}
