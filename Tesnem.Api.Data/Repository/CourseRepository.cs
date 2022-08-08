using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.Exceptions;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;

namespace Tesnem.Api.Data.Repository
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly AppDbContext _appDbContext;
        public CourseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            var Courses = await _appDbContext.Courses
                .Include(c => c.Program)
                .Include(c => c.Students)
                .Include(c => c.Professors)
                .Include(c => c.Classes)
                .Include(c => c.Requirements)
                .ToListAsync();
            foreach (var course in Courses)
            {
                course.Classes = await _appDbContext.Classes.Where(x=>x.Course.Id == course.Id).ToListAsync();
                foreach (var classAux in course.Classes)
                {
                    classAux.Tests = await _appDbContext.Tests.Where(x => x.Class.Id == classAux.Id).ToListAsync();
                }
                course.Students = await _appDbContext.Students.Where(x => x.CoursesCurrent.Contains(course)).ToListAsync();
            }

            return Courses;
        }
        public async override Task<Course> GetById(Guid id)
        {
            var course = await _appDbContext.Courses
                .Include(c => c.Program)
                .Include(c => c.Students)
                .Include(c => c.Professors)
                .Include(c => c.Classes)
                .Include(c => c.Requirements)
                .FirstOrDefaultAsync(x=> x.Id == id);

            if (course == null)
            {
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, id);
            }
            
            if(course.Program == null)
            {
                throw new NotFoundException(ExceptionMessages.MajorNotFoundMessage, course.Program.Id);
            }

            ProgramMajor Program = await _appDbContext.Majors.FirstOrDefaultAsync(x => x.Id == course.Program.Id);
            course.Program = Program;
            course.Classes = await _appDbContext.Classes.Where(x => x.Course.Id == course.Id).ToListAsync();
            foreach(var classAux in course.Classes)
            {
                classAux.Tests = await _appDbContext.Tests.Where(x => x.Class.Id == classAux.Id).ToListAsync();
            }
            course.Students = await _appDbContext.Students.Where(x => x.CoursesCurrent.Contains(course)).ToListAsync();
            return course;
        }
        public async Task<Course> GetByProgramId(Guid programId)
        {
            var course = await _appDbContext.Courses
                .Include(c => c.Program)
                .Include(c => c.Students)
                .Include(c => c.Professors)
                .Include(c => c.Classes)
                .Include(c => c.Requirements)
                .FirstOrDefaultAsync(x => x.Program.Id == programId);

            if (course == null)
            {
                throw new NotFoundException(ExceptionMessages.CourseNotFoundWithMajorMessage, programId);
            }

            if (course.Program == null)
            {
                throw new NotFoundException(ExceptionMessages.MajorNotFoundMessage, programId);
            }

            ProgramMajor Program = await _appDbContext.Majors.FirstOrDefaultAsync(x => x.Id == programId);
            course.Program = Program;
            course.Classes = await _appDbContext.Classes.Where(x => x.Course.Id == course.Id).ToListAsync();
            foreach (var classAux in course.Classes)
            {
                classAux.Tests = await _appDbContext.Tests.Where(x => x.Class.Id == classAux.Id).ToListAsync();
            }
            course.Students = await _appDbContext.Students.Where(x => x.CoursesCurrent.Contains(course)).ToListAsync();

            return course;
        }
    }
}
