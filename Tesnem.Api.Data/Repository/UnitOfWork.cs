using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Repository;

namespace Tesnem.Api.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public IClassRepository Classes {get;}

        public ICourseRepository Courses { get; }

        public IEnrollmentRepository Enrollments { get; }

        public IMajorRepository Majors { get; }

        public IProfessorRepository Professors { get; }

        public IStudentRepository Students { get; }

        public UnitOfWork(AppDbContext dbContext, IClassRepository classRepository, ICourseRepository courseRepository, IEnrollmentRepository enrollmentRepository, IMajorRepository majorRepository, IProfessorRepository professorRepository, IStudentRepository studentRepository)
        {
            _appDbContext = dbContext;
            Classes = classRepository;
            Courses = courseRepository;
            Enrollments = enrollmentRepository;
            Majors = majorRepository;
            Professors = professorRepository;
            Students = studentRepository;
        }

        public int Complete()
        {
            return _appDbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _appDbContext.Dispose();
            }
        }
    }
}
