using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timesheets.Data
{
    public interface IRepoBase<T>
    {
        /// <summary> Возвращает экземпляр записи</summary>
        Task<T> GetItem(Guid id);

        /// <summary> Возвращает список записей</summary>
        Task<IEnumerable<T>> GetItems();

        /// <summary> Добавляет запись</summary>
        Task Add(T item);

        /// <summary> Обновляет запись</summary>
        Task Update(T item);

        /// <summary> Удаляет запись</summary>
        Task Delete(Guid id);
    }
}
