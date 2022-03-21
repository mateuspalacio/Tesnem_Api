using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Services
{
    public interface IStudentService
    {
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(string id, Student student);
        Task DeleteStudent(string id);
        Task<Student> GetStudentById(string id);
    }
}
