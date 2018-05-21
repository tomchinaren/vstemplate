using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RainbowCMS.Domain.Model;

namespace RainbowCMS.Domain.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private Dictionary<Guid, Customer> repository = new Dictionary<Guid, Customer>();

        #region IRepository<Customer> Members

        public Customer GetByID(Guid id)
        {
            if (repository.ContainsKey(id))
                return repository[id];
            return null;
        }

        public IEnumerable<Customer> GetBySpecification(Expression<Func<Customer, bool>> specification)
        {
            return repository.Values.Where(specification.Compile());
        }

        public void Save(Customer obj)
        {
            if (!repository.ContainsKey(obj.ID))
                repository.Add(obj.ID, obj);
            repository[obj.ID] = obj;
        }

        #endregion
    }
}
