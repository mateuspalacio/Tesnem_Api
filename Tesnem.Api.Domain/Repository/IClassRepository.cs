using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Repository
{
    public interface IClassRepository : IGenericRepository<Class>
    {
        Task<IEnumerable<Class>> GetAllClasses();
        Task<IEnumerable<Class>> GetByCourseId(Guid courseId);
        Task<IEnumerable<Class>> GetByMajorId(Guid majorId);
    }
}
