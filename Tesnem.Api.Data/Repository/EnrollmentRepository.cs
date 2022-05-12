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
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        private readonly AppDbContext _appDbContext;
        public EnrollmentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Student> AddClasses(string enrollmentNumber, List<Guid> newClassesIds)
        {
            var student = _appDbContext.Students.FirstOrDefault(y => y.Enrollment.EnrollmentNumber == enrollmentNumber);
            if (student is not null)
                student.Classes = _appDbContext.Classes.Where(x => x.Students.Contains(student)).ToList();
            else
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, enrollmentNumber);
            foreach (var newClassId in newClassesIds)
            {
                var classToAdd = _appDbContext.Classes.FirstOrDefault(x => x.Id == newClassId);
                if (classToAdd.Students == null)
                    classToAdd.Students = new List<Student>();
                _appDbContext.Classes.Update(classToAdd);
                if (student.Classes == null)
                    student.Classes = new List<Class>();
                if (student.Classes.Any(c =>c.Id == classToAdd.Id))
                    throw new ObjectAlredyPresentException(ExceptionMessages.StudentAlredyInClass, classToAdd.Id);
                student.Classes.Add(classToAdd);
            }
            _appDbContext.Students.Update(student);
            await _appDbContext.SaveChangesAsync();
            return student;
        }
    }
}
