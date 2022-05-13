using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Repository
{
    public interface IEnrollmentRepository : IGenericRepository<Enrollment>
    {
        Task<Student> AddClasses(string enrollmentNumber, List<Guid> newClassesIds);
    }
}
