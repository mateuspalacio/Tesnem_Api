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
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;
        public CourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Course> AddCourse(Course course)
        {
            var resp = await _appDbContext.Courses.AddAsync(course);
            await _appDbContext.SaveChangesAsync();
            return resp.Entity;
        }

        public async Task DeleteCourse(Guid id)
        {
            var delete = _appDbContext.Courses.FirstOrDefault(x => x.Id == id);
            if (delete != null)
                _appDbContext.Courses.Remove(delete);
            else
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, id);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Course> GetCourseById(Guid id)
        {
            var course = _appDbContext.Courses.FirstOrDefault(x => x.Id == id);
            course.Classes = _appDbContext.Classes.Where(x => x.Course_Id == id).ToList();

            return course;
        }

        public async Task<Course> UpdateCourse(Guid id, Course course)
        {
            var toUpdate = _appDbContext.Courses.FirstOrDefault(y => y.Id == id);
            if (toUpdate != null)
            {
                toUpdate.Name = course.Name;
                toUpdate.Program = course.Program;
                _appDbContext.Update(toUpdate);
            }
            else
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, id);
            await _appDbContext.SaveChangesAsync();
            return course;
        }
    }
}
