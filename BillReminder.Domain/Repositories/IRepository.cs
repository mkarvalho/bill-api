using System;
using System.Collections.Generic;

namespace BillReminder.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        void Update(Guid id, T item);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByPeriod(DateTime date);
    }
}
