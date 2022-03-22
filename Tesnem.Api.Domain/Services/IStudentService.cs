using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Services
{
    public interface IStudentService
    {
        Task<Student> AddStudent(StudentDto student);
        Task<Student> UpdateStudent(Guid id, StudentDto student);
        Task DeleteStudent(Guid id);
        Task<Student> GetStudentById(Guid id);
    }
}
