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
    public class MajorRepository : GenericRepository<ProgramMajor>, IMajorRepository
    {
        private readonly AppDbContext _appDbContext;
        public MajorRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<ProgramMajor>> GetAllMajors()
        {
            var majors = _appDbContext.Majors
                .Include(l => l.Courses)
                .ToList();
            foreach (var major in majors)
            {
                foreach (var course in major.Courses)
                {
                    course.Classes = await _appDbContext.Classes.Where(x => x.Course.Id == course.Id).ToListAsync();
                    course.Students = await _appDbContext.Students.Where(s => s.CoursesCurrent.Contains(course)).ToListAsync();
                }
            }
            return majors;
        }
        public override async Task<ProgramMajor> GetById(Guid id)
        {
            var major = await _appDbContext.Majors.FindAsync(id);
            if (major == null)
            {
                throw new NotFoundException(ExceptionMessages.MajorNotFoundMessage, id);
            }
            
            major.Courses = await _appDbContext.Courses.Where(x => x.Program.Id == id).ToListAsync();
            
            if(!major.Courses.Any())
                major.Courses = new List<Course>();
            foreach (var course in major.Courses)
            {
                course.Classes = await _appDbContext.Classes.Where(x => x.Course.Id == course.Id).ToListAsync();
                course.Students = await _appDbContext.Students.Where(s => s.CoursesCurrent.Contains(course)).ToListAsync();

                if (!course.Students.Any())
                    course.Students = new List<Student>();
                if (!course.Classes.Any())
                    course.Classes = new List<Class>();
            }
            return major;
        }

    }
}
