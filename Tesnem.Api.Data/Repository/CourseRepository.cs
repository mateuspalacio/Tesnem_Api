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
            var Courses = _appDbContext.Courses
                .Include(c => c.Program)
                .Include(c => c.Students)
                .Include(c => c.Professors)
                .Include(c => c.Classes)
                .Include(c => c.Requirements)
                .ToList();
            foreach (var course in Courses)
            {
                ProgramMajor Program = _appDbContext.Majors.FirstOrDefault(x => x.Id == course.Program_Id);
                course.Program = Program;
                course.Classes = _appDbContext.Classes.Where(x=>x.Course_Id==course.Id).ToList();
                /*foreach (var classAux in course.Classes)
                {
                    classAux.Tests = _appDbContext.Tests.Where(x => x.ClassId == classAux.Id).ToList();
                }*/
            }
            return Courses;
        }
        public async override Task<Course> GetById(Guid id)
        {
            var course = _appDbContext.Courses
                .Include(c => c.Program)
                .Include(c => c.Students)
                .Include(c => c.Professors)
                .Include(c => c.Classes)
                .Include(c => c.Requirements)
                .FirstOrDefault(x=> x.Id == id);
            
            ProgramMajor Program = _appDbContext.Majors.FirstOrDefault(x => x.Id == course.Program_Id);
            course.Program = Program;
            course.Classes = _appDbContext.Classes.Where(x => x.Course_Id == course.Id).ToList();
            foreach(var classAux in course.Classes)
            {
                classAux.Tests = _appDbContext.Tests.Where(x => x.ClassId == classAux.Id).ToList();
            }

            return course;
        }
        public async Task<Course> GetByProgramId(Guid programId)
        {
            var course = _appDbContext.Courses
                .Include(c => c.Program)
                .Include(c => c.Students)
                .Include(c => c.Professors)
                .Include(c => c.Classes)
                .Include(c => c.Requirements)
                .FirstOrDefault(x => x.Program_Id == programId);

            ProgramMajor Program = _appDbContext.Majors.FirstOrDefault(x => x.Id == course.Program_Id);
            course.Program = Program;
            course.Classes = _appDbContext.Classes.Where(x => x.Course_Id == course.Id).ToList();
            foreach (var classAux in course.Classes)
            {
                classAux.Tests = _appDbContext.Tests.Where(x => x.ClassId == classAux.Id).ToList();
            }

            return course;
        }
    }
}
