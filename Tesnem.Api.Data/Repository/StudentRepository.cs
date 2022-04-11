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

        public async Task DeleteStudent(Guid id)
        {
            var delete = _appDbContext.Students.FirstOrDefault(x => x.Id == id);
            if (delete != null)
                _appDbContext.Students.Remove(delete);
            else
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Student> GetStudentById(Guid id)
        {
            var student = _appDbContext.Students.FirstOrDefault(x => x.Id == id);
            student.Classes = _appDbContext.Classes.Where(x => x.Students.Contains(student)).ToList();
            return student;
        }

        public async Task<Student> UpdateStudent(Guid id, Student student)
        {
            var toUpdate = _appDbContext.Students.FirstOrDefault(y => y.Id == id);
            if(toUpdate != null)
            {
                toUpdate.Name = student.Name;
                toUpdate.Data = student.Data;
                toUpdate.ProgramMajor = student.ProgramMajor;
                _appDbContext.Update(toUpdate);
            }
            else
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
            await _appDbContext.SaveChangesAsync();
            return student;
        }
    }
}
