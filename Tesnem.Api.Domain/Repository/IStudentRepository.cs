using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Repository
{
    public interface IStudentRepository
    {
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Guid id, Student student);
        Task DeleteStudent(Guid id);
        Task<Student> GetStudentById(Guid id);
    }
}
