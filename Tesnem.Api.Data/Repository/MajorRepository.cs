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
                    course.Classes = _appDbContext.Classes.Where(x => x.Course_Id == course.Id).ToList();
                    course.Students = _appDbContext.Students.Where(s => s.CoursesCurrent.Contains(course)).ToList();
                }
            }
            return majors;
        }
        public override async Task<ProgramMajor> GetById(Guid id)
        {
            var major = await _appDbContext.Majors.FindAsync(id);
            major.Courses = _appDbContext.Courses.Where(x => x.Program_Id == id).ToList();
            foreach (var course in major.Courses)
            {
                course.Classes = _appDbContext.Classes.Where(x => x.Course_Id == course.Id).ToList();
                course.Students = _appDbContext.Students.Where(s => s.CoursesCurrent.Contains(course)).ToList();
            }
            return major;
        }

    }
}
