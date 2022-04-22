using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Repository
{
    public interface ICourseRepository
    {
        Task<Course> AddCourse(Course course);
        Task<Course> UpdateCourse(Guid id, Course course);
        Task DeleteCourse(Guid id);
        Task<Course> GetCourseById(Guid id);
    }
}
