using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR.Domain.Interfaces.Persistence
{
    public interface IGenericRepository<T>
    {
        public abstract Task<IEnumerable<T>> All();
        public abstract Task<T> GetById(int id);
        public abstract Task<bool> Add(T entity);
        public abstract Task<bool> Delete(int id);
    }
}
