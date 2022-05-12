using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Repository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<IEnumerable<Student>> GetAllStudentsByClass(Guid classId);
        Task<IEnumerable<Student>> GetAllStudentsByCourse(Guid courseId);


    }
}
