using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _rep;
        public StudentService(IStudentRepository repository)
        {
            _rep = repository;
        }
        public async Task<Student> AddStudent (Student student)
        {
            var resp = await _rep.AddStudent(student);
            return resp;
        }

        public async Task DeleteStudent(string id)
        {
            await _rep.DeleteStudent(id);
        }

        public async Task<Student> GetStudentById(string id)
        {
            var resp = await _rep.GetStudentById(id);
            return resp;
        }

        public async Task<Student> UpdateStudent(string id, Student student)
        {
            var resp = await _rep.UpdateStudent(id, student);
            return resp;
        }
    }
}
