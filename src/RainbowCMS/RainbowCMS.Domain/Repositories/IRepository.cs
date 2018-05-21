using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RainbowCMS.Domain.Repositories
{
    public interface IRepository<T>
        where T : class, IAggregateRoot
    {
        T GetByID(Guid id);
        IEnumerable<T> GetBySpecification(Expression<Func<T, bool>> specification);
        void Save(T obj);
    }
}
