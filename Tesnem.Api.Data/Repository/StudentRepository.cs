using Microsoft.EntityFrameworkCore;
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
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var students = _appDbContext.Students
                .Include(e => e.Classes)
                .Include(e => e.CoursesCompleted)
                .Include(e => e.CoursesCurrent)
                .Include(e => e.Enrollment)
                .Include(e => e.ProgramMajor);
            return students;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsByClass(Guid classId)
        {
            var students = _appDbContext.Students.Where(x => x.Classes.Any(y => y.Id == classId));
            return students;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsByCourse(Guid courseId)
        {
            var students = _appDbContext.Students.Where(x => x.CoursesCurrent.Any(y => y.Id == courseId));
            return students;
        }
    }
}
