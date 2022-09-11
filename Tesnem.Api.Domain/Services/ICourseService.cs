using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;

namespace Tesnem.Api.Domain.Services
{
    public interface ICourseService
    {
        Task<CourseResponse> AddCourse(CourseRequest course);
        Task<CourseResponse> UpdateCourse(Guid id, CourseRequest course);
        Task DeleteCourse(Guid id);
        Task<CourseResponse> GetCourseById(Guid id);
        Task<IEnumerable<CourseResponse>> GetCourseByProgramId(Guid ProgramId);
        Task<IEnumerable<CourseResponse>> GetAllCourses();
        Task<IEnumerable<Guid>> DeleteMultipleCourses(List<Guid> CourseIds);
    }
}
