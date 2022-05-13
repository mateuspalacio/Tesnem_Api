using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Update(Guid id, T entity);
        Task Delete(T entity);
        Task<T> GetById(Guid id);
    }
}
