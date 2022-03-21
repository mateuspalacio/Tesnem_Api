using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Exceptions;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;

namespace Tesnem.Api.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Student> AddStudent(Student student)
        {
            var resp = await _appDbContext.Students.AddAsync(student);
            await _appDbContext.SaveChangesAsync();
            return resp.Entity;
        }

        public async Task DeleteStudent(string id)
        {
            var delete = _appDbContext.Students.FirstOrDefault(x => x.Id == id);
            if (delete != null)
                _appDbContext.Students.Remove(delete);
            else
                throw new ErrorException(new ErrorResponse { Message = "not found", StatusCode = 404 });
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Student> GetStudentById(string id)
        {
            var student = _appDbContext.Students.FirstOrDefault(x => x.Id == id);
            return student;
        }

        public async Task<Student> UpdateStudent(string id, Student student)
        {
            var toUpdate = _appDbContext.Students.FirstOrDefault(y => y.Id == id);
            if(toUpdate != null)
                _appDbContext.Update(student);
            else
                throw new ErrorException(new ErrorResponse { Message = "not found", StatusCode = 404 });
            return student;
        }
    }
}
