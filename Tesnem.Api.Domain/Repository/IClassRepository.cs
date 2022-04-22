using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Repository
{
    public interface IClassRepository
    {
        Task<Class> AddClass(Class classroom);
        Task<Class> UpdateClass(Guid id, Class classroom);
        Task DeleteClass(Guid id);
        Task<Class> GetClassById(Guid id);
    }
}
